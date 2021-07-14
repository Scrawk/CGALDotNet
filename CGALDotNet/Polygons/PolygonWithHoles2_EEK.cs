using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public sealed partial class PolygonWithHoles2_EEK : PolygonWithHoles2
    {

        public PolygonWithHoles2_EEK(Polygon2_EEK boundary)
        {
            CheckPolygon(boundary);
            SetPtr(PolygonWithHoles2_EEK_CreateFromPolygon(boundary.Ptr));
        }

        public PolygonWithHoles2_EEK(Point2d[] points)
        {
            var boundary = new Polygon2_EEK(points);
            CheckPolygon(boundary);
            SetPtr(PolygonWithHoles2_EEK_CreateFromPolygon(boundary.Ptr));
        }

        internal PolygonWithHoles2_EEK(IntPtr ptr) : base(ptr)
        {
            HoleCount = PolygonWithHoles2_EEK_HoleCount(Ptr);
        }

        public override string ToString()
        {
            return string.Format("[PolygonWithHoles2_EEK: HoleCount={0}]", HoleCount);
        }

        public override void Clear()
        {
            CheckPtr();
            PolygonWithHoles2_EEK_Clear(Ptr);
        }

        public override void RemoveBoundary()
        {
            CheckPtr();
            PolygonWithHoles2_EEK_RemoveHole(Ptr, -1);
        }

        public override void ReverseBoundary()
        {
            CheckPtr();
            PolygonWithHoles2_EEK_ReverseHole(Ptr, -1);
        }

        public PolygonWithHoles2_EEK Copy()
        {
            CheckPtr();
            return new PolygonWithHoles2_EEK(PolygonWithHoles2_EEK_Copy(Ptr));
        }

        public Polygon2_EEK CopyBoundary()
        {
            CheckPtr();
            var ptr = PolygonWithHoles2_EEK_CopyHole(Ptr, -1);
            if (ptr != IntPtr.Zero)
                return new Polygon2_EEK(ptr);
            else
                return null;
        }

        public override void AddHole(Polygon2 polygon)
        {
            CheckPtr();
            CheckPolygon(polygon);
            PolygonWithHoles2_EEK_AddHoleFromPolygon(Ptr, polygon.Ptr);
            HoleCount++;
        }

        public override void RemoveHole(int index)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, HoleCount);
            PolygonWithHoles2_EEK_RemoveHole(Ptr, index);
            HoleCount--;
        }

        public override void ReverseHole(int index)
        {
            CheckPtr();
            PolygonWithHoles2_EEK_ReverseHole(Ptr, index);
        }

        public Polygon2_EEK CopyHole(int index)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, HoleCount);
            return new Polygon2_EEK(PolygonWithHoles2_EEK_CopyHole(Ptr, index));
        }

        public override bool FindIfUnbounded()
        {
            CheckPtr();
            return PolygonWithHoles2_EEK_IsUnbounded(Ptr);
        }

        public override bool FindIfBoundaryIsSimple()
        {
            CheckPtr();
            return PolygonWithHoles2_EEK_IsSimple(Ptr, -1);
        }

        public override bool FindIfBoundaryIsConvex()
        {
            CheckPtr();
            return PolygonWithHoles2_EEK_IsConvex(Ptr, -1);
        }

        public override CGAL_ORIENTATION FindBoundaryOrientation()
        {
            CheckPtr();
            return PolygonWithHoles2_EEK_Orientation(Ptr, -1);
        }

        public override CGAL_ORIENTED_SIDE BoundaryOrientedSide(Point2d point)
        {
            CheckPtr();
            return PolygonWithHoles2_EEK_OrientedSide(Ptr, -1, point);
        }

        public override double FindBoundarySignedArea()
        {
            CheckPtr();
            return PolygonWithHoles2_EEK_SignedArea(Ptr, -1);
        }

        public override bool FindIfHoleIsSimple(int index)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_IsSimple(Ptr, index);
        }

        public override bool FindIfHoleIsConvex(int index)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_IsConvex(Ptr, index);
        }

        public override CGAL_ORIENTATION FindHoleOrientation(int index)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_Orientation(Ptr, index);
        }

        public override CGAL_ORIENTED_SIDE HoleOrientedSide(int index, Point2d point)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_OrientedSide(Ptr, index, point);
        }

        public override double FindHoleSignedArea(int index)
        {
            CheckPtr();
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_SignedArea(Ptr, index);
        }

        public List<Polygon2_EEK> ToList()
        {
            var unbounded = FindIfUnbounded();

            int count = HoleCount;
            if (!unbounded)
                count++;

            var polygons = new List<Polygon2_EEK>(count);

            if(!unbounded)
                polygons.Add(CopyBoundary());

            for (int i = 0; i < HoleCount; i++)
                polygons.Add(CopyHole(i));

            return polygons;
        }

        protected override void ReleasePtr()
        {
            PolygonWithHoles2_EEK_Release(Ptr);
        }
    }
}
