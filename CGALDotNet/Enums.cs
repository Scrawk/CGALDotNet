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

    public static class CGALEnum
    {
        public static CGAL_BOUNDED_SIDE Opposite(CGAL_BOUNDED_SIDE e) => (CGAL_BOUNDED_SIDE)(-(int)e);

        public static CGAL_COMPARISON_RESULT Opposite(CGAL_COMPARISON_RESULT e) => (CGAL_COMPARISON_RESULT)(-(int)e);

        public static CGAL_SIGN Opposite(CGAL_SIGN e) => (CGAL_SIGN)(-(int)e);

        public static CGAL_CLOCK_DIR Opposite(CGAL_CLOCK_DIR e) => (CGAL_CLOCK_DIR)(-(int)e);

        public static CGAL_ORIENTATION Opposite(CGAL_ORIENTATION e) => (CGAL_ORIENTATION)(-(int)e);

        public static CGAL_ORIENTED_SIDE Opposite(CGAL_ORIENTED_SIDE e) => (CGAL_ORIENTED_SIDE)(-(int)e);

        public static bool SameOrientation(CGAL_ORIENTATION e1, CGAL_ORIENTED_SIDE e2) => e1 == (CGAL_ORIENTATION)e2;

        public static bool OppositeOrientation(CGAL_ORIENTATION e1, CGAL_ORIENTED_SIDE e2) => Opposite(e1) == (CGAL_ORIENTATION)e2;
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
        ON_BOUNDARY = 0,
        ON_POSITIVE_SIDE = 1,
        UNDETERMINED = 2
    }
}
