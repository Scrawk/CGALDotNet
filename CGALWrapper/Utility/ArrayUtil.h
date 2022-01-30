#pragma once
#include "../CGALWrapper.h"

namespace ArrayUtil
{
	static void FillWithNull(int* indices, int count)
	{
		for (int i = 0; i < count; i++)
			indices[i] = NULL_INDEX;
	}
}