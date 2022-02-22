using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polygons
{
    internal class PolygonSimplificationKernel2_EIK : PolygonSimplificationKernel2
    {
        internal override string Name => "EIK";

        internal static readonly PolygonSimplificationKernel2 Instance = new PolygonSimplificationKernel2_EIK();

        internal override IntPtr Create()
        {
            return PolygonSimplification2_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonSimplification2_EIK_Release(ptr);
        }

        internal override IntPtr SimplifyPolygon(IntPtr polyPtr, PolygonSimplificationParams param)
        {
            return PolygonSimplification2_EIK_Simplify(polyPtr, param.cost, param.stop, param.threshold);
        }

        internal override IntPtr SimplifyPolygonWithHoles_All(IntPtr pwhPtr, PolygonSimplificationParams param)
        {
            return PolygonSimplification2_EIK_SimplifyPolygonWithHoles_All(pwhPtr, param.cost, param.stop, param.threshold);
        }

        internal override IntPtr SimplifyPolygonWithHoles_Boundary(IntPtr pwhPtr, PolygonSimplificationParams param)
        {
            return PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Boundary(pwhPtr, param.cost, param.stop, param.threshold);
        }

        internal override IntPtr SimplifyPolygonWithHoles_Holes(IntPtr pwhPtr, PolygonSimplificationParams param)
        {
            return PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Holes(pwhPtr, param.cost, param.stop, param.threshold);
        }

        internal override IntPtr SimplifyPolygonWithHoles_Hole(IntPtr pwhPtr, PolygonSimplificationParams param, int index)
        {
            return PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Hole(pwhPtr, param.cost, param.stop, param.threshold, index);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonSimplification2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EIK_Simplify(IntPtr polyPtr, POLYGON_SIMP_COST_FUNC cost, POLYGON_SIMP_STOP_FUNC stop, double theshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EIK_SimplifyPolygonWithHoles_All(IntPtr pwhPtr, POLYGON_SIMP_COST_FUNC cost, POLYGON_SIMP_STOP_FUNC stop, double theshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Boundary(IntPtr pwhPtr, POLYGON_SIMP_COST_FUNC cost, POLYGON_SIMP_STOP_FUNC stop, double theshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Holes(IntPtr pwhPtr, POLYGON_SIMP_COST_FUNC cost, POLYGON_SIMP_STOP_FUNC stop, double theshold);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonSimplification2_EIK_SimplifyPolygonWithHoles_Hole(IntPtr pwhPtr, POLYGON_SIMP_COST_FUNC cost, POLYGON_SIMP_STOP_FUNC stop, double theshold, int index);
    }
}
