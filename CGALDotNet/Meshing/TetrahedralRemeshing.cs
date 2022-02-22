using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polygons;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Meshing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class TetrahedralRemeshing<K> : TetrahedralRemeshing where K : CGALKernel, new()
    {
        /// <summary>
        /// A static instance of the tetrahedral remeshing.
        /// </summary>
        public static readonly TetrahedralRemeshing<K> Instance = new TetrahedralRemeshing<K>();

        /// <summary>
        /// 
        /// </summary>
        public TetrahedralRemeshing() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal TetrahedralRemeshing(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[TetrahedralRemeshing<{0}>: ]", Kernel.Name);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class TetrahedralRemeshing : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private TetrahedralRemeshing()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal TetrahedralRemeshing(CGALKernel kernel)
        {
            Kernel = kernel.TetrahedralRemeshingKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal TetrahedralRemeshing(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.TetrahedralRemeshingKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// The tetrahedral remeshing kernel.
        /// </summary>
        internal TetrahedralRemeshingKernel Kernel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetLength"></param>
        /// <param name="iterations"></param>
        /// <param name="points"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Remesh(double targetLength, int iterations, Point3d[] points, int count)
        {
            return Kernel.Remesh(Ptr, targetLength, iterations, points, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="count"></param>
        public void GetPoints(Point3d[] points, int count)
        {
            Kernel.GetPoints(Ptr, points, count);
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
