using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingConnectionsKernel_EEK : PolygonMeshProcessingConnectionsKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingConnectionsKernel Instance = new PolygonMeshProcessingConnectionsKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingConnections_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingConnections_EEK_Release(ptr);
        }

        //Polyhedron

        internal override int ConnectedComponents_PH(IntPtr meshPtr)
        {
            return PolygonMeshProcessingConnections_EEK_ConnectedComponents_PH(meshPtr);
        }

        internal override int ConnectedComponent_PH(IntPtr meshPtr, int index)
        {
            return PolygonMeshProcessingConnections_EEK_ConnectedComponent_PH(meshPtr, index);
        }

        internal override int SplitConnectedComponents_PH(IntPtr ptr, IntPtr meshPtr)
        {
            return PolygonMeshProcessingConnections_EEK_SplitConnectedComponents_PH(ptr, meshPtr);
        }

        internal override void GetSplitConnectedComponents_PH(IntPtr ptr, IntPtr[] meshPtrs, int count)
        {
            PolygonMeshProcessingConnections_EEK_GetSplitConnectedComponents_PH(ptr, meshPtrs, count);
        }

        internal override int KeepLargestConnectedComponents_PH(IntPtr meshPtr, int nb_components_to_keep)
        {
            return PolygonMeshProcessingConnections_EEK_KeepLargestConnectedComponents_PH(meshPtr, nb_components_to_keep);
        }

        //Surface MEsh

        internal override int ConnectedComponents_SM(IntPtr meshPtr)
        {
            return PolygonMeshProcessingConnections_EEK_ConnectedComponents_SM(meshPtr);
        }

        internal override int ConnectedComponent_SM(IntPtr meshPtr, int index)
        {
            return PolygonMeshProcessingConnections_EEK_ConnectedComponent_SM(meshPtr, index);
        }

        internal override int SplitConnectedComponents_SM(IntPtr ptr, IntPtr meshPtr)
        {
            return PolygonMeshProcessingConnections_EEK_SplitConnectedComponents_SM(ptr, meshPtr);
        }

        internal override void GetSplitConnectedComponents_SM(IntPtr ptr, IntPtr[] meshPtrs, int count)
        {
            PolygonMeshProcessingConnections_EEK_GetSplitConnectedComponents_SM(ptr, meshPtrs, count);
        }

        internal override int KeepLargestConnectedComponents_SM(IntPtr meshPtr, int nb_components_to_keep)
        {
            return PolygonMeshProcessingConnections_EEK_KeepLargestConnectedComponents_SM(meshPtr, nb_components_to_keep);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingConnections_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingConnections_EEK_Release(IntPtr ptr);

        //Polyhedron

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_ConnectedComponents_PH(IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_ConnectedComponent_PH(IntPtr meshPtr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_ConnectedComponent_PH(IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_SplitConnectedComponents_PH(IntPtr ptr, IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingConnections_EEK_GetSplitConnectedComponents_PH(IntPtr ptr, [Out] IntPtr[] meshPtrs, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_KeepLargestConnectedComponents_PH(IntPtr meshPtr, int nb_components_to_keep);

        //Surface Mesh

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_ConnectedComponents_SM(IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_ConnectedComponent_SM(IntPtr meshPtr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_ConnectedComponent_SM(IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_SplitConnectedComponents_SM(IntPtr ptr, IntPtr meshPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingConnections_EEK_GetSplitConnectedComponents_SM(IntPtr ptr, [Out] IntPtr[] meshPtrs, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_KeepLargestConnectedComponents_SM(IntPtr meshPtr, int nb_components_to_keep);
    }
}
