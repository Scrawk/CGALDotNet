#pragma once
#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Boolean_set_operations_2.h>
#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>
#include <vector>

//Do Intersect

template<class P1, class P2>
bool PolygonBoolean2_DoIntersect(P1* polygon1, P2* polygon2)
{
	return CGAL::do_intersect(*polygon1, *polygon2);
}

template<class K>
bool PolygonBoolean2_DoIntersect_P_P(void* ptr1, void* ptr2)
{
	using POLYGON = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	return PolygonBoolean2_DoIntersect<POLYGON, POLYGON>(polygon1, polygon2);
}

template<class K>
bool PolygonBoolean2_DoIntersect_P_PWH(void* ptr1, void* ptr2)
{
	using POLYGON = CGAL::Polygon_2<K>;
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	return PolygonBoolean2_DoIntersect<POLYGON, PWH>(polygon1, polygon2);
}

template<class K>
bool PolygonBoolean2_DoIntersect_PWH_PWH(void* ptr1, void* ptr2)
{
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (PWH*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	return PolygonBoolean2_DoIntersect<PWH, PWH>(polygon1, polygon2);
}

//Join

template<class K, class P1, class P2>
bool PolygonBoolean2_Join(P1* polygon1, P2* polygon2, void** resultPtr)
{
	auto result = new CGAL::Polygon_with_holes_2<K>();

	if (CGAL::join(*polygon1, *polygon2, *result))
	{
		*resultPtr = result;
		return true;
	}
	else
	{
		delete result;
		result = nullptr;
		return false;
	}
}

template<class K>
bool PolygonBoolean2_Join_P_P(void* ptr1, void* ptr2, void** resultPtr)
{
	using POLYGON = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	return PolygonBoolean2_Join<K, POLYGON, POLYGON>(polygon1, polygon2, resultPtr);
}

template<class K>
bool PolygonBoolean2_Join_P_PWH(void* ptr1, void* ptr2, void** resultPtr)
{
	using POLYGON = CGAL::Polygon_2<K>;
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	return PolygonBoolean2_Join<K, POLYGON, PWH>(polygon1, polygon2, resultPtr);
}

template<class K>
bool PolygonBoolean2_Join_PWH_PWH(void* ptr1, void* ptr2, void** resultPtr)
{
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (PWH*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	return PolygonBoolean2_Join<K, PWH, PWH>(polygon1, polygon2, resultPtr);
}

//Intersect

template<class K, class P1, class P2, class LIST>
void PolygonBoolean2_Intersect(P1* polygon1, P2* polygon2, LIST& list)
{
	CGAL::intersection(*polygon1, *polygon2, std::back_inserter(list));
}

template<class K, class LIST>
void PolygonBoolean2_Intersect_P_P(void* ptr1, void* ptr2, LIST& list)
{
	using POLYGON = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	PolygonBoolean2_Intersect<K, POLYGON, POLYGON, LIST>(polygon1, polygon2, list);
}

template<class K, class LIST>
void PolygonBoolean2_Intersect_P_PWH(void* ptr1, void* ptr2, LIST& list)
{
	using POLYGON = CGAL::Polygon_2<K>;
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	PolygonBoolean2_Intersect<K, POLYGON, PWH, LIST>(polygon1, polygon2, list);
}

template<class K, class LIST>
void PolygonBoolean2_Intersect_PWH_PWH(void* ptr1, void* ptr2, LIST& list)
{
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (PWH*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	PolygonBoolean2_Intersect<K, PWH, PWH, LIST>(polygon1, polygon2, list);
}

//Difference

template<class K, class P1, class P2, class LIST>
void PolygonBoolean2_Difference(P1* polygon1, P2* polygon2, LIST& list)
{
	CGAL::difference(*polygon1, *polygon2, std::back_inserter(list));
}

template<class K, class LIST>
void PolygonBoolean2_Difference_P_P(void* ptr1, void* ptr2, LIST& list)
{
	using POLYGON = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	PolygonBoolean2_Difference<K, POLYGON, POLYGON, LIST>(polygon1, polygon2, list);
}

template<class K, class LIST>
void PolygonBoolean2_Difference_P_PWH(void* ptr1, void* ptr2, LIST& list)
{
	using POLYGON = CGAL::Polygon_2<K>;
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	PolygonBoolean2_Difference<K, POLYGON, PWH, LIST>(polygon1, polygon2, list);
}

template<class K, class LIST>
void PolygonBoolean2_Difference_PWH_PWH(void* ptr1, void* ptr2, LIST& list)
{
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (PWH*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	PolygonBoolean2_Difference<K, PWH, PWH, LIST>(polygon1, polygon2, list);
}

//Symmetric Difference

template<class K, class P1, class P2, class LIST>
void PolygonBoolean2_SymmetricDifference(P1* polygon1, P2* polygon2, LIST& list)
{
	CGAL::symmetric_difference(*polygon1, *polygon2, std::back_inserter(list));
}

template<class K, class LIST>
void PolygonBoolean2_SymmetricDifference_P_P(void* ptr1, void* ptr2, LIST& list)
{
	using POLYGON = CGAL::Polygon_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (POLYGON*)ptr2;

	PolygonBoolean2_SymmetricDifference<K, POLYGON, POLYGON, LIST>(polygon1, polygon2, list);
}

template<class K, class LIST>
void PolygonBoolean2_SymmetricDifference_P_PWH(void* ptr1, void* ptr2, LIST& list)
{
	using POLYGON = CGAL::Polygon_2<K>;
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (POLYGON*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	PolygonBoolean2_SymmetricDifference<K, POLYGON, PWH, LIST>(polygon1, polygon2, list);
}

template<class K, class LIST>
void PolygonBoolean2_SymmetricDifference_PWH_PWH(void* ptr1, void* ptr2, LIST& list)
{
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto polygon1 = (PWH*)ptr1;
	auto polygon2 = (PWH*)ptr2;

	PolygonBoolean2_SymmetricDifference<K, PWH, PWH, LIST>(polygon1, polygon2, list);
}

//Complement

template<class K, class P, class LIST>
void PolygonBoolean2_Complement(P* polygon, LIST& list)
{
	CGAL::symmetric_complement(*polygon, std::back_inserter(list));
}

template<class K, class LIST>
void PolygonBoolean2_Complement_PWH(void* ptr, LIST& list)
{
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto pwh = (PWH*)ptr;

	PolygonBoolean2_Complement<K, PWH, LIST>(pwh, list);
}

//Connect Holes

template<class K, class P, class LIST>
void PolygonBoolean2_ConnectHoles(P* polygon, LIST& list)
{
CGAL:connect_holes(*polygon, std::back_inserter(list));
}

template<class K, class LIST>
void PolygonBoolean2_ConnectHoles_PWH(void* ptr, LIST& list)
{
	using PWH = CGAL::Polygon_with_holes_2<K>;

	auto pwh = (PWH*)ptr;

	PolygonBoolean2_ConnectHoles<K, PWH, LIST>(pwh, list);
}




