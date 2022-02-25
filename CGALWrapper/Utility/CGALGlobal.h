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

    inline static CGAL::Vector_3<EIK>* CastToVector3_EIK(void* ptr)
    {
        return static_cast<CGAL::Vector_3<EIK>*>(ptr);
    }

    inline static CGAL::Vector_3<EEK>* CastToVector3_EEK(void* ptr)
    {
        return static_cast<CGAL::Vector_3<EEK>*>(ptr);
    }

    inline static CGAL::Point_2<EIK>* CastToPoint2_EIK(void* ptr)
    {
        return static_cast<CGAL::Point_2<EIK>*>(ptr);
    }

    inline static CGAL::Point_2<EEK>* CastToPoint2_EEK(void* ptr)
    {
        return static_cast<CGAL::Point_2<EEK>*>(ptr);
    }

    inline static CGAL::Point_3<EIK>* CastToPoint3_EIK(void* ptr)
    {
        return static_cast<CGAL::Point_3<EIK>*>(ptr);
    }

    inline static CGAL::Point_3<EEK>* CastToPoint3_EEK(void* ptr)
    {
        return static_cast<CGAL::Point_3<EEK>*>(ptr);
    }

    inline static CGAL::Line_2<EIK>* CastToLine2_EIK(void* ptr)
    {
        return static_cast<CGAL::Line_2<EIK>*>(ptr);
    }

    inline static CGAL::Line_2<EEK>* CastToLine2_EEK(void* ptr)
    {
        return static_cast<CGAL::Line_2<EEK>*>(ptr);
    }

    inline static CGAL::Ray_2<EIK>* CastToRay2_EIK(void* ptr)
    {
        return static_cast<CGAL::Ray_2<EIK>*>(ptr);
    }

    inline static CGAL::Ray_2<EEK>* CastToRay2_EEK(void* ptr)
    {
        return static_cast<CGAL::Ray_2<EEK>*>(ptr);
    }

    inline static CGAL::Segment_2<EIK>* CastToSegment2_EIK(void* ptr)
    {
        return static_cast<CGAL::Segment_2<EIK>*>(ptr);
    }

    inline static CGAL::Segment_2<EEK>* CastToSegment2_EEK(void* ptr)
    {
        return static_cast<CGAL::Segment_2<EEK>*>(ptr);
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

    static BOOL Collinear_Point2d(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::collinear(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static BOOL Collinear_EIK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EIK(p);
        auto Q = CastToPoint2_EIK(q);
        auto R = CastToPoint2_EIK(r);
        return CGAL::collinear(*P, *Q, *R);
    }

    static BOOL Collinear_EEK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EEK(p);
        auto Q = CastToPoint2_EEK(q);
        auto R = CastToPoint2_EEK(r);
        return CGAL::collinear(*P, *Q, *R);
    }

    static BOOL Collinear_Point3d(Point3d p, Point3d q, Point3d r)
    {
        return CGAL::collinear(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                              Barycenter                                   //
    //---------------------------------------------------------------------------//

    static Point2d Barycenter_Point2d(Point2d p, Point2d q, Point2d r)
    {
        auto bc = CGAL::barycenter(p.ToCGAL<K>(), 1, q.ToCGAL<K>(), 1, r.ToCGAL<K>(), 1);
        double x = CGAL::to_double(bc.x());
        double y = CGAL::to_double(bc.y());
        return { x, y };
    }

    static void* Barycenter_EIK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EIK(p);
        auto Q = CastToPoint2_EIK(q);
        auto R = CastToPoint2_EIK(r);
        auto bc = CGAL::barycenter(*P, 1, *Q, 1, *R, 1);

        return new CGAL::Point_2<EIK>(bc.x(), bc.y());
    }

    static void* Barycenter_EEK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EEK(p);
        auto Q = CastToPoint2_EEK(q);
        auto R = CastToPoint2_EEK(r);
        auto bc = CGAL::barycenter(*P, 1, *Q, 1, *R, 1);

        return new CGAL::Point_2<EEK>(bc.x(), bc.y());
    }

    static Point3d Barycenter_Point3d(Point3d p, Point3d q, Point3d r)
    {
        auto bc = CGAL::barycenter(p.ToCGAL<K>(), 1, q.ToCGAL<K>(), 1, r.ToCGAL<K>(), 1);
        double x = CGAL::to_double(bc.x());
        double y = CGAL::to_double(bc.y());
        double z = CGAL::to_double(bc.z());
        return { x, y, z};
    }

    //---------------------------------------------------------------------------//
    //                              Bisector                                     //
    //---------------------------------------------------------------------------//

    static Line2d Bisector_Point3d(Point3d p, Point3d q)
    {
        auto l = CGAL::bisector(p.ToCGAL<K>(), q.ToCGAL<K>());
        auto a = CGAL::to_double(l.a());
        auto b = CGAL::to_double(l.b());
        auto c = CGAL::to_double(l.c());
        return { a, b, c };
    }

    static Line2d Bisector_Line2d(Line2d p, Line2d q)
    {
        auto l = CGAL::bisector(p.ToCGAL<K, Line2>(), q.ToCGAL<K, Line2>());
        auto a = CGAL::to_double(l.a());
        auto b = CGAL::to_double(l.b());
        auto c = CGAL::to_double(l.c());
        return { a, b, c };
    }

    static void* Bisector_EIK_Line2(void* p, void* q)
    {
        auto P = CastToLine2_EIK(p);
        auto Q = CastToLine2_EIK(q);

        auto l = CGAL::bisector(*P, *Q);
        return new CGAL::Line_2<EIK>(l.a(), l.b(), l.c());
    }

    static void* Bisector_EEK_Line2(void* p, void* q)
    {
        auto P = CastToLine2_EEK(p);
        auto Q = CastToLine2_EEK(q);

        auto l = CGAL::bisector(*P, *Q);
        return new CGAL::Line_2<EEK>(l.a(), l.b(), l.c());
    }

    //---------------------------------------------------------------------------//
    //                             Coplanar                                      //
    //---------------------------------------------------------------------------//

    static BOOL Coplanar_Point3d(Point3d p, Point3d q, Point3d r, Point3d s)
    {
        return CGAL::coplanar(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>(), s.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                            CoplanarOrientation                            //
    //---------------------------------------------------------------------------//

    static CGAL::Orientation CoplanarOrientation_Point3d(Point3d p, Point3d q, Point3d r)
    {
        return CGAL::coplanar_orientation(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static CGAL::Orientation CoplanarOrientation_Point3d(Point3d p, Point3d q, Point3d r, Point3d s)
    {
        return CGAL::coplanar_orientation(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>(), s.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                               EquidistantLine                             //
    //---------------------------------------------------------------------------//

    static Line3d EquidistantLine_Point3d(Point3d p, Point3d q, Point3d r)
    {
        auto l = CGAL::equidistant_line(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
        return Line3d::FromCGAL<K>(l.point(), l.to_vector());
    }

    //---------------------------------------------------------------------------//
    //                            LeftTurn                                       //
    //---------------------------------------------------------------------------//

    static BOOL LeftTurn_Point2d(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::left_turn(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static BOOL LeftTurn_EIK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EIK(p);
        auto Q = CastToPoint2_EIK(q);
        auto R = CastToPoint2_EIK(r);
        return CGAL::left_turn(*P, *Q, *R);
    }

    static BOOL LeftTurn_EEK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EEK(p);
        auto Q = CastToPoint2_EEK(q);
        auto R = CastToPoint2_EEK(r);
        return CGAL::left_turn(*P, *Q, *R);
    }

    //---------------------------------------------------------------------------//
    //                            RightTurn                                      //
    //---------------------------------------------------------------------------//

    static BOOL RightTurn_Point2d(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::right_turn(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static BOOL RightTurn_EIK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EIK(p);
        auto Q = CastToPoint2_EIK(q);
        auto R = CastToPoint2_EIK(r);
        return CGAL::right_turn(*P, *Q, *R);
    }

    static BOOL RightTurn_EEK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EEK(p);
        auto Q = CastToPoint2_EEK(q);
        auto R = CastToPoint2_EEK(r);
        return CGAL::right_turn(*P, *Q, *R);
    }

    //---------------------------------------------------------------------------//
    //                              Orientation                                  //
    //---------------------------------------------------------------------------//

    static CGAL::Orientation Orientation_Point2d(Point2d p, Point2d q, Point2d r)
    {
        return CGAL::orientation(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
    }

    static CGAL::Orientation Orientation_EIK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EIK(p);
        auto Q = CastToPoint2_EIK(q);
        auto R = CastToPoint2_EIK(r);
        return CGAL::orientation(*P, *Q, *R);
    }

    static CGAL::Orientation Orientation_EEK_Point2(void* p, void* q, void* r)
    {
        auto P = CastToPoint2_EEK(p);
        auto Q = CastToPoint2_EEK(q);
        auto R = CastToPoint2_EEK(r);
        return CGAL::orientation(*P, *Q, *R);
    }

    static CGAL::Orientation Orientation_Vector2d(Vector2d u, Vector2d v)
    {
        return CGAL::orientation(u.ToCGAL<K>(), v.ToCGAL<K>());
    }

    static CGAL::Orientation Orientation_EIK_Vector2(void* p, void* q)
    {
        auto P = CastToVector2_EIK(p);
        auto Q = CastToVector2_EIK(q);
        return CGAL::orientation(*P, *Q);
    }

    static CGAL::Orientation Orientation_EEK_Vector2(void* p, void* q)
    {
        auto P = CastToVector2_EEK(p);
        auto Q = CastToVector2_EEK(q);
        return CGAL::orientation(*P, *Q);
    }

    static CGAL::Orientation Orientation_Point3d(Point3d p, Point3d q, Point3d r, Point3d s)
    {
        return CGAL::orientation(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>(), s.ToCGAL<K>());
    }

    static CGAL::Orientation Orientation_Vector3d(Vector3d u, Vector3d v, Vector3d w)
    {
        return CGAL::orientation(u.ToCGAL<K>(), v.ToCGAL<K>(), w.ToCGAL<K>());
    }

    //---------------------------------------------------------------------------//
    //                            OrthogonalVector                               //
    //---------------------------------------------------------------------------//

    static Vector3d OrthogonalVector_Point3d(Point3d p, Point3d q, Point3d r)
    {
        auto v = CGAL::orthogonal_vector(p.ToCGAL<K>(), q.ToCGAL<K>(), r.ToCGAL<K>());
        return Vector3d::FromCGAL<K>(v);
    }

    static void* OrthogonalVector_EIK_Point3(void* p, void* q, void* r)
    {
        auto P = CastToPoint3_EIK(p);
        auto Q = CastToPoint3_EIK(q);
        auto R = CastToPoint3_EIK(r);
        auto v = CGAL::orthogonal_vector(*P, *Q, *R);

        return new CGAL::Vector_3<EIK>(v.x(), v.y(), v.z());
    }

    static void* OrthogonalVector_EEK_Point3(void* p, void* q, void* r)
    {
        auto P = CastToPoint3_EEK(p);
        auto Q = CastToPoint3_EEK(q);
        auto R = CastToPoint3_EEK(r);
        auto v = CGAL::orthogonal_vector(*P, *Q, *R);

        return new CGAL::Vector_3<EEK>(v.x(), v.y(), v.z());
    }

    //---------------------------------------------------------------------------//
    //                            Parallel                                       //
    //---------------------------------------------------------------------------//

    static BOOL Parallel_Line2d(Line2d l1, Line2d l2)
    {
        auto L1 = l1.ToCGAL<K, Line2>();
        auto L2 = l2.ToCGAL<K, Line2>();
        return CGAL::parallel(L1, L2);
    }

    static BOOL Parallel_EIK_Line2d(void* l1, void* l2)
    {
        auto L1 = CastToLine2_EIK(l1);
        auto L2 = CastToLine2_EIK(l2);
        return CGAL::parallel(*L1, *L2);
    }

    static BOOL Parallel_EEK_Line2d(void* l1, void* l2)
    {
        auto L1 = CastToLine2_EEK(l1);
        auto L2 = CastToLine2_EEK(l2);
        return CGAL::parallel(*L1, *L2);
    }

    static BOOL Parallel_Ray2d(Ray2d r1, Ray2d r2)
    {
        auto R1 = r1.ToCGAL<K, Ray2>();
        auto R2 = r2.ToCGAL<K, Ray2>();
        return CGAL::parallel(R1, R2);
    }

    static BOOL Parallel_EIK_Ray2d(void* r1, void* r2)
    {
        auto R1 = CastToRay2_EIK(r1);
        auto R2 = CastToRay2_EIK(r2);
        return CGAL::parallel(*R1, *R2);
    }

    static BOOL Parallel_EEK_Ray2d(void* r1, void* r2)
    {
        auto R1 = CastToRay2_EEK(r1);
        auto R2 = CastToRay2_EEK(r2);
        return CGAL::parallel(*R1, *R2);
    }

    static BOOL Parallel_Segment2d(Segment2d s1, Segment2d s2)
    {
        auto S1 = s1.ToCGAL<K, Segment2>();
        auto S2 = s2.ToCGAL<K, Segment2>();
        return CGAL::parallel(S1, S2);
    }

    static BOOL Parallel_EIK_Segment2d(void* s1, void* s2)
    {
        auto S1 = CastToSegment2_EIK(s1);
        auto S2 = CastToSegment2_EIK(s2);
        return CGAL::parallel(*S1, *S2);
    }

    static BOOL Parallel_EEK_Segment2d(void* s1, void* s2)
    {
        auto S1 = CastToSegment2_EEK(s1);
        auto S2 = CastToSegment2_EEK(s2);
        return CGAL::parallel(*S1, *S2);
    }
};


