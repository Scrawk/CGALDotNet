using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{

    /// <summary>
    /// Generic polyhedron definition.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class Polyhedra3<K> : Polyhedra3 where K : CGALKernel, new()
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Polyhedra3() : base(new K())
        {

        }

        /// <summary>
        /// Create with a set size for each element.
        /// </summary>
        /// <param name="vertices">The number of vertices</param>
        /// <param name="halfEdges">The number of halfedges</param>
        /// <param name="faces">The number of faces</param>
        public Polyhedra3(int vertices, int halfEdges, int faces) :
            base(vertices, halfEdges, faces, new K())
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polyhedrons pointer.</param>
        internal Polyhedra3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polyhdron as a string.
        /// </summary>
        /// <returns>The polyhedron as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Polyhedra3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FaceCount={3}]",
                Kernel.KernelName, VertexCount, HalfEdgeCount, FaceCount);
        }

    }

    /// <summary>
    /// The abstract polyhedra definition.
    /// </summary>
    public abstract class Polyhedra3 : CGALObject
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Polyhedra3()
        {

        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        internal Polyhedra3(CGALKernel kernel)
        {
            Kernel = kernel.PolyhedronKernel3;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Create with a set size for each element.
        /// </summary>
        /// <param name="vertices">The number of vertices.</param>
        /// <param name="halfEdges">The number of halfedges.</param>
        /// <param name="faces">The number of faces.</param>
        /// <param name="kernel">The polyhedra kernel.</param>
        internal Polyhedra3(int vertices, int halfEdges, int faces, CGALKernel kernel)
        {
            Kernel = kernel.PolyhedronKernel3;
            Ptr = Kernel.CreateFromSize(vertices, halfEdges, faces);
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        /// <param name="ptr">The polyhedrons pointer.</param>
        internal Polyhedra3(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolyhedronKernel3;
        }

        /// <summary>
        /// The polyhedron kernel.
        /// Contains the functions to the unmanaged CGAL polhedron.
        /// </summary>
        protected private PolyhedronKernel3 Kernel { get; private set; }

        public int VertexCount => Kernel.VertexCount(Ptr);

        public int FaceCount => Kernel.FaceCount(Ptr);

        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        public int BorderEdgeCount => Kernel.BorderEdgeCount(Ptr);

        public int BorderHalfEdgeCount => Kernel.BorderHalfEdgeCount(Ptr);

        public bool IsClosed => Kernel.IsClosed(Ptr);

        public bool IsPureBivalent => Kernel.IsPureBivalent(Ptr);

        public bool IsPureTrivalent => Kernel.IsPureTrivalent(Ptr);

        public bool IsPureTriangle => Kernel.IsPureTriangle(Ptr);

        public bool IsPureQuad => Kernel.IsPureQuad(Ptr);

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

        internal void MakeTetrahedron(Point3d p1, Point3d p2, Point3d p3, Point3d p4)
        {
            Kernel.MakeTetrahedron(Ptr, p1, p2, p3, p4);
        }

        internal void MakeTriangle(Point3d p1, Point3d p2, Point3d p3)
        {
            Kernel.MakeTriangle(Ptr, p1, p2, p3);
        }

        public void CreateTriangleMesh(Point3d[] points, int[] indices)
        {
            if (points == null || points.Length == 0) return;
            if (indices == null || indices.Length == 0) return;

            Clear();
            Kernel.CreateTriangleMesh(Ptr, points, points.Length, indices, indices.Length);
        }

        public void GetPoints(Point3d[] points)
        {
            if (points == null || points.Length == 0) return;

            Kernel.GetPoints(Ptr, points, points.Length);
        }

        public void GetTriangleIndices(int[] indices)
        {
            if (indices == null || indices.Length == 0) return;

            Kernel.GetTriangleIndices(Ptr, indices, indices.Length);
        }

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
            builder.AppendLine("HalfEdgeCount = " + HalfEdgeCount);
            builder.AppendLine("BorderEdgeCount = " + BorderEdgeCount);
            builder.AppendLine("BorderHalfEdgeCount = " + BorderHalfEdgeCount);
            builder.AppendLine("IsValid = " + IsValid());
            builder.AppendLine("IsClosed = " + IsClosed);
            builder.AppendLine("IsPureBivalent = " + IsPureBivalent);
            builder.AppendLine("IsPureTrivalent= " + IsPureTrivalent);
            builder.AppendLine("IsPureTriangle = " + IsPureTriangle);
            builder.AppendLine("IsPureQuad = " + IsPureQuad);
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
