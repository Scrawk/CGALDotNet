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

        public static bool Join(Polygon2_EEK polygon1, Polygon2_EEK polygon2, out PolygonWithHoles2 result)
        {
            if(PolygonBoolean2_EEK_Join(polygon1.Ptr, polygon2.Ptr, out IntPtr resultPtr))
            {
                result = new PolygonWithHoles2(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

    }
}
