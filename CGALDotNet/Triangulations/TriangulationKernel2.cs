using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Triangulations
{
    internal abstract class TriangulationKernel2 : BaseTriangulationKernel2 
    {
        internal abstract bool MoveVertex(IntPtr ptr, int index, Point2d point, bool ifNoCollision, out TriVertex2 vertex);

    }
}
