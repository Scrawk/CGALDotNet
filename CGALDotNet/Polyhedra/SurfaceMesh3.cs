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
    /// This class is a data structure that can be used as halfedge data structure.
    /// It is an alternative to the classes Polyhedron3.The main difference is that it is indexed based and not pointer based, 
    /// and that the mechanism for adding information to vertices, halfedges, edges, and faces is much simpler.
    /// When elements are removed, they are only marked as removed, and a garbage collection function must be called to really remove them.
    /// </summary>
    /// <typeparam name="K">The kernel type</typeparam>
    public sealed class SurfaceMesh3<K> : SurfaceMesh3 where K : CGALKernel, new()
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceMesh3() : base(new K())
        {

        }

        /// <summary>
        /// Construct from points and triangle indices.
        /// </summary>
        public SurfaceMesh3(Point3d[] points, int[] triangles) : base(new K())
        {
            CreateMesh(points, triangles);
        }

        /// <summary>
        /// Construct from points and polygon indices.
        /// </summary>
        public SurfaceMesh3(Point3d[] points, PolygonalIndices indices) : base(new K())
        {
            CreatePolygonalMesh(points, points.Length, indices);
        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The surface meshes pointer.</param>
        internal SurfaceMesh3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The mesh as a string.
        /// </summary>
        /// <returns>The mesh as a string.</returns>
        public override string ToString()
        {
            return string.Format("[SurfaceMesh3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FaceCount={3}]",
                Kernel.Name, VertexCount, HalfedgeCount, FaceCount);
        }

        /// <summary>
        /// Create a deep copy of the mesh.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public SurfaceMesh3<K> Copy()
        {
            var ptr = Kernel.Copy(Ptr);
            return new SurfaceMesh3<K>(ptr);
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
        public void Split(List<SurfaceMesh3<K>> results)
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
        /// Copy the other mesh to this one.
        /// </summary>
        /// <param name="other"></param>
        public void Join(SurfaceMesh3<K> other)
        {
            IsUpdated = false;
            Kernel.Join(Ptr, other.Ptr);
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

        /*
        /// <summary>
        /// Create the dual mesh where each face becomes a vertex
        /// and each vertex becomes a face.
        /// Must be a valid closed mesh to create the dual.
        /// </summary>
        /// <returns>The duel mesh.</returns>
        /// <exception cref="InvalidOperationException">Is thrown if the mesh is not a valid closed mesh.</exception>
        public SurfaceMesh3<K> CreateDualMesh()
        {
            if (!IsValidClosedMesh)
                throw new InvalidOperationException("Mesh must be a valid closed mesh to create a dual mesh.");

            int faceCount = FaceCount;
            var points = new Point3d[faceCount];
            GetCentroids(points, faceCount);

            var indices = GetDualPolygonalIndices();
  
            var dual = new SurfaceMesh3<K>();
            dual.CreatePolygonalMesh(points, points.Length, indices);

            return dual;
        }
        */

        /// <summary>
        /// Convert to a polyhedron mesh.
        /// </summary>
        /// <returns>The polyhedron mesh.</returns>
        public Polyhedron3<K> ToPolyhedronMesh()
        {
            var points = new Point3d[VertexCount];
            GetPoints(points, points.Length);

            var indices = GetPolygonalIndices();

            var mesh = new Polyhedron3<K>();
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
    /// The surface mesh abstract base class.
    /// </summary>
    public abstract class SurfaceMesh3 : CGALObject, IMesh
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
        private SurfaceMesh3()
        {

        }

        /// <summary>
        /// Construct mesh with the kernel.
        /// </summary>
        /// <param name="kernel">The kernel</param>
        internal SurfaceMesh3(CGALKernel kernel)
        {
            Kernel = kernel.SurfaceMeshKernel3;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The surface meshes kernel.</param>
        /// <param name="ptr">The surface meshes pointer.</param>
        internal SurfaceMesh3(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.SurfaceMeshKernel3;
        }

        /// <summary>
        /// The meshes kernel type.
        /// </summary>
        protected private SurfaceMeshKernel3 Kernel { get; private set; }

        /// <summary>
        /// The number of vertices in the mesh.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// The number of half edges in the mesh.
        /// </summary>
        public int HalfedgeCount => Kernel.HalfedgeCount(Ptr);

        /// <summary>
        /// The number of edges in the mesh.
        /// </summary>
        public int EdgeCount => Kernel.EdgeCount(Ptr);

        /// <summary>
        /// The number of faces in the mesh.
        /// </summary>
        public int FaceCount => Kernel.FaceCount(Ptr);

        /// <summary>
        /// The number of border edges.
        /// </summary>
        public int BorderEdgeCount => Kernel.BorderEdgeCount(Ptr);

        /// <summary>
        /// The current build stamp.
        /// </summary>
        public int BuildStamp => Kernel.GetBuildStamp(Ptr);

        /// <summary>
        /// The number of vertices currenly maked to be removed
        /// but have not. Calling collect garbage will remove them.
        /// </summary>
        /// <returns>The number of vertices marked to be removed.</returns>
        public int RemovedVertexCount => Kernel.RemovedVertexCount(Ptr);

        /// <summary>
        /// The number of halfedges currenly maked to be removed
        /// but have not. Calling collect garbage will remove them.
        /// </summary>
        /// <returns>The number of half edges marked to be removed.</returns>
        public int RemovedHalfedgeCount => Kernel.RemovedHalfedgeCount(Ptr);

        /// <summary>
        /// The number of edges currenly maked to be removed
        /// but have not. Calling collect garbage will remove them.
        /// </summary>
        /// <returns>The number of edges marked to be removed.</returns>
        public int RemovedEdgeCount => Kernel.RemovedEdgeCount(Ptr);

        /// <summary>
        /// The number of faces currenly maked to be removed
        /// but have not. Calling collect garbage will remove them.
        /// </summary>
        /// <returns>The number of face marked to be removed.</returns>
        public int RemovedFaceCount => Kernel.RemovedFaceCount(Ptr);

        /// <summary>
        /// Returns true if the meshl surface is combinatorially consistent.
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
        /// Mark the mesh as needing to be updated.
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
            IsUpdated = false;
            Kernel.Clear(Ptr);
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
        /// <param name="halfedges">True to clear the halfedges index map.</param>
        public void ClearIndexMaps(bool vertices, bool faces, bool edges, bool halfedges)
        {
            Kernel.ClearIndexMaps(Ptr, vertices, faces, edges, halfedges);
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
        /// Clear the property maps.
        /// </summary>
        public void ClearProperyMaps()
        {
            Kernel.ClearProperyMaps(Ptr);
        }

        /// <summary>
        /// Build the index maps.
        /// The index maps are used to access the meshes elemnts by index.
        /// They are automaticaly created when a elements is accessed
        /// be a function requiring it but can be create ahead of time.
        /// </summary>
        /// <param name="vertices">True to build the vertex index maps.</param>
        /// <param name="faces">True to build the face index maps.</param>
        /// <param name="edges">True to build the edge index maps.</param>
        /// <param name="halfedges">True to build the halfedge index maps.</param>
        /// <param name="force">The index maps wont be build if the mesh knows they are already built and upto date.
        /// Setting force to true will build them always.</param>
        public void BuildIndices(bool vertices, bool faces, bool edges, bool halfedges, bool force = false)
        {
            Kernel.BuildIndices(Ptr, vertices, faces, edges, halfedges, force);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="faces"></param>
        /// <param name="edges"></param>
        /// <param name="halfedges"></param>
        /// <param name="force"></param>
        internal void PrintIndices(bool vertices, bool faces, bool edges, bool halfedges, bool force = false)
        {
            Kernel.PrintIndices(Ptr, vertices, faces, edges, halfedges, force);
        }

        /// <summary>
        /// Adds a vertex to the mesh.
        /// </summary>
        /// <param name="point">The vertices position</param>
        /// <returns>The vertices index in the mesh.</returns>
        public int AddVertex(Point3d point)
        {
            IsUpdated = false;
            return Kernel.AddVertex(Ptr, point);
        }

        /// <summary>
        /// Adds a edge between the two vertices.
        /// </summary>
        /// <param name="v0">The index of the vertex in the mesh.</param>
        /// <param name="v1">The index of the vertex in the mesh.</param>
        /// <returns>The index of the edge in the mesh.</returns>
        public int AddEdge(int v0, int v1)
        {
            IsUpdated = false;
            return Kernel.AddEdge(Ptr, v0, v1);
        }

        /// <summary>
        /// Adds a triangle face to the mesh.
        /// </summary>
        /// <param name="v0">The index of the vertex in the mesh.</param>
        /// <param name="v1">The index of the vertex in the mesh.</param>
        /// <param name="v2">The index of the vertex in the mesh.</param>
        /// <returns>The index of the face in the mesh.</returns>
        public int AddTriangle(int v0, int v1, int v2)
        {
            IsUpdated = false;
            return Kernel.AddTriangle(Ptr, v0, v1, v2);
        }

        /// <summary>
        /// Adds a quad face to the mesh.
        /// </summary>
        /// <param name="v0">The index of the vertex in the mesh.</param>
        /// <param name="v1">The index of the vertex in the mesh.</param>
        /// <param name="v2">The index of the vertex in the mesh.</param>
        /// <param name="v3">The index of the vertex in the mesh.</param>
        /// <returns>The index of the face in the mesh.</returns>
        public int AddQuad(int v0, int v1, int v2, int v3)
        {
            IsUpdated = false;
            return Kernel.AddQuad(Ptr, v0, v1, v2, v3);
        }

        /// <summary>
        /// Adds a pentagon face to the mesh.
        /// </summary>
        /// <param name="v0">The index of the vertex in the mesh.</param>
        /// <param name="v1">The index of the vertex in the mesh.</param>
        /// <param name="v2">The index of the vertex in the mesh.</param>
        /// <param name="v3">The index of the vertex in the mesh.</param>
        /// <param name="v4">The index of the vertex in the mesh.</param>
        /// <returns>The index of the face in the mesh.</returns>
        public int AddPentagon(int v0, int v1, int v2, int v3, int v4)
        {
            IsUpdated = false;
            return Kernel.AddPentagon(Ptr, v0, v1, v2, v3, v4);
        }

        /// <summary>
        /// Adds a hexagon face to the mesh.
        /// </summary>
        /// <param name="v0">The index of the vertex in the mesh.</param>
        /// <param name="v1">The index of the vertex in the mesh.</param>
        /// <param name="v2">The index of the vertex in the mesh.</param>
        /// <param name="v3">The index of the vertex in the mesh.</param>
        /// <param name="v4">The index of the vertex in the mesh.</param>
        /// <param name="v5">The index of the vertex in the mesh.</param>
        /// <returns>The index of the face in the mesh.</returns>
        public int AddHexagon(int v0, int v1, int v2, int v3, int v4, int v5)
        {
            IsUpdated = false;
            return Kernel.AddHexagon(Ptr, v0, v1, v2, v3, v4, v5);
        }

        /// <summary>
        /// Add a polygon face to the mesh.
        /// </summary>
        /// <param name="indices">The indices of the points in the mesm.</param>
        /// <param name="count">The indices array length.</param>
        /// <returns>The index of the face in the mesh.</returns>
        public int AddPolygon(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            IsUpdated = false;
            return Kernel.AddFace(Ptr, indices, count);
        }

        /// <summary>
        /// Checks if any vertices, halfedges, edges, or faces are marked as removed.
        /// </summary>
        /// <returns></returns>
        public bool HasGarbage => Kernel.HasGarbage(Ptr);

        /// <summary>
        /// Really removes vertices, halfedges, edges, and faces which are marked removed.
        /// By garbage collecting elements get new indices. In case you store indices in an 
        /// auxiliary data structure or in a property these indices are potentially no 
        /// longer refering to the right elements.
        /// </summary>
        public void CollectGarbage()
        {
            Kernel.CollectGarbage(Ptr);
        }

        /// <summary>
        /// Controls the recycling or not of simplices previously marked as removed 
        /// upon addition of new elements.
        /// When set to true (default value), new elements are first picked in the 
        /// garbage(if any) while if set to false only new elements are created.
        /// </summary>
        /// <returns></returns>
        public bool DoesRecycleGarbage
        {
            get { return Kernel.DoesRecycleGarbage(Ptr); }
            set { Kernel.SetRecycleGarbage(Ptr, value); }
        }

        /// <summary>
        /// Array accessor for the polygon.
        /// Getting a point wraps around the polygon.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
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
            if(index < 0 || index >= VertexCount) 
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
        /// <param name="index">The vertices index.</param>
        /// <returns>The vertex.</returns>
        public MeshVertex3 GetVertex(int index)
        {
            Kernel.GetVertex(Ptr, index, out MeshVertex3 vertex);
            return vertex;
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
        /// <returns>The face.</returns>
        public MeshFace3 GetFace(int index)
        {
            Kernel.GetFace(Ptr, index, out MeshFace3 face);
            return face;
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
        /// Get the mesh halfedge.
        /// </summary>
        /// <param name="index">The halfedges index.</param>
        /// <returns>THe healfedge.</returns>
        public MeshHalfedge3 GetHalfedge(int index)
        {
            Kernel.GetHalfedge(Ptr, index, out MeshHalfedge3 halfedge);
            return halfedge;
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
        /// Returns the number of incident halfedges of vertex.
        /// </summary>
        /// <param name="vertex">The index of the vertex in the mesh.</param>
        /// <returns>Returns the number of incident halfedges of vertex.</returns>
        public int VertexDegree(int vertex)
        {
            return Kernel.VertexDegree(Ptr, vertex);
        }

        /// <summary>
        /// Returns the number of incident halfedges of face.
        /// </summary>
        /// <param name="face">The index of the face in the mesh.</param>
        /// <returns>Returns the number of incident halfedges of face.</returns>
        public int FaceDegree(int face)
        {
            return Kernel.FaceDegree(Ptr, face);
        }

        /// <summary>
        /// Returns whether vertex is isolated.
        /// </summary>
        /// <param name="vertex">The index of the vertex in the mesh.</param>
        /// <returns>Returns whether vertex is isolated.</returns>
        public bool VertexIsIsolated(int vertex)
        {
            return Kernel.VertexIsIsolated(Ptr, vertex);
        }

        /// <summary>
        /// Returns whether vertex is a border vertex.
        /// If the data contained in the Surface_mesh is not
        /// a 2-manifold, then this operation is not 
        /// guaranteed to return the right result.
        /// </summary>
        /// <param name="vertex">he index of the vertex in the mesh.</param>
        /// <param name="check_all_incident_halfedges">With the default value for 
        /// check_all_incident_halfedges the function iteratates over the incident 
        /// halfedges. With check_all_incident_halfedges == false the function 
        /// returns true, if the incident halfedge associated to vertex is a
        /// border halfedge, or if the vertex is isolated.</param>
        /// <returns>Returns whether vertex is a border vertex.</returns>
        public bool VertexIsBorder(int vertex, bool check_all_incident_halfedges = true)
        {
            return Kernel.VertexIsBorder(Ptr, vertex, check_all_incident_halfedges);
        }

        /// <summary>
        /// Returns whether edge is a border edge, i.e., if any of its two halfedges is a border halfedge.
        /// </summary>
        /// <param name="edge">The index of the edge in the mesh.</param>
        /// <returns>Returns whether edge is a border edge.</returns>
        public bool EdgeIsBorder(int edge)
        {
            return Kernel.EdgeIsBorder(Ptr, edge);
        }

        /// <summary>
        /// Returns the next halfedge within the incident face.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the next halfedge within the incident face.</returns>
        public int NextHalfedge(int halfedge)
        {
            return  Kernel.NextHalfedge(Ptr, halfedge);
        }

        /// <summary>
        /// Returns the previous halfedge within the incident face.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the previous halfedge within the incident face.</returns>
        public int PreviousHalfedge(int halfedge)
        {
            return Kernel.PreviousHalfedge(Ptr, halfedge);
        }

        /// <summary>
        /// Returns the opposite halfedge of halfedge.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the opposite halfedge of halfedge.</returns>
        public int OppositeHalfedge(int halfedge)
        {
            return Kernel.OppositeHalfedge(Ptr, halfedge);   
        }

        /// <summary>
        /// Returns the vertex the halfedge emanates from.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the vertex the halfedge emanates from.</returns>
        public int SourceVertex(int halfedge)
        {
            return Kernel.SourceVertex(Ptr, halfedge);
        }

        /// <summary>
        /// Returns the vertex the halfedge points to.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the vertex the halfedge points to.</returns>
        public int TargetVertex(int halfedge)
        {
            return Kernel.TargetVertex(Ptr, halfedge);
        }

        /// <summary>
        /// Removes vertex from the halfedge data structure without adjusting anything.
        /// </summary>
        /// <param name="vertex">The index of the vertex in the mesh.</param>
        /// <returns>True if face removed.</returns>
        public bool RemoveVertex(int vertex)
        {
            IsUpdated = false;
            return Kernel.RemoveVertex(Ptr, vertex);
        }

        /// <summary>
        /// Removes the two halfedges corresponding to edge from the halfedge
        /// data structure without adjusting anything.
        /// </summary>
        /// <param name="edge">The index of the edge in the mesh.</param>
        /// <returns>True if face removed.</returns>
        public bool RemoveEdge(int edge)
        {
            IsUpdated = false;
            return Kernel.RemoveEdge(Ptr, edge);
        }

        /// <summary>
        /// Removes face from the halfedge data structure without adjusting anything.
        /// </summary>
        /// <param name="face">The index of the face in the mesh.</param>
        /// <returns>True if face removed.</returns>
        public bool RemoveFace(int face)
        {
            IsUpdated = false;
            return Kernel.RemoveFace(Ptr, face);
        }

        /// <summary>
        /// Has this vertex been marked to be removed.
        /// </summary>
        /// <param name="index">The vertices index in the mesh.</param>
        /// <returns>Has this vertex been marked to be removed.</returns>
        public bool IsVertexRemoved(int index)
        {
            return Kernel.IsVertexRemoved(Ptr, index);
        }

        /// <summary>
        /// Has this face been marked to be removed.
        /// </summary>
        /// <param name="index">The faces index in the mesh.</param>
        /// <returns>Has this face been marked to be removed.</returns>
        public bool IsFaceRemoved(int index)
        {
            return Kernel.IsFaceRemoved(Ptr, index);
        }

        /// <summary>
        /// Has this halfedge been marked to be removed.
        /// </summary>
        /// <param name="index">The halfedge index in the mesh.</param>
        /// <returns>Has this halfedge been marked to be removed.</returns>
        public bool IsHalfedgeRemoved(int index)
        {
            return Kernel.IsHalfedgeRemoved(Ptr, index);
        }

        /// <summary>
        /// Has this edge been marked to be removed.
        /// </summary>
        /// <param name="index">The edges index in the mesh.</param>
        /// <returns>Has this edge been marked to be removed.</returns>
        public bool IsEdgeRemoved(int index)
        {
            return Kernel.IsEdgeRemoved(Ptr, index);
        }

        /// <summary>
        /// Performs a validity check on a single vertex.
        /// </summary>
        /// <param name="vertex">The index of the vertex in the mesh.</param>
        /// <returns>True if valid.</returns>
        public bool IsVertexValid(int vertex)
        {
            return Kernel.IsVertexValid(Ptr, vertex);
        }

        /// <summary>
        /// Performs a validity check on a single edge.
        /// </summary>
        /// <param name="edge">The index of the edge in the mesh.</param>
        /// <returns>True if valid.</returns>
        public bool IsEdgeValid(int edge)
        {
            return  Kernel.IsEdgeValid(Ptr, edge);
        }

        /// <summary>
        /// Performs a validity check on a single halfedge.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>True if valid.</returns>
        public bool IsHalfedgeValid(int halfedge)
        {
            return  Kernel.IsHalfedgeValid(Ptr, halfedge);
        }

        /// <summary>
        /// Performs a validity check on a single face.
        /// </summary>
        /// <param name="face">The index of the face in the mesh.</param>
        /// <returns>True if valid.</returns>
        public bool IsFaceValid(int face)
        {
            return Kernel.IsFaceValid(Ptr, face);
        }

        /// <summary>
        /// Translate each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point3d translation)
        {
            IsUpdated = false;
            var m = Matrix4x4d.Translate(translation);
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Rotate each point in the mesh.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Quaternion3d rotation)
        {
            IsUpdated = false;
            var m = rotation.ToMatrix4x4d();
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Scale each point in the mesh.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(Point3d scale)
        {
            IsUpdated = false;
            var m = Matrix4x4d.Scale(scale);
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Transform each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point3d translation, Quaternion3d rotation, Point3d scale)
        {
            IsUpdated = false;
            var m = Matrix4x4d.TranslateRotateScale(translation, rotation, scale);
            Kernel.Transform(Ptr, m);
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
        /// <param name="count">The paoint array length.</param>
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

        /*
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
        */

        /// <summary>
        /// Whether v is a border vertex.
        /// </summary>
        /// <param name="index">The vertices index.</param>
        /// <param name="check_all_incident_halfedges">With the default value for 
        /// check_all_incident_halfedges the function iteratates over the incident halfedges. 
        /// With check_all_incident_halfedges == false the function returns true, 
        /// if the incident halfedge associated to vertex v is a border halfedge, 
        /// or if the vertex is isolated.</param>
        /// <returns>Whether v is a border vertex.</returns>
        public bool IsVertexBorder(int index, bool check_all_incident_halfedges)
        {
            return Kernel.IsVertexBorder(Ptr, index, check_all_incident_halfedges);
        }

        /// <summary>
        /// Whether half edge is a border halfege, that is if its incident face is null.
        /// </summary>
        /// <param name="index">The halfedges index.</param>
        /// <returns>Whether half edge is a border halfege.</returns>
        public bool IsHalfedgeBorder(int index)
        {
            return Kernel.IsHalfedgeBorder(Ptr, index);
        }

        /// <summary>
        /// Whether e is a border edge, i.e., if any of its two halfedges is a border halfedge.
        /// </summary>
        /// <param name="index">The edges index.</param>
        /// <returns>Whether e is a border edge.</returns>
        public bool IsEdgeBorder(int index)
        {
            return  Kernel.IsEdgeBorder(Ptr, index);    
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
        /// Build the aabb tree.
        /// </summary>
        public void BuildAABBTree()
        {
            Kernel.BuildAABBTree(Ptr);
        }

        /// <summary>
        /// Release the aabb tree.
        /// </summary>
        public void ReleaseAABBTree()
        {
            Kernel.ReleaseAABBTree(Ptr);
        }

        /// <summary>
        /// Find the bounding box of the meshes points.
        /// </summary>
        /// <returns></returns>
        public Box3d FindBoundingBox()
        {
            return Kernel.GetBoundingBox(Ptr);
        }

        /// <summary>
        /// Read the mesh from a off file format.
        /// </summary>
        /// <param name="filename">The files name.</param>
        public void ReadOFF(string filename)
        {
            IsUpdated = false;
            Kernel.ReadOFF(Ptr, filename);
        }

        /// <summary>
        /// Write the mesh to off file format.
        /// </summary>
        /// <param name="filename">The files name.</param>
        public void WriteOFF(string filename)
        {
            Kernel.WriteOFF(Ptr, filename);
        }

        /// <summary>
        /// Make all faces triangles.
        /// </summary>
        public void Triangulate()
        {
            if (!IsValid || IsTriangle) return;

            IsUpdated = false;
            Kernel.Triangulate(Ptr);
        }

        /// <summary>
        /// Tests if a set of faces of a triangulated surface mesh self-intersects.
        /// Must be a triangle mesh.
        /// </summary>
        /// <returns>True/Fasle if a valid triangle mesh,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED DoesSelfIntersect()
        {
            if (IsValidTriangleMesh)
                return Kernel.DoesSelfIntersect(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Perform an expensive validity check on the data structure.
        /// </summary>
        /// <returns>If the mesh is valid.</returns>
        public bool FindIfValid()
        {
            return Kernel.IsValid(Ptr);
        }

        /// <summary>
        /// Find if all the faces in the mesh are triangles.
        /// </summary>
        /// <returns>True if all the faces in the mesh are triangles, Will be undetermined if no a valid mesh.</returns>
        public BOOL_OR_UNDETERMINED FindIfTriangleMesh()
        {
            if (IsValid)
                return Kernel.CheckFaceVertexCount(Ptr, 3).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Find if all the faces in the mesh are quads.
        /// </summary>
        /// <returns>True if all the faces in the mesh are quads, Will be undetermined if no a valid mesh.</returns>
        public BOOL_OR_UNDETERMINED FindIfQuadMesh()
        {
            if (IsValid)
                return Kernel.CheckFaceVertexCount(Ptr, 4).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Find if the mesh is closed, ie has no border edges.
        /// </summary>
        //// <returns>True if all closed, Will be undetermined if no a valid mesh.</returns>
        public BOOL_OR_UNDETERMINED FindIfClosed()
        {
            if (IsValid)
                return Kernel.IsClosed(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Computes the area of a range of faces
        /// of a given triangulated surface mesh.
        /// </summary>
        /// <returns>The area or 0 if mesh is not valid triangle mesh.</returns>
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
        /// <returns>The centroid or 0 if mesh is not valid.</returns>
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
        /// <returns>The volume or 0 if mesh is not valid closed triangle mesh.</returns>
        public double FindVolume()
        {
            if (IsValidClosedTriangleMesh)
                return Kernel.Volume(Ptr);
            else
                return 0;
        }

        /// <summary>
        /// Indicates if the mesh bounds a volume.
        /// Must be a closed and triangulated.
        /// </summary>
        /// <returns>True/Fasle if a valid triangle closed mesh,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED FindIfDoesBoundAVolume()
        {
            if (IsValidClosedTriangleMesh)
                return Kernel.DoesBoundAVolume(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
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
            var result = LocateFace(ray);
            if (result.Hit && GetFace(result.Face, out face))
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
            var result = LocateFace(ray);
            if (result.Hit && GetFace(result.Face, out MeshFace3 face))
            {
                double minSqDist = double.PositiveInfinity;
                var closest = MeshVertex3.NullVertex;

                foreach (var v in face.EnumerateVertices(this))
                {
                    var sqdist = Point3d.SqrDistance(result.Point, v.Point);
                    if (sqdist < minSqDist)
                    {
                        minSqDist = sqdist;
                        closest = v;
                    }
                }

                if (closest.Index != CGALGlobal.NULL_INDEX && minSqDist < radius * radius)
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
        /// Returns true if there exists a face of this poly and 
        /// a face of other mesh which intersect, and false otherwise.
        /// Must be a triangle mesh
        /// </summary>
        /// <param name="mesh">The other triangle poly.</param>
        /// <param name="test_bounded_sides">If test_bounded_sides is set to true, 
        /// the overlap of bounded sides are tested as well. In that case, the meshes must be closed.</param>
        /// <returns>True/Fasle if a valid triangle closed mesh,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED DoIntersect(SurfaceMesh3 mesh, bool test_bounded_sides = true)
        {
            if (IsValidTriangleMesh && mesh.IsValidTriangleMesh)
            {
                //if test bounded side both must be closed meshes.
                //If not test bounded side does not matter if not closed.
                if ((test_bounded_sides && IsClosed && mesh.IsClosed) || !test_bounded_sides)
                {
                    return Kernel.DoIntersects(Ptr, mesh.Ptr, test_bounded_sides).ToBoolOrUndetermined();
                }
                else
                    return BOOL_OR_UNDETERMINED.UNDETERMINED;
            }
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

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
        /// Compute the vertex normal map.
        /// Will only be computed if mesh has
        /// changed since last computation or 
        /// no current nomral maps have been computed.
        /// </summary>
        public void ComputeVertexNormals()
        {
            Kernel.ComputeVertexNormals(Ptr);
        }

        /// <summary>
        /// Compute the face normal map.
        /// Will only be computed if mesh has
        /// changed since last computation or 
        /// no current nomral maps have been computed.
        /// </summary>
        public void ComputeFaceNormals()
        {
            Kernel.ComputeFaceNormals(Ptr);
        }

        /// <summary>
        /// Get the vertex normals.
        /// Will be compute if they have not aready.
        /// </summary>
        /// <param name="normals">The normal map array.</param>
        /// <param name="count">The normal maps array length.</param>
        public void GetVertexNormals(Vector3d[] normals, int count)
        {
            Kernel.GetVertexNormals(Ptr, normals, count);
        }

        /// <summary>
        /// Get the face normals.
        /// Will be compute if they have not aready.
        /// </summary>
        /// <param name="normals">The normal map array.</param>
        /// <param name="count">The normal maps array length.</param>
        public void GetFaceNormals(Vector3d[] normals, int count)
        {
            Kernel.GetFaceNormals(Ptr, normals, count);
        }

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
            builder.AppendLine(ToString());
            builder.AppendLine("BuildStamp = " + BuildStamp);
            builder.AppendLine("IsValid = " + IsValid);
            builder.AppendLine("VertexCount = " + VertexCount);
            builder.AppendLine("FaceCount = " + FaceCount);
            builder.AppendLine("EdgeCount = " + EdgeCount);
            builder.AppendLine("RemovedVertexCount = " + RemovedVertexCount);
            builder.AppendLine("RemovedFaceCount = " + RemovedFaceCount);
            builder.AppendLine("RemovedHalfdgeCount = " + RemovedHalfedgeCount);
            builder.AppendLine("RemovedEdgeCount = " + RemovedEdgeCount);
            builder.AppendLine("BorderEdgeCount = " + BorderEdgeCount);
            builder.AppendLine("HasGarbage = " + HasGarbage);
            builder.AppendLine("IsTriangle = " + IsTriangle);
            builder.AppendLine("IsQuad = " + IsQuad);
            builder.AppendLine("IsClosed = " + IsClosed);
        }

        /// <summary>
        /// 
        /// </summary>
        internal void PrintVertices()
        {
            foreach(var p in this)
                Console.WriteLine(p);
        }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
