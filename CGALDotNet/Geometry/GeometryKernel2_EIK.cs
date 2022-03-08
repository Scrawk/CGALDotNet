using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    internal class GeometryKernel2_EIK : GeometryKernel2
    {
        internal override string Name => "EIK";

        internal static readonly GeometryKernel2 Instance = new GeometryKernel2_EIK();

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point2 Class Functions
        /// 
        /// </summary>-------------------------------------------------------

        internal override IntPtr Point2_Create()
        {
            return Point2_Create();
        }

        internal override IntPtr Point2_CreateFromPoint(Point2d point)
        {
            return Point2_EIK_CreateFromPoint(point);
        }

        internal override void Point2_Release(IntPtr ptr)
        {
            Point2_EIK_Release(ptr);
        }

        internal override double Point2_GetX(IntPtr ptr)
        {
            return Point2_EIK_GetX(ptr);
        }

        internal override double Point2_GetY(IntPtr ptr)
        {
            return Point2_EIK_GetY(ptr);
        }

        internal override void Point2_SetX(IntPtr ptr, double x)
        {
            Point2_EIK_SetX(ptr, x);
        }

        internal override void Point2_SetY(IntPtr ptr, double y)
        {
            Point2_EIK_SetY(ptr, y);
        }

        internal override IntPtr Point2_Copy(IntPtr ptr)
        {
            return Point2_EIK_Copy(ptr);
        }

        internal override IntPtr Point2_Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Point2_EIK_Convert(ptr, k);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Vector2 Class Functions
        /// 
        /// </summary>-------------------------------------------------------

        internal override IntPtr Vector2_Create()
        {
            return Vector2_EIK_Create();
        }

        internal override IntPtr Vector2_CreateFromVector(Vector2d vector)
        {
            return Vector2_EIK_CreateFromVector(vector);
        }

        internal override void Vector2_Release(IntPtr ptr)
        {
            Vector2_EIK_Release(ptr);
        }

        internal override double Vector2_GetX(IntPtr ptr)
        {
            return Vector2_EIK_GetX(ptr);
        }

        internal override double Vector2_GetY(IntPtr ptr)
        {
            return Vector2_EIK_GetY(ptr);
        }

        internal override void Vector2_SetX(IntPtr ptr, double x)
        {
            Vector2_EIK_SetX(ptr, x);
        }

        internal override void Vector2_SetY(IntPtr ptr, double y)
        {
            Vector2_EIK_SetY(ptr, y);
        }

        internal override double Vector2_SqrLength(IntPtr ptr)
        {
            return Vector2_EIK_SqrLength(ptr);
        }

        internal override IntPtr Vector2_Perpendicular(IntPtr ptr, ORIENTATION orientation)
        {
            return Vector2_EIK_Perpendicular(ptr, orientation);
        }

        internal override void Vector2_Normalize(IntPtr ptr)
        {
            Vector2_EIK_Normalize(ptr);
        }

        internal override double Vector2_Magnitude(IntPtr ptr)
        {
            return Vector2_EIK_Magnitude(ptr);
        }

        internal override IntPtr Vector2_Copy(IntPtr ptr)
        {
            return Vector2_EIK_Copy(ptr);
        }

        internal override IntPtr Vector2_Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Vector2_EIK_Convert(ptr, k);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The HPoint2 Class Functions
        /// 
        /// </summary>-------------------------------------------------------

        internal override IntPtr HPoint2_Create()
        {
            return HPoint2_Create();
        }

        internal override IntPtr HPoint2_CreateFromPoint(HPoint2d point)
        {
            return HPoint2_EIK_CreateFromPoint(point);
        }

        internal override void HPoint2_Release(IntPtr ptr)
        {
            HPoint2_EIK_Release(ptr);
        }

        internal override double HPoint2_GetX(IntPtr ptr)
        {
            return HPoint2_EIK_GetX(ptr);
        }

        internal override double HPoint2_GetY(IntPtr ptr)
        {
            return HPoint2_EIK_GetY(ptr);
        }

        internal override double HPoint2_GetW(IntPtr ptr)
        {
            return HPoint2_EIK_GetW(ptr);
        }

        internal override void HPoint2_SetX(IntPtr ptr, double x)
        {
            HPoint2_EIK_SetX(ptr, x);
        }

        internal override void HPoint2_SetY(IntPtr ptr, double y)
        {
            HPoint2_EIK_SetY(ptr, y);
        }

        internal override void HPoint2_SetW(IntPtr ptr, double w)
        {
            HPoint2_EIK_SetW(ptr, w);
        }

        internal override IntPtr HPoint2_Copy(IntPtr ptr)
        {
            return HPoint2_EIK_Copy(ptr);
        }

        internal override IntPtr HPoint2_Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return HPoint2_EIK_Convert(ptr, k);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line2 Class Functions
        /// 
        /// </summary>-------------------------------------------------------

        internal override IntPtr Line2_Create(double a, double b, double c)
        {
            return Line2_EIK_Create(a, b, c);
        }

        internal override IntPtr CreateFromPoints(Point2d p1, Point2d p2)
        {
            return Line2_EIK_CreateFromPoints(p1, p2);
        }

        internal override IntPtr CreateFromPointVector(Point2d p, Vector2d v)
        {
            return Line2_EIK_CreateFromPointVector(p, v);
        }

        internal override void Line2_Release(IntPtr ptr)
        {
            Line2_EIK_Release(ptr);
        }

        internal override double Line2_GetA(IntPtr ptr)
        {
            return Line2_EIK_GetA(ptr);
        }

        internal override double Line2_GetB(IntPtr ptr)
        {
            return Line2_EIK_GetB(ptr);
        }

        internal override double Line2_GetC(IntPtr ptr)
        {
            return Line2_EIK_GetC(ptr);
        }

        internal override void Line2_SetA(IntPtr ptr, double a)
        {
            Line2_EIK_SetA(ptr, a);
        }

        internal override void Line2_SetB(IntPtr ptr, double b)
        {
            Line2_EIK_SetB(ptr, b);
        }

        internal override void Line2_SetC(IntPtr ptr, double c)
        {
            Line2_EIK_SetC(ptr, c);
        }

        internal override bool Line2_IsDegenerate(IntPtr ptr)
        {
            return Line2_EIK_IsDegenerate(ptr);
        }

        internal override bool Line2_IsHorizontal(IntPtr ptr)
        {
            return Line2_EIK_IsHorizontal(ptr);
        }

        internal override bool Line2_IsVertical(IntPtr ptr)
        {
            return Line2_EIK_IsVertical(ptr);
        }

        internal override bool Line2_HasOn(IntPtr linePtr, Point2d point)
        {
            return Line2_EIK_HasOn(linePtr, point);
        }

        internal override bool Line2_HasOnNegativeSide(IntPtr linePtr, Point2d point)
        {
            return Line2_EIK_HasOnNegativeSide(linePtr, point);
        }

        internal override bool Line2_HasOnPositiveSide(IntPtr linePtr, Point2d point)
        {
            return Line2_EIK_HasOnPositiveSide(linePtr, point);
        }

        internal override IntPtr Line2_Opposite(IntPtr ptr)
        {
            return Line2_EIK_Opposite(ptr);
        }

        internal override IntPtr Line2_Perpendicular(IntPtr ptr, Point2d point)
        {
            return Line2_EIK_Perpendicular(ptr, point);
        }

        internal override double Line2_X_On_Y(IntPtr ptr, double y)
        {
            return Line2_EIK_X_On_Y(ptr, y);
        }

        internal override double Line2_Y_On_X(IntPtr ptr, double x)
        {
            return Line2_EIK_Y_On_X(ptr, x);
        }

        internal override Vector2d Line2_Vector(IntPtr ptr)
        {
            return Line2_EIK_Vector(ptr);
        }

        internal override void Line2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Line2_EIK_Transform(ptr, translation, rotation, scale);
        }

        internal override IntPtr Line2_Copy(IntPtr ptr)
        {
            return Line2_EIK_Copy(ptr);
        }

        internal override IntPtr Line2_Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Line2_EIK_Convert(ptr, k);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray2 Class Functions
        /// 
        /// </summary>-------------------------------------------------------

        internal override IntPtr Ray2_Create(Point2d position, Vector2d direction)
        {
            return Ray2_EIK_Create(position, direction);
        }

        internal override void Ray2_Release(IntPtr ptr)
        {
            Ray2_EIK_Release(ptr);
        }

        internal override bool Ray2_IsDegenerate(IntPtr ptr)
        {
            return Box2_EIK_IsDegenerate(ptr);
        }

        internal override bool Ray2_IsHorizontal(IntPtr ptr)
        {
            return Ray2_EIK_IsHorizontal(ptr);
        }

        internal override bool Ray2_IsVertical(IntPtr ptr)
        {
            return Ray2_EIK_IsVertical(ptr);
        }

        internal override bool Ray2_HasOn(IntPtr rayPtr, Point2d point)
        {
            return Ray2_EIK_HasOn(rayPtr, point);
        }

        internal override Point2d Ray2_Source(IntPtr ptr)
        {
            return Ray2_EIK_Source(ptr);
        }

        internal override Vector2d Ray2_Vector(IntPtr ptr)
        {
            return Ray2_EIK_Vector(ptr);
        }

        internal override IntPtr Ray2_Opposite(IntPtr ptr)
        {
            return Ray2_EIK_Opposite(ptr);
        }

        internal override IntPtr Ray2_Line(IntPtr ptr)
        {
            return Ray2_EIK_Line(ptr);
        }

        internal override void Ray2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Ray2_EIK_Transform(ptr, translation, rotation, scale);
        }

        internal override IntPtr Ray2_Copy(IntPtr ptr)
        {
            return Ray2_EIK_Copy(ptr);
        }

        internal override IntPtr Ray2_Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Ray2_EIK_Convert(ptr, k);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment Class Functions
        /// 
        /// </summary>-------------------------------------------------------

        internal override IntPtr Segment2_Create(Point2d a, Point2d b)
        {
            return Segment2_EIK_Create(a, b);
        }

        internal override void Segment2_Release(IntPtr ptr)
        {
            Segment2_EIK_Release(ptr);
        }

        internal override Point2d Segment2_GetVertex(IntPtr ptr, int i)
        {
            return Segment2_EIK_GetVertex(ptr, i);
        }

        internal override void Segment2_SetVertex(IntPtr ptr, int i, Point2d point)
        {
            Segment2_EIK_SetVertex(ptr, i, point);
        }

        internal override Point2d Segment2_Min(IntPtr ptr)
        {
            return Segment2_EIK_Min(ptr);
        }

        internal override Point2d Segment2_Max(IntPtr ptr)
        {
            return Segment2_EIK_Max(ptr);
        }

        internal override bool Segment2_IsDegenerate(IntPtr ptr)
        {
            return Segment2_EIK_IsDegenerate(ptr);
        }

        internal override bool Segment2_IsHorizontal(IntPtr ptr)
        {
            return Segment2_EIK_IsHorizontal(ptr);
        }

        internal override bool Segment2_IsVertical(IntPtr ptr)
        {
            return Segment2_EIK_IsVertical(ptr);
        }

        internal override bool Segment2_HasOn(IntPtr segPtr, Point2d point)
        {
            return Segment2_EIK_HasOn(segPtr, point);
        }

        internal override Vector2d Segment2_Vector(IntPtr ptr)
        {
            return Segment2_EIK_Vector(ptr);
        }

        internal override IntPtr Segment2_Line(IntPtr ptr)
        {
            return Segment2_EIK_Line(ptr);
        }

        internal override double Segment2_SqrLength(IntPtr ptr)
        {
            return Segment2_EIK_SqrLength(ptr);
        }

        internal override void Segment2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Segment2_EIK_Transform(ptr, translation, rotation, scale);
        }

        internal override IntPtr Segment2_Copy(IntPtr ptr)
        {
            return Segment2_EIK_Copy(ptr);
        }

        internal override IntPtr Segment2_Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Segment2_EIK_Convert(ptr, k);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle2 Class Functions
        /// 
        /// </summary>-------------------------------------------------------

        internal override IntPtr Triangle2_Create(Point2d a, Point2d b, Point2d c)
        {
            return Triangle2_EIK_Create(a, b, c);
        }

        internal override void Triangle2_Release(IntPtr ptr)
        {
            Triangle2_EIK_Release(ptr);
        }

        internal override Point2d Triangle2_GetVertex(IntPtr ptr, int i)
        {
            return Triangle2_EIK_GetVertex(ptr, i);
        }

        internal override void Triangle2_SetVertex(IntPtr ptr, int i, Point2d point)
        {
            Segment2_EIK_SetVertex(ptr, i, point);
        }

        internal override double Triangle2_Area(IntPtr ptr)
        {
            return Triangle2_EIK_Area(ptr);
        }

        internal override BOUNDED_SIDE Triangle2_BoundedSide(IntPtr ptr, Point2d point)
        {
            return Triangle2_EIK_BoundedSide(ptr, point);
        }

        internal override ORIENTED_SIDE Triangle2_OrientedSide(IntPtr ptr, Point2d point)
        {
            return Triangle2_EIK_OrientedSide(ptr, point);
        }

        internal override ORIENTATION Triangle2_Orientation(IntPtr ptr)
        {
            return Triangle2_EIK_Orientation(ptr);
        }

        internal override bool Triangle2_IsDegenerate(IntPtr ptr)
        {
            return Triangle2_EIK_IsDegenerate(ptr);
        }

        internal override void Triangle2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Triangle2_EIK_Transform(ptr, translation, rotation, scale);
        }

        internal override IntPtr Triangle2_Copy(IntPtr ptr)
        {
            return Triangle2_EIK_Copy(ptr);
        }

        internal override IntPtr Triangle2_Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Triangle2_EIK_Convert(ptr, k);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The IsoRectancle2 Class Functions
        /// 
        /// </summary>-------------------------------------------------------

        internal override IntPtr Box2_Create(Point2d min, Point2d max)
        {
            return Box2_EIK_Create(min, max);
        }

        internal override void Box2_Release(IntPtr ptr)
        {
            Box2_EIK_Release(ptr);
        }

        internal override Point2d Box2_GetMin(IntPtr ptr)
        {
            return Box2_EIK_GetMin(ptr);
        }

        internal override void Box2_SetMin(IntPtr ptr, Point2d point)
        {
            Box2_EIK_SetMin(ptr, point);
        }

        internal override Point2d Box2_GetMax(IntPtr ptr)
        {
            return Box2_EIK_GetMax(ptr);
        }

        internal override void Box2_SetMax(IntPtr ptr, Point2d point)
        {
            Box2_EIK_SetMax(ptr, point);
        }

        internal override double Box2_Area(IntPtr ptr)
        {
            return Box2_EIK_Area(ptr);
        }

        internal override BOUNDED_SIDE Box2_BoundedSide(IntPtr ptr, Point2d point)
        {
            return Box2_EIK_BoundedSide(ptr, point);
        }
        internal override bool Box2_ContainsPoint(IntPtr ptr, Point2d point, bool inculdeBoundary)
        {
            return Box2_EIK_ContainsPoint(ptr, point, inculdeBoundary);
        }

        internal override bool Box2_IsDegenerate(IntPtr ptr)
        {
            return Box2_EIK_IsDegenerate(ptr);
        }

        internal override void Box2_Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Box2_EIK_Transform(ptr, translation, rotation, scale);
        }

        internal override IntPtr Box2_Copy(IntPtr ptr)
        {
            return Box2_EIK_Copy(ptr);
        }

        internal override IntPtr Box2_Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Box2_EIK_Convert(ptr, k);
        }

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Point2 extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Point2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Point2_EIK_CreateFromPoint(Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Point2_EIK_GetX(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Point2_EIK_GetY(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EIK_SetX(IntPtr ptr, double x);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EIK_SetY(IntPtr ptr, double y);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Point2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Point2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Vector2 extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Vector2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Vector2_EIK_CreateFromVector(Vector2d vector);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Vector2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Vector2_EIK_GetX(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Vector2_EIK_GetY(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Vector2_EIK_SetX(IntPtr ptr, double x);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Vector2_EIK_SetY(IntPtr ptr, double y);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Vector2_EIK_SqrLength(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Vector2_EIK_Perpendicular(IntPtr ptr, ORIENTATION orientation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Vector2_EIK_Normalize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Vector2_EIK_Magnitude(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Vector2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Vector2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The HPoint2 extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr HPoint2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr HPoint2_EIK_CreateFromPoint(HPoint2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void HPoint2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double HPoint2_EIK_GetX(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double HPoint2_EIK_GetY(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double HPoint2_EIK_GetW(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void HPoint2_EIK_SetX(IntPtr ptr, double x);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void HPoint2_EIK_SetY(IntPtr ptr, double y);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void HPoint2_EIK_SetW(IntPtr ptr, double y);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr HPoint2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr HPoint2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Line2 extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EIK_Create(double a, double b, double c);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EIK_CreateFromPoints(Point2d p1, Point2d p2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EIK_CreateFromPointVector(Point2d p, Vector2d v);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Line2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EIK_GetA(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EIK_GetB(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EIK_GetC(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Line2_EIK_SetA(IntPtr ptr, double a);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Line2_EIK_SetB(IntPtr ptr, double b);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Line2_EIK_SetC(IntPtr ptr, double c);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EIK_IsDegenerate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EIK_IsHorizontal(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EIK_IsVertical(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EIK_HasOn(IntPtr linePtr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EIK_HasOnNegativeSide(IntPtr linePtr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Line2_EIK_HasOnPositiveSide(IntPtr linePtr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EIK_Opposite(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EIK_Perpendicular(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EIK_X_On_Y(IntPtr ptr, double y);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Line2_EIK_Y_On_X(IntPtr ptr, double x);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Vector2d Line2_EIK_Vector(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Line2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Ray2 extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Ray2_EIK_Create(Point2d position, Vector2d direction);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Ray2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Ray2_EIK_IsDegenerate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Ray2_EIK_IsHorizontal(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Ray2_EIK_IsVertical(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Ray2_EIK_HasOn(IntPtr rayPtr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Ray2_EIK_Source(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Vector2d Ray2_EIK_Vector(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Ray2_EIK_Opposite(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Ray2_EIK_Line(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Ray2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Ray2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Ray2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Segment2 extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Segment2_EIK_Create(Point2d a, Point2d b);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Segment2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Segment2_EIK_GetVertex(IntPtr ptr, int i);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Segment2_EIK_SetVertex(IntPtr ptr, int i, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Segment2_EIK_Min(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Segment2_EIK_Max(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Segment2_EIK_IsDegenerate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Segment2_EIK_IsHorizontal(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Segment2_EIK_IsVertical(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Segment2_EIK_HasOn(IntPtr segPtr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Vector2d Segment2_EIK_Vector(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Segment2_EIK_Line(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Segment2_EIK_SqrLength(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Segment2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Segment2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Segment2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Triangle2 extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Triangle2_EIK_Create(Point2d a, Point2d b, Point2d c);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Triangle2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Triangle2_EIK_GetVertex(IntPtr ptr, int i);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Triangle2_EIK_SetVertex(IntPtr ptr, int i, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Triangle2_EIK_Area(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern BOUNDED_SIDE Triangle2_EIK_BoundedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTED_SIDE Triangle2_EIK_OrientedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION Triangle2_EIK_Orientation(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Triangle2_EIK_IsDegenerate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Triangle2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Triangle2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Triangle2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        /// <summary>--------------------------------------------------------
        /// 
        ///                 The Box2 extern functions
        /// 
        /// </summary>-------------------------------------------------------

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Box2_EIK_Create(Point2d min, Point2d max);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Box2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Box2_EIK_GetMin(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Box2_EIK_SetMin(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Box2_EIK_GetMax(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Box2_EIK_SetMax(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Box2_EIK_Area(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern BOUNDED_SIDE Box2_EIK_BoundedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Box2_EIK_ContainsPoint(IntPtr ptr, Point2d point, bool inculdeBoundary);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Box2_EIK_IsDegenerate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Box2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Box2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Box2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);
    }
}
