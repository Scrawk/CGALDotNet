using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polyhedra;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Meshing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class SkinSurfaceMeshing<K> : SkinSurfaceMeshing where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly SkinSurfaceMeshing<K> Instance = new SkinSurfaceMeshing<K>();

        /// <summary>
        /// 
        /// </summary>
        public SkinSurfaceMeshing() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal SkinSurfaceMeshing(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[SkinMeshing<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shrinkFactor"></param>
        /// <param name="subdivde"></param>
        /// <param name="points"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Polyhedron3<K> CreateSkinPolyhedra(double shrinkFactor, bool subdivde, Point3d[] points, int count)
        {
            if (shrinkFactor < 0)
                shrinkFactor = 0;

            if (shrinkFactor == 0)
                return new Polyhedron3<K>();

            ErrorUtil.CheckArray(points, count);
            var ptr = Kernel.MakeSkinSurface(shrinkFactor, subdivde, points, count);
            return new Polyhedron3<K>(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shrinkFactor"></param>
        /// <param name="subdivde"></param>
        /// <param name="points"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public Polyhedron3<K> CreateSkinPolyhedra(double shrinkFactor, bool subdivde, HPoint3d[] points, int count)
        {
            if(shrinkFactor < 0)
                shrinkFactor = 0;

            if (shrinkFactor == 0)
                return new Polyhedron3<K>();

            ErrorUtil.CheckArray(points, count);
            var ptr = Kernel.MakeSkinSurface(shrinkFactor, subdivde, points, count);
            return new Polyhedron3<K>(ptr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class SkinSurfaceMeshing : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private SkinSurfaceMeshing()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal SkinSurfaceMeshing(CGALKernel kernel)
        {
            Kernel = kernel.SkinSurfaceMeshingKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal SkinSurfaceMeshing(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.SkinSurfaceMeshingKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal SkinSurfaceMeshingKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
