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

        internal override void PolyhedronConnectedComponents(IntPtr polyPtr)
        {
            PolygonMeshProcessingConnections_EEK_PolyhedronConnectedComponents(polyPtr);
        }

        internal override int PolyhedronSplitConnectedComponents(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonMeshProcessingConnections_EEK_PolyhedronSplitConnectedComponents(ptr, polyPtr);
        }

        internal override void PolyhedronGetSplitConnectedComponents(IntPtr ptr, IntPtr[] polyPtrs, int count)
        {
            PolygonMeshProcessingConnections_EEK_PolyhedronGetSplitConnectedComponents(ptr, polyPtrs, count);
        }

        internal override int PolyhedronKeepLargestConnectedComponents(IntPtr polyPtr, int nb_components_to_keep)
        {
            return PolygonMeshProcessingConnections_EEK_PolyhedronKeepLargestConnectedComponents(polyPtr, nb_components_to_keep);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingConnections_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingConnections_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingConnections_EEK_PolyhedronConnectedComponents(IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_PolyhedronSplitConnectedComponents(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingConnections_EEK_PolyhedronGetSplitConnectedComponents(IntPtr ptr, [Out] IntPtr[] polyPtrs, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingConnections_EEK_PolyhedronKeepLargestConnectedComponents(IntPtr polyPtr, int nb_components_to_keep);
    }
}
