using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Processing
{
    internal abstract class PolygonMeshProcessingBooleanKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract bool PolyhedronUnion(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr);

        internal abstract bool PolyhedronDifference(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr);

        internal abstract bool PolyhedronIntersection(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr);

        internal abstract bool PolyhedronClip(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr);

        internal abstract bool PlaneClip(IntPtr polyPtr1, Plane3d plane, out IntPtr resultPtr);

        internal abstract bool BoxClip(IntPtr polyPtr1, Box3d box, out IntPtr resultPtr);
    }
}
