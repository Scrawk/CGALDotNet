using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Processing
{
    internal abstract class MeshProcessingBooleanKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

        //Polyhedron 

        internal abstract bool Union_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        internal abstract bool Difference_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        internal abstract bool Intersection_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        internal abstract bool Clip_PH(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        internal abstract bool PlaneClip_PH(IntPtr meshPtr1, Plane3d plane, out IntPtr resultPtr);

        internal abstract bool BoxClip_PH(IntPtr meshPtr1, Box3d box, out IntPtr resultPtr);

        //Surface Mesh

        internal abstract bool Union_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        internal abstract bool Difference_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        internal abstract bool Intersection_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        internal abstract bool Clip_SM(IntPtr meshPtr1, IntPtr meshPtr2, out IntPtr resultPtr);

        internal abstract bool PlaneClip_SM(IntPtr meshPtr1, Plane3d plane, out IntPtr resultPtr);

        internal abstract bool BoxClip_SM(IntPtr meshPtr1, Box3d box, out IntPtr resultPtr);
    }
}
