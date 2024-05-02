#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"

#include <CGAL/Boolean_set_operations_2.h>
#include <CGAL/connect_holes.h>
#include <CGAL/Polygon_2.h>
#include <CGAL/enum.h>
#include <vector>

template<class K>
class PolygonBoolean2
{

public:

	typedef CGAL::Polygon_2<K> Polygon_2;
	typedef CGAL::Polygon_with_holes_2<K> Pwh_2;

private:
	
	std::vector<Pwh_2> buffer;

public:

	PolygonBoolean2() 
	{

	}

	~PolygonBoolean2() 
	{

	}

	inline static PolygonBoolean2* NewPolygonBoolean2()
	{
		return new PolygonBoolean2();
	}

	inline static void DeletePolygonBoolean2(void* ptr)
	{
		auto obj = static_cast<PolygonBoolean2*>(ptr);

		if (obj != nullptr)
		{
			delete obj;
			obj = nullptr;
		}
	}

	inline static PolygonBoolean2* CastToBoolean2(void* ptr)
	{
		return static_cast<PolygonBoolean2*>(ptr);
	}

	inline static Polygon_2* CastToPolygon2(void* ptr)
	{
		return static_cast<Polygon_2*>(ptr);
	}

	inline static Pwh_2* CastToPolygonWithHoles2(void* ptr)
	{
		return static_cast<Pwh_2*>(ptr);
	}

	static void ClearBuffer(void* ptr)
	{
		auto boo = CastToBoolean2(ptr);
		boo->buffer.clear();
	}

	static void* CopyBufferItem(void* ptr, int index)
	{
		auto boo = CastToBoolean2(ptr);
		return new Pwh_2(boo->buffer[index]);
	}

	//Do Intersect

	template<class P1, class P2>
	BOOL DoIntersect(P1* polygon1, P2* polygon2)
	{
		return CGAL::do_intersect(*polygon1, *polygon2);
	}

	static BOOL DoIntersect_P_P(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygon2(ptr2);

        return boo->template DoIntersect<Polygon_2, Polygon_2>(polygon1, polygon2);
	}

	static BOOL DoIntersect_P_PWH(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template DoIntersect<Polygon_2, Pwh_2>(polygon1, polygon2);
	}

	static BOOL DoIntersect_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygonWithHoles2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template DoIntersect<Pwh_2, Pwh_2>(polygon1, polygon2);
	}

	//Join

	template<class P1, class P2>
	BOOL Join(P1* polygon1, P2* polygon2, void** resultPtr)
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

	static BOOL Join_P_P(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygon2(ptr2);

        return boo->template Join<Polygon_2, Polygon_2>(polygon1, polygon2, resultPtr);
	}

	static BOOL Join_P_PWH(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template Join<Polygon_2, Pwh_2>(polygon1, polygon2, resultPtr);
	}

	static BOOL Join_PWH_PWH(void* ptr0, void* ptr1, void* ptr2, void** resultPtr)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygonWithHoles2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template Join<Pwh_2, Pwh_2>(polygon1, polygon2, resultPtr);
	}

	//Intersect

	template<class P1, class P2>
	int Intersect(P1* polygon1, P2* polygon2)
	{
		CGAL::intersection(*polygon1, *polygon2, std::back_inserter(buffer));
		return (int)buffer.size();
	}

	static int Intersect_P_P(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygon2(ptr2);

        return boo->template Intersect<Polygon_2, Polygon_2>(polygon1, polygon2);
	}

	static int Intersect_P_PWH(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template Intersect<Polygon_2, Pwh_2>(polygon1, polygon2);

	}

	static int Intersect_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygonWithHoles2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template Intersect<Pwh_2, Pwh_2>(polygon1, polygon2);
	}

	//Difference

	template<class P1, class P2>
	int Difference(P1* polygon1, P2* polygon2)
	{
		CGAL::difference(*polygon1, *polygon2, std::back_inserter(buffer));
		return (int)buffer.size();
	}

	static int Difference_P_P(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygon2(ptr2);

        return boo->template Difference<Polygon_2, Polygon_2>(polygon1, polygon2);
	}

	static int Difference_P_PWH(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template Difference<Polygon_2, Pwh_2>(polygon1, polygon2);
	}

	static int Difference_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygonWithHoles2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template Difference<Pwh_2, Pwh_2>(polygon1, polygon2);
	}

	//Symmetric Difference

	template<class P1, class P2>
	int SymmetricDifference(P1* polygon1, P2* polygon2)
	{
		CGAL::symmetric_difference(*polygon1, *polygon2, std::back_inserter(buffer));
		return (int)buffer.size();
	}

	static int SymmetricDifference_P_P(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygon2(ptr2);

        return boo->template SymmetricDifference<Polygon_2, Polygon_2>(polygon1, polygon2);
	}

	static int SymmetricDifference_P_PWH(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygon2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template SymmetricDifference<Polygon_2, Pwh_2>(polygon1, polygon2);
	}

	static int SymmetricDifference_PWH_PWH(void* ptr0, void* ptr1, void* ptr2)
	{
		auto boo = CastToBoolean2(ptr0);
		auto polygon1 = CastToPolygonWithHoles2(ptr1);
		auto polygon2 = CastToPolygonWithHoles2(ptr2);

        return boo->template SymmetricDifference<Pwh_2, Pwh_2>(polygon1, polygon2);
	}

	//Complement

	template<class P>
	int Complement(P* polygon)
	{
		CGAL::complement(*polygon, std::back_inserter(buffer));
		return (int)buffer.size();
	}

	static int Complement_PWH(void*ptr0, void* ptr1)
	{
		auto boo = CastToBoolean2(ptr0);
		auto pwh = CastToPolygonWithHoles2(ptr1);

        return boo->template Complement<Pwh_2>(pwh);
	}

};



