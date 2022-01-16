using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingNormalsKernel_EEK : PolygonMeshProcessingNormalsKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingNormalsKernel Instance = new PolygonMeshProcessingNormalsKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingNormals_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingNormals_EEK_Release(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingNormals_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingNormals_EEK_Release(IntPtr ptr);
    }
}
