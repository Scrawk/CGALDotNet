using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Meshing
{
    internal abstract class SkinSurfaceMeshingKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr MakeSkinSurface(double shrinkfactor, bool subdivide, Point3d[] points, int count);

        internal abstract IntPtr MakeSkinSurface(double shrinkfactor, bool subdivide, HPoint3d[] points, int count);
    }
}