using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Meshing
{
    public abstract class SurfaceMesherKernel3
    {
        protected const string DLL_NAME = "CGALWrapper.dll";

        protected const CallingConvention CDECL = CallingConvention.Cdecl;

        internal abstract string Name { get; }

        internal abstract int VertexCount();

        internal abstract int TriangleCount();

        internal abstract void ClearMesh();

        internal abstract Point3d GetPoint(int i);

        internal abstract TriangleIndex GetTriangle(int i);

        internal abstract void Generate();
    }
}
