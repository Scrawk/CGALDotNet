using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Processing
{
    internal abstract class MeshProcessingMeshingKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

		//Polyhedron

		internal abstract IntPtr Extrude_PH(IntPtr meshPtr, Vector3d dir);

		internal abstract Index2 Fair_PH(IntPtr meshPtr, int index, int k_ring);

		internal abstract Index2 Refine_PH(IntPtr meshPtr, double density_control_factor);

		internal abstract int IsotropicRemeshing_PH(IntPtr meshPtr, int iterations, double target_edge_length);

		internal abstract void RandomPerturbation_PH(IntPtr meshPtr, double perturbation_max_size);

		internal abstract void SmoothMesh_PH(IntPtr meshPtr, double featureAngle, int iterations);

		internal abstract void SmoothShape_PH(IntPtr meshPtr, double timeStep, int iterations);

		internal abstract int SplitLongEdges_PH(IntPtr meshPtr, double target_edge_length);

		internal abstract bool TriangulateFace_PH(IntPtr meshPtr, int index);

		internal abstract bool TriangulateFaces_PH(IntPtr meshPtr, int[] faces, int count);

		//Surface Mesh

		internal abstract IntPtr Extrude_SM(IntPtr meshPtr, Vector3d dir);

		internal abstract Index2 Fair_SM(IntPtr meshPtr, int index, int k_ring);

		internal abstract Index2 Refine_SM(IntPtr meshPtr, double density_control_factor);

		internal abstract int IsotropicRemeshing_SM(IntPtr meshPtr, int iterations, double target_edge_length);

		internal abstract void RandomPerturbation_SM(IntPtr meshPtr, double perturbation_max_size);

		internal abstract void SmoothMesh_SM(IntPtr meshPtr, double featureAngle, int iterations);

		internal abstract void SmoothShape_SM(IntPtr meshPtr, double timeStep, int iterations);

		internal abstract int SplitLongEdges_SM(IntPtr meshPtr, double target_edge_length);

		internal abstract bool TriangulateFace_SM(IntPtr meshPtr, int index);

		internal abstract bool TriangulateFaces_SM(IntPtr meshPtr, int[] faces, int count);
	}
}
