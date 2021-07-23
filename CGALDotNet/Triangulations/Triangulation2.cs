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
            int count = VertexCount;
            if (count == 0) return;

            ErrorUtil.CheckBounds(points, 0, count);
            Kernel.GetPoints(Ptr, points, 0, points.Length);
        }

        public void GetIndices(int[] indices)
        {
            int count = IndiceCount;
            if (count == 0) return;

            ErrorUtil.CheckBounds(indices, 0, count);
            Kernel.GetIndices(Ptr, indices, 0, indices.Length);
        }

        public bool GetVertex(int index, out TriVertex2 vertex)
        {
            return Kernel.GetVertex(Ptr, index, out vertex);
        }

        public void GetVertices(TriVertex2[] vertices)
        {
            int count = VertexCount;
            if (count == 0) return;

            ErrorUtil.CheckBounds(vertices, 0, count);
            Kernel.GetVertices(Ptr, vertices, 0, vertices.Length);
        }

        public bool GetFace(int index, out TriFace2 face)
        {
            return Kernel.GetFace(Ptr, index, out face);
        }

        public void GetFaces(TriFace2[] faces)
        {
            int count = FaceCount;
            if (count == 0) return;

            ErrorUtil.CheckBounds(faces, 0, count);
            Kernel.GetFaces(Ptr, faces, 0, faces.Length);
        }

        public bool GetSegment(int faceIndex, int neighbourIndex, out Segment2d segment)
        {
            return Kernel.GetSegment(Ptr, faceIndex, neighbourIndex, out segment);
        }

        public bool GetTriangle(int faceIndex, out Triangle2d triangle)
        {
            return Kernel.GetTriangle(Ptr, faceIndex, out triangle);
        }

        public bool GetCircumcenter(int faceIndex, out Point2d circumcenter)
        {
            return Kernel.GetCircumcenter(Ptr, faceIndex, out circumcenter);
        }

        public void GetCircumcenters(Point2d[] circumcenters)
        {
            int count = FaceCount;
            if (count == 0) return;

            ErrorUtil.CheckBounds(circumcenters, 0, count);
            Kernel.GetCircumcenters(Ptr, circumcenters, 0, circumcenters.Length);
        }

        public bool LocateFace(Point2d point, out TriFace2 face)
        {
            return Kernel.LocateFace(Ptr, point, out face);
        }

        public bool MoveVertex(int index, Point2d point, bool ifNoCollision, out TriVertex2 vertex)
        {
            return Kernel.MoveVertex(Ptr, index, point, ifNoCollision, out vertex);
        }

        public bool RemoveVertex(int index)
        {
            return Kernel.RemoveVertex(Ptr, index);
        }

        public bool FlipEdge(int faceIndex, int neighbourIndex)
        {
            return Kernel.FlipEdge(Ptr, faceIndex, neighbourIndex);
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
