using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// The generic delaunay triangulation class.
    /// </summary>
    /// <typeparam name="K">The kerne</typeparam>
    public sealed class DelaunayTriangulation2<K> : DelaunayTriangulation2 where K : CGALKernel, new()
    {
        /// <summary>
        /// A static instance of the delaunay triangulation.
        /// </summary>
        public static readonly DelaunayTriangulation2<K> Instance = new DelaunayTriangulation2<K>();

        /// <summary>
        /// 
        /// </summary>
        public DelaunayTriangulation2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        public DelaunayTriangulation2(Point2d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal DelaunayTriangulation2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The triangulation as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[DelaunayTriangulation2<{0}>: VertexCount={1}, FaceCount={2}]",
                Kernel.Name, VertexCount, TriangleCount);
        }

        /// <summary>
        /// A deep copy of the triangulation.
        /// </summary>
        /// <returns></returns>
        public DelaunayTriangulation2<K> Copy()
        {
            return new DelaunayTriangulation2<K>(Kernel.Copy(Ptr));
        }

        /// <summary>
        /// Insert the polygons points into the triangulation.
        /// May not retatin the poylgons edges.
        /// </summary>
        /// <param name="polygon">The polygon to insert.</param>
        public void InsertPolygon(Polygon2<K> polygon)
        {
            if (polygon == null)
                return;

            Kernel.InsertPolygon(Ptr, polygon.Ptr);
        }

        /// <summary>
        /// Insert the polygons points into the triangulation.
        /// May not retatin the poylgons edges.
        /// </summary>
        /// <param name="pwh">The polygon to insert.</param>
        public void InsertPolygon(PolygonWithHoles2<K> pwh)
        {
            if (pwh == null)
                return;

            Kernel.InsertPolygonWithHoles(Ptr, pwh.Ptr);
        }

    }

    /// <summary>
    /// The anstract base class for the delaunay triangulation.
    /// </summary>
    public abstract class DelaunayTriangulation2 : BaseTriangulation2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal DelaunayTriangulation2(CGALKernel kernel) 
            : base(kernel.DelaunayTriangulationKernel2)
        {
            TriangulationKernel = Kernel as DelaunayTriangulationKernel2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="points"></param>
        internal DelaunayTriangulation2(CGALKernel kernel, Point2d[] points) 
            : base(kernel.DelaunayTriangulationKernel2, points)
        {
            TriangulationKernel = Kernel as DelaunayTriangulationKernel2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal DelaunayTriangulation2(CGALKernel kernel, IntPtr ptr) 
            : base(kernel.DelaunayTriangulationKernel2, ptr)
        {
            TriangulationKernel = Kernel as DelaunayTriangulationKernel2;
        }

        /// <summary>
        /// The kernel with the functions unique to the delaunay triangulation.
        /// </summary>
        protected private DelaunayTriangulationKernel2 TriangulationKernel { get; private set; }

        /// <summary>
        /// If the dual voronoi diagram of the triangulation is taken
        /// How many segments and rays would be produced.
        /// </summary>
        /// <param name="numSegments">The number of segments.</param>
        /// <param name="numRays">The number of rays.</param>
        public void GetVoronoCount(out int numSegments, out int numRays)
        {
            TriangulationKernel.VoronoiCount(Ptr, out numSegments, out numRays);
        }

        /// <summary>
        /// Get a array of the voronoi's segments.
        /// </summary>
        /// <returns>A array of the voronoi's segments.</returns>
        public Segment2d[] GetVoronoiSegments()
        {
            TriangulationKernel.VoronoiCount(Ptr, out int numSegments, out int numRays);
            var segments = new Segment2d[numSegments];
            TriangulationKernel.GetVoronoiSegments(Ptr, segments, 0, segments.Length);
            return segments;
        }

        /// <summary>
        /// Get a array of the voronois rays.
        /// These are the segment at edge of triangulation that 
        /// a end point can not be determined.
        /// </summary>
        /// <returns>A array of the voronoi's rays.</returns>
        public Ray2d[] GetVoronoiRays()
        {
            TriangulationKernel.VoronoiCount(Ptr, out int numSegments, out int numRays);
            var rays = new Ray2d[numRays];
            TriangulationKernel.GetVoronoiRays(Ptr, rays, 0, rays.Length);
            return rays;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Is valid = " + IsValid());
        }

    }
}
