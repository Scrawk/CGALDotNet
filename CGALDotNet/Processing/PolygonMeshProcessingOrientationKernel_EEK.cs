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

        //Polyhedron

        internal override bool DoesBoundAVolume_PH(IntPtr polyPtr)
        {
            return PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume_PH(polyPtr);
        }

        internal override bool IsOutwardOriented_PH(IntPtr polyPtr)
        {
            return PolygonMeshProcessingOrientation_EEK_IsOutwardOriented_PH(polyPtr);
        }

        internal override void Orient_PH(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_Orient_PH(polyPtr);
        }

        internal override void OrientToBoundAVolume_PH(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume_PH(polyPtr);
        }

        internal override void ReverseFaceOrientations_PH(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations_PH(polyPtr);
        }

        //Surface Mesh

        internal override bool DoesBoundAVolume_SM(IntPtr polyPtr)
        {
            return PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume_SM(polyPtr);
        }

        internal override bool IsOutwardOriented_SM(IntPtr polyPtr)
        {
            return PolygonMeshProcessingOrientation_EEK_IsOutwardOriented_SM(polyPtr);
        }

        internal override void Orient_SM(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_Orient_SM(polyPtr);
        }

        internal override void OrientToBoundAVolume_SM(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume_SM(polyPtr);
        }

        internal override void ReverseFaceOrientations_SM(IntPtr polyPtr)
        {
            PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations_SM(polyPtr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingOrientation_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_Release(IntPtr ptr);

        //Polyhedron

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume_PH(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingOrientation_EEK_IsOutwardOriented_PH(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_Orient_PH(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume_PH(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations_PH(IntPtr polyPtr);

        //Surface Mesh

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingOrientation_EEK_DoesBoundAVolume_SM(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingOrientation_EEK_IsOutwardOriented_SM(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_Orient_SM(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_OrientToBoundAVolume_SM(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingOrientation_EEK_ReverseFaceOrientations_SM(IntPtr polyPtr);
    }
}
