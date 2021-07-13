using System;
using System.Collections.Generic;

namespace CGALDotNet
{
    public enum CGAL_KERNEL
    {
        EIK = 0,
        EEK = 1,
        EEK_SQRT2 = 2,
        EEK_KTH_ROOT = 3,
        EEK_ROOT_OF = 4
    }

    public enum CGAL_KERNEL_LONG
    {
        EXACT_PREDICATES_INEXACT_CONSTRUCTION = 0,
        EXACT_PREDICATES_EXACT_CONSTRUCTION = 1,
        EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_SQRT2 = 2,
        EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_KTH_ROOT = 3,
        EXACT_PREDICATES_EXACT_CONSTRUCTION_WITH_ROOT_OF = 4
    }

    public enum CGAL_ANGLE 
    { 
        OBTUSE = -1, 
        RIGHT = 0, 
        ACUTE = 1 
    }

    public enum CGAL_BOUNDED_SIDE
    { 
        ON_UNBOUNDED_SIDE = -1, 
        ON_BOUNDARY = 0, 
        ON_BOUNDED_SIDE = 1
    }

    public enum CGAL_COMPARISON_RESULT 
    { 
        SMALLER = -1, 
        EQUAL = 0, 
        LARGER = 1
    }

    public enum CGAL_SIGN 
    { 
        NEGATIVE = -1, 
        ZERO = 0, 
        POSITIVE = 1
    }

    public enum CGAL_CLOCK_DIR
    {
        CLOCKWISE = -1,
        ZERO = 0,
        COUNTER_CLOCKWISE = 1
    }

    public enum CGAL_ORIENTATION
    {
        NEGATIVE = -1,
        ZERO = 0,
        POSITIVE = 1
    }

    public enum CGAL_ORIENTED_SIDE
    { 
        ON_NEGATIVE_SIDE = -1, 
        ON_ORIENTED_BOUNDARY = 0,
        ON_POSITIVE_SIDE = 1
    }
}
