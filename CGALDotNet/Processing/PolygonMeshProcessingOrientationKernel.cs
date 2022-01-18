using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class PolygonMeshProcessingOrientationKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract bool DoesBoundAVolume(IntPtr polyPtr);

        internal abstract bool IsOutwardOriented(IntPtr polyPtr);

        internal abstract void Orient(IntPtr polyPtr);

        internal abstract void OrientToBoundAVolume(IntPtr polyPtr);

        internal abstract void ReverseFaceOrientations(IntPtr polyPtr);
    }
}
