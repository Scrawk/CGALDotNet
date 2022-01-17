using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class PolygonMeshProcessingMeshingKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

		internal abstract void Extrude(IntPtr polyPtr);

		internal abstract bool Fair(IntPtr polyPtr);

		internal abstract int Refine(IntPtr polyPtr, double density_control_factor);

		internal abstract void IsotropicRemeshing(IntPtr polyPtr, int iterations, double target_edge_length);

		internal abstract void RandomPerturbation(IntPtr polyPtr, double perturbation_max_size);

		internal abstract void SmoothMesh(IntPtr polyPtr);

		internal abstract void SmoothShape(IntPtr polyPtr);

		internal abstract void SplitLongEdges(IntPtr polyPtr, double target_edge_length);
	}
}
