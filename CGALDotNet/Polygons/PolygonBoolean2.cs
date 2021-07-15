using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{

    public enum CGAL_POLYGON_BOOLEAN 
    { 
        JOIN, 
        INTERSECT, 
        DIFFERENCE, 
        SYMMETRIC_DIFFERENCE 
    };

    public static partial class PolygonBoolean2<K> where K : CGALKernel, new()
    {

        private static readonly K Kernel = new K();

        public static bool IsValid(Polygon2<K> polygon)
        {
            return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        public static bool DoIntersect(Polygon2<K> polygon1, Polygon2<K> polygon2) 
        {
            CheckPolygons(polygon1, polygon2);
            return Kernel.PolygonBooleanKernel2.DoIntersect(polygon1, polygon2);
        }

        public static bool DoIntersect(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2)
        {
            CheckPolygon(polygon1);
            return Kernel.PolygonBooleanKernel2.DoIntersect(polygon1, polygon2);
        }

        public static bool DoIntersect(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2)
        {
            return Kernel.PolygonBooleanKernel2.DoIntersect(polygon1, polygon2);
        }

        public static bool Join(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygons(polygon1, polygon2);

            if (Kernel.PolygonBooleanKernel2.Join(polygon1, polygon2, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2<K>(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Join(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);

            if (Kernel.PolygonBooleanKernel2.Join(polygon1, polygon2, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2<K>(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Join(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            if (Kernel.PolygonBooleanKernel2.Join(polygon1, polygon2, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2<K>(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Intersect(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygons(polygon1, polygon2);
            int count = Kernel.PolygonBooleanKernel2.Intersect(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void Intersect(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            int count = Kernel.PolygonBooleanKernel2.Intersect(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void Intersect(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            int count = Kernel.PolygonBooleanKernel2.Intersect(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void Difference(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygons(polygon1, polygon2);
            int count = Kernel.PolygonBooleanKernel2.Difference(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void Difference(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            int count = Kernel.PolygonBooleanKernel2.Difference(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void Difference(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            int count = Kernel.PolygonBooleanKernel2.Difference(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void SymmetricDifference(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygons(polygon1, polygon2);
            int count = Kernel.PolygonBooleanKernel2.SymmetricDifference(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void SymmetricDifference(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            int count = Kernel.PolygonBooleanKernel2.SymmetricDifference(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void SymmetricDifference(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            int count = Kernel.PolygonBooleanKernel2.SymmetricDifference(polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public static void Complement(PolygonWithHoles2<K> polygon, List<PolygonWithHoles2<K>> result)
        {
            int count = Kernel.PolygonBooleanKernel2.Complement(polygon);
            CopyBuffer(count, result);
        }

        private static void CopyBuffer(int count, List<PolygonWithHoles2<K>> result)
        {
            for (int i = 0; i < count; i++)
                result.Add(CopyBufferItem(i));

            ClearBuffer();
        }

        private static PolygonWithHoles2<K> CopyBufferItem(int index)
        {
            var ptr = Kernel.PolygonBooleanKernel2.CopyBufferItem(index);
            return new PolygonWithHoles2<K>(ptr);
        }

        private static void ClearBuffer()
        {
            Kernel.PolygonBooleanKernel2.ClearBuffer();
        }

        private static void CheckPolygon(Polygon2<K> polygon)
        {
            if (!IsValid(polygon))
                throw new Exception("Poylgon must be simple and counter clock wise for boolean op.");
        }

        private static void CheckPolygons(Polygon2<K> polygon1, Polygon2<K> polygon2)
        {
            if (!IsValid(polygon1))
                throw new Exception("Poylgon must be simple for counter clock wise boolean op.");

            if (!IsValid(polygon2))
                throw new Exception("Poylgon must be simple for counter clock wise boolean op.");
        }

    }
}
