#include "UnmanagedList.h"

#include <algorithm>

void* UnmanagedList_Create()
{
	return new UnmanagedList();
}

void* UnmanagedList_CreateWithCount(int count)
{
	return new UnmanagedList(count);
}

void UnmanagedList_Release(void* listPtr)
{
	auto obj = static_cast<UnmanagedList*>(listPtr);

	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

void UnmanagedList_Add(void* listPtr, void* ptr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->Add(ptr);
}

void UnmanagedList_AddRange(void* listPtr, void** ptr_array, int count)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->AddRange(ptr_array, count);
}

int UnmanagedList_Capacity(void* listPtr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	return list->Capacity();
}

void UnmanagedList_Clear(void* listPtr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->Clear();
}

int UnmanagedList_Count(void* listPtr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	return list->Count();
}

BOOL UnmanagedList_Contains(void* listPtr, void* ptr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	return list->Contains(ptr);
}

void* UnmanagedList_Copy(void* listPtr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	return list->Copy();
}

void* UnmanagedList_Get(void* listPtr, int index)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	return list->Get(index);
}

void UnmanagedList_Set(void* listPtr, int index, void* ptr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->Set(index, ptr);
}

int UnmanagedList_IndexOf(void* listPtr, void* ptr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	return list->IndexOf(ptr);
}

void UnmanagedList_Insert(void* listPtr, void* ptr, int index)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->Insert(ptr, index);
}

void UnmanagedList_Remove(void* listPtr, void* ptr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->Remove(ptr);
}

void UnmanagedList_RemoveAt(void* listPtr, int index)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->RemoveAt(index);
}

void UnmanagedList_Reverse(void* listPtr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->Reverse();
}

void UnmanagedList_TrimExcess(void* listPtr)
{
	auto list = UnmanagedList::CastToUnmanagedList(listPtr);
	list->TrimExcess();
}



UnmanagedList::UnmanagedList()
{

}

UnmanagedList::UnmanagedList(int count)
{
	vec.reserve(count);
}

UnmanagedList::~UnmanagedList()
{

}

void UnmanagedList::Add(void* ptr)
{
	vec.push_back(ptr);
}

void UnmanagedList::AddRange(void** ptr_array, int count)
{
	vec.insert(vec.end(), ptr_array, ptr_array + count);
}

int UnmanagedList::Capacity()
{
	return (int)vec.capacity();
}

void UnmanagedList::Clear()
{
	vec.clear();
}

int UnmanagedList::Count()
{
	return (int)vec.size();
}

BOOL UnmanagedList::Contains(void* ptr)
{
	return IndexOf(ptr) != -1;
}

void* UnmanagedList::Copy()
{
	auto copy = new UnmanagedList();
	copy->vec = vec;
	return copy;
}

void* UnmanagedList::Get(int index)
{
	if (InRange(index))
		return vec[index];
	else
		return nullptr;
}

void UnmanagedList::Set(int index, void* ptr)
{
	if (InRange(index))
		vec[index] = ptr;
}

int UnmanagedList::IndexOf(void* ptr)
{
	for (int i = 0; i < Count(); i++)
		if (vec[i] == ptr)
			return i;

	return -1;
}

void UnmanagedList::Insert(void* ptr, int index)
{
	if(InRange(index))
		vec.insert(vec.begin() + index, ptr);
}

void UnmanagedList::Remove(void* ptr)
{
	int i = IndexOf(ptr);
	if (i == -1) return;

	RemoveAt(i);
}

void UnmanagedList::RemoveAt(int index)
{
	if (InRange(index))
		vec.erase(vec.begin() + index);
}

void UnmanagedList::Reverse()
{
	std::reverse(vec.begin(), vec.end());
}

void UnmanagedList::TrimExcess()
{
	vec.shrink_to_fit();
}

bool UnmanagedList::InRange(int index)
{
	if (index < 0 || index >= Count())
		return false;
	else
		return true;
}

bool UnmanagedList::NotInRange(int index)
{
	return !InRange(index);
}

