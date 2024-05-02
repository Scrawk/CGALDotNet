#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Index.h"

extern "C"
{

	CGALWRAPPER_API int CGALGlobal_VersionNumber();

	CGALWRAPPER_API Index3 CGALGlobal_EigenVersionNumber();

}
