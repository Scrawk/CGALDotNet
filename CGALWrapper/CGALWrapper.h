#pragma once

#define CGALWRAPPER_API __declspec(dllexport)

#define NULL_INDEX -1
#define WIN32_LEAN_AND_MEAN 
#define NOMINMAX

#include <windows.h>
#include <cstdbool>
#include <CGAL/Cartesian.h>
#include <CGAL/Homogeneous.h>
#include <CGAL/Exact_predicates_inexact_constructions_kernel.h>
#include <CGAL/Exact_predicates_exact_constructions_kernel.h>
#include <CGAL/Exact_predicates_exact_constructions_kernel_with_sqrt.h>
#include <CGAL/Exact_predicates_exact_constructions_kernel_with_kth_root.h>
#include <CGAL/Exact_predicates_exact_constructions_kernel_with_root_of.h>
#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include "CGAL/Point_2.h"

typedef CGAL::Exact_predicates_inexact_constructions_kernel EIK;
typedef CGAL::Exact_predicates_exact_constructions_kernel EEK;
typedef CGAL::Exact_predicates_exact_constructions_kernel_with_sqrt EEK_SQRT2;
typedef CGAL::Exact_predicates_exact_constructions_kernel_with_kth_root EEK_KTH_ROOT;
typedef CGAL::Exact_predicates_exact_constructions_kernel_with_root_of EEK_ROOT_OF;

//typedef EEK::Point_2                            Point_EEK;
//typedef CGAL::Polygon_2<EEK>		            Polygon_EEK_2;
//typedef CGAL::Polygon_with_holes_2<EEK>         Polygon_with_holes_EEK_2;

enum class CGAL_KERNEL : int
{
    EXACT_PREDICATES_INEXACT_CONSTRUCTION = 0,
    EXACT_PREDICATES_EXACT_CONSTRUCTION = 1,
    EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_SQRT2 = 2,
    EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_KTH_ROOT = 3,
    EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_ROOT_OF = 4
};

enum class POLYGON_ELEMENT : int
{
    BOUNDARY,
    HOLE,
    ALL
};

