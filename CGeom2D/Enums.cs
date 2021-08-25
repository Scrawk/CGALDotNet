using System;
using System.Collections.Generic;
using System.Text;

namespace CGeom2D
{
    public enum INTERSECTION
    {
        NONE,
        COLLINEAR,
        INTERSECT
    }

    public enum BOUNDED_SIDE
    {
        ON_UNBOUNDED_SIDE = -1,
        ON_BOUNDARY = 0,
        ON_BOUNDED_SIDE = 1
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
}
