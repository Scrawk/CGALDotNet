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
        UNBOUNDED_SIDE = -1,
        BOUNDARY = 0,
        BOUNDED_SIDE = 1
    }

    public enum COMPARISON
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

    public enum CLOCK
    {
        CW = -1,
        ZERO = 0,
        CCW = 1
    }

    public enum ORIENTATION
    {
        NEGATIVE = -1,
        ZERO = 0,
        POSITIVE = 1
    }

    public enum ORIENTED_SIDE
    {
        NEGATIVE_SIDE = -1,
        BOUNDARY = 0,
        POSITIVE_SIDE = 1,
        UNDETERMINED = 2
    }
}
