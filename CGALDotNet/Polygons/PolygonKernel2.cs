using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonKernel2 : CGALObjectKernel
    {

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract int Count(IntPtr ptr);

        internal abstract IntPtr Copy(IntPtr ptr);

        internal abstract IntPtr Convert(IntPtr ptr, CGAL_KERNEL k);

        internal abstract Box2d GetBoundingBox(IntPtr ptr);

        internal abstract void Clear(IntPtr ptr);

        internal abstract int Capacity(IntPtr ptr);

        internal abstract void Resize(IntPtr ptr, int count);

        internal abstract void ShrinkToFit(IntPtr ptr);

        internal abstract void Erase(IntPtr ptr, int index);

        internal abstract void EraseRange(IntPtr ptr, int start, int count);

        internal abstract void Insert(IntPtr ptr, int index, Point2d point);

        internal abstract void InsertRange(IntPtr ptr, int start, int count, Point2d[] points);

        internal abstract double SqPerimeter(IntPtr ptr);

        internal abstract Point2d GetPoint(IntPtr ptr, int index);

        internal abstract void GetPoints(IntPtr ptr, Point2d[] points, int count);

        internal abstract void GetSegments(IntPtr ptr, Segment2d[] segments, int count);

        internal abstract void SetPoint(IntPtr ptr, int index, Point2d point);

        internal abstract void SetPoints(IntPtr ptr, Point2d[] points, int count);

        internal abstract void Reverse(IntPtr ptr);

        internal abstract bool IsSimple(IntPtr ptr);

        internal abstract bool IsConvex(IntPtr ptr);

        internal abstract ORIENTATION Orientation(IntPtr ptr);

        internal abstract ORIENTED_SIDE OrientedSide(IntPtr ptr, Point2d point);

        internal abstract BOUNDED_SIDE BoundedSide(IntPtr ptr, Point2d point);

        internal abstract double SignedArea(IntPtr ptr);

        internal abstract void Translate(IntPtr ptr, Point2d translation);

        internal abstract void Rotate(IntPtr ptr, double rotation);

        internal abstract void Scale(IntPtr ptr, double scale);

        internal abstract void Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

        internal abstract bool ContainsPoint(IntPtr ptr, Point2d point, ORIENTATION orientation, bool inculdeBoundary);
    }
}
