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

        internal override void Extrude(IntPtr polyPtr)
        {
            PolygonMeshProcessingMeshing_EEK_Extrude(polyPtr);
        }

        internal override bool Fair(IntPtr polyPtr)
        {
            return PolygonMeshProcessingMeshing_EEK_Fair(polyPtr);
        }

        internal override int Refine(IntPtr polyPtr, double density_control_factor)
        {
            return PolygonMeshProcessingMeshing_EEK_Refine(polyPtr, density_control_factor);
        }

        internal override void IsotropicRemeshing(IntPtr polyPtr, int iterations, double target_edge_length)
        {
            PolygonMeshProcessingMeshing_EEK_IsotropicRemeshing(polyPtr, iterations, target_edge_length);
        }

        internal override void RandomPerturbation(IntPtr polyPtr, double perturbation_max_size)
        {
            PolygonMeshProcessingMeshing_EEK_RandomPerturbation(polyPtr, perturbation_max_size);
        }

        internal override void SmoothMesh(IntPtr polyPtr)
        {
            PolygonMeshProcessingMeshing_EEK_SmoothMesh(polyPtr);
        }

        internal override void SmoothShape(IntPtr polyPtr)
        {
            PolygonMeshProcessingMeshing_EEK_SmoothShape(polyPtr);
        }

        internal override void SplitLongEdges(IntPtr polyPtr, double target_edge_length)
        {
            PolygonMeshProcessingMeshing_EEK_SplitLongEdges(polyPtr, target_edge_length);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingMeshing_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingMeshing_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingMeshing_EEK_Extrude(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingMeshing_EEK_Fair(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingMeshing_EEK_Refine(IntPtr polyPtr, double density_control_factor);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingMeshing_EEK_IsotropicRemeshing(IntPtr polyPtr, int iterations, double target_edge_length);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingMeshing_EEK_RandomPerturbation(IntPtr polyPtr, double perturbation_max_size);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingMeshing_EEK_SmoothMesh(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingMeshing_EEK_SmoothShape(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingMeshing_EEK_SplitLongEdges(IntPtr polyPtr, double target_edge_length);
    }
}
