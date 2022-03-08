using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{

    internal class PolygonKernel2_EEK : PolygonKernel2
    {
        internal override string Name => "EEK";

        internal static readonly PolygonKernel2 Instance = new PolygonKernel2_EEK();

        internal override IntPtr Create()
        {
            return Polygon2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            Polygon2_EEK_Release(ptr);
        }

        internal override int Count(IntPtr ptr)
        {
            return Polygon2_EEK_Count(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return Polygon2_EEK_Copy(ptr);
        }

        internal override IntPtr Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Polygon2_EEK_Convert(ptr, k);
        }

        internal override Box2d GetBoundingBox(IntPtr ptr)
        {
            return Polygon2_EEK_GetBoundingBox(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            Polygon2_EEK_Copy(ptr);
        }

        internal override int Capacity(IntPtr ptr)
        {
            return Polygon2_EEK_Capacity(ptr);
        }

        internal override void Resize(IntPtr ptr, int count)
        {
            Polygon2_EEK_Resize(ptr, count);
        }

        internal override void ShrinkToFit(IntPtr ptr)
        {
            Polygon2_EEK_ShrinkToFit(ptr);
        }

        internal override void Erase(IntPtr ptr, int index)
        {
            Polygon2_EEK_Erase(ptr, index);
        }

        internal override void EraseRange(IntPtr ptr, int start, int count)
        {
            Polygon2_EEK_EraseRange(ptr, start, count);
        }

        internal override void Insert(IntPtr ptr, int index, Point2d point)
        {
            Polygon2_EEK_Insert(ptr, index, point);
        }

        internal override void InsertRange(IntPtr ptr, int start, int count, Point2d[] points)
        {
            Polygon2_EEK_InsertRange(ptr, start, count, points);
        }

        internal override double SqPerimeter(IntPtr ptr)
        {
            return Polygon2_EEK_SqPerimeter(ptr);
        }

        internal override Point2d GetPoint(IntPtr ptr, int index)
        {
            return Polygon2_EEK_GetPoint(ptr, index);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Polygon2_EEK_GetPoints(ptr, points, count);
        }

        internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            Polygon2_EEK_GetSegments(ptr, segments, count);
        }

        internal override void SetPoint(IntPtr ptr, int index, Point2d point)
        {
            Polygon2_EEK_SetPoint(ptr, index, point);
        }

        internal override void SetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Polygon2_EEK_SetPoints(ptr, points, count);
        }

        internal override void Reverse(IntPtr ptr)
        {
            Polygon2_EEK_Reverse(ptr);
        }

        internal override bool IsSimple(IntPtr ptr)
        {
            return Polygon2_EEK_IsSimple(ptr);
        }

        internal override bool IsConvex(IntPtr ptr)
        {
            return Polygon2_EEK_IsConvex(ptr);
        }

        internal override ORIENTATION Orientation(IntPtr ptr)
        {
            return Polygon2_EEK_Orientation(ptr);
        }

        internal override ORIENTED_SIDE OrientedSide(IntPtr ptr, Point2d point)
        {
            return Polygon2_EEK_OrientedSide(ptr, point);
        }

        internal override BOUNDED_SIDE BoundedSide(IntPtr ptr, Point2d point)
        {
            return Polygon2_EEK_BoundedSide(ptr, point);
        }

        internal override double SignedArea(IntPtr ptr)
        {
            return Polygon2_EEK_SignedArea(ptr);
        }

        internal override void Translate(IntPtr ptr, Point2d translation)
        {
            Polygon2_EEK_Translate(ptr, translation);
        }

        internal override void Rotate(IntPtr ptr, double rotation)
        {
            Polygon2_EEK_Rotate(ptr, rotation);
        }

        internal override void Scale(IntPtr ptr, double scale)
        {
            Polygon2_EEK_Scale(ptr, scale);
        }

        internal override void Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Polygon2_EEK_Transform(ptr,  translation, rotation, scale);
        }

        internal override bool ContainsPoint(IntPtr ptr, Point2d point, ORIENTATION orientation, bool inculdeBoundary)
        {
            return Polygon2_EEK_ContainsPoint(ptr, point, orientation, inculdeBoundary);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polygon2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polygon2_EEK_Count(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polygon2_EEK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polygon2_EEK_Convert(IntPtr ptr, CGAL_KERNEL k);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Box2d Polygon2_EEK_GetBoundingBox(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polygon2_EEK_Capacity(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Resize(IntPtr ptr, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_ShrinkToFit(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Erase(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_EraseRange(IntPtr ptr, int start, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Insert(IntPtr ptr, int index, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_InsertRange(IntPtr ptr, int start, int count, Point2d[] points);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Polygon2_EEK_SqPerimeter(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EEK_GetPoint(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_SetPoint(IntPtr ptr, int index, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_SetPoints(IntPtr ptr, [In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EEK_TopVertex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EEK_BottomVertex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EEK_RightVertex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polygon2_EEK_LeftVertex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Reverse(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polygon2_EEK_IsSimple(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polygon2_EEK_IsConvex(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION Polygon2_EEK_Orientation(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTED_SIDE Polygon2_EEK_OrientedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern BOUNDED_SIDE Polygon2_EEK_BoundedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Polygon2_EEK_SignedArea(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Translate(IntPtr ptr, Point2d translation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Rotate(IntPtr ptr, double rotation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Scale(IntPtr ptr, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polygon2_EEK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polygon2_EEK_ContainsPoint(IntPtr ptr, Point2d point, ORIENTATION orientation, bool inculdeBoundary);

    }
}
