using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;
using CGALDotNet.CSG;

namespace CGALDotNet.Marching
{
    public class MarchingSquares
    {

        public double Surface { get; set; }

        private float[] Square { get; set; }

        private Point2d[] EdgeVertex { get; set; }

        public MarchingSquares()
        {
            Square = new float[4];
            EdgeVertex = new Point2d[4];
        }

        /// <summary>
        /// Generate the vertices and indices from the data returned from the function.
        /// </summary>
        /// <param name="sdf">The signed distance function</param>
        /// <param name="width">The width of the sdf's bounds</param>
        /// <param name="height">The height of the sdf's bounds</param>
        /// <param name="verts">The list the vertices will be added to.</param>
        /// <param name="indices">The list the indices will be added to.</param>
        public void Generate(Node2 sdf, int width, int height, List<Point2d> verts, List<int> indices)
        {

            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int ix = x + VertexOffset[i, 0];
                        int iy = y + VertexOffset[i, 1];
                        var point = new Point2d(ix, iy);

                        Square[i] = (float)sdf.Func(point);
                    }

                    March(x, y, Square, verts, indices);
                }
            }
        }

        /// <summary>
        /// Generate the vertices and indices from the data returned from the function.
        /// </summary>
        /// <param name="sdf">The signed distance function</param>
        /// <param name="width">The width of the sdf's bounds</param>
        /// <param name="height">The height of the sdf's bounds</param>
        /// <param name="verts">The list the vertices will be added to.</param>
        /// <param name="indices">The list the indices will be added to.</param>
        public void Generate(Func<double, double, double> sdf, int width, int height, List<Point2d> verts, List<int> indices)
        {

            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {

                    for (int i = 0; i < 4; i++)
                    {
                        int ix = x + VertexOffset[i, 0];
                        int iy = y + VertexOffset[i, 1];

                        Square[i] = (float)sdf(ix, iy);
                    }

                    March(x, y, Square, verts, indices);
                }
            }
        }

        /// <summary>
        /// Generate the vertices and indices from the data in the voxel array.
        /// </summary>
        /// <param name="voxels">The voxel array</param>
        /// <param name="verts">The list the vertices will be added to.</param>
        /// <param name="indices">The list the indices will be added to.</param>
        public void Generate(float[,] voxels, List<Point2d> verts, List<int> indices)
        {
            int width = voxels.GetLength(0);
            int height = voxels.GetLength(1);

            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {

                    for (int i = 0; i < 4; i++)
                    {
                        int ix = x + VertexOffset[i, 0];
                        int iy = y + VertexOffset[i, 1];

                        Square[i] = voxels[ix, iy];
                    }

                    March(x, y, Square, verts, indices);
                }
            }
        }

        private void March(float x, float y, float[] square, List<Point2d> verts, List<int> indices)
        {
            int flagIndex = 0;

            //Find which vertices are inside of the surface and which are outside
            for (int i = 0; i < 4; i++)
                if (square[i] <= Surface) flagIndex |= 1 << i;

            //Find which edges are intersected by the surface
            int edgeFlags = SquareEdgeFlags[flagIndex];

            //If the cube is entirely inside or outside of the surface, then there will be no intersections
            if (edgeFlags == 0) return;

            //Find the point of intersection of the surface with each edge
            for (int i = 0; i < 4; i++)
            {
                //if there is an intersection on this edge
                if ((edgeFlags & (1 << i)) != 0)
                {
                    double offset = GetOffset(square[EdgeConnection[i, 0]], square[EdgeConnection[i, 1]]);

                    EdgeVertex[i].x = x + (VertexOffset[EdgeConnection[i, 0], 0] + offset * EdgeDirection[i, 0]);
                    EdgeVertex[i].y = y + (VertexOffset[EdgeConnection[i, 0], 1] + offset * EdgeDirection[i, 1]);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                if (EdgeConnectionTable[flagIndex, 2 * i] < 0) break;

                int idx = verts.Count;
                int i0 = EdgeConnectionTable[flagIndex, 2 * i + 0];
                int i1 = EdgeConnectionTable[flagIndex, 2 * i + 1];

                var v0 = EdgeVertex[i0];
                var v1 = EdgeVertex[i1];

                if (v0 != v1)
                {
                    indices.Add(idx + 0);
                    indices.Add(idx + 1);

                    verts.Add(v0);
                    verts.Add(v1);
                }

            }
        }

        /// <summary>
        /// GetOffset finds the approximate point of intersection of the surface
        /// between two points with the values v1 and v2
        /// </summary>
        private double GetOffset(double v1, double v2)
        {
            if (v2 == double.PositiveInfinity) return 0;
            if (v1 == double.PositiveInfinity) return 1;

            double delta = v2 - v1;
            return (delta == 0.0) ? Surface : (Surface - v1) / delta;
        }

        /// <summary>
        /// VertexOffset lists the positions, relative to vertex0, 
        /// of each of the 4 vertices of a square.
        /// </summary>
        private static readonly int[,] VertexOffset = new int[,]
        {
            {0, 0,},{1, 0},{1, 1},{0, 1}
        };

        /// <summary>
        /// EdgeConnection lists the index of the endpoint vertices for each 
        /// of the 4 edges of the cube.
        /// </summary>
        private static readonly int[,] EdgeConnection = new int[,]
        {
            {0,1}, {1,2}, {2,3}, {3,0}
        };

        /// <summary>
        /// edgeDirection lists the direction vector (vertex1-vertex0) for each edge in the cube.
        /// </summary>
        private static readonly float[,] EdgeDirection = new float[,]
        {
            {1, 0},{0, 1},{-1, 0},{0, -1}
        };

        public static byte[] SquareEdgeFlags = new byte[]
        {
            0b_0000_0000, //0
            0b_0000_1001, //1
            0b_0000_0011, //2
            0b_0000_1010, //3
            0b_0000_0110, //4
            0b_0000_1111, //5
            0b_0000_0101, //6
            0b_0000_1100, //7
            0b_0000_1100, //8
            0b_0000_0101, //9
            0b_0000_1111, //10
            0b_0000_0110, //11
            0b_0000_1010, //12
            0b_0000_0011, //13
            0b_0000_1001, //14
            0b_0000_0000  //15
        };

        private static readonly int[,] EdgeConnectionTable = new int[,]
        {
            {-1, -1, -1, -1}, //0
            {0, 3, -1, -1}, //1
            {1, 0, -1, -1}, //2
            {1, 3, -1, -1}, //3
            {2, 1, -1, -1}, //4
            {2, 3, 0, 1}, //5
            {2, 0, -1, -1}, //6
            {2, 3, -1, -1}, //7
            {3, 2, -1, -1}, //8
            {0, 2, -1, -1}, //9
            {3, 0, 1, 2}, //10
            {1, 2, -1, -1}, //11
            {3, 1, -1, -1}, //12
            {0, 1, -1, -1}, //13
            {3, 0, -1, -1}, //14
            {-1, -1, -1, -1}, //15
        };

    }
}
