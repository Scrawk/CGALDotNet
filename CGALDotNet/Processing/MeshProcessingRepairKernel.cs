using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class MeshProcessingRepairKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

		//Polyhedron

		internal abstract int DegenerateEdgeCount_PH(IntPtr ptr);

		internal abstract int DegenerateTriangleCount_PH(IntPtr ptr);

		internal abstract int NeedleTriangleCount_PH(IntPtr ptr, double threshold);

		internal abstract int NonManifoldVertexCount_PH(IntPtr ptr);

		internal abstract void RepairPolygonSoup_PH(IntPtr ptr);

		internal abstract int StitchBoundaryCycles_PH(IntPtr ptr);

		internal abstract int StitchBorders_PH(IntPtr ptr);

		internal abstract int MergeDuplicatedVerticesInBoundaryCycle_PH(IntPtr ptr, int index);

		internal abstract int MergeDuplicatedVerticesInBoundaryCycles_PH(IntPtr ptr);

		internal abstract int RemoveIsolatedVertices_PH(IntPtr ptr);

		//SurfaceMesh

		internal abstract int DegenerateEdgeCount_SM(IntPtr ptr);

		internal abstract int DegenerateTriangleCount_SM(IntPtr ptr);

		internal abstract int NeedleTriangleCount_SM(IntPtr ptr, double threshold);

		internal abstract int NonManifoldVertexCount_SM(IntPtr ptr);

		internal abstract void RepairPolygonSoup_SM(IntPtr ptr);

		internal abstract int StitchBoundaryCycles_SM(IntPtr ptr);

		internal abstract int StitchBorders_SM(IntPtr ptr);

		internal abstract int MergeDuplicatedVerticesInBoundaryCycle_SM(IntPtr ptr, int index);

		internal abstract int MergeDuplicatedVerticesInBoundaryCycles_SM(IntPtr ptr);

		internal abstract int RemoveIsolatedVertices_SM(IntPtr ptr);
	}
}
