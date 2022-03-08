using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{

    internal class PolygonKernel2_EIK : PolygonKernel2
    {

        internal override string Name => "EIK";

        internal static readonly PolygonKernel2 Instance = new PolygonKernel2_EIK();

        internal override IntPtr Create()
        {
            return Polygon2_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            Polygon2_EIK_Release(ptr);
        }

        internal override int Count(IntPtr ptr)
        {
            return Polygon2_EIK_Count(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return Polygon2_EIK_Copy(ptr);
        }

        internal override IntPtr Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Polygon2_EIK_Convert(ptr, k);
        }

        internal override Box2d GetBoundingBox(IntPtr ptr)
        {
            return Polygon2_EIK_GetBoundingBox(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            Polygon2_EIK_Copy(ptr);
        }

        internal override int Capacity(IntPtr ptr)
        {
            return Polygon2_EIK_Capacity(ptr);
        }

        internal override void Resize(IntPtr ptr, int count)
        {
            Polygon2_EIK_Resize(ptr, count);
        }

        internal override void ShrinkToFit(IntPtr ptr)
        {
            Polygon2_EIK_ShrinkToFit(ptr);
        }

        internal override void Erase(IntPtr ptr, int index)
        {
            Polygon2_EIK_Erase(ptr, index);
        }

        internal override void EraseRange(IntPtr ptr, int start, int count)
        {
            Polygon2_EIK_EraseRange(ptr, start, count);
        }

        internal override void Insert(IntPtr ptr, int index, Point2d point)
        {
            Polygon2_EIK_Insert(ptr, index, point);
        }

        internal override void InsertRange(IntPtr ptr, int start, int count, Point2d[] points)
        {
            Polygon2_EIK_InsertRange(ptr, start, count, points);
        }

        internal override double SqPerimeter(IntPtr ptr)
        {
            return Polygon2_EIK_SqPerimeter(ptr);
        }

        internal override Point2d GetPoint(IntPtr ptr, int index)
        {
            return Polygon2_EIK_GetPoint(ptr, index);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Polygon2_EIK_GetPoints(ptr, points, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            Polygon2_EIK_GetSegments(ptr, segments, count);
        }

        internal override void SetPoint(IntPtr ptr, int index, Point2d point)
        {
            Polygon2_EIK_SetPoint(ptr, index, point);
        }

        internal override void SetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Polygon2_EIK_SetPoints(ptr, points, count);
        }

        internal override void Reverse(IntPtr ptr)
        {
            Polygon2_EIK_Reverse(ptr);
        }

        internal override bool IsSimple(IntPtr ptr)
        {
            return Polygon2_EIK_IsSimple(ptr);
        }

        internal override bool IsConvex(IntPtr ptr)
        {
            return Polygon2_EIK_IsConvex(ptr);
        }

        internal override ORIENTATION Orientation(IntPtr ptr)
        {
            return Polygon2_EIK_Orientation(ptr);
        }

        internal override ORIENTED_SIDE OrientedSide(IntPtr ptr, Point2d point)
        {
            return Polygon2_EIK_OrientedSide(ptr, point);
        }

        internal override BOUNDED_SIDE BoundedSide(IntPtr ptr, Point2d point)
        {
            return Polygon2_EIK_BoundedSide(ptr, point);
        }

        internal override double SignedArea(IntPtr ptr)
        {
            return Polygon2_EIK_SignedArea(ptr);
        }

        internal override void Translate(IntPtr ptr, Point2d translation)
        {
            Polygon2_EIK_Translate(ptr, translation);
        }

        internal override void Rotate(IntPtr ptr, double rotation)
        {
            Polygon2_EIK_Rotate(ptr, rotation);
        }

        internal override void Scale(IntPtr ptr, double scale)
        {
            Polygon2_EIK_Scale(ptr, scale);
        }

        internal override void Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Polygon2_EIK_Transform(ptr, translation, rotation, scale);
        }

        internal override bool ContainsPoint(IntPtr ptr, Point2d point, ORIENTATION orientation, bool inculdeBoundary)
        {
            return Polygon2_EIK_ContainsPoint(ptr, point, orientation, inculdeBoundary);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polygon2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polygon2_EIK_Count(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polygon2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polygon2_EIK_Convert(IntPtr ptr, CGAL_KERNEL k);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Box2d Polygon2_EIK_GetBoundingBox(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polygon2_EIK_Capacity(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Resize(IntPtr ptr, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_ShrinkToFit(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Erase(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_EraseRange(IntPtr ptr, int start, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Insert(IntPtr ptr, int index, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_InsertRange(IntPtr ptr, int start, int count, Point2d[] points);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Polygon2_EIK_SqPerimeter(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EIK_GetPoint(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_SetPoint(IntPtr ptr, int index, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_SetPoints(IntPtr ptr, [In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EIK_TopVertex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EIK_BottomVertex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EIK_RightVertex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EIK_LeftVertex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Reverse(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polygon2_EIK_IsSimple(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polygon2_EIK_IsConvex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION Polygon2_EIK_Orientation(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTED_SIDE Polygon2_EIK_OrientedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern BOUNDED_SIDE Polygon2_EIK_BoundedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Polygon2_EIK_SignedArea(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Translate(IntPtr ptr, Point2d translation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Rotate(IntPtr ptr, double rotation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Scale(IntPtr ptr, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polygon2_EIK_ContainsPoint(IntPtr ptr, Point2d point, ORIENTATION orientation, bool inculdeBoundary);

    }
}
