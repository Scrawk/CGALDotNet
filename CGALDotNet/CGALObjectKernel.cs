using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.InteropServices;

namespace CGALDotNet
{
    internal abstract class CGALObjectKernel
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        internal abstract string Name { get; }

    }
}
