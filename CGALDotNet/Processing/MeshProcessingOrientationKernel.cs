using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class MeshProcessingOrientationKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        //Polyhedron 
        internal abstract bool DoesBoundAVolume_PH(IntPtr polyPtr);

        internal abstract bool IsOutwardOriented_PH(IntPtr polyPtr);

        internal abstract void Orient_PH(IntPtr polyPtr);

        internal abstract void OrientToBoundAVolume_PH(IntPtr polyPtr);

        internal abstract void ReverseFaceOrientations_PH(IntPtr polyPtr);

        //Surface Mesh 
        internal abstract bool DoesBoundAVolume_SM(IntPtr polyPtr);

        internal abstract bool IsOutwardOriented_SM(IntPtr polyPtr);

        internal abstract void Orient_SM(IntPtr polyPtr);

        internal abstract void OrientToBoundAVolume_SM(IntPtr polyPtr);

        internal abstract void ReverseFaceOrientations_SM(IntPtr polyPtr);
    }
}
