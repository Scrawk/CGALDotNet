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

		public static Dictionary<string, Polyhedron3<K>> CreateAll(bool allowPolygons = false)
        {
			var meshes = new Dictionary<string, Polyhedron3<K>>();

			meshes.Add("Cube", CreateCube(1, allowPolygons));
			meshes.Add("Plane", CreatePlane(allowPolygons));
			meshes.Add("Torus", CreateTorus(allowPolygons));
			meshes.Add("Cone", CreateCone(allowPolygons));
			meshes.Add("Cylinder", CreateCylinder(allowPolygons));
			meshes.Add("UVSphere", CreateUVSphere(allowPolygons));
			meshes.Add("NormalizedCube", CreateNormalizedCube(allowPolygons));
			meshes.Add("Icosahedron", CreateIcosahedron());
			meshes.Add("Tetrahedron", CreateTetrahedron());
			meshes.Add("Octahedron", CreateOctahedron());
			meshes.Add("Dodecahedron", CreateDodecahedron());

			return meshes;
		}

		public static Polyhedron3<K> CreateCube( double scale = 1, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateCube(points, triangles, quads, scale);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateCube(points, triangles, null, scale);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);
			}

			return mesh;
		}

		public static Polyhedron3<K> CreateCube(Box3d box, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateCube(points, triangles, quads, box);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateCube(points, triangles, null, box);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);
			}

			return mesh;
		}

		public static Polyhedron3<K> CreatePlane(bool allowPolygons = false)
        {
			return CreatePlane(PlaneParams.Default, allowPolygons);
        }

		public static Polyhedron3<K> CreatePlane(PlaneParams param, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
            {
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreatePlane(points, triangles, quads, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
            {
				points.Clear();
				triangles.Clear();
				MeshFactory.CreatePlane(points, triangles, null, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);
			}

			return mesh;
		}

		public static Polyhedron3<K> CreateTorus(bool allowPolygons = false)
        {
			return CreateTorus(TorusParams.Default, allowPolygons);
        }

		public static Polyhedron3<K> CreateTorus(TorusParams param, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateTorus(points, triangles, quads, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateTorus(points, triangles, null, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);
			}

			return mesh;
		}

		public static Polyhedron3<K> CreateCone(bool allowPolygons = false)
		{
			return CreateCone(CylinderParams.Default, allowPolygons);
		}

		public static Polyhedron3<K> CreateCone(CylinderParams param, bool allowPolygons = false)
        {
			param.radiusTop = 0;
			return CreateCylinder(param, allowPolygons);
		}

		public static Polyhedron3<K> CreateCylinder(bool allowPolygons = false)
        {
			return CreateCylinder(CylinderParams.Default, allowPolygons);
        }

		public static Polyhedron3<K> CreateCylinder(CylinderParams param, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateCylinder(points, triangles, quads, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateCylinder(points, triangles, null, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);
			}

			return mesh;
		}

		public static Polyhedron3<K> CreateUVSphere(bool allowPolygons = false)
        {
			return CreateUVSphere(UVSphereParams.Default, allowPolygons);
        }

		public static Polyhedron3<K> CreateUVSphere(UVSphereParams param, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateUVSphere(points, triangles, quads, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
            {
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateUVSphere(points, triangles, null, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);
			}

			return mesh;
		}

		public static Polyhedron3<K> CreateNormalizedCube(bool allowPolygons = false)
        {
			return CreateNormalizedCube(NormalizedCubeParams.Default, allowPolygons);
        }

		public static Polyhedron3<K> CreateNormalizedCube(NormalizedCubeParams param, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				points.Clear();
				triangles.Clear();
				quads.Clear();
				MeshFactory.CreateNormalizedCube(points, triangles, quads, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), quads.ToArray());
			}
			else
			{
				points.Clear();
				triangles.Clear();
				MeshFactory.CreateNormalizedCube(points, triangles, null, param);
				mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);
			}

			return mesh;
		}

		public static Polyhedron3<K> CreateTetrahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateTetrahedron(points, triangles, scale);

			var mesh = new Polyhedron3<K>();
			mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);

			return mesh;
		}

		public static Polyhedron3<K> CreateIcosahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateIcosahedron(points, triangles, scale);

			var mesh = new Polyhedron3<K>();
			mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);

			return mesh;
		}

		public static Polyhedron3<K> CreateOctahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateOctahedron(points, triangles, scale);

			var mesh = new Polyhedron3<K>();
			mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);

			return mesh;
		}

		public static Polyhedron3<K> CreateDodecahedron(double scale = 1)
		{
			points.Clear();
			triangles.Clear();
			MeshFactory.CreateDodecahedron(points, triangles, scale);

			var mesh = new Polyhedron3<K>();
			mesh.CreateMesh(points.ToArray(), triangles.ToArray(), null);

			return mesh;
		}
	}
}
