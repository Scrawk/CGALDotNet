#pragma once
#include "CGALWrapper.h"
#include "Geometry2.h"

#include <CGAL/Boolean_set_operations_2.h>
#include <CGAL/connect_holes.h>
#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>
#include <vector>

template<class K>
class PolygonBoolean2
{

private:
	PolygonBoolean2() {}

	typedef CGAL::Polygon_2<K> Polygon_2;
	typedef CGAL::Polygon_with_holes_2<K> Pwh_2;

public:

	//Do Intersect

	template<class P1, class P2>
	static bool DoIntersect(P1* polygon1, P2* polygon2)
	{
		return CGAL::do_intersect(*polygon1, *polygon2);
	}

	static bool DoIntersect_P_P(void* ptr1, void* ptr2)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Polygon_2*)ptr2;

		return DoIntersect<Polygon_2, Polygon_2>(polygon1, polygon2);
	}

	static bool DoIntersect_P_PWH(void* ptr1, void* ptr2)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		return DoIntersect<Polygon_2, Pwh_2>(polygon1, polygon2);
	}

	static bool DoIntersect_PWH_PWH(void* ptr1, void* ptr2)
	{
		auto polygon1 = (Pwh_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		return DoIntersect<Pwh_2, Pwh_2>(polygon1, polygon2);
	}

	//Join

	template<class P1, class P2>
	static bool Join(P1* polygon1, P2* polygon2, void** resultPtr)
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

	static bool Join_P_P(void* ptr1, void* ptr2, void** resultPtr)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Polygon_2*)ptr2;

		return Join<Polygon_2, Polygon_2>(polygon1, polygon2, resultPtr);
	}

	static bool Join_P_PWH(void* ptr1, void* ptr2, void** resultPtr)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		return Join<Polygon_2, Pwh_2>(polygon1, polygon2, resultPtr);
	}

	static bool Join_PWH_PWH(void* ptr1, void* ptr2, void** resultPtr)
	{
		auto polygon1 = (Pwh_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		return Join<Pwh_2, Pwh_2>(polygon1, polygon2, resultPtr);
	}

	//Intersect

	template<class P1, class P2, class LIST>
	static void Intersect(P1* polygon1, P2* polygon2, LIST& list)
	{
		CGAL::intersection(*polygon1, *polygon2, std::back_inserter(list));
	}

	template<class LIST>
	static void Intersect_P_P(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Polygon_2*)ptr2;

		Intersect<Polygon_2, Polygon_2, LIST>(polygon1, polygon2, list);
	}

	template<class LIST>
	static void Intersect_P_PWH(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		Intersect<Polygon_2, Pwh_2, LIST>(polygon1, polygon2, list);
	}

	template<class LIST>
	static void Intersect_PWH_PWH(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Pwh_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		Intersect<Pwh_2, Pwh_2, LIST>(polygon1, polygon2, list);
	}

	//Difference

	template<class P1, class P2, class LIST>
	static void Difference(P1* polygon1, P2* polygon2, LIST& list)
	{
		CGAL::difference(*polygon1, *polygon2, std::back_inserter(list));
	}

	template<class LIST>
	static void Difference_P_P(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Polygon_2*)ptr2;

		Difference<Polygon_2, Polygon_2, LIST>(polygon1, polygon2, list);
	}

	template<class LIST>
	static void Difference_P_PWH(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		Difference<Polygon_2, Pwh_2, LIST>(polygon1, polygon2, list);
	}

	template<class LIST>
	static void Difference_PWH_PWH(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Pwh_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		Difference<Pwh_2, Pwh_2, LIST>(polygon1, polygon2, list);
	}

	//Symmetric Difference

	template<class P1, class P2, class LIST>
	static void SymmetricDifference(P1* polygon1, P2* polygon2, LIST& list)
	{
		CGAL::symmetric_difference(*polygon1, *polygon2, std::back_inserter(list));
	}

	template<class LIST>
	static void SymmetricDifference_P_P(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Polygon_2*)ptr2;

		SymmetricDifference<Polygon_2, Polygon_2, LIST>(polygon1, polygon2, list);
	}

	template<class LIST>
	static void SymmetricDifference_P_PWH(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Polygon_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		SymmetricDifference<Polygon_2, Pwh_2, LIST>(polygon1, polygon2, list);
	}

	template<class LIST>
	static void SymmetricDifference_PWH_PWH(void* ptr1, void* ptr2, LIST& list)
	{
		auto polygon1 = (Pwh_2*)ptr1;
		auto polygon2 = (Pwh_2*)ptr2;

		SymmetricDifference<Pwh_2, Pwh_2, LIST>(polygon1, polygon2, list);
	}

	//Complement

	template<class P, class LIST>
	static void Complement(P* polygon, LIST& list)
	{
		CGAL::complement(*polygon, std::back_inserter(list));
	}

	template<class LIST>
	static void Complement_PWH(void* ptr, LIST& list)
	{
		auto pwh = (Pwh_2*)ptr;

		Complement<Pwh_2, LIST>(pwh, list);
	}

};



