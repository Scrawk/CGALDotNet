using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Segment2<K> : Segment2 where K : CGALKernel, new()
    {

        public Segment2(Point2d a, Point2d b) : base(a, b, new K())
        {

        }

        internal Segment2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Segment2<{0}>: ]",
                Kernel.KernelName);
        }
    }

    public abstract class Segment2 : CGALObject
    {

        private Segment2()
        {

        }

        internal Segment2(Point2d a, Point2d b, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Segment2_Create(a, b);
        }

        internal Segment2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.Segment2_Release(Ptr);
        }
    }
}
