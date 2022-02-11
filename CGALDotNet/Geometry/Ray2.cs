using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Ray2<K> : Ray2 where K : CGALKernel, new()
    {

        public Ray2(Point2d position, Vector2d direction) 
            : base(position, direction, new K())
        {

        }

        internal Ray2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Ray2<{0}>: ]",
                Kernel.KernelName);
        }
    }

    public abstract class Ray2 : CGALObject
    {

        private Ray2()
        {

        }

        internal Ray2(Point2d position, Vector2d direction, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Ray2_Create(position, direction);
        }

        internal Ray2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.Ray2_Release(Ptr);
        }
    }
}
