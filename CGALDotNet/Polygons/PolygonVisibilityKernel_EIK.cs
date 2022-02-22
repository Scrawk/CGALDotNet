using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polygons
{
    internal class PolygonVisibilityKernel_EIK : PolygonVisibilityKernel
    {
        internal override string Name => "EIK";

        internal static readonly PolygonVisibilityKernel Instance = new PolygonVisibilityKernel_EIK();

        internal override IntPtr Create()
        {
            return PolygonVisibility_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonVisibility_EIK_Release(ptr);
        }

        internal override IntPtr ComputeVisibilitySimple(Point2d point, IntPtr polyPtr)
        {
            return PolygonVisibility_EIK_ComputeVisibilitySimple(point, polyPtr);
        }

        internal override IntPtr ComputeVisibilityTEV(Point2d point, IntPtr pwhPtr)
        {
            return PolygonVisibility_EIK_ComputeVisibilityTEV(point, pwhPtr);
        }

        internal override IntPtr ComputeVisibilityRSV(Point2d point, IntPtr pwhPtr)
        {
            return PolygonVisibility_EIK_ComputeVisibilityRSV(point, pwhPtr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonVisibility_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EIK_ComputeVisibilitySimple(Point2d point, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EIK_ComputeVisibilityTEV(Point2d point, IntPtr pwhPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EIK_ComputeVisibilityRSV(Point2d point, IntPtr pwhPtr);
    }
}
