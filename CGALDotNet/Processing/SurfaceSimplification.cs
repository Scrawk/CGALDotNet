using System;
using System.Collections.Generic;

using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class SurfaceSimplification<K> : SurfaceSimplification where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly SurfaceSimplification<K> Instance = new SurfaceSimplification<K>();

        /// <summary>
        /// 
        /// </summary>
        public SurfaceSimplification() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[SurfaceSimplification<{0}>: ]", Kernel.KernelName);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class SurfaceSimplification : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private SurfaceSimplification()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal SurfaceSimplification(CGALKernel kernel)
        {
            Kernel = kernel.SurfaceSimplificationKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        protected private SurfaceSimplificationKernel Kernel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="stop_ratio"></param>
        public void Simplify(Polyhedron3 poly, double stop_ratio)
        {
            stop_ratio = CGALGlobal.Clamp01(stop_ratio);
            if (stop_ratio == 0) return;
            
            CheckIsValidAndTriangle(poly);
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
