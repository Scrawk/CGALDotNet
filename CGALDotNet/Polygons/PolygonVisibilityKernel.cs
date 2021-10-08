using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonVisibilityKernel
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr ComputeVisibilitySimple(Point2d point, IntPtr polyPtr);

        internal abstract IntPtr ComputeVisibilityTEV(Point2d point, IntPtr pwhPtr);

        internal abstract IntPtr ComputeVisibilityRSV(Point2d point, IntPtr pwhPtr);
    }
}
