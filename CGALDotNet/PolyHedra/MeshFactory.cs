using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
	public struct UVSphereParams
    {
		public int meridians;
		public int parallels;
		public double scale;

		public static UVSphereParams Default
        {
			get
            {
				var param = new UVSphereParams();
				param.parallels = 32;
				param.meridians = 32;
				param.scale = 1;
				return param;
            }
        }
	}

	public struct NormalizedCubeParams
	{

		public int divisions;
		public double scale;

		public static NormalizedCubeParams Default
		{
			get
			{
				var param = new NormalizedCubeParams();
				param.divisions = 16;
				param.scale = 1;
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
		public double thetaStart;
		public double thetaLength;

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
				param.thetaStart = 0;
				param.thetaLength = Math.PI * 2;
				return param;
			}
		}
	}

	/// <summary>
	/// https://github.com/caosdoar/spheres/blob/master/src/spheres.cpp
	/// https://github.com/mrdoob/three.js/tree/dev/src/geometries
	/// </summary>
	public static class MeshFactory
    {

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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="triangles"></param>
		/// <param name="quads"></param>
		/// <param name="scale"></param>
		public static void CreateCube(List<Point3d> points, List<int> triangles, List<int> quads, double scale = 1)
        {
            points.Add(new Point3d(-0.5, -0.5, -0.5) * scale); //0
            points.Add(new Point3d(0.5, -0.5, -0.5) * scale);  //1
			points.Add(new Point3d(0.5, 0.5, -0.5) * scale);   //2
			points.Add(new Point3d(-0.5, 0.5, -0.5) * scale);  //3
			points.Add(new Point3d(-0.5, 0.5, 0.5) * scale);   //4
			points.Add(new Point3d(0.5, 0.5, 0.5) * scale);    //5
			points.Add(new Point3d(0.5, -0.5, 0.5) * scale);   //6
			points.Add(new Point3d(-0.5, -0.5, 0.5) * scale);  //7

			if (quads != null)
			{
				quads.AddQuad(3, 2, 1, 0);  //face front
				quads.AddQuad(2, 3, 4, 5);	//face top
				quads.AddQuad(1, 2, 5, 6);	//face right
				quads.AddQuad(0, 7, 4, 3);	//face left
				quads.AddQuad(5, 4, 7, 6);  //face back
				quads.AddQuad(1, 6, 7, 0);  //face bottom
			}
			else
			{
				triangles.AddTriangle(0, 2, 1); //face front
				triangles.AddTriangle(0, 3, 2);
				triangles.AddTriangle(2, 3, 4); //face top
				triangles.AddTriangle(2, 4, 5);
				triangles.AddTriangle(1, 2, 5); //face right
				triangles.AddTriangle(1, 5, 6);
				triangles.AddTriangle(0, 7, 4); //face left
				triangles.AddTriangle(0, 4, 3);
				triangles.AddTriangle(5, 4, 7); //face back
				triangles.AddTriangle(5, 7, 6);
				triangles.AddTriangle(0, 6, 7); //face bottom
				triangles.AddTriangle(0, 1, 6);
			}
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="triangles"></param>
		/// <param name="quads"></param>
		/// <param name="box"></param>
		public static void CreateCube(List<Point3d> points, List<int> triangles, List<int> quads, Box3d box)
		{
			var corners = box.GetCorners();

			//corners[0] = new Point3d(Min.x, Min.y, Min.z);
			//corners[1] = new Point3d(Max.x, Min.y, Min.z);
			//corners[2] = new Point3d(Max.x, Min.y, Max.z);
			//corners[3] = new Point3d(Min.x, Min.y, Max.z);
			//corners[4] = new Point3d(Min.x, Max.y, Min.z);
			//corners[5] = new Point3d(Max.x, Max.y, Min.z);
			//corners[6] = new Point3d(Max.x, Max.y, Max.z);
			//corners[7] = new Point3d(Min.x, Max.y, Max.z);

			points.Add(corners[0]); //0
			points.Add(corners[1]); //1
			points.Add(corners[5]); //2
			points.Add(corners[4]); //3
			points.Add(corners[7]); //4
			points.Add(corners[6]); //5
			points.Add(corners[2]); //6
			points.Add(corners[3]); //7

			if (quads != null)
			{
				quads.AddQuad(3, 2, 1, 0);  //face front
				quads.AddQuad(2, 3, 4, 5);  //face top
				quads.AddQuad(1, 2, 5, 6);  //face right
				quads.AddQuad(0, 7, 4, 3);  //face left
				quads.AddQuad(5, 4, 7, 6);  //face back
				quads.AddQuad(1, 6, 7, 0);  //face bottom
			}
			else
			{
				triangles.AddTriangle(0, 2, 1); //face front
				triangles.AddTriangle(0, 3, 2);
				triangles.AddTriangle(2, 3, 4); //face top
				triangles.AddTriangle(2, 4, 5);
				triangles.AddTriangle(1, 2, 5); //face right
				triangles.AddTriangle(1, 5, 6);
				triangles.AddTriangle(0, 7, 4); //face left
				triangles.AddTriangle(0, 4, 3);
				triangles.AddTriangle(5, 4, 7); //face back
				triangles.AddTriangle(5, 7, 6);
				triangles.AddTriangle(0, 6, 7); //face bottom
				triangles.AddTriangle(0, 1, 6);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="triangles"></param>
		/// <param name="quads"></param>
		/// <param name="param"></param>
		public static void CreatePlane(List<Point3d> points, List<int> triangles, List<int> quads, PlaneParams param)
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
					points.Add(new Point3d(x, 0, -y));
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

					if(quads != null)
                    {
						quads.AddQuad(d, c, b, a);
					}
					else
                    {
						triangles.AddTriangle(d, b, a);
						triangles.AddTriangle(d, c, b);
					}


				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="triangles"></param>
		/// <param name="quads"></param>
		/// <param name="param"></param>
		public static void CreateUVSphere(List<Point3d> points, List<int> triangles, List<int> quads, UVSphereParams param)
		{
			double scale = param.scale * 0.5;

			points.Add(new Point3d(0.0, 1.0, 0.0) * scale);

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

					points.Add(new Point3d(x, y, z) * scale);
				}
			}

			points.Add(new Point3d(0.0, -1.0, 0.0) * scale);

			for (int i = 0; i < param.meridians; ++i)
			{
				int a = i + 1;
				int b = (i + 1) % param.meridians + 1;

				triangles.AddTriangle(0, b, a);
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

					if(quads != null)
                    {
						quads.AddQuad(a, a1, b1, b);
                    }
					else
                    {
						triangles.AddTriangle(a, a1, b1);
						triangles.AddTriangle(a, b1, b);
					}
				}
			}

			for (int i = 0; i < param.meridians; ++i)
			{
				int a = i + param.meridians * (param.parallels - 2) + 1;
				int b = (i + 1) % param.meridians + param.meridians * (param.parallels - 2) + 1;

				triangles.AddTriangle(points.Count - 1, a, b);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="triangles"></param>
		/// <param name="quads"></param>
		/// <param name="param"></param>
		public static void CreateNormalizedCube(List<Point3d> points, List<int> triangles, List<int>quads, NormalizedCubeParams param)
		{
			double scale = param.scale * 0.5;

			double step = 1.0 / param.divisions;
			Point3d step3 = new Point3d(step, step, step);

			for (int face = 0; face < 6; ++face)
			{
				Point3d origin = Origins[face];
				Point3d right = Rights[face];
				Point3d up = Ups[face];

				for (int j = 0; j < param.divisions + 1; ++j)
				{
					Point3d j3= new Point3d(j, j, j);

					for (int i = 0; i < param.divisions + 1; ++i)
					{
						Point3d i3 = new Point3d(i, i, i);
						Point3d p = origin + step3 * (i3 * right + j3 * up);

						points.Add(p.Vector3d.Normalized * scale);
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

						if (quads != null)
						{
							quads.AddQuad(a, c, d, b);
						}
                        else
                        {
							triangles.AddTriangle(a, c, d);
							triangles.AddTriangle(a, d, b);
						}

					}
				}
			}

			WeldVertices(points, triangles, quads, 1e-4);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="indices"></param>
		/// <param name="scale"></param>
		public static void CreateTetrahedron(List<Point3d> points, List<int> indices, double scale = 1)
        {
			scale *= 0.5;

			// choose coordinates on the unit sphere
			double a = 1.0 / 3.0;
			double b = Math.Sqrt(8.0 / 9.0);
			double c = Math.Sqrt(2.0 / 9.0);
			double d = Math.Sqrt(2.0 / 3.0);

			points.Add(new Point3d(0, 1, 0) * scale);
			points.Add(new Point3d(-c, -a, d) * scale);
			points.Add(new Point3d(-c, -a, -d) * scale);
			points.Add(new Point3d(b, -a, 0) * scale);

			indices.AddTriangle(0, 2, 1);
			indices.AddTriangle(0, 3, 2);
			indices.AddTriangle(0, 1, 3);
			indices.AddTriangle(3, 1, 2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="indices"></param>
		/// <param name="scale"></param>
		public static void CreateOctahedron(List<Point3d> points, List<int> indices, double scale = 1)
        {
			scale *= 0.5;

			points.Add(new Point3d(1, 0, 0) * scale);
			points.Add(new Point3d(-1, 0, 0) * scale);
			points.Add(new Point3d(0, 1, 0) * scale);
			points.Add(new Point3d(0, -1, 0) * scale);
			points.Add(new Point3d(0, 0, 1) * scale);
			points.Add(new Point3d(0, 0, -1) * scale);

			indices.AddTriangle(0, 2, 4);
			indices.AddTriangle(0, 4, 3);
			indices.AddTriangle(0, 3, 5);
			indices.AddTriangle(0, 5, 2);
			indices.AddTriangle(1, 2, 5);
			indices.AddTriangle(1, 5, 3);
			indices.AddTriangle(1, 3, 4);
			indices.AddTriangle(1, 4, 2);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="indices"></param>
		/// <param name="scale"></param>
		public static void CreateIcosahedron(List<Point3d> points, List<int> indices, double scale = 1)
		{
			scale *= 0.5;
			double t = (1.0 + Math.Sqrt(5.0)) / 2.0;

			// Vertices
			points.Add(new Vector3d(-1.0, t, 0.0).Normalized * scale);
			points.Add(new Vector3d(1.0, t, 0.0).Normalized * scale);
			points.Add(new Vector3d(-1.0, -t, 0.0).Normalized * scale);
			points.Add(new Vector3d(1.0, -t, 0.0).Normalized * scale);
			points.Add(new Vector3d(0.0, -1.0, t).Normalized * scale);
			points.Add(new Vector3d(0.0, 1.0, t).Normalized * scale);
			points.Add(new Vector3d(0.0, -1.0, -t).Normalized * scale);
			points.Add(new Vector3d(0.0, 1.0, -t).Normalized * scale);
			points.Add(new Vector3d(t, 0.0, -1.0).Normalized * scale);
			points.Add(new Vector3d(t, 0.0, 1.0).Normalized * scale);
			points.Add(new Vector3d(-t, 0.0, -1.0).Normalized * scale);
			points.Add(new Vector3d(-t, 0.0, 1.0).Normalized * scale);

			// Faces
			indices.AddTriangle(0, 11, 5);
			indices.AddTriangle(0, 5, 1);
			indices.AddTriangle(0, 1, 7);
			indices.AddTriangle(0, 7, 10);
			indices.AddTriangle(0, 10, 11);
			indices.AddTriangle(1, 5, 9);
			indices.AddTriangle(5, 11, 4);
			indices.AddTriangle(11, 10, 2);
			indices.AddTriangle(10, 7, 6);
			indices.AddTriangle(7, 1, 8);
			indices.AddTriangle(3, 9, 4);
			indices.AddTriangle(3, 4, 2);
			indices.AddTriangle(3, 2, 6);
			indices.AddTriangle(3, 6, 8);
			indices.AddTriangle(3, 8, 9);
			indices.AddTriangle(4, 9, 5);
			indices.AddTriangle(2, 4, 11);
			indices.AddTriangle(6, 2, 10);
			indices.AddTriangle(8, 6, 7);
			indices.AddTriangle(9, 8, 1);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="indices"></param>
		/// <param name="scale"></param>
		public static void CreateDodecahedron(List<Point3d> points, List<int> indices, double scale = 1)
        {
			scale *= 0.5;
			double t = (1 + Math.Sqrt(5)) / 2;
			double r = 1 / t;

			points.Add(new Vector3d(-1, -1, -1).Normalized * scale);
			points.Add(new Vector3d(-1, -1, 1).Normalized * scale);
			points.Add(new Vector3d(-1, 1, -1).Normalized * scale);
			points.Add(new Vector3d(-1, 1, 1).Normalized * scale);
			points.Add(new Vector3d(1, -1, -1).Normalized * scale);
			points.Add(new Vector3d(1, -1, 1).Normalized * scale);
			points.Add(new Vector3d(1, 1, -1).Normalized * scale);
			points.Add(new Vector3d(1, 1, 1).Normalized * scale);
			points.Add(new Vector3d(0, -r, -t).Normalized * scale);
			points.Add(new Vector3d(0, -r, t).Normalized * scale);
			points.Add(new Vector3d(0, r, -t).Normalized * scale);
			points.Add(new Vector3d(0, r, t).Normalized * scale);
			points.Add(new Vector3d(-r, -t, 0).Normalized * scale);
			points.Add(new Vector3d(-r, t, 0).Normalized * scale);
			points.Add(new Vector3d(r, -t, 0).Normalized * scale);
			points.Add(new Vector3d(r, t, 0).Normalized * scale);
			points.Add(new Vector3d(-t, 0, -r).Normalized * scale);
			points.Add(new Vector3d(t, 0, -r).Normalized * scale);
			points.Add(new Vector3d(-t, 0, r).Normalized * scale);
			points.Add(new Vector3d(t, 0, r).Normalized * scale);

			indices.AddTriangle(3, 11, 7);
			indices.AddTriangle(3, 7, 15);
			indices.AddTriangle(3, 15, 13);
			indices.AddTriangle(7, 19, 17);
			indices.AddTriangle(7, 17, 6);
			indices.AddTriangle(7, 6, 15);
			indices.AddTriangle(17, 4, 8);
			indices.AddTriangle(17, 8, 10);
			indices.AddTriangle(17, 10, 6);
			indices.AddTriangle(8, 0, 16);
			indices.AddTriangle(8, 16, 2);
			indices.AddTriangle(8, 2, 10);
			indices.AddTriangle(0, 12, 1);
			indices.AddTriangle(0, 1, 18);
			indices.AddTriangle(0, 18, 16);
			indices.AddTriangle(6, 10, 2);
			indices.AddTriangle(6, 2, 13);
			indices.AddTriangle(6, 13, 15);
			indices.AddTriangle(2, 16, 18);
			indices.AddTriangle(2, 18, 3);
			indices.AddTriangle(2, 3, 13);
			indices.AddTriangle(18, 1, 9);
			indices.AddTriangle(18, 9, 11);
			indices.AddTriangle(18, 11, 3);
			indices.AddTriangle(4, 14, 12);
			indices.AddTriangle(4, 12, 0);
			indices.AddTriangle(4, 0, 8);
			indices.AddTriangle(11, 9, 5);
			indices.AddTriangle(11, 5, 19);
			indices.AddTriangle(11, 19, 7);
			indices.AddTriangle(19, 5, 14);
			indices.AddTriangle(19, 14, 4);
			indices.AddTriangle(19, 4, 17);
			indices.AddTriangle(1, 12, 14);
			indices.AddTriangle(1, 14, 5);
			indices.AddTriangle(1, 5, 9);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="triangles"></param>
		/// <param name="quads"></param>
		/// <param name="param"></param>
		public static void CreateTorus(List<Point3d> points, List<int> triangles, List<int> quads, TorusParams param)
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

					points.Add(vertex);
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

					if(quads != null)
                    {
						quads.AddQuad(d, c, b, a);
                    }
					else
                    {
						triangles.AddTriangle(d, b, a);
						triangles.AddTriangle(d, c, b);
					}
				}
			}

			WeldVertices(points, triangles, quads, 1e-4);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="triangles"></param>
		/// <param name="quads"></param>
		/// <param name="param"></param>
		public static void CreateCylinder(List<Point3d> points, List<int> triangles, List<int> quads, CylinderParams param)
        {

			int index = 0;
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

					double theta = u * param.thetaLength + param.thetaStart;

					double sinTheta = Math.Sin(theta);
					double cosTheta = Math.Cos(theta);

					var vertex = new Point3d();
					vertex.x = radius * sinTheta;
					vertex.y = -v * param.height + halfHeight;
					vertex.z = radius * cosTheta;
					points.Add(vertex);

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

					if(quads != null)
                    {
						quads.AddQuad(a, b, c, d);
                    }
					else
                    {
						triangles.AddTriangle(a, b, d);
						triangles.AddTriangle(b, c, d);
					}

				}
			}

			if (param.radiusTop > 0)
				GenerateCap(points, triangles, param, true, ref index);

			if (param.radiusBottom > 0)
				GenerateCap(points, triangles, param, false, ref index);

			//WeldVertices(points, triangles, quads, 1e-4);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="points"></param>
		/// <param name="indices"></param>
		/// <param name="param"></param>
		/// <param name="top"></param>
		/// <param name="index"></param>
		private static void GenerateCap(List<Point3d> points, List<int> indices, CylinderParams param, bool top, ref int index )
		{
			// save the index of the first center vertex
			int centerIndexStart = index;
			double halfHeight = param.height / 2.0;
			double radius = top ? param.radiusTop : param.radiusBottom;
			double sign = top ? 1 : -1;

			for (int x = 1; x <= param.radialDivisions; x++)
			{
				points.Add(new Point3d(0, halfHeight * sign, 0));
				index++;
			}

			// save the index of the last center vertex
			int centerIndexEnd = index;

			for (int x = 0; x <= param.radialDivisions; x++)
			{
				double u = x / (double)param.radialDivisions;
				double theta = u * param.thetaLength + param.thetaStart;

				double cosTheta = Math.Cos(theta);
				double sinTheta = Math.Sin(theta);

				var vertex = new Point3d();
				vertex.x = radius * sinTheta;
				vertex.y = halfHeight * sign;
				vertex.z = radius * cosTheta;
				points.Add(vertex);

				index++;
			}

			for (int x = 0; x < param.radialDivisions; x++)
			{
				int c = centerIndexStart + x;
				int i = centerIndexEnd + x;

				if (top)
					indices.AddTriangle(i, i + 1, c);
				else
					indices.AddTriangle(i + 1, i, c);
			}

		}

		/// <summary>
		/// Welds duplicate vertices given some threshold.
		/// This is not optimized and will be slow for large point sets.
		/// </summary>
		/// <param name="points">The points. Duplicats wiil be removed.</param>
		/// <param name="triangles">The triangle indices to remap.</param>
		/// <param name="quads">The quad indices to remap.</param>
		/// <param name="threshold">The distance threshold for points.</param>
		private static void WeldVertices(List<Point3d> points, List<int> triangles, List<int> quads, double threshold)
        {
			double sqthreshold = threshold * threshold;

			//Find 

			Dictionary<int, int> table = new Dictionary<int, int>();
			for(int i = 0; i < points.Count; i++)
            {
				for (int j = 0; j < points.Count; j++)
				{
					if (i == j) continue;
					//has been remapped so contiune.
					if (table.ContainsKey(j)) continue;

					double sqdist = Point3d.SqrDistance(points[i], points[j]);

					if(sqdist < threshold)
                    {
						// Vertices too close.
						// i stays were it is add j now points to i.
						table[i] = i;
						table[j] = i;
					}
				}
			}

			//record whats point indices are used.
			var indexSet = new HashSet<int>();

			if (triangles != null)
			{
				//remap any index that has moved.
				for (int k = 0; k < triangles.Count; k++)
				{
					int i = triangles[k];

					if (table.TryGetValue(i, out int j))
					{
						//points at index i where moved to j.
						triangles[k] = j;
						indexSet.Add(j);
					}
					else
					{
						//no change
						indexSet.Add(i);
					}
				}
			}

			if (quads != null)
			{
				//remap any index that has moved.
				for (int k = 0; k < quads.Count; k++)
				{
					int i = quads[k];

					if (table.TryGetValue(i, out int j))
					{
						//points at index i where moved to j.
						quads[k] = j;
						indexSet.Add(j);
					}
					else
					{
						//no change
						indexSet.Add(i);
					}
				}
			}

			//create a new point list containing only the points in used.
			var newPoints = new List<Point3d>();
			foreach(int i in indexSet)
				newPoints.Add(points[i]);

			if (triangles != null)
			{
				//find the point index in the new array.
				for (int k = 0; k < triangles.Count; k++)
				{
					int i = triangles[k];
					var point = points[i];
					triangles[k] = newPoints.IndexOf(point);
				}
			}

			if (quads != null)
			{
				//find the point index in the new array.
				for (int k = 0; k < quads.Count; k++)
				{
					int i = quads[k];
					var point = points[i];
					quads[k] = newPoints.IndexOf(point);
				}
			}

			//copy back into point list.
			points.Clear();
			points.AddRange(newPoints);

		}

	}
}
