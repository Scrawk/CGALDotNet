using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonWithHolesKernel2
    {
        internal PolygonWithHolesKernel2()
        {

        }

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract int HoleCount(IntPtr ptr);

        internal abstract IntPtr Copy(IntPtr ptr);

        internal abstract void Clear(IntPtr ptr);

        internal abstract void ClearBoundary(IntPtr ptr);

        internal abstract IntPtr CreateFromPolygon(IntPtr ptr);

        internal abstract IntPtr CreateFromPoints(Point2d[] points, int startIndex, int count);

        internal abstract void AddHoleFromPolygon(IntPtr pwhPtr, IntPtr polygonPtr);

        internal abstract void AddHoleFromPoints(IntPtr ptr, Point2d[] points, int startIndex, int count);

        internal abstract void RemoveHole(IntPtr ptr, int index);

        internal abstract IntPtr CopyHole(IntPtr ptr, int index);

        internal abstract void ReverseHole(IntPtr ptr, int index);

        internal abstract bool IsUnbounded(IntPtr ptr);

        internal abstract bool IsSimple(IntPtr ptr, int index);

        internal abstract bool IsConvex(IntPtr ptr, int index);

        internal abstract CGAL_ORIENTATION Orientation(IntPtr ptr, int index);

        internal abstract CGAL_ORIENTED_SIDE OrientedSide(IntPtr ptr, int index, Point2d point);

        internal abstract double SignedArea(IntPtr ptr, int index);

        internal abstract void Translate(IntPtr ptr, int index, Point2d translation);

        internal abstract void Rotate(IntPtr ptr, int index, double rotation);

        internal abstract void Scale(IntPtr ptr, int index, double scale);

        internal abstract void Transform(IntPtr ptr, int index, Point2d translation, double rotation, double scale);

    }
}
