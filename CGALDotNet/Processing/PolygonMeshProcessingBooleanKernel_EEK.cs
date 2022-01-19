using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingBooleanKernel_EEK : PolygonMeshProcessingBooleanKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingBooleanKernel Instance = new PolygonMeshProcessingBooleanKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingBoolean_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingBoolean_EEK_Release(ptr);
        }

        internal override bool PolyhedronUnion(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr)
        {
            return PolygonMeshProcessingBoolean_EEK_PolyhedronUnion(polyPtr1, polyPtr2, out resultPtr);
        }

        internal override bool PolyhedronDifference(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr)
        {
            return PolygonMeshProcessingBoolean_EEK_PolyhedronDifference(polyPtr1, polyPtr2, out resultPtr);
        }

        internal override bool PolyhedronIntersection(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr)
        {
            return PolygonMeshProcessingBoolean_EEK_PolyhedronIntersection(polyPtr1, polyPtr2, out resultPtr);
        }

        internal override bool PolyhedronClip(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr)
        {
            return PolygonMeshProcessingBoolean_EEK_PolyhedronClip(polyPtr1, polyPtr2, out resultPtr);
        }

        internal override bool PlaneClip(IntPtr polyPtr1, Plane3d plane, out IntPtr resultPtr)
        {
            return PolygonMeshProcessingBoolean_EEK_PlaneClip(polyPtr1, plane, out resultPtr);
        }

        internal override bool BoxClip(IntPtr polyPtr1, Box3d box, out IntPtr resultPtr)
        {
            return PolygonMeshProcessingBoolean_EEK_BoxClip(polyPtr1, box, out resultPtr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingBoolean_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingBoolean_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingBoolean_EEK_PolyhedronUnion(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingBoolean_EEK_PolyhedronDifference(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingBoolean_EEK_PolyhedronIntersection(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingBoolean_EEK_PolyhedronClip(IntPtr polyPtr1, IntPtr polyPtr2, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingBoolean_EEK_PlaneClip(IntPtr polyPtr1, Plane3d plane, out IntPtr resultPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonMeshProcessingBoolean_EEK_BoxClip(IntPtr polyPtr1, Box3d box, out IntPtr resultPtr);
    }
}
