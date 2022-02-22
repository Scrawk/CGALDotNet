using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNet.Polygons;
using CGALDotNet.Hulls;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// Generic triangulation class.
    /// </summary>
    /// <typeparam name="K">The kerel.</typeparam>
    public sealed class Triangulation2<K> : Triangulation2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of a triangulation.
        /// </summary>
        public static readonly Triangulation2<K> Instance = new Triangulation2<K>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Triangulation2() : base(new K())
        {

        }

        /// <summary>
        /// Construct a triangulation from the points.
        /// </summary>
        /// <param name="points">The triangulation points.</param>
        public Triangulation2(Point2d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// Construct from a existing triangulation.
        /// </summary>
        /// <param name="ptr">A pointer to the unmanaged object.</param>
        internal Triangulation2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The triangulation as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Triangulation2<{0}>: VertexCount={1}, TriangleCount={2}]",
                Kernel.Name, VertexCount, TriangleCount);
        }

        /// <summary>
        /// Create a deep copy of the triangulation.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public Triangulation2<K> Copy()
        {
            return new Triangulation2<K>(Kernel.Copy(Ptr));
        }

        /// <summary>
        /// Insert the points of the polygon into the triagulation.
        /// May no have the same edges as polygon.
        /// </summary>
        /// <param name="polygon">The polygon to insert/</param>
        public void InsertPolygon(Polygon2<K> polygon)
        {
            if (polygon == null) 
                return;

            Kernel.InsertPolygon(Ptr, polygon.Ptr);
        }

        /// <summary>
        /// Insert the points of the polygon into the triagulation.
        /// May no have the same edges as polygon.
        /// </summary>
        /// <param name="pwh">The polygon to insert/</param>
        public void InsertPolygon(PolygonWithHoles2<K> pwh)
        {
            if (pwh == null)
                return;

            Kernel.InsertPolygonWithHoles(Ptr, pwh.Ptr);
        }

        /// <summary>
        /// Compute the convex of the triagulation.
        /// </summary>
        /// <returns>The convex hull polygon.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Polygon2<K> ComputeHull()
        {
            int count = VertexCount;
            if (count < 3)
                throw new InvalidOperationException("Trianglution must have at least 3 points to compute the hull.");

            var points = ArrayCache.Point2dArray(count);
            GetPoints(points, count);

            var hull = ConvexHull2<K>.Instance;
            return hull.CreateHull(points, count);
        }

    }

    /// <summary>
    /// Abstract base class for the triagulation.
    /// </summary>
    public abstract class Triangulation2 : BaseTriangulation2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal Triangulation2(CGALKernel kernel) 
            : base(kernel.TriangulationKernel2)
        {
            TriangulationKernel = Kernel as TriangulationKernel2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="points"></param>
        internal Triangulation2(CGALKernel kernel, Point2d[] points)
            : base(kernel.TriangulationKernel2, points)
        {
            TriangulationKernel = Kernel as TriangulationKernel2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal Triangulation2(CGALKernel kernel, IntPtr ptr) 
            : base(kernel.TriangulationKernel2, ptr)
        {
            TriangulationKernel = Kernel as TriangulationKernel2;
        }

        /// <summary>
        /// The kernel with the functions unique to the triangulation.
        /// </summary>
        protected private TriangulationKernel2 TriangulationKernel { get; private set; }

        /// <summary>
        /// Move the vertex.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="point"></param>
        /// <param name="ifNoCollision">If there is not already another vertex placed on the point, 
        /// the triangulation is modified such that the new position of vertex same as point.</param>
        /// <param name="vertex">The moved vertex</param>
        /// <returns>True if the vertex was found.</returns>
        public bool MoveVertex(int index, Point2d point, bool ifNoCollision, out TriVertex2 vertex)
        {
            return TriangulationKernel.MoveVertex(Ptr, index, point, ifNoCollision, out vertex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("IsValid = " + IsValid());
            builder.AppendLine("BuildStamp = " + BuildStamp);
            builder.AppendLine("VertexCount = " + VertexCount);
            builder.AppendLine("TriangleCount = " + TriangleCount);
            builder.AppendLine("IndiceCount = " + IndiceCount);
        }

    }
}
