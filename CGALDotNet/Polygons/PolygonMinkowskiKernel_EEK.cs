using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    internal class PolygonMinkowskiKernel_EEK : PolygonMinkowskiKernel
    {
        internal override string Name => "EEK";

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

        internal override IntPtr MinkowskiSumPWH(IntPtr pwhPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSumPWH(pwhPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_SSAB(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSum_SSAB(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_OptimalConvex(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSum_OptimalConvex(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_HertelMehlhorn(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSum_HertelMehlhorn(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_GreeneConvex(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSum_GreeneConvex(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_Vertical(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSum_Vertical(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSumPWH_Vertical(IntPtr pwhPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSumPWH_Vertical(pwhPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_Triangle(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSum_Triangle(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSumPWH_Triangle(IntPtr pwhPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EEK_MinkowskiSumPWH_Triangle(pwhPtr1, polyPtr2);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMinkowski_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSumPWH(IntPtr pwhPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum_SSAB(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum_OptimalConvex(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum_HertelMehlhorn(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum_GreeneConvex(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum_Vertical(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSumPWH_Vertical(IntPtr pwhPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSum_Triangle(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EEK_MinkowskiSumPWH_Triangle(IntPtr pwhPtr1, IntPtr polyPtr2);

    }
}
