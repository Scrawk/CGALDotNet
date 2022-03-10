using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polylines
{
    internal class PolylineKernel2_EEK : PolylineKernel2
    {
        internal override string Name => "EEK";

        internal static readonly PolylineKernel2 Instance = new PolylineKernel2_EEK();

		internal override IntPtr Create()
        {
            return Polyline2_EEK_Create();
        }

		internal override IntPtr CreateWithCount(int count)
        {
            return Polyline2_EEK_CreateWithCount(count);    
        }

		internal override void Release(IntPtr ptr)
        {
            Polyline2_EEK_Release(ptr);
        }

		internal override int Count(IntPtr ptr)
        {
            return Polyline2_EEK_Count(ptr);
        }

		internal override IntPtr Copy(IntPtr ptr)
        {
            return Polyline2_EEK_Copy(ptr);
        }

        internal override IntPtr Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return Polyline2_EEK_Convert(ptr, k);
        }

        internal override void Clear(IntPtr ptr)
        {
            Polyline2_EEK_Clear(ptr);   
        }

		internal override int Capacity(IntPtr ptr)
        {
            return Polyline2_EEK_Capacity(ptr);
        }

		internal override void Resize(IntPtr ptr, int count)
        {
            Polyline2_EEK_Resize(ptr, count);
        }

		internal override void Reverse(IntPtr ptr)
        {
            Polyline2_EEK_Reverse(ptr);
        }

		internal override void ShrinkToFit(IntPtr ptr)
        {
            Polyline2_EEK_ShrinkToFit(ptr);
        }

		internal override void Erase(IntPtr ptr, int index)
        {
            Polyline2_EEK_Erase(ptr, index);
        }

		internal override void EraseRange(IntPtr ptr, int start, int count)
        {
            Polyline2_EEK_EraseRange(ptr, start, count);
        }

        internal override void Insert(IntPtr ptr, int index, Point2d point)
        {
            Polyline2_EEK_Insert(ptr, index, point);
        }

        internal override void InsertRange(IntPtr ptr, int start, int count, Point2d[] points)
        {
            Polyline2_EEK_InsertRange(ptr, start, count, points);
        }

        internal override bool IsClosed(IntPtr ptr, double threshold)
        {
            return Polyline2_EEK_IsClosed(ptr, threshold);
        }

        internal override double SqLength(IntPtr ptr)
        {
            return Polyline2_EEK_SqLength(ptr);
        }

        internal override Point2d GetPoint(IntPtr ptr, int index)
        {
            return Polyline2_EEK_GetPoint(ptr, index);
        }

		internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Polyline2_EEK_GetPoints(ptr, points, count);
        }

		internal override void GetSegments(IntPtr ptr, Segment2d[] segments, int count)
        {
            Polyline2_EEK_GetSegments(ptr, segments, count);
        }

		internal override void SetPoint(IntPtr ptr, int index, Point2d point)
        {
            Polyline2_EEK_SetPoint(ptr, index, point);
        }

		internal override void SetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            Polyline2_EEK_SetPoints(ptr, points, count);
        }

		internal override void Translate(IntPtr ptr, Point2d translation)
        { 
            Polyline2_EEK_Translate(ptr, translation);
        }

		internal override void Rotate(IntPtr ptr, double rotation)
        {
            Polyline2_EEK_Rotate(ptr, rotation);
        }

		internal override void Scale(IntPtr ptr, double scale)
        {
            Polyline2_EEK_Scale(ptr, scale);
        }

		internal override void Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            Polyline2_EEK_Transform(ptr, translation, rotation, scale); 
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline2_EEK_CreateWithCount(int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polyline2_EEK_Count(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline2_EEK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Polyline2_EEK_Convert(IntPtr ptr, CGAL_KERNEL k);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int Polyline2_EEK_Capacity(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Resize(IntPtr ptr, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Reverse(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_ShrinkToFit(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Erase(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_EraseRange(IntPtr ptr, int start, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Insert(IntPtr ptr, int index, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_InsertRange(IntPtr ptr, int start, int count, Point2d[] points);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool Polyline2_EEK_IsClosed(IntPtr ptr, double threshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double Polyline2_EEK_SqLength(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Polyline2_EEK_GetPoint(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_GetSegments(IntPtr ptr, [Out] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_SetPoint(IntPtr ptr, int index, Point2d point);

       [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_SetPoints(IntPtr ptr, Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Translate(IntPtr ptr, Point2d translation);

            [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Rotate(IntPtr ptr, double rotation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Scale(IntPtr ptr, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Polyline2_EEK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);
    }
}
