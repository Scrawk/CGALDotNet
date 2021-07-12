#pragma once

#include "CGALWrapper.h"
#include "Points.h"

#include <CGAL/Polygon_2.h>
#include <CGAL/Polygon_with_holes_2.h>
#include <CGAL/enum.h>

typedef CGAL::Polygon_2<EEK> Polygon2_EEK;
typedef CGAL::Polygon_with_holes_2<EEK> PolygonWithHoles2_EEK;

extern "C" CGALWRAPPER_API void* PolygonWithHoles2_EEK_Create();

extern "C" CGALWRAPPER_API void PolygonWithHoles2_EEK_Release(void* ptr);
