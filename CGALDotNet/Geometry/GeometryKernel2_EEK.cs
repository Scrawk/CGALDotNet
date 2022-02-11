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

        //Point2
        internal override IntPtr Point2_Create()
        {
            return Point2_Create();
        }

        internal override IntPtr Point2_CreateFromPoint(Point2d point)
        {
            return Point2_CreateFromPoint(point);
        }

        internal override void Point2_Release(IntPtr ptr)
        {
            Point2_EEK_Release(ptr);
        }

        internal override Point2d Point2_GetPoint(IntPtr ptr)
        {
            return Point2_EEK_GetPoint(ptr);
        }

        internal override void Point2_SetPoint(IntPtr ptr, Point2d point)
        {
            Point2_EEK_SetPoint(ptr, point);
        }

        //Line2
        internal override IntPtr Line2_Create(double a, double b, double c)
        {
            return Line2_EEK_Create(a, b, c);
        }

        internal override void Line2_Release(IntPtr ptr)
        {
            Line2_EEK_Release(ptr);
        }

        //Ray2
        internal override IntPtr Ray2_Create(Point2d position, Vector2d direction)
        {
            return Ray2_EEK_Create(position, direction);
        }

        internal override void Ray2_Release(IntPtr ptr)
        {
            Ray2_EEK_Release(ptr);
        }

        //Segment2
        internal override IntPtr Segment2_Create(Point2d a, Point2d b)
        {
            return Segment2_EEK_Create(a, b);
        }

        internal override void Segment2_Release(IntPtr ptr)
        {
            Segment2_EEK_Release(ptr);
        }

        //Triangle2
        internal override IntPtr Triangle2_Create(Point2d a, Point2d b, Point2d c)
        {
            return Triangle2_EEK_Create(a, b, c);
        }

        internal override void Triangle2_Release(IntPtr ptr)
        {
            Triangle2_EEK_Release(ptr);
        }

        //IsoRectangle2
        internal override IntPtr IsoRectangle2_Create(Point2d min, Point2d max)
        {
            return IsoRectangle2_EEK_Create(min, max);
        }

        internal override void IsoRectangle2_Release(IntPtr ptr)
        {
            IsoRectangle2_EEK_Release(ptr);
        }

        internal override Point2d IsoRectangle2_GetMin(IntPtr ptr)
        {
            return IsoRectangle2_EEK_GetMin(ptr);
        }

        internal override Point2d IsoRectangle2_GetMax(IntPtr ptr)
        {
            return IsoRectangle2_EEK_GetMax(ptr);
        }

        internal override double IsoRectangle2_Area(IntPtr ptr)
        {
            return IsoRectangle2_EEK_Area(ptr);
        }

        internal override BOUNDED_SIDE IsoRectangle2_BoundedSide(IntPtr ptr, Point2d point)
        {
            return IsoRectangle2_EEK_BoundedSide(ptr, point);
        }
        internal override bool IsoRectangle2_ContainsPoint(IntPtr ptr, Point2d point, bool inculdeBoundary)
        {
            return IsoRectangle2_EEK_ContainsPoint(ptr, point, inculdeBoundary);
        }

        //Point2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Point2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Point2_EEK_CreateFromPoint(Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d Point2_EEK_GetPoint(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Point2_EEK_SetPoint(IntPtr ptr, Point2d point);

        //Line2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Line2_EEK_Create(double a, double b, double c);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Line2_EEK_Release(IntPtr ptr);

        //Ray2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Ray2_EEK_Create(Point2d position, Vector2d direction);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Ray2_EEK_Release(IntPtr ptr);

        //Segment2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Segment2_EEK_Create(Point2d a, Point2d b);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Segment2_EEK_Release(IntPtr ptr);

        //Triangle2
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr Triangle2_EEK_Create(Point2d a, Point2d b, Point2d c);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void Triangle2_EEK_Release(IntPtr ptr);

        //IsoRectangle2
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
