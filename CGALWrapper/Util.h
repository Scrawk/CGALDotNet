#pragma once

namespace Util
{

	template<class T>
	void* Create()
	{
		return new T();
	}

	template<class T>
	void Release(void* ptr)
	{
		auto obj = (T*)ptr;

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

}
