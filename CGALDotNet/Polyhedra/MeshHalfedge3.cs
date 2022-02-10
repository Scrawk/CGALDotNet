using System;
using System.Collections.Generic;

namespace CGALDotNet.Polyhedra
{
    public struct MeshHalfedge3
    {
		public bool IsBorder;

		public int Index;

		public int Vertex;

		public int Opposite;

		public int Next;

		public int Previous;

		public override string ToString()
		{
			return string.Format("[MeshHalfedge3: Index={0}, Opposite={1}, Next={2}, Previous={3}, IsBorder={4}]",
				Index, Opposite, Next, Previous, IsBorder);
		}

		public IEnumerable<MeshHalfedge3> EnumerateHalfedges(IMesh mesh)
		{
			var start = this;
			var e = start;

			int count = mesh.HalfedgeCount;

			do
			{
				yield return e;

				if (e.Next >= 0 && e.Next < count)
					mesh.GetHalfedge(e.Next, out e);
				else
					yield break;

			}
			while (e.Index != start.Index);
		}

		public IEnumerable<MeshVertex3> EnumerateVertices(IMesh mesh)
		{
			var start = this;
			var e = start;

			int vertCount = mesh.VertexCount;
			int edgeCount = mesh.HalfedgeCount;

			do
			{
				if (e.Vertex >= 0 && e.Vertex < vertCount)
				{
					MeshVertex3 vert;
					mesh.GetVertex(e.Vertex, out vert);
					yield return vert;
				}

				if (e.Next >= 0 && e.Next < edgeCount)
					mesh.GetHalfedge(e.Next, out e);
				else
					yield break;
			}
			while (e.Index != start.Index);
		}
	}
}
