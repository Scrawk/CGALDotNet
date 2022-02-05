using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Hulls
{
    internal abstract class ConvexHullKernel3 : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr CreateHullAsPolyhedronFromPoints(Point3d[] points, int count);

        internal abstract IntPtr CreateHullAsSurfaceMeshFromPoints(Point3d[] points, int count);

        internal abstract IntPtr CreateHullAsPolyhedronFromPlanes(Plane3d[] planes, int count);

        internal abstract IntPtr CreateHullAsSurfaceMeshFromPlanes(Plane3d[] planes, int count);

        internal abstract bool IsPolyhedronStronglyConvex(IntPtr ptr);

        internal abstract bool IsSurfaceMeshStronglyConvex(IntPtr ptr);


    }
}
