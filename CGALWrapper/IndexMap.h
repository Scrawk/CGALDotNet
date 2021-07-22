#pragma once

#include <map>

template<class T>
struct IndexMap
{
	int nextIndex = 0;

	std::map<int, T> map;

	bool indicesSet = false;

	bool mapBuilt = false;

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

};

