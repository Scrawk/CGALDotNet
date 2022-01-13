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

    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class SubdivisionSurface : CGALObject
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
        public void Subdivide(SUBDIVISION_METHOD method, Polyhedron3 poly, int iterations)
        {
            if (iterations < 0) return;

            switch (method)
            {
                case SUBDIVISION_METHOD.CATMULL_CLARK:
                    Kernel.SubdivePolyhedron_CatmullClark(poly.Ptr, iterations);
                    break;
                case SUBDIVISION_METHOD.LOOP:
                    Kernel.SubdivePolyhedron_Loop(poly.Ptr, iterations);
                    break;
                case SUBDIVISION_METHOD.SQRT3:
                    Kernel.SubdivePolyhedron_Sqrt3(poly.Ptr, iterations);
                    break;
                default:
                    Kernel.SubdivePolyhedron_CatmullClark(poly.Ptr, iterations);
                    break;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="iterations"></param>
        public void Subdivide_CatmullClark(Polyhedron3 poly, int iterations)
        {
            if (iterations < 0) return;
            Kernel.SubdivePolyhedron_CatmullClark(poly.Ptr, iterations);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="iterations"></param>
        public void Subdivide_Loop(Polyhedron3 poly, int iterations)
        {
            if (iterations < 0) return;
            Kernel.SubdivePolyhedron_Loop(poly.Ptr, iterations);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="iterations"></param>
        public void Subdivide_Sqrt3(Polyhedron3 poly, int iterations)
        {
            if (iterations < 0) return;
            Kernel.SubdivePolyhedron_Sqrt3(poly.Ptr, iterations);
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
