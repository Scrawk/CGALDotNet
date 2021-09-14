using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonSimplificationKernel2_EEK : PolygonSimplificationKernel2
    {
        private const string DLL_NAME = "CGALWrapper.dll";

        private const CallingConvention CDECL = CallingConvention.Cdecl;

        internal static readonly PolygonSimplificationKernel2 Instance = new PolygonSimplificationKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return PolygonSimplification2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonSimplification2_EEK_Release(ptr);
        }

        internal override IntPtr SimplifyPolygon(IntPtr polyPtr, PolygonSimplificationParams param)
        {
            return PolygonSimplification2_EEK_Simplify(polyPtr, param.cost, param.stop, param.threshold);
        }

        internal override IntPtr SimplifyPolygonWithHoles(IntPtr pwhPtr, PolygonSimplificationParams param)
        {
            return PolygonSimplification2_EEK_SimplifyPolygonWithHoles(pwhPtr, param.cost, param.stop, param.threshold, param.elements);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonSimplification2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EEK_Simplify(IntPtr polyPtr, POLYGON_SIMP_COST_FUNC cost, POLYGON_SIMP_STOP_FUNC stop, double theshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EEK_SimplifyPolygonWithHoles(IntPtr pwhPtr, POLYGON_SIMP_COST_FUNC cost, POLYGON_SIMP_STOP_FUNC stop, double theshold, POLYGON_ELEMENT element);
    }
}
