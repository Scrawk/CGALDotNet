using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
	public static class SurfaceMeshFactory<K> where K : CGALKernel, new()
	{
		private static List<Point3d> points = new List<Point3d>();
		private static List<int> triangles = new List<int>();

		public static SurfaceMesh3<K> CreateCube(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateCube(points, triangles, null, scale);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return mesh;
		}

		public static SurfaceMesh3<K> CreatePlane(PlaneParams param)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreatePlane(points, triangles, null, param);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return mesh;
		}

		public static SurfaceMesh3<K> CreateTorus(TorusParams param)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateTorus(points, triangles, null, param);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return mesh;
		}

		public static SurfaceMesh3<K> CreateUVSphere(UVSphereParams param)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateUVSphere(points, triangles, null, param);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return mesh;
		}
		public static SurfaceMesh3<K> CreateNormalizedCube(NormalizedCubeParams param)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateNormalizedCube(points, triangles, null, param);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return mesh;
		}

		public static SurfaceMesh3<K> CreateIcosahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateIcosahedron(points, triangles, scale);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return mesh;
		}
	}
}
