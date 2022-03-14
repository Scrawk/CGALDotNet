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
    public sealed class DelaunayTriangulation3<K> : DelaunayTriangulation3 where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of a triangulation.
        /// </summary>
        public static readonly DelaunayTriangulation3<K> Instance = new DelaunayTriangulation3<K>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DelaunayTriangulation3() : base(new K())
        {

        }

        /// <summary>
        /// Construct a triangulation from the points.
        /// </summary>
        /// <param name="points">The triangulation points.</param>
        public DelaunayTriangulation3(Point3d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// Construct from a existing triangulation.
        /// </summary>
        /// <param name="ptr">A pointer to the unmanaged object.</param>
        internal DelaunayTriangulation3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The triangulation as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[DelaunayTriangulation3<{0}>: VertexCount={1}, TetrahedronCount={2}, TriangleCount={3}]",
                Kernel.Name, VertexCount, FiniteTetrahedronCount, FiniteTriangleCount);
        }

        /// <summary>
        /// Create a deep copy of the triangulation.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public DelaunayTriangulation3<K> Copy()
        {
            return new DelaunayTriangulation3<K>(Kernel.Copy(Ptr));
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
    public abstract class DelaunayTriangulation3 : BaseTriangulation3
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal DelaunayTriangulation3(CGALKernel kernel)
            : base(kernel.TriangulationKernel3)
        {
            TriangulationKernel = Kernel as DelaunayTriangulationKernel3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="points"></param>
        internal DelaunayTriangulation3(CGALKernel kernel, Point3d[] points)
            : base(kernel.TriangulationKernel3, points)
        {
            TriangulationKernel = Kernel as DelaunayTriangulationKernel3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal DelaunayTriangulation3(CGALKernel kernel, IntPtr ptr)
            : base(kernel.TriangulationKernel3, ptr)
        {
            TriangulationKernel = Kernel as DelaunayTriangulationKernel3;
        }

        /// <summary>
        /// The kernel with the functions unique to the triangulation.
        /// </summary>
        protected private DelaunayTriangulationKernel3 TriangulationKernel { get; private set; }

        /// <summary>
        /// Move a vertex.
        /// </summary>
        /// <param name="index">The vertices index.</param>
        /// <param name="point">The point to move to.</param>
        /// <param name="ifNoCollision">Should the vertex only be moved if there is no coliision.</param>
        /// <returns>If the vertex was moved.</returns>
        public bool Move(int index, Point3d point, bool ifNoCollision = true)
        {
            return TriangulationKernel.Move(Ptr, index, point, ifNoCollision);
        }

        /// <summary>
        /// Find the index of the nearest vertex to the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The index of the nearest vertex to the point.</returns>
        public int NearestVertex(Point3d point)
        {
            return TriangulationKernel.NearestVertex(Ptr, point);
        }

        /// <summary>
        /// Find the index of the nearest vertex to the point.
        /// Presumes poimt is in a cell.
        /// </summary>
        /// <param name="index">The cells index.</param>
        /// <param name="point">The point.</param>
        /// <returns>The index of the nearest vertex to the point.</returns>
        public int NearestVertexInCell(int index, Point3d point)
        {
            return TriangulationKernel.NearestVertexInCell(Ptr, index, point);
        }

        /// <summary>
        /// Remobe a vertex.
        /// </summary>
        /// <param name="index">The vertex index.</param>
        /// <returns>True if vertex was removed.</returns>
        public bool RemoveVertex(int index)
        {
            return TriangulationKernel.RemoveVertex(Ptr, index);
        }

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
