using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
	internal abstract class MeshProcessingLocateKernel : CGALObjectKernel
	{
		internal abstract IntPtr Create();

		internal abstract void Release(IntPtr ptr);

		//Polyhedron

		internal abstract Point3d RandomLocationOnMesh_PH(IntPtr ptr);

		internal abstract MeshHitResult LocateFaceRay_PH(IntPtr ptr, Ray3d ray);

		internal abstract MeshHitResult LocateFacePoint_PH(IntPtr ptr, Point3d point);

		//SurfaceMesh

		internal abstract Point3d RandomLocationOnMesh_SM(IntPtr ptr);

		internal abstract MeshHitResult LocateFaceRay_SM(IntPtr ptr, Ray3d ray);

		internal abstract MeshHitResult LocateFacePoint_SM(IntPtr ptr, Point3d point);

	}
}
