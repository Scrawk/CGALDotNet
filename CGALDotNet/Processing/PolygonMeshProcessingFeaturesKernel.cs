using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Processing
{
    internal abstract class PolygonMeshProcessingFeaturesKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract int DetectSharpEdges(IntPtr feaPtr, IntPtr polyPtr, Degree feature_angle);

    }
}
