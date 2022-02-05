using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNet.Polygons;

namespace CGALDotNet.Hulls
{
    internal abstract class ConvexHullKernel2 : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr CreateHull(Point2d[] points, int count, HULL_METHOD method);

        internal abstract IntPtr UpperHull(Point2d[] points, int count);

        internal abstract IntPtr LowerHull(Point2d[] points, int count);

        internal abstract bool IsStronglyConvexCCW(Point2d[] points, int count);

        internal abstract bool IsStronglyConvexCW(Point2d[] points, int count);
    }
}
