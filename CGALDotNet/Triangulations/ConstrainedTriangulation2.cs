using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Triangulations
{

    public sealed class ConstrainedTriangulation2<K> : ConstrainedTriangulation2 where K : CGALKernel, new()
    {

        public static readonly ConstrainedTriangulation2<K> Instance = new ConstrainedTriangulation2<K>();

        public ConstrainedTriangulation2() : base(new K())
        {

        }

        public ConstrainedTriangulation2(Point2d[] points) : base(new K(), points)
        {

        }

        public ConstrainedTriangulation2(Polygon2<K> polygon) : base(new K())
        {
            InsertPolygon(polygon);
        }

        public ConstrainedTriangulation2(PolygonWithHoles2<K> polygon) : base(new K())
        {
            InsertPolygon(polygon);
        }

        internal ConstrainedTriangulation2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[ConstrainedTriangulation2<{0}>: VertexCount={1}, FaceCount={2}]",
                Kernel.Name, VertexCount, FaceCount);
        }

        public ConstrainedTriangulation2<K> Copy()
        {
            return new ConstrainedTriangulation2<K>(Kernel.Copy(Ptr));
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

    public abstract class ConstrainedTriangulation2 : BaseTriangulation2
    {

        internal ConstrainedTriangulation2(CGALKernel kernel) : base(kernel)
        {

        }

        internal ConstrainedTriangulation2(CGALKernel kernel, Point2d[] points) : base(kernel, points)
        {
            TriangulationKernel = kernel.ConstrainedTriangulationKernel2;
        }

        internal ConstrainedTriangulation2(CGALKernel kernel, IntPtr ptr) : base(kernel, ptr)
        {
            TriangulationKernel = kernel.ConstrainedTriangulationKernel2;
        }

        protected private ConstrainedTriangulationKernel2 TriangulationKernel { get; private set; }

    }
}
