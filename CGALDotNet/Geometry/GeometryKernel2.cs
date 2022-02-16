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

        internal abstract double Line2_GetA(IntPtr ptr);

        internal abstract double Line2_GetB(IntPtr ptr);

        internal abstract double Line2_GetC(IntPtr ptr);

        internal abstract bool Line2_IsDegenerate(IntPtr ptr);

        internal abstract bool Line2_IsHorizontal(IntPtr ptr);

        internal abstract bool Line2_IsVertical(IntPtr ptr);

        internal abstract bool Line2_HasOn(IntPtr linePtr, Point2d point);

        internal abstract bool Line2_HasOnNegativeSide(IntPtr linePtr, Point2d point);

        internal abstract bool Line2_HasOnPositiveSide(IntPtr linePtr, Point2d point);

        internal abstract IntPtr Line2_Opposite(IntPtr ptr);

        internal abstract IntPtr Line2_Perpendicular(IntPtr ptr, Point2d point);

        internal abstract double Line2_X_On_Y(IntPtr ptr, double y);

        internal abstract double Line2_Y_On_X(IntPtr ptr, double x);

        internal abstract Vector2d Line2_Vector(IntPtr ptr);

        internal abstract IntPtr Line2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

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

        internal abstract void IsoRectangle2_SetMin(IntPtr ptr, Point2d point);

        internal abstract Point2d IsoRectangle2_GetMax(IntPtr ptr);

        internal abstract void IsoRectangle2_SetMax(IntPtr ptr, Point2d point);

        internal abstract double IsoRectangle2_Area(IntPtr ptr);

        internal abstract BOUNDED_SIDE IsoRectangle2_BoundedSide(IntPtr ptr, Point2d point);

        internal abstract bool IsoRectangle2_ContainsPoint(IntPtr ptr, Point2d point, bool inculdeBoundary);

        internal abstract bool IsoRectangle2_IsDegenerate(IntPtr ptr);

        internal abstract IntPtr IsoRectangle2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

    }
}
