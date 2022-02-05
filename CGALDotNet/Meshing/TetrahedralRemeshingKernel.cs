using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Meshing
{
    internal abstract class TetrahedralRemeshingKernel : CGALObjectKernel
    {
		internal abstract IntPtr Create();

		internal abstract void Release(IntPtr ptr);

		internal abstract void GetPoints(IntPtr ptr, Point3d[] points, int count);

		internal abstract int Remesh(IntPtr ptr, double targetLength, int iterations, Point3d[] points, int count);
	}
}
