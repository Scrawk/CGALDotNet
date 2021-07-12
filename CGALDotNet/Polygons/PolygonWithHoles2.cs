using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public class PolygonWithHoles2 : CGALObject
    {
        public PolygonWithHoles2()
        {
            SetPtr(PolygonWithHoles2_EEK_Create());
        }

        public PolygonWithHoles2(Polygon2_EEK polygon)
        {
            SetPtr(PolygonWithHoles2_EEK_CreateFromPolygon(polygon.Ptr));
        }

        public PolygonWithHoles2(Point2d[] points)
        {
            SetPtr(PolygonWithHoles2_EEK_CreateFromPoints(points, 0, points.Length));
        }

        internal PolygonWithHoles2(IntPtr ptr) : base(ptr)
        {
            HoleCount = PolygonWithHoles2_EEK_HoleCount(Ptr);
        }

        public int HoleCount { get; private set; }

        public override string ToString()
        {
            return string.Format("[PolygonWithHoles2: HoleCount={0}]", HoleCount);
        }

        public PolygonWithHoles2 Copy()
        {
            return new PolygonWithHoles2(PolygonWithHoles2_EEK_Copy(Ptr));
        }

        public void Clear()
        {
            HoleCount = 0;
            PolygonWithHoles2_EEK_Clear(Ptr);
        }

        public void AddHole(Point2d[] points)
        {
            PolygonWithHoles2_EEK_AddHoleFromPoints(Ptr, points, 0, points.Length);
            HoleCount++;
        }

        public void AddHole(Polygon2 polygon)
        {
            PolygonWithHoles2_EEK_AddHoleFromPolygon(Ptr, polygon.Ptr);
            HoleCount++;
        }

        public void RemoveHole(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            PolygonWithHoles2_EEK_RemoveHole(Ptr, index);
            HoleCount--;
        }

        public Polygon2_EEK CopyHole(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return new Polygon2_EEK(PolygonWithHoles2_EEK_CopyHole(Ptr, index));
        }

        public bool IsUnbounded()
        {
            return PolygonWithHoles2_EEK_IsUnbounded(Ptr);
        }

        public bool BoundaryIsSimple()
        {
            return PolygonWithHoles2_EEK_IsSimple(Ptr, -1);
        }

        public bool BoundaryIsConvex()
        {
            return PolygonWithHoles2_EEK_IsConvex(Ptr, -1);
        }

        public CGAL_ORIENTATION BoundaryOrientation()
        {
            return PolygonWithHoles2_EEK_Orientation(Ptr, -1);
        }

        public CGAL_ORIENTED_SIDE BoundaryOrientedSide(Point2d point)
        {
            return PolygonWithHoles2_EEK_OrientedSide(Ptr, -1, point);
        }

        public double BoundarySignedArea()
        {
            return PolygonWithHoles2_EEK_SignedArea(Ptr, -1);
        }

        public bool HoleIsSimple(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_IsSimple(Ptr, index);
        }

        public bool HoleIsConvex(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_IsConvex(Ptr, index);
        }

        public CGAL_ORIENTATION HoleOrientation(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_Orientation(Ptr, index);
        }

        public CGAL_ORIENTED_SIDE HoleOrientedSide(int index, Point2d point)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_OrientedSide(Ptr, index, point);
        }

        public double HoleSignedArea(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_SignedArea(Ptr, index);
        }

        protected override void ReleasePtr()
        {
            PolygonWithHoles2_EEK_Release(Ptr);
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
