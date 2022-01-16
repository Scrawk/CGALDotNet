using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    internal sealed class PolygonMeshProcessingRepair<K> : PolygonMeshProcessingRepair where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingRepair<K> Instance = new PolygonMeshProcessingRepair<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingRepair() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingRepair(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingRepair<{0}>: ]", Kernel.KernelName);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal abstract class PolygonMeshProcessingRepair : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingRepair()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingRepair(CGALKernel kernel)
        {
            //Kernel = kernel.PolygonMeshProcessingRepairKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingRepair(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            //Kernel = kernel.PolygonMeshProcessingRepairKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingRepairKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

