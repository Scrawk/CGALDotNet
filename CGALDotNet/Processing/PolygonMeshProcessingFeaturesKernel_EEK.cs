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

        //Polyhedron

        internal override int DetectSharpEdges_PH(IntPtr feaPtr, IntPtr meshPtr, double feature_angle)
        {
            return PolygonMeshProcessingFeatures_EEK_DetectSharpEdges_PH(feaPtr, meshPtr, feature_angle);
        }

        internal override void GetSharpEdges_PH(IntPtr feaPtr, IntPtr meshPtr, int[] indices, int count)
        {
            PolygonMeshProcessingFeatures_EEK_GetSharpEdges_PH(feaPtr, meshPtr, indices, count);
        }

        internal override Index2 SharpEdgesSegmentation_PH(IntPtr feaPtr, IntPtr meshPtr, double feature_angle)
        {
            return PolygonMeshProcessingFeatures_EEK_SharpEdgesSegmentation_PH(feaPtr, meshPtr, feature_angle);
        }

        internal override void ClearPatchBuffer_PH(IntPtr feaPtr)
        {
            PolygonMeshProcessingFeatures_EEK_ClearPatchBuffer_PH(feaPtr);
        }

        internal override int GetPatchBufferFaceCount_PH(IntPtr feaPtr, int patchIndex)
        {
            return PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceCount_PH(feaPtr, patchIndex);
        }

        internal override int GetPatchBufferFaceIndex_PH(IntPtr feaPtr, int patchIndex, int faceIndex)
        {
            return PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceIndex_PH(feaPtr, patchIndex, faceIndex);
        }

        //Surface Mesh

        internal override int DetectSharpEdges_SM(IntPtr feaPtr, IntPtr meshPtr, double feature_angle)
        {
            return PolygonMeshProcessingFeatures_EEK_DetectSharpEdges_SM(feaPtr, meshPtr, feature_angle);
        }

        internal override void GetSharpEdges_SM(IntPtr feaPtr, IntPtr meshPtr, int[] indices, int count)
        {
            PolygonMeshProcessingFeatures_EEK_GetSharpEdges_SM(feaPtr, meshPtr, indices, count);
        }

        internal override Index2 SharpEdgesSegmentation_SM(IntPtr feaPtr, IntPtr meshPtr, double feature_angle)
        {
            return PolygonMeshProcessingFeatures_EEK_SharpEdgesSegmentation_SM(feaPtr, meshPtr, feature_angle);
        }

        internal override void ClearPatchBuffer_SM(IntPtr feaPtr)
        {
            PolygonMeshProcessingFeatures_EEK_ClearPatchBuffer_SM(feaPtr);
        }

        internal override int GetPatchBufferFaceCount_SM(IntPtr feaPtr, int patchIndex)
        {
            return PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceCount_SM(feaPtr, patchIndex);
        }

        internal override int GetPatchBufferFaceIndex_SM(IntPtr feaPtr, int patchIndex, int faceIndex)
        {
            return PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceIndex_SM(feaPtr, patchIndex, faceIndex);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonMeshProcessingFeatures_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingFeatures_EEK_Release(IntPtr ptr);

        //Polyhedron
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingFeatures_EEK_DetectSharpEdges_PH(IntPtr feaPtr, IntPtr meshPtr, double feature_angle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingFeatures_EEK_GetSharpEdges_PH(IntPtr feaPtr, IntPtr meshPtr, [Out] int[] indices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Index2 PolygonMeshProcessingFeatures_EEK_SharpEdgesSegmentation_PH(IntPtr feaPtr, IntPtr meshPtr, double feature_angle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingFeatures_EEK_ClearPatchBuffer_PH(IntPtr feaPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceCount_PH(IntPtr feaPtr, int patchIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceIndex_PH(IntPtr feaPtr, int patchIndex, int faceIndex);

        //Surface Mesh
        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingFeatures_EEK_DetectSharpEdges_SM(IntPtr feaPtr, IntPtr meshPtr, double feature_angle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingFeatures_EEK_GetSharpEdges_SM(IntPtr feaPtr, IntPtr meshPtr, [Out] int[] indices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Index2 PolygonMeshProcessingFeatures_EEK_SharpEdgesSegmentation_SM(IntPtr feaPtr, IntPtr meshPtr, double feature_angle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonMeshProcessingFeatures_EEK_ClearPatchBuffer_SM(IntPtr feaPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceCount_SM(IntPtr feaPtr, int patchIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonMeshProcessingFeatures_EEK_GetPatchBufferFaceIndex_SM(IntPtr feaPtr, int patchIndex, int faceIndex);

    }
}
