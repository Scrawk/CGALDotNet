using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Meshing
{
    internal abstract class ConformingTriangulationKernel2 : CGALObjectKernel
	{

		internal abstract IntPtr Create();

		internal abstract void Release(IntPtr ptr);

		internal abstract void Clear(IntPtr ptr);

		internal abstract IntPtr Copy(IntPtr ptr);

		internal abstract int VertexCount(IntPtr ptr);

		internal abstract int FaceCount(IntPtr ptr);

		internal abstract void InsertPoint(IntPtr ptr, Point2d point);

		internal abstract void InsertPoints(IntPtr ptr, Point2d[] points, int count);

		internal abstract void InsertPolygon(IntPtr triPtr, IntPtr polyPtr);

		internal abstract void InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr);

		internal abstract void GetPoints(IntPtr ptr, Point2d[] points, int count);

		internal abstract void GetIndices(IntPtr ptr, int[] indices, int count);

		internal abstract void Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

		internal abstract void InsertSegmentConstraint(IntPtr ptr, Point2d a, Point2d b);

		internal abstract void InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int count);

		internal abstract void InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr);

		internal abstract void InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr);

		internal abstract void MakeDelaunay(IntPtr ptr);

		internal abstract void MakeGabriel(IntPtr ptr);

		internal abstract void RefineAndOptimize(IntPtr ptr, int iterations, double angleBounds, double lengthBounds);

		internal abstract void RefineAndOptimizeWithSeeds(IntPtr ptr, int iterations, double angleBounds, double lengthBounds, Point2d[] points, int count);
	}
}


