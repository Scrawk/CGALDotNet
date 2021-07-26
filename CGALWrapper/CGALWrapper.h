#pragma once

#define CGALWRAPPER_API __declspec(dllexport)

#define NULL_INDEX -1

#include <cstdbool>
#include <CGAL/Cartesian.h>
#include <CGAL/Homogeneous.h>
#include <CGAL/Exact_predicates_inexact_constructions_kernel.h>
#include <CGAL/Exact_predicates_exact_constructions_kernel.h>
#include <CGAL/Exact_predicates_exact_constructions_kernel_with_sqrt.h>
#include <CGAL/Exact_predicates_exact_constructions_kernel_with_kth_root.h>
#include <CGAL/Exact_predicates_exact_constructions_kernel_with_root_of.h>

typedef CGAL::Exact_predicates_inexact_constructions_kernel EIK;
typedef CGAL::Exact_predicates_exact_constructions_kernel EEK;
typedef CGAL::Exact_predicates_exact_constructions_kernel_with_sqrt EEK_SQRT2;
typedef CGAL::Exact_predicates_exact_constructions_kernel_with_kth_root EEK_KTH_ROOT;
typedef CGAL::Exact_predicates_exact_constructions_kernel_with_root_of EEK_ROOT_OF;

enum class CGAL_KERNEL : int
{
    EXACT_PREDICATES_INEXACT_CONSTRUCTION = 0,
    EXACT_PREDICATES_EXACT_CONSTRUCTION = 1,
    EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_SQRT2 = 2,
    EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_KTH_ROOT = 3,
    EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_ROOT_OF = 4
};

