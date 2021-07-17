using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
	public enum ARRANGEMENT2_ELEMENT
	{
		VERTEX,
		EDGE,
		FACE,
		HALF_EDGE,
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

        public int ElementCount(ARRANGEMENT2_ELEMENT element)
        {
            return Kernel.ElementCount(Ptr, element);
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
            builder.AppendLine("Vertex Count = " + ElementCount(ARRANGEMENT2_ELEMENT.VERTEX));
            builder.AppendLine("Edge Count = " + ElementCount(ARRANGEMENT2_ELEMENT.EDGE));
            builder.AppendLine("Face Count = " + ElementCount(ARRANGEMENT2_ELEMENT.FACE));
            builder.AppendLine("Half Edge Count = " + ElementCount(ARRANGEMENT2_ELEMENT.HALF_EDGE));
            builder.AppendLine("Isolated Vertex Count = " + ElementCount(ARRANGEMENT2_ELEMENT.ISOLATED_VERTEX));
            builder.AppendLine("Vertex at Infinity Count = " + ElementCount(ARRANGEMENT2_ELEMENT.VERTEX_AT_INFINITY));
            builder.AppendLine("Unbounded Face Count = " + ElementCount(ARRANGEMENT2_ELEMENT.UNBOUNDED_FACE));
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
