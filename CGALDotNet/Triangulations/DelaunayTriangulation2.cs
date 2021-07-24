using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Triangulations
{

    public sealed class DelaunayTriangulation2<K> : DelaunayTriangulation2 where K : CGALKernel, new()
    {
        public static readonly DelaunayTriangulation2<K> Instance = new DelaunayTriangulation2<K>();

        public DelaunayTriangulation2() : base(new K())
        {

        }

        public DelaunayTriangulation2(Point2d[] points) : base(new K(), points)
        {

        }

        public DelaunayTriangulation2(Polygon2<K> polygon) : base(new K())
        {
            InsertPolygon(polygon);
        }

        public DelaunayTriangulation2(PolygonWithHoles2<K> polygon) : base(new K())
        {
            InsertPolygon(polygon);
        }

        internal DelaunayTriangulation2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[DelaunayTriangulation2<{0}>: VertexCount={1}, FaceCount={2}]",
                Kernel.Name, VertexCount, FaceCount);
        }

        public DelaunayTriangulation2<K> Copy()
        {
            return new DelaunayTriangulation2<K>(Kernel.Copy(Ptr));
        }

        public void InsertPolygon(Polygon2<K> polygon)
        {
            Kernel.InsertPolygon(Ptr, polygon.Ptr);
        }

        public void InsertPolygon(PolygonWithHoles2<K> pwh)
        {
            Kernel.InsertPolygonWithHoles(Ptr, pwh.Ptr);
        }

    }

    public abstract class DelaunayTriangulation2 : BaseTriangulation2
    {

        internal DelaunayTriangulation2(CGALKernel kernel) : base(kernel)
        {
            TriangulationKernel = kernel.DelaunayTriangulationKernel2;
        }

        internal DelaunayTriangulation2(CGALKernel kernel, Point2d[] points) : base(kernel, points)
        {
            TriangulationKernel = kernel.DelaunayTriangulationKernel2;
        }

        internal DelaunayTriangulation2(CGALKernel kernel, IntPtr ptr) : base(kernel, ptr)
        {
            TriangulationKernel = kernel.DelaunayTriangulationKernel2;
        }

        protected private DelaunayTriangulationKernel2 TriangulationKernel { get; private set; }

        public Segment2d[] GetVoronoiSegments()
        {
            TriangulationKernel.VoronoiCount(Ptr, out int numSegments, out int numRays);
            var segments = new Segment2d[numSegments];
            TriangulationKernel.GetVoronoiSegments(Ptr, segments, 0, segments.Length);
            return segments;
        }

        public Ray2d[] GetVoronoiRays()
        {
            TriangulationKernel.VoronoiCount(Ptr, out int numSegments, out int numRays);
            var rays = new Ray2d[numRays];
            TriangulationKernel.GetVoronoiRays(Ptr, rays, 0, rays.Length);
            return rays;
        }

    }
}
