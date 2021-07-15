using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonBooleanKernel2
    {
        internal PolygonBooleanKernel2()
        {

        }

        internal abstract string Name { get; }

        internal abstract void ClearBuffer();

        internal abstract IntPtr CopyBufferItem(int index);

        internal abstract bool DoIntersect(Polygon2 poly1, Polygon2 poly2);

        internal abstract bool DoIntersect(Polygon2 poly1, PolygonWithHoles2 poly2);

        internal abstract bool DoIntersect(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2);

        internal abstract bool Join(Polygon2 poly1, Polygon2 poly2, out IntPtr result);

        internal abstract bool Join(Polygon2 poly1, PolygonWithHoles2 poly2, out IntPtr result);

        internal abstract bool Join(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2, out IntPtr result);

        internal abstract int Intersect(Polygon2 poly, Polygon2 poly2);

        internal abstract int Intersect(Polygon2 poly1, PolygonWithHoles2 poly2);

        internal abstract int Intersect(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2);

        internal abstract int Difference(Polygon2 poly1, Polygon2 poly2);

        internal abstract int Difference(Polygon2 poly1, PolygonWithHoles2 poly2);

        internal abstract int Difference(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2);

        internal abstract int SymmetricDifference(Polygon2 poly1, Polygon2 poly2);

        internal abstract int SymmetricDifference(Polygon2 poly1, PolygonWithHoles2 poly2);

        internal abstract int SymmetricDifference(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2);

        internal abstract int Complement(PolygonWithHoles2 poly);
    }
}
