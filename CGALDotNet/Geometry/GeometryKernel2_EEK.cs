using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    internal class GeometryKernel2_EEK : GeometryKernel2
    {
        internal override string KernelName => "EEK";

        internal static readonly GeometryKernel2 Instance = new GeometryKernel2_EEK();

        //Point2
        internal override IntPtr Point2_Create()
        {
            return Point2_Create();
        }

        internal override IntPtr Point2_CreateFromPoint(Point2d point)
        {
            return Point2_EEK_CreateFromPoint(point);
        }

        internal override void Point2_Release(IntPtr ptr)
        {
            Point2_EEK_Release(ptr);
        }

        internal override double Point2_GetX(IntPtr ptr)
        {
            return Point2_EEK_GetX(ptr);
        }

        internal override double Point2_GetY(IntPtr ptr)
        {
            return Point2_EEK_GetY(ptr);
        }

        internal override Point2d Point2_GetPoint(IntPtr ptr)
        {
            return Point2_EEK_GetPoint(ptr);
        }

        internal override void Point2_SetX(IntPtr ptr, double x)
        {
            Point2_EEK_SetX(ptr, x);
        }

        internal override void Point2_SetY(IntPtr ptr, double y)
        {
            Point2_EEK_SetY(ptr, y);
        }

        internal override void Point2_SetPoint(IntPtr ptr, Point2d point)
        {
            Point2_EEK_SetPoint(ptr, point);
        }

        //Line2
        internal override IntPtr Line2_Create(double a, double b, double c)
        {
            return Line2_EEK_Create(a, b, c);
        }

        internal override void Line2_Release(IntPtr ptr)
        {
            Line2_EEK_Release(ptr);
        }

        internal override double Line2_GetA(IntPtr ptr)
        {
            return Line2_EEK_GetA(ptr);
        }

        internal override double Line2_GetB(IntPtr ptr)
        {
            return Line2_EEK_GetB(ptr);
        }

        internal override double Line2_GetC(IntPtr ptr)
        {
            return Line2_EEK_GetC(ptr);
        }

        internal override bool Line2_IsDegenerate(IntPtr ptr)
        {
            return Line2_EEK_IsDegenerate(ptr); 
        }

        internal override bool Line2_IsHorizontal(IntPtr ptr)
        {
            return Line2_EEK_IsHorizontal(ptr); 
        }

        internal override bool Line2_IsVertical(IntPtr ptr)
        {
            return Line2_EEK_IsVertical(ptr);
        }

        internal override bool Line2_HasOn(IntPtr linePtr, Point2d point)
        {
            return Line2_EEK_HasOn(linePtr, point);
        }

        internal override bool Line2_HasOnNegativeSide(IntPtr linePtr, Point2d point)
        {
            return Line2_EEK_HasOnNegativeSide(linePtr, point);
        }

        internal override bool Line2_HasOnPositiveSide(IntPtr linePtr, Point2d point)
        {
            return Line2_EEK_HasOnPositiveSide(linePtr, point);
        }

        internal override IntPtr Line2_Opposite(IntPtr ptr)
        {
            return Line2_EEK_Opposite(ptr); 
        }

        internal override IntPtr Line2_Perpendicular(IntPtr ptr, Point2d point)
        {
            return Line2_EEK_Perpendicular(ptr, point);
        }

        internal override double Line2_X_On_Y(IntPtr ptr, double y)
        {
            return Line2_EEK_X_On_Y(ptr, y);
        }

        internal override double Line2_Y_On_X(IntPtr ptr, double x)
        {
            return Line2_EEK_Y_On_X(ptr, x);
        }

        internal override Vector2d Line2_Vector(IntPtr ptr)
        {
            return Line2_EEK_Vector(ptr);
        }

        internal override IntPtr Line2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            return Line2_EEK_Transform(ptr, translation, rotation, scale);  
        }

        //Ray2
        internal override IntPtr Ray2_Create(Point2d position, Vector2d direction)
        {
            return Ray2_EEK_Create(position, direction);
        }

        internal override void Ray2_Release(IntPtr ptr)
        {
            Ray2_EEK_Release(ptr);
        }

        //Segment2
        internal override IntPtr Segment2_Create(Point2d a, Point2d b)
        {
            return Segment2_EEK_Create(a, b);
        }

        internal override void Segment2_Release(IntPtr ptr)
        {
            Segment2_EEK_Release(ptr);
        }

        //Triangle2
        internal override IntPtr Triangle2_Create(Point2d a, Point2d b, Point2d c)
        {
            return Triangle2_EEK_Create(a, b, c);
        }

        internal override void Triangle2_Release(IntPtr ptr)
        {
            Triangle2_EEK_Release(ptr);
        }

        //IsoRectangle2
        internal override IntPtr IsoRectangle2_Create(Point2d min, Point2d max)
        {
            return IsoRectangle2_EEK_Create(min, max);
        }

        internal override void IsoRectangle2_Release(IntPtr ptr)
        {
            IsoRectangle2_EEK_Release(ptr);
        }

        internal override Point2d IsoRectangle2_GetMin(IntPtr ptr)
        {
            return IsoRectangle2_EEK_GetMin(ptr);
        }

        internal override void IsoRectangle2_SetMin(IntPtr ptr, Point2d point)
        {
            IsoRectangle2_EEK_SetMin(ptr, point);
        }

        internal override Point2d IsoRectangle2_GetMax(IntPtr ptr)
        {
            return IsoRectangle2_EEK_GetMax(ptr);
        }

        internal override void IsoRectangle2_SetMax(IntPtr ptr, Point2d point)
        {
            IsoRectangle2_EEK_SetMax(ptr, point);
        }

        internal override double IsoRectangle2_Area(IntPtr ptr)
        {
            return IsoRectangle2_EEK_Area(ptr);
        }

        internal override BOUNDED_SIDE IsoRectangle2_BoundedSide(IntPtr ptr, Point2d point)
        {
            return IsoRectangle2_EEK_BoundedSide(ptr, point);
        }
        internal override bool IsoRectangle2_ContainsPoint(IntPtr ptr, Point2d point, bool inculdeBoundary)
        {
            return IsoRectangle2_EEK_ContainsPoint(ptr, point, inculdeBoundary);
        }

        internal override bool IsoRectangle2_IsDegenerate(IntPtr ptr)
        {
            return IsoRectangle2_EEK_IsDegenerate(ptr);
        }

        internal override IntPtr IsoRectangle2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            return IsoRectangle2_EEK_Transform(ptr, translation, rotation, scale);  
        }

        //Point2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Point2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Point2_EEK_CreateFromPoint(Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Point2_EEK_GetX(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Point2_EEK_GetY(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Point2_EEK_GetPoint(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EEK_SetX(IntPtr ptr, double x);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EEK_SetY(IntPtr ptr, double y);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EEK_SetPoint(IntPtr ptr, Point2d point);

        //Line2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EEK_Create(double a, double b, double c);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Line2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EEK_GetA(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EEK_GetB(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EEK_GetC(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EEK_IsDegenerate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EEK_IsHorizontal(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EEK_IsVertical(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EEK_HasOn(IntPtr linePtr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EEK_HasOnNegativeSide(IntPtr linePtr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EEK_HasOnPositiveSide(IntPtr linePtr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EEK_Opposite(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EEK_Perpendicular(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EEK_X_On_Y(IntPtr ptr, double y);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EEK_Y_On_X(IntPtr ptr, double x);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Vector2d Line2_EEK_Vector(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EEK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        //Ray2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Ray2_EEK_Create(Point2d position, Vector2d direction);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Ray2_EEK_Release(IntPtr ptr);

        //Segment2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Segment2_EEK_Create(Point2d a, Point2d b);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Segment2_EEK_Release(IntPtr ptr);

        //Triangle2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Triangle2_EEK_Create(Point2d a, Point2d b, Point2d c);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Triangle2_EEK_Release(IntPtr ptr);

        //IsoRectangle2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr IsoRectangle2_EEK_Create(Point2d min, Point2d max);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void IsoRectangle2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d IsoRectangle2_EEK_GetMin(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void IsoRectangle2_EEK_SetMin(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d IsoRectangle2_EEK_GetMax(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void IsoRectangle2_EEK_SetMax(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double IsoRectangle2_EEK_Area(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern BOUNDED_SIDE IsoRectangle2_EEK_BoundedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool IsoRectangle2_EEK_ContainsPoint(IntPtr ptr, Point2d point,  bool inculdeBoundary);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool IsoRectangle2_EEK_IsDegenerate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr IsoRectangle2_EEK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);
    }
}
