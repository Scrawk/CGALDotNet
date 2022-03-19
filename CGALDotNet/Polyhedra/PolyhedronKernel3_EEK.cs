using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
	internal class PolyhedronKernel3_EEK : PolyhedronKernel3
	{
		internal override string Name => "EEK";

		internal static readonly PolyhedronKernel3 Instance = new PolyhedronKernel3_EEK();

		internal override IntPtr Create()
		{
			return Polyhedron3_EEK_Create();
		}

		internal override void Release(IntPtr ptr)
		{
			Polyhedron3_EEK_Release(ptr);
		}

		internal override int GetBuildStamp(IntPtr ptr)
		{
			return Polyhedron3_EEK_GetBuildStamp(ptr);
		}

		internal override void Clear(IntPtr ptr)
		{
			Polyhedron3_EEK_Clear(ptr);
		}

		internal override void ClearIndexMaps(IntPtr ptr, bool vertices, bool faces, bool edges)
		{
			Polyhedron3_EEK_ClearIndexMaps(ptr, vertices, faces, edges);
		}

		internal override void ClearNormalMaps(IntPtr ptr, bool vertices, bool faces)
		{
			Polyhedron3_EEK_ClearNormalMaps(ptr, vertices, faces);
		}

		internal override void BuildIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool force)
		{
			Polyhedron3_EEK_BuildIndices(ptr, vertices, faces, edges, force);
		}

		internal override IntPtr Copy(IntPtr ptr)
		{
			return Polyhedron3_EEK_Copy(ptr);
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

		internal override int MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
		{
			return Polyhedron3_EEK_MakeTetrahedron(ptr, p1, p2, p3, p4);
		}

		internal override int MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3)
		{
			return Polyhedron3_EEK_MakeTriangle(ptr, p1, p2, p3);
		}

		internal override Point3d GetPoint(IntPtr ptr, int index)
        {
			return Polyhedron3_EEK_GetPoint(ptr, index);
        }

		internal override void GetPoints(IntPtr ptr, Point3d[] points, int count)
		{
			Polyhedron3_EEK_GetPoints(ptr, points, count);
		}

		internal override void SetPoint(IntPtr ptr, int index, Point3d point)
        {
			Polyhedron3_EEK_SetPoint(ptr, index, point);
        }

		internal override void SetPoints(IntPtr ptr, Point3d[] points, int count)
        {
			Polyhedron3_EEK_SetPoints(ptr, points, count);
        }

		internal override bool GetSegment(IntPtr ptr, int index, out Segment3d segment)
        {
			return Polyhedron3_EEK_GetSegment(ptr, index, out segment);
        }

		internal override bool GetTriangle(IntPtr ptr, int index, out Triangle3d tri)
        {
			return Polyhedron3_EEK_GetTriangle(ptr, index, out tri);
        }

		internal override bool GetVertex(IntPtr ptr, int index, out MeshVertex3 vert)
        {
			return Polyhedron3_EEK_GetVertex(ptr, index, out vert);
        }

		internal override bool GetFace(IntPtr ptr, int index, out MeshFace3 face)
        {
			return Polyhedron3_EEK_GetFace(ptr, index, out face);
		}

		internal override bool GetHalfedge(IntPtr ptr, int index, out MeshHalfedge3 edge)
        {
			return Polyhedron3_EEK_GetHalfedge(ptr, index, out edge);
		}

		internal override void GetSegments(IntPtr ptr, Segment3d[] segments, int count)
        {
			Polyhedron3_EEK_GetSegments(ptr, segments, count);
        }

		internal override void GetTriangles(IntPtr ptr, Triangle3d[] triangles, int count)
        {
			Polyhedron3_EEK_GetTriangles(ptr, triangles, count);
        }

		internal override void GetVertices(IntPtr ptr, MeshVertex3[] vertices, int count)
        {
			Polyhedron3_EEK_GetVertices(ptr, vertices, count);
		}

		internal override void GetFaces(IntPtr ptr, MeshFace3[] faces, int count)
        {
			Polyhedron3_EEK_GetFaces(ptr, faces, count);
		}

		internal override void GetHalfedges(IntPtr ptr, MeshHalfedge3[] edges, int count)
        {
			Polyhedron3_EEK_GetHalfedges(ptr, edges, count);
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

		internal override PolygonalCount GetPolygonalCount(IntPtr ptr)
		{
			return Polyhedron3_EEK_GetPolygonalCount(ptr);
		}

		internal override PolygonalCount GetDualPolygonalCount(IntPtr ptr)
		{
			return Polyhedron3_EEK_GetDualPolygonalCount(ptr);
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

		internal override void GetDualPolygonalIndices(IntPtr ptr,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount)
		{
			Polyhedron3_EEK_GetDualPolygonalIndices(ptr,
				triangles, triangleCount,
				quads, quadCount,
				pentagons, pentagonCount,
				hexagons, hexagonCount);
		}

		internal override int AddFacetToBorder(IntPtr ptr, int h, int g)
        {
			return Polyhedron3_EEK_AddFacetToBorder(ptr, h, g);
        }

		internal override int AddVertexAndFacetToBorder(IntPtr ptr, int h, int g)
        {
			return Polyhedron3_EEK_AddVertexAndFacetToBorder(ptr, h, g);

		}

		internal override int CreateCenterVertex(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_CreateCenterVertex(ptr, h);
        }

		internal override int EraseCenterVertex(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_EraseCenterVertex(ptr, h);
        }

		internal override bool EraseConnectedComponent(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_EraseConnectedComponent(ptr, h);
        }

		internal override bool EraseFacet(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_EraseFacet(ptr, h);	
        }

		internal override int FillHole(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_FillHole(ptr, h);	
        }

		internal override int FlipEdge(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_FlipEdge(ptr, h);
        }

		internal override int JoinFacet(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_JoinFacet(ptr, h);	
        }

		internal override int JoinLoop(IntPtr ptr, int h, int g)
        {
			return Polyhedron3_EEK_JoinLoop(ptr, h, g);	
        }

		internal override int JoinVertex(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_JoinVertex(ptr, h);
        }

		internal override int MakeHole(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_MakeHole(ptr, h);	
        }

		internal override int SplitEdge(IntPtr ptr, int h)
        {
			return Polyhedron3_EEK_SplitEdge(ptr, h);	
        }

		internal override int SplitFacet(IntPtr ptr, int h, int g)
        {
			return Polyhedron3_EEK_SplitFacet(ptr, h, g);	
        }

		internal override int SplitLoop(IntPtr ptr, int h, int g, int k)
        {
			return Polyhedron3_EEK_SplitLoop(ptr, h, g, k);
        }

		internal override int SplitVertex(IntPtr ptr, int h, int g)
        {
			return Polyhedron3_EEK_SplitVertex(ptr, h, g);
        }

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr Polyhedron3_EEK_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_GetBuildStamp(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_Clear(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ClearIndexMaps(IntPtr ptr, bool vertices, bool faces, bool edges);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ClearNormalMaps(IntPtr ptr, bool vertices, bool faces);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_BuildIndices(IntPtr ptr, bool vertices, bool faces, bool edges, bool force);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr Polyhedron3_EEK_Copy(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_VertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_FaceCount(IntPtr ptr);

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
		private static extern int Polyhedron3_EEK_MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern Point3d Polyhedron3_EEK_GetPoint(IntPtr ptr, int index);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetPoints(IntPtr ptr, [Out] Point3d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_SetPoint(IntPtr ptr, int index, Point3d point);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_SetPoints(IntPtr ptr, Point3d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_GetSegment(IntPtr ptr, int index, [Out] out Segment3d segment);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_GetTriangle(IntPtr ptr, int index, [Out] out Triangle3d tri);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_GetVertex(IntPtr ptr, int index, [Out] out MeshVertex3 vert);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_GetFace(IntPtr ptr, int index, [Out] out MeshFace3 face);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_GetHalfedge(IntPtr ptr, int index, [Out] out MeshHalfedge3 edge);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetSegments(IntPtr ptr, [Out] Segment3d[] segments, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetTriangles(IntPtr ptr, [Out] Triangle3d[] triangles, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetVertices(IntPtr ptr, [Out] MeshVertex3[] vertices, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetFaces(IntPtr ptr, [Out] MeshFace3[] faces, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetHalfedges(IntPtr ptr, [Out] MeshHalfedge3[] edges, int count);

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
		private static extern PolygonalCount Polyhedron3_EEK_GetPolygonalCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern PolygonalCount Polyhedron3_EEK_GetDualPolygonalCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_CreatePolygonalMesh(IntPtr ptr,
			Point3d[] points, int pointsCount,
			int[] triangles, int triangleCount,
			int[] quads, int quadCount,
			int[] pentagons, int pentagonCount,
			int[] hexagons, int hexagonCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetPolygonalIndices(IntPtr ptr,
			[Out] int[] triangles, int triangleCount,
			[Out] int[] quads, int quadCount,
			[Out] int[] pentagons, int pentagonCount,
			[Out] int[] hexagons, int hexagonCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetDualPolygonalIndices(IntPtr ptr,
			[Out] int[] triangles, int triangleCount,
			[Out] int[] quads, int quadCount,
			[Out] int[] pentagons, int pentagonCount,
			[Out] int[] hexagons, int hexagonCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_AddFacetToBorder(IntPtr ptr, int h, int g);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_AddVertexAndFacetToBorder(IntPtr ptr, int h, int g);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_CreateCenterVertex(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_EraseCenterVertex(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_EraseConnectedComponent(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_EraseFacet(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_FillHole(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_FlipEdge(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_JoinFacet(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_JoinLoop(IntPtr ptr, int h, int g);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_JoinVertex(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_MakeHole(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_SplitEdge(IntPtr ptr, int h);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_SplitFacet(IntPtr ptr, int h, int g);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_SplitLoop(IntPtr ptr, int h, int g, int k);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_SplitVertex(IntPtr ptr, int h, int g);
	}
}
