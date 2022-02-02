using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polyhedra;
using CGALDotNet.Polylines;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class MeshProcessingSlicer<K> : MeshProcessingSlicer where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly MeshProcessingSlicer<K> Instance = new MeshProcessingSlicer<K>();

        /// <summary>
        /// 
        /// </summary>
        public MeshProcessingSlicer() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MeshProcessingSlicer(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshProcessingSlicer<{0}>: ]", Kernel.KernelName);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="plane"></param>
        /// <param name="results"></param>
        public void Slice(Polyhedron3<K> poly, Plane3d plane, List<Polyline3<K>> results)
        {
            int count = Kernel.Slice(Ptr, poly.Ptr, plane, true);
            GetLines(count, results);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="increment"></param>
        /// <param name="results"></param>
        public void Slice(Polyhedron3<K> poly, Point3d start, Point3d end, double increment, List<Polyline3<K>> results)
        {
            int count = Kernel.Slice(Ptr, poly.Ptr, start, end, increment);
            GetLines(count, results);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="results"></param>
        private void GetLines(int count, List<Polyline3<K>> results)
        {
            if (count == 0) return;

            var ptrs = new IntPtr[count];
            Kernel.GetLines(Ptr, ptrs, count);

            for (int i = 0; i < count; i++)
            {
                var line = new Polyline3<K>(ptrs[i]);
                results.Add(line);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MeshProcessingSlicer : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private MeshProcessingSlicer()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal MeshProcessingSlicer(CGALKernel kernel)
        {
            Kernel = kernel.MeshProcessingSlicerKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal MeshProcessingSlicer(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.MeshProcessingSlicerKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal MeshProcessingSlicerKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

