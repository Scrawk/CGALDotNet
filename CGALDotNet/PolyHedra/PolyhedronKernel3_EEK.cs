using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CGALDotNet.PolyHedra
{
	internal sealed class PolyhedronKernel3_EEK : PolyhedronKernel3
	{

		internal static readonly PolyhedronKernel3 Instance = new PolyhedronKernel3_EEK();

		internal override string Name => "EEK";

		internal override IntPtr Create()
        {
			return Polyhedron3_EEK_Create();
		}

		internal override void Release(IntPtr ptr)
        {
			Polyhedron3_EEK_Release(ptr);
		}

		internal override void Clear(IntPtr ptr)
        {
			Polyhedron3_EEK_Clear(ptr);
		}

		internal override int VertexCount(IntPtr ptr)
        {
			return Polyhedron3_EEK_VertexCount(ptr);
		}

		internal override int FaceCount(IntPtr ptr)
        {
			return Polyhedron3_EEK_FaceCount(ptr);
		}

		internal override int HalfEdgeCount(IntPtr ptr)
        {
			return Polyhedron3_EEK_HalfEdgeCount(ptr);
		}

		internal override int BorderEdgeCount(IntPtr ptr)
        {
			return Polyhedron3_EEK_BorderEdgeCount(ptr);
		}

		internal override int BorderHalfEdgeCount(IntPtr ptr)
        {
			return Polyhedron3_EEK_BorderHalfEdgeCount(ptr);
		}

		internal override bool IsClosed(IntPtr ptr)
		{
			return Polyhedron3_EEK_IsClosed(ptr);
		}

		internal override bool IsPureBivalent(IntPtr ptr)
        {
			return Polyhedron3_EEK_IsPureBivalent(ptr);
		}

		internal override bool IsPureTrivalent(IntPtr ptr)
        {
			return Polyhedron3_EEK_IsPureTrivalent(ptr);
		}

		internal override bool IsPureTriangle(IntPtr ptr)
        {
			return Polyhedron3_EEK_IsPureTriangle(ptr);
		}

		internal override bool IsPureQuad(IntPtr ptr)
        {
			return Polyhedron3_EEK_IsPureQuad(ptr);
		}

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  IntPtr Polyhedron3_EEK_Create();

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  void Polyhedron3_EEK_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  void Polyhedron3_EEK_Clear(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_VertexCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern  int Polyhedron3_EEK_FaceCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_HalfEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_BorderEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int Polyhedron3_EEK_BorderHalfEdgeCount(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsClosed(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsPureBivalent(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsPureTrivalent(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsPureTriangle(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool Polyhedron3_EEK_IsPureQuad(IntPtr ptr);
	}
}
