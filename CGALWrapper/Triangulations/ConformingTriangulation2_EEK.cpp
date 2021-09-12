#pragma once
#include "../pch.h"
#include "../Utility/Util.h"
#include "ConformingTriangulation2_EEK.h"
#include "ConformingTriangulation2.h"

void* ConformingTriangulation2_EEK_Create()
{
	return Util::Create<ConformingTriangulation2<EEK>>();
}

void ConformingTriangulation2_EEK_Release(void* ptr)
{
	Util::Release<ConformingTriangulation2<EEK>>(ptr);
}

void ConformingTriangulation2_EEK_MakeConforming(Point2d* points, int startIndex, int count)
{
	ConformingTriangulation2<EEK>::MakeConforming(points, startIndex, count);
}
