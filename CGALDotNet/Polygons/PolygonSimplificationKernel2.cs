using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonSimplificationKernel2 : CGALObjectKernel
    {

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract IntPtr SimplifyPolygon(IntPtr polyPtr, PolygonSimplificationParams param);

        internal abstract IntPtr SimplifyPolygonWithHoles_All(IntPtr polyPtr, PolygonSimplificationParams param);

        internal abstract IntPtr SimplifyPolygonWithHoles_Boundary(IntPtr polyPtr, PolygonSimplificationParams param);

        internal abstract IntPtr SimplifyPolygonWithHoles_Holes(IntPtr polyPtr, PolygonSimplificationParams param);

        internal abstract IntPtr SimplifyPolygonWithHoles_Hole(IntPtr polyPtr, PolygonSimplificationParams param, int index);

    }
}
