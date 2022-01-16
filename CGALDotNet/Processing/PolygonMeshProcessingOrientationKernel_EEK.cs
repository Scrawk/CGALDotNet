using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingOrientationKernel_EEK : PolygonMeshProcessingOrientationKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingOrientationKernel Instance = new PolygonMeshProcessingOrientationKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingOrientation_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingOrientation_EEK_Release(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingOrientation_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_Release(IntPtr ptr);
    }
}
