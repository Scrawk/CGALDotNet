using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Processing;
using CGALDotNet.Polygons;
using CGALDotNet.Extensions;

namespace CGALDotNet.Polyhedra
{

    /// <summary>
    /// A polyhedral surface consists of vertices, edges, 
    /// facets and an incidence relation on them.
    ///  Each edge is represented by two halfedges with opposite orientations.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class Polyhedron3<K> : Polyhedron3 where K : CGALKernel, new()
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Polyhedron3() : base(new K())
        {

        }

        /// <summary>
        /// Construct from points and triangle indices.
        /// </summary>
        public Polyhedron3(Point3d[] points, int[] triangles) : base(new K())
        {
            CreateMesh(points, triangles);
        }

        /// <summary>
        /// Construct from points and polygon indices.
        /// </summary>
        public Polyhedron3(Point3d[] points, PolygonalIndices indices) : base(new K())
        {
            CreatePolygonalMesh(points, points.Length, indices);
        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The meshs pointer.</param>
        internal Polyhedron3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polyhdron as a string.
        /// </summary>
        /// <returns>The mesh as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Polyhedron3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FaceCount={3}]",
                Kernel.Name, VertexCount, HalfedgeCount, FaceCount);
        }

        /// <summary>
        /// Create a deep copy of the mesh.
        /// </summary>
        /// <returns>A deep copy of the mesh.</returns>
        public Polyhedron3<K> Copy()
        {
            return new Polyhedron3<K>(Kernel.Copy(Ptr));
        }

        /// <summary>
        /// Subdive the mesh.
        /// </summary>
        /// <param name="iterations">The number of iterations to perfrom.</param>
        /// <param name="method">The subdivision method.</param>
        public override void Subdivide(int iterations, SUBDIVISION_METHOD method = SUBDIVISION_METHOD.SQRT3)
        {
            try
            {
                var sub = SubdivisionSurface<K>.Instance;
                sub.Subdivide(method, this, iterations);
                IsUpdated = false;
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };
        }

        /// <summary>
        /// Simplify the polyhedra.
        /// </summary>
        /// <param name="stop_ratio">A number between 0-1 that represents the percentage of vertices to remove.</param>
        public override void Simplify(double stop_ratio)
        {
            try
            {
                var sim = SurfaceSimplification<K>.Instance;
                sim.Simplify(this, stop_ratio);
                IsUpdated = false;
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };
        }

        /// <summary>
        /// Refines a triangle mesh
        /// </summary>
        /// <param name="density_control_factor">a factor to control density of the output mesh, 
        /// where larger values lead to denser refinements. Defalus to sqrt of 2.</param>
        /// <returns>The number of new vertices.</returns>
        public override int Refine(double density_control_factor = MathUtil.SQRT2_64)
        {
            try
            {
                IsUpdated = false;
                var meshing = MeshProcessingMeshing<K>.Instance;
                return meshing.Refine(this, density_control_factor);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };

            return 0;
        }

        /// <summary>
        /// Orient the faces in the mesh.
        /// </summary>
        /// <param name="oriente">The orientation method.</param>
        public override void Orient(ORIENTATE oriente)
        {
            try
            {
                IsUpdated = false;
                var orient = MeshProcessingOrientation<K>.Instance;
                orient.Orient(oriente, this);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };
        }

        /// <summary>
        /// Reverses the orientation of the vertices in each face.
        /// </summary>
        public override void ReverseFaceOrientation()
        {
            Orient(ORIENTATE.REVERSE_FACE_ORIENTATIONS);
        }

        /// <summary>
        /// Split the mesh into its unconnected components.
        /// </summary>
        /// <param name="results">Each unconnect component as a new mesh.</param>
        public void Split(List<Polyhedron3<K>> results)
        {
            try
            {
                var con = MeshProcessingConnections<K>.Instance;
                con.SplitUnconnectedComponents(this, results);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };
        }

        /// <summary>
        /// Remove all unconnected compontents except the largest.
        /// Largest is defined by the face count.
        /// </summary>
        /// <param name="num_components_to_keep">The numbero of largest components to keep.</param>
        /// <returns>The number of components removed in the mesh.</returns>
        public override int KeepLargest(int num_components_to_keep = 1)
        {
            try
            {
                var con = MeshProcessingConnections<K>.Instance;
                return con.KeepLargestComponents(this, num_components_to_keep);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };

            return 0;
        }

        /// <summary>
        /// Create a mesh consisting of one polygon face.
        /// </summary>
        /// <param name="polygon">The faces polygon.</param>
        /// <param name="xz">Should the y coord of the points be used for the z coord.</param>
        /// <exception cref="InvalidOperationException">Thrown if the polygon is not simple.</exception>
        public void CreatePolygonMesh(Polygon2<K> polygon, bool xz)
        {
            if (!polygon.IsSimple)
                throw new InvalidOperationException("Polygon must be simple to convert to mesh mesh.");

            var points = polygon.ToArray();
            CreatePolygonMesh(points, points.Length, xz);  
        }

        /// <summary>
        /// Create the dual mesh where each face becomes a vertex
        /// and each vertex becomes a face.
        /// Must be a valid closed mesh to create the dual.
        /// </summary>
        /// <returns>The duel mesh.</returns>
        /// <exception cref="InvalidOperationException">Is thrown if the mesh is not a valid closed mesh.</exception>
        public Polyhedron3<K> Dual()
        {
            if (!IsValidClosedMesh)
                throw new InvalidOperationException("Mesh must be a valid closed mesh to create a dual mesh.");

            int faceCount = FaceCount;
            var points = new Point3d[faceCount];
            GetCentroids(points, faceCount);

            var indices = GetDualPolygonalIndices();

            var dual = new Polyhedron3<K>();
            dual.CreatePolygonalMesh(points, points.Length, indices);

            return dual;
        }

        /// <summary>
        /// Convert to a surface mesh.
        /// </summary>
        /// <returns>The surface mesh.</returns>
        public SurfaceMesh3<K> ToSurfaceMesh()
        {
            var points = new Point3d[VertexCount];
            GetPoints(points, points.Length);

            var indices = GetPolygonalIndices();
     
            var mesh = new SurfaceMesh3<K>();
            mesh.CreatePolygonalMesh(points, points.Length, indices);

            return mesh;
        }

        /// <summary>
        /// Find the min, max and average edge lengths in the mesh
        /// </summary>
        /// <returns>The min, max and average edge lengths in the mesh.</returns>
        public override MinMaxAvg FindMinMaxAvgEdgeLength()
        {
            try
            {
                var fea = MeshProcessingFeatures<K>.Instance;
                return fea.EdgeLengthMinMaxAvg(this);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };

            return new MinMaxAvg();
        }

        /// <summary>
        /// Find the min, max and average face areas in the mesh
        /// </summary>
        /// <returns>The min, max and average face areas in the mesh.</returns>
        public override MinMaxAvg FindMinMaxAvgFaceArea()
        {
            try
            {
                var fea = MeshProcessingFeatures<K>.Instance;
                return fea.FaceAreaMinMaxAvg(this);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };

            return new MinMaxAvg();
        }

        /// <summary>
        /// Locate the face the rays hits.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <returns>The hit result.</returns>
        public override MeshHitResult LocateFace(Ray3d ray)
        {
            try
            {
                var locate = MeshProcessingLocate<K>.Instance;
                return locate.LocateFace(this, ray);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };

            return MeshHitResult.NoHitResult;
        }

        /// <summary>
        /// Find the face closest to the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The hit result.</returns>
        public override MeshHitResult ClosestFace(Point3d point)
        {
            try
            {
                var locate = MeshProcessingLocate<K>.Instance;
                return locate.ClosestFace(this, point);
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };

            return MeshHitResult.NoHitResult;
        }

    }

    /// <summary>
    /// The abstract polyhedra definition.
    /// </summary>
    public abstract class Polyhedron3 : CGALObject, IMesh
    {
        /// <summary>
        /// Cached values found by running Update.
        /// </summary>
        private bool m_isValid;
        private bool m_isClosed;
        private bool m_isTriangle;
        private bool m_isQuad;

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Polyhedron3()
        {

        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The mesh kernel.</param>
        internal Polyhedron3(CGALKernel kernel)
        {
            Kernel = kernel.PolyhedronKernel3;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The mesh kernel.</param>
        /// <param name="ptr">The meshs pointer.</param>
        internal Polyhedron3(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolyhedronKernel3;
        }

        /// <summary>
        /// The mesh kernel.
        /// Contains the functions to the unmanaged CGAL polhedron.
        /// </summary>
        protected private PolyhedronKernel3 Kernel { get; private set; }

        /// <summary>
        /// Number of vertices.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// Number of faces.
        /// </summary>
        public int FaceCount => Kernel.FaceCount(Ptr);

        /// <summary>
        /// Number of half edges.
        /// </summary>
        public int HalfedgeCount => Kernel.HalfEdgeCount(Ptr);

        /// <summary>
        /// Number of border edges.
        /// Since each border edge of a polyhedral surface has exactly one 
        /// border halfedge, this number is equal to size of border halfedges.
        /// </summary>
        public int BorderEdgeCount => Kernel.BorderEdgeCount(Ptr);

        /// <summary>
        /// Number of border halfedges.
        /// </summary>
        public int BorderHalfEdgeCount => Kernel.BorderHalfEdgeCount(Ptr);

        /// <summary>
        /// The current build stamp.
        /// </summary>
        public int BuildStamp => Kernel.GetBuildStamp(Ptr);

        /// <summary>
        /// Returns true if the polyhedral surface is combinatorially consistent.
        /// Must be a valid mesh to check many other properties.
        /// </summary>
        public bool IsValid
        {
            get
            {
                Update();
                return m_isValid;
            }
            protected set
            {
                m_isValid = value;
            }
        }

        /// <summary>
        /// Returns true if there are no border edges.
        /// </summary>
        public bool IsClosed
        {
            get
            {
                Update();
                return m_isClosed;
            }
            protected set
            {
                m_isClosed = value;
            }
        }

        /// <summary>
        /// Returns true if all faces are triangles.
        /// </summary>
        public bool IsTriangle
        {
            get
            {
                Update();
                return m_isTriangle;
            }
            protected set
            {
                m_isTriangle = value;
            }
        }

        /// <summary>
        /// Returns true if all faces are quads.
        /// </summary>
        public bool IsQuad
        {
            get
            {
                Update();
                return m_isQuad;
            }
            protected set
            {
                m_isQuad = value;
            }
        }

        /// <summary>
        /// Is the mesh a valid triangle mesh.
        /// </summary>
        public bool IsValidTriangleMesh => IsValid && IsTriangle;

        /// <summary>
        /// Is the mesh a valid closed mesh.
        /// </summary>
        public bool IsValidClosedMesh => IsValid && IsClosed;

        /// <summary>
        /// Is the mesh a valid closed triangle mesh.
        /// </summary>
        public bool IsValidClosedTriangleMesh => IsValid && IsClosed && IsTriangle;

        /// <summary>
        /// Has the update function been called.
        /// </summary>
        protected bool IsUpdated { get; set; }

        /// <summary>
        /// Mark th mesh as needing to be updated.
        /// </summary>
        public void SetIsUpdatedToFalse()
        {
            IsUpdated = false;
        }

        /// <summary>
        /// Clear the mesh.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// Clear the index maps.
        /// The index maps are used to access the meshes elemnts by index.
        /// They are automaticaly created when a elements is accessed
        /// be a function requiring it.
        /// </summary>
        /// <param name="vertices">True to clear the vertex index map.</param>
        /// <param name="faces">True to clear the face index map.</param>
        /// <param name="edges">True to clear the edges index map.</param>
        public void ClearIndexMaps(bool vertices, bool faces, bool edges)
        {
            Kernel.ClearIndexMaps(Ptr, vertices, faces, edges);
        }

        /// <summary>
        /// Clear the normal maps.
        /// </summary>
        /// <param name="vertices">True to clear the vertex normal map.</param>
        /// <param name="faces">True to clear the face normal map</param>
        public void ClearNormalMaps(bool vertices, bool faces)
        {
            Kernel.ClearNormalMaps(Ptr, vertices, faces);
        }

        /// <summary>
        /// Builds the vertex and/or face index maps if needed.
        /// </summary>
        /// <param name="vertices">True to build the vertex index map.</param>
        /// <param name="faces">True to build the face index map.</param>
        /// <param name="edges">True to build the face index map.</param>
        /// <param name="force">True to force the build even if already built.</param>
        public void BuildIndices(bool vertices, bool faces, bool edges, bool force = false)
        {
            Kernel.BuildIndices(Ptr, vertices, faces, edges, force);
        }

        /// <summary>
        /// A tetrahedron is added to the polyhedral surface
        /// with its vertices initialized to p1, p2, p3, and p4.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="p4"></param>
        /// <returns>A edge in the tetrahdron.</returns>
        public int MakeTetrahedron(Point3d p1, Point3d p2, Point3d p3, Point3d p4)
        {
            IsUpdated = false;
            return Kernel.MakeTetrahedron(Ptr, p1, p2, p3, p4);
        }

        /// <summary>
        /// A triangle with border edges is added to the 
        /// polyhedral surface with its vertices initialized to p1, p2, and p3.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <returns>A edge in the triangle.</returns>
        public int MakeTriangle(Point3d p1, Point3d p2, Point3d p3)
        {
            IsUpdated = false;
            return Kernel.MakeTriangle(Ptr, p1, p2, p3);
        }

        /// <summary>
        /// Create a mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="triangles">The meshes triangles as a index array. Maybe null.</param>
        /// <param name="quads">The meshes quads as a index array. Maybe null.</param>
        public void CreateMesh(Point3d[] points, int[] triangles, int[] quads = null)
        {
            bool hasTriangles = triangles != null && triangles.Length > 0;
            bool hasQuads = quads != null && quads.Length > 0;

            if (hasTriangles && hasQuads)
                CreateTriangleQuadMesh(points, points.Length, triangles, triangles.Length, quads, quads.Length);
            else if (hasTriangles)
                CreateTriangleMesh(points, points.Length, triangles, triangles.Length);
            else if (hasQuads)
                CreateQuadMesh(points, points.Length, quads, quads.Length);
        }

        /// <summary>
        /// Create a triangle mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="pointCount">The point arrays length.</param>
        /// <param name="indices">The meshes trinagles as a index array.</param>
        /// <param name="indexCount">The indices array length.</param>
        public void CreateTriangleMesh(Point3d[] points, int pointCount, int[] indices, int indexCount)
        {
            ErrorUtil.CheckArray(points, pointCount);
            ErrorUtil.CheckArray(indices, indexCount);

            Clear();
            IsUpdated = false;
            Kernel.CreatePolygonalMesh(Ptr, points, pointCount, indices, indexCount, null, 0, null, 0, null, 0);
        }

        /// <summary>
        /// Create a quad mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="pointCount">The point arrays length.</param>
        /// <param name="indices">The meshes trinagles as a index array.</param>
        /// <param name="indexCount">The indices array length.</param>
        public void CreateQuadMesh(Point3d[] points, int pointCount, int[] indices, int indexCount)
        {
            ErrorUtil.CheckArray(points, pointCount);
            ErrorUtil.CheckArray(indices, indexCount);

            Clear();
            IsUpdated = false;
            Kernel.CreatePolygonalMesh(Ptr, points, pointCount, null, 0, indices, indexCount, null, 0, null, 0);
        }

        /// <summary>
        /// Create a mesh with quads and triangles.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="pointsCount">The point array length.</param>
        /// <param name="triangles">The meshes triangles.</param>
        /// <param name="triangleCount">The triangle array length.</param>
        /// <param name="quads">The meshes quads.</param>
        /// <param name="quadsCount">The quads array length.</param>
        public void CreateTriangleQuadMesh(Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadsCount)
        {
            ErrorUtil.CheckArray(points, pointsCount);
            ErrorUtil.CheckArray(triangles, triangleCount);
            ErrorUtil.CheckArray(quads, quadsCount);

            Clear();
            IsUpdated = false;
            Kernel.CreatePolygonalMesh(Ptr, points, pointsCount, triangles, triangleCount, quads, quadsCount, null, 0, null, 0);
        }

        /// <summary>
        /// Create a mesh with riangles, quads, pentagons and hexagons.
        /// </summary>
        /// <param name="points">The meshs points.</param>
        /// <param name="pointsCount">The length of the point array.</param>
        /// <param name="indices">The faces indices.</param>
        public void CreatePolygonalMesh(Point3d[] points, int pointsCount, PolygonalIndices indices)
        {
            ErrorUtil.CheckArray(points, pointsCount);
            ErrorUtil.CheckArray(indices.triangles, indices.triangleCount);
            ErrorUtil.CheckArray(indices.quads, indices.quadCount);
            ErrorUtil.CheckArray(indices.pentagons, indices.pentagonCount);
            ErrorUtil.CheckArray(indices.hexagons, indices.hexagonCount);

            Clear();
            IsUpdated = false;
            Kernel.CreatePolygonalMesh(Ptr, points, pointsCount, 
                indices.triangles, indices.triangleCount,
                indices.quads, indices.quadCount,
                indices.pentagons, indices.pentagonCount,
                indices.hexagons, indices.hexagonCount);
        }

        /// <summary>
        /// Create a mesh consisting of one polygon face.
        /// </summary>
        /// <param name="points">The faces points</param>
        /// <param name="count">The point array length.</param>
        /// <param name="xz">Should the y coord of the points be used for the z coord.</param>
        public void CreatePolygonMesh(Point2d[] points, int count, bool xz)
        {
            ErrorUtil.CheckArray(points, count);

            Clear();
            IsUpdated = false;
            Kernel.CreatePolygonMesh(Ptr, points, count, xz);
        }

        /// <summary>
        /// Get the triangle and quad indices.
        /// </summary>
        /// <param name="triangles">The meshes triangles as a index array. Maybe null.</param>
        /// <param name="quads">The meshes quads as a index array. Maybe null.</param>
        public void GetIndices(int[] triangles, int[] quads = null)
        {
            bool hasTriangles = triangles != null && triangles.Length > 0;
            bool hasQuads = quads != null && quads.Length > 0;

            if (hasTriangles && hasQuads)
                GetTriangleQuadIndices(triangles, triangles.Length, quads, quads.Length);
            else if (hasTriangles)
                GetTriangleIndices(triangles, triangles.Length);
            else if (hasQuads)
                GetQuadIndices(quads, quads.Length);
        }

        /// <summary>
        /// Get the meshes triangles.
        /// </summary>
        /// <param name="triangles">The meshes triangles.</param>
        /// <param name="trianglesCount">The triangle array length.</param>
        public void GetTriangleIndices(int[] triangles, int trianglesCount)
        {
            ErrorUtil.CheckArray(triangles, trianglesCount);
            Kernel.GetPolygonalIndices(Ptr, triangles, trianglesCount, null, 0, null, 0, null, 0);
        }

        /// <summary>
        /// Get the meshes quads.
        /// </summary>
        /// <param name="quads">The meshes quads.</param>
        /// <param name="quadsCount">The quads array length.</param>
        public void GetQuadIndices(int[] quads, int quadsCount)
        {
            ErrorUtil.CheckArray(quads, quadsCount);
            Kernel.GetPolygonalIndices(Ptr, null, 0, quads, quadsCount, null, 0, null, 0);
        }

        /// <summary>
        /// Get the meshes triangles and quads.
        /// </summary>
        /// <param name="triangles">The meshes triangles.</param>
        /// <param name="trianglesCount">The triangle array length.</param>
        /// <param name="quads">The meshes quads.</param>
        /// <param name="quadsCount">The quads array length.</param>
        public void GetTriangleQuadIndices(int[] triangles, int trianglesCount, int[] quads, int quadsCount)
        {
            ErrorUtil.CheckArray(triangles, trianglesCount);
            ErrorUtil.CheckArray(quads, quadsCount);
            Kernel.GetPolygonalIndices(Ptr, triangles, trianglesCount, quads, quadsCount, null, 0, null, 0);
        }

        /// <summary>
        /// Get the meshes triangles, quads, pentagons and hexagons.
        /// </summary>
        /// <returns>The indices.</returns>
        public PolygonalIndices GetPolygonalIndices()
        {
            var count = GetPolygonalCount();
            var indices = count.Indices();

            Kernel.GetPolygonalIndices(Ptr, 
                indices.triangles, indices.triangleCount, 
                indices.quads, indices.quadCount,
                indices.pentagons, indices.pentagonCount,
                indices.hexagons, indices.hexagonCount);

            return indices;
        }


        /// <summary>
        /// Get the dual meshes triangles, quads, pentagons and hexagons.
        /// A dual mesh is were faces become vertices and vertices become faces.
        /// </summary>
        /// <returns>The indices</returns>
        public PolygonalIndices GetDualPolygonalIndices()
        {
            var count = GetDualPolygonalCount();
            var indices = count.Indices();

            Kernel.GetDualPolygonalIndices(Ptr,
                indices.triangles, indices.triangleCount,
                indices.quads, indices.quadCount,
                indices.pentagons, indices.pentagonCount,
                indices.hexagons, indices.hexagonCount);

            return indices;
        }

        /// <summary>
        /// Array accessor for the polygon.
        /// Getting a point wraps around the polygon.
        /// </summary>
        /// <param name="i">The points index.</param>
        /// <returns>The vertices point.</returns>
        public Point3d this[int i]
        {
            get => GetPoint(i);
            set => SetPoint(i, value);
        }

        /// <summary>
        /// Get the vertices point.
        /// </summary>
        /// <param name="index">The vertex index in the mesh.</param>
        /// <returns>The vertices point.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If index is out of range.</exception>
        public Point3d GetPoint(int index)
        {
            if (index < 0 || index >= VertexCount)
                throw new ArgumentOutOfRangeException("Index must be a number >= 0 and < count");

            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get the point at the index
        /// and wrap around the polygon.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <returns>The point at the index.</returns>
        public Point3d GetPointWrapped(int index)
        {
            index = MathUtil.Wrap(index, VertexCount);
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get the point at the index
        /// and clamp to the polygons last point.
        /// </summary>
        /// <param name="index">The points index.</param>
        /// <returns>The point at the index.</returns>
        public Point3d GetPointClamped(int index)
        {
            index = MathUtil.Clamp(index, 0, VertexCount - 1);
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get the vertices point but wraps the index.
        /// </summary>
        /// <param name="index">The vertex index in the mesh.</param>
        /// <returns>The vertices point.</returns>
        public Point3d GetPointClamp(int index)
        {
            index = MathUtil.Wrap(index, VertexCount);
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get the points in the mesh.
        /// </summary>
        /// <param name="points">The array to copy points into.</param>
        /// <param name="count">The point array length.</param>
        public void GetPoints(Point3d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
        }

        /// <summary>
        /// Set the point at the index.
        /// </summary>
        /// <param name="index">The points index</param>
        /// <param name="point">The points</param>am>
        /// <exception cref="ArgumentOutOfRangeException">If index is out of range.</exception>
        public void SetPoint(int index, Point3d point)
        {
            if (index < 0 || index >= VertexCount)
                throw new ArgumentOutOfRangeException("Index must be a number >= 0 and < count");

            IsUpdated = false;
            Kernel.SetPoint(Ptr, index, point);
        }

        /// <summary>
        /// Set the points from a array.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The point arrays length.</param>
        public void SetPoints(Point3d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            IsUpdated = false;
            Kernel.SetPoints(Ptr, points, count);
        }

        /// <summary>
        /// Get a halfedges segment.
        /// </summary>
        /// <param name="index">The halfedges index.</param>
        /// <param name="segment">The segment.</param>
        /// <returns>True if halfedge found.</returns>
        public bool GetSegment(int index, out Segment3d segment)
        {
            return Kernel.GetSegment(Ptr, index, out segment);
        }

        /// <summary>
        /// Get the segment.
        /// </summary>
        /// <param name="index">The segment index.</param>
        /// <returns>The segment</returns>
        /// <exception cref="ArgumentException">If segmentwith the index not found.</exception>
        public Segment3d GetSegment(int index)
        {
            if (GetSegment(index, out Segment3d seg))
                return seg;
            else
                throw new ArgumentException("Cound not get segment " + index);
        }

        /// <summary>
        /// Get a segment for  each halfedge in the mesh.
        /// </summary>
        /// <param name="segments">The segment array.</param>
        /// <param name="count">The segment array length.</param>
        public void GetSegments(Segment3d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);
            Kernel.GetSegments(Ptr, segments, count);
        }

        /// <summary>
        /// Get the faces triangle. 
        /// Presumes face is a triangle with no checks.
        /// </summary>
        /// <param name="index">The faces index.</param>
        /// <param name="triangle">The faces triangle</param>
        /// <returns></returns>
        public bool GetTriangle(int index, out Triangle3d triangle)
        {
            return Kernel.GetTriangle(Ptr, index, out triangle);
        }

        /// <summary>
        /// Get the triangle.
        /// </summary>
        /// <param name="index">The triangle index.</param>
        /// <returns>The triangle</returns>
        /// <exception cref="ArgumentException">If triangle with the index not found.</exception>
        public Triangle3d GetTriangle(int index)
        {
            if (GetTriangle(index, out Triangle3d tri))
                return tri;
            else
                throw new ArgumentException("Cound not get triangle " + index);
        }

        /// <summary>
        /// Get a triangle for each face in the mesh.
        /// Presumes all faces are triangles with no checks.
        /// </summary>
        /// <param name="triangles">The trainagle array.</param>
        /// <param name="count">The traingle  arrays length.</param>
        public void GetTriangles(Triangle3d[] triangles, int count)
        {
            ErrorUtil.CheckArray(triangles, count);
            Kernel.GetTriangles(Ptr, triangles, count);
        }

        /// <summary>
        /// Get the mesh vertex.
        /// </summary>
        /// <param name="index">The vertices index.</param>
        /// <param name="vertex">The vertex.</param>
        /// <returns>True if the vertex was found.</returns>
        public bool GetVertex(int index, out MeshVertex3 vertex)
        {
            return Kernel.GetVertex(Ptr, index, out vertex);
        }

        /// <summary>
        /// Get the mesh vertex.
        /// </summary>
        /// <param name="index">The vertexs index.</param>
        /// <returns>The vertexs</returns>
        /// <exception cref="ArgumentException">If vertex with the index not found.</exception>
        public MeshVertex3 GetVertex(int index)
        {
            if (GetVertex(index, out MeshVertex3 vertex))
                return vertex;
            else
                throw new ArgumentException("Cound not get vertex " + index);
        }

        /// <summary>
        /// Get the vertices in the mesh.
        /// </summary>
        /// <param name="vertices">The vertex array.</param>
        /// <param name="count">The vertex array length.</param>
        public void GetVertices(MeshVertex3[] vertices, int count)
        {
            ErrorUtil.CheckArray(vertices, count);
            Kernel.GetVertices(Ptr, vertices, count);
        }

        /// <summary>
        /// Get the mesh face.
        /// </summary>
        /// <param name="index">The faces index.</param>
        /// <param name="face">The face.</param>
        /// <returns>True if the face was found.</returns>
        public bool GetFace(int index, out MeshFace3 face)
        {
            return Kernel.GetFace(Ptr, index, out face);
        }

        /// <summary>
        /// Get the mesh face.
        /// </summary>
        /// <param name="index">The faces index.</param>
        /// <returns>The faces</returns>
        /// <exception cref="ArgumentException">If face with the index not found.</exception>
        public MeshFace3 GetFace(int index)
        {
            if(GetFace(index, out MeshFace3 face))
                return face;
            else
                throw new ArgumentException("Cound not get face " + index);
        }

        /// <summary>
        /// Get the faces in the mesh.
        /// </summary>
        /// <param name="faces">The face array.</param>
        /// <param name="count">The face array length.</param>
        public void GetFaces(MeshFace3[] faces, int count)
        {
            ErrorUtil.CheckArray(faces, count);
            Kernel.GetFaces(Ptr, faces, count);
        }

        /// <summary>
        /// Get the mesh halfedge.
        /// </summary>
        /// <param name="index">The halfedges index.</param>
        /// <param name="halfedge">The halfedge.</param>
        /// <returns>True if the halfedge was found.</returns>
        public bool GetHalfedge(int index, out MeshHalfedge3 halfedge)
        {
            return Kernel.GetHalfedge(Ptr, index, out halfedge);
        }

        /// <summary>
        /// Get the mesh Halfedge.
        /// </summary>
        /// <param name="index">The Halfedges index.</param>
        /// <returns>The Halfedges</returns>
        /// <exception cref="ArgumentException">If Halfedge with the index not found.</exception>
        public MeshHalfedge3 GetHalfedge(int index)
        {
            if (GetHalfedge(index, out MeshHalfedge3 Halfedge))
                return Halfedge;
            else
                throw new ArgumentException("Cound not get Halfedge " + index);
        }

        /// <summary>
        /// Get the halfedges in the mesh.
        /// </summary>
        /// <param name="halfedges">The halfedge array.</param>
        /// <param name="count">The halfedge array length.</param>
        public void GetHalfedges(MeshHalfedge3[] halfedges, int count)
        {
            ErrorUtil.CheckArray(halfedges, count);
            Kernel.GetHalfedges(Ptr, halfedges, count);
        }

        /// <summary>
        /// Count the number of triangles, quads and polygons in the mesh.
        /// </summary>
        /// <returns>The number of triangles, quads and polygons in the mesh.</returns>
        public PolygonalCount GetPolygonalCount()
        {
            return Kernel.GetPolygonalCount(Ptr);
        }

        /// <summary>
        /// Count the number of triangles, quads and polygons in the dual mesh.
        /// A dual mesh is were faces become vertices and vertices become faces.
        /// </summary>
        /// <returns>The number of triangles, quads and polygons in the mesh.</returns>
        public PolygonalCount GetDualPolygonalCount()
        {
            return Kernel.GetDualPolygonalCount(Ptr);
        }

        /// <summary>
        /// Get a centroid (the avergae face position) for each face in the mesh.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The points arrays lemgth.</param>
        public void GetCentroids(Point3d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetCentroids(Ptr, points, count);
        }

        /// <summary>
        /// Computes the vertex normals if needed.
        /// </summary>
        public void ComputeVertexNormals()
        {
            Kernel.ComputeVertexNormals(Ptr);
        }

        /// <summary>
        /// Computes the face normals if needed.
        /// </summary>
        public void ComputeFaceNormals()
        {
            Kernel.ComputeFaceNormals(Ptr);
        }

        /// <summary>
        /// Get the vertex normals.
        /// </summary>
        /// <param name="normals">The normals array.</param>
        /// <param name="count">The normals array length.</param>
        public void GetVertexNormals(Vector3d[] normals, int count)
        {
            ErrorUtil.CheckArray(normals, count);
            Kernel.GetVertexNormals(Ptr, normals, count);
        }

        /// <summary>
        /// Get the face normals.
        /// </summary>
        /// <param name="normals">The normals array.</param>
        /// <param name="count">The normals array length.</param>
        public void GetFaceNormals(Vector3d[] normals, int count)
        {
            ErrorUtil.CheckArray(normals, count);
            Kernel.GetFaceNormals(Ptr, normals, count);
        }

        /// <summary>
        /// Translate each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point3d translation)
        {
            var m = Matrix4x4d.Translate(translation);
            Kernel.Transform(Ptr, m);
            IsUpdated = false;
        }

        /// <summary>
        /// Rotate each point in the mesh.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Quaternion3d rotation)
        {
            var m = rotation.ToMatrix4x4d();
            Kernel.Transform(Ptr, m);
            IsUpdated = false;
        }

        /// <summary>
        /// Scale each point in the mesh.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(Point3d scale)
        {
            var m = Matrix4x4d.Scale(scale);
            Kernel.Transform(Ptr, m);
            IsUpdated = false;
        }

        /// <summary>
        /// Transform each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point3d translation, Quaternion3d rotation, Point3d scale)
        {
            var m = Matrix4x4d.TranslateRotateScale(translation, rotation, scale);
            Kernel.Transform(Ptr, m);
            IsUpdated = false;
        }

        /// <summary>
        /// Make all faces triangles.
        /// </summary>
        public void Triangulate()
        {
            if (!IsValid || IsTriangle) return;

            Kernel.Triangulate(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// sorts halfedges such that the non-border edges precede the border edges.
        /// For each border edge the halfedge iterator will reference the halfedge 
        /// incident to the facet right before the halfedge incident to the hole.
        /// </summary>
        public void NormalizeBorder()
        {
            if (!IsValid) return;

            Kernel.NormalizeBorder(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// returns true if the border halfedges are in normalized representation, 
        /// which is when enumerating all halfedges with the iterator: 
        /// The non-border edges precede the border edges and for border edges,
        /// the second halfedge is the border halfedge.
        /// </summary>
        /// <returns></returns>
        public bool NormalizedBorderIsValid()
        {
            return Kernel.NormalizedBorderIsValid(Ptr);
        }

        /// <summary>
        /// Find what side of the mesh the lies in.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>ON_BOUNDED_SIDE if point inside mesh, 
        /// ON_UNBOUNDED_SIDE if point not inside, 
        /// ON_BOUNDARY if point is on the surface.</returns>
        public BOUNDED_SIDE BoundedSide(Point3d point)
        {
            if (IsValid) 
                return Kernel.SideOfTriangleMesh(Ptr, point);
            else
                return BOUNDED_SIDE.UNDETERMINED;

        }

        /// <summary>
        /// Does the mesh contain the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="includeBoundary">If point is on the boundary does it count a being contained.</param>
        /// <returns>True if the poly contains the point</returns>
        public bool ContainsPoint(Point3d point, bool includeBoundary = true)
        {
            var side = BoundedSide(point);

            if (side == BOUNDED_SIDE.UNDETERMINED)
                return false;

            if (side == BOUNDED_SIDE.ON_BOUNDED_SIDE)
                return true;

            if (includeBoundary && side == BOUNDED_SIDE.ON_BOUNDARY)
                return true;

            return false;
        }

        /// <summary>
        /// Locate the face the rays hits.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <returns>The hit result.</returns>
        public abstract MeshHitResult LocateFace(Ray3d ray);

        /// <summary>
        /// Find the face closest to the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The hit result.</returns>
        public abstract MeshHitResult ClosestFace(Point3d point);

        /// <summary>
        /// Locate the face hit by the ray.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <param name="face">The hit face.</param>
        /// <returns>True if the ray hit a face.</returns>
        public bool LocateFace(Ray3d ray, out MeshFace3 face)
        {
            if (ray.IsDegenerate)
            {
                face = MeshFace3.NullFace;
                return false;
            }

            var result = LocateFace(ray);
            if(result.Hit && GetFace(result.Face, out face))
            {
                return true;
            }
            else
            {
                face = MeshFace3.NullFace;
                return false;
            }

        }

        /// <summary>
        /// Locate the vertex hit by the ray.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <param name="radius">The distance the vertex has to be within hit point.</param>
        /// <param name="vertex">The hit vertex.</param>
        /// <returns>True if the ray hit a vertex.</returns>
        public bool LocateVertex(Ray3d ray, double radius, out MeshVertex3 vertex)
        {
            if (ray.IsDegenerate)
            {
                vertex = MeshVertex3.NullVertex;
                return false;
            }

            var result = LocateFace(ray);
            if (result.Hit && GetFace(result.Face, out MeshFace3 face))
            {
                double minSqDist = double.PositiveInfinity;
                var closest = MeshVertex3.NullVertex;

                foreach(var v in face.EnumerateVertices(this))
                {
                    var sqdist = Point3d.SqrDistance(result.Point, v.Point);
                    if (sqdist < minSqDist)
                    {
                        minSqDist = sqdist;
                        closest = v;
                    }
                }

                if(closest.Index != CGALGlobal.NULL_INDEX && minSqDist < radius * radius)
                {
                    vertex = closest;
                    return true;
                }
                else
                {
                    vertex = MeshVertex3.NullVertex;
                    return false;
                } 
            }
            else
            {
                vertex = MeshVertex3.NullVertex;
                return false;
            }
        }

        /// <summary>
        /// Locate the edge hit by the ray.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <param name="radius">The distance the edge has to be within hit point.</param>
        /// <param name="edge">The hit edge.</param>
        /// <returns>True if the ray hit a edge.</returns>
        public bool LocateHalfedge(Ray3d ray, double radius, out MeshHalfedge3 edge)
        {
            if (ray.IsDegenerate)
            {
                edge = MeshHalfedge3.NullHalfedge;
                return false;
            }

            var result = LocateFace(ray);
            if (result.Hit && GetFace(result.Face, out MeshFace3 face))
            {
                double minSqDist = double.PositiveInfinity;
                var closest = MeshHalfedge3.NullHalfedge;
                MeshVertex3 source, target;
                Segment3d seg;

                foreach (var e in face.EnumerateHalfedges(this))
                {
                    if (!GetVertex(e.Source, out source)) continue;
                    if (!GetVertex(e.Target, out target)) continue;

                    seg.A = source.Point;
                    seg.B = target.Point;
                    var p = seg.Closest(result.Point);

                    var sqdist = Point3d.SqrDistance(result.Point, p);
                    if (sqdist < minSqDist)
                    {
                        minSqDist = sqdist;
                        closest = e;
                    }
                }

                if (closest.Index != CGALGlobal.NULL_INDEX && minSqDist < radius * radius)
                {
                    edge = closest;
                    return true;
                }
                else
                {
                    edge = MeshHalfedge3.NullHalfedge;
                    return false;
                }
            }
            else
            {
                edge = MeshHalfedge3.NullHalfedge;
                return false;
            }
        }

        /// <summary>
        /// Tests if a set of faces of a triangulated surface mesh self-intersects.
        /// Must be a triangle mesh.
        /// </summary>
        /// <returns>True/Fasle if a valid triangle polyhedra,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED DoesSelfIntersect()
        {
            if (IsValidTriangleMesh)
                return Kernel.DoesSelfIntersect(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// returns true if the polyhedral surface is combinatorially consistent.
        /// For level == 1 the normalization of the border edges is checked too.
        /// This method checks that each face is at least a triangle and that the
        /// two incident facets of a non-border edge are distinct.
        /// </summary>
        /// <returns></returns>
        public bool FindIfValid(int level = 0)
        {
            return Kernel.IsValid(Ptr, level);
        }

        /// <summary>
        /// Computes the bounding box.
        /// </summary>
        /// <returns>The bounding box.</returns>
        public Box3d FindBoundingBox()
        {
            return Kernel.GetBoundingBox(Ptr);
        }

        /// <summary>
        /// Computes the area of a range of faces
        /// of a given triangulated surface mesh.
        /// </summary>
        /// <returns>The area or 0 if poyhedron is not valid triangle mesh.</returns>
        public double FindArea()
        {
            if (IsValidTriangleMesh)
                return Kernel.Area(Ptr);
            else
                return 0;

        }

        /// <summary>
        /// computes the centroid of a volume bounded 
        /// by a closed triangulated surface mesh.
        /// </summary>
        /// <returns>The centroid or 0 if poyhedron is not valid.</returns>
        public Point3d FindCentroid()
        {
            if (IsValid)
                return Kernel.Centroid(Ptr);
            else
                return Point3d.Zero;
        }

        /// <summary>
        /// Computes the volume of the domain bounded by a 
        /// closed triangulated surface mesh.
        /// </summary>
        /// <returns>The volume or 0 if poyhedron is not valid closed triangle mesh.</returns>
        public double FindVolume()
        {
            if (IsValidClosedTriangleMesh)
                return Kernel.Volume(Ptr);
            else
                return 0;
        }

        /// <summary>
        /// Returns true if there are no border edges.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfClosed()
        {
            if (IsValid)
                return Kernel.IsClosed(Ptr).ToBoolOrUndetermined();
            else 
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Returns true if all vertices have exactly two incident edges.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfBivalent()
        {
            if (IsValid)
                return Kernel.IsPureBivalent(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Returns true if all vertices have exactly three incident edges.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfTrivalent()
        {
            if (IsValid)
                return Kernel.IsPureTrivalent(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Returns true if all faces are triangles.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfTriangleMesh()
        {
            if (IsValid)
                return Kernel.IsPureTriangle(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Returns true if all faces are quads.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfQuadMesh()
        {
            if (IsValid)
                return Kernel.IsPureQuad(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Indicates if the mesh bounds a volume.
        /// Must be a closed and triangulated.
        /// </summary>
        /// <returns>True/Fasle if a valid triangle closed polyhedra,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED FindIfDoesBoundAVolume()
        {
            if (IsValidClosedTriangleMesh)
                return Kernel.DoesBoundAVolume(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Builds the aabb tree used for location.
        /// Tree will be automatically built if need so not 
        /// actually necessary to call this function.
        /// </summary>
        public void BuildAABBTree()
        {
            Kernel.BuildAABBTree(Ptr);
        }

        /// <summary>
        /// Will delete the aabb tree.
        /// </summary>
        public void ReleaseAABBTree()
        {
            Kernel.ReleaseAABBTree(Ptr);
        }

        /// <summary>
        /// Returns true if there exists a face of this poly and 
        /// a face of other poly which intersect, and false otherwise.
        /// Must be a triangle mesh
        /// </summary>
        /// <param name="poly">The other triangle poly.</param>
        /// <param name="test_bounded_sides">If test_bounded_sides is set to true, 
        /// the overlap of bounded sides are tested as well. In that case, the meshes must be closed.</param>
        /// <returns>True/Fasle if a valid triangle closed polyhedra,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED DoIntersect(Polyhedron3 poly, bool test_bounded_sides = true)
        {
            if (IsValidTriangleMesh && poly.IsValidTriangleMesh)
            {
                //if test bounded side both must be closed meshes.
                //If not test bounded side does not matter if not closed.
                if ((test_bounded_sides && IsClosed && poly.IsClosed) || !test_bounded_sides)
                {
                    return Kernel.DoIntersects(Ptr, poly.Ptr, test_bounded_sides).ToBoolOrUndetermined();
                }
                else
                    return BOOL_OR_UNDETERMINED.UNDETERMINED;
            }
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Subdive the mesh.
        /// </summary>
        /// <param name="iterations">The number of iterations to perfrom.</param>
        /// <param name="method">The subdivision method.</param>
        public abstract void Subdivide(int iterations, SUBDIVISION_METHOD method = SUBDIVISION_METHOD.SQRT3);

        /// <summary>
        /// Simplify the polyhedra.
        /// </summary>
        /// <param name="stop_ratio">A number between 0-1 that represents the percentage of vertices to remove.</param>
        public abstract void Simplify(double stop_ratio);

        /// <summary>
        /// Refines a triangle mesh
        /// </summary>
        /// <param name="density_control_factor">a factor to control density of the output mesh, 
        /// where larger values lead to denser refinements. Defalus to sqrt of 2.</param>
        /// <returns>The number of new vertices.</returns>
        public abstract int Refine(double density_control_factor = MathUtil.SQRT2_64);

        /// <summary>
        /// Orient the faces in the mesh.
        /// </summary>
        /// <param name="orientate">The orientation method.</param>
        public abstract void Orient(ORIENTATE orientate);

        /// <summary>
        /// Reverses the orientation of the vertices in each face.
        /// </summary>
        public abstract void ReverseFaceOrientation();

        /// <summary>
        /// Remove all unconnected compontents except the largest.
        /// Largest is defined by the face count.
        /// </summary>
        /// <param name="num_components_to_keep">The numbero of largest components to keep.</param>
        /// <returns>The number of components removed in the mesh.</returns>
        public abstract int KeepLargest(int num_components_to_keep = 1);

        /// <summary>
        /// Find the min, max and average edge lengths in the mesh
        /// </summary>
        /// <returns>The min, max and average edge lengths in the mesh.</returns>
        public abstract MinMaxAvg FindMinMaxAvgEdgeLength();

        /// <summary>
        /// Find the min, max and average face areas in the mesh
        /// </summary>
        /// <returns>The min, max and average face areas in the mesh.</returns>
        public abstract MinMaxAvg FindMinMaxAvgFaceArea();

        /// <summary>
        /// Enumerate all points in the mesh.
        /// </summary>
        /// <returns>Each point in mesh.</returns>
        public IEnumerator<Point3d> GetEnumerator()
        {
            for (int i = 0; i < VertexCount; i++)
                yield return GetPoint(i);
        }

        /// <summary>
        /// Enumerate all points in the mesh.
        /// </summary>
        /// <returns>Each point in mesh.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Read data from a off file into the pollyhedron.
        /// </summary>
        /// <param name="filename">The files name.</param>
        public void ReadOFF(string filename)
        {
            IsUpdated = false;
            Kernel.ReadOFF(Ptr, filename);
        }

        /// <summary>
        /// Write data from a off file into the pollyhedron.
        /// </summary>
        /// <param name="filename">The files name.</param>
        public void WriteOFF(string filename)
        {
            Kernel.WriteOFF(Ptr, filename);
        }

        /// <summary>
        /// Return all the points in the mesh in a array.
        /// </summary>
        /// <returns>The array.</returns>
        public Point3d[] ToArray()
        {
            var points = new Point3d[VertexCount];
            GetPoints(points, points.Length);
            return points;
        }

        /// <summary>
        /// Return all the points in the mesh in a list.
        /// </summary>
        /// <returns>The list.</returns>
        public List<Point3d> ToList()
        {
            int count = VertexCount;
            var points = new List<Point3d>(count);
           for (int i = 0; i < count; i++)
                points.Add(GetPoint(i));
        
            return points;
        }


        /// <summary>
        /// https://doc.cgal.org/latest/Polyhedron/classCGAL_1_1Polyhedron__3.html#a73119c0c90bf8612da003305af25a52a
        /// creates a new facet within the hole incident to h and g by connecting the 
        /// vertex denoted by g with the vertex denoted by h with a new halfedge and 
        /// filling this separated part of the hole with a new facet, such that the 
        /// new facet is incident to g.
        ///
        /// Precondition
        /// h->is_border(), g->is_border(), h != g, h->next() != g, 
        /// and g can be reached along the same hole starting with h.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <param name="g">a halfedge index</param>
        /// <returns> Returns the halfedge of the new edge that is incident to the new facet.</returns>
        public int AddFacetToBorder(int h, int g)
        {
            IsUpdated = false;
            return Kernel.AddFacetToBorder(Ptr, h, g);
        }

        /// <summary>
        /// creates a new facet within the hole incident to h and g by connecting the 
        /// tip of g with the tip of h with two new halfedges and a new vertex and 
        /// filling this separated part of the hole with a new facet, such that the 
        /// new facet is incident to g.
        ///
        /// Precondition
        /// h->is_border(), g->is_border(), h != g, and g can be reached along the same hole starting with h.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <param name="g">a halfedge index</param>
        /// <returns>Returns the halfedge of the new edge that is incident to the new facet and the new vertex.</returns>
        public int AddVertexAndFacetToBorder(int h, int g)
        {
            IsUpdated = false;
            return Kernel.AddVertexAndFacetToBorder(Ptr, h, g);
        }

        /// <summary>
        /// barycentric triangulation of h->facet().
        /// Creates a new vertex, a copy of h->vertex(), and connects it to each vertex incident 
        /// to h->facet() splitting h->facet() into triangles.h remains incident to the original 
        /// facet, all other triangles are copies of this facet.
        /// Precondition
        /// h is not a border halfedge.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns>Returns the halfedge h->next() 
        /// after the operation, i.e., a halfedge pointing to the new vertex.The time is 
        /// proportional to the size of the facet.</returns>
        public int CreateCenterVertex(int h)
        {
            IsUpdated = false;
            return Kernel.CreateCenterVertex(Ptr, h);
        }

        /// <summary>
        /// reverses create_center_vertex().
        /// Erases the vertex pointed to by g and all incident halfedges thereby merging all 
        /// incident facets.Only g->facet() remains. The neighborhood of g->vertex() may not 
        /// be triangulated, it can have larger facets.
        /// Precondition
        /// None of the incident facets of g->vertex() is a hole. There are at least two distinct facets incident to the facets that are incident to g->vertex(). (This prevents the operation from collapsing a volume into two facets glued together with opposite orientations, such as would happen with any vertex of a tetrahedron.)
        /// Supports_removal must be CGAL::Tag_true.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns>Returns the halfedge g->prev(). 
        /// Thus, the invariant h == erase_center_vertex(create_center_vertex(h)) 
        /// holds if h is not a border halfedge.The time is proportional to the sum of the size of all incident facets.</returns>
        public int EraseCenterVertex(int h)
        {
            IsUpdated = false;
            return Kernel.EraseCenterVertex(Ptr, h);
        }

        /// <summary>
        /// removes the incident facet of h and changes all halfedges incident to the facet 
        /// into border edges or removes them from the polyhedral surface if they were already border edges.
        /// If this creates isolated vertices they get removed as well.See make_hole(h) for a more specialized variant.
        /// Precondition
        /// h->is_border() == false.
        /// Supports_removal must be CGAL::Tag_true
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns></returns>
        public bool EraseConnectedComponent(int h)
        {
            IsUpdated = false;
            return Kernel.EraseConnectedComponent(Ptr, h);
        }

        /// <summary>
        /// Erase a facet.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns>returns a range of handles over the facets.</returns>
        public bool EraseFacet(int h)
        {
            IsUpdated = false;
            return Kernel.EraseFacet(Ptr, h);
        }

        /// <summary>
        /// fills a hole with a newly created facet.
        /// Makes all border halfedges of the hole denoted 
        /// by h incident to the new facet.Returns h.
        /// Precondition
        /// h.is_border().
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns></returns>
        public int FillHole(int h)
        {
            IsUpdated = false;
            return Kernel.FillHole(Ptr, h);
        }

        /// <summary>
        /// performs an edge flip.
        /// 
        /// Precondition
        /// h != Halfedge_handle() and both facets incident to h are triangles.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns>It returns h after rotating the edge h one vertex in the direction of the face orientation.</returns>
        public int FlipEdge(int h)
        {
            IsUpdated = false;
            return Kernel.FlipEdge(Ptr, h);
        }

        /// <summary>
        /// joins the two facets incident to h.
        /// The facet incident to h->opposite() gets removed.Both facets might be holes. 
        /// 
        /// Precondition
        /// The degree of both vertices incident to h is at least three(no antennas).
        /// Supports_removal must be CGAL::Tag_true.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns>Returns the predecessor of h around the facet. The invariant join_facet(split_facet(h, g)) 
        /// returns h and keeps the polyhedron unchanged.The time is proportional to the size of 
        /// the facet removed and the time to compute h->prev().</returns>
        public int JoinFacet(int h)
        {
            IsUpdated = false;
            return Kernel.JoinFacet(Ptr, h);
        }

        /// <summary>
        /// glues the boundary of the two facets denoted by h and g together and returns h.
        /// Both facets and the vertices along the facet denoted by g gets removed.Both facets may be holes.
        /// The invariant join_loop(h, split_loop(h, i, j)) 
        /// Precondition
        /// The facets denoted by h and g are different and have equal degree(i.e., number of edges).
        /// Supports_removal must be CGAL::Tag_true.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <param name="g">a halfedge index</param>
        /// <returns>returns h and keeps the polyhedron unchanged.</returns>
        public int JoinLoop(int h, int g)
        {
            IsUpdated = false;
            return Kernel.JoinLoop(Ptr, h, g);
        }

        /// <summary>
        /// joins the two vertices incident to h.
        /// The vertex denoted by h->opposite() gets removed.
        /// Precondition
        /// The size of both facets incident to h is at least four(no multi-edges).
        /// Supports_removal must be CGAL::Tag_true.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns>Returns the predecessor of h around the vertex, i.e.,
        /// h->opposite()->prev(). The invariant join_vertex(split_vertex(h, g)) 
        /// returns h and keeps the polyhedron unchanged.The time is proportional 
        /// to the degree of the vertex removed and the time to compute h->prev() and h->opposite()->prev().</returns>
        public int JoinVertex(int h)
        {
            IsUpdated = false;
            return Kernel.JoinVertex(Ptr, h);
        }

        /// <summary>
        /// removes the incident facet of h and changes all halfedges incident to the facet into border edges.
        /// 
        /// Precondition
        /// None of the incident halfedges of the facet is a border edge.
        /// Supports_removal must be CGAL::Tag_true.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns>Returns h.See erase_facet(h) for a more generalized variant.</returns>
        public int MakeHole(int h)
        {
            IsUpdated = false;
            return Kernel.MakeHole(Ptr, h);
        }

        /// <summary>
        /// splits the halfedge h into two halfedges inserting a new vertex that is a copy of h->opposite()->vertex().
        /// Is equivalent to split_vertex(h->prev(), h->opposite())->opposite(). The call of prev() can make this method 
        /// slower than a direct call of split_vertex() if the previous halfedge is already known and computing 
        /// it would be costly when the halfedge data structure does not support the prev() member function.
        /// 
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <returns>Returns the new halfedge now pointing to the inserted vertex.The new halfedge is followed 
        /// by the old halfedge, i.e., hnew->next() == h.</returns>
        public int SplitEdge(int h)
        {
            IsUpdated = false;
            return Kernel.SplitEdge(Ptr, h);
        }

        /// <summary>
        /// splits the facet incident to h and g into two facets with a new diagonal between 
        /// the two vertices denoted by h and g respectively.
        /// The second(new) facet is a copy of the first facet.
        /// Precondition
        /// h and g are incident to the same facet.h != g (no loops). h->next() != g and g->next() != h (no multi-edges).
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <param name="g">a halfedge index</param>
        /// <returns>Returns h->next() after the
        /// operation, i.e., the new diagonal.The new face is to the right of the new diagonal,
        /// the old face is to the left.The time is proportional to the distance from h to g around the facet.</returns>
        /// <returns></returns>
        public int SplitFacet(int h, int g)
        {
            IsUpdated = false;
            return Kernel.SplitFacet(Ptr, h, g);
        }

        /// <summary>
        /// cuts the polyhedron into two parts along the cycle (h,i,j) (edge j runs on the backside of the three dimensional figure above).
        /// Three new vertices(one copy for each vertex in the cycle) and three new halfedges(one copy for each halfedge in the cycle), 
        /// and two new triangles are created.h,i,j will be incident to the first new triangle.
        /// Precondition
        /// h, i, j denote distinct, consecutive vertices of the polyhedron and form a cycle: i.e., h->vertex() == i->opposite()->vertex(),
        /// … , j->vertex() == h->opposite()->vertex(). The six facets incident to(h, i, j) are all distinct.
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <param name="g">a halfedge index</param>
        /// <param name="k">a halfedge index</param>
        /// <returns>The return value will be the halfedge 
        /// incident to the second new triangle which is the copy of h-opposite().</returns>
        public int SplitLoop(int h, int g, int k)
        {
            IsUpdated = false;
            return Kernel.SplitLoop(Ptr, h, g, k);
        }

        /// <summary>
        /// splits the vertex incident to h and g into two vertices, the old vertex remains and a
        /// new copy is created, and connects them with a new edge.
        /// Let hnew be h->next()->opposite() after the split, i.e., a halfedge of the new edge.
        /// The split regroups the halfedges around the two vertices.The halfedge sequence hnew,
        /// g->next()->opposite(), … , h remains around the old vertex, while the halfedge 
        /// sequence hnew->opposite(), h->next()->opposite() (before the split), … , g is 
        /// regrouped around the new vertex.
        /// Precondition
        /// h and g are incident to the same vertex. h != g (antennas are not allowed).
        /// </summary>
        /// <param name="h">a halfedge index</param>
        /// <param name="g">a halfedge index</param>
        /// <returns>The split returns hnew, i.e., the new halfedge 
        /// incident to the old vertex.The time is proportional to the distance from h to 
        /// g around the vertex.</returns>
        public int SplitVertex(int h, int g)
        {
            IsUpdated = false;
            return Kernel.SplitVertex(Ptr, h, g);
        }

        /// <summary>
        /// Update the mesh if needed.
        /// </summary>
        protected void Update()
        {
            if (IsUpdated) return;
            IsUpdated = true;

            if (FindIfValid())
            {
                m_isValid = true;
                m_isClosed = FindIfClosed().ToBool();
                m_isTriangle = FindIfTriangleMesh().ToBool();
                m_isQuad = FindIfQuadMesh().ToBool();
            }
            else
            {
                m_isValid = false;
                m_isClosed = false;
                m_isTriangle = false;
                m_isQuad = false;   
            }
        }

        /// <summary>
        /// Print the mesh into a string builder.
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            Update();

            builder.AppendLine(ToString());
            builder.AppendLine("BuildStamp = " + BuildStamp);
            builder.AppendLine("VertexCount = " + VertexCount);
            builder.AppendLine("FaceCount= " + FaceCount);
            builder.AppendLine("HalfEdgeCount = " + HalfedgeCount);
            builder.AppendLine("BorderEdgeCount = " + BorderEdgeCount);
            builder.AppendLine("BorderHalfEdgeCount = " + BorderHalfEdgeCount);
            builder.AppendLine("IsValid = " + IsValid);
            builder.AppendLine("NormalizedBorderIsValid = " + NormalizedBorderIsValid());
            builder.AppendLine("IsClosed = " + IsClosed);
            builder.AppendLine("IsTriangle = " + IsTriangle);
            builder.AppendLine("IsQuad = " + IsQuad);
            builder.AppendLine("IsBivalent = " + FindIfBivalent());
            builder.AppendLine("IsTrivalent = " + FindIfTrivalent());
            builder.AppendLine("DoesBoundAVolume = " + FindIfDoesBoundAVolume());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void PrintVertices(StringBuilder builder)
        {
            builder.AppendLine("Vertices");
            var verts = new MeshVertex3[VertexCount];
            GetVertices(verts, verts.Length);

            foreach (var v in verts)
                builder.AppendLine(v.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void PrintFaces(StringBuilder builder)
        {
            builder.AppendLine("Faces");
            var faces = new MeshFace3[FaceCount];
            GetFaces(faces, faces.Length);

            foreach (var f in faces)
                builder.AppendLine(f.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void PrintHalfedges(StringBuilder builder)
        {
            builder.AppendLine("Edges");
            var edges = new MeshHalfedge3[HalfedgeCount];
            GetHalfedges(edges, edges.Length);

            foreach (var e in edges)
                builder.AppendLine(e.ToString());
        }

        /// <summary>
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

    }
}
