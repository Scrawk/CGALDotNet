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
            Update();
        }

        internal Polygon2_EEK(IntPtr ptr) : base(ptr)
        {
            Count = Polygon2_EEK_Count(Ptr);
            Update();
        }

        public override string ToString()
        {
            Update();
            return string.Format("[Polygon2_EEK: Count={0}, IsSimple={1}, Orientation={2}]", 
                Count, IsSimple, Orientation);
        }

        public Polygon2_EEK Copy()
        {
            CheckPtr();
            var copy = new Polygon2_EEK(Polygon2_EEK_Copy(Ptr));
            copy.IsSimple = IsSimple;
            copy.Orientation = Orientation;
            copy.IsUpdated = true;
            return copy;
        }

        public override void Clear()
        {
            Count = 0;
            CheckPtr();
            Polygon2_EEK_Clear(Ptr);
            IsSimple = false;
            Orientation = CGAL_ORIENTATION.ZERO;
            IsUpdated = true;
        }

        public override Point2d GetPoint(int index)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, Count);
            return Polygon2_EEK_GetPoint(Ptr, index);
        }

        public override Point2d GetPointWrapped(int index)
        {
            CheckPtr();
            index = MathUtil.Wrap(index, Count);
            return Polygon2_EEK_GetPoint(Ptr, index);
        }

        public override Point2d GetPointClamped(int index)
        {
            CheckPtr();
            index = MathUtil.Clamp(index, 0, Count - 1);
            return Polygon2_EEK_GetPoint(Ptr, index);
        }

        public override void GetPoints(Point2d[] points, int startIndex = 0)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(points, startIndex, Count);
            Polygon2_EEK_GetPoints(Ptr, points, startIndex, Count);
        }

        public override void SetPoint(int index, Point2d point)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, Count);
            Polygon2_EEK_SetPoint(Ptr, index, point);
            IsUpdated = false;
        }

        public override void SetPoints(Point2d[] points, int startIndex = 0)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(points, startIndex, Count);
            Polygon2_EEK_SetPoints(Ptr, points, startIndex, Count);
            IsUpdated = false;
        }

        public override void Reverse()
        {
            CheckPtr();
            Polygon2_EEK_Reverse(Ptr);
            ReverseOrientation();
        }

        public override bool FindIfSimple()
        {
            CheckPtr();
            if (Count < 3)
                return false;
            else
                return Polygon2_EEK_IsSimple(Ptr);
        }

        public override bool FindIfConvex()
        {
            CheckPtr();
            if (IsSimple)
                return Polygon2_EEK_IsConvex(Ptr);
            else
                return false;
        }

        public override CGAL_ORIENTATION FindOrientation()
        {
            CheckPtr();
            if (IsSimple)
                return Polygon2_EEK_Orientation(Ptr);
            else
                return CGAL_ORIENTATION.ZERO;
        }

        public override CGAL_ORIENTED_SIDE OrientedSide(Point2d point)
        {
            CheckPtr();
            if (IsSimple)
                return Polygon2_EEK_OrientedSide(Ptr, point);
            else
                return CGAL_ORIENTED_SIDE.UNDETERMINED;
        }

        public override double FindSignedArea()
        {
            CheckPtr();
            if (IsSimple)
                return Polygon2_EEK_SignedArea(Ptr);
            else
                return 0;
        }

        protected override void ReleasePtr()
        {
            Polygon2_EEK_Release(Ptr);
        }

    }
}
