using System;
using System.Collections.Generic;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Arrangements;

namespace CGALDotNetConsole.Examples
{
    public static class Arrangement2Examples
    {

        public static void CreateArrangement()
        {
            Console.WriteLine("Create arrangement example\n");

            Point2d p1 = new Point2d(0, 0);
            Point2d p2 = new Point2d(0, 4);
            Point2d p3 = new Point2d(4, 0);

            var segments= new Segment2d[]
            {
                new Segment2d(p1, p2),
                new Segment2d(p2, p3),
                new Segment2d(p3, p1)
            };

            var arr = new Arrangement2<EEK>(segments);
            arr.Print();
        }
    }
}
