#pragma once

#include "../CGALWrapper.h"

extern "C"
{
	CGALWRAPPER_API void* MeshProcessingOrientation_EIK_Create();

	CGALWRAPPER_API void MeshProcessingOrientation_EIK_Release(void* ptr);

	//Polyhedron

	CGALWRAPPER_API BOOL MeshProcessingOrientation_EIK_DoesBoundAVolume_PH(void* meshPtr);

	CGALWRAPPER_API BOOL MeshProcessingOrientation_EIK_IsOutwardOriented_PH(void* meshPtr);

	CGALWRAPPER_API void MeshProcessingOrientation_EIK_Orient_PH(void* meshPtr);

	CGALWRAPPER_API void MeshProcessingOrientation_EIK_OrientToBoundAVolume_PH(void* meshPtr);

	CGALWRAPPER_API void MeshProcessingOrientation_EIK_ReverseFaceOrientations_PH(void* meshPtr);

	//Surface Mesh

	CGALWRAPPER_API BOOL MeshProcessingOrientation_EIK_DoesBoundAVolume_SM(void* meshPtr);

	CGALWRAPPER_API BOOL MeshProcessingOrientation_EIK_IsOutwardOriented_SM(void* meshPtr);

	CGALWRAPPER_API void MeshProcessingOrientation_EIK_Orient_SM(void* meshPtr);

	CGALWRAPPER_API void MeshProcessingOrientation_EIK_OrientToBoundAVolume_SM(void* meshPtr);

	CGALWRAPPER_API void MeshProcessingOrientation_EIK_ReverseFaceOrientations_SM(void* meshPtr);

}

