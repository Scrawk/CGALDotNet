using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Meshing
{
    internal abstract class SkinSurfaceMeshingKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr MakeSkinSurface(double shrinkfactor, BOOL subdivide, HPoint3d* points, int count);
    }
}