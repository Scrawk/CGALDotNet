using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonOffsetKernel2_EEK : PolygonOffsetKernel2
    {
        internal static readonly PolygonOffsetKernel2 Instance = new PolygonOffsetKernel2_EEK();

        internal override string Name => "EEK";

        internal override IntPtr Create()
        {
            return PolygonOffset2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonOffset2_EEK_Release(ptr);
        }

        internal override int PolygonBufferSize(IntPtr ptr)
        {
            return PolygonOffset2_EEK_PolygonBufferSize(ptr);
        }

        internal override void ClearPolygonBuffer(IntPtr ptr)
        {
            PolygonOffset2_EEK_ClearPolygonBuffer(ptr);
        }

        internal override IntPtr GetBufferedPolygon(IntPtr ptr, int index)
        {
            return PolygonOffset2_EEK_GetBufferedPolygon(ptr, index);
        }

        internal override void CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset)
        {
            PolygonOffset2_EEK_CreateInteriorOffset(ptr, polyPtr, offset);
        }

        internal override void CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset)
        {
            PolygonOffset2_EEK_CreateExteriorOffset(ptr, polyPtr, offset);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonOffset2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonOffset2_EEK_PolygonBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_ClearPolygonBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonOffset2_EEK_GetBufferedPolygon(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EEK_CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

    }
}
