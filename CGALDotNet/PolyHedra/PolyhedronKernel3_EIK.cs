using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
	internal class PolyhedronKernel3_EIK : PolyhedronKernel3
	{
		internal override string KernelName => "EIK";

		internal static readonly PolyhedronKernel3 Instance = new PolyhedronKernel3_EIK();

		internal override IntPtr Create()
		{
			return Polyhedron3_EIK_Create();
		}

		internal override void Release(IntPtr ptr)
		{
			Polyhedron3_EIK_Release(ptr);
		}

		internal override void Clear(IntPtr ptr)
		{
			Polyhedron3_EIK_Clear(ptr);
		}

		internal override IntPtr Copy(IntPtr ptr)
		{
			return Polyhedron3_EIK_Copy(ptr);
		}

		internal override void BuildIndices(IntPtr ptr, bool vertices, bool faces, bool force)
		{
			Polyhedron3_EIK_BuildIndices(ptr, vertices, faces, force);
		}

		internal override int VertexCount(IntPtr ptr)
		{
			return Polyhedron3_EIK_VertexCount(ptr);
		}

		internal override int FaceCount(IntPtr ptr)
		{
			return Polyhedron3_EIK_FaceCount(ptr);
		}

		internal override int HalfEdgeCount(IntPtr ptr)
		{
			return Polyhedron3_EIK_HalfEdgeCount(ptr);
		}

		internal override int BorderEdgeCount(IntPtr ptr)
		{
			return Polyhedron3_EIK_BorderEdgeCount(ptr);
		}

		internal override int BorderHalfEdgeCount(IntPtr ptr)
		{
			return Polyhedron3_EIK_BorderHalfEdgeCount(ptr);
		}

		internal override bool IsValid(IntPtr ptr, int level)
		{
			return Polyhedron3_EIK_IsValid(ptr, level);
		}

		internal override bool IsClosed(IntPtr ptr)
		{
			return Polyhedron3_EIK_IsClosed(ptr);
		}

		internal override bool IsPureBivalent(IntPtr ptr)
		{
			return Polyhedron3_EIK_IsPureBivalent(ptr);
		}

		internal override bool IsPureTrivalent(IntPtr ptr)
		{
			return Polyhedron3_EIK_IsPureTrivalent(ptr);
		}

		internal override bool IsPureTriangle(IntPtr ptr)
		{
			return Polyhedron3_EIK_IsPureTriangle(ptr);
		}

		internal override bool IsPureQuad(IntPtr ptr)
		{
			return Polyhedron3_EIK_IsPureQuad(ptr);
		}

		internal override void MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
		{
			Polyhedron3_EIK_MakeTetrahedron(ptr, p1, p2, p3, p4);
		}

		internal override void MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3)
		{
			Polyhedron3_EIK_MakeTriangle(ptr, p1, p2, p3);
		}

		internal override void CreateTriangleMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount)
		{
			Polyhedron3_EIK_CreateTriangleMesh(ptr, points, pointsCount, triangles, triangleCount);
		}

		internal override void CreateQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] quads, int quadCount)
		{
			Polyhedron3_EIK_CreateQuadMesh(ptr, points, pointsCount, quads, quadCount);
		}

		internal override void CreateTriangleQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadCount)
		{
			Polyhedron3_EIK_CreateTriangleQuadMesh(ptr, points, pointsCount, triangles, triangleCount, quads, quadCount);
		}

		internal override void GetPoints(IntPtr ptr, Point3d[] points, int count)
		{
			Polyhedron3_EIK_GetPoints(ptr, points, count);
		}

		internal override PrimativeCount GetPrimativeCount(IntPtr ptr)
		{
			return Polyhedron3_EIK_GetPrimativeCount(ptr);
		}

		internal override void GetTriangleIndices(IntPtr ptr, int[] indices, int count)
		{
			Polyhedron3_EIK_GetTriangleIndices(ptr, indices, count);
		}

		internal override void GetQuadIndices(IntPtr ptr, int[] indices, int count)
		{
			Polyhedron3_EIK_GetQuadIndices(ptr, indices, count);
		}

		internal override void Transform(IntPtr ptr, Matrix4x4d matrix)
		{
			Polyhedron3_EIK_Transform(ptr, matrix);
		}

		internal override void InsideOut(IntPtr ptr)
		{
			Polyhedron3_EIK_InsideOut(ptr);
		}

		internal override void Triangulate(IntPtr ptr)
		{
			Polyhedron3_EIK_Triangulate(ptr);
		}

		internal override void NormalizeBorder(IntPtr ptr)
		{
			Polyhedron3_EIK_NormalizeBorder(ptr);
		}

		internal override bool NormalizedBorderIsValid(IntPtr ptr)
		{
			return Polyhedron3_EIK_NormalizedBorderIsValid(ptr);
		}

		internal override BOUNDED_SIDE SideOfTriangleMesh(IntPtr ptr, Point3d point)
		{
			return Polyhedron3_EIK_SideOfTriangleMesh(ptr, point);
		}

		internal override bool DoesSelfIntersect(IntPtr ptr)
		{
			return Polyhedron3_EIK_DoesSelfIntersect(ptr);
		}

		internal override double Area(IntPtr ptr)
		{
			return Polyhedron3_EIK_Area(ptr);
		}

		internal override Point3d Centroid(IntPtr ptr)
		{
			return Polyhedron3_EIK_Centroid(ptr);
		}

		internal override double Volume(IntPtr ptr)
		{
			return Polyhedron3_EIK_Volume(ptr);
		}

		internal override bool DoesBoundAVolume(IntPtr ptr)
		{
			return Polyhedron3_EIK_DoesBoundAVolume(ptr);
		}

		internal override void BuildAABBTree(IntPtr ptr)
		{
			Polyhedron3_EIK_BuildAABBTree(ptr);
		}

		internal override void ReleaseAABBTree(IntPtr ptr)
		{
			Polyhedron3_EIK_ReleaseAABBTree(ptr);
		}

		internal override bool DoIntersects(IntPtr ptr, IntPtr otherPtr, bool test_bounded_sides)
		{
			return Polyhedron3_EIK_DoIntersects(ptr, otherPtr, test_bounded_sides);
		}

		internal override void ReadOFF(IntPtr ptr, string filename)
		{
			Polyhedron3_EIK_ReadOFF(ptr, filename);
		}

		internal override void WriteOFF(IntPtr ptr, string filename)
		{
			Polyhedron3_EIK_WriteOFF(ptr, filename);
		}

		internal override MinMaxAvg MinMaxEdgeLength(IntPtr ptr)
		{
			return Polyhedron3_EIK_MinMaxEdgeLength(ptr);
		}

		internal override void GetCentroids(IntPtr ptr, Point3d[] points, int count)
		{
			Polyhedron3_EIK_GetCentroids(ptr, points, count);
		}

		internal override void ComputeVertexNormals(IntPtr ptr)
		{
			Polyhedron3_EIK_ComputeVertexNormals(ptr);
		}

		internal override void ComputeFaceNormals(IntPtr ptr)
		{
			Polyhedron3_EIK_ComputeFaceNormals(ptr);
		}

		internal override void GetVertexNormals(IntPtr ptr, Vector3d[] normals, int count)
		{
			Polyhedron3_EIK_GetVertexNormals(ptr, normals, count);
		}

		internal override void GetFaceNormals(IntPtr ptr, Vector3d[] normals, int count)
		{
			Polyhedron3_EIK_GetFaceNormals(ptr, normals, count);
		}

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr Polyhedron3_EIK_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_Clear(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr Polyhedron3_EIK_Copy(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_BuildIndices(IntPtr ptr, bool vertices, bool faces, bool force);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EIK_VertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EIK_FaceCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EIK_HalfEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EIK_BorderEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EIK_BorderHalfEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_IsValid(IntPtr ptr, int level);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_IsClosed(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_IsPureBivalent(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_IsPureTrivalent(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_IsPureTriangle(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_IsPureQuad(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_CreateTriangleMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_CreateQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] quads, int quadCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_CreateTriangleQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_GetPoints(IntPtr ptr, [Out] Point3d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern PrimativeCount Polyhedron3_EIK_GetPrimativeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_GetTriangleIndices(IntPtr ptr, [Out] int[] indices, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_GetQuadIndices(IntPtr ptr, [Out] int[] indices, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_Transform(IntPtr ptr, Matrix4x4d matrix);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_InsideOut(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_Triangulate(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_NormalizeBorder(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_NormalizedBorderIsValid(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern BOUNDED_SIDE Polyhedron3_EIK_SideOfTriangleMesh(IntPtr ptr, Point3d point);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_DoesSelfIntersect(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double Polyhedron3_EIK_Area(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern Point3d Polyhedron3_EIK_Centroid(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double Polyhedron3_EIK_Volume(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_DoesBoundAVolume(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_BuildAABBTree(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_ReleaseAABBTree(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EIK_DoIntersects(IntPtr ptr, IntPtr otherPtr, bool test_bounded_sides);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_ReadOFF(IntPtr ptr, string filename);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_WriteOFF(IntPtr ptr, string filename);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern MinMaxAvg Polyhedron3_EIK_MinMaxEdgeLength(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_GetCentroids(IntPtr ptr, [Out] Point3d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_ComputeVertexNormals(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_ComputeFaceNormals(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_GetVertexNormals(IntPtr ptr, [Out] Vector3d[] normals, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EIK_GetFaceNormals(IntPtr ptr, [Out] Vector3d[] normals, int count);
	}
}
