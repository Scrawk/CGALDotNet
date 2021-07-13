using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    public static partial class PolygonBoolean2
    {
        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_P_P(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_P_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_PWH_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_Join_P_P(IntPtr ptr1, IntPtr ptr2, out IntPtr result);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_Join_P_PWH(IntPtr ptr1, IntPtr ptr2, out IntPtr result);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_Join_PWH_PWH(IntPtr ptr1, IntPtr ptr2, out IntPtr result);
    }
}
