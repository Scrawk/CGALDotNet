using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class SurfaceSubdivisionKernel_EIK : SurfaceSubdivisionKernel
    {
        internal static readonly SurfaceSubdivisionKernel Instance = new SurfaceSubdivisionKernel_EIK();

        internal override IntPtr Create()
        {
            return SurfaceSubdivision_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SurfaceSubdivision_EIK_Release(ptr);
        }

        internal override void SubdivePolyhedron_CatmullClark(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EIK_SubdivePolyhedron_CatmullClark(polyPtr, iterations);
        }

        internal override void SubdivePolyhedron_Loop(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EIK_SubdivePolyhedron_Loop(polyPtr, iterations);
        }

        internal override void SubdivePolyhedron_Sqrt3(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EIK_SubdivePolyhedron_Sqrt3(polyPtr, iterations);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceSubdivision_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EIK_SubdivePolyhedron_CatmullClark(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EIK_SubdivePolyhedron_Loop(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EIK_SubdivePolyhedron_Sqrt3(IntPtr polyPtr, int iterations);
    }
}
