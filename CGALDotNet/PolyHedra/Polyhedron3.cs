using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Processing;

namespace CGALDotNet.Polyhedra
{

    /// <summary>
    /// Generic polyhedron definition.
    /// A polyhedral surface Polyhedron_3 consists of vertices V, edges E, 
    /// facets F and an incidence relation on them.
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
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polyhedrons pointer.</param>
        internal Polyhedron3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polyhdron as a string.
        /// </summary>
        /// <returns>The polyhedron as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Polyhedron3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FaceCount={3}]",
                Kernel.KernelName, VertexCount, HalfEdgeCount, FaceCount);
        }

        /// <summary>
        /// Subdive the polyhedron.
        /// </summary>
        /// <param name="iterations">The number of iterations to perfrom.</param>
        /// <param name="method">The subdivision method.</param>
        public override void Subdivide(int iterations, SUBDIVISION_METHOD method = SUBDIVISION_METHOD.SQRT3)
        {
            try
            {
                var sub = SubdivisionSurface<K>.Instance;
                sub.Subdivide(method, this, iterations);
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
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };
        }

    }

    /// <summary>
    /// The abstract polyhedra definition.
    /// </summary>
    public abstract class Polyhedron3 : CGALObject
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Polyhedron3()
        {

        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        internal Polyhedron3(CGALKernel kernel)
        {
            Kernel = kernel.PolyhedronKernel3;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        /// <param name="ptr">The polyhedrons pointer.</param>
        internal Polyhedron3(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolyhedronKernel3;
        }

        /// <summary>
        /// The polyhedron kernel.
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
        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

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
        /// Returns true if there are no border edges.
        /// </summary>
        public bool IsClosed => Kernel.IsClosed(Ptr);

        /// <summary>
        /// Returns true if all vertices have exactly two incident edges.
        /// </summary>
        public bool IsBivalent => Kernel.IsPureBivalent(Ptr);

        /// <summary>
        /// Returns true if all vertices have exactly three incident edges.
        /// </summary>
        public bool IsTrivalent => Kernel.IsPureTrivalent(Ptr);

        /// <summary>
        /// Returns true if all faces are triangles.
        /// </summary>
        public bool IsTriangle => Kernel.IsPureTriangle(Ptr) == 0;

        /// <summary>
        /// Returns true if all faces are quads.
        /// </summary>
        public bool IsQuad => Kernel.IsPureQuad(Ptr) == 0;

        /// <summary>
        /// returns true if the polyhedral surface is combinatorially consistent.
        // For level == 1 the normalization of the border edges is checked too.
        // This method checks that each face is at least a triangle and that the
        // two incident facets of a non-border edge are distinct.
        /// </summary>
        /// <returns></returns>
        public bool IsValid(int level = 0)
        {
            return Kernel.IsValid(Ptr, level);
        }

        /// <summary>
        /// Clear the polyhedron.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        /// <summary>
        /// A tetrahedron is added to the polyhedral surface
        /// with its vertices initialized to p1, p2, p3, and p4.
        /// </summary>
        public void MakeTetrahedron(Point3d p1, Point3d p2, Point3d p3, Point3d p4)
        {
            Kernel.MakeTetrahedron(Ptr, p1, p2, p3, p4);
        }

        /// <summary>
        /// A triangle with border edges is added to the 
        /// polyhedral surface with its vertices initialized to p1, p2, and p3.
        /// </summary>
        public void MakeTriangle(Point3d p1, Point3d p2, Point3d p3)
        {
            Kernel.MakeTriangle(Ptr, p1, p2, p3);
        }

        /// <summary>
        /// Create a mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="triangles">The meshes triangles as a index array. Maybe null.</param>
        /// <param name="quads">The meshes quads as a index array. Maybe null.</param>
        public void CreateMesh(Point3d[] points, int[] triangles, int[] quads)
        {
            bool hasTriangles = triangles != null && triangles.Length > 0;
            bool hasquads = quads != null && quads.Length > 0;

            if (hasTriangles && hasquads)
                CreateTriangleQuadMesh(points, triangles, quads);
            else if (hasTriangles)
                CreateTriangleMesh(points, triangles);
            else if (hasquads)
                CreateQuadMesh(points, quads);
        }

        /// <summary>
        /// Create a triangle mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="indices">The meshes triangles as a index array.</param>
        public void CreateTriangleMesh(Point3d[] points, int[] triangles)
        {
            ErrorUtil.CheckArray(points, points.Length);
            ErrorUtil.CheckArray(triangles, triangles.Length);

            Clear();
            Kernel.CreateTriangleMesh(Ptr, points, points.Length, triangles, triangles.Length);
        }

        /// <summary>
        /// Create a quad mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="quads">The meshes quads as a index array.</param>
        public void CreateQuadMesh(Point3d[] points, int[] quads)
        {
            ErrorUtil.CheckArray(points, points.Length);
            ErrorUtil.CheckArray(quads, quads.Length);

            Clear();
            Kernel.CreateQuadMesh(Ptr, points, points.Length, quads, quads.Length);
        }

        /// <summary>
        /// Create a triangle mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="triangles">The meshes triangles as a index array.</param>
        /// <param name="quads">The meshes quads as a index array.</param>
        public void CreateTriangleQuadMesh(Point3d[] points, int[] triangles, int[] quads)
        {
            ErrorUtil.CheckArray(points, points.Length);
            ErrorUtil.CheckArray(triangles, triangles.Length);
            ErrorUtil.CheckArray(quads, quads.Length);

            Clear();
            Kernel.CreateTriangleQuadMesh(Ptr, points, points.Length, triangles, triangles.Length, quads, quads.Length);
        }

        /// <summary>
        /// Get the meshes points.
        /// </summary>
        /// <param name="points">The array to copy the points into.</param>
        /// <param name="count">The ararys length.</param>
        public void GetPoints(Point3d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
        }

        /// <summary>
        /// Count the number of triangles, quads and polygons in the mesh.
        /// </summary>
        /// <returns>The number of triangles, quads and polygons in the mesh.</returns>
        public PrimativeCount GetPrimativeCount()
        {
            return Kernel.GetPrimativeCount(Ptr);
        }

        /// <summary>
        /// Get the meshes triangle indices.
        /// </summary>
        /// <param name="indices">The array to copy the indices into.</param>
        /// <param name="count">The ararys length.</param>
        public void GetTriangleIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetTriangleIndices(Ptr, indices, count);
        }

        /// <summary>
        /// Get the meshes quad indices.
        /// </summary>
        /// <param name="indices">The array to copy the indices into.</param>
        /// <param name="count">The ararys length.</param>
        public void GetQuadIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetQuadIndices(Ptr, indices, count);
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
        /// Reverses face orientations.
        /// </summary>
        public void InsideOut()
        {
            Kernel.InsideOut(Ptr);
        }

        /// <summary>
        /// Make all faces triangles.
        /// </summary>
        public void Triangulate()
        {
            Kernel.Triangulate(Ptr);
        }

        /// <summary>
        /// sorts halfedges such that the non-border edges precede the border edges.
        /// For each border edge the halfedge iterator will reference the halfedge 
        /// incident to the facet right before the halfedge incident to the hole.
        /// </summary>
        public void NormalizeBorder()
        {
            Kernel.NormalizeBorder(Ptr);
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
        /// Subdive the polyhedron.
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
        /// Print the polyhedron into a string builder.
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            bool isValid = IsValid();

            builder.AppendLine(ToString());
            builder.AppendLine("HalfEdgeCount = " + HalfEdgeCount);
            builder.AppendLine("BorderEdgeCount = " + BorderEdgeCount);
            builder.AppendLine("BorderHalfEdgeCount = " + BorderHalfEdgeCount);
            builder.AppendLine("IsValid = " + isValid);
            builder.AppendLine("NormalizedBorderIsValid = " + NormalizedBorderIsValid());
            builder.AppendLine("IsClosed = " + IsClosed);

            if (isValid)
            {
                builder.AppendLine("IsBivalent = " + IsBivalent);
                builder.AppendLine("IsTrivalent= " + IsTrivalent);
                builder.AppendLine("IsTriangle = " + IsTriangle);
                builder.AppendLine("IsQuad = " + IsQuad);
            }
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
