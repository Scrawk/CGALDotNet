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
        /// Returns the dimension of the affine hull.
        /// </summary>
        public int Dimension => Kernel.Dimension(Ptr);

        /// <summary>
        /// Returns the number of finite vertices.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

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
        /// <param name="segments"></param>
        public void GetSegmentsIndices(List<SegmentIndex> segments)
        {
            var indices = TetrahedronToSegmentIndices();
            var set = new HashSet<SegmentIndex>();

            for (int i = 0; i < indices.Count; i++)
            {
                var seg = indices[i];
                var opp = seg.Reversed;

                if (!set.Contains(seg) && !set.Contains(opp))
                {
                    set.Add(seg);
                    set.Add(opp);
                    segments.Add(seg);
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<SegmentIndex> TetrahedronToSegmentIndices()
        {
            int count =TetrahdronIndiceCount;
            var indices = new int[count];

            GetTetrahedronIndices(indices, count);

            var segments = new List<SegmentIndex>();

            for (int i = 0; i < indices.Length / 4; i++)
            {
                int i0 = indices[i * 4 + 0];
                int i1 = indices[i * 4 + 1];
                int i2 = indices[i * 4 + 2];
                int i3 = indices[i * 4 + 3];

                var i01 = new SegmentIndex(i0, i1);
                var i02 = new SegmentIndex(i0, i2);
                var i03 = new SegmentIndex(i0, i3);

                var i12 = new SegmentIndex(i1, i2);
                var i23 = new SegmentIndex(i2, i3);
                var i31 = new SegmentIndex(i3, i1);

                if (!i01.HasNullIndex) segments.Add(i01);
                if (!i02.HasNullIndex) segments.Add(i02);
                if (!i03.HasNullIndex) segments.Add(i03);

                if (!i12.HasNullIndex) segments.Add(i12);
                if (!i23.HasNullIndex) segments.Add(i23);
                if (!i31.HasNullIndex) segments.Add(i31);

            }

            return segments;
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
