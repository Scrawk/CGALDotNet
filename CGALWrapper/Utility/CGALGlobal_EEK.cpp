
#include "../pch.h"
#include "CGALGlobal_EEK.h"
#include "CGALGlobal.h"

#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

CGAL::Angle CGALGlobal_EEK_Angle_Vector2(Vector2d u, Vector2d v)
{
	return CGALGlobal<EEK>::Angle(u, v);
}

CGAL::Angle CGALGlobal_EEK_Angle_Vector3(Vector3d u, Vector3d v)
{
	return CGALGlobal<EEK>::Angle(u, v);
}

double CGALGlobal_EEK_ApproxAngle_Vector3(Vector3d u, Vector3d v)
{
	return CGALGlobal<EEK>::ApproxAngle(u, v);
}

double CGALGlobal_EEK_ApproxDihedralAngle_Point3(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EEK>::ApproxDihedralAngle(p, q, r, s);
}

BOOL CGALGlobal_EEK_AreOrderedAlongLine_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EEK>::AreOrderedAlongLine(p, q, r);
}

BOOL CGALGlobal_EEK_AreOrderedAlongLine_Point3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EEK>::AreOrderedAlongLine(p, q, r);
}

BOOL CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EEK>::AreStrictlyOrderedAlongLine(p, q, r);
}

BOOL CGALGlobal_EEK_AreStrictlyOrderedAlongLine_Point3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EEK>::AreStrictlyOrderedAlongLine(p, q, r);
}

BOOL CGALGlobal_EEK_Collinear_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EEK>::Collinear(p, q, r);
}

BOOL CGALGlobal_EEK_Collinear_Point3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EEK>::Collinear(p, q, r);
}

Line2d CGALGlobal_EEK_Bisector_Point3(Point3d p, Point3d q)
{
	return CGALGlobal<EEK>::Bisector(p, q);
}

Line2d CGALGlobal_EEK_Bisector_Line2(Line2d p, Line2d q)
{
	return CGALGlobal<EEK>::Bisector(p, q);
}

BOOL CGALGlobal_EEK_Coplanar_Point3(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EEK>::Coplanar(p, q, r, s);
}

CGAL::Orientation CGALGlobal_EEK_CoplanarOrientation_3Point3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EEK>::CoplanarOrientation(p, q, r);
}

CGAL::Orientation CGALGlobal_EEK_CoplanarOrientation_4Point3(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EEK>::CoplanarOrientation(p, q, r, s);
}

Line3d CGALGlobal_EEK_EquidistantLine_Line3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EEK>::EquidistantLine(p, q, r);
}


BOOL CGALGlobal_EEK_LeftTurn_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EEK>::LeftTurn(p, q, r);
}

BOOL CGALGlobal_EEK_RightTurn_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EEK>::RightTurn(p, q, r);
}

CGAL::Orientation CGALGlobal_EEK_Orientation_Point2(Point2d p, Point2d q, Point2d r)
{
	return CGALGlobal<EEK>::Orientation(p, q, r);
}

CGAL::Orientation CGALGlobal_EEK_Orientation_Vector2(Vector2d u, Vector2d v)
{
	return CGALGlobal<EEK>::Orientation(u, v);
}

CGAL::Orientation CGALGlobal_EEK_Orientation_Point3(Point3d p, Point3d q, Point3d r, Point3d s)
{
	return CGALGlobal<EEK>::Orientation(p, q, r, s);
}

CGAL::Orientation CGALGlobal_EEK_Orientation_Vector3(Vector3d u, Vector3d v, Vector3d w)
{
	return CGALGlobal<EEK>::Orientation(u, v, w);
}

Vector3d CGALGlobal_EEK_OrthogonalVector_Point3(Point3d p, Point3d q, Point3d r)
{
	return CGALGlobal<EEK>::OrthogonalVector(p, q, r);
}

BOOL CGALGlobal_EEK_Parallel_Line2(Line2d l1, Line2d l2)
{
	return CGALGlobal<EEK>::Parallel(l1, l2);
}

BOOL CGALGlobal_EEK_Parallel_Ray2(Ray2d r1, Ray2d r2)
{
	return CGALGlobal<EEK>::Parallel(r1, r2);
}

BOOL CGALGlobal_EEK_Parallel_Segment2(Segment2d s1, Segment2d s2)
{
	return CGALGlobal<EEK>::Parallel(s1, s2);
}
