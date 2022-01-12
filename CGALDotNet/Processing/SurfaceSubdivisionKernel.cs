using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class SurfaceSubdivisionKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void SubdivePolyhedron_CatmullClark(IntPtr polyPtr, int iterations);

        internal abstract void SubdivePolyhedron_Loop(IntPtr polyPtr, int iterations);

        internal abstract void SubdivePolyhedron_Sqrt3(IntPtr polyPtr, int iterations);
    }
}
