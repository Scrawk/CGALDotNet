using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingRepairKernel_EEK : PolygonMeshProcessingRepairKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingRepairKernel Instance = new PolygonMeshProcessingRepairKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingRepair_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingRepair_EEK_Release(ptr);
        }

        internal override int DegenerateHalfEdgeCount(IntPtr ptr)
        {
            return PolygonMeshProcessingRepair_EEK_DegenerateHalfEdgeCount(ptr);
        }

        internal override int DegenerateTriangleCount(IntPtr ptr)
        {
            return PolygonMeshProcessingRepair_EEK_DegenerateTriangleCount(ptr);
        }

        internal override int NeedleTriangleCount(IntPtr ptr, double threshold)
        {
            return PolygonMeshProcessingRepair_EEK_NeedleTriangleCount(ptr, threshold);
        }

        internal override int NonManifoldVertexCount(IntPtr ptr)
        {
            return PolygonMeshProcessingRepair_EEK_NonManifoldVertexCount(ptr);
        }

        internal override void RepairPolygonSoup(IntPtr ptr)
        {
            PolygonMeshProcessingRepair_EEK_RepairPolygonSoup(ptr);
        }

        internal override int StitchBoundaryCycles(IntPtr ptr)
        {
            return PolygonMeshProcessingRepair_EEK_StitchBoundaryCycles(ptr);
        }

        internal override int StitchBorders(IntPtr ptr)
        {
           return PolygonMeshProcessingRepair_EEK_StitchBorders(ptr);   
        }

        internal override int MergeDuplicatedVerticesInBoundaryCycle(IntPtr ptr)
        {
            return PolygonMeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle(ptr);
        }

        internal override int RemoveIsolatedVertices(IntPtr ptr)
        {
            return PolygonMeshProcessingRepair_EEK_RemoveIsolatedVertices(ptr);
        }

        internal override void PolygonMeshToPolygonSoup(IntPtr ptr, int[] triangles, int triangleCount, int[] quads, int quadCount)
        {
            PolygonMeshProcessingRepair_EEK_PolygonMeshToPolygonSoup(ptr, triangles, triangleCount, quads, quadCount);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingRepair_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingRepair_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingRepair_EEK_DegenerateHalfEdgeCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingRepair_EEK_DegenerateTriangleCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingRepair_EEK_NeedleTriangleCount(IntPtr ptr, double threshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingRepair_EEK_NonManifoldVertexCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingRepair_EEK_RepairPolygonSoup(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingRepair_EEK_StitchBoundaryCycles(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingRepair_EEK_StitchBorders(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingRepair_EEK_RemoveIsolatedVertices(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingRepair_EEK_PolygonMeshToPolygonSoup(IntPtr ptr, [Out] int[] triangles, int triangleCount, [Out] int[] quads, int quadCount);
    }
}
