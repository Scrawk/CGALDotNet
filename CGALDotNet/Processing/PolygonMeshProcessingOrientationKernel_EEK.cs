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

        internal override bool DoesBoundAVolume(IntPtr polyPtr)
        {
            return PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume(polyPtr);
        }

        internal override bool IsOutwardOriented(IntPtr polyPtr)
        {
            return PolygonMeshProcessingOrientation_EEK_IsOutwardOriented(polyPtr);
        }

        internal override void Orient(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_Orient(polyPtr);
        }

        internal override void OrientToBoundAVolume(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume(polyPtr);
        }

        internal override void ReverseFaceOrientations(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations(polyPtr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingOrientation_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingOrientation_EEK_IsOutwardOriented(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_Orient(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations(IntPtr polyPtr);
    }
}
