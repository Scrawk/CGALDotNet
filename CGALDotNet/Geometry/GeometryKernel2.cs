using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Geometry
{
    internal abstract class GeometryKernel2 : CGALObjectKernel
    {

        //Point2
        internal abstract IntPtr Point2_Create();

        internal abstract IntPtr Point2_CreateFromPoint(Point2d point);

	    internal abstract void Point2_Release(IntPtr ptr);

        internal abstract double Point2_GetX(IntPtr ptr);

        internal abstract double Point2_GetY(IntPtr ptr);

        internal abstract Point2d Point2_GetPoint(IntPtr ptr);

        internal abstract void Point2_SetX(IntPtr ptr, double x);

        internal abstract void Point2_SetY(IntPtr ptr, double y);

        internal abstract void Point2_SetPoint(IntPtr ptr, Point2d point);

        //Line2
        internal abstract IntPtr Line2_Create(double a, double b, double c);

        internal abstract void Line2_Release(IntPtr ptr);

        //Ray2
        internal abstract IntPtr Ray2_Create(Point2d position, Vector2d direction);

        internal abstract void Ray2_Release(IntPtr ptr);

        //Segment2
        internal abstract IntPtr Segment2_Create(Point2d a, Point2d b);

        internal abstract void Segment2_Release(IntPtr ptr);

        //Triangle2
        internal abstract IntPtr Triangle2_Create(Point2d a, Point2d b, Point2d c);

        internal abstract void Triangle2_Release(IntPtr ptr);

        //IsoRectangle2
        internal abstract IntPtr IsoRectangle2_Create(Point2d min, Point2d max);

        internal abstract void IsoRectangle2_Release(IntPtr ptr);

        internal abstract Point2d IsoRectangle2_GetMin(IntPtr ptr);

        internal abstract Point2d IsoRectangle2_GetMax(IntPtr ptr);

        internal abstract double IsoRectangle2_Area(IntPtr ptr);

        internal abstract BOUNDED_SIDE IsoRectangle2_BoundedSide(IntPtr ptr, Point2d point);

        internal abstract bool IsoRectangle2_ContainsPoint(IntPtr ptr, Point2d point, bool inculdeBoundary);

    }
}
