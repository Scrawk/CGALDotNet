#pragma once
#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "ConformingTriangulation2.h"

extern "C"
{
	CGALWRAPPER_API void* ConformingTriangulation2_EEK_Create();

	CGALWRAPPER_API void ConformingTriangulation2_EEK_Release(void* ptr);

	CGALWRAPPER_API void ConformingTriangulation2_EEK_MakeConforming(Point2d* points, int startIndex, int count);

}

