#pragma once

#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"

template<class K>
class CGALGlobal
{
private:

    typedef CGAL::Point_2<K> Point2;
    typedef CGAL::Vector_2<K> Vector2;
    typedef CGAL::Line_2<K> Line2;
    typedef CGAL::Line_3<K> Line3;
    typedef CGAL::Ray_2<K> Ray2;
    typedef CGAL::Segment_2<K> Segment2;
    typedef CGAL::Triangle_2<K> Triangle2;
    typedef CGAL::Iso_rectangle_2<K> Box2;
    typedef std::vector<Point2> Polygon2;

    inline static CGAL::Vector_2<EIK>* CastToVector2_EIK(void* ptr)
    {
        return static_cast<CGAL::Vector_2<EIK>*>(ptr);
    }

    inline static CGAL::Vector_2<EEK>* CastToVector2_EEK(void* ptr)
    {
        return static_cast<CGAL::Vector_2<EEK>*>(ptr);
    }

    inline static CGAL::Point_2<EIK>* CastToPoint2_EIK(void* ptr)
    {
        return static_cast<CGAL::Point_2<EIK>*>(ptr);
    }

    inline static CGAL::Point_2<EEK>* CastToPoint2_EEK(void* ptr)
    {
        return static_cast<CGAL::Point_2<EEK>*>(ptr);
    }

public:

    //---------------------------------------------------------------------------//
    //                               Angle                                       //
    //---------------------------------------------------------------------------//

    static CGAL::Angle Angle_Vector2(Vector2d u, Vector2d v)
    {
        return CGAL::angle(u.ToCGAL<K>(), v.ToCGAL<K>());
    }

    static CGAL::Angle Angle_EIK_Vector2(void* u, void* v)
    {
        auto U = CastToVector2_EIK(u);
        auto V = CastToVector2_EIK(v);
        return CGAL::angle(*U, *V);
    }

    static CGAL::Angle Angle_EEK_Vector2(void* u, void* v)
    {
        auto U = CastToVector2_EEK(u);
        auto V = CastToVector2_EEK(v);
        return CGAL::angle(*U, *V);
    }

    static CGAL::Angle Angle_Vector3(Vector3d u, Vector3d v)
    {
        return CGAL::angle(u.ToCGAL<K>(), v.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                           ApproxAngle                                     //
    //---------------------------------------------------------------------------//

    static double ApproxAngle_Vector3d(Vector3d u, Vector3d v)
    {
        auto d = CGAL::approximate_angle(u.ToCGAL<K>(), v.ToCGAL<K>());
        return CGAL::to_double(d);
    }

    //---------------------------------------------------------------------------//
    //                           ApproxApproxAngle                               //
    //---------------------------------------------------------------------------//

    static double ApproxDihedralAngle(Point3d p, Point3d q, Point3d r, Point3d s)
    {
        auto d = CGAL::approximate_dihedral_angle(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>(), s.ToCGAL<K>());
        return CGAL::to_double(d);
    }

    //---------------------------------------------------------------------------//
    //                           AreOrderedAlongLine                             //
    //---------------------------------------------------------------------------//

    static BOOL AreOrderedAlongLine_Point2d(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::are_ordered_along_line(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static BOOL AreOrderedAlongLine_EIK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EIK(p);
        auto Q = CastToPoint2_EIK(q);
        auto R = CastToPoint2_EIK(r);
        return CGAL::are_ordered_along_line(*P, *Q, *R);
    }

    static BOOL AreOrderedAlongLine_EEK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EEK(p);
        auto Q = CastToPoint2_EEK(q);
        auto R = CastToPoint2_EEK(r);
        return CGAL::are_ordered_along_line(*P, *Q, *R);
    }

    static BOOL AreOrderedAlongLine_Point3d(Point3d p, Point3d q, Point3d r)
    {
        return CGAL::are_ordered_along_line(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                           AreStrictlyOrderedAlongLine                             //
    //---------------------------------------------------------------------------//

    static BOOL AreStrictlyOrderedAlongLine_Point2d(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::are_strictly_ordered_along_line(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static BOOL AreStrictlyOrderedAlongLine_EIK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EIK(p);
        auto Q = CastToPoint2_EIK(q);
        auto R = CastToPoint2_EIK(r);
        return CGAL::are_strictly_ordered_along_line(*P, *Q, *R);
    }

    static BOOL AreStrictlyOrderedAlongLine_EEK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EEK(p);
        auto Q = CastToPoint2_EEK(q);
        auto R = CastToPoint2_EEK(r);
        return CGAL::are_strictly_ordered_along_line(*P, *Q, *R);
    }

    static BOOL AreStrictlyOrderedAlongLine_Point3d(Point3d p, Point3d q, Point3d r)
    {
        return CGAL::are_strictly_ordered_along_line(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                                  Collinear                                //
    //---------------------------------------------------------------------------//

    static BOOL Collinear(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::collinear(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static BOOL Collinear(Point3d p, Point3d q, Point3d r)
    {
        return CGAL::collinear(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                                                                           //
    //---------------------------------------------------------------------------//

    static Line2d Bisector(Point3d p, Point3d q)
    {
        auto l = CGAL::bisector(p.ToCGAL<K>(), q.ToCGAL<K>());
        auto a = CGAL::to_double(l.a());
        auto b = CGAL::to_double(l.b());
        auto c = CGAL::to_double(l.c());
        return { a, b, c };
    }

    static Line2d Bisector(Line2d p, Line2d q)
    {
        auto l = CGAL::bisector(p.ToCGAL<K, Line2>(), q.ToCGAL<K, Line2>());
        auto a = CGAL::to_double(l.a());
        auto b = CGAL::to_double(l.b());
        auto c = CGAL::to_double(l.c());
        return { a, b, c };
    }

    //---------------------------------------------------------------------------//
    //                                                                           //
    //---------------------------------------------------------------------------//

    static BOOL Coplanar(Point3d p, Point3d q, Point3d r, Point3d s)
    {
        return CGAL::coplanar(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>(), s.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                                                                           //
    //---------------------------------------------------------------------------//

    static CGAL::Orientation CoplanarOrientation(Point3d p, Point3d q, Point3d r)
    {
        return CGAL::coplanar_orientation(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static CGAL::Orientation CoplanarOrientation(Point3d p, Point3d q, Point3d r, Point3d s)
    {
        return CGAL::coplanar_orientation(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>(), s.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                                                                           //
    //---------------------------------------------------------------------------//

    static Line3d EquidistantLine(Point3d p, Point3d q, Point3d r)
    {
        auto l = CGAL::equidistant_line(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
        return Line3d::FromCGAL<K>(l.point(), l.to_vector());
    }

    //---------------------------------------------------------------------------//
    //                                                                           //
    //---------------------------------------------------------------------------//

    static BOOL LeftTurn(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::left_turn(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                                                                           //
    //---------------------------------------------------------------------------//

    static BOOL RightTurn(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::right_turn(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                                                                           //
    //---------------------------------------------------------------------------//

    static CGAL::Orientation Orientation(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::orientation(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static CGAL::Orientation Orientation(Vector2d u, Vector2d v)
    {
        return CGAL::orientation(u.ToCGAL<K>(), v.ToCGAL<K>());
    }

    static CGAL::Orientation Orientation(Point3d p, Point3d q, Point3d r, Point3d s)
    {
        return CGAL::orientation(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>(), s.ToCGAL<K>());
    }

    static CGAL::Orientation Orientation(Vector3d u, Vector3d v, Vector3d w)
    {
        return CGAL::orientation(u.ToCGAL<K>(), v.ToCGAL<K>(), w.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                                                                           //
    //---------------------------------------------------------------------------//

    static Vector3d OrthogonalVector(Point3d p, Point3d q, Point3d r)
    {
        auto v = CGAL::orthogonal_vector(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
        return Vector3d::FromCGAL<K>(v);
    }

    static BOOL Parallel(Line2d l1, Line2d l2)
    {
        auto L1 = l1.ToCGAL<K, Line2>();
        auto L2 = l2.ToCGAL<K, Line2>();
        return CGAL::parallel(L1, L2);
    }

    static BOOL Parallel(Ray2d r1, Ray2d r2)
    {
        auto R1 = r1.ToCGAL<K, Ray2>();
        auto R2 = r2.ToCGAL<K, Ray2>();
        return CGAL::parallel(R1, R2);
    }

    static BOOL Parallel(Segment2d s1, Segment2d s2)
    {
        auto S1 = s1.ToCGAL<K, Segment2>();
        auto S2 = s2.ToCGAL<K, Segment2>();
        return CGAL::parallel(S1, S2);
    }
};


