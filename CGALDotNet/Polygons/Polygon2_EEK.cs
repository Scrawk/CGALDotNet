using System;
using System.Collections;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public sealed partial class Polygon2_EEK : Polygon2
    {

        public Polygon2_EEK()
        {
            SetPtr(Polygon2_EEK_Create());
        }

        public Polygon2_EEK(Point2d[] points)
        {
            Count = points.Length;
            SetPtr(Polygon2_EEK_CreateFromPoints(points, 0, points.Length));
        }

        internal Polygon2_EEK(IntPtr ptr) : base(ptr)
        {
            Count = Polygon2_EEK_Count(Ptr);
        }

        public override string ToString()
        {
            return string.Format("[Polygon2_EEK: Count={0}]", Count);
        }

        public Polygon2_EEK Copy()
        {
            return new Polygon2_EEK(Polygon2_EEK_Copy(Ptr));
        }

        public override void Clear()
        {
            Count = 0;
            Polygon2_EEK_Clear(Ptr);
        }

        public override Point2d GetPoint(int index)
        {
            ErrorUtil.CheckBounds(index, Count);
            return Polygon2_EEK_GetPoint(Ptr, index);
        }

        public override Point2d GetPointWrapped(int index)
        {
            index = MathUtil.Wrap(index, Count);
            return Polygon2_EEK_GetPoint(Ptr, index);
        }

        public override Point2d GetPointClamped(int index)
        {
            index = MathUtil.Clamp(index, 0, Count - 1);
            return Polygon2_EEK_GetPoint(Ptr, index);
        }

        public override void GetPoints(Point2d[] points, int startIndex = 0)
        {
            ErrorUtil.CheckBounds(points, startIndex, Count);
            Polygon2_EEK_GetPoints(Ptr, points, startIndex, Count);
        }

        public override void SetPoint(int index, Point2d point)
        {
            ErrorUtil.CheckBounds(index, Count);
            Polygon2_EEK_SetPoint(Ptr, index, point);
        }

        public override void SetPoints(Point2d[] points, int startIndex = 0)
        {
            ErrorUtil.CheckBounds(points, startIndex, Count);
            Polygon2_EEK_SetPoints(Ptr, points, startIndex, Count);
        }

        public override void Reverse()
        {
            Polygon2_EEK_Reverse(Ptr);
        }

        public override bool IsSimple()
        {
            return Polygon2_EEK_IsSimple(Ptr);
        }

        public override bool IsConvex()
        {
            return Polygon2_EEK_IsConvex(Ptr);
        }

        public override CGAL_ORIENTATION Orientation()
        {
            return Polygon2_EEK_Orientation(Ptr);
        }

        public override CGAL_ORIENTED_SIDE OrientedSide(Point2d point)
        {
            return Polygon2_EEK_OrientedSide(Ptr, point);
        }

        public override double SignedArea()
        {
            return Polygon2_EEK_SignedArea(Ptr);
        }

        protected override void ReleasePtr()
        {
            Polygon2_EEK_Release(Ptr);
        }

    }
}
