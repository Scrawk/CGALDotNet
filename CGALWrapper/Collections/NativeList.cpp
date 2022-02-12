#include "NativeList.h"

#include <algorithm>

void* NativeList_Create()
{
	return new NativeList();
}

void* NativeList_CreateWithCount(int count)
{
	return new NativeList(count);
}

void NativeList_Release(void* listPtr)
{
	auto obj = static_cast<NativeList*>(listPtr);

	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

void NativeList_Add(void* listPtr, void* ptr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	list->Add(ptr);
}

void NativeList_AddRange(void* listPtr, void** ptr_array, int count)
{
	auto list = NativeList::CastToNativeList(listPtr);
	list->AddRange(ptr_array, count);
}

int NativeList_Capacity(void* listPtr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	return list->Capacity();
}

void NativeList_Clear(void* listPtr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	list->Clear();
}

int NativeList_Count(void* listPtr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	return list->Count();
}

BOOL NativeList_Contains(void* listPtr, void* ptr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	return list->Contains(ptr);
}

void* NativeList_Copy(void* listPtr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	return list->Copy();
}

void* NativeList_Get(void* listPtr, int index)
{
	auto list = NativeList::CastToNativeList(listPtr);
	return list->Get(index);
}

void NativeList_Set(void* listPtr, int index, void* ptr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	list->Set(index, ptr);
}

int NativeList_IndexOf(void* listPtr, void* ptr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	return list->IndexOf(ptr);
}

void NativeList_Insert(void* listPtr, void* ptr, int index)
{
	auto list = NativeList::CastToNativeList(listPtr);
	list->Insert(ptr, index);
}

BOOL NativeList_Remove(void* listPtr, void* ptr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	int before = list->Count();
	list->Remove(ptr);
	return list->Count() == before - 1;
}

void NativeList_RemoveAt(void* listPtr, int index)
{
	auto list = NativeList::CastToNativeList(listPtr);
	list->RemoveAt(index);
}

void NativeList_Reverse(void* listPtr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	list->Reverse();
}

void NativeList_TrimExcess(void* listPtr)
{
	auto list = NativeList::CastToNativeList(listPtr);
	list->TrimExcess();
}



NativeList::NativeList()
{

}

NativeList::NativeList(int count)
{
	vec.reserve(count);
}

NativeList::~NativeList()
{

}

void NativeList::Add(void* ptr)
{
	vec.push_back(ptr);
}

void NativeList::AddRange(void** ptr_array, int count)
{
	vec.insert(vec.end(), ptr_array, ptr_array + count);
}

int NativeList::Capacity()
{
	return (int)vec.capacity();
}

void NativeList::Clear()
{
	vec.clear();
}

int NativeList::Count()
{
	return (int)vec.size();
}

BOOL NativeList::Contains(void* ptr)
{
	return IndexOf(ptr) != -1;
}

void* NativeList::Copy()
{
	auto copy = new NativeList();
	copy->vec = vec;
	return copy;
}

void* NativeList::Get(int index)
{
	if (InRange(index))
		return vec[index];
	else
		return nullptr;
}

void NativeList::Set(int index, void* ptr)
{
	if (InRange(index))
		vec[index] = ptr;
}

int NativeList::IndexOf(void* ptr)
{
	for (int i = 0; i < Count(); i++)
		if (vec[i] == ptr)
			return i;

	return -1;
}

void NativeList::Insert(void* ptr, int index)
{
	if(InRange(index))
		vec.insert(vec.begin() + index, ptr);
}

void NativeList::Remove(void* ptr)
{
	int i = IndexOf(ptr);
	if (i == -1) return;

	RemoveAt(i);
}

void NativeList::RemoveAt(int index)
{
	if (InRange(index))
		vec.erase(vec.begin() + index);
}

void NativeList::Reverse()
{
	std::reverse(vec.begin(), vec.end());
}

void NativeList::TrimExcess()
{
	vec.shrink_to_fit();
}

bool NativeList::InRange(int index)
{
	if (index < 0 || index >= Count())
		return false;
	else
		return true;
}

bool NativeList::NotInRange(int index)
{
	return !InRange(index);
}

