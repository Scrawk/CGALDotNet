#include "pch.h"
#include "Util.h"
#include "Arrangement2_EEK.h"
#include "Arrangement2.h"

#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>


void* Arrangement2_EEK_Create()
{
	return Util::Create<Arrangement2<EEK>::Arrangement_2>();
}

void* Arrangement2_EEK_CreateFromSegments(Segment2d* segments, int startIndex, int count)
{
	return Arrangement2<EEK>::CreateFromSegments(segments, startIndex, count);
}

void Arrangement2_EEK_Release(void* ptr)
{
	Util::Release<Arrangement2<EEK>::Arrangement_2>(ptr);
}

int Arrangement2_EEK_ElementCount(void* ptr, ARRANGEMENT2_ELEMENT element)
{
	return Arrangement2<EEK>::ElementCount(ptr, element);
}