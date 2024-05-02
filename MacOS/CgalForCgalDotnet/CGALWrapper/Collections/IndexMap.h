#pragma once

#include <map>
#include <unordered_map>

template<class T>
class IndexMap
{
private:

	int nextIndex = 0;

	std::unordered_map<int, T> map;

public:

	IndexMap()
	{
		nextIndex = 0;
		indicesSet = false;
		mapBuilt = false;
	}

	bool indicesSet;

	bool mapBuilt;

	void Clear()
	{
		ClearMap();
		ResetIndices();
	}

	void ClearMap()
	{
		mapBuilt = false;
		map.clear();
	}

	void ResetIndices()
	{
		indicesSet = false;
		nextIndex = 0;
	}

	int NextIndex()
	{
		return nextIndex++;
	}

	void Insert(int index, T item)
	{
		map.insert(std::pair<int, T>(index, item));
	}

	T* Find(int index)
	{
		auto item = map.find(index);
		if (item != map.end())
			return &item->second;
		else
			return nullptr;
	}

};

