using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;

namespace CGALDotNetConsole.Examples
{
    public static class Geometry2Examples
    {

        public static void Transform()
        {
            Console.WriteLine("Transform example\n");

            var p0 = new Point2d(0, 0);
            var p1 = new Point2d(1, 0);
            var p2 = new Point2d(0, 1);
            var p3 = new Point2d(1, 1);

            var v0 = new Vector2d(1, 0);

            //var tri = new Triangle2d(p0, p1, p2);

            var ray = new Ray2d(p0, v0);

            Console.WriteLine("Before " + ray);

            var t = new Vector3d(2, 0, 0);
            var r = Quaternion3d.RotateZ(Radian.A90);
            var s = new Vector3d(2, 2, 1);

            var m2 = Matrix2x2d.Rotate(Degree.A90);

            var m3 = Matrix3x3d.RotateZ(Degree.A90);

            var m4 = Matrix4x4d.TranslateRotateScale(t, r, s);

            ray.Transform(m4);
            ray.Round(1);

            Console.WriteLine("After " + ray);

        }

    }
}
