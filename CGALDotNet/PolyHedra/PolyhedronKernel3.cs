using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CGALDotNet.PolyHedra
{
    internal abstract class PolyhedronKernel3 : FuncKernel
	{
        internal abstract IntPtr Create();

		internal abstract IntPtr CreateFromSize(int vertices, int halfedges, int faces);

		internal abstract void Release(IntPtr ptr);

		internal abstract void Clear(IntPtr ptr);

		internal abstract int VertexCount(IntPtr ptr);

		internal abstract int FaceCount(IntPtr ptr);

		internal abstract int HalfEdgeCount(IntPtr ptr);

		internal abstract int BorderEdgeCount(IntPtr ptr);

		internal abstract int BorderHalfEdgeCount(IntPtr ptr);

		internal abstract bool IsValid(IntPtr ptr, int level);

		internal abstract bool IsClosed(IntPtr ptr);

		internal abstract bool IsPureBivalent(IntPtr ptr);

		internal abstract bool IsPureTrivalent(IntPtr ptr);

		internal abstract bool IsPureTriangle(IntPtr ptr);

		internal abstract bool IsPureQuad(IntPtr ptr);


	}
}
