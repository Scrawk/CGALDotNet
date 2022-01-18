using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Processing
{
    internal abstract class PolygonMeshProcessingRepairKernel : FuncKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

		internal abstract int DegenerateHalfEdgeCount(IntPtr ptr);

		internal abstract int DegenerateTriangleCount(IntPtr ptr);

		internal abstract int NeedleTriangleCount(IntPtr ptr, double threshold);

		internal abstract int NonManifoldVertexCount(IntPtr ptr);

		internal abstract void RepairPolygonSoup(IntPtr ptr);

		internal abstract int StitchBoundaryCycles(IntPtr ptr);

		internal abstract int StitchBorders(IntPtr ptr);

		internal abstract int MergeDuplicatedVerticesInBoundaryCycle(IntPtr ptr);

		internal abstract int RemoveIsolatedVertices(IntPtr ptr);

		internal abstract void PolygonMeshToPolygonSoup(IntPtr ptr, int[] triangles, int triangleCount, int[] quads, int quadCount);
	}
}
