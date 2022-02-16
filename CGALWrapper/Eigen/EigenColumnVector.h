#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API void* EigenColumnVector_CreateVector(int rows);

	CGALWRAPPER_API void EigenColumnVector_Release(void* ptr);

	CGALWRAPPER_API int EigenColumnVector_Dimension(void* ptr);

	CGALWRAPPER_API double EigenColumnVector_Get(void* ptr, int x);

	CGALWRAPPER_API void EigenColumnVector_Set(void* ptr, int x, double value);

	CGALWRAPPER_API double EigenColumnVector_Dot(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenColumnVector_Normalized(void* ptr);

	CGALWRAPPER_API void EigenColumnVector_Normalize(void* ptr);

	CGALWRAPPER_API double EigenColumnVector_Norm(void* ptr);

	CGALWRAPPER_API void* EigenColumnVector_Transpose(void* ptr);

	CGALWRAPPER_API void* EigenColumnVector_Adjoint(void* ptr);

	CGALWRAPPER_API void* EigenColumnVector_Conjugate(void* ptr);

	CGALWRAPPER_API void EigenColumnVector_Resize(void* ptr, int dimension);
}



