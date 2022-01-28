using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class SurfaceSubdivisionKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        //Polyhedron

        internal abstract void Subdive_CatmullClark_PH(IntPtr polyPtr, int iterations);

        internal abstract void Subdive_Loop_PH(IntPtr polyPtr, int iterations);

        internal abstract void Subdive_Sqrt3_PH(IntPtr polyPtr, int iterations);

        //Surface Mesh

        internal abstract void Subdive_CatmullClark_SM(IntPtr polyPtr, int iterations);

        internal abstract void Subdive_DoSabin_SM(IntPtr polyPtr, int iterations);

        internal abstract void Subdive_Loop_SM(IntPtr polyPtr, int iterations);

        internal abstract void Subdive_Sqrt3_SM(IntPtr polyPtr, int iterations);
    }
}
