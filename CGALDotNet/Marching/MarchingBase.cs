using System;
using System.Collections;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Marching
{
    public abstract class MarchingBase
    {

        public double Surface { get; set; }

        private float[] Cube { get; set; }

        /// <summary>
        /// Winding order of triangles use 2,1,0 or 0,1,2
        /// </summary>
        protected int[] WindingOrder { get; private set; }

        public MarchingBase()
        {
            Surface = 0;
            Cube = new float[8];
            WindingOrder = new int[] { 2, 1, 0 };
        }

        /// <summary>
        /// Generate the vertices and indices from the data returned from the function.
        /// </summary>
        /// <param name="sdf">The signed distance function</param>
        /// <param name="width">The width of the sdf's bounds</param>
        /// <param name="height">The height of the sdf's bounds</param>
        /// <param name="depth">The depth of the sdf's bounds</param>
        /// <param name="verts">The list the vertices will be added to.</param>
        /// <param name="indices">The list the indices will be added to.</param>
        public void Generate(Func<Point3d, double> sdf, int width, int height, int depth, List<Point3d> verts, List<int> indices)
        {
            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    for (int z = 0; z < depth - 1; z++)
                    {
                        //Get the values in the 8 neighbours which make up a cube
                        for (int i = 0; i < 8; i++)
                        {
                            int ix = x + VertexOffset[i, 0];
                            int iy = y + VertexOffset[i, 1];
                            int iz = z + VertexOffset[i, 2];

                            Cube[i] = (float)sdf(new Point3d(ix, iy, iz));
                        }

                        //Perform algorithm
                        March(x, y, z, Cube, verts, indices);
                    }
                }
            }
        }

        /// <summary>
        /// Generate the vertices and indices from the data in the voxel array.
        /// </summary>
        /// <param name="voxels">The voxel array</param>
        /// <param name="verts">The list the vertices will be added to.</param>
        /// <param name="indices">The list the indices will be added to.</param>
        public void Generate(float[,,] voxels, List<Point3d> verts, List<int> indices)
        {
            int width = voxels.GetLength(0);
            int height = voxels.GetLength(1);
            int depth = voxels.GetLength(2);

            for (int x = 0; x < width - 1; x++)
            {
                for (int y = 0; y < height - 1; y++)
                {
                    for (int z = 0; z < depth - 1; z++)
                    {
                        //Get the values in the 8 neighbours which make up a cube
                        for (int i = 0; i < 8; i++)
                        {
                            int ix = x + VertexOffset[i, 0];
                            int iy = y + VertexOffset[i, 1];
                            int iz = z + VertexOffset[i, 2];

                            Cube[i] = voxels[ix,iy,iz];
                        }

                        //Perform algorithm
                        March(x, y, z, Cube, verts, indices);
                    }
                }
            }
        }

         /// <summary>
        /// MarchCube performs the Marching algorithm on a single cube
        /// </summary>
        protected abstract void March(double x, double y, double z, float[] cube, List<Point3d> vertList, List<int> indexList);

        /// <summary>
        /// GetOffset finds the approximate point of intersection of the surface
        /// between two points with the values v1 and v2
        /// </summary>
        protected double GetOffset(double v1, double v2)
        {
            double delta = v2 - v1;
            return (delta == 0.0f) ? Surface : (Surface - v1) / delta;
        }

        /// <summary>
        /// VertexOffset lists the positions, relative to vertex0, 
        /// of each of the 8 vertices of a cube.
        /// vertexOffset[8][3]
        /// </summary>
        protected static readonly int[,] VertexOffset = new int[,]
	    {
	        {0, 0, 0},{1, 0, 0},{1, 1, 0},{0, 1, 0},
	        {0, 0, 1},{1, 0, 1},{1, 1, 1},{0, 1, 1}
	    };

    }

}
