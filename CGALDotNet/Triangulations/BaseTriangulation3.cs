using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Triangulations
{

    public enum TRIANGULATION3
    {
        TRIANGULATION,
        DELAUNAY
    }

    /// <summary>
    /// Base triangulation class for Triangulation, DelaunayTriangulation 
    /// and ConstrainedTriangulation.
    /// </summary>
    public abstract class BaseTriangulation3 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private BaseTriangulation3()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="points"></param>
        internal BaseTriangulation3(BaseTriangulationKernel3 kernel, Point3d[] points)
        {
            Kernel = kernel;
            Ptr = Kernel.Create();
            Insert(points, points.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal BaseTriangulation3(BaseTriangulationKernel3 kernel)
        {
            Kernel = kernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal BaseTriangulation3(BaseTriangulationKernel3 kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel;
        }

        /// <summary>
        /// The triangulations kernel.
        /// </summary>
        protected private BaseTriangulationKernel3 Kernel { get; private set; }

        /// <summary>
        /// Returns the dimension of the affine hull.
        /// </summary>
        public int Dimension => Kernel.Dimension(Ptr);

        /// <summary>
        /// Returns the number of finite vertices.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// Returns the number of cells or 0 if Dimension < 3.
        /// </summary>
        public int TetrahedronCount => Kernel.CellCount(Ptr);

        /// <summary>
        /// The number of finite cells.
        /// Returns 0 if Dimension < 3.
        /// </summary>
        public int FiniteTetrahedronCount => Kernel.FiniteCellCount(Ptr);

        /// <summary>
        /// The number of edges.
        /// Returns 0 if Dimension < 1.
        /// </summary>
        public int EdgeCount => Kernel.EdgeCount(Ptr);

        /// <summary>
        /// The number of finite edges.
        /// Returns 0 if Dimension < 1.
        /// </summary>
        public int FiniteEdgeCount => Kernel.FiniteEdgeCount(Ptr);

        /// <summary>
        /// The number of facets.
        /// Returns 0 if Dimension < 2.
        /// </summary>
        public int TriangleCount => Kernel.FacetCount(Ptr);

        /// <summary>
        /// The number of facets.
        /// Returns 0 if Dimension < 2.
        /// </summary>
        public int FiniteTriangleCount =>  Kernel.FiniteFacetCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int SegmentIndiceCount => FiniteEdgeCount * 2;

        /// <summary>
        /// 
        /// </summary>
        public int TriangleIndiceCount => FiniteTriangleCount * 3;

        /// <summary>
        /// 
        /// </summary>
        public int TetrahdronIndiceCount => FiniteTetrahedronCount * 4;

        /// <summary>
        /// Clear the triangulation.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        /// <summary>
        /// Inserts the point p in the triangulation.
        /// If point p coincides with an already existing vertex the triangulation remains unchanged.
        /// If point p lies in the convex hull of the points, it is added naturally: 
        /// if it lies inside a cell, the cell is split into four cells, if it lies 
        /// on a facet, the two incident cells are split into three cells, if it lies
        /// on an edge, all the cells incident to this edge are split into two cells.
        /// If point p is strictly outside the convex hull but in the affine hull, p 
        /// is linked to all visible points on the convex hull to form the new triangulation.
        /// If point p is outside the affine hull of the points, p is linked to all the points,
        /// and the dimension of the triangulation is incremented. All the points now belong to 
        /// the boundary of the convex hull, so, the infinite vertex is linked to all the points 
        /// to triangulate the new infinite face.
        /// </summary>
        /// <param name="point">The point to insert</param>
        public void Insert(Point3d point)
        {
            Kernel.InsertPoint(Ptr, point);
        }

        /// <summary>
        /// Insert all the points in the array.
        /// </summary>
        /// <param name="points">The points to insert.</param>
        /// <param name="count">The arrays length</param>
        public void Insert(Point3d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.InsertPoints(Ptr, points, count);
        }

        /// <summary>
        /// Get all the points in the triangulation.
        /// </summary>
        /// <param name="points">The array to copy into.</param>
        /// <param name="count">The arrays length.</param>
        public void GetPoints(Point3d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="count"></param>
        public void GetSegmentIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetSegmentIndices(Ptr, indices, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="count"></param>
        public void GetTriangleIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetTriangleIndices(Ptr, indices, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="count"></param>
        public void GetTetrahedronIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetTetrahedraIndices(Ptr, indices, count);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
        }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
