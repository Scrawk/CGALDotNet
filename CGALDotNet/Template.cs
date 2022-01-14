using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    internal sealed class Template<K> : Template where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly Template<K> Instance = new Template<K>();

        /// <summary>
        /// 
        /// </summary>
        public Template() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal Template(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Template<{0}>: ]", "");//Kernel.KernelName);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal abstract class Template : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private Template()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal Template(CGALKernel kernel)
        {
            //Kernel = kernel.TemplateKernel;
            //Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal Template(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            //Kernel = kernel.TemplateKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        //internal TemplateKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            //Kernel.Release(Ptr);
        }
    }
}
