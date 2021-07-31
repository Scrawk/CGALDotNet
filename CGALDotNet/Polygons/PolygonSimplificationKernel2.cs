using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonSimplificationKernel2
    {

        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr SimplifyPolygon(IntPtr polyPtr, double theshold);

        internal abstract IntPtr SimplifyPolygonWithHoles(IntPtr polyPtr, double theshold);

    }
}
