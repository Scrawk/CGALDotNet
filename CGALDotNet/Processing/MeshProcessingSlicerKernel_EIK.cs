using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingSlicerKernel_EIK : MeshProcessingSlicerKernel
    {
        internal override string Name => "EIK";

        internal static readonly MeshProcessingSlicerKernel Instance = new MeshProcessingSlicerKernel_EIK();

        internal override IntPtr Create()
        {
            return MeshProcessingSlicer_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingSlicer_EIK_Release(ptr);
        }

        internal override void GetLines(IntPtr slicerPtr, IntPtr[] lines, int count)
        {
            MeshProcessingSlicer_EIK_GetLines(slicerPtr, lines, count);
        }

        //Polyhedron
        internal override int Slice_PH(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree)
        {
            return MeshProcessingSlicer_EIK_Slice_PH(slicerPtr, meshPtr, plane, useTree);
        }

        internal override int IncrementalSlice_PH(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment)
        {
            return MeshProcessingSlicer_EIK_IncrementalSlice_PH(slicerPtr, meshPtr, start, end, increment);
        }

        //Surface Mesh
        internal override int Slice_SM(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree)
        {
            return MeshProcessingSlicer_EIK_Slice_SM(slicerPtr, meshPtr, plane, useTree);
        }

        internal override int IncrementalSlice_SM(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment)
        {
            return MeshProcessingSlicer_EIK_IncrementalSlice_SM(slicerPtr, meshPtr, start, end, increment);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingSlicer_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingSlicer_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingSlicer_EIK_GetLines(IntPtr slicerPtr, IntPtr[] lines, int count);

        //Polyhedron
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EIK_Slice_PH(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EIK_IncrementalSlice_PH(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment);

        //SurfaceMesh
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EIK_Slice_SM(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int MeshProcessingSlicer_EIK_IncrementalSlice_SM(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment);
    }
}
