using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingSlicerKernel_EEK : MeshProcessingSlicerKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly MeshProcessingSlicerKernel Instance = new MeshProcessingSlicerKernel_EEK();

        internal override IntPtr Create()
        {
            return MeshProcessingSlicer_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingSlicer_EEK_Release(ptr);
        }

        internal override void GetLines(IntPtr slicerPtr, IntPtr[] lines, int count)
        {
            MeshProcessingSlicer_EEK_GetLines(slicerPtr, lines, count);
        }

        internal override int Slice(IntPtr slicerPtr, IntPtr polyPtr, Plane3d plane, bool useTree)
        {
            return MeshProcessingSlicer_EEK_Polyhedron_Slice(slicerPtr, polyPtr, plane, useTree);
        }

        internal override int Slice(IntPtr slicerPtr, IntPtr polyPtr, Point3d start, Point3d end, double increment)
        {
            return MeshProcessingSlicer_EEK_Polyhedron_IncrementalSlice(slicerPtr, polyPtr, start, end, increment);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingSlicer_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingSlicer_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingSlicer_EEK_GetLines(IntPtr slicerPtr, IntPtr[] lines, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EEK_Polyhedron_Slice(IntPtr slicerPtr, IntPtr polyPtr, Plane3d plane, bool useTree);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EEK_Polyhedron_IncrementalSlice(IntPtr slicerPtr, IntPtr polyPtr, Point3d start, Point3d end, double increment);
    }
}
