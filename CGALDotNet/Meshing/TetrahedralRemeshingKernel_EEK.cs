using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Meshing
{
    internal class TetrahedralRemeshingKernel_EEK : TetrahedralRemeshingKernel
	{
		internal override string Name => "EEK";

		internal static readonly TetrahedralRemeshingKernel Instance = new TetrahedralRemeshingKernel_EEK();

		internal override IntPtr Create()
		{
			return TetrahedralRemeshing_EEK_Create();
		}

		internal override void Release(IntPtr ptr)
		{
			TetrahedralRemeshing_EEK_Release(ptr);
		}

		internal override void GetPoints(IntPtr ptr, Point3d[] points, int count)
        {
			TetrahedralRemeshing_EEK_GetPoints(ptr, points, count);
        }

		internal override int Remesh(IntPtr ptr, double targetLength, int iterations, Point3d[] points, int count)
        {
			return TetrahedralRemeshing_EEK_Remesh(ptr, targetLength, iterations, points, count);
		}

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr TetrahedralRemeshing_EEK_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void TetrahedralRemeshing_EEK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void TetrahedralRemeshing_EEK_GetPoints(IntPtr ptr, [Out] Point3d[] points, int count);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int TetrahedralRemeshing_EEK_Remesh(IntPtr ptr, double targetLength, int iterations, Point3d[] points, int count);

	}
}
