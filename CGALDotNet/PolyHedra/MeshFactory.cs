using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{

	/// <summary>
	/// https://github.com/caosdoar/spheres/blob/master/src/spheres.cpp
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

		private static void AddQuad(this List<int> list, int item1, int item2, int item3, int item4)
		{
			list.Add(item1);
			list.Add(item2);
			list.Add(item3);
			list.Add(item1);
			list.Add(item3);
			list.Add(item4);
		}

		private static void AddQuadAlt(this List<int> list, int item1, int item2, int item3, int item4)
		{
			list.Add(item1);
			list.Add(item2);
			list.Add(item4);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
		}

		public static void CreateCube(List<Point3d> points, List<int> indices, double scale = 1)
        {
            points.Add(new Point3d(-0.5, -0.5, -0.5) * scale);
            points.Add(new Point3d(0.5, -0.5, -0.5) * scale);
            points.Add(new Point3d(0.5, 0.5, -0.5) * scale);
            points.Add(new Point3d(-0.5, 0.5, -0.5) * scale);
            points.Add(new Point3d(-0.5, 0.5, 0.5) * scale);
            points.Add(new Point3d(0.5, 0.5, 0.5) * scale);
            points.Add(new Point3d(0.5, -0.5, 0.5) * scale);
            points.Add(new Point3d(-0.5, -0.5, 0.5) * scale);

            indices.AddTriangle(0, 2, 1); //face front
            indices.AddTriangle(0, 3, 2);
            indices.AddTriangle(2, 3, 4); //face top
            indices.AddTriangle(2, 4, 5);
            indices.AddTriangle(1, 2, 5); //face right
            indices.AddTriangle(1, 5, 6);
            indices.AddTriangle(0, 7, 4); //face left
            indices.AddTriangle(0, 4, 3);
            indices.AddTriangle(5, 4, 7); //face back
            indices.AddTriangle(5, 7, 6);
            indices.AddTriangle(0, 6, 7); //face bottom
            indices.AddTriangle(0, 1, 6);
        }

		public static void CreateUVSphere(List<Point3d> points, List<int> indices, int meridians, int parallels, double scale = 1)
		{
			scale *= 0.5;

			points.Add(new Point3d(0.0, 1.0, 0.0) * scale);

			for (int j = 0; j < parallels - 1; ++j)
			{
				double polar = Math.PI * (j + 1) / (double)parallels;
				double sp = Math.Sin(polar);
				double cp = Math.Cos(polar);

				for (int i = 0; i < meridians; ++i)
				{
					double azimuth = 2.0 * Math.PI * i / (double)meridians;
					double sa = Math.Sin(azimuth);
					double ca = Math.Cos(azimuth);
					double x = sp * ca;
					double y = cp;
					double z = sp * sa;

					points.Add(new Point3d(x, y, z) * scale);
				}
			}

			points.Add(new Point3d(0.0, -1.0, 0.0) * scale);

			for (int i = 0; i < meridians; ++i)
			{
				int a = i + 1;
				int b = (i + 1) % meridians + 1;

				indices.AddTriangle(0, b, a);
			}

			for (int j = 0; j < parallels - 2; ++j)
			{
				int aStart = j * meridians + 1;
				int bStart = (j + 1) * meridians + 1;

				for (int i = 0; i < meridians; ++i)
				{
					int a = aStart + i;
					int a1 = aStart + (i + 1) % meridians;
					int b = bStart + i;
					int b1 = bStart + (i + 1) % meridians;

					indices.AddQuad(a, a1, b1, b);
				}
			}

			for (int i = 0; i < meridians; ++i)
			{
				int a = i + meridians * (parallels - 2) + 1;
				int b = (i + 1) % meridians + meridians * (parallels - 2) + 1;

				indices.AddTriangle(points.Count - 1, a, b);
			}
		}

		public static void CreateNormalizedCube(List<Point3d> points, List<int> indices, int divisions, double scale = 1)
		{
			scale *= 0.5;

			double step = 1.0 / divisions;
			Point3d step3 = new Point3d(step, step, step);

			for (int face = 0; face < 6; ++face)
			{
				Point3d origin = Origins[face];
				Point3d right = Rights[face];
				Point3d up = Ups[face];

				for (int j = 0; j < divisions + 1; ++j)
				{
					Point3d j3= new Point3d(j, j, j);

					for (int i = 0; i < divisions + 1; ++i)
					{
						Point3d i3 = new Point3d(i, i, i);
						Point3d p = origin + step3 * (i3 * right + j3 * up);

						points.Add(p.Vector3d.Normalized * scale);
					}
				}
			}

			int k = divisions + 1;

			for (int face = 0; face < 6; ++face)
			{
				for (int j = 0; j < divisions; ++j)
				{
					bool bottom = j < (divisions / 2);

					for (int i = 0; i < divisions; ++i)
					{
						bool left = i < (divisions / 2);

						int a = (face * k + j) * k + i;
						int b = (face * k + j) * k + i + 1;
						int c = (face * k + j + 1) * k + i;
						int d = (face * k + j + 1) * k + i + 1;

						if (bottom ^ left) 
							indices.AddQuadAlt(a, c, d, b);
						else 
							indices.AddQuad(a, c, d, b);
					}
				}
			}
		}

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

	}
}
