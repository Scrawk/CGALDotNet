using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

namespace CGALDotNetConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Polygon2Examples.PolygonContainsPoint();

            //BenchmarkRunner.Run<BenchmarkDemo>();

        }

        [MemoryDiagnoser]
        public class BenchmarkDemo
        {

            [GlobalSetup]
            public void Setup()
            {
         
            }

            [Benchmark]
            public void Func1()
            {
 
            }



        }

    }
}
