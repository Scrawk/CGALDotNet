using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public sealed class PolygonVisibility2<K> : PolygonVisibility2 where K : CGALKernel, new()
    {

        public static readonly PolygonVisibility2<K> Instance = new PolygonVisibility2<K>();

        public PolygonVisibility2() : base(new K())
        {

        }

        public void ComputeVisibility(Polygon2<K> polygon, Point2d point)
        {
            int count = polygon.Count;
            var segments = new Segment2d[count];
            polygon.GetSegments(segments);
            Kernel.ComputeVisibility(polygon.Ptr, point, segments, 0, count);
        }

    }

    public abstract class PolygonVisibility2 : CGALObject
    {
        private PolygonVisibility2()
        {

        }

        internal PolygonVisibility2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonVisibilityKernel2;
            Ptr = Kernel.Create();
        }

        protected private PolygonVisibilityKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
