using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonMeshProcessingConnections<K> : PolygonMeshProcessingConnections where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingConnections<K> Instance = new PolygonMeshProcessingConnections<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingConnections() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingConnections(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingConnections<{0}>: ]", Kernel.KernelName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="results"></param>
        public void SplitConnectedComponents(Polyhedron3<K> poly, List<Polyhedron3<K>> results)
        {
            int count = Kernel.PolyhedronSplitConnectedComponents(Ptr, poly.Ptr);
            if (count == 0) return;

            var ptrs = new IntPtr[count];
            Kernel.PolyhedronGetSplitConnectedComponents(Ptr, ptrs, count);

            for (int i = 0; i < count; i++)
                results.Add( new Polyhedron3<K>(ptrs[i]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poly"></param>
        /// <param name="num_components_to_keep"></param>
        /// <returns></returns>
        public int KeepLargestComponents(Polyhedron3<K> poly, int num_components_to_keep)
        {
            return Kernel.PolyhedronKeepLargestConnectedComponents(poly.Ptr, num_components_to_keep);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PolygonMeshProcessingConnections : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingConnections()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingConnections(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMeshProcessingConnectionsKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingConnections(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonMeshProcessingConnectionsKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingConnectionsKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

