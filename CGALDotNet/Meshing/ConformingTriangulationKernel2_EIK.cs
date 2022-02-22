using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Meshing
{
	internal class ConformingTriangulationKernel2_EIK : ConformingTriangulationKernel2
	{
		internal override string Name => "EIK";

		internal static readonly ConformingTriangulationKernel2 Instance = new ConformingTriangulationKernel2_EIK();

		internal override IntPtr Create()
		{
			return ConformingTriangulation2_EIK_Create();
		}

		internal override void Release(IntPtr ptr)
		{
			ConformingTriangulation2_EIK_Release(ptr);
		}

		internal override void Clear(IntPtr ptr)
		{
			ConformingTriangulation2_EIK_Clear(ptr);
		}

		internal override IntPtr Copy(IntPtr ptr)
		{
			return ConformingTriangulation2_EIK_Copy(ptr);
		}

		internal override int VertexCount(IntPtr ptr)
		{
			return ConformingTriangulation2_EIK_VertexCount(ptr);
		}

		internal override int FaceCount(IntPtr ptr)
		{
			return ConformingTriangulation2_EIK_FaceCount(ptr);
		}

		internal override void InsertPoint(IntPtr ptr, Point2d point)
		{
			ConformingTriangulation2_EIK_InsertPoint(ptr, point);
		}

		internal override void InsertPoints(IntPtr ptr, Point2d[] points, int count)
		{
			ConformingTriangulation2_EIK_InsertPoints(ptr, points, count);
		}

		internal override void InsertPolygon(IntPtr triPtr, IntPtr polyPtr)
		{
			ConformingTriangulation2_EIK_InsertPolygon(triPtr, polyPtr);
		}

		internal override void InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr)
		{
			ConformingTriangulation2_EIK_InsertPolygonWithHoles(triPtr, pwhPtr);
		}

		internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
		{
			ConformingTriangulation2_EIK_GetPoints(ptr, points, count);
		}

		internal override void GetIndices(IntPtr ptr, int[] indices, int count)
		{
			ConformingTriangulation2_EIK_GetIndices(ptr, indices, count);
		}

		internal override void Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
		{
			ConformingTriangulation2_EIK_Transform(ptr, translation, rotation, scale);
		}

		internal override void InsertSegmentConstraint(IntPtr ptr, Point2d a, Point2d b)
		{
			ConformingTriangulation2_EIK_InsertSegmentConstraint(ptr, a, b);
		}

		internal override void InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int count)
		{
			ConformingTriangulation2_EIK_InsertSegmentConstraints(ptr, segments, count);
		}

		internal override void InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr)
		{
			ConformingTriangulation2_EIK_InsertPolygonConstraint(triPtr, polyPtr);
		}

		internal override void InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr)
		{
			ConformingTriangulation2_EIK_InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
		}

		internal override void MakeDelaunay(IntPtr ptr)
		{
			ConformingTriangulation2_EIK_MakeDelaunay(ptr);
		}

		internal override void MakeGabriel(IntPtr ptr)
		{
			ConformingTriangulation2_EIK_MakeGabriel(ptr);
		}

		internal override void RefineAndOptimize(IntPtr ptr, int iterations, double angleBounds, double lengthBounds)
		{
			Conformingriangulation2_EIK_RefineAndOptimize(ptr, iterations, angleBounds, lengthBounds);
		}

		internal override void RefineAndOptimizeWithSeeds(IntPtr ptr, int iterations, double angleBounds, double lengthBounds, Point2d[] points, int count)
		{
			ConformingTriangulation2_EIK_RefineAndOptimizeWithSeeds(ptr, iterations, angleBounds, lengthBounds, points, count);
		}

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr ConformingTriangulation2_EIK_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_Clear(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr ConformingTriangulation2_EIK_Copy(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int ConformingTriangulation2_EIK_VertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int ConformingTriangulation2_EIK_FaceCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_InsertPoint(IntPtr ptr, Point2d point);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_InsertPoints(IntPtr ptr, Point2d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_InsertPolygon(IntPtr triPtr, IntPtr polyPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_GetIndices(IntPtr ptr, [Out] int[] indices, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_InsertSegmentConstraint(IntPtr ptr, Point2d a, Point2d b);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_MakeDelaunay(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_MakeGabriel(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Conformingriangulation2_EIK_RefineAndOptimize(IntPtr ptr, int iterations, double angleBounds, double lengthBounds);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void ConformingTriangulation2_EIK_RefineAndOptimizeWithSeeds(IntPtr ptr, int iterations, double angleBounds, double lengthBounds, Point2d[] points, int count);

	}
}
