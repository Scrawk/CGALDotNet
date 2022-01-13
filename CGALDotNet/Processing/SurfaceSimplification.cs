using System;
using System.Collections.Generic;

using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{

    public sealed class SurfaceSimplification<K> : SurfaceSimplification where K : CGALKernel, new()
    {
        public static readonly SurfaceSimplification<K> Instance = new SurfaceSimplification<K>();

        public SurfaceSimplification() : base(new K())
        {

        }

    }

    public abstract class SurfaceSimplification : CGALObject
    {
        private SurfaceSimplification()
        {

        }

        internal SurfaceSimplification(CGALKernel kernel)
        {
            Kernel = kernel.SurfaceSimplificationKernel;
            Ptr = Kernel.Create();
        }

        protected private SurfaceSimplificationKernel Kernel { get; private set; }

        public void Simplify(Polyhedron3 poly, double stop_ratio)
        {
            stop_ratio = CGALGlobal.Clamp01(stop_ratio);
            if (stop_ratio == 0) return;
            if (!poly.IsPureTriangle) return;

            Kernel.SimplifyPolyhedron(poly.Ptr, stop_ratio);
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
