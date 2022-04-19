using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Processing
{
    internal class HeatMethodKernel_EEK : HeatMethodKernel
    {
        internal override string Name => "EEK";

        internal static readonly HeatMethodKernel Instance = new HeatMethodKernel_EEK();

        internal override IntPtr Create()
        {
            return HeatMethod_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            HeatMethod_EEK_Release(ptr);
        }

        internal override double GetDistance(IntPtr ptr, int index)
        {
            return HeatMethod_EEK_GetDistance(ptr, index);  
        }

        internal override void ClearDistances(IntPtr ptr)
        {
            HeatMethod_EEK_ClearDistances(ptr);  
        }

        internal override int EstimateGeodesicDistances_SM(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT)
        {
            return HeatMethod_EEK_EstimateGeodesicDistances_SM(ptr, meshPtr, vertexIndex, useIDT);
        }

        internal override int EstimateGeodesicDistances_PH(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT)
        {
            return HeatMethod_EEK_EstimateGeodesicDistances_PH(ptr, meshPtr, vertexIndex, useIDT);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr HeatMethod_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void HeatMethod_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double HeatMethod_EEK_GetDistance(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void HeatMethod_EEK_ClearDistances(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int HeatMethod_EEK_EstimateGeodesicDistances_SM(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int HeatMethod_EEK_EstimateGeodesicDistances_PH(IntPtr ptr, IntPtr meshPtr, int vertexIndex, bool useIDT);
    }
}
