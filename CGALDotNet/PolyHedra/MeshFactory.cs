using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{
    public static class MeshFactory
    {

        public static void CreateCone(List<Point3d> points, List<int> indices, int resolution, double radius, double height)
        {
            // add the tip of the cone
            points.Add(new Point3d(0.0, 0.0, height));

            // add vertices subdividing a circle
            for (int i = 0; i < resolution; i++)
            {
                var ratio = i / (double)resolution;
                var r = ratio * Math.PI * 2.0;
                var x = Math.Cos(r) * radius;
                var y = Math.Sin(r) * radius;

                var p = new Point3d(x, y, 0.0);
                points.Add(p);
            }

            // generate triangular faces
            for (int i = 0; i < resolution; i++)
            {
                var ii = (i + 1) % resolution;

                indices.Add(0);
                indices.Add(i);
                indices.Add(ii);
            }
        }

    }
}
