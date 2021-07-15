using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonWithHolesKernel2_EEK : PolygonWithHolesKernel2
    {

        internal static readonly PolygonWithHolesKernel2_EEK Instance = new PolygonWithHolesKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return PolygonWithHoles2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonWithHoles2_EEK_Release(ptr);
        }

        internal override int HoleCount(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_HoleCount(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_Copy(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            PolygonWithHoles2_EEK_Clear(ptr);
        }

        internal override void ClearBoundary(IntPtr ptr)
        {
            PolygonWithHoles2_EEK_ClearBoundary(ptr);
        }

        internal override IntPtr CreateFromPolygon(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_CreateFromPolygon(ptr);
        }

        internal override IntPtr CreateFromPoints(Point2d[] points, int startIndex, int count)
        {
            return PolygonWithHoles2_EEK_CreateFromPoints(points, startIndex, count);
        }

        internal override void AddHoleFromPolygon(IntPtr pwhPtr, IntPtr polygonPtr)
        {
            PolygonWithHoles2_EEK_AddHoleFromPolygon(pwhPtr, polygonPtr);
        }

        internal override void AddHoleFromPoints(IntPtr ptr, Point2d[] points, int startIndex, int count)
        {
            PolygonWithHoles2_EEK_AddHoleFromPoints(ptr, points, startIndex, count);
        }

        internal override void RemoveHole(IntPtr ptr, int index)
        {
            PolygonWithHoles2_EEK_RemoveHole(ptr, index);
        }

        internal override IntPtr CopyHole(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_CopyHole(ptr, index);
        }

        internal override void ReverseHole(IntPtr ptr, int index)
        {
            PolygonWithHoles2_EEK_ReverseHole(ptr, index);
        }

        internal override bool IsUnbounded(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_IsUnbounded(ptr);
        }

        internal override bool IsSimple(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_IsSimple(ptr, index);
        }

        internal override bool IsConvex(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_IsConvex(ptr, index);
        }

        internal override CGAL_ORIENTATION Orientation(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_Orientation(ptr, index);
        }

        internal override CGAL_ORIENTED_SIDE OrientedSide(IntPtr ptr, int index, Point2d point)
        {
            return PolygonWithHoles2_EEK_OrientedSide(ptr, index, point);
        }

        internal override double SignedArea(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_SignedArea(ptr, index);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonWithHoles2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonWithHoles2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonWithHoles2_EEK_HoleCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonWithHoles2_EEK_Copy(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonWithHoles2_EEK_Clear(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonWithHoles2_EEK_ClearBoundary(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonWithHoles2_EEK_CreateFromPolygon(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonWithHoles2_EEK_CreateFromPoints(Point2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonWithHoles2_EEK_AddHoleFromPolygon(IntPtr pwhPtr, IntPtr polygonPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonWithHoles2_EEK_AddHoleFromPoints(IntPtr ptr, Point2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonWithHoles2_EEK_RemoveHole(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonWithHoles2_EEK_CopyHole(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonWithHoles2_EEK_ReverseHole(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonWithHoles2_EEK_IsUnbounded(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonWithHoles2_EEK_IsSimple(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonWithHoles2_EEK_IsConvex(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern CGAL_ORIENTATION PolygonWithHoles2_EEK_Orientation(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern CGAL_ORIENTED_SIDE PolygonWithHoles2_EEK_OrientedSide(IntPtr ptr, int index, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double PolygonWithHoles2_EEK_SignedArea(IntPtr ptr, int index);
    }
}
