using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonMinkowskiKernel
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2);

        internal abstract IntPtr MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2, MINKOWSKI_DECOMPOSITION decomp);
    }

}
