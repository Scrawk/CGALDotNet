using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Meshing
{
    internal abstract class SurfaceMesherKernel3 : FuncKernel
    {
        internal abstract int VertexCount();

        internal abstract int TriangleCount();

        internal abstract void ClearMesh();

        internal abstract Point3d GetPoint(int i);

        internal abstract TriangleIndex GetTriangle(int i);

        internal abstract void Generate();
    }
}
