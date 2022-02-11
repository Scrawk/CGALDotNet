using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
 
    public sealed class Point2<K> : Point2 where K : CGALKernel, new()
    {

        public Point2() : base(new K())
        {

        }

        public Point2(double x, double y) : base(x, y, new K())
        {

        }

        internal Point2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Point2<{0}>: ]",
                Kernel.KernelName);
        }
    }

    public abstract class Point2 : CGALObject
    {

        internal Point2(CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Point2_Create();
        }

        internal Point2(double x, double y, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Point2_CreateFromPoint(new Point2d(x,y));
        }

        internal Point2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.Point2_Release(Ptr);
        }
    }
}
