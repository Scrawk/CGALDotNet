using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polygons
{
    internal class PolygonVisibilityKernel_EEK : PolygonVisibilityKernel
    {
        internal override string Name => "EEK";

        internal static readonly PolygonVisibilityKernel Instance = new PolygonVisibilityKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonVisibility_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonVisibility_EEK_Release(ptr);
        }

        internal override IntPtr ComputeVisibilitySimple(Point2d point, IntPtr polyPtr)
        {
            return PolygonVisibility_EEK_ComputeVisibilitySimple(point, polyPtr);
        }

        internal override IntPtr ComputeVisibilityTEV(Point2d point, IntPtr pwhPtr)
        {
            return PolygonVisibility_EEK_ComputeVisibilityTEV(point, pwhPtr);
        }

        internal override IntPtr ComputeVisibilityRSV(Point2d point, IntPtr pwhPtr)
        {
            return PolygonVisibility_EEK_ComputeVisibilityRSV(point, pwhPtr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonVisibility_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EEK_ComputeVisibilitySimple(Point2d point, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EEK_ComputeVisibilityTEV(Point2d point, IntPtr pwhPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EEK_ComputeVisibilityRSV(Point2d point, IntPtr pwhPtr);
    }
}
