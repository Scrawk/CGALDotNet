using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNetGeometry.Extensions;

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
using CGALDotNet.Collections;
using CGALDotNet.Eigen;

namespace CGALDotNetConsole
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            var points = Point3d.RandomPoints(0, 10, new Box3f(-10, 10));
            points.Round(2);

            var tri = new DelaunayTriangulation3<EEK>(points);

            tri.Print();

            var vertices = new TriVertex3[tri.VertexCount];
            tri.GetVertices(vertices, vertices.Length);

            var cells = new TriCell3[tri.TetrahedronCount];
            tri.GetCells(cells, cells.Length);

        }


    }
}
