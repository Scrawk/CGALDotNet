using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{
    internal abstract class NefPolyhedronKernel3 : FuncKernel
    {
		internal abstract IntPtr CreateFromSpace(NEF_CONTENT space);

		internal abstract IntPtr CreateFromPlane(Plane3d plane, NEF_BOUNDARY boundary);

		internal abstract IntPtr CreateFromPolyhedron(IntPtr ptr);

		internal abstract void Release(IntPtr ptr);

		internal abstract void Clear(IntPtr ptr);

		internal abstract bool IsEmpty(IntPtr ptr);

		internal abstract bool IsSimple(IntPtr ptr);

		internal abstract bool IsSpace(IntPtr ptr);

		internal abstract bool IsValid(IntPtr ptr);

		internal abstract int EdgeCount(IntPtr ptr);

		internal abstract int FacetCount(IntPtr ptr);

		internal abstract int HalfEdgeCount(IntPtr ptr);

		internal abstract int HalfFacetCount(IntPtr ptr);

		internal abstract int VertexCount(IntPtr ptr);

		internal abstract int VolumeCount(IntPtr ptr);

		internal abstract IntPtr Intersection(IntPtr ptr1, IntPtr ptr2);

	}
}
