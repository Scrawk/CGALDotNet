using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNet;
using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;
using CGALDotNet.Arrangements;
using CGALDotNet.Polyhedra;
using CGALDotNet.Meshing;
using CGALDotNet.Hulls;
using CGALDotNet.Processing;

namespace CGALDotNetConsole
{
    public class Program
    {
        

        public static void Main(string[] args)
        {

            var points = Point3d.RandomPoints(0, 10, new Box3d(-10, 10));
            var poly = SkinSurfaceMeshing<EEK>.Instance.CreateSkinPolyhedra(0.5, true, points, points.Length);
            poly.Print();

  
            var connetions = PolygonMeshProcessingConnections<EEK>.Instance;

            connetions.ConnectedComponents(poly);
        }



    }
}
