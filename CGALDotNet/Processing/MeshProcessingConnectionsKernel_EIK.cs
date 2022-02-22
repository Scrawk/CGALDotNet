using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingConnectionsKernel_EIK : MeshProcessingConnectionsKernel
    {
        internal override string Name => "EIK";

        internal static readonly MeshProcessingConnectionsKernel Instance = new MeshProcessingConnectionsKernel_EIK();

        internal override IntPtr Create()
        {
            return MeshProcessingConnections_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingConnections_EIK_Release(ptr);
        }

        //Polyhedron

        internal override int ConnectedComponents_PH(IntPtr meshPtr)
        {
            return MeshProcessingConnections_EIK_ConnectedComponents_PH(meshPtr);
        }

        internal override int ConnectedComponent_PH(IntPtr ptr, IntPtr meshPtr, int index)
        {
            return MeshProcessingConnections_EIK_ConnectedComponent_PH(ptr, meshPtr, index);
        }

        internal override void GetConnectedComponentsFaceIndex_PH(IntPtr ptr, IntPtr meshPtr, int[] indices, int count)
        {
            MeshProcessingConnections_EIK_GetConnectedComponentsFaceIndex_PH(ptr, meshPtr, indices, count);
        }

        internal override int SplitConnectedComponents_PH(IntPtr ptr, IntPtr meshPtr)
        {
            return MeshProcessingConnections_EIK_SplitConnectedComponents_PH(ptr, meshPtr);
        }

        internal override void GetSplitConnectedComponents_PH(IntPtr ptr, IntPtr[] meshPtrs, int count)
        {
            MeshProcessingConnections_EIK_GetSplitConnectedComponents_PH(ptr, meshPtrs, count);
        }

        internal override int KeepLargeConnectedComponents_PH(IntPtr meshPtr, int threshold_value)
        {
            return MeshProcessingConnections_EIK_KeepLargeConnectedComponents_PH(meshPtr, threshold_value);
        }

        internal override int KeepLargestConnectedComponents_PH(IntPtr meshPtr, int nb_components_to_keep)
        {
            return MeshProcessingConnections_EIK_KeepLargestConnectedComponents_PH(meshPtr, nb_components_to_keep);
        }

        //Surface MEsh

        internal override int ConnectedComponents_SM(IntPtr meshPtr)
        {
            return MeshProcessingConnections_EIK_ConnectedComponents_SM(meshPtr);
        }

        internal override int ConnectedComponent_SM(IntPtr ptr, IntPtr meshPtr, int index)
        {
            return MeshProcessingConnections_EIK_ConnectedComponent_SM(ptr, meshPtr, index);
        }

        internal override void GetConnectedComponentsFaceIndex_SM(IntPtr ptr, IntPtr meshPtr, int[] indices, int count)
        {
            MeshProcessingConnections_EIK_GetConnectedComponentsFaceIndex_SM(ptr, meshPtr, indices, count);
        }

        internal override int SplitConnectedComponents_SM(IntPtr ptr, IntPtr meshPtr)
        {
            return MeshProcessingConnections_EIK_SplitConnectedComponents_SM(ptr, meshPtr);
        }

        internal override void GetSplitConnectedComponents_SM(IntPtr ptr, IntPtr[] meshPtrs, int count)
        {
            MeshProcessingConnections_EIK_GetSplitConnectedComponents_SM(ptr, meshPtrs, count);
        }

        internal override int KeepLargeConnectedComponents_SM(IntPtr meshPtr, int threshold_value)
        {
            return MeshProcessingConnections_EIK_KeepLargeConnectedComponents_SM(meshPtr, threshold_value);
        }

        internal override int KeepLargestConnectedComponents_SM(IntPtr meshPtr, int nb_components_to_keep)
        {
            return MeshProcessingConnections_EIK_KeepLargestConnectedComponents_SM(meshPtr, nb_components_to_keep);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingConnections_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingConnections_EIK_Release(IntPtr ptr);

        //Polyhedron

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_ConnectedComponents_PH(IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_ConnectedComponent_PH(IntPtr ptr, IntPtr meshPtr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingConnections_EIK_GetConnectedComponentsFaceIndex_PH(IntPtr ptr, IntPtr meshPtr, [Out] int[] indices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_ConnectedComponent_PH(IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_SplitConnectedComponents_PH(IntPtr ptr, IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingConnections_EIK_GetSplitConnectedComponents_PH(IntPtr ptr, [Out] IntPtr[] meshPtrs, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_KeepLargeConnectedComponents_PH(IntPtr meshPtr, int threshold_value);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_KeepLargestConnectedComponents_PH(IntPtr meshPtr, int nb_components_to_keep);

        //Surface Mesh

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_ConnectedComponents_SM(IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_ConnectedComponent_SM(IntPtr ptr, IntPtr meshPtr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingConnections_EIK_GetConnectedComponentsFaceIndex_SM(IntPtr ptr, IntPtr meshPtr, [Out] int[] indices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_ConnectedComponent_SM(IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_SplitConnectedComponents_SM(IntPtr ptr, IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingConnections_EIK_GetSplitConnectedComponents_SM(IntPtr ptr, [Out] IntPtr[] meshPtrs, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_KeepLargeConnectedComponents_SM(IntPtr meshPtr, int threshold_value);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingConnections_EIK_KeepLargestConnectedComponents_SM(IntPtr meshPtr, int nb_components_to_keep);
    }
}
