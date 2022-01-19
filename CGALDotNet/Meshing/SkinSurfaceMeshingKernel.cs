using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Meshing
{
    internal abstract class SkinSurfaceMeshingKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr MakeSkinSurface(double shrinkfactor, bool subdivide, Point3d[] points, int count);

        internal abstract IntPtr MakeSkinSurface(double shrinkfactor, bool subdivide, HPoint3d[] points, int count);
    }
}