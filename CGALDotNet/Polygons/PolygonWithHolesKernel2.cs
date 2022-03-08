using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonWithHolesKernel2 : CGALObjectKernel
    {

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract int HoleCount(IntPtr ptr);

        internal abstract int PointCount(IntPtr ptr, int index);

        internal abstract IntPtr Copy(IntPtr ptr);

        internal abstract IntPtr Convert(IntPtr ptr, CGAL_KERNEL k);

        internal abstract void Clear(IntPtr ptr);

        internal abstract void ClearBoundary(IntPtr ptr);

        internal abstract void ClearHoles(IntPtr ptr);

        internal abstract IntPtr CreateFromPolygon(IntPtr ptr);

        internal abstract IntPtr CreateFromPoints(Point2d[] points, int count);

        internal abstract Point2d GetPoint(IntPtr ptr, int polyIndex, int pointIndex);

        internal abstract void GetPoints(IntPtr ptr, Point2d[] points, int polyIndex, int count);

        internal abstract void SetPoint(IntPtr ptr, int polyIndex, int pointIndex, Point2d point);

        internal abstract void SetPoints(IntPtr ptr, Point2d[] points, int polyIndex, int count);

        internal abstract void AddHoleFromPolygon(IntPtr pwhPtr, IntPtr polygonPtr);

        internal abstract void AddHoleFromPoints(IntPtr ptr, Point2d[] points, int count);

        internal abstract void RemoveHole(IntPtr ptr, int index);

        internal abstract IntPtr CopyPolygon(IntPtr ptr, int index);

        internal abstract void ReversePolygon(IntPtr ptr, int index);

        internal abstract bool IsUnbounded(IntPtr ptr);

        internal abstract Box2d GetBoundingBox(IntPtr ptr, int index);

        internal abstract bool IsSimple(IntPtr ptr, int index);

        internal abstract bool IsConvex(IntPtr ptr, int index);

        internal abstract ORIENTATION Orientation(IntPtr ptr, int index);

        internal abstract ORIENTED_SIDE OrientedSide(IntPtr ptr, int index, Point2d point);

        internal abstract double SignedArea(IntPtr ptr, int index);

        internal abstract void Translate(IntPtr ptr, int index, Point2d translation);

        internal abstract void Rotate(IntPtr ptr, int index, double rotation);

        internal abstract void Scale(IntPtr ptr, int index, double scale);

        internal abstract void Transform(IntPtr ptr, int index, Point2d translation, double rotation, double scale);

        internal abstract bool ContainsPoint(IntPtr ptr, Point2d point, ORIENTATION orientation, bool inculdeBoundary);

        internal abstract IntPtr ConnectHoles(IntPtr ptr);

    }
}
