using System;
using System.Collections.Generic;

using CGALDotNet.Polyhedra;
using CGALDotNetGeometry.Numerics;

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
            return string.Format("[SurfaceSimplification<{0}>: ]", Kernel.Name);
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
        /// Simplify the mesh.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="stop_ratio">A percentage 0-1 of edges to remove.</param>
        public void Simplify(Polyhedron3 mesh, double stop_ratio)
        {
            stop_ratio = MathUtil.Clamp01(stop_ratio);
            if (stop_ratio == 0) return;

            CheckIsValidTriangleException(mesh);
            mesh.SetIsUpdatedToFalse();
            Kernel.Simplify_PH(mesh.Ptr, stop_ratio);
        }

        /// <summary>
        /// Simplify the mesh.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="stop_ratio">A percentage 0-1 of edges to remove.</param>
        public void Simplify(SurfaceMesh3 mesh, double stop_ratio)
        {
            stop_ratio = MathUtil.Clamp01(stop_ratio);
            if (stop_ratio == 0) return;

            CheckIsValidTriangleException(mesh);
            mesh.SetIsUpdatedToFalse();
            Kernel.Simplify_SM(mesh.Ptr, stop_ratio);
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
