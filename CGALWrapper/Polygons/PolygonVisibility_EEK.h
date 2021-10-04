#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include <CGAL/enum.h>

extern "C"
{
	CGALWRAPPER_API void* PolygonVisibility_EEK_Create();

	CGALWRAPPER_API void PolygonVisibility_EEK_Release(void* ptr);

	CGALWRAPPER_API void PolygonVisibility_EEK_Test();

}

