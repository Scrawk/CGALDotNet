using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Triangle2<K> : Triangle2 where K : CGALKernel, new()
    {

        public Triangle2(Point2d a, Point2d b, Point2d c) : base(a, b, c, new K())
        {

        }

        internal Triangle2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Triangle2<{0}>: ]",
                Kernel.KernelName);
        }
    }

    public abstract class Triangle2 : CGALObject
    {

        private Triangle2()
        {
       
        }

        internal Triangle2(Point2d a, Point2d b, Point2d c, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Triangle2_Create(a, b, c);
        }

        internal Triangle2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.Triangle2_Release(Ptr);
        }
    }
}
