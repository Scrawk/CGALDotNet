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
                Kernel.Name, VertexCount, FaceCount);
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

    public abstract class Triangulation2 : CGALObject
    {
        private Triangulation2()
        {

        }

        internal Triangulation2(CGALKernel kernel)
        {
            Kernel = kernel.TriangulationKernel2;
            Ptr = Kernel.Create();
        }

        internal Triangulation2(CGALKernel kernel, Point2d[] points)
        {
            Kernel = kernel.TriangulationKernel2;
            Ptr = Kernel.Create();
            InsertPoints(points);
        }

        internal Triangulation2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.TriangulationKernel2;
        }

        protected private TriangulationKernel2 Kernel { get; private set; }

        public int VertexCount => Kernel.VertexCount(Ptr);

        public int FaceCount => Kernel.FaceCount(Ptr);

        public int IndiceCount => FaceCount * 3;

        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        public void InsertPoint(Point2d point)
        {
            Kernel.InsertPoint(Ptr, point);
        }

        public void InsertPoints(Point2d[] points)
        {
            Kernel.InsertPoints(Ptr, points, 0, points.Length);
        }

        public void GetPoints(Point2d[] points)
        {
            ErrorUtil.CheckBounds(points, 0, VertexCount);
            Kernel.GetPoints(Ptr, points, 0, points.Length);
        }

        public void GetIndices(int[] indices)
        {
            int count = IndiceCount;
            if (count == 0) return;

            ErrorUtil.CheckBounds(indices, 0, count);
            Kernel.GetIndices(Ptr, indices, 0, indices.Length);
        }

        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        public void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
