using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonVisibilityKernel_EEK : PolygonVisibilityKernel
    {
        internal static readonly PolygonVisibilityKernel Instance = new PolygonVisibilityKernel_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return PolygonVisibility_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonVisibility_EEK_Release(ptr);
        }

        internal override void Test()
        {
            PolygonVisibility_EEK_Test();
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonVisibility_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonVisibility_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonVisibility_EEK_Test();
    }
}
