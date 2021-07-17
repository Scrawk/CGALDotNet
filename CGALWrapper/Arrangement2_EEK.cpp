#include "pch.h"
#include "Util.h"
#include "Arrangement2_EEK.h"
#include "Arrangement2.h"

#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arrangement_2.h>

typedef CGAL::Arr_segment_traits_2<EEK> Traits_2;
typedef Traits_2::X_monotone_curve_2 Segment_2;
typedef CGAL::Arrangement_2<Traits_2> Arrangement_2;

void* Arrangement2_EEK_Create()
{
	return Util::Create<Arrangement_2>();
}

void Arrangement2_EEK_Release(void* ptr)
{
	Util::Release<Arrangement_2>(ptr);
}