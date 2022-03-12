using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polyhedra
{
    public struct MeshHalfedge3 : IEquatable<MeshHalfedge3>
	{
		public bool IsBorder;

		public int Index;

		public int Source;

		public int Target;

		public int Opposite;

		public int Next;

		public int Previous;

		public int Face;

		public static MeshHalfedge3 NullHalfedge
		{
			get
			{
				var edge = new MeshHalfedge3();
				edge.Index = CGALGlobal.NULL_INDEX;
				edge.Source = CGALGlobal.NULL_INDEX;
				edge.Target = CGALGlobal.NULL_INDEX;
				edge.Opposite = CGALGlobal.NULL_INDEX;
				edge.Next = CGALGlobal.NULL_INDEX;
				edge.Previous = CGALGlobal.NULL_INDEX;
				edge.Face = CGALGlobal.NULL_INDEX;
				return edge;
			}
		}

		public override string ToString()
		{
			return string.Format("[MeshHalfedge3: Index={0}, Source={1}, Target={2}, Opposite={3}, Next={4}, Previous={5}, Face={6}, IsBorder={7}]",
				Index, Source, Target, Opposite, Next, Previous, Face,  IsBorder);
		}

		public static bool operator ==(MeshHalfedge3 v1, MeshHalfedge3 v2)
		{
			return v1.Index == v2.Index && v1.IsBorder == v2.IsBorder
				&& v1.Source == v2.Source && v1.Target == v2.Target
				&& v1.Opposite == v2.Opposite && v1.Next == v2.Next
				&& v1.Previous == v2.Previous && v1.Face == v2.Face;
		}

		public static bool operator !=(MeshHalfedge3 v1, MeshHalfedge3 v2)
		{
			return v1.Index != v2.Index || v1.IsBorder != v2.IsBorder
				|| v1.Source != v2.Source || v1.Target != v2.Target
				|| v1.Opposite != v2.Opposite || v1.Next != v2.Next
				|| v1.Previous != v2.Previous || v1.Face != v2.Face;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is MeshHalfedge3)) return false;
			MeshHalfedge3 v = (MeshHalfedge3)obj;
			return this == v;
		}

		public bool Equals(MeshHalfedge3 v)
		{
			return this == v;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = (int)MathUtil.HASH_PRIME_1;
				hash = (hash * MathUtil.HASH_PRIME_2) ^ IsBorder.GetHashCode();
				hash = (hash * MathUtil.HASH_PRIME_2) ^ Index.GetHashCode();
				hash = (hash * MathUtil.HASH_PRIME_2) ^ Source.GetHashCode();
				hash = (hash * MathUtil.HASH_PRIME_2) ^ Target.GetHashCode();
				hash = (hash * MathUtil.HASH_PRIME_2) ^ Opposite.GetHashCode();
				hash = (hash * MathUtil.HASH_PRIME_2) ^ Next.GetHashCode();
				hash = (hash * MathUtil.HASH_PRIME_2) ^ Previous.GetHashCode();
				hash = (hash * MathUtil.HASH_PRIME_2) ^ Face.GetHashCode();
				return hash;
			}
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
