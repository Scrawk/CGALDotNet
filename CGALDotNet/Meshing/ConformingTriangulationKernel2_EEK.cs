using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Meshing
{
	internal class ConformingTriangulationKernel2_EEK : ConformingTriangulationKernel2
	{
		internal override string Name => "EEK";

		internal static readonly ConformingTriangulationKernel2 Instance = new ConformingTriangulationKernel2_EEK();

		internal override IntPtr Create()
		{
			return ConformingTriangulation2_EEK_Create();
		}

		internal override void Release(IntPtr ptr)
		{
			ConformingTriangulation2_EEK_Release(ptr);
		}

		internal override void Clear(IntPtr ptr)
		{
			ConformingTriangulation2_EEK_Clear(ptr);
		}

		internal override IntPtr Copy(IntPtr ptr)
		{
			return ConformingTriangulation2_EEK_Copy(ptr);
		}

		internal override int VertexCount(IntPtr ptr)
		{
			return ConformingTriangulation2_EEK_VertexCount(ptr);
		}

		internal override int FaceCount(IntPtr ptr)
		{
			return ConformingTriangulation2_EEK_FaceCount(ptr);
		}

		internal override void InsertPoint(IntPtr ptr, Point2d point)
		{
			ConformingTriangulation2_EEK_InsertPoint(ptr, point);
		}

		internal override void InsertPoints(IntPtr ptr, Point2d[] points, int count)
		{
			ConformingTriangulation2_EEK_InsertPoints(ptr, points, count);
		}

		internal override void InsertPolygon(IntPtr triPtr, IntPtr polyPtr)
		{
			ConformingTriangulation2_EEK_InsertPolygon(triPtr, polyPtr);
		}

		internal override void InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr)
		{
			ConformingTriangulation2_EEK_InsertPolygonWithHoles(triPtr, pwhPtr);
		}

		internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
		{
			ConformingTriangulation2_EEK_GetPoints(ptr, points, count);
		}

		internal override void GetIndices(IntPtr ptr, int[] indices, int count)
		{
			ConformingTriangulation2_EEK_GetIndices(ptr, indices, count);
		}

		internal override void Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
			ConformingTriangulation2_EEK_Transform(ptr, translation, rotation, scale);
		}

		internal override void InsertSegmentConstraint(IntPtr ptr, Point2d a, Point2d b)
		{
			ConformingTriangulation2_EEK_InsertSegmentConstraint(ptr, a, b);
		}

		internal override void InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int count)
		{
			ConformingTriangulation2_EEK_InsertSegmentConstraints(ptr, segments, count);
		}

		internal override void InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr)
		{
			ConformingTriangulation2_EEK_InsertPolygonConstraint(triPtr, polyPtr);
		}

		internal override void InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr)
		{
			ConformingTriangulation2_EEK_InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
		}

		internal override void MakeDelaunay(IntPtr ptr)
		{
			ConformingTriangulation2_EEK_MakeDelaunay(ptr);
		}

		internal override void MakeGabriel(IntPtr ptr)
		{
			ConformingTriangulation2_EEK_MakeGabriel(ptr);
		}

		internal override void RefineAndOptimize(IntPtr ptr, int iterations, double angleBounds, double lengthBounds)
		{
			Conformingriangulation2_EEK_RefineAndOptimize(ptr, iterations, angleBounds, lengthBounds);
		}

		internal override void RefineAndOptimizeWithSeeds(IntPtr ptr, int iterations, double angleBounds, double lengthBounds, Point2d[] points, int count)
		{
			ConformingTriangulation2_EEK_RefineAndOptimizeWithSeeds(ptr, iterations, angleBounds, lengthBounds, points, count);
		}

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr ConformingTriangulation2_EEK_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_Clear(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr ConformingTriangulation2_EEK_Copy(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int ConformingTriangulation2_EEK_VertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int ConformingTriangulation2_EEK_FaceCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_InsertPoint(IntPtr ptr, Point2d point);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_InsertPoints(IntPtr ptr, Point2d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_InsertPolygon(IntPtr triPtr, IntPtr polyPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_GetIndices(IntPtr ptr, [Out] int[] indices, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_InsertSegmentConstraint(IntPtr ptr, Point2d a, Point2d b);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_MakeDelaunay(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_MakeGabriel(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Conformingriangulation2_EEK_RefineAndOptimize(IntPtr ptr, int iterations, double angleBounds, double lengthBounds);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EEK_RefineAndOptimizeWithSeeds(IntPtr ptr, int iterations, double angleBounds, double lengthBounds, Point2d[] points, int count);

	}
}
