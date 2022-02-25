
#include "../pch.h"
#include "CGALGlobal_EIK_EEK.h"
#include "CGALGlobal.h"

#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

//---------------------------------------------------------------------------//
//                               Angle                                       //
//---------------------------------------------------------------------------//

CGAL::Angle CGALGlobal_EIK_Angle_Vector2d(Vector2d u, Vector2d v)
{
	return CGALGlobal<EIK>::Angle_Vector2(u, v);
}

CGAL::Angle CGALGlobal_EIK_Angle_Vector2(void* u, void* v)
{
	return CGALGlobal<EIK>::Angle_EIK_Vector2(u, v);
}

CGAL::Angle CGALGlobal_EEK_Angle_Vector2(void* u, void* v)
{
	return CGALGlobal<EEK>::Angle_EEK_Vector2(u, v);
}

CGAL::Angle CGALGlobal_EIK_Angle_Vector3d(Vector3d u, Vector3d v)
{
	return CGALGlobal<EIK>::Angle_Vector3(u, v);
}

//---------------------------------------------------------------------------//
//                               ApproxAngle                                 //
//---------------------------------------------------------------------------//

double CGALGlobal_EIK_ApproxAngle_Vector3d(Vector3d u, Vector3d v)
{
	return CGALGlobal<EIK>::ApproxAngle_Vector3d(u, v);
}

//---------------------------------------------------------------------------//
//                               ApproxDihedralAngle                         //
//---------------------------------------------------------------------------//

double CGALGlobal_EIK_ApproxDihedralAngle_Point3(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EIK>::ApproxDihedralAngle(p, q, r, s);
}

//---------------------------------------------------------------------------//
//                               AreOrderedAlongLine                         //
//---------------------------------------------------------------------------//

BOOL CGALGlobal_EIK_AreOrderedAlongLine_Point2d(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::AreOrderedAlongLine_Point2d(p, q, r);
}

BOOL CGALGlobal_EIK_AreOrderedAlongLine_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::AreOrderedAlongLine_EIK_Point2(p, q, r);
}

BOOL CGALGlobal_EEK_AreOrderedAlongLine_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::AreOrderedAlongLine_EEK_Point2(p, q, r);
}

BOOL CGALGlobal_EIK_AreOrderedAlongLine_Point3d(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::AreOrderedAlongLine_Point3d(p, q, r);
}

//---------------------------------------------------------------------------//
//                               AreStrictlyOrderedAlongLine                 //
//---------------------------------------------------------------------------//

BOOL CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point2d(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::AreStrictlyOrderedAlongLine_Point2d(p, q, r);
}

BOOL CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::AreStrictlyOrderedAlongLine_EIK_Point2(p, q, r);
}

BOOL CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EEK>::AreStrictlyOrderedAlongLine_EEK_Point2(p, q, r);
}

BOOL CGALGlobal_EIK_AreStrictlyOrderedAlongLine_Point3d(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::AreStrictlyOrderedAlongLine_Point3d(p, q, r);
}

//---------------------------------------------------------------------------//
//                                  Collinear                                //
//---------------------------------------------------------------------------//

BOOL CGALGlobal_EIK_Collinear_Point2d(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::Collinear_Point2d(p, q, r);
}

BOOL CGALGlobal_EIK_Collinear_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::Collinear_EIK_Point2(p, q, r);
}

BOOL CGALGlobal_EEK_Collinear_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EEK>::Collinear_EEK_Point2(p, q, r);
}

BOOL CGALGlobal_EIK_Collinear_Point3d(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::Collinear_Point3d(p, q, r);
}

//---------------------------------------------------------------------------//
//                                  Barycenter                               //
//---------------------------------------------------------------------------//

Point2d CGALGlobal_EIK_Barycenter_Point2d(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::Barycenter_Point2d(p, q, r);
}

void* CGALGlobal_EIK_Barycenter_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::Barycenter_EIK_Point2(p, q, r);
}

void* CGALGlobal_EEK_Barycenter_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EEK>::Barycenter_EEK_Point2(p, q, r);
}

Point3d CGALGlobal_EIK_Barycenter_Point3d(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::Barycenter_Point3d(p, q, r);
}

//---------------------------------------------------------------------------//
//                              Bisector                                     //
//---------------------------------------------------------------------------//

Line2d CGALGlobal_EIK_Bisector_Point3d(Point3d p, Point3d q)
{
	return CGALGlobal<EIK>::Bisector_Point3d(p, q);
}

Line2d CGALGlobal_EIK_Bisector_Line2d(Line2d p, Line2d q)
{
	return CGALGlobal<EIK>::Bisector_Line2d(p, q);
}

void* CGALGlobal_EIK_Bisector_Line2(void* p, void* q)
{
	return CGALGlobal<EIK>::Bisector_EIK_Line2(p, q);
}

void* CGALGlobal_EEK_Bisector_Line2(void* p, void* q)
{
	return CGALGlobal<EEK>::Bisector_EEK_Line2(p, q);
}

//---------------------------------------------------------------------------//
//                             Coplanar                                      //
//---------------------------------------------------------------------------//

BOOL CGALGlobal_EIK_Coplanar_Point3d(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EIK>::Coplanar_Point3d(p, q, r, s);
}

//---------------------------------------------------------------------------//
//                          CoplanarOrientation                              //
//---------------------------------------------------------------------------//

CGAL::Orientation CGALGlobal_EIK_CoplanarOrientation_3Point3d(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::CoplanarOrientation_Point3d(p, q, r);
}

CGAL::Orientation CGALGlobal_EIK_CoplanarOrientation_4Point3d(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EIK>::CoplanarOrientation_Point3d(p, q, r, s);
}

//---------------------------------------------------------------------------//
//                            EquidistantLine                                //
//---------------------------------------------------------------------------//

Line3d CGALGlobal_EIK_EquidistantLine_Line3d(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::EquidistantLine_Point3d(p, q, r);
}

//---------------------------------------------------------------------------//
//                               LeftTurn                                    //
//---------------------------------------------------------------------------//

BOOL CGALGlobal_EIK_LeftTurn_Point2d(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::LeftTurn_Point2d(p, q, r);
}

BOOL CGALGlobal_EIK_LeftTurn_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::LeftTurn_EIK_Point2(p, q, r);
}

BOOL CGALGlobal_EEK_LeftTurn_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EEK>::LeftTurn_EEK_Point2(p, q, r);
}

//---------------------------------------------------------------------------//
//                             RightTurn                                     //
//---------------------------------------------------------------------------//

BOOL CGALGlobal_EIK_RightTurn_Point2d(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::RightTurn_Point2d(p, q, r);
}

BOOL CGALGlobal_EIK_RightTurn_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::RightTurn_EIK_Point2(p, q, r);
}

BOOL CGALGlobal_EEK_RightTurn_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EEK>::RightTurn_EEK_Point2(p, q, r);
}

//---------------------------------------------------------------------------//
//                             Orientation                                   //
//---------------------------------------------------------------------------//

CGAL::Orientation CGALGlobal_EIK_Orientation_Point2d(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::Orientation_Point2d(p, q, r);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::Orientation_EIK_Point2(p, q, r);
}

CGAL::Orientation CGALGlobal_EEK_Orientation_Point2(void* p, void* q, void* r)
{
	return CGALGlobal<EEK>::Orientation_EEK_Point2(p, q, r);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Vector2d(Vector2d u, Vector2d v)
{
	return CGALGlobal<EIK>::Orientation_Vector2d(u, v);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Vector2(void* p, void* q)
{
	return CGALGlobal<EIK>::Orientation_EIK_Vector2(p, q);
}

CGAL::Orientation CGALGlobal_EEK_Orientation_Vector2(void* p, void* q)
{
	return CGALGlobal<EEK>::Orientation_EEK_Vector2(p, q);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Point3d(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EIK>::Orientation_Point3d(p, q, r, s);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Vector3d(Vector3d u, Vector3d v, Vector3d w)
{
	return CGALGlobal<EIK>::Orientation_Vector3d(u, v, w);
}

//---------------------------------------------------------------------------//
//                            OrthogonalVector                               //
//---------------------------------------------------------------------------//

Vector3d CGALGlobal_EIK_OrthogonalVector_Point3d(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::OrthogonalVector_Point3d(p, q, r);
}

void* CGALGlobal_EIK_OrthogonalVector_Point3(void* p, void* q, void* r)
{
	return CGALGlobal<EIK>::OrthogonalVector_EIK_Point3(p, q, r);
}

void* CGALGlobal_EEK_OrthogonalVector_Point3(void* p, void* q, void* r)
{
	return CGALGlobal<EEK>::OrthogonalVector_EEK_Point3(p, q, r);
}

//---------------------------------------------------------------------------//
//                              Parallel                                     //
//---------------------------------------------------------------------------//

BOOL CGALGlobal_EIK_Parallel_Line2d(Line2d l1, Line2d l2)
{
	return CGALGlobal<EIK>::Parallel_Line2d(l1, l2);
}

BOOL CGALGlobal_EIK_Parallel_Line2(void* l1, void* l2)
{
	return CGALGlobal<EIK>::Parallel_EIK_Line2d(l1, l2);
}

BOOL CGALGlobal_EEK_Parallel_Line2(void* l1, void* l2)
{
	return CGALGlobal<EEK>::Parallel_EEK_Line2d(l1, l2);
}

BOOL CGALGlobal_EIK_Parallel_Ray2d(Ray2d r1, Ray2d r2)
{
	return CGALGlobal<EIK>::Parallel_Ray2d(r1, r2);
}

BOOL CGALGlobal_EIK_Parallel_Ray2(void* r1, void* r2)
{
	return CGALGlobal<EIK>::Parallel_EIK_Ray2d(r1, r2);
}

BOOL CGALGlobal_EEK_Parallel_Ray2(void* r1, void* r2)
{
	return CGALGlobal<EEK>::Parallel_EEK_Ray2d(r1, r2);
}

BOOL CGALGlobal_EIK_Parallel_Segment2d(Segment2d s1, Segment2d s2)
{
	return CGALGlobal<EIK>::Parallel_Segment2d(s1, s2);
}

BOOL CGALGlobal_EIK_Parallel_Segment2(void* s1, void* s2)
{
	return CGALGlobal<EIK>::Parallel_EIK_Segment2d(s1, s2);
}

BOOL CGALGlobal_EEK_Parallel_Segment2(void* s1, void* s2)
{
	return CGALGlobal<EEK>::Parallel_EEK_Segment2d(s1, s2);
}


