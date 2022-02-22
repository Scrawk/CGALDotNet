using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Hulls
{

    /// <summary>
    /// The generic convex hull class.
    /// </summary>
    /// <typeparam name="K">The kernel type</typeparam>
    public sealed class ConvexHull3<K> : ConvexHull3 where K : CGALKernel, new()
    {
        /// <summary>
        /// The static instance.
        /// </summary>
        public static readonly ConvexHull3<K> Instance = new ConvexHull3<K>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ConvexHull3() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[ConvexHull3<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Create the convex hull from a set of points.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The point arrays length</param>
        /// <returns>The hull as a polyhedron.</returns>
        public Polyhedron3<K> CreateHullAsPolyhedron(Point3d[] points, int count)
        {
            CheckCount(count);
            ErrorUtil.CheckArray(points, count);
            var ptr = Kernel.CreateHullAsPolyhedronFromPoints(points, count);
            return new Polyhedron3<K>(ptr);
        }

        /// <summary>
        /// Create the convex hull from a set of points.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The point arrays length</param>
        /// <returns>The hull as a surface mesh.</returns>
        public SurfaceMesh3<K> CreateHullAsSurfaceMesh(Point3d[] points, int count)
        {
            CheckCount(count);
            ErrorUtil.CheckArray(points, count);
            var ptr = Kernel.CreateHullAsSurfaceMeshFromPoints(points, count);
            return new SurfaceMesh3<K>(ptr);
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="planes"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Polyhedron3<K> CreateHullAsPolyhedron(Plane3d[] planes, int count)
        {
            CheckCount(count);
            ErrorUtil.CheckArray(planes, count);
            var ptr = Kernel.CreateHullAsPolyhedronFromPlanes(planes, count);
             return new Polyhedron3<K>(ptr);
        }
        */

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="planes"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public SurfaceMesh3<K> CreateHullAsSurfaceMesh(Plane3d[] planes, int count)
        {
           CheckCount(count);
           ErrorUtil.CheckArray(planes, count);
            var ptr = Kernel.CreateHullAsSurfaceMeshFromPlanes(planes, count);
            return new SurfaceMesh3<K>(ptr);
        }
        */
    }

    /// <summary>
    /// The convex hull abstract base class.
    /// </summary>
    public abstract class ConvexHull3 : CGALObject
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        private ConvexHull3()
        {

        }

        /// <summary>
        /// Construct hull with the kernel.
        /// </summary>
        /// <param name="kernel">The kernel</param>
        internal ConvexHull3(CGALKernel kernel)
        {
            Kernel = kernel.ConvexHullKernel3;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The hulls kernel type.
        /// </summary>
        protected private ConvexHullKernel3 Kernel { get; private set; }

        /// <summary>
        /// Check if the points in the polyhedron are convex.
        /// </summary>
        /// <param name="poly">The polyhedron.</param>
        /// <returns>True if the polyhedron is convex.</returns>
        public bool IsStronglyConvex(Polyhedron3 poly)
        {
            return Kernel.IsPolyhedronStronglyConvex(poly.Ptr);
        }

        /// <summary>
        /// Check if the points in the mesh are convex.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <returns>True if the mesh is convex.</returns>
        public bool IsStronglyConvex(SurfaceMesh3 mesh)
        {
            return Kernel.IsSurfaceMeshStronglyConvex(mesh.Ptr); ;
        }

        /// <summary>
        /// Checks if the minimum number of points have been provided.
        /// </summary>
        /// <param name="count">The point array length.</param>
        /// <exception cref="ArgumentException"></exception>
        protected void CheckCount(int count)
        {
            if (count < 4)
                throw new ArgumentException("4 or more points must be provided to find the convex hull.");
        }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
