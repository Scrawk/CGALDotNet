using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonVisibilityKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr ComputeVisibilitySimple(Point2d point, IntPtr polyPtr);

        internal abstract IntPtr ComputeVisibilityTEV(Point2d point, IntPtr pwhPtr);

        internal abstract IntPtr ComputeVisibilityRSV(Point2d point, IntPtr pwhPtr);
    }
}
