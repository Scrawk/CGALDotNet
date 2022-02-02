using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Polylines;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.Polyhedra;
using CGALDotNet.Meshing;
using CGALDotNet.Hulls;
using CGALDotNet.Processing;
using CGALDotNet.Extensions;

namespace CGALDotNetConsole
{
    public class Program
    {
        

        public static void Main(string[] args)
        {

            var mesh = PolyhedronFactory<EEK>.CreateDodecahedron(1, true);

            mesh.Print();


            var meshes = PolyhedronFactory<EEK>.CreateAll(true);

            foreach(var kvp in meshes)
            {
                if(kvp.Value.VertexCount == 0)
                {
                    Console.WriteLine(kvp.Key + " is empty");
                    kvp.Value.Print();
                }

            }

        }

    }
}
