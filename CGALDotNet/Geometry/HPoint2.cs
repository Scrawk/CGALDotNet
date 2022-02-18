using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class HPoint2<K> : HPoint2 where K : CGALKernel, new()
    {

        public HPoint2() : base(new K())
        {

        }

        public HPoint2(double v) : base(v, v, 1, new K())
        {

        }

        public HPoint2(double x, double y) : base(x, y, 1, new K())
        {

        }

        public HPoint2(double x, double y, double w) : base(x, y, w, new K())
        {

        }

        internal HPoint2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public double x
        {
            get { return Kernel.HPoint2_GetX(Ptr); }
            set { Kernel.HPoint2_SetX(Ptr, value); }
        }

        public double y
        {
            get { return Kernel.HPoint2_GetY(Ptr); }
            set { Kernel.HPoint2_SetY(Ptr, value); }
        }

        public double w
        {
            get { return Kernel.HPoint2_GetW(Ptr); }
            set { Kernel.HPoint2_SetW(Ptr, value); }
        }

        public override string ToString()
        {
            return string.Format("[HPoint2<{0}>: x={1}, y={2}, w={3}]",
                Kernel.KernelName, x, y, w);
        }
    }

    public abstract class HPoint2 : CGALObject
    {

        internal HPoint2(CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.HPoint2_Create();
        }

        internal HPoint2(double x, double y, double w, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.HPoint2_CreateFromPoint(new HPoint2d(x, y, w));
        }

        internal HPoint2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.HPoint2_Release(Ptr);
        }

        protected override void ReleasePtr(IntPtr ptr)
        {
            Kernel.HPoint2_Release(ptr);
        }
    }
}
