using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{
    internal abstract class SurfaceMeshKernel3
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void Clear(IntPtr ptr);

        internal abstract bool IsValid(IntPtr ptr);

        internal abstract int VertexCount(IntPtr ptr);

        internal abstract int HalfEdgeCount(IntPtr ptr);

        internal abstract int EdgeCount(IntPtr ptr);

        internal abstract int FaceCount(IntPtr ptr);

        internal abstract int AddVertex(IntPtr ptr, Point3d point);

        internal abstract int AddEdge(IntPtr ptr, int v0, int v1);

        internal abstract int AddFace(IntPtr ptr, int v0, int v1, int v2);

    }
}
