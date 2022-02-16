#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API void* EigenRowVector_CreateVector(int columns);

	CGALWRAPPER_API void EigenRowVector_Release(void* ptr);

	CGALWRAPPER_API int EigenRowVector_Dimension(void* ptr);

	CGALWRAPPER_API double EigenRowVector_Get(void* ptr, int x);

	CGALWRAPPER_API void EigenRowVector_Set(void* ptr, int x, double value);

	CGALWRAPPER_API double EigenRowVector_Dot(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenRowVector_Normalized(void* ptr);

	CGALWRAPPER_API void EigenRowVector_Normalize(void* ptr);

	CGALWRAPPER_API double EigenRowVector_Norm(void* ptr);

	CGALWRAPPER_API void* EigenRowVector_Transpose(void* ptr);

	CGALWRAPPER_API void* EigenRowVector_Adjoint(void* ptr);

	CGALWRAPPER_API void* EigenRowVector_Conjugate(void* ptr);

	CGALWRAPPER_API void EigenRowVector_Resize(void* ptr, int dimension);
}



