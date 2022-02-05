using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    internal class GeometryKernel2_EEK : GeometryKernel2
    {
        internal override string KernelName => "EEK";

        internal static readonly GeometryKernel2 Instance = new GeometryKernel2_EEK();

        internal override IntPtr IsoRectangle_Create(Point2d min, Point2d max)
        {
            return IsoRectangle2_EEK_Create(min, max);
        }

        internal override void IsoRectangle_Release(IntPtr ptr)
        {
            IsoRectangle2_EEK_Release(ptr);
        }

        internal override Point2d IsoRectangle_GetMin(IntPtr ptr)
        {
            return IsoRectangle2_EEK_GetMin(ptr);
        }

        internal override Point2d IsoRectangle_GetMax(IntPtr ptr)
        {
            return IsoRectangle2_EEK_GetMax(ptr);
        }

        internal override double IsoRectangle_Area(IntPtr ptr)
        {
            return IsoRectangle2_EEK_Area(ptr);
        }

        internal override BOUNDED_SIDE IsoRectangle_BoundedSide(IntPtr ptr, Point2d point)
        {
            return IsoRectangle2_EEK_BoundedSide(ptr, point);
        }
        internal override bool IsoRectangle_ContainsPoint(IntPtr ptr, Point2d point, bool inculdeBoundary)
        {
            return IsoRectangle2_EEK_ContainsPoint(ptr, point, inculdeBoundary);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr IsoRectangle2_EEK_Create(Point2d min, Point2d max);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void IsoRectangle2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d IsoRectangle2_EEK_GetMin(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d IsoRectangle2_EEK_GetMax(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double IsoRectangle2_EEK_Area(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern BOUNDED_SIDE IsoRectangle2_EEK_BoundedSide(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool IsoRectangle2_EEK_ContainsPoint(IntPtr ptr, Point2d point,  bool inculdeBoundary);
    }
}
