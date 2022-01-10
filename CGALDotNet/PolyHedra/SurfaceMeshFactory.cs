using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
	public static class SurfaceMeshFactory<K> where K : CGALKernel, new()
	{
		private static List<Point3d> points = new List<Point3d>();
		private static List<int> indices = new List<int>();

		public static SurfaceMesh3<K> CreateCube(double scale = 1)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateCube(points, indices, scale);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return mesh;
		}

		public static SurfaceMesh3<K> CreatePlane(PlaneParams param)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreatePlane(points, indices, param);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return mesh;
		}

		public static SurfaceMesh3<K> CreateTorus(TorusParams param)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateTorus(points, indices, param);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return mesh;
		}

		public static SurfaceMesh3<K> CreateUVSphere(UVSphereParams param)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateUVSphere(points, indices, param);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return mesh;
		}
		public static SurfaceMesh3<K> CreateNormalizedCube(NormalizedCubeParams param)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateNormalizedCube(points, indices, param);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return mesh;
		}

		public static SurfaceMesh3<K> CreateIcosahedron(double scale = 1)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateIcosahedron(points, indices, scale);

			var mesh = new SurfaceMesh3<K>();
			mesh.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return mesh;
		}
	}
}
