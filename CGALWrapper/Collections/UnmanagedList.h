#pragma once
#include "../CGALWrapper.h"

#include <vector>

extern "C"
{

	CGALWRAPPER_API void* UnmanagedList_Create();

	CGALWRAPPER_API void* UnmanagedList_CreateWithCount(int count);

	CGALWRAPPER_API void UnmanagedList_Release(void* listPtr);

	CGALWRAPPER_API void UnmanagedList_Add(void* listPtr, void* ptr);

	CGALWRAPPER_API void UnmanagedList_AddRange(void* listPtr, void** ptr_array, int count);

	CGALWRAPPER_API int UnmanagedList_Capacity(void* listPtr);

	CGALWRAPPER_API void UnmanagedList_Clear(void* listPtr);

	CGALWRAPPER_API int UnmanagedList_Count(void* listPtr);

	CGALWRAPPER_API BOOL UnmanagedList_Contains(void* listPtr, void* ptr);

	CGALWRAPPER_API void* UnmanagedList_Copy(void* listPtr);

	CGALWRAPPER_API void* UnmanagedList_Get(void* listPtr, int index);

	CGALWRAPPER_API void UnmanagedList_Set(void* listPtr, int index, void* ptr);

	CGALWRAPPER_API int UnmanagedList_IndexOf(void* listPtr, void* ptr);

	CGALWRAPPER_API void UnmanagedList_Insert(void* listPtr, void* ptr, int index);

	CGALWRAPPER_API void UnmanagedList_Remove(void* listPtr, void* ptr);

	CGALWRAPPER_API void UnmanagedList_RemoveAt(void* listPtr, int index);

	CGALWRAPPER_API void UnmanagedList_Reverse(void* listPtr);

	CGALWRAPPER_API void UnmanagedList_TrimExcess(void* listPtr);

}

class UnmanagedList
{

private:

	std::vector<void*> vec;

public:

	UnmanagedList();

	UnmanagedList(int count);

	~UnmanagedList();

	inline static UnmanagedList* CastToUnmanagedList(void* ptr)
	{
		return static_cast<UnmanagedList*>(ptr);
	}

	void Add(void* ptr);

	void AddRange(void** ptr_array, int count);

	int Capacity();

	void Clear();

	int Count();

	BOOL Contains(void* ptr);

	void* Copy();

	void* Get(int index);

	void Set(int index, void* ptr);

	int IndexOf(void* ptr);

	void Insert(void* ptr, int index);

	void Remove(void* ptr);

	void RemoveAt(int index);

	void Reverse();

	void TrimExcess();

private:

	bool InRange(int index);

	bool NotInRange(int index);

};

