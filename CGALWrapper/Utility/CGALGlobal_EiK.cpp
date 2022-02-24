
#include "../pch.h"
#include "CGALGlobal_EIK.h"
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

BOOL CGALGlobal_EIK_Collinear_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::Collinear(p, q, r);
}

BOOL CGALGlobal_EIK_Collinear_Point3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::Collinear(p, q, r);
}

Line2d CGALGlobal_EIK_Bisector_Point3(Point3d p, Point3d q)
{
	return CGALGlobal<EIK>::Bisector(p, q);
}

Line2d CGALGlobal_EIK_Bisector_Line2(Line2d p, Line2d q)
{
	return CGALGlobal<EIK>::Bisector(p, q);
}

BOOL CGALGlobal_EIK_Coplanar_Point3(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EIK>::Coplanar(p, q, r, s);
}

CGAL::Orientation CGALGlobal_EIK_CoplanarOrientation_3Point3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::CoplanarOrientation(p, q, r);
}

CGAL::Orientation CGALGlobal_EIK_CoplanarOrientation_4Point3(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EIK>::CoplanarOrientation(p, q, r, s);
}

Line3d CGALGlobal_EIK_EquidistantLine_Line3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::EquidistantLine(p, q, r);
}


BOOL CGALGlobal_EIK_LeftTurn_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::LeftTurn(p, q, r);
}

BOOL CGALGlobal_EIK_RightTurn_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::RightTurn(p, q, r);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EIK>::Orientation(p, q, r);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Vector2(Vector2d u, Vector2d v)
{
	return CGALGlobal<EIK>::Orientation(u, v);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Point3(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EIK>::Orientation(p, q, r, s);
}

CGAL::Orientation CGALGlobal_EIK_Orientation_Vector3(Vector3d u, Vector3d v, Vector3d w)
{
	return CGALGlobal<EIK>::Orientation(u, v, w);
}

Vector3d CGALGlobal_EIK_OrthogonalVector_Point3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EIK>::OrthogonalVector(p, q, r);
}

BOOL CGALGlobal_EIK_Parallel_Line2(Line2d l1, Line2d l2)
{
	return CGALGlobal<EIK>::Parallel(l1, l2);
}

BOOL CGALGlobal_EIK_Parallel_Ray2(Ray2d r1, Ray2d r2)
{
	return CGALGlobal<EIK>::Parallel(r1, r2);
}

BOOL CGALGlobal_EIK_Parallel_Segment2(Segment2d s1, Segment2d s2)
{
	return CGALGlobal<EIK>::Parallel(s1, s2);
}
