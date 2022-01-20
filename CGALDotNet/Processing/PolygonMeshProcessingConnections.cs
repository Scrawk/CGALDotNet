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

        public void ConnectedComponents(Polyhedron3<K> poly)
        {
            Kernel.PolyhedronConnectedComponents(poly.Ptr);
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

