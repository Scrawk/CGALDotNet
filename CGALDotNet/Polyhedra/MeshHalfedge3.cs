using System;
using System.Collections.Generic;

namespace CGALDotNet.Polyhedra
{
    public struct MeshHalfedge3
    {
		public bool IsBorder;

		public int Index;

		public int Source;

		public int Target;

		public int Opposite;

		public int Next;

		public int Previous;

		public int Face;

		public override string ToString()
		{
			return string.Format("[MeshHalfedge3: Index={0}, Source={1}, Target={2}, Opposite={3}, Next={4}, Previous={5}, Face={6}, IsBorder={7}]",
				Index, Source, Target, Opposite, Next, Previous, Face,  IsBorder);
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
				if (e.Source >= 0 && e.Source < vertCount)
				{
					MeshVertex3 vert;
					mesh.GetVertex(e.Source, out vert);
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
