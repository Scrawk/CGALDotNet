using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Line2<K> : Line2 where K : CGALKernel, new()
    {

        public Line2(double a, double b, double c) : base(a, b, c, new K())
        {

        }

        internal Line2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Line2<{0}>: ]",
                Kernel.KernelName);
        }
    }

    public abstract class Line2 : CGALObject
    {
        private Line2()
        {
      
        }

        internal Line2(double a, double b, double c, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Line2_Create(a, b, c);
        }

        internal Line2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        protected override void ReleasePtr()
        {
            Kernel.Line2_Release(Ptr);
        }
    }
}
