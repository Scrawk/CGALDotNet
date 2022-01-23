using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Processing
{
    internal class PolygonMeshProcessingFeaturesKernel_EEK : PolygonMeshProcessingFeaturesKernel
    {
        internal override string KernelName => "EEK";

        internal static readonly PolygonMeshProcessingFeaturesKernel Instance = new PolygonMeshProcessingFeaturesKernel_EEK();

        internal override IntPtr Create()
        {
            return PolygonMeshProcessingFeatures_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonMeshProcessingFeatures_EEK_Release(ptr);
        }

        internal override int DetectSharpEdges(IntPtr feaPtr, IntPtr polyPtr, Degree feature_angle)
        {
            return PolygonMeshProcessingFeatures_EEK_DetectSharpEdges(feaPtr, polyPtr, feature_angle.angle);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingFeatures_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingFeatures_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingFeatures_EEK_DetectSharpEdges(IntPtr feaPtr, IntPtr polyPtr, double feature_angle);

    }
}
