using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Hulls
{
    public sealed class ConvexHull2<K> : ConvexHull2 where K : CGALKernel, new()
    {

        public static readonly ConvexHull2<K> Instance = new ConvexHull2<K>();

        public ConvexHull2() : base(new K())
        {

        }

        public  Polygon2<K> CreateHull(Point2d[] points, int startIndex, int count)
        {
            var ptr = Kernel.CreateHull(points, startIndex, count);
            return new Polygon2<K>(ptr);
        }

        public Polygon2<K> UpperHull(Point2d[] points, int startIndex, int count)
        {
            var ptr = Kernel.UpperHull(points, startIndex, count);
            return new Polygon2<K>(ptr);
        }

        public Polygon2<K> LowerHull(Point2d[] points, int startIndex, int count)
        {
            var ptr = Kernel.LowerHull(points, startIndex, count);
            return new Polygon2<K>(ptr);
        }
    }

    public abstract class ConvexHull2 : CGALObject
    {
        private ConvexHull2()
        {

        }

        internal ConvexHull2(CGALKernel kernel)
        {
            Kernel = kernel.ConvexHullKernel2;
            Ptr = Kernel.Create();
        }

        protected private ConvexHullKernel2 Kernel { get; private set; }

        public bool IsStronglyConvexCCW(Point2d[] points, int startIndex, int count)
        {
            return Kernel.IsStronglyConvexCCW(points, startIndex, count);
        }

        public bool IsStronglyConvexCW(Point2d[] points, int startIndex, int count)
        {
            return Kernel.IsStronglyConvexCW(points, startIndex, count);
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
