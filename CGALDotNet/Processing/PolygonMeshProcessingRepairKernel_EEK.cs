using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingRepairKernel_EEK : PolygonMeshProcessingRepairKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingRepairKernel Instance = new PolygonMeshProcessingRepairKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingRepair_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingRepair_EEK_Release(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingRepair_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingRepair_EEK_Release(IntPtr ptr);
    }
}
