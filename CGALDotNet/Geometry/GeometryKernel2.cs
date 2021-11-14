using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Geometry
{
    internal abstract class GeometryKernel2 : FuncKernel
    {
        internal abstract IntPtr IsoRectangle_Create(Point2d min, Point2d max);

        internal abstract void IsoRectangle_Release(IntPtr ptr);

        internal abstract Point2d IsoRectangle_GetMin(IntPtr ptr);

        internal abstract Point2d IsoRectangle_GetMax(IntPtr ptr);

        internal abstract double IsoRectangle_Area(IntPtr ptr);

        internal abstract BOUNDED_SIDE IsoRectangle_BoundedSide(IntPtr ptr, Point2d point);

        internal abstract bool IsoRectangle_ContainsPoint(IntPtr ptr, Point2d point, bool inculdeBoundary);

    }
}
