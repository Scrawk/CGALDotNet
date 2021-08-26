using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

using CGeom2D;
using CGeom2D.Geometry;
using CGeom2D.Points;

namespace CGALDotNetConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var collection = new PointCollection(1000000);

            collection.AddPoint(0, 0);
            collection.AddPoint(4, 0);
            collection.AddPoint(2, 2);
            collection.AddPoint(4, -4);
            collection.AddPoint(6, -6);
            collection.AddPoint(8, -4);

            collection.AddSegment(0, 1);
            collection.AddSegment(0, 2);
            collection.AddSegment(0, 3);
            collection.AddSegment(3, 4);
            collection.AddSegment(3, 5);

            var line = collection.CreateSweepLine();

            SweepEvent e;
            do
            {
                e = line.PopEvent();
            }
            while (line.HandleEvent(e));

            //BenchmarkRunner.Run<BenchmarkDemo>();

        }

        [MemoryDiagnoser]
        public class BenchmarkDemo
        {

            Point2i a = new Point2i(1, 2);
            Point2i b = new Point2i(3, 4);
            Point2i c = new Point2i(5, 6);

            [Benchmark]
            public void BenchmarkFunc1()
            {
                var area = Predicates.Area2(a, b, c);
            }

        }

    }
}
