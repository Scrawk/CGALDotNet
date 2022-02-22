using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingRepairKernel_EEK : MeshProcessingRepairKernel
    {
        internal override string Name => "EEK";

        internal static readonly MeshProcessingRepairKernel Instance = new MeshProcessingRepairKernel_EEK();

        internal override IntPtr Create()
        {
            return MeshProcessingRepair_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingRepair_EEK_Release(ptr);
        }

        //Polyhedron

        internal override int DegenerateEdgeCount_PH(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_DegenerateEdgeCount_PH(ptr);
        }

        internal override int DegenerateTriangleCount_PH(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_DegenerateTriangleCount_PH(ptr);
        }

        internal override int NeedleTriangleCount_PH(IntPtr ptr, double threshold)
        {
            return MeshProcessingRepair_EEK_NeedleTriangleCount_PH(ptr, threshold);
        }

        internal override int NonManifoldVertexCount_PH(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_NonManifoldVertexCount_PH(ptr);
        }

        internal override void RepairPolygonSoup_PH(IntPtr ptr)
        {
            MeshProcessingRepair_EEK_RepairPolygonSoup_PH(ptr);
        }

        internal override int StitchBoundaryCycles_PH(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_StitchBoundaryCycles_PH(ptr);
        }

        internal override int StitchBorders_PH(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_StitchBorders_PH(ptr);
        }

        internal override int MergeDuplicatedVerticesInBoundaryCycle_PH(IntPtr ptr, int index)
        {
            return MergeDuplicatedVerticesInBoundaryCycle_PH(ptr, index);
        }

        internal override int MergeDuplicatedVerticesInBoundaryCycles_PH(IntPtr ptr)
        {
            return MergeDuplicatedVerticesInBoundaryCycles_PH(ptr);
        }

        internal override int RemoveIsolatedVertices_PH(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_RemoveIsolatedVertices_PH(ptr);
        }

        //SurfaceMesh

        internal override int DegenerateEdgeCount_SM(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_DegenerateEdgeCount_SM(ptr);
        }

        internal override int DegenerateTriangleCount_SM(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_DegenerateTriangleCount_SM(ptr);
        }

        internal override int NeedleTriangleCount_SM(IntPtr ptr, double threshold)
        {
            return MeshProcessingRepair_EEK_NeedleTriangleCount_SM(ptr, threshold);
        }

        internal override int NonManifoldVertexCount_SM(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_NonManifoldVertexCount_SM(ptr);
        }

        internal override void RepairPolygonSoup_SM(IntPtr ptr)
        {
            MeshProcessingRepair_EEK_RepairPolygonSoup_SM(ptr);
        }

        internal override int StitchBoundaryCycles_SM(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_StitchBoundaryCycles_SM(ptr);
        }

        internal override int StitchBorders_SM(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_StitchBorders_SM(ptr);
        }

        internal override int MergeDuplicatedVerticesInBoundaryCycle_SM(IntPtr ptr, int index)
        {
            return MergeDuplicatedVerticesInBoundaryCycle_SM(ptr, index);
        }

        internal override int MergeDuplicatedVerticesInBoundaryCycles_SM(IntPtr ptr)
        {
            return MergeDuplicatedVerticesInBoundaryCycles_SM(ptr);
        }

        internal override int RemoveIsolatedVertices_SM(IntPtr ptr)
        {
            return MeshProcessingRepair_EEK_RemoveIsolatedVertices_SM(ptr);
        }



        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingRepair_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingRepair_EEK_Release(IntPtr ptr);

        //Polyhedron
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_DegenerateEdgeCount_PH(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_DegenerateTriangleCount_PH(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_NeedleTriangleCount_PH(IntPtr ptr, double threshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_NonManifoldVertexCount_PH(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingRepair_EEK_RepairPolygonSoup_PH(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_StitchBoundaryCycles_PH(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_StitchBorders_PH(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle_PH(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycles_PH(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_RemoveIsolatedVertices_PH(IntPtr ptr);

        //SurfaceMesh
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_DegenerateEdgeCount_SM(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_DegenerateTriangleCount_SM(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_NeedleTriangleCount_SM(IntPtr ptr, double threshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_NonManifoldVertexCount_SM(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingRepair_EEK_RepairPolygonSoup_SM(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_StitchBoundaryCycles_SM(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_StitchBorders_SM(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycle_SM(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_MergeDuplicatedVerticesInBoundaryCycles_SM(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingRepair_EEK_RemoveIsolatedVertices_SM(IntPtr ptr);
    }
}
