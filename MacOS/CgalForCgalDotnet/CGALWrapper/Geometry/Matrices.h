#pragma once

#include "../CGALWrapper.h"

#include <CGAL/Aff_transformation_3.h>

/*
* Structs to pass data from C# and c++.
* Must be c style layout.
*
* A standard-layout class is a class that:
*
* Has no non-static data members of type non-standard-layout class (or array of such types) or reference,
* Has no virtual functions and no virtual base classes,
* Has the same access control for all non-static data members,
* Has no non-standard-layout base classes,
* Either has no non-static data members in the most derived class and at most one base class with non-static data members,
* or has no base classes with non-static data members, and
* Has no base classes of the same type as the first non-static data member.
*
*/

struct Matrix4x4d
{
    double m00, m10, m20, m30;
    double m01, m11, m21, m31;
    double m02, m12, m22, m32;
    double m03, m13, m23, m33;

    template<class K>
    CGAL::Aff_transformation_3<K> ToCGAL() const
    {
        return CGAL::Aff_transformation_3<K>(
            m00, m01, m02, m03,
            m10, m11, m12, m13,
            m20, m21, m22, m23,
            /*m30, m31, m32,*/ m33);
    }

};
