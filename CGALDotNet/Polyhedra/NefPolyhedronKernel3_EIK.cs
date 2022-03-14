using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
	internal class NefPolyhedronKernel3_EIK : NefPolyhedronKernel3
	{
		internal override string Name => "EIK";

		internal static readonly NefPolyhedronKernel3 Instance = new NefPolyhedronKernel3_EIK();

		internal override IntPtr CreateFromSpace(NEF_CONTENT space)
		{
			return NefPolyhedron3_EIK_CreateFromSpace(space);
		}

		internal override IntPtr CreateFromPlane(Plane3d plane, NEF_BOUNDARY boundary)
		{
			return NefPolyhedron3_EIK_CreateFromPlane(plane, boundary);
		}

		internal override IntPtr CreateFromPolyhedron(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_CreateFromPolyhedron(ptr);
		}

		internal override void Release(IntPtr ptr)
		{
			NefPolyhedron3_EIK_Release(ptr);
		}

		internal override void Clear(IntPtr ptr, NEF_CONTENT space)
		{
			NefPolyhedron3_EIK_Clear(ptr, space);
		}

		internal override bool IsEmpty(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_IsEmpty(ptr);
		}

		internal override bool IsSimple(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_IsSimple(ptr);
		}

		internal override bool IsSpace(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_IsSpace(ptr);
		}

		internal override bool IsValid(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_IsValid(ptr);
		}

		internal override int EdgeCount(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_EdgeCount(ptr);
		}

		internal override int FacetCount(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_FacetCount(ptr);
		}

		internal override int HalfEdgeCount(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_HalfEdgeCount(ptr);
		}

		internal override int HalfFacetCount(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_HalfFacetCount(ptr);
		}

		internal override int VertexCount(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_VertexCount(ptr);
		}

		internal override int VolumeCount(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_VolumeCount(ptr);
		}

		internal override IntPtr Intersection(IntPtr ptr1, IntPtr ptr2)
		{
			return NefPolyhedron3_EIK_Intersection(ptr1, ptr2);
		}

		internal override IntPtr Join(IntPtr ptr1, IntPtr ptr2)
		{
			return NefPolyhedron3_EIK_Join(ptr1, ptr2);
		}

		internal override IntPtr Difference(IntPtr ptr1, IntPtr ptr2)
		{
			return NefPolyhedron3_EIK_Difference(ptr1, ptr2);
		}

		internal override IntPtr SymmetricDifference(IntPtr ptr1, IntPtr ptr2)
		{
			return NefPolyhedron3_EIK_SymmetricDifference(ptr1, ptr2);
		}

		internal override IntPtr Complement(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_Complement(ptr);
		}

		internal override IntPtr Interior(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_Interior(ptr);
		}

		internal override IntPtr Boundary(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_Boundary(ptr);
		}

		internal override IntPtr Closure(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_Closure(ptr);
		}

		internal override IntPtr Regularization(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_Regularization(ptr);
		}

		internal override IntPtr MinkowskiSum(IntPtr ptr1, IntPtr ptr2)
		{
			return NefPolyhedron3_EIK_MinkowskiSum(ptr1, ptr2);
		}

		internal override IntPtr ConvertToPolyhedron(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_ConvertToPolyhedron(ptr);
		}

		internal override IntPtr ConvertToSurfaceMesh(IntPtr ptr)
		{
			return NefPolyhedron3_EIK_ConvertToSurfaceMesh(ptr);
		}

		internal override void ConvexDecomposition(IntPtr ptr)
		{
			NefPolyhedron3_EIK_ConvexDecomposition(ptr);
		}

		internal override void GetVolumes(IntPtr ptr, IntPtr[] volumes, int count)
		{
			NefPolyhedron3_EIK_GetVolumes(ptr, volumes, count);
		}

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_CreateFromSpace(NEF_CONTENT space);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_CreateFromPlane(Plane3d plane, NEF_BOUNDARY boundary);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_CreateFromPolyhedron(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void NefPolyhedron3_EIK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void NefPolyhedron3_EIK_Clear(IntPtr ptr, NEF_CONTENT space);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool NefPolyhedron3_EIK_IsEmpty(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool NefPolyhedron3_EIK_IsSimple(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool NefPolyhedron3_EIK_IsSpace(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool NefPolyhedron3_EIK_IsValid(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EIK_EdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EIK_FacetCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EIK_HalfEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EIK_HalfFacetCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EIK_VertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EIK_VolumeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_Intersection(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_Join(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_Difference(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_SymmetricDifference(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_Complement(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_Interior(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_Boundary(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_Closure(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_Regularization(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_MinkowskiSum(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_ConvertToPolyhedron(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EIK_ConvertToSurfaceMesh(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void NefPolyhedron3_EIK_ConvexDecomposition(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void NefPolyhedron3_EIK_GetVolumes(IntPtr ptr, [Out] IntPtr[] volumes, int count);

	}
}
