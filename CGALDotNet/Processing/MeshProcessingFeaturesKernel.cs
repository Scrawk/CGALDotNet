using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Processing
{
	internal abstract class MeshProcessingFeaturesKernel : CGALObjectKernel
	{
		internal abstract IntPtr Create();

		internal abstract void Release(IntPtr ptr);

		//Polyhedron

		internal abstract int DetectSharpEdges_PH(IntPtr feaPtr, IntPtr meshPtr, double feature_angle);

		internal abstract void GetSharpEdges_PH(IntPtr feaPtr, IntPtr meshPtr, int[] indices, int count);

		internal abstract Index2 SharpEdgesSegmentation_PH(IntPtr feaPtr, IntPtr meshPtr, double feature_angle);

		internal abstract void ClearPatchBuffer_PH(IntPtr feaPtr);

		internal abstract int GetPatchBufferFaceCount_PH(IntPtr feaPtr, int patchIndex);

		internal abstract int GetPatchBufferFaceIndex_PH(IntPtr feaPtr, int patchIndex, int faceIndex);

		internal abstract MinMaxAvg EdgeLengthMinMaxAvg_PH(IntPtr ptr);

		internal abstract MinMaxAvg FaceAreaMinMaxAvg_PH(IntPtr ptr);

		//Surface Mesh

		internal abstract int DetectSharpEdges_SM(IntPtr feaPtr, IntPtr meshPtr, double feature_angle);

		internal abstract void GetSharpEdges_SM(IntPtr feaPtr, IntPtr meshPtr, int[] indices, int count);

		internal abstract Index2 SharpEdgesSegmentation_SM(IntPtr feaPtr, IntPtr meshPtr, double feature_angle);

		internal abstract void ClearPatchBuffer_SM(IntPtr feaPtr);

		internal abstract int GetPatchBufferFaceCount_SM(IntPtr feaPtr, int patchIndex);

		internal abstract int GetPatchBufferFaceIndex_SM(IntPtr feaPtr, int patchIndex, int faceIndex);

		internal abstract MinMaxAvg EdgeLengthMinMaxAvg_SM(IntPtr ptr);

		internal abstract MinMaxAvg FaceAreaMinMaxAvg_SM(IntPtr ptr);

	}
}
