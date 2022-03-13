using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Triangulations
{
    internal abstract class DelaunayTriangulationKernel3 : BaseTriangulationKernel3
    {
        internal abstract bool Move(IntPtr ptr, int index, Point3d point, bool ifNoCollision);

        internal abstract int NearestVertex(IntPtr ptr, Point3d point);

        internal abstract int NearestVertexInCell(IntPtr ptr, int index, Point3d point);

        internal abstract bool RemoveVertex(IntPtr ptr, int index);
    }
}
