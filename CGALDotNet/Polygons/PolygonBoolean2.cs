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

    public class PolygonBoolean2<K> : PolygonBoolean2 where K : CGALKernel, new()
    {

        public static readonly PolygonBoolean2<K> Instance = new PolygonBoolean2<K>();

        public PolygonBoolean2() : base(new K())
        {

        }

        public bool IsValid(Polygon2<K> polygon)
        {
            return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        public bool DoIntersect(Polygon2<K> polygon1, Polygon2<K> polygon2) 
        {
            CheckPolygons(polygon1, polygon2);
            return Kernel.DoIntersect(Ptr, polygon1, polygon2);
        }

        public bool DoIntersect(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2)
        {
            CheckPolygon(polygon1);
            return Kernel.DoIntersect(Ptr, polygon1, polygon2);
        }

        public bool DoIntersect(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2)
        {
            return Kernel.DoIntersect(Ptr, polygon1, polygon2);
        }

        public bool Join(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygons(polygon1, polygon2);

            if (Kernel.Join(Ptr, polygon1, polygon2, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2<K>(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Join(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);

            if (Kernel.Join(Ptr, polygon1, polygon2, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2<K>(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Join(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            if (Kernel.Join(Ptr, polygon1, polygon2, out IntPtr resultPtr))
            {
                result.Add(new PolygonWithHoles2<K>(resultPtr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Intersect(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygons(polygon1, polygon2);
            int count = Kernel.Intersect(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void Intersect(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            int count = Kernel.Intersect(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void Intersect(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            int count = Kernel.Intersect(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void Difference(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygons(polygon1, polygon2);
            int count = Kernel.Difference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void Difference(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            int count = Kernel.Difference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void Difference(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            int count = Kernel.Difference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void SymmetricDifference(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygons(polygon1, polygon2);
            int count = Kernel.SymmetricDifference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void SymmetricDifference(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            int count = Kernel.SymmetricDifference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void SymmetricDifference(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            int count = Kernel.SymmetricDifference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
        }

        public void Complement(PolygonWithHoles2<K> polygon, List<PolygonWithHoles2<K>> result)
        {
            int count = Kernel.Complement(Ptr, polygon);
            CopyBuffer(count, result);
        }

        private void CopyBuffer(int count, List<PolygonWithHoles2<K>> result)
        {
            for (int i = 0; i < count; i++)
                result.Add(CopyBufferItem(i));

            ClearBuffer();
        }

        private PolygonWithHoles2<K> CopyBufferItem(int index)
        {
            var ptr = Kernel.CopyBufferItem(Ptr, index);
            return new PolygonWithHoles2<K>(ptr);
        }

        private void CheckPolygon(Polygon2<K> polygon)
        {
            if (!IsValid(polygon))
                throw new Exception("Poylgon must be simple and counter clock wise for boolean op.");
        }

        private void CheckPolygons(Polygon2<K> polygon1, Polygon2<K> polygon2)
        {
            if (!IsValid(polygon1))
                throw new Exception("Poylgon must be simple for counter clock wise boolean op.");

            if (!IsValid(polygon2))
                throw new Exception("Poylgon must be simple for counter clock wise boolean op.");
        }

    }

    public abstract class PolygonBoolean2 : CGALObject
    {
        private PolygonBoolean2()
        {

        }

        internal PolygonBoolean2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonBooleanKernel2;
            Ptr = Kernel.Create();
        }

        protected private PolygonBooleanKernel2 Kernel { get; private set; }

        protected void ClearBuffer()
        {
            Kernel.ClearBuffer(Ptr);
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
