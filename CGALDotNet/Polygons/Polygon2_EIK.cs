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
            SetPtr(Polygon2_EIK_Create());
        }

        public Polygon2_EIK(Point2d[] points)
        {
            Count = points.Length;
            SetPtr(Polygon2_EIK_CreateFromPoints(points, 0, points.Length));
            Update();
        }

        internal Polygon2_EIK(IntPtr ptr) : base(ptr)
        {
            Count = Polygon2_EIK_Count(Ptr);
            Update();
        }

        public override string ToString()
        {
            Update();
            return string.Format("[Polygon2_EIK: Count={0}, IsSimple={1}, Orientation={2}]", 
                Count, IsSimple, Orientation);
        }

        public Polygon2_EIK Copy()
        {
            CheckPtr();
            var copy = new Polygon2_EIK(Polygon2_EIK_Copy(Ptr));
            copy.IsSimple = IsSimple;
            copy.Orientation = Orientation;
            copy.IsUpdated = true;
            return copy;
        }

        public override void Clear()
        {
            Count = 0;
            CheckPtr();
            Polygon2_EIK_Clear(Ptr);
            IsSimple = false;
            Orientation = CGAL_ORIENTATION.ZERO;
            IsUpdated = true;
        }

        public override Point2d GetPoint(int index)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, Count);
            return Polygon2_EIK_GetPoint(Ptr, index);
        }

        public override Point2d GetPointWrapped(int index)
        {
            CheckPtr();
            index = MathUtil.Wrap(index, Count);
            return Polygon2_EIK_GetPoint(Ptr, index);
        }

        public override Point2d GetPointClamped(int index)
        {
            CheckPtr();
            index = MathUtil.Clamp(index, 0, Count - 1);
            return Polygon2_EIK_GetPoint(Ptr, index);
        }

        public override void GetPoints(Point2d[] points, int startIndex = 0)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(points, startIndex, Count);
            Polygon2_EIK_GetPoints(Ptr, points, startIndex, Count);
        }

        public override void SetPoint(int index, Point2d point)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, Count);
            Polygon2_EIK_SetPoint(Ptr, index, point);
            IsUpdated = false;
        }

        public override void SetPoints(Point2d[] points, int startIndex = 0)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(points, startIndex, Count);
            Polygon2_EIK_SetPoints(Ptr, points, startIndex, Count);
            IsUpdated = false;
        }

        public override void Reverse()
        {
            CheckPtr();
            Polygon2_EIK_Reverse(Ptr);
            ReverseOrientation();
        }

        public override bool FindIfSimple()
        {
            CheckPtr();
            if (Count < 3)
                return false;
            else
                return Polygon2_EIK_IsSimple(Ptr);
        }

        public override bool FindIfConvex()
        {
            CheckPtr();
            if (IsSimple)
                return Polygon2_EIK_IsConvex(Ptr);
            else
                return false;
        }

        public override CGAL_ORIENTATION FindOrientation()
        {
            CheckPtr();
            if (IsSimple)
                return Polygon2_EIK_Orientation(Ptr);
            else
                return CGAL_ORIENTATION.ZERO;
        }

        public override CGAL_ORIENTED_SIDE OrientedSide(Point2d point)
        {
            CheckPtr();
            if (IsSimple)
                return Polygon2_EIK_OrientedSide(Ptr, point);
            else
                return CGAL_ORIENTED_SIDE.UNDETERMINED;
        }

        public override double FindSignedArea()
        {
            CheckPtr();
            if (IsSimple)
                return Polygon2_EIK_SignedArea(Ptr);
            else
                return 0;
        }

        protected override void ReleasePtr()
        {
            Polygon2_EIK_Release(Ptr);
        }

    }
}
