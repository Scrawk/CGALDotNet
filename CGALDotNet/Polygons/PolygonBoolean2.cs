using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{

    public enum CGAL_POLYGON_BOOLEAN { JOIN };

    public static partial class PolygonBoolean2
    {

        public static bool DoIntersect(Polygon2_EEK polygon1, Polygon2_EEK polygon2)
        {
            return PolygonBoolean2_EEK_DoIntersect_P_P(polygon1.Ptr, polygon2.Ptr);
        }

        public static bool DoIntersect(Polygon2_EEK polygon1, PolygonWithHoles2_EEK polygon2)
        {
            return PolygonBoolean2_EEK_DoIntersect_P_PWH(polygon1.Ptr, polygon2.Ptr);
        }

        public static bool DoIntersect(PolygonWithHoles2_EEK polygon1, PolygonWithHoles2_EEK polygon2)
        {
            return PolygonBoolean2_EEK_DoIntersect_PWH_PWH(polygon1.Ptr, polygon2.Ptr);
        }

        public static bool Join(Polygon2_EEK polygon1, Polygon2_EEK polygon2, out PolygonWithHoles2_EEK result)
        {
            if(PolygonBoolean2_EEK_Join_P_P(polygon1.Ptr, polygon2.Ptr, out IntPtr resultPtr))
            {
                result = new PolygonWithHoles2_EEK(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public static bool Join(Polygon2_EEK polygon1, PolygonWithHoles2_EEK polygon2, out PolygonWithHoles2_EEK result)
        {
            if (PolygonBoolean2_EEK_Join_P_PWH(polygon1.Ptr, polygon2.Ptr, out IntPtr resultPtr))
            {
                result = new PolygonWithHoles2_EEK(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        public static bool Join(PolygonWithHoles2_EEK polygon1, PolygonWithHoles2_EEK polygon2, out PolygonWithHoles2_EEK result)
        {
            if (PolygonBoolean2_EEK_Join_PWH_PWH(polygon1.Ptr, polygon2.Ptr, out IntPtr resultPtr))
            {
                result = new PolygonWithHoles2_EEK(resultPtr);
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
