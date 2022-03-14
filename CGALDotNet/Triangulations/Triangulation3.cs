using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Extensions;

using CGALDotNet.Meshing;
using CGALDotNet.Hulls;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// Generic triangulation class.
    /// </summary>
    /// <typeparam name="K">The kerel.</typeparam>
    public sealed class Triangulation3<K> : Triangulation3 where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of a triangulation.
        /// </summary>
        public static readonly Triangulation3<K> Instance = new Triangulation3<K>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Triangulation3() : base(new K())
        {

        }

        /// <summary>
        /// Construct a triangulation from the points.
        /// </summary>
        /// <param name="points">The triangulation points.</param>
        public Triangulation3(Point3d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// Construct from a existing triangulation.
        /// </summary>
        /// <param name="ptr">A pointer to the unmanaged object.</param>
        internal Triangulation3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The triangulation as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Triangulation3<{0}>: VertexCount={1}, TetrahedronCount={2}, TriangleCount={3}]",
                Kernel.Name, VertexCount, FiniteTetrahedronCount, FiniteTriangleCount);
        }

        /// <summary>
        /// Create a deep copy of the triangulation.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public Triangulation3<K> Copy()
        {
            return new Triangulation3<K>(Kernel.Copy(Ptr));
        }

        /// <summary>
        /// Refine the triangulation.
        /// </summary>
        /// <param name="targetEdgeLength">The target edge lengths.</param>
        /// <param name="iterations">The number of iterations.</param>
        public void Refine(double targetEdgeLength, int iterations = 1)
        {
            int count = VertexCount;
            var points = ArrayCache.Point3dArray(count);
            GetPoints(points, count);

            var tet = TetrahedralRemeshing<K>.Instance;
            count = tet.Remesh(targetEdgeLength, iterations, points, count);

            if (count > 0)
            {
                points = ArrayCache.Point3dArray(count);
                tet.GetPoints(points, count);

                Clear();
                Insert(points, points.Length);
            }
        }

        /// <summary>
        /// Compute the convex of the triagulation.
        /// </summary>
        /// <returns>The convex hull polygon.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Polyhedron3<K> ComputeHull()
        {
            int count = VertexCount;
            if (count < 4)
                throw new InvalidOperationException("Trianglution must have at least 4 points to compute the hull.");

            var points = new Point3d[count];
            GetPoints(points, count);

            points = points.RemoveNonFinite().ToArray();

            var hull = ConvexHull3<K>.Instance;
            return hull.CreateHullAsPolyhedron(points, points.Length);
        }

    }

    /// <summary>
    /// Abstract base class for the triagulation.
    /// </summary>
    public abstract class Triangulation3 : BaseTriangulation3
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal Triangulation3(CGALKernel kernel)
            : base(kernel.TriangulationKernel3)
        {
            TriangulationKernel = Kernel as TriangulationKernel3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="points"></param>
        internal Triangulation3(CGALKernel kernel, Point3d[] points)
            : base(kernel.TriangulationKernel3, points)
        {
            TriangulationKernel = Kernel as TriangulationKernel3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal Triangulation3(CGALKernel kernel, IntPtr ptr)
            : base(kernel.TriangulationKernel3, ptr)
        {
            TriangulationKernel = Kernel as TriangulationKernel3;
        }

        /// <summary>
        /// The kernel with the functions unique to the triangulation.
        /// </summary>
        protected private TriangulationKernel3 TriangulationKernel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("IsValid = " + IsValid());
            builder.AppendLine("Dimension = " + Dimension);
            builder.AppendLine("VertexCount = " + VertexCount);
            builder.AppendLine("FiniteVertexCount = " + FiniteVertexCount);
            builder.AppendLine("TetrahedronCount = " + TetrahedronCount);
            builder.AppendLine("FiniteTetrahedronCount = " + FiniteTetrahedronCount);
            builder.AppendLine("EdgeCount = " + EdgeCount);
            builder.AppendLine("FiniteEdgeCount = " + FiniteEdgeCount);
            builder.AppendLine("TriangleCount = " + TriangleCount);
            builder.AppendLine("FiniteTriangleCount = " + FiniteTriangleCount);
        }

    }
}
