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

        internal abstract int PolyhedronSplitConnectedComponents(IntPtr polyPtr);

        internal abstract int PolyhedronKeepLargestConnectedComponents(IntPtr polyPtr, int nb_components_to_keep);
    }
}
