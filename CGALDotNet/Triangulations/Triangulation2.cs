using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Triangulations
{

    public sealed class Triangulation2<K> : Triangulation2 where K : CGALKernel, new()
    {

        public static readonly Triangulation2<K> Instance = new Triangulation2<K>();

        public Triangulation2() : base(new K())
        {

        }

        public Triangulation2(Point2d[] points) : base(new K(), points)
        {

        }

        public Triangulation2(Polygon2<K> polygon) : base(new K())
        {
            InsertPolygon(polygon);
        }

        public Triangulation2(PolygonWithHoles2<K> polygon) : base(new K())
        {
            InsertPolygon(polygon);
        }

        internal Triangulation2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Triangulation2<{0}>: VertexCount={1}, FaceCount={2}]",
                Kernel.Name, VertexCount, TriangleCount);
        }

        public Triangulation2<K> Copy()
        {
            return new Triangulation2<K>(Kernel.Copy(Ptr));
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

    public abstract class Triangulation2 : BaseTriangulation2
    {

        internal Triangulation2(CGALKernel kernel) 
            : base(kernel.TriangulationKernel2)
        {
            TriangulationKernel = Kernel as TriangulationKernel2;
        }

        internal Triangulation2(CGALKernel kernel, Point2d[] points)
            : base(kernel.TriangulationKernel2, points)
        {
            TriangulationKernel = Kernel as TriangulationKernel2;
        }

        internal Triangulation2(CGALKernel kernel, IntPtr ptr) 
            : base(kernel.TriangulationKernel2, ptr)
        {
            TriangulationKernel = Kernel as TriangulationKernel2;
        }

        protected private TriangulationKernel2 TriangulationKernel { get; private set; }

        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Is valid = " + IsValid()); ;
        }

    }
}
