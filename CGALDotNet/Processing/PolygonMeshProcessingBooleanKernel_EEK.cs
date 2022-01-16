using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingBooleanKernel_EEK : PolygonMeshProcessingBooleanKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingBooleanKernel Instance = new PolygonMeshProcessingBooleanKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingBoolean_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingBoolean_EEK_Release(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingBoolean_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingBoolean_EEK_Release(IntPtr ptr);
    }
}
