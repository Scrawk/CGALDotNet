using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
    public static class PolyhedronFactory<K> where K : CGALKernel, new()
    {
		private static List<Point3d> points = new List<Point3d>();
		private static List<int> indices = new List<int>();

		public static Polyhedron3<K> CreateCube( double scale = 1)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateCube(points, indices, scale);

			var poly = new Polyhedron3<K>();
			poly.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return poly;
		}

		public static Polyhedron3<K> CreateUVSphere(int meridians, int parallels, double scale = 1)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateUVSphere(points, indices, meridians, parallels, scale);

			var poly = new Polyhedron3<K>();
			poly.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return poly;
		}
		public static Polyhedron3<K> CreateNormalizedCube(int divisions, double scale = 1)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateNormalizedCube(points, indices, divisions, scale);

			var poly = new Polyhedron3<K>();
			poly.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return poly;
		}

		public static Polyhedron3<K> CreateIcosahedron(double scale = 1)
		{
			points.Clear();
			indices.Clear();
			MeshFactory.CreateIcosahedron(points, indices, scale);

			var poly = new Polyhedron3<K>();
			poly.CreateTriangleMesh(points.ToArray(), indices.ToArray());

			return poly;
		}
	}
}
