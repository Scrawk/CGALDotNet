using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    internal abstract class ConstrainedTriangulationKernel2 : BaseTriangulationKernel2
    {
        internal abstract int ConstrainedEdgesCount(IntPtr ptr);

        internal abstract void InsertConstraint(IntPtr ptr, Segment2d segment);

    }
}
