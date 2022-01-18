using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    internal sealed class PolygonMeshProcessingConnected<K> : PolygonMeshProcessingConnected where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingConnected<K> Instance = new PolygonMeshProcessingConnected<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingConnected() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingConnected(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingConnected<{0}>: ]", Kernel.KernelName);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal abstract class PolygonMeshProcessingConnected : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingConnected()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingConnected(CGALKernel kernel)
        {
            //Kernel = kernel.PolygonMeshProcessingConnectedKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingConnected(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            //Kernel = kernel.PolygonMeshProcessingConnectedKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingConnectedKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

