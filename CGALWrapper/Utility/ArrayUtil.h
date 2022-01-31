#pragma once
#include "../CGALWrapper.h"

namespace ArrayUtil
{
	static void FillWithNull(int* indices, int count)
	{
		if (count <= 0) return;
		if (indices == nullptr) return;

		for (int i = 0; i < count; i++)
			indices[i] = NULL_INDEX;
	}

	static void MakeOutOfBoundsNull(int* indices, int count, int len)
	{
		if (count <= 0) return;
		if (indices == nullptr) return;

		for (int i = 0; i < count; i++)
		{
			if(indices[i] < NULL_INDEX || indices[i] >= len)
				indices[i] = NULL_INDEX;
		}
			
	}
}