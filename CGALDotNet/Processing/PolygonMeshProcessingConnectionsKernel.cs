using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class PolygonMeshProcessingConnectionsKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void PolyhedronConnectedComponents(IntPtr polyPtr);

        internal abstract int PolyhedronSplitConnectedComponents(IntPtr ptr, IntPtr polyPtr);

        internal abstract void PolyhedronGetSplitConnectedComponents(IntPtr ptr, IntPtr[] polyPtrs, int count);

        internal abstract int PolyhedronKeepLargestConnectedComponents(IntPtr polyPtr, int nb_components_to_keep);

    }
}
