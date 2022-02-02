using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class MeshProcessingConnectionsKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        //Polyhedron

        internal abstract int ConnectedComponents_PH(IntPtr meshPtr);

        internal abstract int ConnectedComponent_PH(IntPtr ptr, IntPtr meshPtr, int index);

        internal abstract void GetConnectedComponentsFaceIndex_PH(IntPtr ptr, IntPtr meshPtr, int[] indices, int count);

        internal abstract int SplitConnectedComponents_PH(IntPtr ptr, IntPtr meshPtr);

        internal abstract void GetSplitConnectedComponents_PH(IntPtr ptr, IntPtr[] meshPtrs, int count);

        internal abstract int KeepLargeConnectedComponents_PH(IntPtr meshPtr, int threshold_value);

        internal abstract int KeepLargestConnectedComponents_PH(IntPtr meshPtr, int nb_components_to_keep);

        //Surface Mesh

        internal abstract int ConnectedComponents_SM(IntPtr meshPtr);

        internal abstract int ConnectedComponent_SM(IntPtr ptr, IntPtr meshPtr, int index);

        internal abstract void GetConnectedComponentsFaceIndex_SM(IntPtr ptr, IntPtr meshPtr, int[] indices, int count);

        internal abstract int SplitConnectedComponents_SM(IntPtr ptr, IntPtr meshPtr);

        internal abstract void GetSplitConnectedComponents_SM(IntPtr ptr, IntPtr[] meshPtrs, int count);

        internal abstract  int KeepLargeConnectedComponents_SM(IntPtr meshPtr, int threshold_value);

        internal abstract int KeepLargestConnectedComponents_SM(IntPtr meshPtr, int nb_components_to_keep);
    }
}
