using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class SurfaceSimplificationKernel_EIK : SurfaceSimplificationKernel
    {
        internal override string Name => "EIK";

        internal static readonly SurfaceSimplificationKernel Instance = new SurfaceSimplificationKernel_EIK();

        internal override IntPtr Create()
        {
            return SurfaceSimplification_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SurfaceSimplification_EIK_Release(ptr);
        }

        internal override void Simplify_PH(IntPtr meshPtr, double stop_ratio)
        {
            SurfaceSimplification_EIK_Simplify_PH(meshPtr, stop_ratio);    
        }

        internal override void Simplify_SM(IntPtr meshPtr, double stop_ratio)
        {
            SurfaceSimplification_EIK_Simplify_SM(meshPtr, stop_ratio);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceSimplification_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSimplification_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSimplification_EIK_Simplify_PH(IntPtr meshPtr, double stop_ratio);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSimplification_EIK_Simplify_SM(IntPtr meshPtr, double stop_ratio);
    }
}
