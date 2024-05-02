#pragma once
#include "../CGALWrapper.h"

#include <vector>

extern "C"
{

	CGALWRAPPER_API void* NativeList_Create();

	CGALWRAPPER_API void* NativeList_CreateWithCount(int count);

	CGALWRAPPER_API void NativeList_Release(void* listPtr);

	CGALWRAPPER_API void NativeList_Add(void* listPtr, void* ptr);

	CGALWRAPPER_API void NativeList_AddRange(void* listPtr, void** ptr_array, int count);

	CGALWRAPPER_API int NativeList_Capacity(void* listPtr);

	CGALWRAPPER_API void NativeList_Clear(void* listPtr);

	CGALWRAPPER_API int NativeList_Count(void* listPtr);

	CGALWRAPPER_API BOOL NativeList_Contains(void* listPtr, void* ptr);

	CGALWRAPPER_API void* NativeList_Copy(void* listPtr);

	CGALWRAPPER_API void* NativeList_Get(void* listPtr, int index);

	CGALWRAPPER_API void NativeList_Set(void* listPtr, int index, void* ptr);

	CGALWRAPPER_API int NativeList_IndexOf(void* listPtr, void* ptr);

	CGALWRAPPER_API void NativeList_Insert(void* listPtr, void* ptr, int index);

	CGALWRAPPER_API BOOL NativeList_Remove(void* listPtr, void* ptr);

	CGALWRAPPER_API void NativeList_RemoveAt(void* listPtr, int index);

	CGALWRAPPER_API void NativeList_Reverse(void* listPtr);

	CGALWRAPPER_API void NativeList_TrimExcess(void* listPtr);

}

class NativeList
{

private:

	std::vector<void*> vec;

public:

	NativeList();

	NativeList(int count);

	~NativeList();

	inline static NativeList* CastToNativeList(void* ptr)
	{
		return static_cast<NativeList*>(ptr);
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

