using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonPartitionKernel2
    {

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void ClearBuffer(IntPtr ptr);

        internal abstract int BufferCount(IntPtr ptr);

        internal abstract IntPtr CopyBufferItem(IntPtr ptr, int index);

        internal abstract bool Is_Y_Monotone(IntPtr ptr, IntPtr polyPtr);

        internal abstract bool ConvexPartitionIsValid(IntPtr ptr, IntPtr polyPtr);

        internal abstract int Y_MonotonePartition(IntPtr ptr, IntPtr polyPtr);

        internal abstract int ApproxConvexPartition(IntPtr ptr, IntPtr polyPtr);

        internal abstract int GreeneApproxConvexPartition(IntPtr ptr, IntPtr polyPtr);

        internal abstract int OptimalConvexPartition(IntPtr ptr, IntPtr polyPtr);
    }
}
