using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polyhedra
{

	public struct MeshHalfedge3 : IEquatable<MeshHalfedge3>
	{
		/// <summary>
		/// Is the edge a border to a hole.
		/// </summary>
		public bool IsBorder;

		/// <summary>
		/// The edges index.
		/// </summary>
		public int Index;

		/// <summary>
		/// The edges  source vertices index.
		/// </summary>
		public int Source;

		/// <summary>
		/// The edges  target vertices index.
		/// </summary>
		public int Target;

		/// <summary>
		/// The edges opposite edge.
		/// </summary>
		public int Opposite;

		/// <summary>
		/// The edges next edge.
		/// </summary>
		public int Next;

		/// <summary>
		/// The edges previous edge.
		/// </summary>
		public int Previous;

		/// <summary>
		/// The edges face
		/// </summary>
		public int Face;

		/// <summary>
		/// A edge where everthing is set to null index.
		/// </summary>
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

		/// <summary>
		/// Get the source point. 
		/// </summary>
		/// <param name="mesh">The mesh the point belongs to.</param>
		/// <returns>The  source point</returns>
		/// <exception cref="ArgumentException">If point is null index.</exception>
		public Point3d SourcePoint(IMesh mesh)
        {
			if (Source == CGALGlobal.NULL_INDEX)
				throw new ArgumentException("Source is null");

			return mesh.GetPoint(Source);
        }

		/// <summary>
		/// Get the target point. 
		/// </summary>
		/// <param name="mesh">The mesh the point belongs to.</param>
		/// <returns>The  target point</returns>
		/// <exception cref="ArgumentException">If point is null index.</exception>
		public Point3d TargetPoint(IMesh mesh)
		{
			if (Target == CGALGlobal.NULL_INDEX)
				throw new ArgumentException("Target is null");

			return mesh.GetPoint(Target);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("[MeshHalfedge3: Index={0}, Source={1}, Target={2}, Opposite={3}, Next={4}, Previous={5}, Face={6}, IsBorder={7}]",
				Index, Source, Target, Opposite, Next, Previous, Face,  IsBorder);
		}

		/// <summary>
		/// Are these edges equal.
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static bool operator ==(MeshHalfedge3 v1, MeshHalfedge3 v2)
		{
			return v1.Index == v2.Index && v1.IsBorder == v2.IsBorder
				&& v1.Source == v2.Source && v1.Target == v2.Target
				&& v1.Opposite == v2.Opposite && v1.Next == v2.Next
				&& v1.Previous == v2.Previous && v1.Face == v2.Face;
		}

		/// <summary>
		/// Are these edges not equal.
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static bool operator !=(MeshHalfedge3 v1, MeshHalfedge3 v2)
		{
			return v1.Index != v2.Index || v1.IsBorder != v2.IsBorder
				|| v1.Source != v2.Source || v1.Target != v2.Target
				|| v1.Opposite != v2.Opposite || v1.Next != v2.Next
				|| v1.Previous != v2.Previous || v1.Face != v2.Face;
		}

		/// <summary>
		/// Are these objects equal.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (!(obj is MeshHalfedge3)) return false;
			MeshHalfedge3 v = (MeshHalfedge3)obj;
			return this == v;
		}

		/// <summary>
		/// Are these edges equal.
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public bool Equals(MeshHalfedge3 v)
		{
			return this == v;
		}

		/// <summary>
		/// The edges hahe code
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Enmerate all edges in this edge loop.
		/// </summary>
		/// <param name="mesh">The mesh the edges belong too.</param>
		/// <returns>The next edge</returns>
		public IEnumerable<MeshHalfedge3> EnumerateHalfedges(IMesh mesh)
		{
			var start = this;
			var e = start;

			do
			{
				yield return e;

				if (e.Next != CGALGlobal.NULL_INDEX)
					mesh.GetHalfedge(e.Next, out e);
				else
					yield break;

			}
			while (e.Index != start.Index);
		}

		/// <summary>
		/// Enmerate all vertices in this edge loop.
		/// </summary>
		/// <param name="mesh">The mesh the edges belong too.</param>
		/// <returns>The next vertex</returns>
		public IEnumerable<MeshVertex3> EnumerateVertices(IMesh mesh)
		{
			var start = this;
			var e = start;

			do
			{
				if (e.Source != CGALGlobal.NULL_INDEX)
				{
					MeshVertex3 vert;
					mesh.GetVertex(e.Source, out vert);
					yield return vert;
				}

				if (e.Next != CGALGlobal.NULL_INDEX)
					mesh.GetHalfedge(e.Next, out e);
				else
					yield break;
			}
			while (e.Index != start.Index);
		}
	}
}
