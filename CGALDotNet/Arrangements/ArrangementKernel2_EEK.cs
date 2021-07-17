using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
    internal sealed class ArrangementKernel2_EEK : ArrangementKernel2
    {

        internal static readonly ArrangementKernel2 Instance = new ArrangementKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return Arrangement2_EEK_Create();
        }

        internal override IntPtr CreateFromSegments(Segment2d[] segments, int startIndex, int count)
        {
            return Arrangement2_EEK_CreateFromSegments(segments, startIndex, count);
        }

        internal override void Release(IntPtr ptr)
        {
            Arrangement2_EEK_Release(ptr);
        }

        internal override int ElementCount(IntPtr ptr, ARRANGEMENT2_ELEMENT element)
        {
            return Arrangement2_EEK_ElementCount(ptr, element);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Arrangement2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Arrangement2_EEK_CreateFromSegments([In] Segment2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Arrangement2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int Arrangement2_EEK_ElementCount(IntPtr ptr, ARRANGEMENT2_ELEMENT element);
    }
}
