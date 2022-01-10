#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

template<class K>
class TetrahedralRemeshing
{

public:

	inline static TetrahedralRemeshing* NewTetrahedralRemeshing()
	{
		return new TetrahedralRemeshing();
	}

	inline static void DeleteTetrahedralRemeshing(void* ptr)
	{
		auto obj = static_cast<TetrahedralRemeshing*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static TetrahedralRemeshing* CastToTetrahedralRemeshing(void* ptr)
	{
		return static_cast<TetrahedralRemeshing*>(ptr);
	}

};
