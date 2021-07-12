using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    public static partial class PolygonBoolean2
    {
        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect(IntPtr ptr1, IntPtr ptr2);
    }
}
