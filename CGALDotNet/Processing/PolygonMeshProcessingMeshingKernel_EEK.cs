using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingMeshingKernel_EEK : PolygonMeshProcessingMeshingKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingMeshingKernel Instance = new PolygonMeshProcessingMeshingKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingMeshing_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingMeshing_EEK_Release(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingMeshing_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingMeshing_EEK_Release(IntPtr ptr);
    }
}
