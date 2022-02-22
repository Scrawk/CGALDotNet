using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class SurfaceSubdivisionKernel_EEK : SurfaceSubdivisionKernel
    {
        internal override string Name => "EEK";

        internal static readonly SurfaceSubdivisionKernel Instance = new SurfaceSubdivisionKernel_EEK();

        internal override IntPtr Create()
        {
            return SurfaceSubdivision_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            SurfaceSubdivision_EEK_Release(ptr);
        }

        //Polyhedron

        internal override void Subdive_CatmullClark_PH(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_Subdive_CatmullClark_PH(polyPtr, iterations);
        }

        internal override void Subdive_Loop_PH(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_Subdive_Loop_PH(polyPtr, iterations);
        }

        internal override void Subdive_Sqrt3_PH(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_Subdive_Sqrt3_PH(polyPtr, iterations);
        }

        //Surface Mesh

        internal override void Subdive_CatmullClark_SM(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_Subdive_CatmullClark_SM(polyPtr, iterations);
        }

        internal override void Subdive_DoSabin_SM(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_Subdive_DoSabin_SM(polyPtr, iterations);
        }

        internal override void Subdive_Loop_SM(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_Subdive_Loop_SM(polyPtr, iterations);
        }

        internal override void Subdive_Sqrt3_SM(IntPtr polyPtr, int iterations)
        {
            SurfaceSubdivision_EEK_Subdive_Sqrt3_SM(polyPtr, iterations);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr SurfaceSubdivision_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Release(IntPtr ptr);

        //Polyhedron

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Subdive_CatmullClark_PH(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Subdive_Loop_PH(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Subdive_Sqrt3_PH(IntPtr polyPtr, int iterations);

        //Surface Mesh

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Subdive_CatmullClark_SM(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Subdive_DoSabin_SM(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Subdive_Loop_SM(IntPtr polyPtr, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceSubdivision_EEK_Subdive_Sqrt3_SM(IntPtr polyPtr, int iterations);
    }
}
