using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Processing
{
    internal class HeatMethodKernel_EIK : HeatMethodKernel
    {
        internal override string Name => "EIK";

        internal static readonly HeatMethodKernel Instance = new HeatMethodKernel_EIK();

        internal override IntPtr Create()
        {
            return HeatMethod_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            HeatMethod_EIK_Release(ptr);
        }

        internal override double GetDistance(IntPtr ptr, int index)
        {
            return HeatMethod_EIK_GetDistance(ptr, index);
        }

        internal override void ClearDistances(IntPtr ptr)
        {
            HeatMethod_EIK_ClearDistances(ptr);
        }

        internal override int EstimateGeodesicDistances_SM(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT)
        {
            return HeatMethod_EIK_EstimateGeodesicDistances_SM(ptr, meshPtr, vertexIndex, useIDT);
        }

        internal override int EstimateGeodesicDistances_PH(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT)
        {
            return HeatMethod_EIK_EstimateGeodesicDistances_PH(ptr, meshPtr, vertexIndex, useIDT);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr HeatMethod_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void HeatMethod_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double HeatMethod_EIK_GetDistance(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void HeatMethod_EIK_ClearDistances(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int HeatMethod_EIK_EstimateGeodesicDistances_SM(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int HeatMethod_EIK_EstimateGeodesicDistances_PH(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT);
    }
}
