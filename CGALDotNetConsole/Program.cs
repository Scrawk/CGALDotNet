using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetConsole.Examples;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;

namespace CGALDotNetConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var t = new Triangulation2<EEK>();
            t.InsertPoint(new Point2d(-5, -5));
            t.InsertPoint(new Point2d(5, -5));
            t.InsertPoint(new Point2d(0, 5));

            //Console.WriteLine("Build Stamp " + t.BuildStamp);


        }


    }
}
