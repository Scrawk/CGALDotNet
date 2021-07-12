#pragma once

template<class T>
void* Util_Create()
{
	return new T();
}

template<class T>
void Util_Release(void* ptr)
{
	auto obj = (T*)ptr;

	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}
