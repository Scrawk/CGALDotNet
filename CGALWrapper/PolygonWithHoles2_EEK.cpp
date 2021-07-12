#include "pch.h"
#include "Util.h"
#include "PolygonWithHoles2_EEK.h"

void* PolygonWithHoles2_EEK_Create()
{
	return Util_Create<PolygonWithHoles2_EEK>();
}

void PolygonWithHoles2_EEK_Release(void* ptr)
{
	Util_Release<PolygonWithHoles2_EEK>(ptr);
}
