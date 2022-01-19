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
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="poly">A valid mesh. Must be a triangle mesh for loop or sqrt3.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide(SUBDIVISION_METHOD method, Polyhedron3 poly, int iterations)
        {
            switch (method)
            {
                case SUBDIVISION_METHOD.CATMULL_CLARK:
                    Subdivide_CatmullClark(poly, iterations);
                    break;
                case SUBDIVISION_METHOD.LOOP:
                    Subdivide_Loop(poly, iterations);
                    break;
                case SUBDIVISION_METHOD.SQRT3:
                    Subdivide_Sqrt3(poly, iterations);
                    break;
                default:
                    Subdivide_Sqrt3(poly, iterations);
                    break;
            }
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="poly">A valid mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_CatmullClark(Polyhedron3 poly, int iterations)
        {
            if (iterations < 0) return;
            CheckIsValidException(poly);
            Kernel.SubdivePolyhedron_CatmullClark(poly.Ptr, iterations);
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="poly">A valid triangle mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_Loop(Polyhedron3 poly, int iterations)
        {
            if (iterations < 0) return;
            CheckIsValidTriangleException(poly);
            Kernel.SubdivePolyhedron_Loop(poly.Ptr, iterations);
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="poly">A valid triangle mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_Sqrt3(Polyhedron3 poly, int iterations)
        {
            if (iterations < 0) return;
            CheckIsValidTriangleException(poly);
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
