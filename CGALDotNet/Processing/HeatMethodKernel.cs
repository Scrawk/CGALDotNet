using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Processing
{
    internal abstract class HeatMethodKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract double GetDistance(IntPtr ptr, int index);

        internal abstract void ClearDistances(IntPtr ptr);

        internal abstract int EstimateGeodesicDistances_SM(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT);

        internal abstract int EstimateGeodesicDistances_PH(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT);
    }
}
