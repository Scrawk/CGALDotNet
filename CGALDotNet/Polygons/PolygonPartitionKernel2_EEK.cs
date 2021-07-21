using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonPartitionKernel2_EEK : PolygonPartitionKernel2
    {

        internal static readonly PolygonPartitionKernel2 Instance = new PolygonPartitionKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return PolygonPartition2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonPartition2_EEK_Release(ptr);
        }

        internal override void ClearBuffer(IntPtr ptr)
        {
            PolygonPartition2_EEK_ClearBuffer(ptr);
        }

        internal override int BufferCount(IntPtr ptr)
        {
            return PolygonPartition2_EEK_BufferCount(ptr);
        }

        internal override IntPtr CopyBufferItem(IntPtr ptr, int index)
        {
            return PolygonPartition2_EEK_CopyBufferItem(ptr, index);
        }

        internal override bool Is_Y_Monotone(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EEK_Is_Y_Monotone(ptr, polyPtr);
        }

        internal override bool ConvexPartitionIsValid(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EEK_ConvexPartitionIsValid(ptr, polyPtr);
        }

        internal override int Y_MonotonePartition(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EEK_Y_MonotonePartition(ptr, polyPtr);
        }

        internal override int ApproxConvexPartition(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EEK_ApproxConvexPartition(ptr, polyPtr);
        }

        internal override int GreeneApproxConvexPartition(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EEK_GreeneApproxConvexPartition(ptr, polyPtr);
        }

        internal override int OptimalConvexPartition(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EEK_OptimalConvexPartition(ptr, polyPtr);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonPartition2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonPartition2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonPartition2_EEK_ClearBuffer(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonPartition2_EEK_BufferCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonPartition2_EEK_CopyBufferItem(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonPartition2_EEK_Is_Y_Monotone(IntPtr ptr, IntPtr polyPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonPartition2_EEK_ConvexPartitionIsValid(IntPtr ptr, IntPtr polyPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonPartition2_EEK_Y_MonotonePartition(IntPtr ptr, IntPtr polyPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonPartition2_EEK_ApproxConvexPartition(IntPtr ptr, IntPtr polyPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonPartition2_EEK_GreeneApproxConvexPartition(IntPtr ptr, IntPtr polyPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonPartition2_EEK_OptimalConvexPartition(IntPtr ptr, IntPtr polyPtr);

    }
}
