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
            return string.Format("[SubdivisionSurface<{0}>: ]", Kernel.Name);
        }


        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="mesh">A valid mesh. Must be a triangle mesh for loop or sqrt3.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide(SUBDIVISION_METHOD method, Polyhedron3<K> mesh, int iterations)
        {
            switch (method)
            {
                case SUBDIVISION_METHOD.CATMULL_CLARK:
                    Subdivide_CatmullClark(mesh, iterations);
                    break;
                case SUBDIVISION_METHOD.LOOP:
                    Subdivide_Loop(mesh, iterations);
                    break;
                case SUBDIVISION_METHOD.SQRT3:
                    Subdivide_Sqrt3(mesh, iterations);
                    break;
                default:
                    Subdivide_Sqrt3(mesh, iterations);
                    break;
            }
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="method"></param>
        /// <param name="mesh">A valid mesh. Must be a triangle mesh for loop or sqrt3.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide(SUBDIVISION_METHOD method, SurfaceMesh3<K> mesh, int iterations)
        {
            switch (method)
            {
                case SUBDIVISION_METHOD.CATMULL_CLARK:
                    Subdivide_CatmullClark(mesh, iterations);
                    break;
                case SUBDIVISION_METHOD.LOOP:
                    Subdivide_Loop(mesh, iterations);
                    break;
                case SUBDIVISION_METHOD.SQRT3:
                    Subdivide_Sqrt3(mesh, iterations);
                    break;
                default:
                    Subdivide_Sqrt3(mesh, iterations);
                    break;
            }
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_CatmullClark(Polyhedron3<K> mesh, int iterations)
        {
            if (iterations <= 0) return;
            CheckIsValidException(mesh);
            Kernel.Subdive_CatmullClark_PH(mesh.Ptr, iterations);
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_CatmullClark(SurfaceMesh3<K> mesh, int iterations)
        {
            if (iterations <= 0) return;
            CheckIsValidException(mesh);
            Kernel.Subdive_CatmullClark_SM(mesh.Ptr, iterations);
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_Loop(Polyhedron3<K> mesh, int iterations)
        {
            if (iterations <= 0) return;
            CheckIsValidTriangleException(mesh);
            Kernel.Subdive_Loop_PH(mesh.Ptr, iterations);
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_Loop(SurfaceMesh3<K> mesh, int iterations)
        {
            if (iterations <= 0) return;
            CheckIsValidTriangleException(mesh);
            Kernel.Subdive_Loop_SM(mesh.Ptr, iterations);
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_DoSabin(SurfaceMesh3<K> mesh, int iterations)
        {
            if (iterations <= 0) return;
            CheckIsValidTriangleException(mesh);
            Kernel.Subdive_DoSabin_SM(mesh.Ptr, iterations);
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_Sqrt3(Polyhedron3<K> mesh, int iterations)
        {
            if (iterations <= 0) return;
            CheckIsValidTriangleException(mesh);
            Kernel.Subdive_Sqrt3_PH(mesh.Ptr, iterations);
        }

        /// <summary>
        /// Subdive each face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="iterations">The number of subdivision iterations.</param>
        public void Subdivide_Sqrt3(SurfaceMesh3<K> mesh, int iterations)
        {
            if (iterations <= 0) return;
            CheckIsValidTriangleException(mesh);
            Kernel.Subdive_Sqrt3_SM(mesh.Ptr, iterations);
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
        /// Release the unmanaged resourses.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
