using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonVisibilityKernel2
    {

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr ComputeVisibility(Point2d point, Segment2d[] segments, int startIndex, int count);

    }
}
