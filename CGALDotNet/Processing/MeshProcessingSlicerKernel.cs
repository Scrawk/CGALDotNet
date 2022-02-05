using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Processing
{
    internal abstract class MeshProcessingSlicerKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        internal abstract void GetLines(IntPtr slicerPtr, IntPtr[] lines, int count);

        //Polyhedron

        internal abstract int Slice_PH(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree);

        internal abstract int IncrementalSlice_PH(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment);

        //SUrfaceMesh

        internal abstract int Slice_SM(IntPtr slicerPtr, IntPtr meshPtr, Plane3d plane, bool useTree);

        internal abstract int IncrementalSlice_SM(IntPtr slicerPtr, IntPtr meshPtr, Point3d start, Point3d end, double increment);

    }
}
