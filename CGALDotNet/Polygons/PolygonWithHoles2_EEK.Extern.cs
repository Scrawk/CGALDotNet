using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public sealed partial class PolygonWithHoles2_EEK
    {
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
