using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
	internal class PolyhedronKernel3_EEK : PolyhedronKernel3
	{

		internal static readonly PolyhedronKernel3 Instance = new PolyhedronKernel3_EEK();

		internal override IntPtr Create()
        {
			return Polyhedron3_EEK_Create();
		}

		internal override IntPtr CreateFromSize(int vertices, int halfedges, int faces)
        {
			return Polyhedron3_EEK_CreateFromSize(vertices, halfedges, faces);
		}

		internal override void Release(IntPtr ptr)
        {
			Polyhedron3_EEK_Release(ptr);
		}

		internal override void Clear(IntPtr ptr)
        {
			Polyhedron3_EEK_Clear(ptr);
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

		internal override int IsPureTriangle(IntPtr ptr)
        {
			return Polyhedron3_EEK_IsPureTriangle(ptr);
		}

		internal override int IsPureQuad(IntPtr ptr)
        {
			return Polyhedron3_EEK_IsPureQuad(ptr);
		}

		internal override void MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4)
		{
			Polyhedron3_EEK_MakeTetrahedron(ptr, p1, p2, p3, p4);
		}

		internal override void MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3)
		{
			Polyhedron3_EEK_MakeTriangle(ptr, p1, p2, p3);
		}

		internal override void CreateTriangleMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount)
        {
			Polyhedron3_EEK_CreateTriangleMesh(ptr, points, pointsCount, triangles, triangleCount);
        }

		internal override void CreateQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] quads, int quadCount)
		{
			Polyhedron3_EEK_CreateQuadMesh(ptr, points, pointsCount, quads, quadCount);
		}

		internal override void CreateTriangleQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadCount)
        {
			Polyhedron3_EEK_CreateTriangleQuadMesh(ptr, points, pointsCount, triangles, triangleCount, quads, quadCount);
        }

		internal override void GetPoints(IntPtr ptr, Point3d[] points, int count)
        {
			Polyhedron3_EEK_GetPoints(ptr, points, count);
        }

		internal override PrimativeCount GetPrimativeCount(IntPtr ptr)
        {
			return Polyhedron3_EEK_GetPrimativeCount(ptr);
        }

		internal override void GetTriangleIndices(IntPtr ptr, int[] indices, int count)
        {
			Polyhedron3_EEK_GetTriangleIndices(ptr, indices, count);
        }

		internal override void GetQuadIndices(IntPtr ptr, int[] indices, int count)
		{
			Polyhedron3_EEK_GetQuadIndices(ptr, indices, count);
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

		internal override void Orient(IntPtr ptr)
        {
			Polyhedron3_EEK_Orient(ptr);
        }

		internal override void OrientToBoundingVolume(IntPtr ptr)
        {
			Polyhedron3_EEK_OrientToBoundingVolume(ptr);
        }

		internal override void ReverseFaceOrientations(IntPtr ptr)
        {
			Polyhedron3_EEK_ReverseFaceOrientations(ptr);
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

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr Polyhedron3_EEK_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr Polyhedron3_EEK_CreateFromSize(int vertices, int halfedges, int faces);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  void Polyhedron3_EEK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  void Polyhedron3_EEK_Clear(IntPtr ptr);

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
		private static extern int Polyhedron3_EEK_IsPureTriangle(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_IsPureQuad(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_MakeTetrahedron(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3, Point3d p4);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_MakeTriangle(IntPtr ptr, Point3d p1, Point3d p2, Point3d p3);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_CreateTriangleMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_CreateQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] quads, int quadCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_CreateTriangleQuadMesh(IntPtr ptr, Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadCount);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetPoints(IntPtr ptr, [Out] Point3d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern PrimativeCount Polyhedron3_EEK_GetPrimativeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetTriangleIndices(IntPtr ptr, [Out] int[] indices, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_GetQuadIndices(IntPtr ptr, [Out] int[] indices, int count);

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
		private static extern void Polyhedron3_EEK_Orient(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_OrientToBoundingVolume(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void Polyhedron3_EEK_ReverseFaceOrientations(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_DoesSelfIntersect(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double Polyhedron3_EEK_Area(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern Point3d Polyhedron3_EEK_Centroid(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double Polyhedron3_EEK_Volume(IntPtr ptr);
	}
}
