using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Processing;

namespace CGALDotNet.Polyhedra
{
    public static class PolyhedronFactory<K> where K : CGALKernel, new()
    {
		private static IndexList triangleList = IndexList.CreateTriangleIndexList();
		private static IndexList polygonList = IndexList.CreatePolygonIndexList();

		public static Dictionary<string, Polyhedron3<K>> CreateAll(bool allowPolygons = false)
        {
			var meshes = new Dictionary<string, Polyhedron3<K>>();

			meshes.Add("Cube", CreateCube(1, allowPolygons));
			meshes.Add("Plane", CreatePlane(allowPolygons));
			meshes.Add("Torus", CreateTorus(allowPolygons));
			meshes.Add("Cone", CreateCone(allowPolygons));
			meshes.Add("Cylinder", CreateCylinder(allowPolygons));
			meshes.Add("Capsule", CreateCapsule(allowPolygons));
			meshes.Add("UVSphere", CreateUVSphere(allowPolygons));
			meshes.Add("NormalizedCube", CreateNormalizedCube(allowPolygons));
			meshes.Add("Icosahedron", CreateIcosahedron());
			meshes.Add("Tetrahedron", CreateTetrahedron());
			meshes.Add("Octahedron", CreateOctahedron());
			meshes.Add("Dodecahedron", CreateDodecahedron(1, allowPolygons));

			return meshes;
		}

		public static Polyhedron3<K> CreateCube( double scale = 1, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				polygonList.Clear();
				MeshFactory.CreateCube(polygonList, scale);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
			{
				triangleList.Clear();
				MeshFactory.CreateCube(triangleList, scale);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
			}

			return mesh;
		}

		public static Polyhedron3<K> CreateCube(Box3d box, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				polygonList.Clear();
				MeshFactory.CreateCube(polygonList, box);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
			{
				triangleList.Clear();
				MeshFactory.CreateCube(triangleList, box);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
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
				polygonList.Clear();
				MeshFactory.CreatePlane(polygonList, param);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
            {
				triangleList.Clear();
				MeshFactory.CreatePlane(triangleList, param);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
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
				polygonList.Clear();
				MeshFactory.CreateTorus(polygonList, param);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
			{
				triangleList.Clear();
				MeshFactory.CreateTorus(triangleList, param);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
			}

			WeldVertices(mesh);

			return mesh;
		}

		public static Polyhedron3<K> CreateCone(bool allowPolygons = false)
		{
			return CreateCone(ConeParams.Default, allowPolygons);
		}

		public static Polyhedron3<K> CreateCone(ConeParams param, bool allowPolygons = false)
        {
			return CreateCylinder(param.AsCylinderParam(), allowPolygons);
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
				polygonList.Clear();
				MeshFactory.CreateCylinder(polygonList, param);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
			{
				triangleList.Clear();
				MeshFactory.CreateCylinder(triangleList, param);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
			}

			WeldVertices(mesh);

			return mesh;
		}

		public static Polyhedron3<K> CreateCapsule(bool allowPolygons = false)
        {
			return CreateCapsule(CapsuleParams.Default, allowPolygons);
        }

		public static Polyhedron3<K> CreateCapsule(CapsuleParams param, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				polygonList.Clear();
				MeshFactory.CreateCapsule(polygonList, param);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
			{
				triangleList.Clear();
				MeshFactory.CreateCapsule(triangleList, param);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
			}

			WeldVertices(mesh);

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
				polygonList.Clear();
				MeshFactory.CreateUVSphere(polygonList, param);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
            {
				triangleList.Clear();
				MeshFactory.CreateUVSphere(triangleList, param);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
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
				polygonList.Clear();
				MeshFactory.CreateNormalizedCube(polygonList, param);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
			{
				triangleList.Clear();
				MeshFactory.CreateNormalizedCube(triangleList, param);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
			}

			WeldVertices(mesh);

			return mesh;
		}

		public static Polyhedron3<K> CreateTetrahedron(double scale = 1)
		{
			triangleList.Clear();
			MeshFactory.CreateTetrahedron(triangleList, scale);

			var mesh = new Polyhedron3<K>();
			mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());

			return mesh;
		}

		public static Polyhedron3<K> CreateIcosahedron(double scale = 1)
		{
			triangleList.Clear();
			MeshFactory.CreateIcosahedron(triangleList, scale);

			var mesh = new Polyhedron3<K>();
			mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());

			return mesh;
		}

		public static Polyhedron3<K> CreateOctahedron(double scale = 1)
		{
			triangleList.Clear();
			MeshFactory.CreateOctahedron(triangleList, scale);

			var mesh = new Polyhedron3<K>();
			mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());

			return mesh;
		}

		public static Polyhedron3<K> CreateDodecahedron(double scale = 1, bool allowPolygons = false)
		{
			var mesh = new Polyhedron3<K>();

			if (allowPolygons)
			{
				polygonList.Clear();
				MeshFactory.CreateDodecahedron(polygonList, scale);
				var indices = polygonList.ToIndices();
				var points = polygonList.points.ToArray();
				mesh.CreatePolygonalMesh(points, points.Length, indices);
			}
			else
			{
				triangleList.Clear();
				MeshFactory.CreateDodecahedron(triangleList, scale);
				mesh.CreateMesh(triangleList.points.ToArray(), triangleList.triangles.ToArray());
			}

			return mesh;
		}

		private static void WeldVertices(Polyhedron3<K> mesh)
        {
			var repair = MeshProcessingRepair<K>.Instance;
			repair.RepairPolygonSoup(mesh);
		}
	}
}
