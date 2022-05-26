using System;
using System.Collections.Generic;
using System.Linq;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
	public struct UVSphereParams
    {
		public int meridians;
		public int parallels;
		public double radius;

		public static UVSphereParams Default
        {
			get
            {
				var param = new UVSphereParams();
				param.parallels = 16;
				param.meridians = 16;
				param.radius = 0.5;
				return param;
            }
        }
	}

	public struct NormalizedCubeParams
	{

		public int divisions;
		public double radius;

		public static NormalizedCubeParams Default
		{
			get
			{
				var param = new NormalizedCubeParams();
				param.divisions = 8;
				param.radius = 0.5;
				return param;
			}
		}
	}

	public struct PlaneParams
	{
		public double width;
		public double height;
		public int divisionsX;
		public int divisionsZ;

		public static PlaneParams Default
		{
			get
			{
				var param = new PlaneParams();
				param.width = 1;
				param.height = 1;
				param.divisionsX = 4;
				param.divisionsZ = 4;
				return param;
			}
		}
	}

	public struct TorusParams
	{
		public int radialDivisions;
		public int tubularDivisions;
		public double radius;
		public double tube;
		public double arc;

		public static TorusParams Default
		{
			get
			{
				var param = new TorusParams();
				param.radialDivisions = 16;
				param.tubularDivisions = 16;
				param.radius = 0.5;
				param.tube = 0.2;
				param.arc = Math.PI * 2;
				return param;
			}
		}
	}

	public struct CylinderParams
	{
		public double radiusTop;
		public double radiusBottom;
		public double height;
		public int radialDivisions;
		public int heightDivisions;

		public static CylinderParams Default
		{
			get
			{
				var param = new CylinderParams();
				param.radiusTop = 0.5;
				param.radiusBottom = 0.5;
				param.height = 1;
				param.radialDivisions = 8;
				param.heightDivisions = 4;
				return param;
			}
		}
	}

	public struct ConeParams
	{
		public double radiusBottom;
		public double height;
		public int radialDivisions;
		public int heightDivisions;

		public static ConeParams Default
		{
			get
			{
				var param = new ConeParams();
				param.radiusBottom = 0.5;
				param.height = 1;
				param.radialDivisions = 8;
				param.heightDivisions = 4;
				return param;
			}
		}
		internal CylinderParams AsCylinderParam()
		{
			var param = new CylinderParams();
			param.radiusTop = 0;
			param.radiusBottom = this.radiusBottom;
			param.height = this.height;
			param.radialDivisions = this.radialDivisions;
			param.heightDivisions = this.heightDivisions;
			return param;

		}
	}

	public struct CapsuleParams
	{
		public int meridians;
		public int parallels;
		public double height;
		public double capHeight;
		public double radius;

		public static CapsuleParams Default
		{
			get
			{
				var param = new CapsuleParams();
				param.parallels = 16;
				param.meridians = 16;
				param.radius = 0.25;
				param.height = 0.5;
				param.capHeight = 0.25;
				return param;
			}
		}
	}

	internal class IndexList
	{
		internal List<Point3d> points;
		internal List<int> triangles;
		internal List<int> quads;
		internal List<int> pentagons;
		internal List<int> hexagons;

		internal void Clear()
        {
			if( points != null) points.Clear();
			if (triangles != null) triangles.Clear();
			if (quads != null) quads.Clear();
			if (pentagons != null) pentagons.Clear();
			if (hexagons != null) hexagons.Clear();
		}

		internal PolygonalIndices ToIndices()
        {
			var indices = new PolygonalIndices();
			if (triangles != null)  indices.triangles = triangles.ToArray();
			if (quads != null) indices.quads = quads.ToArray();
			if (pentagons != null) indices.pentagons = pentagons.ToArray();
			if (hexagons != null) indices.hexagons = hexagons.ToArray();

			return indices;
		}

		internal static IndexList CreateTriangleIndexList()
		{
			var list = new IndexList();
			list.points = new List<Point3d>();
			list.triangles = new List<int>();
			return list;
		}

		internal static IndexList CreatePolygonIndexList()
		{
			var list = new IndexList();
			list.points = new List<Point3d>();
			list.triangles = new List<int>();
			list.quads = new List<int>();
			list.pentagons = new List<int>();
			list.hexagons = new List<int>();
			return list;
		}

	}

	/// <summary>
	/// https://github.com/caosdoar/spheres/blob/master/src/spheres.cpp
	/// https://github.com/mrdoob/three.js/tree/dev/src/geometries
	/// </summary>
	internal static class MeshFactory
    {

		private const double WELD_EPS = 1e-4;

		private static Point3d[] Origins =
		{
		new Point3d(-1.0, -1.0, -1.0),
		new Point3d(1.0, -1.0, -1.0),
		new Point3d(1.0, -1.0, 1.0),
		new Point3d(-1.0, -1.0, 1.0),
		new Point3d(-1.0, 1.0, -1.0),
		new Point3d(-1.0, -1.0, 1.0)
		};

		private static Point3d[] Rights =
		{
		new Point3d(2.0, 0.0, 0.0),
		new Point3d(0.0, 0.0, 2.0),
		new Point3d(-2.0, 0.0, 0.0),
		new Point3d(0.0, 0.0, -2.0),
		new Point3d(2.0, 0.0, 0.0),
		new Point3d(2.0, 0.0, 0.0)
		};

		private static Point3d[] Ups =
		{
		new Point3d(0.0, 2.0, 0.0),
		new Point3d(0.0, 2.0, 0.0),
		new Point3d(0.0, 2.0, 0.0),
		new Point3d(0.0, 2.0, 0.0),
		new Point3d(0.0, 0.0, 2.0),
		new Point3d(0.0, 0.0, -2.0)
		};

		private static void AddTriangle(this List<int> list, int item1, int item2, int item3)
        {
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
        }

		private static void AddTriangleAlt(this List<int> list, int item1, int item2, int item3)
		{
			list.Add(item3);
			list.Add(item2);
			list.Add(item1);
		}

		private static void AddQuad(this List<int> list, int item1, int item2, int item3, int item4)
		{
			list.Add(item1);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
		}

		private static void AddPentagon(this List<int> list, int item1, int item2, int item3, int item4, int item5)
		{
			list.Add(item1);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
		}

		private static void AddHexagon(this List<int> list, int item1, int item2, int item3, int item4, int item5, int item6)
		{
			list.Add(item1);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
			list.Add(item6);
		}

		internal static void CreateCube(IndexList list, double scale = 1)
        {
            list.points.Add(new Point3d(-0.5, -0.5, -0.5) * scale); //0
            list.points.Add(new Point3d(0.5, -0.5, -0.5) * scale);  //1
			list.points.Add(new Point3d(0.5, 0.5, -0.5) * scale);   //2
			list.points.Add(new Point3d(-0.5, 0.5, -0.5) * scale);  //3
			list.points.Add(new Point3d(-0.5, 0.5, 0.5) * scale);   //4
			list.points.Add(new Point3d(0.5, 0.5, 0.5) * scale);    //5
			list.points.Add(new Point3d(0.5, -0.5, 0.5) * scale);   //6
			list.points.Add(new Point3d(-0.5, -0.5, 0.5) * scale);  //7

			if (list.quads != null)
			{
				list.quads.AddQuad(3, 2, 1, 0);  //face front
				list.quads.AddQuad(2, 3, 4, 5);	//face top
				list.quads.AddQuad(1, 2, 5, 6);	//face right
				list.quads.AddQuad(0, 7, 4, 3);	//face left
				list.quads.AddQuad(5, 4, 7, 6);  //face back
				list.quads.AddQuad(1, 6, 7, 0);  //face bottom
			}
			else
			{
				list.triangles.AddTriangle(0, 3, 1); //face front
				list.triangles.AddTriangle(1, 3, 2);
				list.triangles.AddTriangle(2, 3, 4); //face top
				list.triangles.AddTriangle(2, 4, 5);
				list.triangles.AddTriangle(1, 2, 6); //face right
				list.triangles.AddTriangle(2, 5, 6);
				list.triangles.AddTriangle(0, 7, 4); //face left
				list.triangles.AddTriangle(0, 4, 3);
				list.triangles.AddTriangle(5, 4, 7); //face back
				list.triangles.AddTriangle(5, 7, 6);
				list.triangles.AddTriangle(0, 6, 7); //face bottom
				list.triangles.AddTriangle(0, 1, 6);
			}
        }

		internal static void CreateCube(IndexList list, Box3d box)
		{
			Point3d[] corners = new Point3d[8];
			box.GetCorners(corners);

			list.points.Add(corners[0]); //0
			list.points.Add(corners[1]); //1
			list.points.Add(corners[5]); //2
			list.points.Add(corners[4]); //3
			list.points.Add(corners[7]); //4
			list.points.Add(corners[6]); //5
			list.points.Add(corners[2]); //6
			list.points.Add(corners[3]); //7

			if (list.quads != null)
			{
				list.quads.AddQuad(3, 2, 1, 0);  //face front
				list.quads.AddQuad(2, 3, 4, 5);  //face top
				list.quads.AddQuad(1, 2, 5, 6);  //face right
				list.quads.AddQuad(0, 7, 4, 3);  //face left
				list.quads.AddQuad(5, 4, 7, 6);  //face back
				list.quads.AddQuad(1, 6, 7, 0);  //face bottom
			}
			else
			{
				list.triangles.AddTriangle(0, 2, 1); //face front
				list.triangles.AddTriangle(0, 3, 2);
				list.triangles.AddTriangle(2, 3, 4); //face top
				list.triangles.AddTriangle(2, 4, 5);
				list.triangles.AddTriangle(1, 2, 5); //face right
				list.triangles.AddTriangle(1, 5, 6);
				list.triangles.AddTriangle(0, 7, 4); //face left
				list.triangles.AddTriangle(0, 4, 3);
				list.triangles.AddTriangle(5, 4, 7); //face back
				list.triangles.AddTriangle(5, 7, 6);
				list.triangles.AddTriangle(0, 6, 7); //face bottom
				list.triangles.AddTriangle(0, 1, 6);
			}
		}

		internal static void CreatePlane(IndexList list, PlaneParams param)
		{
			double width_half = param.width / 2;
			double height_half = param.height / 2;

			int gridX = param.divisionsX;
			int gridY = param.divisionsZ;

			int gridX1 = gridX + 1;
			int gridY1 = gridY + 1;

			double segment_width = param.width / gridX;
			double segment_height = param.height / gridY;

			for (int iy = 0; iy < gridY1; iy++)
			{
				double y = iy * segment_height - height_half;

				for (int ix = 0; ix < gridX1; ix++)
				{
					double x = ix * segment_width - width_half;
					list.points.Add(new Point3d(x, 0, -y));
				}
			}

			for (int iy = 0; iy < gridY; iy++)
			{
				for (int ix = 0; ix < gridX; ix++)
				{

					int a = ix + gridX1 * iy;
					int b = ix + gridX1 * (iy + 1);
					int c = (ix + 1) + gridX1 * (iy + 1);
					int d = (ix + 1) + gridX1 * iy;

					if(list.quads != null)
                    {
						list.quads.AddQuad(d, c, b, a);
					}
					else
                    {
						list.triangles.AddTriangle(d, b, a);
						list.triangles.AddTriangle(d, c, b);
					}


				}
			}
		}

		internal static void CreateUVSphere(IndexList list, UVSphereParams param)
		{
			double radius = param.radius;

			list.points.Add(new Point3d(0.0, 1.0, 0.0) * radius);

			for (int j = 0; j < param.parallels - 1; ++j)
			{
				double polar = Math.PI * (j + 1) / (double)param.parallels;
				double sp = Math.Sin(polar);
				double cp = Math.Cos(polar);

				for (int i = 0; i < param.meridians; ++i)
				{
					double azimuth = 2.0 * Math.PI * i / (double)param.meridians;
					double sa = Math.Sin(azimuth);
					double ca = Math.Cos(azimuth);
					double x = sp * ca;
					double y = cp;
					double z = sp * sa;

					list.points.Add(new Point3d(x, y, z) * radius);
				}
			}

			list.points.Add(new Point3d(0.0, -1.0, 0.0) * radius);

			for (int i = 0; i < param.meridians; ++i)
			{
				int a = i + 1;
				int b = (i + 1) % param.meridians + 1;

				list.triangles.AddTriangle(0, b, a);
			}

			for (int j = 0; j < param.parallels - 2; ++j)
			{
				int aStart = j * param.meridians + 1;
				int bStart = (j + 1) * param.meridians + 1;

				for (int i = 0; i < param.meridians; ++i)
				{
					int a = aStart + i;
					int a1 = aStart + (i + 1) % param.meridians;
					int b = bStart + i;
					int b1 = bStart + (i + 1) % param.meridians;

					if(list.quads != null)
                    {
						list.quads.AddQuad(a, a1, b1, b);
                    }
					else
                    {
						list.triangles.AddTriangle(a, a1, b1);
						list.triangles.AddTriangle(a, b1, b);
					}
				}
			}

			for (int i = 0; i < param.meridians; ++i)
			{
				int a = i + param.meridians * (param.parallels - 2) + 1;
				int b = (i + 1) % param.meridians + param.meridians * (param.parallels - 2) + 1;

				list.triangles.AddTriangle(list.points.Count - 1, a, b);
			}
		}

		internal static void CreateNormalizedCube(IndexList list, NormalizedCubeParams param)
		{
			double radius = param.radius;

			double step = 1.0 / param.divisions;
			Point3d step3 = new Point3d(step, step, step);

			for (int face = 0; face < 6; ++face)
			{
				Point3d origin = Origins[face];
				Point3d right = Rights[face];
				Point3d up = Ups[face];

				for (int j = 0; j < param.divisions + 1; ++j)
				{
					Point3d j3 = new Point3d(j, j, j);

					for (int i = 0; i < param.divisions + 1; ++i)
					{
						Point3d i3 = new Point3d(i, i, i);
						Point3d p = origin + step3 * (i3 * right + j3 * up);
						Vector3d v = (Vector3d)p;

						list.points.Add(v.Normalized * radius);
					}
				}
			}

			int k = param.divisions + 1;

			for (int face = 0; face < 6; ++face)
			{
				for (int j = 0; j < param.divisions; ++j)
				{
					bool bottom = j < (param.divisions / 2);

					for (int i = 0; i < param.divisions; ++i)
					{
						bool left = i < (param.divisions / 2);

						int a = (face * k + j) * k + i;
						int b = (face * k + j) * k + i + 1;
						int c = (face * k + j + 1) * k + i;
						int d = (face * k + j + 1) * k + i + 1;

						if (list.quads != null)
						{
							list.quads.AddQuad(a, c, d, b);
						}
                        else
                        {
							list.triangles.AddTriangle(a, c, d);
							list.triangles.AddTriangle(a, d, b);
						}

					}
				}
			}

			//WeldVertices(list);
		}

		internal static void CreateTetrahedron(IndexList list, double scale = 1)
        {
			scale *= 0.5;

			// choose coordinates on the unit sphere
			double a = 1.0 / 3.0;
			double b = Math.Sqrt(8.0 / 9.0);
			double c = Math.Sqrt(2.0 / 9.0);
			double d = Math.Sqrt(2.0 / 3.0);

			list.points.Add(new Point3d(0, 1, 0) * scale);
			list.points.Add(new Point3d(-c, -a, d) * scale);
			list.points.Add(new Point3d(-c, -a, -d) * scale);
			list.points.Add(new Point3d(b, -a, 0) * scale);

			list.triangles.AddTriangle(0, 2, 1);
			list.triangles.AddTriangle(0, 3, 2);
			list.triangles.AddTriangle(0, 1, 3);
			list.triangles.AddTriangle(3, 1, 2);
		}

		internal static void CreateOctahedron(IndexList list, double scale = 1)
        {
			scale *= 0.5;

			list.points.Add(new Point3d(1, 0, 0) * scale);
			list.points.Add(new Point3d(-1, 0, 0) * scale);
			list.points.Add(new Point3d(0, 1, 0) * scale);
			list.points.Add(new Point3d(0, -1, 0) * scale);
			list.points.Add(new Point3d(0, 0, 1) * scale);
			list.points.Add(new Point3d(0, 0, -1) * scale);

			list.triangles.AddTriangle(0, 2, 4);
			list.triangles.AddTriangle(0, 4, 3);
			list.triangles.AddTriangle(0, 3, 5);
			list.triangles.AddTriangle(0, 5, 2);
			list.triangles.AddTriangle(1, 2, 5);
			list.triangles.AddTriangle(1, 5, 3);
			list.triangles.AddTriangle(1, 3, 4);
			list.triangles.AddTriangle(1, 4, 2);
		}

		internal static void CreateIcosahedron(IndexList list, double scale = 1)
		{
			scale *= 0.5;
			double t = (1.0 + Math.Sqrt(5.0)) / 2.0;

			// Vertices
			list.points.Add(new Vector3d(-1.0, t, 0.0).Normalized * scale);
			list.points.Add(new Vector3d(1.0, t, 0.0).Normalized * scale);
			list.points.Add(new Vector3d(-1.0, -t, 0.0).Normalized * scale);
			list.points.Add(new Vector3d(1.0, -t, 0.0).Normalized * scale);
			list.points.Add(new Vector3d(0.0, -1.0, t).Normalized * scale);
			list.points.Add(new Vector3d(0.0, 1.0, t).Normalized * scale);
			list.points.Add(new Vector3d(0.0, -1.0, -t).Normalized * scale);
			list.points.Add(new Vector3d(0.0, 1.0, -t).Normalized * scale);
			list.points.Add(new Vector3d(t, 0.0, -1.0).Normalized * scale);
			list.points.Add(new Vector3d(t, 0.0, 1.0).Normalized * scale);
			list.points.Add(new Vector3d(-t, 0.0, -1.0).Normalized * scale);
			list.points.Add(new Vector3d(-t, 0.0, 1.0).Normalized * scale);

			// Faces
			list.triangles.AddTriangle(0, 11, 5);
			list.triangles.AddTriangle(0, 5, 1);
			list.triangles.AddTriangle(0, 1, 7);
			list.triangles.AddTriangle(0, 7, 10);
			list.triangles.AddTriangle(0, 10, 11);
			list.triangles.AddTriangle(1, 5, 9);
			list.triangles.AddTriangle(5, 11, 4);
			list.triangles.AddTriangle(11, 10, 2);
			list.triangles.AddTriangle(10, 7, 6);
			list.triangles.AddTriangle(7, 1, 8);
			list.triangles.AddTriangle(3, 9, 4);
			list.triangles.AddTriangle(3, 4, 2);
			list.triangles.AddTriangle(3, 2, 6);
			list.triangles.AddTriangle(3, 6, 8);
			list.triangles.AddTriangle(3, 8, 9);
			list.triangles.AddTriangle(4, 9, 5);
			list.triangles.AddTriangle(2, 4, 11);
			list.triangles.AddTriangle(6, 2, 10);
			list.triangles.AddTriangle(8, 6, 7);
			list.triangles.AddTriangle(9, 8, 1);
		}

		internal static void CreateDodecahedron(IndexList list, double scale = 1)
        {
			scale *= 0.5;
			double t = (1 + Math.Sqrt(5)) / 2;
			double r = 1 / t;

			list.points.Add(new Vector3d(-1, -1, -1).Normalized * scale);//0
			list.points.Add(new Vector3d(-1, -1, 1).Normalized * scale); //1
			list.points.Add(new Vector3d(-1, 1, -1).Normalized * scale); //2
			list.points.Add(new Vector3d(-1, 1, 1).Normalized * scale);  //3
			list.points.Add(new Vector3d(1, -1, -1).Normalized * scale); //4
			list.points.Add(new Vector3d(1, -1, 1).Normalized * scale);  //5
			list.points.Add(new Vector3d(1, 1, -1).Normalized * scale);  //6
			list.points.Add(new Vector3d(1, 1, 1).Normalized * scale);   //7 
			list.points.Add(new Vector3d(0, -r, -t).Normalized * scale); //8
			list.points.Add(new Vector3d(0, -r, t).Normalized * scale);  //9 
			list.points.Add(new Vector3d(0, r, -t).Normalized * scale);  //10
			list.points.Add(new Vector3d(0, r, t).Normalized * scale );   //11
			list.points.Add(new Vector3d(-r, -t, 0).Normalized * scale); //12
			list.points.Add(new Vector3d(-r, t, 0).Normalized * scale );  //13
			list.points.Add(new Vector3d(r, -t, 0).Normalized * scale);  //14
			list.points.Add(new Vector3d(r, t, 0).Normalized * scale);   //15
			list.points.Add(new Vector3d(-t, 0, -r).Normalized * scale); //16
			list.points.Add(new Vector3d(t, 0, -r).Normalized * scale);  //17
			list.points.Add(new Vector3d(-t, 0, r).Normalized * scale);  //18
			list.points.Add(new Vector3d(t, 0, r).Normalized * scale);   //19

			if (list.pentagons != null)
			{
				list.pentagons.AddPentagon(3, 11, 7, 15, 13);
				list.pentagons.AddPentagon(15, 7, 19, 17, 6);
				list.pentagons.AddPentagon(10, 6, 17, 4, 8);
				list.pentagons.AddPentagon(2, 10, 8, 0, 16);
				list.pentagons.AddPentagon(16, 0, 12, 1, 18);
				list.pentagons.AddPentagon(6, 10, 2, 13, 15);
				list.pentagons.AddPentagon(2, 16, 18, 3, 13);
				list.pentagons.AddPentagon(11, 3, 18, 1, 9);
				list.pentagons.AddPentagon(8, 4, 14, 12, 0);
				list.pentagons.AddPentagon(11, 9, 5, 19, 7);
				list.pentagons.AddPentagon(19, 5, 14, 4, 17);
				list.pentagons.AddPentagon(9, 1, 12, 14, 5);
			}
			else
			{ 
				list.triangles.AddTriangle(3, 11, 7);
				list.triangles.AddTriangle(3, 7, 15);
				list.triangles.AddTriangle(3, 15, 13);
				list.triangles.AddTriangle(7, 19, 17);
				list.triangles.AddTriangle(7, 17, 6);
				list.triangles.AddTriangle(7, 6, 15);
				list.triangles.AddTriangle(17, 4, 8);
				list.triangles.AddTriangle(17, 8, 10);
				list.triangles.AddTriangle(17, 10, 6);
				list.triangles.AddTriangle(8, 0, 16);
				list.triangles.AddTriangle(8, 16, 2);
				list.triangles.AddTriangle(8, 2, 10);
				list.triangles.AddTriangle(0, 12, 1);
				list.triangles.AddTriangle(0, 1, 18);
				list.triangles.AddTriangle(0, 18, 16);
				list.triangles.AddTriangle(6, 10, 2);
				list.triangles.AddTriangle(6, 2, 13);
				list.triangles.AddTriangle(6, 13, 15);
				list.triangles.AddTriangle(2, 16, 18);
				list.triangles.AddTriangle(2, 18, 3);
				list.triangles.AddTriangle(2, 3, 13);
				list.triangles.AddTriangle(18, 1, 9);
				list.triangles.AddTriangle(18, 9, 11);
				list.triangles.AddTriangle(18, 11, 3);
				list.triangles.AddTriangle(4, 14, 12);
				list.triangles.AddTriangle(4, 12, 0);
				list.triangles.AddTriangle(4, 0, 8);
				list.triangles.AddTriangle(11, 9, 5);
				list.triangles.AddTriangle(11, 5, 19);
				list.triangles.AddTriangle(11, 19, 7);
				list.triangles.AddTriangle(19, 5, 14);
				list.triangles.AddTriangle(19, 14, 4);
				list.triangles.AddTriangle(19, 4, 17);
				list.triangles.AddTriangle(1, 12, 14);
				list.triangles.AddTriangle(1, 14, 5);
				list.triangles.AddTriangle(1, 5, 9);
			}

		}

		internal static void CreateTorus(IndexList list, TorusParams param)
        {

			for (int j = 0; j <= param.radialDivisions; j++)
			{
				for (int i = 0; i <= param.tubularDivisions; i++)
				{
					double u = i / (double)param.tubularDivisions * param.arc;
					double v = j / (double)param.radialDivisions * Math.PI * 2;

					var vertex = new Point3d();
					vertex.x = (param.radius + param.tube * Math.Cos(v)) * Math.Cos(u);
					vertex.z = (param.radius + param.tube * Math.Cos(v)) * Math.Sin(u);
					vertex.y = param.tube * Math.Sin(v);

					list.points.Add(vertex);
				}
			}

			for (int j = 1; j <= param.radialDivisions; j++)
			{
				for (int i = 1; i <= param.tubularDivisions; i++)
				{
					int a = (param.tubularDivisions + 1) * j + i - 1;
					int b = (param.tubularDivisions + 1) * (j - 1) + i - 1;
					int c = (param.tubularDivisions + 1) * (j - 1) + i;
					int d = (param.tubularDivisions + 1) * j + i;

					if(list.quads != null)
                    {
						list.quads.AddQuad(d, c, b, a);
                    }
					else
                    {
						list.triangles.AddTriangle(d, b, a);
						list.triangles.AddTriangle(d, c, b);
					}
				}
			}

			//WeldVertices(list);
		}

		internal static void CreateCylinder(IndexList list, CylinderParams param)
        {

			int index = 0;
			double thetaStart = 0;
			double thetaLength = Math.PI * 2;

			var indexArray = new List<List<int>>();
			double halfHeight = param.height / 2;

			for (int y = 0; y <= param.heightDivisions; y++)
			{
				var indexRow = new List<int>();

				double v = y / (double)param.heightDivisions;

				double radius = v * (param.radiusBottom - param.radiusTop) + param.radiusTop;

				for (int x = 0; x <= param.radialDivisions; x++)
				{
					double u = x / (double)param.radialDivisions;

					double theta = u * thetaLength + thetaStart;

					double sinTheta = Math.Sin(theta);
					double cosTheta = Math.Cos(theta);

					var vertex = new Point3d();
					vertex.x = radius * sinTheta;
					vertex.y = -v * param.height + halfHeight;
					vertex.z = radius * cosTheta;
					list.points.Add(vertex);

					// save index of vertex in respective row
					indexRow.Add(index++);
				}

				// now save vertices of the row in our index array
				indexArray.Add(indexRow);
			}

			for (int x = 0; x < param.radialDivisions; x++)
			{

				for (int y = 0; y < param.heightDivisions; y++)
				{
					// we use the index array to access the correct indices
					int a = indexArray[y][x];
					int b = indexArray[y + 1][x];
					int c = indexArray[y + 1][x + 1];
					int d = indexArray[y][x + 1];

					if(list.quads != null)
                    {
						list.quads.AddQuad(a, b, c, d);
                    }
					else
                    {
						list.triangles.AddTriangle(a, b, d);
						list.triangles.AddTriangle(b, c, d);
					}

				}
			}

			if (param.radiusTop > 0)
				GenerateCap(list, param, true, ref index);

			if (param.radiusBottom > 0)
				GenerateCap(list, param, false, ref index);

			//WeldVertices(list);
		}

		private static void GenerateCap(IndexList list, CylinderParams param, bool top, ref int index )
		{
			double thetaStart = 0;
			double thetaLength = Math.PI * 2;

			// save the index of the first center vertex
			int centerIndexStart = index;
			double halfHeight = param.height / 2.0;
			double radius = top ? param.radiusTop : param.radiusBottom;
			double sign = top ? 1 : -1;

			for (int x = 1; x <= param.radialDivisions; x++)
			{
				list.points.Add(new Point3d(0, halfHeight * sign, 0));
				index++;
			}

			// save the index of the last center vertex
			int centerIndexEnd = index;

			for (int x = 0; x <= param.radialDivisions; x++)
			{
				double u = x / (double)param.radialDivisions;
				double theta = u * thetaLength + thetaStart;

				double cosTheta = Math.Cos(theta);
				double sinTheta = Math.Sin(theta);

				var vertex = new Point3d();
				vertex.x = radius * sinTheta;
				vertex.y = halfHeight * sign;
				vertex.z = radius * cosTheta;
				list.points.Add(vertex);

				index++;
			}

			for (int x = 0; x < param.radialDivisions; x++)
			{
				int c = centerIndexStart + x;
				int i = centerIndexEnd + x;

				if (top)
					list.triangles.AddTriangle(i, i + 1, c);
				else
					list.triangles.AddTriangle(i + 1, i, c);
			}

		}

		internal static void CreateCapsule(IndexList list, CapsuleParams param)
		{
			double radius = param.radius;
			int halfParallels = param.parallels / 2;
			double hafHeight = param.height * 0.5;
			double capHeight = param.capHeight;

			list.points.Add(new Point3d(0.0, (capHeight + hafHeight), 0.0));

			for (int j = 0; j < halfParallels - 1; ++j)
			{
				double polar = Math.PI * j / (double)param.parallels;
				double sp = Math.Sin(polar);
				double cp = Math.Cos(polar);

				for (int i = 0; i < param.meridians; ++i)
				{
					double azimuth = 2.0 * Math.PI * i / (double)param.meridians;
					double sa = Math.Sin(azimuth);
					double ca = Math.Cos(azimuth);
					double x = sp * ca * radius;
					double y = (cp * capHeight) + hafHeight;
					double z = sp * sa * radius;

					list.points.Add(new Point3d(x, y, z));
				}
			}

			for (int j = halfParallels - 1; j < param.parallels - 1; ++j)
			{
				double polar = Math.PI * (j + 2) / (double)param.parallels;
				double sp = Math.Sin(polar);
				double cp = Math.Cos(polar);

				for (int i = 0; i < param.meridians; ++i)
				{
					double azimuth = 2.0 * Math.PI * i / (double)param.meridians;
					double sa = Math.Sin(azimuth);
					double ca = Math.Cos(azimuth);
					double x = sp * ca * radius;
					double y = (cp * capHeight) - hafHeight;
					double z = sp * sa * radius;

					list.points.Add(new Point3d(x, y, z));
				}
			}

			list.points.Add(new Point3d(0.0, -(capHeight + hafHeight), 0.0));

			for (int i = 0; i < param.meridians; ++i)
			{
				int a = i + 1;
				int b = (i + 1) % param.meridians + 1;
				list.triangles.AddTriangle(0, b, a);
			}

			for (int j = 0; j < param.parallels - 2; ++j)
			{
				int aStart = j * param.meridians + 1;
				int bStart = (j + 1) * param.meridians + 1;

				for (int i = 0; i < param.meridians; ++i)
				{
					int a = aStart + i;
					int a1 = aStart + (i + 1) % param.meridians;
					int b = bStart + i;
					int b1 = bStart + (i + 1) % param.meridians;

					if (list.quads != null)
					{
						list.quads.AddQuad(a, a1, b1, b);
					}
					else
					{
						list.triangles.AddTriangle(a, a1, b1);
						list.triangles.AddTriangle(a, b1, b);
					}
				}
			}

			for (int i = 0; i < param.meridians; ++i)
			{
				int a = i + param.meridians * (param.parallels - 2) + 1;
				int b = (i + 1) % param.meridians + param.meridians * (param.parallels - 2) + 1;
				list.triangles.AddTriangle(list.points.Count - 1, a, b);
			}
		}

		/*
		private static void RemapIndices(List<Point3d> points, 
			List<int> indices, 
			Dictionary<int, List<Point3d>> indexTable, 
			Dictionary<Point3d, int> pointTable)
		{
			if (indices == null) return;

			for (int k = 0; k < indices.Count; k++)
			{
				int i = indices[k];

				if (indexTable.ContainsKey(i))
				{
					var point = indexTable[i].First();
					i = pointTable[point];
					indices[k] = i;
				}
				else
				{
					var point = points[i];

					if (!pointTable.ContainsKey(point))
						pointTable.Add(point, i);
				}
			}
		}

		private static void RemapIndices(List<Point3d> points, List<int> indices, List<Point3d> newPoints)
		{
			if (indices == null) return;

			for (int k = 0; k < indices.Count; k++)
			{
				int i = indices[k];
				var point = points[i];
				indices[k] = newPoints.IndexOf(point);
			}
		}


		/// <summary>
		/// Welds duplicate vertices given some threshold.
		/// This is not optimized and will be slow for large point sets.
		/// </summary>
		/// <param name="list"></param>
		private static void WeldVertices(IndexList list)
		{

			double sqthreshold = WELD_EPS * WELD_EPS;

			//Find the points that are to close and put them in a list together.
			//That set then goes in a dictionary with any one of the indices as the key.
			var indexTable = new Dictionary<int, List<Point3d>>();
			for (int i = 0; i < list.points.Count; i++)
			{
				for (int j = 0; j < list.points.Count; j++)
				{
					if (i == j) continue;

					double sqdist = Point3d.SqrDistance(list.points[i], list.points[j]);
					if (sqdist <= sqthreshold)
					{
						if(indexTable.ContainsKey(i))
						{
							indexTable[i].Add(list.points[i]);
							indexTable[i].Add(list.points[j]);
						}
						else if (indexTable.ContainsKey(j))
						{
							indexTable[j].Add(list.points[i]);
							indexTable[j].Add(list.points[j]);
						}
						else
						{
							var set = new HashSet<Point3d>();
							set.Add(list.points[i]);
							set.Add(list.points[j]);
						}
					}
				}
			}

			//Take the first point in the index table
			//and make a point table where the point is
			//the key and any of the points indices is the value.
			var pointTable = new Dictionary<Point3d, int>();
			foreach (var kvp in indexTable)
			{
				int index = kvp.Key;
				var set = kvp.Value;
				pointTable.Add(set.First(), index);
			}

			//Remap the indies so the same index points to the same point.
			RemapIndices(list.points, list.triangles, indexTable, pointTable);
			RemapIndices(list.points, list.quads, indexTable, pointTable);

			//create a new point list containing only the points in used.
			var newPoints = new List<Point3d>();
			foreach(var kvp in indexTable)
				newPoints.Add(kvp.Value.First());

			//Remap the indices so point to the same point in the new point table
			//that has had all the duplicate points removed.
			RemapIndices(list.points, list.triangles, newPoints);
			RemapIndices(list.points, list.quads, newPoints);

			//copy back into point list.
			list.points.Clear();
			list.points.AddRange(newPoints);

		}
		*/

	}
}
