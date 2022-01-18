using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingConnectedKernel_EEK : PolygonMeshProcessingConnectedKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingConnectedKernel Instance = new PolygonMeshProcessingConnectedKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingConnected_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingConnected_EEK_Release(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingConnected_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingConnected_EEK_Release(IntPtr ptr);
    }
}
