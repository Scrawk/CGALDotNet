using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingSlicerKernel_EEK : MeshProcessingSlicerKernel
    {
        internal override string Name => "EEK";

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

        //Polyhedron
        internal override int Slice_PH(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree)
        {
            return MeshProcessingSlicer_EEK_Slice_PH(slicerPtr, meshPtr, plane, useTree);
        }

        internal override int IncrementalSlice_PH(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment)
        {
            return MeshProcessingSlicer_EEK_IncrementalSlice_PH(slicerPtr, meshPtr, start, end, increment);
        }

        //Surface Mesh
        internal override int Slice_SM(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree)
        {
            return MeshProcessingSlicer_EEK_Slice_SM(slicerPtr, meshPtr, plane, useTree);
        }

        internal override int IncrementalSlice_SM(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment)
        {
            return MeshProcessingSlicer_EEK_IncrementalSlice_SM(slicerPtr, meshPtr, start, end, increment);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingSlicer_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingSlicer_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingSlicer_EEK_GetLines(IntPtr slicerPtr, IntPtr[] lines, int count);

        //Polyhedron
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EEK_Slice_PH(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EEK_IncrementalSlice_PH(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment);

        //SurfaceMesh
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EEK_Slice_SM(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EEK_IncrementalSlice_SM(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment);
    }
}
