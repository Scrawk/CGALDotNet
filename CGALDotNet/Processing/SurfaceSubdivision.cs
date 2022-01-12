using System;
using System.Collections.Generic;

using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{

    public enum SUBDIVISION_METHOD
    {
        CATMULL_CLARK,
        LOOP,
        SQRT3
    }


    public sealed class SubdivisionSurface<K> : SubdivisionSurface where K : CGALKernel, new()
    {
        public static readonly SubdivisionSurface<K> Instance = new SubdivisionSurface<K>();

        public SubdivisionSurface() : base(new K())
        {

        }

    }

    public abstract class SubdivisionSurface : CGALObject
    {
        private SubdivisionSurface()
        {

        }

        internal SubdivisionSurface(CGALKernel kernel)
        {
            Kernel = kernel.SurfaceSubdivisionKernel;
            Ptr = Kernel.Create();
        }

        protected private SurfaceSubdivisionKernel Kernel { get; private set; }

        public void Subdivide(Polyhedron3 poly, int iterations, SUBDIVISION_METHOD method)
        {
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

        public void Subdivide_CatmullClark(Polyhedron3 poly, int iterations)
        {
            Kernel.SubdivePolyhedron_CatmullClark(poly.Ptr, iterations);
        }

        public void Subdivide_Loop(Polyhedron3 poly, int iterations)
        {
            Kernel.SubdivePolyhedron_Loop(poly.Ptr, iterations);
        }

        public void Subdivide_Sqrt3(Polyhedron3 poly, int iterations)
        {
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
