using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonBooleanKernel2 : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void ClearBuffer(IntPtr ptr);

        internal abstract IntPtr CopyBufferItem(IntPtr ptr, int index);

        internal abstract bool DoIntersect(IntPtr ptr, Polygon2 poly1, Polygon2 poly2);

        internal abstract bool DoIntersect(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2);

        internal abstract bool DoIntersect(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2);

        internal abstract bool Join(IntPtr ptr, Polygon2 poly1, Polygon2 poly2, out IntPtr result);

        internal abstract bool Join(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2, out IntPtr result);

        internal abstract bool Join(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2, out IntPtr result);

        internal abstract int Intersect(IntPtr ptr, Polygon2 poly, Polygon2 poly2);

        internal abstract int Intersect(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2);

        internal abstract int Intersect(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2);

        internal abstract int Difference(IntPtr ptr, Polygon2 poly1, Polygon2 poly2);

        internal abstract int Difference(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2);

        internal abstract int Difference(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2);

        internal abstract int SymmetricDifference(IntPtr ptr, Polygon2 poly1, Polygon2 poly2);

        internal abstract int SymmetricDifference(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2);

        internal abstract int SymmetricDifference(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2);

        internal abstract int Complement(IntPtr ptr, PolygonWithHoles2 poly);
    }
}
