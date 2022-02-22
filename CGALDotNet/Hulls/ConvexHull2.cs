using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
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
        JARVIS
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
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[ConvexHull2<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Find the convex of the points.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The ararys length.</param>
        /// <param name="method">The hull ethod to use.</param>
        /// <returns>A polygon that represents the convex hull.</returns>
        public Polygon2<K> CreateHull(Point2d[] points, int count, HULL_METHOD method = HULL_METHOD.DEFAULT)
        {
            CheckCount(count);
            ErrorUtil.CheckArray(points, count);
            var ptr = Kernel.CreateHull(points, count, method);
            return new Polygon2<K>(ptr);
        }

        /// <summary>
        /// Find the upper hull of points.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The ararys length.</param>
        /// <returns>A polygon that represents the upper hull.</returns>
        public Polygon2<K> UpperHull(Point2d[] points, int count)
        {
            CheckCount(count);
            ErrorUtil.CheckArray(points, count);
            var ptr = Kernel.UpperHull(points, count);
            return new Polygon2<K>(ptr);
        }

        /// <summary>
        /// Find the lower hull of points.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The ararys length.</param>
        /// <returns>A polygon that represents the lower hull.</returns>
        public Polygon2<K> LowerHull(Point2d[] points, int count)
        {
            CheckCount(count);
            ErrorUtil.CheckArray(points, count);
            var ptr = Kernel.LowerHull(points, count);
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
        /// <param name="count">The ararys length.</param>
        /// <returns>Is this set of points ccw orderer.</returns>
        public bool IsStronglyConvexCCW(Point2d[] points, int count)
        {
            CheckCount(count);
            ErrorUtil.CheckArray(points, count);
            return Kernel.IsStronglyConvexCCW(points, count);
        }

        /// <summary>
        /// Is this set of points cw orderer.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The ararys length.</param>
        /// <returns>Is this set of points cw orderer.</returns>
        public bool IsStronglyConvexCW(Point2d[] points, int count)
        {
            CheckCount(count);
            ErrorUtil.CheckArray(points, count);
            return Kernel.IsStronglyConvexCW(points, count);
        }

        /// <summary>
        /// Checks if the minimum number of points have been provided.
        /// </summary>
        /// <param name="count">The point array length.</param>
        /// <exception cref="ArgumentException"></exception>
        protected void CheckCount(int count)
        {
            if (count < 3)
                throw new ArgumentException("3 or more points must be provided to find the convex hull.");
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
