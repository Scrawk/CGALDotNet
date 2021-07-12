using System;
using System.Collections;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public sealed partial class Polygon2_EIK : Polygon2
    {

        public Polygon2_EIK()
        {
            Ptr = Polygon2_EIK_Create();
        }

        public Polygon2_EIK(Point2d[] points)
        {
            Count = points.Length;
            Ptr = Polygon2_EIK_CreateFromPoints(points, 0, Count);
        }

        public override string ToString()
        {
            return string.Format("[Polygon2_EIK: Count={0}, IsDisposed={1},]", Count, IsDisposed);
        }

        public override Point2d GetPoint(int index)
        {
            return Polygon2_EIK_GetPoint(Ptr, index);
        }

        public override Point2d GetPointWrapped(int index)
        {
            index = MathUtil.Wrap(index, Count);
            return Polygon2_EIK_GetPoint(Ptr, index);
        }

        public override Point2d GetPointClamped(int index)
        {
            index = MathUtil.Clamp(index, 0, Count - 1);
            return Polygon2_EIK_GetPoint(Ptr, index);
        }

        public override void GetPoints(Point2d[] points, int arrayStartIndex = 0)
        {
            Polygon2_EIK_GetPoints(Ptr, points, arrayStartIndex, Count);
        }

        public override void GetPoints(Point2d[] points, int arrayStartIndex, int count)
        {
            Polygon2_EIK_GetPoints(Ptr, points, arrayStartIndex, count);
        }

        public override void SetPoint(int index, Point2d point)
        {
            Polygon2_EIK_SetPoint(Ptr, index, point);
        }

        public override void SetPoints(Point2d[] points, int arrayStartIndex = 0)
        {
            Polygon2_EIK_SetPoints(Ptr, points, arrayStartIndex, Count);
        }

        public override void SetPoints(Point2d[] points, int arrayStartIndex, int count)
        {
            Polygon2_EIK_SetPoints(Ptr, points, arrayStartIndex, count);
        }

        public override void Reverse()
        {
            Polygon2_EIK_Reverse(Ptr);
        }

        public override bool IsSimple()
        {
            return Polygon2_EIK_IsSimple(Ptr);
        }

        public override bool IsConvex()
        {
            return Polygon2_EIK_IsConvex(Ptr);
        }

        public override CGAL_ORIENTATION Orientation()
        {
            return Polygon2_EIK_Orientation(Ptr);
        }

        public override CGAL_ORIENTED_SIDE OrientedSide(Point2d point)
        {
            return Polygon2_EIK_OrientedSide(Ptr, point);
        }

        public override double SignedArea()
        {
            return Polygon2_EIK_Area(Ptr);
        }

        public override void Clear()
        {
            Count = 0;
            Polygon2_EIK_Clear(Ptr);
        }

        protected override void ReleasePtr()
        {
            Polygon2_EIK_Release(Ptr);
        }

    }
}
