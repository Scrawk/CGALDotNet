using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Hulls
{
    /// <summary>
    /// The convex hull method to use.
    /// </summary>
    public enum HULL_METHOD
    {
        DEFAULT,
        AKL_TOUSSAINT,
        BYKAT,
        EDDY,
        GRAHAM_ANDREW,
        JARVIS,
        MELKMAN
    };

    /// <summary>
    /// The generic convex hull class.
    /// </summary>
    /// <typeparam name="K">The kernel type</typeparam>
    public sealed class ConvexHull2<K> : ConvexHull2 where K : CGALKernel, new()
    {
        /// <summary>
        /// The static instance.
        /// </summary>
        public static readonly ConvexHull2<K> Instance = new ConvexHull2<K>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ConvexHull2() : base(new K())
        {

        }

        /// <summary>
        /// Find the convex of the points.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="method">The hull ethod to use.</param>
        /// <returns>A polygon that represents the convex hull.</returns>
        public  Polygon2<K> CreateHull(Point2d[] points, HULL_METHOD method = HULL_METHOD.DEFAULT)
        {
            var ptr = Kernel.CreateHull(points, 0, points.Length, method);
            return new Polygon2<K>(ptr);
        }

        /// <summary>
        /// Find the upper hull of points.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <returns>A polygon that represents the upper hull.</returns>
        public Polygon2<K> UpperHull(Point2d[] points)
        {
            var ptr = Kernel.UpperHull(points, 0, points.Length);
            return new Polygon2<K>(ptr);
        }

        /// <summary>
        /// Find the lower hull of points.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <returns>A polygon that represents the lower hull.</returns>
        public Polygon2<K> LowerHull(Point2d[] points)
        {
            var ptr = Kernel.LowerHull(points, 0, points.Length);
            return new Polygon2<K>(ptr);
        }
    }

    /// <summary>
    /// The convex hull abstract base class.
    /// </summary>
    public abstract class ConvexHull2 : CGALObject
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        private ConvexHull2()
        {

        }

        /// <summary>
        /// Construct hull with the kernel.
        /// </summary>
        /// <param name="kernel">The kernel</param>
        internal ConvexHull2(CGALKernel kernel)
        {
            Kernel = kernel.ConvexHullKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The hulls kernel type.
        /// </summary>
        protected private ConvexHullKernel2 Kernel { get; private set; }

        /// <summary>
        /// Is this set of points ccw orderer.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <returns>Is this set of points ccw orderer.</returns>
        public bool IsStronglyConvexCCW(Point2d[] points)
        {
            return Kernel.IsStronglyConvexCCW(points, 0, points.Length);
        }

        /// <summary>
        /// Is this set of points cw orderer.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <returns>Is this set of points cw orderer.</returns>
        public bool IsStronglyConvexCW(Point2d[] points)
        {
            return Kernel.IsStronglyConvexCW(points, 0, points.Length);
        }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
