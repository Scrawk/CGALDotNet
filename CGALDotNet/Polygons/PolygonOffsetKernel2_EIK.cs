using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonOffsetKernel2_EIK : PolygonOffsetKernel2
    {

        internal static readonly PolygonOffsetKernel2 Instance = new PolygonOffsetKernel2_EIK();

        internal override string Name => "EIK";

        internal override IntPtr Create()
        {
            return PolygonOffset2_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonOffset2_EIK_Release(ptr);
        }

        internal override int PolygonBufferSize(IntPtr ptr)
        {
            return PolygonOffset2_EIK_PolygonBufferSize(ptr);
        }

        internal override void ClearPolygonBuffer(IntPtr ptr)
        {
            PolygonOffset2_EIK_ClearPolygonBuffer(ptr);
        }

        internal override IntPtr GetBufferedPolygon(IntPtr ptr, int index)
        {
            return PolygonOffset2_EIK_GetBufferedPolygon(ptr, index);
        }

        internal override void CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset)
        {
            PolygonOffset2_EIK_CreateInteriorOffset(ptr, polyPtr, offset);
        }

        internal override void CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset)
        {
            PolygonOffset2_EIK_CreateExteriorOffset(ptr, polyPtr, offset);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonOffset2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonOffset2_EIK_PolygonBufferSize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_ClearPolygonBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonOffset2_EIK_GetBufferedPolygon(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonOffset2_EIK_CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

    }
}
