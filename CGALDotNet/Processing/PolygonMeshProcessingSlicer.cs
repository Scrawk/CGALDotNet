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
    public sealed class PolygonMeshProcessingSlicer<K> : PolygonMeshProcessingSlicer where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingSlicer<K> Instance = new PolygonMeshProcessingSlicer<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingSlicer() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingSlicer(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingSlicer<{0}>: ]", Kernel.KernelName);
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
    public abstract class PolygonMeshProcessingSlicer : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingSlicer()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingSlicer(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMeshProcessingSlicerKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingSlicer(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonMeshProcessingSlicerKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingSlicerKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

