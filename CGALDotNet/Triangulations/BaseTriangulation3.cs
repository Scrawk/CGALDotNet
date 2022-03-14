using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

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
        /// Returns the buildStamp.
        /// The build stamp will change if 
        /// the triangulation model has changed
        /// </summary>
        public int BuildStamp => Kernel.BuildStamp(Ptr);

        /// <summary>
        /// Returns the dimension of the affine hull.
        /// </summary>
        public int Dimension => Kernel.Dimension(Ptr);

        /// <summary>
        /// Returns the number of vertices.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// Returns the number of finite vertices.
        /// </summary>
        public int FiniteVertexCount => Kernel.FiniteVertexCount(Ptr);

        /// <summary>
        /// Returns the number of cells or 0 if Dimension less than 3.
        /// </summary>
        public int TetrahedronCount => Kernel.CellCount(Ptr);

        /// <summary>
        /// The number of finite cells.
        /// Returns 0 if Dimension less than 3.
        /// </summary>
        public int FiniteTetrahedronCount => Kernel.FiniteCellCount(Ptr);

        /// <summary>
        /// The number of edges.
        /// Returns 0 if Dimension less than 1.
        /// </summary>
        public int EdgeCount => Kernel.EdgeCount(Ptr);

        /// <summary>
        /// The number of finite edges.
        /// Returns 0 if Dimension less than 1.
        /// </summary>
        public int FiniteEdgeCount => Kernel.FiniteEdgeCount(Ptr);

        /// <summary>
        /// The number of facets.
        /// Returns 0 if Dimension less than 2.
        /// </summary>
        public int TriangleCount => Kernel.FacetCount(Ptr);

        /// <summary>
        /// The number of facets.
        /// Returns 0 if Dimension less than 2.
        /// </summary>
        public int FiniteTriangleCount =>  Kernel.FiniteFacetCount(Ptr);

        /// <summary>
        /// The number of indices needed for the finite tetrahedrons.
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
            return Kernel.IsValid(Ptr, false);
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
        /// Insert a vertex into a cell.
        /// </summary>
        /// <param name="index">The cells index.</param>
        /// <param name="point">The point to insert.</param>
        public void InsertInCell(int index, Point3d point)
        {
            Kernel.InsertInCell(Ptr, index, point);
        }

        /// <summary>
        /// If the point query lies inside the convex hull of the points, the cell that contains the query in its interior is returned.
        /// If query lies on a facet, an edge or on a vertex, one of the cells having query on its boundary is returned.
        /// If the point query lies outside the convex hull of the points, an infinite cell with vertices { p,q,r,∞} is
        /// returned such that the tetrahedron(p, q, r, query) is positively oriented(the rest of the triangulation lies
        /// on the other side of facet (p, q, r)).
        /// Note that locate works even in degenerate dimensions: in dimension 2 (resp. 1, 0) the Cell_handle returned
        /// is the one that represents the facet(resp.edge, vertex) containing the query point.
        /// The optional argument start is used as a starting place for the search.
        /// The optional argument could_lock_zone is used by the concurrency-safe version of the triangulation.When the
        /// pointer is not null, the locate will try to lock all the cells along the walk. If it succeeds,
        /// could_lock_zone is true, otherwise it is false. In any case, the locked cells are not unlocked by locate,
        /// leaving this choice to the user. 
        /// </summary>
        /// <param name="point">The point to query</param>
        /// <param name="cell">The cell thats closest to point.</param>
        /// <returns>The closest cell to point.</returns>
        public bool Locate(Point3d point, out TriCell3 cell)
        {
            int index = Kernel.Locate(Ptr, point);
            if(index != CGALGlobal.NULL_INDEX)
            {
                if(GetCell(index, out cell))
                {
                    return true;
                }
                else
                {
                    cell = new TriCell3();
                    return false;
                }
            }
            else
            {
                cell = new TriCell3();
                return false;
            }
            
        }

        /// <summary>
        /// Get the centroids of each cell.
        /// </summary>
        /// <param name="circumcenters">The array of points</param>
        /// <param name="count">The array of points length</param>
        public void GetCircumcenters(Point3d[] circumcenters, int count)
        {
            ErrorUtil.CheckArray(circumcenters, count);
            Kernel.GetCircumcenters(Ptr, circumcenters, count);
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
        /// Get all the points in the triangulation.
        /// </summary>
        /// <param name="points">The array to copy into.</param>
        public void GetPoints(List<Point3d> points)
        {
            int count = VertexCount;
            var array = new Point3d[count];    
            GetPoints(array, array.Length);
            points.AddRange(array);
        }

        /// <summary>
        /// Get the triangulation vertices.
        /// </summary>
        /// <param name="vertices">The vertex array.</param>
        /// <param name="count">The vertex array length.</param>
        public void GetVertices(TriVertex3[] vertices, int count)
        {
            ErrorUtil.CheckArray(vertices, count);
            Kernel.GetVertices(Ptr, vertices, count);
        }

        /// <summary>
        /// Get a triangulation vertex.
        /// </summary>
        /// <param name="index">The vertices index</param>
        /// <param name="vertex">The vertex.</param>
        /// <returns></returns>
        public bool GetVertex(int index, out TriVertex3 vertex)
        {
            return Kernel.GetVertex(Ptr, index, out vertex); 
        }

        /// <summary>
        /// Get the triangulation vertices.
        /// </summary>
        /// <param name="cells">The vertex array.</param>
        /// <param name="count">The vertex array length.</param>
        public void GetCells(TriCell3[] cells, int count)
        {
            ErrorUtil.CheckArray(cells, count);
            Kernel.GetCells(Ptr, cells, count);
        }

        /// <summary>
        /// Get a triangulation vertex.
        /// </summary>
        /// <param name="index">The vertices index</param>
        /// <param name="cell">The vertex.</param>
        /// <returns></returns>
        public bool GetCell(int index, out TriCell3 cell)
        {
            return Kernel.GetCell(Ptr, index, out cell);
        }

        /// <summary>
        /// Get the indices of the cells edges in the triangulation.
        /// </summary>
        /// <param name="indices">The indices array.</param>
        /// <param name="count">The indices array length.</param>
        public void GetSegmentIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetSegmentIndices(Ptr, indices, count);
        }

        public void GetSegments(Segment3d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);
            Kernel.GetSegments(Ptr, segments, count);
        }

        /// <summary>
        /// Get the indices of the cells triangles in the triangulation.
        /// </summary>
        /// <param name="indices">The indices array.</param>
        /// <param name="count">The indices array length.</param>
        public void GetTriangleIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetTriangleIndices(Ptr, indices, count);
        }

        public void GetTriangles(Triangle3d[] triangles, int count)
        {
            ErrorUtil.CheckArray(triangles, count);
            Kernel.GetTriangles(Ptr, triangles, count);
        }

        /// <summary>
        /// Get the indices of the tetrahedron cells in the triangulation.
        /// </summary>
        /// <param name="indices">The indices array.</param>
        /// <param name="count">The indices array length.</param>
        public void GetTetrahedronIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetTetrahedraIndices(Ptr, indices, count);
        }

        public void GetTetrahedrons(Tetrahedron3d[] tetrahedrons, int count)
        {
            ErrorUtil.CheckArray(tetrahedrons, count);
            Kernel.GetTetrahedrons(Ptr, tetrahedrons, count);
        }

        /// <summary>
        /// Translate each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point3d translation)
        {
            var m = Matrix4x4d.Translate(translation);
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Rotate each point in the mesh.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Quaternion3d rotation)
        {
            var m = rotation.ToMatrix4x4d();
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Scale each point in the mesh.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(Point3d scale)
        {
            var m = Matrix4x4d.Scale(scale);
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// Transform each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point3d translation, Quaternion3d rotation, Point3d scale)
        {
            var m = Matrix4x4d.TranslateRotateScale(translation, rotation, scale);
            Kernel.Transform(Ptr, m);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
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
