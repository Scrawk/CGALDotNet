using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingSlicerKernel_EEK : PolygonMeshProcessingSlicerKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingSlicerKernel Instance = new PolygonMeshProcessingSlicerKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingSlicer_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingSlicer_EEK_Release(ptr);
        }

        internal override void GetLines(IntPtr slicerPtr, IntPtr[] lines, int count)
        {
            PolygonMeshProcessingSlicer_EEK_GetLines(slicerPtr, lines, count);
        }

        internal override int Slice(IntPtr slicerPtr, IntPtr polyPtr, Plane3d plane, bool useTree)
        {
            return PolygonMeshProcessingSlicer_EEK_Polyhedron_Slice(slicerPtr, polyPtr, plane, useTree);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingSlicer_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingSlicer_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingSlicer_EEK_GetLines(IntPtr slicerPtr, IntPtr[] lines, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingSlicer_EEK_Polyhedron_Slice(IntPtr slicerPtr, IntPtr polyPtr, Plane3d plane, bool useTree);
    }
}
