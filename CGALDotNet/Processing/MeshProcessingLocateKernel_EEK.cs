using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingLocateKernel_EEK : MeshProcessingLocateKernel
    {
        internal override string Name => "EEK";

        internal static readonly MeshProcessingLocateKernel Instance = new MeshProcessingLocateKernel_EEK();

        internal override IntPtr Create()
        {
            return MeshProcessingLocate_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingLocate_EEK_Release(ptr);
        }

        //Polyhedron 

        internal override Point3d RandomLocationOnMesh_PH(IntPtr ptr)
        {
            return MeshProcessingLocate_EEK_RandomLocationOnMesh_PH(ptr);
        }

        internal override MeshHitResult LocateFaceRay_PH(IntPtr ptr, Ray3d ray)
        {
            return MeshProcessingLocate_EEK_LocateFaceRay_PH(ptr, ray);
        }

	    internal override MeshHitResult LocateFacePoint_PH(IntPtr ptr, Point3d point)
        {
            return MeshProcessingLocate_EEK_LocateFacePoint_PH(ptr, point);
        }

        //SUrfaceMesh 

        internal override Point3d RandomLocationOnMesh_SM(IntPtr ptr)
        {
            return MeshProcessingLocate_EEK_RandomLocationOnMesh_SM(ptr);
        }

        internal override MeshHitResult LocateFaceRay_SM(IntPtr ptr, Ray3d ray)
        {
            return MeshProcessingLocate_EEK_LocateFaceRay_SM(ptr, ray);
        }

        internal override MeshHitResult LocateFacePoint_SM(IntPtr ptr, Point3d point)
        {
            return MeshProcessingLocate_EEK_LocateFacePoint_SM(ptr, point);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingLocate_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingLocate_EEK_Release(IntPtr ptr);

        //Polyhedron

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point3d MeshProcessingLocate_EEK_RandomLocationOnMesh_PH(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern MeshHitResult MeshProcessingLocate_EEK_LocateFaceRay_PH(IntPtr ptr, Ray3d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern MeshHitResult MeshProcessingLocate_EEK_LocateFacePoint_PH(IntPtr ptr, Point3d point);

        //SurfaceMesh

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point3d MeshProcessingLocate_EEK_RandomLocationOnMesh_SM(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern MeshHitResult MeshProcessingLocate_EEK_LocateFaceRay_SM(IntPtr ptr, Ray3d ray);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern MeshHitResult MeshProcessingLocate_EEK_LocateFacePoint_SM(IntPtr ptr, Point3d point);
    }
}
