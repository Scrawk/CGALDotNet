using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Processing;
using CGALDotNet.Polygons;
using CGALDotNet.Extensions;

namespace CGALDotNet.Polyhedra
{

    /// <summary>
    /// A polyhedral surface consists of vertices, edges, 
    /// facets and an incidence relation on them.
    //  Each edge is represented by two halfedges with opposite orientations.
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
                Kernel.KernelName, VertexCount, HalfedgeCount, FaceCount);
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
        public override int Refine(double density_control_factor = CGALGlobal.SQRT2)
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
        /// Remeshes a triangulated region of a polygon mesh.
        /// This operation sequentially performs edge splits, edge collapses, edge flips, 
        /// tangential relaxation and projection to the initial surface to generate 
        /// a smooth mesh with a prescribed edge length.
        /// </summary>
        /// <param name="iterations">The number of times to perform the remeshing.</param>
        /// <param name="target_edge_length">the edge length that is targeted in the remeshed patch. 
        /// If 0 is passed then only the edge-flip, tangential relaxation, and projection steps will be done.</param>
        /// <returns>The number of new vertices added.</returns>
        public override int IsotropicRemeshing(double target_edge_length, int iterations = 1)
        {
            try
            {
                IsUpdated = false;
                var meshing = MeshProcessingMeshing<K>.Instance;
                return meshing.IsotropicRemeshing(this, target_edge_length, iterations);
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
        public Polyhedron3<K> CreateDualMesh()
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
        /// <param name="vertices">True to clear the vertex normal map./param>
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
        internal void MakeTetrahedron(Point3d p1, Point3d p2, Point3d p3, Point3d p4)
        {
            Kernel.MakeTetrahedron(Ptr, p1, p2, p3, p4);
            IsUpdated = false;
        }

        /// <summary>
        /// A triangle with border edges is added to the 
        /// polyhedral surface with its vertices initialized to p1, p2, and p3.
        /// </summary>
        internal void MakeTriangle(Point3d p1, Point3d p2, Point3d p3)
        {
            Kernel.MakeTriangle(Ptr, p1, p2, p3);
            IsUpdated = false;
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
        public void CreateQuadMesh(Point3d[] points, int pointsCount, int[] indices, int indexCount)
        {
            ErrorUtil.CheckArray(points, pointsCount);
            ErrorUtil.CheckArray(indices, indexCount);

            Clear();
            IsUpdated = false;
            Kernel.CreatePolygonalMesh(Ptr, points, pointsCount, null, 0, indices, indexCount, null, 0, null, 0);
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
            var count = GetPolygonalCount();
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
        // For level == 1 the normalization of the border edges is checked too.
        // This method checks that each face is at least a triangle and that the
        // two incident facets of a non-border edge are distinct.
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
        public abstract int Refine(double density_control_factor = CGALGlobal.SQRT2);

        /// <summary>
        /// Remeshes a triangulated region of a polygon mesh.
        /// This operation sequentially performs edge splits, edge collapses, edge flips, 
        /// tangential relaxation and projection to the initial surface to generate 
        /// a smooth mesh with a prescribed edge length.
        /// </summary>
        /// <param name="iterations">The number of times to perform the remeshing.</param>
        /// <param name="target_edge_length">the edge length that is targeted in the remeshed patch. 
        /// If 0 is passed then only the edge-flip, tangential relaxation, and projection steps will be done.</param>
        /// <returns>The number of new vertices added.</returns>
        public abstract int IsotropicRemeshing(double target_edge_length, int iterations = 1);

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
        //public List<Point3d> ToList()
        //{
        //    int count = VertexCount;
        //    var points = new List<Point3d>(count);
        //    for (int i = 0; i < count.; i++)
        //        points.Add(GetPoint(i));
        //
        //    return points;
        //}

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
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

    }
}
