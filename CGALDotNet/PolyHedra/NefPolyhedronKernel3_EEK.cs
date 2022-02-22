using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
	internal class NefPolyhedronKernel3_EEK : NefPolyhedronKernel3
	{
		internal override string Name => "EEK";

		internal static readonly NefPolyhedronKernel3 Instance = new NefPolyhedronKernel3_EEK();

		internal override IntPtr CreateFromSpace(NEF_CONTENT space)
        {
			return NefPolyhedron3_EEK_CreateFromSpace(space);
        }

		internal override IntPtr CreateFromPlane(Plane3d plane, NEF_BOUNDARY boundary)
        {
			return NefPolyhedron3_EEK_CreateFromPlane(plane, boundary);
		}

		internal override IntPtr CreateFromPolyhedron(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_CreateFromPolyhedron(ptr);
        }

		internal override void Release(IntPtr ptr)
        {
			NefPolyhedron3_EEK_Release(ptr);
        }

		internal override void Clear(IntPtr ptr, NEF_CONTENT space)
        {
			NefPolyhedron3_EEK_Clear(ptr, space);
        }

		internal override bool IsEmpty(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_IsEmpty(ptr);
        }

		internal override bool IsSimple(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_IsSimple(ptr);
        }

		internal override bool IsSpace(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_IsSpace(ptr);
        }

		internal override bool IsValid(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_IsValid(ptr);
        }

		internal override int EdgeCount(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_EdgeCount(ptr);
        }

		internal override int FacetCount(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_FacetCount(ptr);
        }

		internal override int HalfEdgeCount(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_HalfEdgeCount(ptr);
        }

		internal override int HalfFacetCount(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_HalfFacetCount(ptr);
        }

		internal override int VertexCount(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_VertexCount(ptr);
        }

		internal override int VolumeCount(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_VolumeCount(ptr);
        }

		internal override IntPtr Intersection(IntPtr ptr1, IntPtr ptr2)
        {
			return NefPolyhedron3_EEK_Intersection(ptr1, ptr2);
        }

		internal override IntPtr Join(IntPtr ptr1, IntPtr ptr2)
        {
			return NefPolyhedron3_EEK_Join(ptr1, ptr2);
        }

		internal override IntPtr Difference(IntPtr ptr1, IntPtr ptr2)
        {
			return NefPolyhedron3_EEK_Difference(ptr1, ptr2);
        }

		internal override IntPtr SymmetricDifference(IntPtr ptr1, IntPtr ptr2)
        {
			return NefPolyhedron3_EEK_SymmetricDifference(ptr1, ptr2);
        }

		internal override IntPtr Complement(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_Complement(ptr);
        }

		internal override IntPtr Interior(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_Interior(ptr);
        }

		internal override IntPtr Boundary(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_Boundary(ptr);
        }

		internal override IntPtr Closure(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_Closure(ptr);
        }

		internal override IntPtr Regularization(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_Regularization(ptr);
        }

		internal override IntPtr MinkowskiSum(IntPtr ptr1, IntPtr ptr2)
        {
			return NefPolyhedron3_EEK_MinkowskiSum(ptr1, ptr2);
        }

		internal override IntPtr ConvertToPolyhedron(IntPtr ptr)
        {
			return NefPolyhedron3_EEK_ConvertToPolyhedron(ptr);
        }

		internal override IntPtr ConvertToSurfaceMesh(IntPtr ptr)
		{
			return NefPolyhedron3_EEK_ConvertToSurfaceMesh(ptr);
		}

		internal override void ConvexDecomposition(IntPtr ptr)
        {
			NefPolyhedron3_EEK_ConvexDecomposition(ptr);
        }

		internal override void GetVolumes(IntPtr ptr, IntPtr[] volumes, int count)
        {
			NefPolyhedron3_EEK_GetVolumes(ptr, volumes, count);
        }

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_CreateFromSpace(NEF_CONTENT space);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_CreateFromPlane(Plane3d plane, NEF_BOUNDARY boundary);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_CreateFromPolyhedron(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void NefPolyhedron3_EEK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void NefPolyhedron3_EEK_Clear(IntPtr ptr, NEF_CONTENT space);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool NefPolyhedron3_EEK_IsEmpty(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool NefPolyhedron3_EEK_IsSimple(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool NefPolyhedron3_EEK_IsSpace(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool NefPolyhedron3_EEK_IsValid(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EEK_EdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EEK_FacetCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EEK_HalfEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EEK_HalfFacetCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EEK_VertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int NefPolyhedron3_EEK_VolumeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_Intersection(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_Join(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_Difference(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_SymmetricDifference(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_Complement(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_Interior(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_Boundary(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_Closure(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_Regularization(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_MinkowskiSum(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_ConvertToPolyhedron(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr NefPolyhedron3_EEK_ConvertToSurfaceMesh(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void NefPolyhedron3_EEK_ConvexDecomposition(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void NefPolyhedron3_EEK_GetVolumes(IntPtr ptr, [Out] IntPtr[] volumes, int count);

	}
}
