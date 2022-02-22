using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{

    /// <summary>
    /// Decomposition stratergy for polygons.
    /// </summary>
    public enum MINKOWSKI_DECOMPOSITION
    {
        SMALL_SIDE_ANGLE_BISECTOR,
        OPTIMAL_CONVEX,
        HERTEL_MEHLHORN_CONVEX,
        GREENE_CONVEX,
        VERTICAL,
        TRIANGULATION
    }

    /// <summary>
    /// Decomposition stratergy for polygons with holes.
    /// </summary>
    public enum MINKOWSKI_DECOMPOSITION_PWH
    {
        VERTICAL,
        TRIANGULATION
    }

    /// <summary>
    /// Generic Minkowski class.
    /// </summary>
    /// <typeparam name="K">The type of kernel</typeparam>
    public class PolygonMinkowski<K> : PolygonMinkowski where K : CGALKernel, new()
    {
        /// <summary>
        /// A static instance to the Minkowski class.
        /// </summary>
        public static readonly PolygonMinkowski<K> Instance = new PolygonMinkowski<K>();

        /// <summary>
        /// Create a new object.
        /// </summary>
        public PolygonMinkowski() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMinkowski<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Compute the Minkowski sum of two polygons.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> Sum(Polygon2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSum(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Compute the Minkowski sum of two polygons.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> Sum(PolygonWithHoles2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSumPWH(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Compute the Minkowski sum of two polygons.
        /// </summary>
        /// <param name="decomp">The decomposition method.</param>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> Sum(MINKOWSKI_DECOMPOSITION decomp, Polygon2<K> polygon, Polygon2<K> shape)
        {
            switch (decomp)
            {
                case MINKOWSKI_DECOMPOSITION.SMALL_SIDE_ANGLE_BISECTOR:
                    return SumSSAB(polygon, shape);

                case MINKOWSKI_DECOMPOSITION.OPTIMAL_CONVEX:
                    return SumOptimalConvex(polygon, shape);

                case MINKOWSKI_DECOMPOSITION.HERTEL_MEHLHORN_CONVEX:
                    return SumHertelMehlhorn(polygon, shape);

                case MINKOWSKI_DECOMPOSITION.GREENE_CONVEX:
                    return SumGreeneConvex(polygon, shape);

                case MINKOWSKI_DECOMPOSITION.VERTICAL:
                    return SumVertical(polygon, shape);

                case MINKOWSKI_DECOMPOSITION.TRIANGULATION:
                    return SumTriangle(polygon, shape);

                default:
                    return Sum(polygon, shape);
            }
        }

        /// <summary>
        /// Compute the Minkowski sum of two polygons.
        /// </summary>
        /// <param name="decomp">The decomposition method.</param>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> Sum(MINKOWSKI_DECOMPOSITION_PWH decomp, PolygonWithHoles2<K> polygon, Polygon2<K> shape)
        {
            switch (decomp)
            {
                case MINKOWSKI_DECOMPOSITION_PWH.VERTICAL:
                    return SumVertical(polygon, shape);

                case MINKOWSKI_DECOMPOSITION_PWH.TRIANGULATION:
                    return SumTriangle(polygon, shape);

                default:
                    return Sum(polygon, shape);
            }
        }

        /// <summary>
        /// It is based on the angle-bisector decomposition method suggested by Chazelle and Dobkin [4],
        /// which runs in O(n2) time. In addition, it applies a heuristic by Flato that reduces the number
        /// of output polygons in many common cases. The convex decompositions that it produces usually 
        /// yield efficient running times for Minkowski sum computations. It starts by examining each pair 
        /// of reflex vertices in the input polygon, such that the entire interior of the diagonal 
        /// connecting these vertices is contained in the polygon. Out of all available pairs, the vertices
        /// pi and pj are selected, such that the number of reflex vertices encountered when traversing 
        /// the boundary of the polygon from pi to pj in clockwise order is minimal. The polygon is split 
        /// by the diagonal pipj. This process is repeated recursively on both resulting sub-polygons. 
        /// In case it is not possible to eliminate two reflex vertices at once any more, each reflex 
        /// vertex is eliminated by a diagonal that is closest to the angle bisector emanating from this 
        /// vertex and having rational-coordinate endpoints on both sides.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> SumSSAB(Polygon2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSum_SSAB(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Uses the dynamic-programming algorithm of Greene [6] for computing an optimal decomposition of 
        /// a polygon into a minimal number of convex sub-polygons. While this algorithm results in a small
        /// number of convex polygons, it consumes rather many resources, as it runs in O(n4) time and O(n3) 
        /// space in the worst case, where n is the number of vertices in the input polygon.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> SumOptimalConvex(Polygon2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSum_OptimalConvex(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        ///  Implements the approximation algorithm suggested by Hertel and Mehlhorn [8], which triangulates 
        ///  the input polygon and then discards unnecessary triangulation edges. After triangulation (carried 
        ///  out by the constrained-triangulation procedure of CGAL) the algorithm runs in O(n) time and space,
        ///  and guarantees that the number of sub-polygons it generates is not more than four times the optimum.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> SumHertelMehlhorn(Polygon2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSum_HertelMehlhorn(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Implementation of Greene's approximation algorithm [6], which computes a convex decomposition of the 
        /// polygon based on its partitioning into y-monotone polygons. This algorithm runs in O(nlogn) time and 
        /// O(n) space, and has the same guarantee on the quality of approximation as Hertel and Mehlhorn's algorithm.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> SumGreeneConvex(Polygon2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSum_GreeneConvex(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Uses vertical decomposition to decompose the underlying arrangement.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> SumVertical(Polygon2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSum_Vertical(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Uses vertical decomposition to decompose the underlying arrangement.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> SumVertical(PolygonWithHoles2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSumPWH_Vertical(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Uses constrained triangulation to decompose the input polygons, which may have holes, into triangles.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> SumTriangle(Polygon2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSum_Triangle(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Uses constrained triangulation to decompose the input polygons, which may have holes, into triangles.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="shape"></param>
        /// <returns></returns>
        public PolygonWithHoles2<K> SumTriangle(PolygonWithHoles2<K> polygon, Polygon2<K> shape)
        {
            CheckPolygon(polygon);
            CheckPolygon(shape);
            var ptr = Kernel.MinkowskiSumPWH_Triangle(polygon.Ptr, shape.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

    }

    /// <summary>
    /// Abstract base class for polygon minkowski.
    /// </summary>
    public abstract class PolygonMinkowski : PolygonAlgorithm
    {
        private PolygonMinkowski()
        {

        }

        internal PolygonMinkowski(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMinkowskiKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The polygon Minkowski kernel.
        /// </summary>
        protected private PolygonMinkowskiKernel Kernel { get; private set; }

        /// <summary>
        /// Release the unmanaged resourses.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
