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

        public Point2(double v) : base(v, v, new K())
        {

        }

        public Point2(double x, double y) : base(x, y, new K())
        {

        }

        internal Point2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public double x
        {
            get { return Kernel.Point2_GetX(Ptr); }
            set { Kernel.Point2_SetX(Ptr, value); }
        }

        public double y
        {
            get { return Kernel.Point2_GetY(Ptr); }
            set { Kernel.Point2_SetY(Ptr, value); }
        }

        public override string ToString()
        {
            return string.Format("[Point2<{0}>: x={1}, y={2}]",
                Kernel.KernelName, x, y);
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

        protected override void ReleasePtr(IntPtr ptr)
        {
            Kernel.Point2_Release(ptr);
        }
    }
}
