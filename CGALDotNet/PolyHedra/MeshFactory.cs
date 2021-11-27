using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{
    public static class MeshFactory
    {

        public static void CreateCube(List<Point3d> points, List<int> indices)
        {

            points.Add(new Point3d(0, 0, 0));
            points.Add(new Point3d(1, 0, 0));
            points.Add(new Point3d(1, 1, 0));
            points.Add(new Point3d(0, 1, 0));
            points.Add(new Point3d(0, 1, 1));
            points.Add(new Point3d(1, 1, 1));
            points.Add(new Point3d(1, 0, 1));
            points.Add(new Point3d(0, 0, 1));

            var _indices = new int[]
                {
                0, 2, 1, //face front
	            0, 3, 2,
                2, 3, 4, //face top
	            2, 4, 5,
                1, 2, 5, //face right
	            1, 5, 6,
                0, 7, 4, //face left
	            0, 4, 3,
                5, 4, 7, //face back
	            5, 7, 6,
                0, 6, 7, //face bottom
	            0, 1, 6
            };

            indices.AddRange(_indices);
        }

    }
}
