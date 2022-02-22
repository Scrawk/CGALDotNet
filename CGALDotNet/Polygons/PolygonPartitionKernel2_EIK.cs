using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polygons
{
    internal class PolygonPartitionKernel2_EIK : PolygonPartitionKernel2
    {
        internal override string Name => "EIK";

        internal static readonly PolygonPartitionKernel2 Instance = new PolygonPartitionKernel2_EIK();

        internal override IntPtr Create()
        {
            return PolygonPartition2_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonPartition2_EIK_Release(ptr);
        }

        internal override void ClearBuffer(IntPtr ptr)
        {
            PolygonPartition2_EIK_ClearBuffer(ptr);
        }

        internal override int BufferCount(IntPtr ptr)
        {
            return PolygonPartition2_EIK_BufferCount(ptr);
        }

        internal override IntPtr CopyBufferItem(IntPtr ptr, int index)
        {
            return PolygonPartition2_EIK_CopyBufferItem(ptr, index);
        }

        internal override bool Is_Y_Monotone(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_Is_Y_Monotone(ptr, polyPtr);
        }

        internal override bool Is_Y_MonotonePWH(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_Is_Y_MonotonePWH(ptr, polyPtr);
        }

        internal override bool PartitionIsValid(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_PartitionIsValid(ptr, polyPtr);
        }

        internal override bool ConvexPartitionIsValid(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_ConvexPartitionIsValid(ptr, polyPtr);
        }

        internal override int Y_MonotonePartition(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_Y_MonotonePartition(ptr, polyPtr);
        }

        internal override int Y_MonotonePartitionPWH(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_Y_MonotonePartitionPWH(ptr, polyPtr);
        }

        internal override int ApproxConvexPartition(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_ApproxConvexPartition(ptr, polyPtr);
        }

        internal override int ApproxConvexPartitionPWH(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_ApproxConvexPartitionPWH(ptr, polyPtr);
        }

        internal override int GreeneApproxConvexPartition(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_GreeneApproxConvexPartition(ptr, polyPtr);
        }

        internal override int GreeneApproxConvexPartitionPWH(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_GreeneApproxConvexPartitionPWH(ptr, polyPtr);
        }

        internal override int OptimalConvexPartition(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_OptimalConvexPartition(ptr, polyPtr);
        }

        internal override int OptimalConvexPartitionPWH(IntPtr ptr, IntPtr polyPtr)
        {
            return PolygonPartition2_EIK_OptimalConvexPartitionPWH(ptr, polyPtr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonPartition2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonPartition2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonPartition2_EIK_ClearBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_BufferCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonPartition2_EIK_CopyBufferItem(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonPartition2_EIK_Is_Y_Monotone(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonPartition2_EIK_Is_Y_MonotonePWH(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonPartition2_EIK_PartitionIsValid(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonPartition2_EIK_ConvexPartitionIsValid(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_Y_MonotonePartition(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_Y_MonotonePartitionPWH(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_ApproxConvexPartition(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_ApproxConvexPartitionPWH(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_GreeneApproxConvexPartition(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_GreeneApproxConvexPartitionPWH(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_OptimalConvexPartition(IntPtr ptr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonPartition2_EIK_OptimalConvexPartitionPWH(IntPtr ptr, IntPtr polyPtr);

    }
}
