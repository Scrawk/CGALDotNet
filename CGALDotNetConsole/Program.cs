using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

using CGALDotNet;
using CGALDotNet.Geometry;

namespace CGALDotNetConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            var min = new Point2d(-1, -1);
            var max = new Point2d(1, 1);

            var point = new Point2d(0, 0);

            var rec = new IsoRectangle2<EEK>(min, max);

            Console.WriteLine(rec.Area);
            Console.WriteLine(rec.BoundedSide(point));
            Console.WriteLine(rec.ContainsPoint(point, true));
            */

            BenchmarkRunner.Run<BenchmarkDemo>();
        }

        [MemoryDiagnoser]
        public class BenchmarkDemo
        {

            int[] list;

            [GlobalSetup]
            public void Setup()
            {
                list = new int[1000];
                for (int i = 0; i < 1000; i++)
                    list[i] = i;
            }

            [Benchmark]
            public void Func1()
            {
                for (int i = 0; i < 1000; i++)
                {
                    var j = list[i];
                }
            }

            [Benchmark]
            public void Func2()
            {
                foreach(var i in list)
                {

                }
            }

        }

    }
}
