using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Vector2<K> : Vector2 where K : CGALKernel, new()
    {

        public Vector2() : base(new K())
        {

        }

        public Vector2(double v) : base(v, v, new K())
        {

        }

        public Vector2(double x, double y) : base(x, y, new K())
        {

        }

        internal Vector2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public double x
        {
            get { return Kernel.Vector2_GetX(Ptr); }
            set { Kernel.Vector2_SetX(Ptr, value); }
        }

        public double y
        {
            get { return Kernel.Vector2_GetY(Ptr); }
            set { Kernel.Vector2_SetY(Ptr, value); }
        }

        public override string ToString()
        {
            return string.Format("[Vector2<{0}>: x={1}, y={2}]",
                Kernel.KernelName, x, y);
        }
    }

    public abstract class Vector2 : CGALObject
    {

        internal Vector2(CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Vector2_Create();
        }

        internal Vector2(double x, double y, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Vector2_CreateFromVector(new Vector2d(x, y));
        }

        internal Vector2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.Vector2_Release(Ptr);
        }

        protected override void ReleasePtr(IntPtr ptr)
        {
            Kernel.Vector2_Release(ptr);
        }
    }
}
