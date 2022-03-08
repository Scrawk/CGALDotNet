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
        public static BOUNDED_SIDE Opposite(BOUNDED_SIDE e) => (BOUNDED_SIDE)(-(int)e);

        public static COMPARISON_RESULT Opposite(COMPARISON_RESULT e) => (COMPARISON_RESULT)(-(int)e);

        public static SIGN Opposite(SIGN e) => (SIGN)(-(int)e);

        public static CLOCK_DIR Opposite(CLOCK_DIR e) => (CLOCK_DIR)(-(int)e);

        public static ORIENTATION Opposite(ORIENTATION e) => (ORIENTATION)(-(int)e);

        public static ORIENTED_SIDE Opposite(ORIENTED_SIDE e) => (ORIENTED_SIDE)(-(int)e);

        public static bool SameOrientation(ORIENTATION e1, ORIENTED_SIDE e2) => e1 == (ORIENTATION)e2;

        public static bool OppositeOrientation(ORIENTATION e1, ORIENTED_SIDE e2) => Opposite(e1) == (ORIENTATION)e2;

        public static T Next<T>(this T src)
        {
            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

        public static int Count<T>()
        {
            return Enum.GetValues(typeof(T)).Length;
        }

        public static CGAL_KERNEL ToKernelEnum(string k)
        {
            switch (k)
            {
                case "EIK":
                    return CGAL_KERNEL.EIK;

                case "EEK":
                    return CGAL_KERNEL.EEK;

                case "EEK_SQRT2":
                    return CGAL_KERNEL.EEK_SQRT2;

                case "EEK_KTH_ROOT":
                    return CGAL_KERNEL.EEK_KTH_ROOT;

                case "EEK_ROOT_OF":
                    return CGAL_KERNEL.EEK_ROOT_OF;

                default:
                    throw new Exception("Unhandled case.");
            }
        }
    }

    public enum ANGLE 
    { 
        OBTUSE = -1, 
        RIGHT = 0, 
        ACUTE = 1 
    }

    public enum BOUNDED_SIDE
    { 
        ON_UNBOUNDED_SIDE = -1, 
        ON_BOUNDARY = 0, 
        ON_BOUNDED_SIDE = 1,
        UNDETERMINED = 2
    }

    public enum COMPARISON_RESULT 
    { 
        SMALLER = -1, 
        EQUAL = 0, 
        LARGER = 1
    }

    public enum SIGN 
    { 
        NEGATIVE = -1, 
        ZERO = 0, 
        POSITIVE = 1
    }

    public enum CLOCK_DIR
    {
        CLOCKWISE = -1,
        ZERO = 0,
        COUNTER_CLOCKWISE = 1
    }

    public enum ORIENTATION
    {
        NEGATIVE = -1,
        ZERO = 0,
        POSITIVE = 1
    }

    public enum ORIENTED_SIDE
    { 
        ON_NEGATIVE_SIDE = -1, 
        ON_BOUNDARY = 0,
        ON_POSITIVE_SIDE = 1,
        UNDETERMINED = 2
    }

    public enum BOOL_OR_UNDETERMINED
    {
        FALSE = 0,
        TRUE = 1,
        UNDETERMINED = 2
    }

    public enum MESH_TYPE
    {
        POLYHEDRON,
        SURFACE_MESH
    }

}
