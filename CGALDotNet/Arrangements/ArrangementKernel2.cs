using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Arrangements
{
    internal abstract class ArrangementKernel2
    {
        internal ArrangementKernel2()
        {

        }

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract IntPtr CreateFromSegments(Segment2d[] segment, int startIndex, int count);

        internal abstract void Release(IntPtr ptr);

        internal abstract int ElementCount(IntPtr ptr, ARRANGEMENT2_ELEMENT element);
    }
}
