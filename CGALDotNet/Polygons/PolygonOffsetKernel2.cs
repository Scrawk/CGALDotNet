using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonOffsetKernel2
    {
        internal abstract string Name { get; }

        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract int PolygonBufferSize(IntPtr ptr);

        internal abstract void ClearPolygonBuffer(IntPtr ptr);

        internal abstract IntPtr GetBufferedPolygon(IntPtr ptr, int index);

        internal abstract void CreateInteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);

        internal abstract void CreateExteriorOffset(IntPtr ptr, IntPtr polyPtr, double offset);
    }
}
