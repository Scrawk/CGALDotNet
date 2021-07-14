using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{

    public enum CGAL_POLYGON_BOOLEAN { JOIN };

    public static partial class PolygonBoolean2
    {

        public static bool IsValid(Polygon2 polygon)
        {
            return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        public static bool DoIntersect(Polygon2_EEK polygon1, Polygon2_EEK polygon2)
        {
            CheckPolygons(polygon1, polygon2);
            return PolygonBoolean2_EEK_DoIntersect_P_P(polygon1.Ptr, polygon2.Ptr);
        }

        public static bool DoIntersect(Polygon2_EEK polygon1, PolygonWithHoles2_EEK polygon2)
        {
            CheckPolygon(polygon1);
            return PolygonBoolean2_EEK_DoIntersect_P_PWH(polygon1.Ptr, polygon2.Ptr);
        }

        public static bool DoIntersect(PolygonWithHoles2_EEK polygon1, PolygonWithHoles2_EEK polygon2)
        {
            return PolygonBoolean2_EEK_DoIntersect_PWH_PWH(polygon1.Ptr, polygon2.Ptr);
        }

        public static bool Join(Polygon2_EEK polygon1, Polygon2_EEK polygon2, List<PolygonWithHoles2_EEK> result)
        {
            CheckPolygons(polygon1, polygon2);

            if (PolygonBoolean2_EEK_Join_P_P(polygon1.Ptr, polygon2.Ptr, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2_EEK(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Join(Polygon2_EEK polygon1, PolygonWithHoles2_EEK polygon2, List<PolygonWithHoles2_EEK> result)
        {
            CheckPolygon(polygon1);

            if (PolygonBoolean2_EEK_Join_P_PWH(polygon1.Ptr, polygon2.Ptr, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2_EEK(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Join(PolygonWithHoles2_EEK polygon1, PolygonWithHoles2_EEK polygon2, List<PolygonWithHoles2_EEK> result)
        {
            if (PolygonBoolean2_EEK_Join_PWH_PWH(polygon1.Ptr, polygon2.Ptr, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2_EEK(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Intersect(Polygon2_EEK polygon1, Polygon2_EEK polygon2, List<PolygonWithHoles2_EEK> result)
        {
            CheckPolygons(polygon1, polygon2);
            int count = PolygonBoolean2_EEK_Intersect_P_P(polygon1.Ptr, polygon2.Ptr);
            CopyBuffer(count, result);
        }

        public static void Intersect(Polygon2_EEK polygon1, PolygonWithHoles2_EEK polygon2, List<PolygonWithHoles2_EEK> result)
        {
            CheckPolygon(polygon1);
            int count = PolygonBoolean2_EEK_Intersect_P_PWH(polygon1.Ptr, polygon2.Ptr);
            CopyBuffer(count, result);
        }

        public static void Intersect(PolygonWithHoles2_EEK polygon1, PolygonWithHoles2_EEK polygon2, List<PolygonWithHoles2_EEK> result)
        {
            int count = PolygonBoolean2_EEK_Intersect_PWH_PWH(polygon1.Ptr, polygon2.Ptr);
            CopyBuffer(count, result);
        }

        private static void CopyBuffer(int count, List<PolygonWithHoles2_EEK> result)
        {
            for (int i = 0; i < count; i++)
                result.Add(CopyBufferItem(i));

            ClearBuffer();
        }

        private static PolygonWithHoles2_EEK CopyBufferItem(int index)
        {
            var ptr = PolygonBoolean2_EEK_CopyBufferItem(index);
            return new PolygonWithHoles2_EEK(ptr);
        }

        private static void ClearBuffer()
        {
            PolygonBoolean2_EEK_ClearBuffer();
        }

        private static void CheckPolygon(Polygon2 polygon)
        {
            if (!IsValid(polygon))
                throw new Exception("Poylgon must be simple and counter clock wise for boolean op.");
        }

        private static void CheckPolygons(Polygon2 polygon1, Polygon2 polygon2)
        {
            if (!IsValid(polygon1))
                throw new Exception("Poylgon must be simple for counter clock wise boolean op.");

            if (!IsValid(polygon2))
                throw new Exception("Poylgon must be simple for counter clock wise boolean op.");
        }

    }
}
