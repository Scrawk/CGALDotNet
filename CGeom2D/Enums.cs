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

}
