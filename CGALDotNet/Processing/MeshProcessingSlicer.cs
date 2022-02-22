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
            return string.Format("[MeshProcessingSlicer<{0}>: ]", Kernel.Name);
        }
        
        /// <summary>
        /// Find the line formed from the intersection of the plane and the mesh.
        /// </summary>
        /// <param name="mesh">The mesh. Is not modified.</param>
        /// <param name="plane">The plane.</param>
        /// <param name="results">The polylines from the intersection.</param>
        public void Slice(Polyhedron3<K> mesh, Plane3d plane, List<Polyline3<K>> results)
        {
            int count = Kernel.Slice_PH(Ptr, mesh.Ptr, plane, true);
            GetLines(count, results);
        }

        /// <summary>
        /// Find the line formed from the intersection of the plane and the mesh.
        /// </summary>
        /// <param name="mesh">The mesh. Is not modified.</param>
        /// <param name="plane">The plane.</param>
        /// <param name="results">The polylines from the intersection.</param>
        public void Slice(SurfaceMesh3<K> mesh, Plane3d plane, List<Polyline3<K>> results)
        {
            int count = Kernel.Slice_SM(Ptr, mesh.Ptr, plane, true);
            GetLines(count, results);
        }

        /// <summary>
        /// Find the lines formed by slicing the mesh from the start
        /// point to the end point creating a plane at each increment.
        /// </summary>
        /// <param name="mesh">The mesh. Is not modified.</param>
        /// <param name="start">The point to start from.</param>
        /// <param name="end">The point to end at.</param>
        /// <param name="increment">Amount to increment each plane.</param>
        /// <param name="results">he polylines from the intersection.</param>
        public void Slice(Polyhedron3<K> mesh, Point3d start, Point3d end, double increment, List<Polyline3<K>> results)
        {
            int count = Kernel.IncrementalSlice_PH(Ptr, mesh.Ptr, start, end, increment);
            GetLines(count, results);
        }

        /// <summary>
        /// Find the lines formed by slicing the mesh from the start
        /// point to the end point creating a plane at each increment.
        /// </summary>
        /// <param name="mesh">The mesh. Is not modified.</param>
        /// <param name="start">The point to start from.</param>
        /// <param name="end">The point to end at.</param>
        /// <param name="increment">Amount to increment each plane.</param>
        /// <param name="results">he polylines from the intersection.</param>
        public void Slice(SurfaceMesh3<K> mesh, Point3d start, Point3d end, double increment, List<Polyline3<K>> results)
        {
            int count = Kernel.IncrementalSlice_SM(Ptr, mesh.Ptr, start, end, increment);
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

