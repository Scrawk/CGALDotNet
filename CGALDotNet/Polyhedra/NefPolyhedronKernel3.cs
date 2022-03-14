using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
    internal abstract class NefPolyhedronKernel3 : CGALObjectKernel
    {
		internal abstract IntPtr CreateFromSpace(NEF_CONTENT space);

		internal abstract IntPtr CreateFromPlane(Plane3d plane, NEF_BOUNDARY boundary);

		internal abstract IntPtr CreateFromPolyhedron(IntPtr ptr);

		internal abstract void Release(IntPtr ptr);

		internal abstract void Clear(IntPtr ptr, NEF_CONTENT space);

		internal abstract bool IsEmpty(IntPtr ptr);

		internal abstract bool IsSimple(IntPtr ptr);

		internal abstract bool IsSpace(IntPtr ptr);

		internal abstract bool IsValid(IntPtr ptr);

		internal abstract int EdgeCount(IntPtr ptr);

		internal abstract int FacetCount(IntPtr ptr);

		internal abstract int HalfEdgeCount(IntPtr ptr);

		internal abstract int HalfFacetCount(IntPtr ptr);

		internal abstract int VertexCount(IntPtr ptr);

		internal abstract int VolumeCount(IntPtr ptr);

		internal abstract IntPtr Intersection(IntPtr ptr1, IntPtr ptr2);

		internal abstract IntPtr Join(IntPtr ptr1, IntPtr ptr2);

		internal abstract IntPtr Difference(IntPtr ptr1, IntPtr ptr2);

		internal abstract IntPtr SymmetricDifference(IntPtr ptr1, IntPtr ptr2);

		internal abstract IntPtr Complement(IntPtr ptr);

		internal abstract IntPtr Interior(IntPtr ptr);

		internal abstract IntPtr Boundary(IntPtr ptr);

		internal abstract IntPtr Closure(IntPtr ptr);

		internal abstract IntPtr Regularization(IntPtr ptr);

		internal abstract IntPtr MinkowskiSum(IntPtr ptr1, IntPtr ptr2);

		internal abstract IntPtr ConvertToPolyhedron(IntPtr ptr);

		internal abstract IntPtr ConvertToSurfaceMesh(IntPtr ptr);

		internal abstract void ConvexDecomposition(IntPtr ptr);

		internal abstract void GetVolumes(IntPtr ptr, IntPtr[] volumes, int count);

	}
}
