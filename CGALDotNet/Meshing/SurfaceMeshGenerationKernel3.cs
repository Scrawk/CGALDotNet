using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CGALDotNet.Meshing
{
    public abstract class SurfaceMeshGenerationKernel3
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        internal abstract string Name { get; }

        public abstract void Generate();
    }
}
