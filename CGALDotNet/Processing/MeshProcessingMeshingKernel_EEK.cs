using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingMeshingKernel_EEK : MeshProcessingMeshingKernel
    {
        internal override string Name => "EEK";

        internal static readonly MeshProcessingMeshingKernel Instance = new MeshProcessingMeshingKernel_EEK();

        internal override IntPtr Create()
        {
            return MeshProcessingMeshing_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingMeshing_EEK_Release(ptr);
        }

        //Polyhedron

        internal override IntPtr Extrude_PH(IntPtr meshPtr, Vector3d dir)
        {
            return MeshProcessingMeshing_EEK_Extrude_PH(meshPtr, dir);
        }

        internal override Index2 Fair_PH(IntPtr meshPtr, int index, int k_ring)
        {
            return MeshProcessingMeshing_EEK_Fair_PH(meshPtr, index, k_ring);
        }

        internal override Index2 Refine_PH(IntPtr meshPtr, double density_control_factor)
        {
            return MeshProcessingMeshing_EEK_Refine_PH(meshPtr, density_control_factor);
        }

        internal override int IsotropicRemeshing_PH(IntPtr meshPtr, int iterations, double target_edge_length)
        {
            return MeshProcessingMeshing_EEK_IsotropicRemeshing_PH(meshPtr, iterations, target_edge_length);
        }

        internal override void RandomPerturbation_PH(IntPtr meshPtr, double perturbation_max_size)
        {
            MeshProcessingMeshing_EEK_RandomPerturbation_PH (meshPtr, perturbation_max_size);
        }

        internal override void SmoothMesh_PH(IntPtr meshPtr, double featureAngle, int iterations)
        {
            MeshProcessingMeshing_EEK_SmoothMesh_PH(meshPtr, featureAngle, iterations);
        }

        internal override void SmoothShape_PH(IntPtr meshPtr, double timeStep, int iterations)
        {
            MeshProcessingMeshing_EEK_SmoothShape_PH(meshPtr, timeStep, iterations);
        }

        internal override int SplitLongEdges_PH(IntPtr meshPtr, double target_edge_length)
        {
            return MeshProcessingMeshing_EEK_SplitLongEdges_PH(meshPtr, target_edge_length);
        }

        internal override bool TriangulateFace_PH(IntPtr meshPtr, int index)
        {
            return MeshProcessingMeshing_EEK_TriangulateFace_PH(meshPtr, index);
        }

        internal override bool TriangulateFaces_PH(IntPtr meshPtr, int[] faces, int count)
        {
            return MeshProcessingMeshing_EEK_TriangulateFaces_PH(meshPtr, faces, count);
        }

        //Surface Mesh

        internal override IntPtr Extrude_SM(IntPtr meshPtr, Vector3d dir)
        {
            return MeshProcessingMeshing_EEK_Extrude_SM(meshPtr, dir);
        }

        internal override Index2 Fair_SM(IntPtr meshPtr, int index, int k_ring)
        {
            return MeshProcessingMeshing_EEK_Fair_SM(meshPtr, index, k_ring);
        }

        internal override Index2 Refine_SM(IntPtr meshPtr, double density_control_factor)
        {
            return MeshProcessingMeshing_EEK_Refine_SM(meshPtr, density_control_factor);
        }

        internal override int IsotropicRemeshing_SM(IntPtr meshPtr, int iterations, double target_edge_length)
        {
            return MeshProcessingMeshing_EEK_IsotropicRemeshing_SM(meshPtr, iterations, target_edge_length);
        }

        internal override void RandomPerturbation_SM(IntPtr meshPtr, double perturbation_max_size)
        {
            MeshProcessingMeshing_EEK_RandomPerturbation_SM(meshPtr, perturbation_max_size);
        }

        internal override void SmoothMesh_SM(IntPtr meshPtr, double featureAngle, int iterations)
        {
            MeshProcessingMeshing_EEK_SmoothMesh_SM(meshPtr, featureAngle, iterations);
        }

        internal override void SmoothShape_SM(IntPtr meshPtr, double timeStep, int iterations)
        {
            MeshProcessingMeshing_EEK_SmoothShape_SM(meshPtr, timeStep, iterations);
        }

        internal override int SplitLongEdges_SM(IntPtr meshPtr, double target_edge_length)
        {
            return MeshProcessingMeshing_EEK_SplitLongEdges_SM(meshPtr, target_edge_length);
        }

        internal override bool TriangulateFace_SM(IntPtr meshPtr, int index)
        {
            return MeshProcessingMeshing_EEK_TriangulateFace_SM(meshPtr, index);
        }

        internal override bool TriangulateFaces_SM(IntPtr meshPtr, int[] faces, int count)
        {
            return MeshProcessingMeshing_EEK_TriangulateFaces_SM(meshPtr, faces, count);
        }


        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingMeshing_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingMeshing_EEK_Release(IntPtr ptr);

        //Polyhedron

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingMeshing_EEK_Extrude_PH(IntPtr meshPtr, Vector3d dir);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Index2 MeshProcessingMeshing_EEK_Fair_PH(IntPtr meshPtr, int index, int k_ring);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Index2 MeshProcessingMeshing_EEK_Refine_PH(IntPtr meshPtr, double density_control_factor);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingMeshing_EEK_IsotropicRemeshing_PH(IntPtr meshPtr, int iterations, double target_edge_length);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingMeshing_EEK_RandomPerturbation_PH(IntPtr meshPtr, double perturbation_max_size);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingMeshing_EEK_SmoothMesh_PH(IntPtr meshPtr, double featureAngle, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingMeshing_EEK_SmoothShape_PH(IntPtr meshPtr, double timeStep, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingMeshing_EEK_SplitLongEdges_PH(IntPtr meshPtr, double target_edge_length);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingMeshing_EEK_TriangulateFace_PH(IntPtr meshPtr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingMeshing_EEK_TriangulateFaces_PH(IntPtr meshPtr, int[] faces, int count);

        //SurfaceMesh

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingMeshing_EEK_Extrude_SM(IntPtr meshPtr, Vector3d dir);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Index2 MeshProcessingMeshing_EEK_Fair_SM(IntPtr meshPtr, int index, int k_ring);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Index2 MeshProcessingMeshing_EEK_Refine_SM(IntPtr meshPtr, double density_control_factor);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingMeshing_EEK_IsotropicRemeshing_SM(IntPtr meshPtr, int iterations, double target_edge_length);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingMeshing_EEK_RandomPerturbation_SM(IntPtr meshPtr, double perturbation_max_size);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingMeshing_EEK_SmoothMesh_SM(IntPtr meshPtr, double featureAngle, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingMeshing_EEK_SmoothShape_SM(IntPtr meshPtr, double timeStep, int iterations);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingMeshing_EEK_SplitLongEdges_SM(IntPtr meshPtr, double target_edge_length);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingMeshing_EEK_TriangulateFace_SM(IntPtr meshPtr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingMeshing_EEK_TriangulateFaces_SM(IntPtr meshPtr, int[] faces, int count);
    }
}
