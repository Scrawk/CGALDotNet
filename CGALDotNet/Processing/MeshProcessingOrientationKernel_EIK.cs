using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingOrientationKernel_EIK : MeshProcessingOrientationKernel
    {
        internal override string Name => "EIK";

        internal static readonly MeshProcessingOrientationKernel Instance = new MeshProcessingOrientationKernel_EIK();

        internal override IntPtr Create()
        {
            return MeshProcessingOrientation_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingOrientation_EIK_Release(ptr);
        }

        //Polyhedron

        internal override bool DoesBoundAVolume_PH(IntPtr polyPtr)
        {
            return MeshProcessingOrientation_EIK_DoesBoundAVolume_PH(polyPtr);
        }

        internal override bool IsOutwardOriented_PH(IntPtr polyPtr)
        {
            return MeshProcessingOrientation_EIK_IsOutwardOriented_PH(polyPtr);
        }

        internal override void Orient_PH(IntPtr polyPtr)
        {
            MeshProcessingOrientation_EIK_Orient_PH(polyPtr);
        }

        internal override void OrientToBoundAVolume_PH(IntPtr polyPtr)
        {
            MeshProcessingOrientation_EIK_OrientToBoundAVolume_PH(polyPtr);
        }

        internal override void ReverseFaceOrientations_PH(IntPtr polyPtr)
        {
            MeshProcessingOrientation_EIK_ReverseFaceOrientations_PH(polyPtr);
        }

        //Surface Mesh

        internal override bool DoesBoundAVolume_SM(IntPtr polyPtr)
        {
            return MeshProcessingOrientation_EIK_DoesBoundAVolume_SM(polyPtr);
        }

        internal override bool IsOutwardOriented_SM(IntPtr polyPtr)
        {
            return MeshProcessingOrientation_EIK_IsOutwardOriented_SM(polyPtr);
        }

        internal override void Orient_SM(IntPtr polyPtr)
        {
            MeshProcessingOrientation_EIK_Orient_SM(polyPtr);
        }

        internal override void OrientToBoundAVolume_SM(IntPtr polyPtr)
        {
            MeshProcessingOrientation_EIK_OrientToBoundAVolume_SM(polyPtr);
        }

        internal override void ReverseFaceOrientations_SM(IntPtr polyPtr)
        {
            MeshProcessingOrientation_EIK_ReverseFaceOrientations_SM(polyPtr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingOrientation_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingOrientation_EIK_Release(IntPtr ptr);

        //Polyhedron

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingOrientation_EIK_DoesBoundAVolume_PH(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingOrientation_EIK_IsOutwardOriented_PH(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingOrientation_EIK_Orient_PH(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingOrientation_EIK_OrientToBoundAVolume_PH(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingOrientation_EIK_ReverseFaceOrientations_PH(IntPtr polyPtr);

        //Surface Mesh

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingOrientation_EIK_DoesBoundAVolume_SM(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingOrientation_EIK_IsOutwardOriented_SM(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingOrientation_EIK_Orient_SM(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingOrientation_EIK_OrientToBoundAVolume_SM(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingOrientation_EIK_ReverseFaceOrientations_SM(IntPtr polyPtr);
    }
}
