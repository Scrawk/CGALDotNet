using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;

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
        /// Create from a set of points.
        /// </summary>
        /// <param name="points">The polhedrons points.</param>
        public Polyhedra3(Point3d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polhedrons pointer.</param>
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
                Kernel.Name, VertexCount, HalfEdgeCount, FaceCount);
        }

    }

    /// <summary>
    /// The abstract polyhedra definition.
    /// </summary>
    public abstract class Polyhedra3 : CGALObject //, IEnumerable<Point3d>
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
        /// <param name="kernel">The polhedron kernel.</param>
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
        /// <param name="kernel">The polhedron kernel.</param>
        /// <param name="points">The points to construct from.</param>
        internal Polyhedra3(CGALKernel kernel, Point3d[] points)
        {
            Kernel = kernel.PolyhedronKernel3;
            Ptr = Kernel.Create();
            //SetPoints(points);
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polhedron kernel.</param>
        /// <param name="ptr">The polhedrons pointer.</param>
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
        /// Clear the polhedron of all points.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        /*

        /// <summary>
        /// Translate the polhedron.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Translate(Ptr, translation);
        }

        /// <summary>
        /// Rotate the polhedron.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        public void Rotate(Radian rotation)
        {
            Kernel.Rotate(Ptr, rotation.angle);
        }

        /// <summary>
        /// Scale the polhedron.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Scale(Ptr, scale);
            IsUpdated = false;
        }

        /// <summary>
        /// Transform the polhedron with a TRS matrix.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point2d translation, Radian rotation, double scale)
        {
            Kernel.Transform(Ptr, translation, rotation.angle, scale);
            IsUpdated = false;
        }

        /// <summary>
        /// Enumerate all points in the polhedron.
        /// </summary>
        /// <returns>Each point in polhedron.</returns>
        public IEnumerator<Point2d> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return GetPoint(i);
        }

        /// <summary>
        /// Enumerate all points in the polhedron.
        /// </summary>
        /// <returns>Each point in polhedron.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Return all the points in the polhedron in a array.
        /// </summary>
        /// <returns>The array.</returns>
        public Point2d[] ToArray()
        {
            var points = new Point2d[Count];
            GetPoints(points);
            return points;
        }

        /// <summary>
        /// Return all the points in the polhedron in a list.
        /// </summary>
        /// <returns>The list.</returns>
        public List<Point2d> ToList()
        {
            var points = new List<Point2d>(Count);
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(i));

            return points;
        }
        */

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
        /// Print the polyhedron into a styring builder.
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
