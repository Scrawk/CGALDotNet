#pragma once

#include "CGALWrapper.h"
#include "Geometry2.h"
#include "Polygon2.h"
#include "PolygonWithHoles2.h"

#include <CGAL/enum.h> 
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/Simple_polygon_visibility_2.h>
#include <CGAL/Arrangement_2.h>
#include <CGAL/Arr_segment_traits_2.h>
#include <CGAL/Arr_naive_point_location.h>
#include <istream>
#include <vector>


template<class K>
class PolygonVisibility2
{
	typedef typename K::Point_2                                                 Point_2;
	typedef typename K::Segment_2                                               Segment_2;
	typedef typename CGAL::Arr_segment_traits_2<K>                              Traits_2;
	typedef typename CGAL::Arrangement_2<Traits_2>                              Arrangement_2;
	typedef typename Arrangement_2::Face_handle                                 Face_handle;
	typedef typename Arrangement_2::Edge_const_iterator							Edge_const_iterator;
	typedef typename Arrangement_2::Ccb_halfedge_circulator                     Ccb_halfedge_circulator;

	typedef typename Arrangement_2::Face_const_handle 							Face;
	typedef typename CGAL::Arr_naive_point_location<Arrangement_2>				Location;
	typedef typename CGAL::Arr_point_location_result<Arrangement_2>::Type		Type;

	typedef typename CGAL::Polygon_2<K>											Polygon_2;
	typedef typename CGAL::Polygon_with_holes_2<K>								Pwh_2;

	typedef typename CGAL::Simple_polygon_visibility_2<Arrangement_2, CGAL::Tag_false> NSPV;
	typedef typename CGAL::Simple_polygon_visibility_2<Arrangement_2, CGAL::Tag_true> RSPV;

public:

	PolygonVisibility2() {}

	inline static PolygonVisibility2* CastToPolygonVisibility2(void* ptr)
	{
		return static_cast<PolygonVisibility2*>(ptr);
	}

	inline static Polygon_2* CastToPolygon2(void* ptr)
	{
		return static_cast<Polygon_2*>(ptr);
	}

	inline static Pwh_2* CastToPolygonWithHoles2(void* ptr)
	{
		return static_cast<Pwh_2*>(ptr);
	}

	static void ComputeVisibility(void* ptr, Point2d point, Segment2d* segments, int startIndex, int count)
	{
		
		auto polygon = CastToPolygon2(ptr);

		std::vector<Segment_2> Segments;
		for (int i = 0; i < count; i++)
		{
			auto seg = segments[i].ToCGAL<K, Segment_2>();
			Segments.push_back(seg);
		}

		Point_2 p1(1, 2), p2(12, 3), p3(19, -2), p4(12, 6), p5(14, 14), p6(9, 5);
		Point_2 h1(8, 3), h2(10, 3), h3(8, 4), h4(10, 6), h5(11, 6), h6(11, 7);
		
		Arrangement_2 env;
		CGAL::insert_non_intersecting_curves(env, Segments.begin(), Segments.end());

		std::cout << "insert_non_intersecting_curves" << std::endl;

		// find the face of the query point
		// (usually you may know that by other means)
		Point_2 q = point.ToCGAL<K>();

		//Location pl(env);
		//Type obj = pl.locate(q);

		std::cout << "locate" << std::endl;

		//Find the halfedge whose target is the query point.
		//(usually you may know that already by other means)
		Point_2 query_point = q;

		auto he = env.halfedges_begin();
		while (he->source()->point() != p3 || he->target()->point() != p4)
			he++;

		//visibility query
		Arrangement_2 output_arr;
		//TEV tev(env);

		//Face_handle fh = tev.compute_visibility(query_point, he, output_arr);

		//print out the visibility region.
		//std::cout << "Regularized visibility region of q has "
		//	<< output_arr.number_of_edges()
		//	<< " edges." << std::endl;
		//std::cout << "Boundary edges of the visibility region:" << std::endl;

		//Arrangement_2::Ccb_halfedge_circulator curr = fh->outer_ccb();
		//std::cout << "[" << curr->source()->point() << " -> " << curr->target()->point() << "]" << std::endl;

		//while (++curr != fh->outer_ccb())
		//	std::cout << "[" << curr->source()->point() << " -> " << curr->target()->point() << "]" << std::endl;

		/*
		// The query point locates in the interior of a face
		Face* face = boost::get<Arrangement_2::Face_const_handle>(&obj);
		if (face != nullptr)
		{
			// compute non regularized visibility area
			// Define visibiliy object type that computes non-regularized visibility area
			
			Arrangement_2 non_regular_output;
			NSPV non_regular_visibility(env);

			std::cout << "non_regular_visibility" << std::endl;

			non_regular_visibility.compute_visibility(q, *face, non_regular_output);
			std::cout << "Non-regularized visibility region of q has "
				<< non_regular_output.number_of_edges()
				<< " edges:" << std::endl;

			for (Edge_const_iterator eit = non_regular_output.edges_begin(); eit != non_regular_output.edges_end(); ++eit)
				std::cout << "[" << eit->source()->point() << " -> " << eit->target()->point() << "]" << std::endl;

			
			// compute non regularized visibility area
			// Define visibiliy object type that computes regularized visibility area
			
			Arrangement_2 regular_output;
			RSPV regular_visibility(env);

			regular_visibility.compute_visibility(q, *face, regular_output);

			std::cout << "Regularized visibility region of q has "

				<< regular_output.number_of_edges()
				<< " edges:" << std::endl;

			for (Edge_const_iterator eit = regular_output.edges_begin(); eit != regular_output.edges_end(); ++eit)
				std::cout << "[" << eit->source()->point() << " -> " << eit->target()->point() << "]" << std::endl;
				
		}
		*/
	}

};
