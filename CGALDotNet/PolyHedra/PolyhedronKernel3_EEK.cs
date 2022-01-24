using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
	internal class PolyhedronKernel3_EEK : PolyhedronKernel3
	{
		internal override string KernelName => "EEK";

		internal static readonly PolyhedronKernel3 Instance = new PolyhedronKernel3_EEK();

		internal override IntPtr Create()
		{
			return Polyhedron3_EEK_Create();
		}

		internal override void Release(IntPtr ptr)
		{
			Polyhedron3_EEK_Release(ptr);
		}

		internal override void Clear(IntPtr ptr)
		{
			Polyhedron3_EEK_Clear(ptr);
		}

		internal override void ClearIndexMaps(IntPtr ptr)
        {
			Polyhedron3_EEK_ClearIndexMaps(ptr);
		}

		internal override void ClearNormalMaps(IntPtr ptr)
        {
			Polyhedron3_EEK_ClearNormalMaps(ptr);
		}

		internal override IntPtr Copy(IntPtr ptr)
		{
			return Polyhedron3_EEK_Copy(ptr);
		}

		internal override void BuildIndices(IntPtr ptr, bool vertices, bool faces, bool force)
        {
			Polyhedron3_EEK_BuildIndices(ptr, vertices, faces, force);
        }

		internal override int VertexCount(IntPtr ptr)
		{
			return Polyhedron3_EEK_VertexCount(ptr);
		}

		internal override int FaceCount(IntPtr ptr)
		{
			return Polyhedron3_EEK_FaceCount(ptr);
		}

		internal override int HalfEdgeCount(IntPtr ptr)
		{
			return Polyhedron3_EEK_HalfEdgeCount(ptr);
		}

		internal override int BorderEdgeCount(IntPtr ptr)
		{
			return Polyhedron3_EEK_BorderEdgeCount(ptr);
		}

		internal override int BorderHalfEdgeCount(IntPtr ptr)
		{
			return Polyhedron3_EEK_BorderHalfEdgeCount(ptr);
		}

		internal override bool IsValid(IntPtr ptr, int level)
		{
			return Polyhedron3_EEK_IsValid(ptr, level);
		}

		internal override bool IsClosed(IntPtr ptr)
		{
			return Polyhedron3_EEK_IsClosed(ptr);
		}

		internal override bool IsPureBivalent(IntPtr ptr)
		{
			return Polyhedron3_EEK_IsPureBivalent(ptr);
		}

		internal override bool IsPureTrivalent(IntPtr ptr)
		{
			return Polyhedron3_EEK_IsPureTrivalent(ptr);
		}

		internal override bool IsPureTriangle(IntPtr ptr)
		{
			return Polyhedron3_EEK_IsPureTriangle(ptr);
		}

		internal override bool IsPureQuad(IntPtr ptr)
		{
			return Polyhedron3_EEK_IsPureQuad(ptr);
		}

		internal override Box3d GetBoundingBox(IntPtr ptr)
        {
			return Polyhedron3_EEK_GetBoundingBox(ptr);
        }

		internal override void MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
		{
			Polyhedron3_EEK_MakeTetrahedron(ptr, p1, p2, p3, p4);
		}

		internal override void MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3)
		{
			Polyhedron3_EEK_MakeTriangle(ptr, p1, p2, p3);
		}

		internal override void GetPoints(IntPtr ptr, Point3d[] points, int count)
		{
			Polyhedron3_EEK_GetPoints(ptr, points, count);
		}

		internal override void Transform(IntPtr ptr, Matrix4x4d matrix)
		{
			Polyhedron3_EEK_Transform(ptr, matrix);
		}

		internal override void InsideOut(IntPtr ptr)
		{
			Polyhedron3_EEK_InsideOut(ptr);
		}

		internal override void Triangulate(IntPtr ptr)
		{
			Polyhedron3_EEK_Triangulate(ptr);
		}

		internal override void NormalizeBorder(IntPtr ptr)
		{
			Polyhedron3_EEK_NormalizeBorder(ptr);
		}

		internal override bool NormalizedBorderIsValid(IntPtr ptr)
		{
			return Polyhedron3_EEK_NormalizedBorderIsValid(ptr);
		}

		internal override BOUNDED_SIDE SideOfTriangleMesh(IntPtr ptr, Point3d point)
		{
			return Polyhedron3_EEK_SideOfTriangleMesh(ptr, point);
		}

		internal override bool DoesSelfIntersect(IntPtr ptr)
		{
			return Polyhedron3_EEK_DoesSelfIntersect(ptr);
		}

		internal override double Area(IntPtr ptr)
		{
			return Polyhedron3_EEK_Area(ptr);
		}

		internal override Point3d Centroid(IntPtr ptr)
		{
			return Polyhedron3_EEK_Centroid(ptr);
		}

		internal override double Volume(IntPtr ptr)
		{
			return Polyhedron3_EEK_Volume(ptr);
		}

		internal override bool DoesBoundAVolume(IntPtr ptr)
		{
			return Polyhedron3_EEK_DoesBoundAVolume(ptr);
		}

		internal override void BuildAABBTree(IntPtr ptr)
		{
			Polyhedron3_EEK_BuildAABBTree(ptr);
		}

		internal override void ReleaseAABBTree(IntPtr ptr)
		{
			Polyhedron3_EEK_ReleaseAABBTree(ptr);
		}

		internal override bool DoIntersects(IntPtr ptr, IntPtr otherPtr, bool test_bounded_sides)
		{
			return Polyhedron3_EEK_DoIntersects(ptr, otherPtr, test_bounded_sides);
		}

		internal override void ReadOFF(IntPtr ptr, string filename)
		{
			Polyhedron3_EEK_ReadOFF(ptr, filename);
		}

		internal override void WriteOFF(IntPtr ptr, string filename)
		{
			Polyhedron3_EEK_WriteOFF(ptr, filename);
		}

		internal override MinMaxAvg MinMaxEdgeLength(IntPtr ptr)
		{
			return Polyhedron3_EEK_MinMaxEdgeLength(ptr);
		}

		internal override void GetCentroids(IntPtr ptr, Point3d[] points, int count)
        {
			Polyhedron3_EEK_GetCentroids(ptr, points, count);
		}

		internal override void ComputeVertexNormals(IntPtr ptr)
        {
			Polyhedron3_EEK_ComputeVertexNormals(ptr);
		}

		internal override void ComputeFaceNormals(IntPtr ptr)
        {
			Polyhedron3_EEK_ComputeFaceNormals(ptr);
		}

		internal override void GetVertexNormals(IntPtr ptr, Vector3d[] normals, int count)
        {
			Polyhedron3_EEK_GetVertexNormals(ptr, normals, count);
		}

		internal override void GetFaceNormals(IntPtr ptr, Vector3d[] normals, int count)
        {
			Polyhedron3_EEK_GetFaceNormals(ptr, normals, count);
		}

		internal override void CreatePolygonMesh(IntPtr ptr, Point2d[] points, int pointsCount, bool xz)
        {
			Polyhedron3_EEK_CreatePolygonMesh(ptr, points, pointsCount, xz);	
        }

		internal override FaceVertexCount GetFaceVertexCount(IntPtr ptr)
        {
			return Polyhedron3_EEK_GetFaceVertexCount(ptr);
        }

		internal override void CreatePolygonalMesh(IntPtr ptr,
			Point3d[] points, int pointsCount,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount)
        {
			Polyhedron3_EEK_CreatePolygonalMesh(ptr, 
				points, pointsCount, 
				triangles, triangleCount, 
				quads, quadCount, pentagons, 
				pentagonCount, 
				hexagons, hexagonCount);
        }

		internal override void GetPolygonalIndices(IntPtr ptr,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount)
        {
			Polyhedron3_EEK_GetPolygonalIndices(ptr, 
				triangles, triangleCount, 
				quads, quadCount, 
				pentagons, pentagonCount, 
				hexagons, hexagonCount);
        }

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr Polyhedron3_EEK_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  void Polyhedron3_EEK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  void Polyhedron3_EEK_Clear(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ClearIndexMaps(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ClearNormalMaps(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr Polyhedron3_EEK_Copy(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_BuildIndices(IntPtr ptr, bool vertices, bool faces, bool force);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_VertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  int Polyhedron3_EEK_FaceCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_HalfEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_BorderEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_BorderHalfEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsValid(IntPtr ptr, int level);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsClosed(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsPureBivalent(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsPureTrivalent(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsPureTriangle(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsPureQuad(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern Box3d Polyhedron3_EEK_GetBoundingBox(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetPoints(IntPtr ptr, [Out] Point3d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_Transform(IntPtr ptr, Matrix4x4d matrix);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_InsideOut(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_Triangulate(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_NormalizeBorder(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_NormalizedBorderIsValid(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern BOUNDED_SIDE Polyhedron3_EEK_SideOfTriangleMesh(IntPtr ptr, Point3d point);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_DoesSelfIntersect(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double Polyhedron3_EEK_Area(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern Point3d Polyhedron3_EEK_Centroid(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double Polyhedron3_EEK_Volume(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_DoesBoundAVolume(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_BuildAABBTree(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ReleaseAABBTree(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_DoIntersects(IntPtr ptr, IntPtr otherPtr, bool test_bounded_sides);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ReadOFF(IntPtr ptr, string filename);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_WriteOFF(IntPtr ptr, string filename);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern MinMaxAvg Polyhedron3_EEK_MinMaxEdgeLength(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetCentroids(IntPtr ptr, [Out] Point3d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ComputeVertexNormals(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ComputeFaceNormals(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetVertexNormals(IntPtr ptr, [Out] Vector3d[] normals, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetFaceNormals(IntPtr ptr, [Out] Vector3d[] normals, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_CreatePolygonMesh(IntPtr ptr, Point2d[] points, int pointsCount, bool xz);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern FaceVertexCount Polyhedron3_EEK_GetFaceVertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_CreatePolygonalMesh(IntPtr ptr,
			Point3d[] points, int pointsCount,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetPolygonalIndices(IntPtr ptr,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount);
	}
}
