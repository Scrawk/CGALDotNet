#pragma once
#pragma once
#include "CGALWrapper.h"
#include "Geometry2.h"
#include "CGALGlobal.h"

#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API CGAL::Angle CGALGlobal_EEK_Angle_Vector2(Vector2d u, Vector2d v);

	CGALWRAPPER_API CGAL::Angle CGALGlobal_EEK_Angle_Vector3(Vector3d u, Vector3d v);

	CGALWRAPPER_API double CGALGlobal_EEK_ApproxAngle_Vector3(Vector3d u, Vector3d v);

    CGALWRAPPER_API double CGALGlobal_EEK_ApproxDihedralAngle_Point3(Point3d p, Point3d q, Point3d r, Point3d s);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_AreOrderedAlongLine_Point2(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_AreOrderedAlongLine_Point3(Point3d p, Point3d q, Point3d r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point2(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point3(Point3d p, Point3d q, Point3d r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_Collinear_Point2(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_Collinear_Point3(Point3d p, Point3d q, Point3d r);

    CGALWRAPPER_API Line2d CGALGlobal_EEK_Bisector_Point3(Point3d p, Point3d q);

    CGALWRAPPER_API Line2d CGALGlobal_EEK_Bisector_Line2(Line2d p, Line2d q);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_Coplanar_Point3(Point3d p, Point3d q, Point3d r, Point3d s);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EEK_CoplanarOrientation_3Point3(Point3d p, Point3d q, Point3d r);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EEK_CoplanarOrientation_4Point3(Point3d p, Point3d q, Point3d r, Point3d s);

    CGALWRAPPER_API Line3d CGALGlobal_EEK_EquidistantLine_Line3(Point3d p, Point3d q, Point3d r);



}

