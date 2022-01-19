using System;
using System.Collections.Generic;

using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    public enum SUBDIVISION_METHOD
    {
        CATMULL_CLARK,
        LOOP,
        SQRT3
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class SubdivisionSurface<K> : SubdivisionSurface where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly SubdivisionSurface<K> Instance = new SubdivisionSurface<K>();

        /// <summary>
        /// 
        /// </summary>
        public SubdivisionSurface() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[SubdivisionSurface<{0}>: ]", Kernel.KernelName);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class SubdivisionSurface : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private SubdivisionSurface()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal SubdivisionSurface(CGALKernel kernel)
        {
            Kernel = kernel.SurfaceSubdivisionKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        protected private SurfaceSubdivisionKernel Kernel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="method"></param>
        /// <param name="poly"></param>
        /// <param name="iterations"></param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool Subdivide(SUBDIVISION_METHOD method, Polyhedron3 poly, int iterations)
        {
            switch (method)
            {
                case SUBDIVISION_METHOD.CATMULL_CLARK:
                    return Subdivide_CatmullClark(poly, iterations);
                case SUBDIVISION_METHOD.LOOP:
                    return Subdivide_Loop(poly, iterations);
                case SUBDIVISION_METHOD.SQRT3:
                    return Subdivide_Sqrt3(poly, iterations);
                default:
                    return Subdivide_Sqrt3(poly, iterations);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="iterations"></param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool Subdivide_CatmullClark(Polyhedron3 poly, int iterations)
        {
            if (!CheckIsValid(poly) ||  iterations <= 0) 
                return false;

            Kernel.SubdivePolyhedron_CatmullClark(poly.Ptr, iterations);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="iterations"></param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool Subdivide_Loop(Polyhedron3 poly, int iterations)
        {
            if (!CheckIsValid(poly) || iterations <= 0)
                return false;

            CheckIsValidTriangleException(poly);
            Kernel.SubdivePolyhedron_Loop(poly.Ptr, iterations);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="iterations"></param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool Subdivide_Sqrt3(Polyhedron3 poly, int iterations)
        {
            if (!CheckIsValid(poly) || iterations <= 0)
                return false;

            CheckIsValidTriangleException(poly);
            Kernel.SubdivePolyhedron_Sqrt3(poly.Ptr, iterations);
            return true;
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
