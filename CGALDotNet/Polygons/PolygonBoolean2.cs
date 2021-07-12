using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{
    public static partial class PolygonBoolean2
    {

        public static bool DoIntersect(Polygon2_EEK polygon1, Polygon2_EEK polygon2)
        {
            return PolygonBoolean2_EEK_DoIntersect(polygon1.Ptr, polygon2.Ptr);
        }

    }
}
