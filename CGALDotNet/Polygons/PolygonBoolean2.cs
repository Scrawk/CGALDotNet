using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{
    /// <summary>
    /// The type of boolean ops.
    /// </summary>
    public enum POLYGON_BOOLEAN 
    { 
        JOIN, 
        INTERSECT, 
        DIFFERENCE, 
        SYMMETRIC_DIFFERENCE
    };

    /// <summary>
    /// Generic polygon boolean class.
    /// </summary>
    /// <typeparam name="K">The type of kernel</typeparam>
    public sealed class PolygonBoolean2<K> : PolygonBoolean2 where K : CGALKernel, new()
    {
        /// <summary>
        /// A static instance to the boolean class.
        /// </summary>
        public static readonly PolygonBoolean2<K> Instance = new PolygonBoolean2<K>();

        /// <summary>
        /// Create a new object.
        /// </summary>
        public PolygonBoolean2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonBoolean2<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Perform the boolean op on the two polygons.
        /// </summary>
        /// <param name="op">The type of op.</param>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The result of the op.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Op(POLYGON_BOOLEAN op, Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            switch (op)
            {
                case POLYGON_BOOLEAN.JOIN:
                    return Join(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.INTERSECT:
                    return Intersect(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.DIFFERENCE:
                    return Difference(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.SYMMETRIC_DIFFERENCE:
                    return SymmetricDifference(polygon1, polygon2, result);
            }

            return false;
        }

        /// <summary>
        /// Perform the boolean op on the two polygons.
        /// </summary>
        /// <param name="op">The type of op.</param>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The result of the op.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Op(POLYGON_BOOLEAN op, Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            switch (op)
            {
                case POLYGON_BOOLEAN.JOIN:
                    return Join(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.INTERSECT:
                    return Intersect(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.DIFFERENCE:
                    return Difference(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.SYMMETRIC_DIFFERENCE:
                    return SymmetricDifference(polygon1, polygon2, result);
            }

            return false;
        }

        /// <summary>
        /// Perform the boolean op on the two polygons.
        /// </summary>
        /// <param name="op">The type of op.</param>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The result of the op.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Op(POLYGON_BOOLEAN op, PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            switch (op)
            {
                case POLYGON_BOOLEAN.JOIN:
                    return Join(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.INTERSECT:
                    return Intersect(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.DIFFERENCE:
                    return Difference(polygon1, polygon2, result);

                case POLYGON_BOOLEAN.SYMMETRIC_DIFFERENCE:
                    return SymmetricDifference(polygon1, polygon2, result);
            }

            return false;
        }

        /// <summary>
        /// Check if the polygons intesect.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <returns>If the polygons intesect.</returns>
        public bool DoIntersect(Polygon2<K> polygon1, Polygon2<K> polygon2) 
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);
            return Kernel.DoIntersect(Ptr, polygon1, polygon2);
        }

        /// <summary>
        /// Check if the polygons intesect.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <returns>If the polygons intesect.</returns>
        public bool DoIntersect(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);
            return Kernel.DoIntersect(Ptr, polygon1, polygon2);
        }

        /// <summary>
        /// Check if the polygons intesect.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <returns>If the polygons intesect.</returns>
        public bool DoIntersect(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);
            return Kernel.DoIntersect(Ptr, polygon1, polygon2);
        }

        /// <summary>
        /// The union of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The union of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Join(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

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

        /// <summary>
        /// The union of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The union of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Join(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

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

        /// <summary>
        /// The union of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The union of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Join(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

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

        /// <summary>
        /// The intersection of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The intersection of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Intersect(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.Intersect(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The intersection of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The intersection of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Intersect(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.Intersect(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The intersection of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The intersection of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Intersect(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.Intersect(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The difference of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The difference of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Difference(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.Difference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The difference of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The difference of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Difference(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.Difference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The difference of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The difference of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool Difference(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.Difference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The symmetric difference of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The symmetric difference of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool SymmetricDifference(Polygon2<K> polygon1, Polygon2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.SymmetricDifference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The symmetric difference of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The symmetric difference of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool SymmetricDifference(Polygon2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.SymmetricDifference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The symmetric difference of the two polygons.
        /// </summary>
        /// <param name="polygon1">A simple ccw polygon.</param>
        /// <param name="polygon2">A simple ccw polygon.</param>
        /// <param name="result">The symmetric difference of the polygons.</param>
        /// <returns>If the op was performed and the result list changed.</returns>
        public bool SymmetricDifference(PolygonWithHoles2<K> polygon1, PolygonWithHoles2<K> polygon2, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon1);
            CheckPolygon(polygon2);

            int count = Kernel.SymmetricDifference(Ptr, polygon1, polygon2);
            CopyBuffer(count, result);
            return count != 0;
        }

        /// <summary>
        /// The complement of the polygon.
        /// </summary>
        /// <param name="polygon">A simple ccw polygon.</param>
        /// <param name="result">The complement of the polygon.</param>
        public void Complement(PolygonWithHoles2<K> polygon, List<PolygonWithHoles2<K>> result)
        {
            CheckPolygon(polygon);

            int count = Kernel.Complement(Ptr, polygon);
            CopyBuffer(count, result);
        }

        /// <summary>
        /// Copy the unmanaged polygon objects created 
        /// into the result list.
        /// </summary>
        /// <param name="count">The number of objects in the buffer.</param>
        /// <param name="result">The result lis.</param>
        private void CopyBuffer(int count, List<PolygonWithHoles2<K>> result)
        {
            for (int i = 0; i < count; i++)
                result.Add(CopyBufferItem(i));

            ClearBuffer();
        }

        /// <summary>
        /// Copy the unmanaged polygon object.
        /// </summary>
        /// <param name="index">The index of the polygon in the buffer.</param>
        /// <returns>The polygon copy.</returns>
        private PolygonWithHoles2<K> CopyBufferItem(int index)
        {
            var ptr = Kernel.CopyBufferItem(Ptr, index);
            return new PolygonWithHoles2<K>(ptr);
        }

    }

    /// <summary>
    /// Abstract base class for polygon boolean.
    /// </summary>
    public abstract class PolygonBoolean2 : PolygonAlgorithm
    {
        private PolygonBoolean2()
        {

        }

        internal PolygonBoolean2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonBooleanKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The polygon boolean kernel.
        /// </summary>
        protected private PolygonBooleanKernel2 Kernel { get; private set; }

        /// <summary>
        /// Clear the unmanaged buffer.
        /// </summary>
        protected void ClearBuffer()
        {
            Kernel.ClearBuffer(Ptr);
        }

        /// <summary>
        /// Release the unmanaged resourses.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
