using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal class PolygonVisibilityKernel2_EEK : PolygonVisibilityKernel2
    {
        internal static readonly PolygonVisibilityKernel2 Instance = new PolygonVisibilityKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return PolygonVisibility2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonVisibility2_EEK_Release(ptr);
        }

        internal override IntPtr ComputeVisibility(Point2d point, Segment2d[] segments, int startIndex, int count)
        {
            return PolygonVisibility2_EEK_ComputeVisibility(point, segments, startIndex, count);
        }


        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonVisibility2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonVisibility2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonVisibility2_EEK_ComputeVisibility(Point2d point, [In] Segment2d[] segments, int startIndex, int count);

    }
}
