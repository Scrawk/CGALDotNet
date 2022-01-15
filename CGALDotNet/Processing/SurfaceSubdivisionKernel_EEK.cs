using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class SurfaceSubdivisionKernel_EEK : SurfaceSubdivisionKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly SurfaceSubdivisionKernel Instance = new SurfaceSubdivisionKernel_EEK();

        internal override IntPtr Create()
        {
            return SurfaceSubdivision_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SurfaceSubdivision_EEK_Release(ptr);
        }

        internal override void SubdivePolyhedron_CatmullClark(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_SubdivePolyhedron_CatmullClark(polyPtr, iterations);
        }

        internal override void SubdivePolyhedron_Loop(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_SubdivePolyhedron_Loop(polyPtr, iterations);
        }

        internal override void SubdivePolyhedron_Sqrt3(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_SubdivePolyhedron_Sqrt3(polyPtr, iterations);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceSubdivision_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_SubdivePolyhedron_CatmullClark(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_SubdivePolyhedron_Loop(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_SubdivePolyhedron_Sqrt3(IntPtr polyPtr, int iterations);
    }
}
