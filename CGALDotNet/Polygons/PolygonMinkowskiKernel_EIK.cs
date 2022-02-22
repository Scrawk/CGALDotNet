using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    internal class PolygonMinkowskiKernel_EIK : PolygonMinkowskiKernel
    {
        internal override string Name => "EIK";

        internal static readonly PolygonMinkowskiKernel Instance = new PolygonMinkowskiKernel_EIK();

        internal override IntPtr Create()
        {
            return PolygonMinkowski_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMinkowski_EIK_Release(ptr);
        }

        internal override IntPtr MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSum(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSumPWH(IntPtr pwhPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSumPWH(pwhPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_SSAB(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSum_SSAB(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_OptimalConvex(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSum_OptimalConvex(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_HertelMehlhorn(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSum_HertelMehlhorn(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_GreeneConvex(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSum_GreeneConvex(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_Vertical(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSum_Vertical(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSumPWH_Vertical(IntPtr pwhPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSumPWH_Vertical(pwhPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSum_Triangle(IntPtr polyPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSum_Triangle(polyPtr1, polyPtr2);
        }

        internal override IntPtr MinkowskiSumPWH_Triangle(IntPtr pwhPtr1, IntPtr polyPtr2)
        {
            return PolygonMinkowski_EIK_MinkowskiSumPWH_Triangle(pwhPtr1, polyPtr2);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMinkowski_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSumPWH(IntPtr pwhPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSum_SSAB(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSum_OptimalConvex(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSum_HertelMehlhorn(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSum_GreeneConvex(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSum_Vertical(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSumPWH_Vertical(IntPtr pwhPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSum_Triangle(IntPtr polyPtr1, IntPtr polyPtr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMinkowski_EIK_MinkowskiSumPWH_Triangle(IntPtr pwhPtr1, IntPtr polyPtr2);

    }
}
