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

using LibTessDotNet.Double;
using System.Drawing;

namespace CGALDotNetConsole
{
    public class Program
    {


        static void Main(string[] args)
        {


        }

        static void LibTess()
        {
            // Example input data in the form of a star that intersects itself.
            var inputData = new float[] { 0.0f, 3.0f, -1.0f, 0.0f, 1.6f, 1.9f, -1.6f, 1.9f, 1.0f, 0.0f };

            // Create an instance of the tessellator. Can be reused.
            var tess = new Tess();

            // Construct the contour from inputData.
            // A polygon can be composed of multiple contours which are all tessellated at the same time.
            int numPoints = inputData.Length / 2;
            var contour = new ContourVertex[numPoints];
            for (int i = 0; i < numPoints; i++)
            {
                // NOTE : Z is here for convenience if you want to keep a 3D vertex position throughout the tessellation process but only X and Y are important.
                contour[i].Position = new Vec3(inputData[i * 2], inputData[i * 2 + 1], 0);
                // Data can contain any per-vertex data, here a constant color.
                contour[i].Data = Color.Azure;
            }
            // Add the contour with a specific orientation, use "Original" if you want to keep the input orientation.
            tess.AddContour(contour, ContourOrientation.Clockwise);

            // Tessellate!
            // The winding rule determines how the different contours are combined together.
            // See http://www.glprogramming.com/red/chapter11.html (section "Winding Numbers and Winding Rules") for more information.
            // If you want triangles as output, you need to use "Polygons" type as output and 3 vertices per polygon.
            tess.Tessellate(WindingRule.EvenOdd, ElementType.Polygons, 3);

            // Same call but the last callback is optional. Data will be null because no interpolated data would have been generated.
            //tess.Tessellate(LibTessDotNet.WindingRule.EvenOdd, LibTessDotNet.ElementType.Polygons, 3); // Some vertices will have null Data in this case.

            Console.WriteLine("Output triangles:");
            int numTriangles = tess.ElementCount;
            for (int i = 0; i < numTriangles; i++)
            {
                var v0 = tess.Vertices[tess.Elements[i * 3]].Position;
                var v1 = tess.Vertices[tess.Elements[i * 3 + 1]].Position;
                var v2 = tess.Vertices[tess.Elements[i * 3 + 2]].Position;
                Console.WriteLine("#{0} ({1:F1},{2:F1}) ({3:F1},{4:F1}) ({5:F1},{6:F1})", i, v0.X, v0.Y, v1.X, v1.Y, v2.X, v2.Y);
            }

            Console.ReadLine();
        }

        private static void Tri3Test()
        {
            var box = new Box3d(-20, 20);
            var randomPoints = Point3d.RandomPoints(1, 10, box);

            var m_triangulation = new DelaunayTriangulation3<EEK>(randomPoints);

            m_triangulation.Print();

            var points = new Point3d[m_triangulation.VertexCount];
            m_triangulation.GetPoints(points, points.Length);
            points.Round(2);

            var verts = new TriVertex3[m_triangulation.VertexCount];
            m_triangulation.GetVertices(verts, verts.Length);
            verts.Round(2);

            var segments = new int[m_triangulation.EdgeCount * 2];
            m_triangulation.GetSegmentIndices(segments, segments.Length);

            Console.WriteLine("Segments = " + segments.Length);

            foreach (var p in points)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("");

            foreach (var v in verts)
            {
                Console.WriteLine(v);
            }

            int edges = 0;

            for (int i = 0; i < segments.Length / 2; i++)
            {
                int A = segments[i * 2 + 0];
                int B = segments[i * 2 + 1];

                Console.WriteLine("Create edge " + A + " " + B);

                if (A < 0 || A >= points.Length)
                {
                    //Console.WriteLine("A is out of bounds");
                    continue;
                }

                if (B < 0 || B >= points.Length)
                {
                    //Console.WriteLine("B is out of bounds");
                    continue;
                }

                var a = points[A];
                var b = points[B];

                if (!a.IsFinite)
                {
                    //Console.WriteLine("a is not finite");
                    //Console.WriteLine(a);
                    continue;
                }

                if (!b.IsFinite)
                {
                    //Console.WriteLine("b is not finite");
                    //Console.WriteLine(b);
                    continue;
                }

                edges++;

                Console.WriteLine("Create edge " + a + " " + b);
            }

            Console.WriteLine("Created " + edges + " edges)");
        }


    }
}
