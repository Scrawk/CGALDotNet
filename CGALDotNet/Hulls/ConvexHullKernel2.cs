using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Hulls
{
    internal abstract class ConvexHullKernel2
    {
        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr CreateHull(Point2d[] points, int count, HULL_METHOD method);

        internal abstract IntPtr UpperHull(Point2d[] points, int count);

        internal abstract IntPtr LowerHull(Point2d[] points, int count);

        internal abstract bool IsStronglyConvexCCW(Point2d[] points, int count);

        internal abstract bool IsStronglyConvexCW(Point2d[] points, int count);
    }
}
