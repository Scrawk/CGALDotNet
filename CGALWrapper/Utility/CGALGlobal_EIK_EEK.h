#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include "CGALGlobal.h"

#include <CGAL/enum.h>

extern "C"
{

    //---------------------------------------------------------------------------//
    //                               Angle                                       //
    //---------------------------------------------------------------------------//

	CGALWRAPPER_API CGAL::Angle CGALGlobal_EIK_Angle_Vector2d(Vector2d u, Vector2d v);

    CGALWRAPPER_API CGAL::Angle CGALGlobal_EIK_Angle_Vector2(void* u, void* v);

    CGALWRAPPER_API CGAL::Angle CGALGlobal_EEK_Angle_Vector2(void* u, void* v);

	CGALWRAPPER_API CGAL::Angle CGALGlobal_EIK_Angle_Vector3d(Vector3d u, Vector3d v);

    //---------------------------------------------------------------------------//
    //                               ApproxAngle                                 //
    //---------------------------------------------------------------------------//

	CGALWRAPPER_API double CGALGlobal_EIK_ApproxAngle_Vector3d(Vector3d u, Vector3d v);

    //---------------------------------------------------------------------------//
    //                               ApproxDihedralAngle                         //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API double CGALGlobal_EIK_ApproxDihedralAngle_Point3(Point3d p, Point3d q, Point3d r, Point3d s);

    //---------------------------------------------------------------------------//
    //                               AreOrderedAlongLine                         //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API BOOL CGALGlobal_EIK_AreOrderedAlongLine_Point2d(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_AreOrderedAlongLine_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_AreOrderedAlongLine_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_AreOrderedAlongLine_Point3d(Point3d p, Point3d q, Point3d r);

    //---------------------------------------------------------------------------//
    //                               AreStrictlyOrderedAlongLine                 //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API BOOL CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point2d(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point3d(Point3d p, Point3d q, Point3d r);

    //---------------------------------------------------------------------------//
    //                                  Collinear                                //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Collinear_Point2d(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Collinear_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_Collinear_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Collinear_Point3d(Point3d p, Point3d q, Point3d r);

   //---------------------------------------------------------------------------//
   //                                  Barycenter                               //
   //---------------------------------------------------------------------------//

    CGALWRAPPER_API Point2d CGALGlobal_EIK_Barycenter_Point2d(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API void* CGALGlobal_EIK_Barycenter_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API void* CGALGlobal_EEK_Barycenter_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API Point3d CGALGlobal_EIK_Barycenter_Point3d(Point3d p, Point3d q, Point3d r);

    //---------------------------------------------------------------------------//
    //                                Bisector                                   //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API Line2d CGALGlobal_EIK_Bisector_Point3d(Point3d p, Point3d q);

    CGALWRAPPER_API Line2d CGALGlobal_EIK_Bisector_Line2d(Line2d p, Line2d q);

    CGALWRAPPER_API void* CGALGlobal_EIK_Bisector_Line2(void* p, void* q);

    CGALWRAPPER_API void* CGALGlobal_EEK_Bisector_Line2(void* p, void* q);

    //---------------------------------------------------------------------------//
    //                                Coplanar                                   //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Coplanar_Point3d(Point3d p, Point3d q, Point3d r, Point3d s);

    //---------------------------------------------------------------------------//
    //                           CoplanarOrientation                             //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EIK_CoplanarOrientation_3Point3d(Point3d p, Point3d q, Point3d r);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EIK_CoplanarOrientation_4Point3d(Point3d p, Point3d q, Point3d r, Point3d s);

    //---------------------------------------------------------------------------//
    //                          EquidistantLine                                  //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API Line3d CGALGlobal_EIK_EquidistantLine_Line3d(Point3d p, Point3d q, Point3d r);

    //---------------------------------------------------------------------------//
    //                             LeftTurn                                      //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API BOOL CGALGlobal_EIK_LeftTurn_Point2d(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_LeftTurn_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_LeftTurn_Point2(void* p, void* q, void* r);

    //---------------------------------------------------------------------------//
    //                              RightTurn                                    //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API BOOL CGALGlobal_EIK_RightTurn_Point2d(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_RightTurn_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_RightTurn_Point2(void* p, void* q, void* r);

    //---------------------------------------------------------------------------//
    //                             Orientation                                   //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EIK_Orientation_Point2d(Point2d p, Point2d q, Point2d r);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EIK_Orientation_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EEK_Orientation_Point2(void* p, void* q, void* r);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EIK_Orientation_Vector2d(Vector2d u, Vector2d v);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EIK_Orientation_Vector2(void* p, void* q);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EEK_Orientation_Vector2(void* p, void* q);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EIK_Orientation_Point3d(Point3d p, Point3d q, Point3d r, Point3d s);

    CGALWRAPPER_API CGAL::Orientation CGALGlobal_EIK_Orientation_Vector3d(Vector3d u, Vector3d v, Vector3d w);

    //---------------------------------------------------------------------------//
    //                                OrthogonalVector                           //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API Vector3d CGALGlobal_EIK_OrthogonalVector_Point3d(Point3d p, Point3d q, Point3d r);

    CGALWRAPPER_API void* CGALGlobal_EIK_OrthogonalVector_Point3(void* p, void* q, void* r);

    CGALWRAPPER_API void* CGALGlobal_EEK_OrthogonalVector_Point3(void* p, void* q, void* r);

    //---------------------------------------------------------------------------//
    //                                    Parallel                               //
    //---------------------------------------------------------------------------//

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Parallel_Line2d(Line2d l1, Line2d l2);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Parallel_Line2(void* l1, void* l2);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_Parallel_Line2(void* l1, void* l2);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Parallel_Ray2d(Ray2d r1, Ray2d r2);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Parallel_Ray2(void* r1, void* r2);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_Parallel_Ray2(void* r1, void* r2);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Parallel_Segment2d(Segment2d s1, Segment2d s2);

    CGALWRAPPER_API BOOL CGALGlobal_EIK_Parallel_Segment2(void* s1, void* s2);

    CGALWRAPPER_API BOOL CGALGlobal_EEK_Parallel_Segment2(void* s1, void* s2);



}

