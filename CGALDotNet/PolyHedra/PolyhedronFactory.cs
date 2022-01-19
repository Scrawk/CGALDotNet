using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
    public static class PolyhedronFactory<K> where K : CGALKernel, new()
    {
		private static List<Point3d> points = new List<Point3d>();
		private static List<int> triangles = new List<int>();
		private static List<int> quads = new List<int>();

		public static Polyhedron3<K> CreateCube( double scale = 1, bool allowQuads = false)
		{
			var poly = new Polyhedron3<K>();

			if (allowQuads)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateCube(points, triangles, quads, scale);
				poly.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateCube(points, triangles, null, scale);
				poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());
			}

			return poly;
		}

		public static Polyhedron3<K> CreateCube(Box3d box, bool allowQuads = false)
		{
			var poly = new Polyhedron3<K>();

			if (allowQuads)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateCube(points, triangles, quads, box);
				poly.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateCube(points, triangles, null, box);
				poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());
			}

			return poly;
		}

		public static Polyhedron3<K> CreatePlane(bool allowQuads = false)
        {
			return CreatePlane(PlaneParams.Default, allowQuads);
        }

		public static Polyhedron3<K> CreatePlane(PlaneParams param, bool allowQuads = false)
		{
			var poly = new Polyhedron3<K>();

			if (allowQuads)
            {
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreatePlane(points, triangles, quads, param);
				poly.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
            {
				points.Clear();
				triangles.Clear();
				MeshFactory.CreatePlane(points, triangles, null, param);
				poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());
			}

			return poly;
		}

		public static Polyhedron3<K> CreateTorus(bool allowQuads = false)
        {
			return CreateTorus(TorusParams.Default, allowQuads);
        }

		public static Polyhedron3<K> CreateTorus(TorusParams param, bool allowQuads = false)
		{
			var poly = new Polyhedron3<K>();

			if (allowQuads)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateTorus(points, triangles, quads, param);
				poly.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateTorus(points, triangles, null, param);
				poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());
			}

			return poly;
		}

		public static Polyhedron3<K> CreateCone(bool allowQuads = false)
		{
			return CreateCone(CylinderParams.Default, allowQuads);
		}

		public static Polyhedron3<K> CreateCone(CylinderParams param, bool allowQuads = false)
        {
			param.radiusTop = 0;
			return CreateCylinder(param, allowQuads);
		}

		public static Polyhedron3<K> CreateCylinder(bool allowQuads = false)
        {
			return CreateCylinder(CylinderParams.Default, allowQuads);
        }

		public static Polyhedron3<K> CreateCylinder(CylinderParams param, bool allowQuads = false)
		{
			var poly = new Polyhedron3<K>();

			if (allowQuads)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateCylinder(points, triangles, quads, param);
				poly.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateCylinder(points, triangles, null, param);
				poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());
			}

			return poly;
		}

		public static Polyhedron3<K> CreateUVSphere(bool allowQuads = false)
        {
			return CreateUVSphere(UVSphereParams.Default, allowQuads);
        }

		public static Polyhedron3<K> CreateUVSphere(UVSphereParams param, bool allowQuads = false)
		{
			var poly = new Polyhedron3<K>();

			if (allowQuads)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateUVSphere(points, triangles, quads, param);
				poly.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
            {
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateUVSphere(points, triangles, null, param);
				poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());
			}

			return poly;
		}

		public static Polyhedron3<K> CreateNormalizedCube(bool allowQuads = false)
        {
			return CreateNormalizedCube(NormalizedCubeParams.Default, allowQuads);
        }

		public static Polyhedron3<K> CreateNormalizedCube(NormalizedCubeParams param, bool allowQuads = false)
		{
			var poly = new Polyhedron3<K>();

			if (allowQuads)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateNormalizedCube(points, triangles, quads, param);
				poly.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateNormalizedCube(points, triangles, null, param);
				poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());
			}

			return poly;
		}

		public static Polyhedron3<K> CreateIcosahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateIcosahedron(points, triangles, scale);

			var poly = new Polyhedron3<K>();
			poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return poly;
		}

		public static Polyhedron3<K> CreateTetrahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateTetrahedron(points, triangles, scale);

			var poly = new Polyhedron3<K>();
			poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return poly;
		}

		public static Polyhedron3<K> CreateOctahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateOctahedron(points, triangles, scale);

			var poly = new Polyhedron3<K>();
			poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return poly;
		}

		public static Polyhedron3<K> CreateDodecahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateDodecahedron(points, triangles, scale);

			var poly = new Polyhedron3<K>();
			poly.CreateTriangleMesh(points.ToArray(), triangles.ToArray());

			return poly;
		}
	}
}
