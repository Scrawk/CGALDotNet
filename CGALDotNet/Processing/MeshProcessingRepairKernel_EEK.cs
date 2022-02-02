using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingRepairKernel_EEK : MeshProcessingRepairKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly MeshProcessingRepairKernel Instance = new MeshProcessingRepairKernel_EEK();

        internal override IntPtr Create()
        {
            return MeshProcessingRepair_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingRepair_EEK_Release(ptr);
        }

        internal override int DegenerateHalfEdgeCount(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_DegenerateHalfEdgeCount(ptr);
        }

        internal override int DegenerateTriangleCount(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_DegenerateTriangleCount(ptr);
        }

        internal override int NeedleTriangleCount(IntPtr ptr, double threshold)
        {
            return MeshProcessingRepair_EEK_NeedleTriangleCount(ptr, threshold);
        }

        internal override int NonManifoldVertexCount(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_NonManifoldVertexCount(ptr);
        }

        internal override void RepairPolygonSoup(IntPtr ptr)
        {
            MeshProcessingRepair_EEK_RepairPolygonSoup(ptr);
        }

        internal override int StitchBoundaryCycles(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_StitchBoundaryCycles(ptr);
        }

        internal override int StitchBorders(IntPtr ptr)
        {
           return MeshProcessingRepair_EEK_StitchBorders(ptr);   
        }

        internal override int MergeDuplicatedVerticesInBoundaryCycle(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle(ptr);
        }

        internal override int RemoveIsolatedVertices(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_RemoveIsolatedVertices(ptr);
        }

        internal override void PolygonMeshToPolygonSoup(IntPtr ptr, int[] triangles, int triangleCount, int[] quads, int quadCount)
        {
            MeshProcessingRepair_EEK_PolygonMeshToPolygonSoup(ptr, triangles, triangleCount, quads, quadCount);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingRepair_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingRepair_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_DegenerateHalfEdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_DegenerateTriangleCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_NeedleTriangleCount(IntPtr ptr, double threshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_NonManifoldVertexCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingRepair_EEK_RepairPolygonSoup(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_StitchBoundaryCycles(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_StitchBorders(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_RemoveIsolatedVertices(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingRepair_EEK_PolygonMeshToPolygonSoup(IntPtr ptr, [Out] int[] triangles, int triangleCount, [Out] int[] quads, int quadCount);
    }
}
