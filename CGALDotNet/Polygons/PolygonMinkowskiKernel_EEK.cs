using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    internal class PolygonMinkowskiKernel_EEK : PolygonMinkowskiKernel
    {
        internal static readonly PolygonMinkowskiKernel Instance = new PolygonMinkowskiKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMinkowski_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMinkowski_EEK_Release(ptr);
        }

        internal override IntPtr MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSum(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2, MINKOWSKI_DECOMPOSITION decomp)
        {
            return PolygonMinkowski_EEK_MinkowskiSum(polyPtr1, polyPtr2, (int)decomp);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMinkowski_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2, int decomp);

    }
}
