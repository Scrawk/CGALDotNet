using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polyhedra;
using CGALDotNet.Polylines;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class MeshProcessingLocate<K> : MeshProcessingLocate where K : CGALKernel, new()
    {

        /// <summary>
        /// 
        /// </summary>
        public static readonly MeshProcessingLocate<K> Instance = new MeshProcessingLocate<K>();

        /// <summary>
        /// 
        /// </summary>
        public MeshProcessingLocate() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MeshProcessingLocate(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshProcessingLocate<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Find a random point on mesh surface.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <returns>A random point on mesh surface.</returns>
        public Point3d RandomLocationOnMesh(Polyhedron3<K> mesh)
        {
            return Kernel.RandomLocationOnMesh_PH(mesh.Ptr);
        }

        /// <summary>
        /// Find a random point on mesh surface.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <returns>A random point on mesh surface.</returns>
        public Point3d RandomLocationOnMesh(SurfaceMesh3<K> mesh)
        {
            return Kernel.RandomLocationOnMesh_SM(mesh.Ptr);
        }

        /// <summary>
        /// Find the face the ray intersects with.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="ray">Th ray.</param>
        /// <returns>The hit result with theface index, hit point and the barycentric coords.</returns>
        public MeshHitResult LocateFace(Polyhedron3<K> mesh, Ray3d ray)
        {
            return Kernel.LocateFaceRay_PH(mesh.Ptr, ray);
        }

        /// <summary>
        /// Find the face the ray intersects with.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="ray">Th ray.</param>
        /// <returns>The hit result with theface index, hit point and the barycentric coords.</returns>
        public MeshHitResult LocateFace(SurfaceMesh3<K> mesh, Ray3d ray)
        {
            return Kernel.LocateFaceRay_SM(mesh.Ptr, ray);
        }

        /// <summary>
        /// Find the closest face to the point.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="point">Th point.</param>
        /// <returns>The hit result with the face index, closest point and the barycentric coords.</returns>
        public MeshHitResult ClosestFace(Polyhedron3<K> mesh, Point3d point)
        {
            return Kernel.LocateFacePoint_PH(mesh.Ptr, point);
        }

        /// <summary>
        /// Find the closest face to the point.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="point">Th point.</param>
        /// <returns>The hit result with the face index, closest point and the barycentric coords.</returns>
        public MeshHitResult ClosestFace(SurfaceMesh3<K> mesh, Point3d point)
        {
            return Kernel.LocateFacePoint_SM(mesh.Ptr, point);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MeshProcessingLocate : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private MeshProcessingLocate()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal MeshProcessingLocate(CGALKernel kernel)
        {
            Kernel = kernel.MeshProcessingLocateKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal MeshProcessingLocate(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.MeshProcessingLocateKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal MeshProcessingLocateKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

