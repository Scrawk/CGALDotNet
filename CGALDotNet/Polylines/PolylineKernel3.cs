using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polylines
{
	internal abstract class PolylineKernel3 : CGALObjectKernel
	{
		internal abstract IntPtr Create();

		internal abstract IntPtr CreateWithCount(int count);

		internal abstract void Release(IntPtr ptr);

		internal abstract int Count(IntPtr ptr);

		internal abstract IntPtr Copy(IntPtr ptr);

		internal abstract IntPtr Convert(IntPtr ptr, CGAL_KERNEL k);

		internal abstract void Clear(IntPtr ptr);

		internal abstract int Capacity(IntPtr ptr);

		internal abstract void Resize(IntPtr ptr, int count);

		internal abstract void Reverse(IntPtr ptr);

		internal abstract void ShrinkToFit(IntPtr ptr);

		internal abstract void Erase(IntPtr ptr, int index);

		internal abstract void EraseRange(IntPtr ptr, int start, int count);

		internal abstract void Insert(IntPtr ptr, int index, Point3d point);

		internal abstract void InsertRange(IntPtr ptr, int start, int count, Point3d[] points);

		internal abstract bool IsClosed(IntPtr ptr, double threshold);

		internal abstract double SqLength(IntPtr ptr);

		internal abstract Point3d GetPoint(IntPtr ptr, int index);

		internal abstract void GetPoints(IntPtr ptr, Point3d[] points, int count);

		internal abstract void GetSegments(IntPtr ptr, Segment3d[] segments, int count);

		internal abstract void SetPoint(IntPtr ptr, int index, Point3d point);

		internal abstract void SetPoints(IntPtr ptr, Point3d[] points, int count);

		internal abstract void Transform(IntPtr ptr, Matrix4x4d matrix);
	}
}
