using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CGALDotNet.PolyHedra
{
    internal abstract class PolyhedronKernel3
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

		internal abstract void Clear(IntPtr ptr);

		internal abstract int VertexCount(IntPtr ptr);

		internal abstract int FaceCount(IntPtr ptr);

		internal abstract int HalfEdgeCount(IntPtr ptr);

		internal abstract int BorderEdgeCount(IntPtr ptr);

		internal abstract int BorderHalfEdgeCount(IntPtr ptr);

		internal abstract bool IsClosed(IntPtr ptr);

		internal abstract bool IsPureBivalent(IntPtr ptr);

		internal abstract bool IsPureTrivalent(IntPtr ptr);

		internal abstract bool IsPureTriangle(IntPtr ptr);

		internal abstract bool IsPureQuad(IntPtr ptr);


	}
}
