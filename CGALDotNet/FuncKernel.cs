using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace CGALDotNet
{
    internal abstract class FuncKernel
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        internal string KernelName
        {
            get
            {
                var str = GetType().Name.Split("_");

                if (str.Length == 2)
                    return str[1];
                else
                    return "";
            }
        }

    }
}
