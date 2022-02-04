using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class SurfaceSimplificationKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void Simplify_PH(IntPtr meshPtr, double stop_ratio);

        internal abstract void Simplify_SM(IntPtr meshPtr, double stop_ratio);
    }
}
