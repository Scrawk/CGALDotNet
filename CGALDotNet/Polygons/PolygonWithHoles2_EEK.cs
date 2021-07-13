using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public sealed partial class PolygonWithHoles2_EEK : PolygonWithHoles2
    {
        public PolygonWithHoles2_EEK()
        {
            SetPtr(PolygonWithHoles2_EEK_Create());
        }

        public PolygonWithHoles2_EEK(Polygon2_EEK boundary)
        {
            SetPtr(PolygonWithHoles2_EEK_CreateFromPolygon(boundary.Ptr));
        }

        public PolygonWithHoles2_EEK(Point2d[] boundary)
        {
            SetPtr(PolygonWithHoles2_EEK_CreateFromPoints(boundary, 0, boundary.Length));
        }

        internal PolygonWithHoles2_EEK(IntPtr ptr) : base(ptr)
        {
            HoleCount = PolygonWithHoles2_EEK_HoleCount(Ptr);
        }

        public override string ToString()
        {
            return string.Format("[PolygonWithHoles2_EEK: HoleCount={0}]", HoleCount);
        }

        public PolygonWithHoles2_EEK Copy()
        {
            return new PolygonWithHoles2_EEK(PolygonWithHoles2_EEK_Copy(Ptr));
        }

        public override void Clear()
        {
            HoleCount = 0;
            PolygonWithHoles2_EEK_Clear(Ptr);
        }

        public override void RemoveBoundary()
        {
            PolygonWithHoles2_EEK_ClearBoundary(Ptr);
        }

        public override void ReverseBoundary()
        {
            PolygonWithHoles2_EEK_ReverseHole(Ptr, -1);
        }

        public Polygon2_EEK CopyBoundary()
        {
            var ptr = PolygonWithHoles2_EEK_CopyHole(Ptr, -1);
            if (ptr != IntPtr.Zero)
                return new Polygon2_EEK(ptr);
            else
                return null;
        }

        public override void AddHole(Point2d[] points)
        {
            PolygonWithHoles2_EEK_AddHoleFromPoints(Ptr, points, 0, points.Length);
            HoleCount++;
        }

        public override void AddHole(Polygon2 polygon)
        {
            PolygonWithHoles2_EEK_AddHoleFromPolygon(Ptr, polygon.Ptr);
            HoleCount++;
        }

        public override void RemoveHole(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            PolygonWithHoles2_EEK_RemoveHole(Ptr, index);
            HoleCount--;
        }

        public override void ReverseHole(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            PolygonWithHoles2_EEK_ReverseHole(Ptr, index);
        }

        public Polygon2_EEK CopyHole(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return new Polygon2_EEK(PolygonWithHoles2_EEK_CopyHole(Ptr, index));
        }

        public override bool IsUnbounded()
        {
            return PolygonWithHoles2_EEK_IsUnbounded(Ptr);
        }

        public override bool BoundaryIsSimple()
        {
            return PolygonWithHoles2_EEK_IsSimple(Ptr, -1);
        }

        public override bool BoundaryIsConvex()
        {
            return PolygonWithHoles2_EEK_IsConvex(Ptr, -1);
        }

        public override CGAL_ORIENTATION BoundaryOrientation()
        {
            return PolygonWithHoles2_EEK_Orientation(Ptr, -1);
        }

        public override CGAL_ORIENTED_SIDE BoundaryOrientedSide(Point2d point)
        {
            return PolygonWithHoles2_EEK_OrientedSide(Ptr, -1, point);
        }

        public override double BoundarySignedArea()
        {
            return PolygonWithHoles2_EEK_SignedArea(Ptr, -1);
        }

        public override bool HoleIsSimple(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_IsSimple(Ptr, index);
        }

        public override bool HoleIsConvex(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_IsConvex(Ptr, index);
        }

        public override CGAL_ORIENTATION HoleOrientation(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_Orientation(Ptr, index);
        }

        public override CGAL_ORIENTED_SIDE HoleOrientedSide(int index, Point2d point)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_OrientedSide(Ptr, index, point);
        }

        public override double HoleSignedArea(int index)
        {
            ErrorUtil.CheckBounds(index, HoleCount);
            return PolygonWithHoles2_EEK_SignedArea(Ptr, index);
        }

        public List<Polygon2_EEK> ToList()
        {
            var unbounded = IsUnbounded();

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
