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
            Polygon2Examples.PolygonWithHolesContainsPoint();

            //BenchmarkRunner.Run<BenchmarkDemo>();
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
