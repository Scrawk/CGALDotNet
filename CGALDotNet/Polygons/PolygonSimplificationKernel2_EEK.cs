using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonSimplificationKernel2_EEK : PolygonSimplificationKernel2
    {

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

        internal override IntPtr SimplifyPolygon(IntPtr polyPtr, double theshold)
        {
            return PolygonSimplification2_EEK_Simplify(polyPtr, theshold);
        }

        internal override IntPtr SimplifyPolygonWithHoles(IntPtr pwhPtr, double theshold)
        {
            return PolygonSimplification2_EEK_SimplifyPolygonWithHoles(pwhPtr, theshold);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonSimplification2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonSimplification2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonSimplification2_EEK_Simplify(IntPtr polyPtr, double theshold);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonSimplification2_EEK_SimplifyPolygonWithHoles(IntPtr pwhPtr, double theshold);
    }
}
