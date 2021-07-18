using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
	public enum ARRANGEMENT2_ELEMENT
	{
		VERTEX,
		FACE,
		HALF_EDGE
	};

    public enum ARRANGEMENT2_ELEMENT_EXT
    {
        EDGE,
        ISOLATED_VERTEX,
        VERTEX_AT_INFINITY,
        UNBOUNDED_FACE
    };

    public sealed class Arrangement2<K> : Arrangement2 where K : CGALKernel, new()
    {
        public Arrangement2() : base(new K())
        {

        }

        public Arrangement2(Segment2d[] points) : base(new K(), points)
        {

        }

        internal Arrangement2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Arrangement2<{0}>: ]",
                Kernel.Name);
        }

    }

    public abstract class Arrangement2 : CGALObject
    {
        private Arrangement2()
        {

        }

        internal Arrangement2(CGALKernel kernel)
        {
            Kernel = kernel.ArrangementKernel2;
            Ptr = Kernel.Create();
        }

        internal Arrangement2(CGALKernel kernel, Segment2d[] segments)
        {
            Kernel = kernel.ArrangementKernel2;
            Ptr = Kernel.CreateFromSegments(segments, 0, segments.Length);
        }

        internal Arrangement2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.ArrangementKernel2;
        }

        protected private ArrangementKernel2 Kernel { get; private set; }

        public int VertexCount => Kernel.VertexCount(Ptr);

        public int IsolatedVerticesCount => Kernel.IsolatedVerticesCount(Ptr);

        public int VerticesAtInfinityCount => Kernel.VerticesAtInfinityCount(Ptr);

        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        public int EdgeCount => Kernel.EdgeCount(Ptr);

        public int FaceCount => Kernel.FaceCount(Ptr);

        public int UnboundedFaceCount => Kernel.UnboundedFaceCount(Ptr);

        public void SetIndices()
        {
            SetVertexIndices();
            SetHalfEdgeIndices();
            SetFaceIndices();
        }

        public void SetVertexIndices()
        {
            Kernel.SetVertexIndices(Ptr);
        }

        public void SetHalfEdgeIndices()
        {
            Kernel.SetHalfEdgeIndices(Ptr);
        }
        public void SetFaceIndices()
        {
            Kernel.SetFaceIndices(Ptr);
        }

        public void GetPoints(Point2d[] points)
        {
            ErrorUtil.CheckBounds(points, 0, VertexCount);
            Kernel.GetPoints(Ptr, points, 0, points.Length);
        }

        public void GetSegments(Segment2d[] segments)
        {
            ErrorUtil.CheckBounds(segments, 0, EdgeCount);
            Kernel.GetSegments(Ptr, segments, 0, segments.Length);
        }

        public void GetVertices(ArrVertex2[] vertices)
        {
            ErrorUtil.CheckBounds(vertices, 0, VertexCount);
            Kernel.GetVertices(Ptr, vertices, 0, vertices.Length);
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
            builder.AppendLine("Vertex Count = " + VertexCount);
            builder.AppendLine("Isolated Vertex Count = " + IsolatedVerticesCount);
            builder.AppendLine("Vertex at Infinity Count = " + VerticesAtInfinityCount);
            builder.AppendLine("Half Edge Count = " + HalfEdgeCount);
            builder.AppendLine("Edge Count = " + EdgeCount);
            builder.AppendLine("Face Count = " + FaceCount);
            builder.AppendLine("Unbounded Face Count = " + UnboundedFaceCount);

            var points = new Point2d[VertexCount];
            GetPoints(points);

            foreach(var p in points)
                builder.AppendLine(p.ToString());

            var segments = new Segment2d[EdgeCount];
            GetSegments(segments);

            foreach (var s in segments)
                builder.AppendLine(s.ToString());

            SetIndices();

            var vertices = new ArrVertex2[VertexCount];
            GetVertices(vertices);

            foreach (var v in vertices)
            {
                builder.AppendLine(v.ToString());

                builder.AppendLine("Index = " + v.Index);
                builder.AppendLine("Face Index = " + v.FaceIndex);
                builder.AppendLine("HalfEdge Index = " + v.HalfEdgeIndex);
            }
                

        }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
