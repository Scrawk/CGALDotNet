using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Processing
{
    internal class MeshProcessingBooleanKernel_EEK : MeshProcessingBooleanKernel
    {
        internal override string Name => "EEK";

        internal static readonly MeshProcessingBooleanKernel Instance = new MeshProcessingBooleanKernel_EEK();

        internal override IntPtr Create()
        {
            return MeshProcessingBoolean_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            MeshProcessingBoolean_EEK_Release(ptr);
        }

        //Polyhedron

        internal override bool Union_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_Union_PH(meshPtr1, meshPtr2, out resultPtr);
        }

        internal override bool Difference_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_Difference_PH(meshPtr1, meshPtr2, out resultPtr);
        }

        internal override bool Intersection_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_Intersection_PH(meshPtr1, meshPtr2, out resultPtr);
        }

        internal override bool Clip_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_Clip_PH(meshPtr1, meshPtr2, out resultPtr);
        }

        internal override bool PlaneClip_PH(IntPtr meshPtr1, Plane3d plane, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_PlaneClip_PH(meshPtr1, plane, out resultPtr);
        }

        internal override bool BoxClip_PH(IntPtr meshPtr1, Box3d box, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_BoxClip_PH(meshPtr1, box, out resultPtr);
        }

        //Surface Mesh

        internal override bool Union_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_Union_SM(meshPtr1, meshPtr2, out resultPtr);
        }

        internal override bool Difference_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_Difference_SM(meshPtr1, meshPtr2, out resultPtr);
        }

        internal override bool Intersection_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_Intersection_SM(meshPtr1, meshPtr2, out resultPtr);
        }

        internal override bool Clip_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_Clip_SM(meshPtr1, meshPtr2, out resultPtr);
        }

        internal override bool PlaneClip_SM(IntPtr meshPtr1, Plane3d plane, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_PlaneClip_SM(meshPtr1, plane, out resultPtr);
        }

        internal override bool BoxClip_SM(IntPtr meshPtr1, Box3d box, out IntPtr resultPtr)
        {
            return MeshProcessingBoolean_EEK_BoxClip_SM(meshPtr1, box, out resultPtr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr MeshProcessingBoolean_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void MeshProcessingBoolean_EEK_Release(IntPtr ptr);

        //Polyhedron

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_Union_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_Difference_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_Intersection_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_Clip_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_PlaneClip_PH(IntPtr meshPtr1, Plane3d plane, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_BoxClip_PH(IntPtr meshPtr1, Box3d box, out IntPtr resultPtr);

        //Surface Mesh

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_Union_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_Difference_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_Intersection_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_Clip_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_PlaneClip_SM(IntPtr meshPtr1, Plane3d plane, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool MeshProcessingBoolean_EEK_BoxClip_SM(IntPtr meshPtr1, Box3d box, out IntPtr resultPtr);
    }
}
