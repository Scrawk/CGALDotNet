using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Processing
{
    internal abstract class MeshProcessingSlicerKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void GetLines(IntPtr slicerPtr, IntPtr[] lines, int count);

        internal abstract int Slice(IntPtr slicerPtr, IntPtr polyPtr, Plane3d plane, bool useTree);

        internal abstract int Slice(IntPtr slicerPtr, IntPtr polyPtr, Point3d start, Point3d end, double increment);

    }
}
