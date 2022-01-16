using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    internal sealed class PolygonMeshProcessingNormals<K> : PolygonMeshProcessingNormals where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingNormals<K> Instance = new PolygonMeshProcessingNormals<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingNormals() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingNormals(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingNormals<{0}>: ]", Kernel.KernelName);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal abstract class PolygonMeshProcessingNormals : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingNormals()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingNormals(CGALKernel kernel)
        {
            //Kernel = kernel.PolygonMeshProcessingNormalsKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingNormals(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            //Kernel = kernel.PolygonMeshProcessingNormalsKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingNormalsKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

