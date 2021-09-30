using System;
using System.Collections.Generic;

namespace CGALDotNet.Polygons
{

    public enum MINKOWSKI_DECOMPOSITION
    {
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
        SMALL_SIDE_ANGLE_BISECTOR,

        /// <summary>
        /// uses the dynamic-programming algorithm of Greene [6] for computing an optimal decomposition of 
        /// a polygon into a minimal number of convex sub-polygons. While this algorithm results in a small
        /// number of convex polygons, it consumes rather many resources, as it runs in O(n4) time and O(n3) 
        /// space in the worst case, where n is the number of vertices in the input polygon.
        /// </summary>
        OPTIMAL_CONVEX,

        /// <summary>
        ///  implements the approximation algorithm suggested by Hertel and Mehlhorn [8], which triangulates 
        ///  the input polygon and then discards unnecessary triangulation edges. After triangulation (carried 
        ///  out by the constrained-triangulation procedure of CGAL) the algorithm runs in O(n) time and space,
        ///  and guarantees that the number of sub-polygons it generates is not more than four times the optimum.
        /// </summary>
        HERTEL_MEHLHORN_CONVEX,

        /// <summary>
        /// implementation of Greene's approximation algorithm [6], which computes a convex decomposition of the 
        /// polygon based on its partitioning into y-monotone polygons. This algorithm runs in O(nlogn) time and 
        /// O(n) space, and has the same guarantee on the quality of approximation as Hertel and Mehlhorn's algorithm.
        /// </summary>
        GREENE_CONVEX,

        /// <summary>
        /// uses vertical decomposition to decompose the underlying arrangement.
        /// </summary>
        POLYGONAL_VERTICAL,

        /// <summary>
        /// uses constrained triangulation to decompose the input polygons, which may have holes, into triangles.
        /// </summary>
        POLYGONAL_TRIANGULATION
    }

    public enum MINKOWSKI_OFFSET
    {
        OFFSET,
        INSET
    }

    public enum MINKOWSKI_APPROX
    {
        APPROX,
        EXACT
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

        public PolygonWithHoles2<K> Sum(Polygon2<K> polygon1, Polygon2<K> polygon2)
        {
            CheckPolygons(polygon1, polygon2);
            var ptr = Kernel.MinkowskiSum(polygon1.Ptr, polygon2.Ptr);
            return new PolygonWithHoles2<K>(ptr);
        }

        public PolygonWithHoles2<K> Sum(Polygon2<K> polygon1, Polygon2<K> polygon2, MINKOWSKI_DECOMPOSITION decom)
        {
            CheckPolygons(polygon1, polygon2);
            var ptr = Kernel.MinkowskiSum(polygon1.Ptr, polygon2.Ptr, decom);
            return new PolygonWithHoles2<K>(ptr);
        }

        /// <summary>
        /// Is this a valid polygon.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        /// <returns>If the polygon is simple and ccw.</returns>
        public bool IsValid(Polygon2<K> polygon)
        {
            if (!CheckInput)
                return true;
            else
                return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        private void CheckPolygon(Polygon2<K> polygon)
        {
            if (!CheckInput) return;

            if (!IsValid(polygon))
                throw new Exception("Poylgon must be simple and counter clock wise.");
        }

        private void CheckPolygons(Polygon2<K> polygon1, Polygon2<K> polygon2)
        {
            if (!CheckInput) return;

            if (!IsValid(polygon1))
                throw new Exception("Poylgon must be simple and counter clock wise.");

            if (!IsValid(polygon2))
                throw new Exception("Poylgon must be simple and counter clock wise.");
        }

    }

    /// <summary>
    /// Abstract base class for polygon boolean.
    /// </summary>
    public abstract class PolygonMinkowski : CGALObject
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
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

        /// <summary>
        /// The polygon boolean kernel.
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
