using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{


    /// <summary>
    /// The generic surface mesh class.
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
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The surface meshes pointer.</param>
        internal SurfaceMesh3(IntPtr ptr) : base(new K(), ptr)
        {

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
        /// The mesh as a string.
        /// </summary>
        /// <returns>The mesh as a string.</returns>
        public override string ToString()
        {
            return string.Format("[SurfaceMesh3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FaceCount={3}]",
                Kernel.KernelName, VertexCount, HalfEdgeCount, FaceCount);
        }
    }

    /// <summary>
    /// The surface mesh abstract base class.
    /// </summary>
    public abstract class SurfaceMesh3 : CGALObject
    {
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
        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        /// <summary>
        /// The number of edges in the mesh.
        /// </summary>
        public int EdgeCount => Kernel.EdgeCount(Ptr);

        /// <summary>
        /// The number of faces in the mesh.
        /// </summary>
        public int FaceCount => Kernel.FaceCount(Ptr);

        /// <summary>
        /// Does the mesh only contain triangles.
        /// </summary>
        /// <returns>Does the mesh only contain triangles.</returns>
        //public bool IsPureTriangle => Kernel.CheckFaceVertices(Ptr, 3);

        /// <summary>
        /// Does the mesh only contain quads.
        /// </summary>
        /// <returns>Does the mesh only contain quads.</returns>
        //public bool IsPureQuad => Kernel.CheckFaceVertices(Ptr, 4);
 
        /// <summary>
        /// The largest number of vertices in a face belonging to the mesh.
        /// </summary>
        /// <returns>The largest number of vertices in a face belonging to the mesh.</returns>
        //public int MaxFaceVertices => Kernel.MaxFaceVertices(Ptr);

        /// <summary>
        /// Checks if the mesh is valid.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        /// <summary>
        /// Adds a vertex to the mesh.
        /// </summary>
        /// <param name="point">The vertices position</param>
        /// <returns>The vertices index in the mesh.</returns>
        public SurfaceMeshVertex AddVertex(Point3d point)
        {
            return new SurfaceMeshVertex(Kernel.AddVertex(Ptr, point));
        }

        /// <summary>
        /// Adds a edge between the two vertices.
        /// </summary>
        /// <param name="v0">The index of the vertex in the mesh.</param>
        /// <param name="v1">The index of the vertex in the mesh.</param>
        /// <returns>The index of the edge in the mesh.</returns>
        public SurfaceMeshHalfedge AddEdge(SurfaceMeshVertex v0, SurfaceMeshVertex v1)
        {
            return new SurfaceMeshHalfedge(Kernel.AddEdge(Ptr, v0.index, v1.index));
        }

        /// <summary>
        /// Adds a triangle face to the mesh.
        /// </summary>
        /// <param name="v0">The index of the vertex in the mesh.</param>
        /// <param name="v1">The index of the vertex in the mesh.</param>
        /// <param name="v2">The index of the vertex in the mesh.</param>
        /// <returns>The index of the face in the mesh.</returns>
        public SurfaceMeshFace AddTriangle(SurfaceMeshVertex v0, SurfaceMeshVertex v1, SurfaceMeshVertex v2)
        {
            return new SurfaceMeshFace(Kernel.AddTriangle(Ptr, v0.index, v1.index, v2.index));
        }

        /// <summary>
        /// Adds a quad face to the mesh.
        /// </summary>
        /// <param name="v0">The index of the vertex in the mesh.</param>
        /// <param name="v1">The index of the vertex in the mesh.</param>
        /// <param name="v2">The index of the vertex in the mesh.</param>
        /// <returns>The index of the face in the mesh.</returns>
        public SurfaceMeshFace AddQuad(SurfaceMeshVertex v0, SurfaceMeshVertex v1, SurfaceMeshVertex v2, SurfaceMeshVertex v3)
        {
            return new SurfaceMeshFace(Kernel.AddQuad(Ptr, v0.index, v1.index, v2.index, v3.index));
        }

        /// <summary>
        /// Checks if any vertices, halfedges, edges, or faces are marked as removed.
        /// </summary>
        /// <returns></returns>
        public bool HasGarbage()
        {
            return Kernel.HasGarbage(Ptr);
        }

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
        /// <param name="collect"></param>
        public void SetRecycleGarbage(bool collect)
        {
            Kernel.SetRecycleGarbage(Ptr, collect);
        }

        /// <summary>
        /// Will the mesh collect garbage.
        /// </summary>
        /// <returns></returns>
        public bool DoesRecycleGarbage()
        {
            return Kernel.DoesRecycleGarbage(Ptr);
        }

        /// <summary>
        /// Get the vertices point.
        /// </summary>
        /// <param name="index">The vertex index in the mesh.</param>
        /// <returns>The vertices point.</returns>
        public Point3d GetPoint(int index)
        {
            return Kernel.GetPoint(Ptr, index);
        }

        /// <summary>
        /// Get the vertices point.
        /// </summary>
        /// <param name="vertex">The vertex index in the mesh.</param>
        /// <returns>The vertices point.</returns>
        public Point3d GetPoint(SurfaceMeshVertex vertex)
        {
            return Kernel.GetPoint(Ptr, vertex.index);
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
        /// Returns the number of incident halfedges of vertex.
        /// </summary>
        /// <param name="vertex">The index of the vertex in the mesh.</param>
        /// <returns>Returns the number of incident halfedges of vertex.</returns>
        public int VertexDegree(SurfaceMeshVertex vertex)
        {
            return Kernel.VertexDegree(Ptr, vertex.index);
        }

        /// <summary>
        /// Returns the number of incident halfedges of face.
        /// </summary>
        /// <param name="face">The index of the face in the mesh.</param>
        /// <returns>Returns the number of incident halfedges of face.</returns>
        public int FaceDegree(SurfaceMeshFace face)
        {
            return Kernel.FaceDegree(Ptr, face.index);
        }

        /// <summary>
        /// Returns whether vertex is isolated.
        /// </summary>
        /// <param name="vertex">The index of the vertex in the mesh.</param>
        /// <returns>Returns whether vertex is isolated.</returns>
        public bool VertexIsIsolated(SurfaceMeshVertex vertex)
        {
            return Kernel.VertexIsIsolated(Ptr, vertex.index);
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
        public bool VertexIsBorder(SurfaceMeshVertex vertex, bool check_all_incident_halfedges = true)
        {
            return Kernel.VertexIsBorder(Ptr, vertex.index, check_all_incident_halfedges);
        }

        /// <summary>
        /// Returns whether edge is a border edge, i.e., if any of its two halfedges is a border halfedge.
        /// </summary>
        /// <param name="edge">The index of the edge in the mesh.</param>
        /// <returns>Returns whether edge is a border edge.</returns>
        public bool EdgeIsBorder(SurfaceMeshEdge edge)
        {
            return Kernel.EdgeIsBorder(Ptr, edge.index);
        }

        /// <summary>
        /// Returns the next halfedge within the incident face.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the next halfedge within the incident face.</returns>
        public SurfaceMeshHalfedge NextHalfedge(SurfaceMeshHalfedge halfedge)
        {
            return  new SurfaceMeshHalfedge(Kernel.NextHalfedge(Ptr, halfedge.index));
        }

        /// <summary>
        /// Returns the previous halfedge within the incident face.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the previous halfedge within the incident face.</returns>
        public SurfaceMeshHalfedge PreviousHalfedge(SurfaceMeshHalfedge halfedge)
        {
            return new SurfaceMeshHalfedge(Kernel.PreviousHalfedge(Ptr, halfedge.index));
        }

        /// <summary>
        /// Returns the opposite halfedge of halfedge.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the opposite halfedge of halfedge.</returns>
        public SurfaceMeshHalfedge OppositeHalfedge(SurfaceMeshHalfedge halfedge)
        {
            return new SurfaceMeshHalfedge(Kernel.OppositeHalfedge(Ptr, halfedge.index));   
        }

        /// <summary>
        /// Returns the vertex the halfedge emanates from.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the vertex the halfedge emanates from.</returns>
        public SurfaceMeshVertex SourceVertex(SurfaceMeshHalfedge halfedge)
        {
            return new SurfaceMeshVertex(Kernel.SourceVertex(Ptr, halfedge.index));
        }

        /// <summary>
        /// Returns the vertex the halfedge points to.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>Returns the vertex the halfedge points to.</returns>
        public SurfaceMeshVertex TargetVertex(SurfaceMeshHalfedge halfedge)
        {
            return new SurfaceMeshVertex(Kernel.TargetVertex(Ptr, halfedge.index));
        }

        /// <summary>
        /// Removes vertex from the halfedge data structure without adjusting anything.
        /// </summary>
        /// <param name="vertex">The index of the vertex in the mesh.</param>
        public void RemoveVertex(SurfaceMeshVertex vertex)
        {
            Kernel.RemoveVertex(Ptr, vertex.index);
        }

        /// <summary>
        /// Removes the two halfedges corresponding to edge from the halfedge
        /// data structure without adjusting anything.
        /// </summary>
        /// <param name="edge">The index of the edge in the mesh.</param>
        public void RemoveEdge(SurfaceMeshEdge edge)
        {
            Kernel.RemoveEdge(Ptr, edge.index);
        }

        /// <summary>
        /// Removes face from the halfedge data structure without adjusting anything.
        /// </summary>
        /// <param name="face">The index of the face in the mesh.</param>
        public void RemoveFace(SurfaceMeshFace face)
        {
            Kernel.RemoveFace(Ptr, face.index);
        }

        /// <summary>
        /// Performs a validity check on a single vertex.
        /// </summary>
        /// <param name="vertex">The index of the vertex in the mesh.</param>
        /// <returns>True if valid.</returns>
        public bool IsVertexValid(SurfaceMeshVertex vertex)
        {
            return Kernel.IsVertexValid(Ptr, vertex.index);
        }

        /// <summary>
        /// Performs a validity check on a single edge.
        /// </summary>
        /// <param name="edge">The index of the edge in the mesh.</param>
        /// <returns>True if valid.</returns>
        public bool IsEdgeValid(SurfaceMeshEdge edge)
        {
            return  Kernel.IsEdgeValid(Ptr, edge.index);
        }

        /// <summary>
        /// Performs a validity check on a single halfedge.
        /// </summary>
        /// <param name="halfedge">The index of the halfedge in the mesh.</param>
        /// <returns>True if valid.</returns>
        public bool IsHalfedgeValid(SurfaceMeshHalfedge halfedge)
        {
            return  Kernel.IsHalfedgeValid(Ptr, halfedge.index);
        }

        /// <summary>
        /// Performs a validity check on a single face.
        /// </summary>
        /// <param name="face">The index of the face in the mesh.</param>
        /// <returns>True if valid.</returns>
        public bool IsFaceValid(SurfaceMeshFace face)
        {
            return Kernel.IsFaceValid(Ptr, face.index);
        }

        /// <summary>
        /// Translate each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point3d translation)
        {
            var m = Matrix4x4d.Translate(translation);
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Rotate each point in the mesh.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Quaternion3d rotation)
        {
            var m = rotation.ToMatrix4x4d();
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Scale each point in the mesh.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(Point3d scale)
        {
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
            var m = Matrix4x4d.TranslateRotateScale(translation, rotation, scale);
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Create a triangle mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="indices">The meshes trinagles as a index array.</param>
        public void CreateTriangleMesh(Point3d[] points, int[] indices)
        {
            ErrorUtil.CheckArray(points, points.Length);
            ErrorUtil.CheckArray(indices, indices.Length);
            Kernel.CreateTriangleMesh(Ptr, points, points.Length, indices, indices.Length);
        }

        /// <summary>
        /// Get the mesh indices. Presumes mesh is pure triangle mesh.
        /// </summary>
        /// <param name="indices">The indices array.</param>
        /// <param name="count">The indices array length.</param>
        //public void GetTriangleIndices(int[] indices, int count)
        //{
        //    ErrorUtil.CheckArray(indices, count);
        //    Kernel.GetTriangleIndices(Ptr, indices, count);
        //}

        /// <summary>
        /// Print the polyhedron.
        /// </summary>
        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// Print the polyhedron into a string builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("EdgeCount = " + EdgeCount);
            builder.AppendLine("HasGarbage = " + HasGarbage());
            builder.AppendLine("DoesRecycleGarbage = " + DoesRecycleGarbage());
            //builder.AppendLine("IsPureTriangle = " + IsPureTriangle);
            //builder.AppendLine("IsPureQuad = " + IsPureQuad);
            //builder.AppendLine("MaxFaceVertices = " + MaxFaceVertices);
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
