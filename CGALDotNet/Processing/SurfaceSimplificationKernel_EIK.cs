using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class SurfaceSimplificationKernel_EIK : SurfaceSimplificationKernel
    {

        internal static readonly SurfaceSimplificationKernel Instance = new SurfaceSimplificationKernel_EIK();

        internal override IntPtr Create()
        {
            return SurfaceSimplification_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SurfaceSimplification_EIK_Release(ptr);
        }

        internal override void SimplifyPolyhedron(IntPtr polyPtr, double stop_ratio)
        {
            SurfaceSimplification_EIK_SimplifyPolyhedron(polyPtr, stop_ratio);    
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceSimplification_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSimplification_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSimplification_EIK_SimplifyPolyhedron(IntPtr polyPtr, double stop_ratio);
    }
}
