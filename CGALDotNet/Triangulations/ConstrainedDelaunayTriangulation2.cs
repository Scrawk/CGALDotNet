using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polygons;
using CGALDotNet.Hulls;

namespace CGALDotNet.Triangulations
{
    /// <summary>
    /// The generic constrained triangulation class.
    /// </summary>
    /// <typeparam name="K">The kernel</typeparam>
    public sealed class ConstrainedDelaunayTriangulation2<K> : ConstrainedDelaunayTriangulation2 where K : CGALKernel, new()
    {
        /// <summary>
        /// A static instance of the triangulation.
        /// </summary>
        public static readonly ConstrainedDelaunayTriangulation2<K> Instance = new ConstrainedDelaunayTriangulation2<K>();

        /// <summary>
        /// 
        /// </summary>
        public ConstrainedDelaunayTriangulation2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        public ConstrainedDelaunayTriangulation2(Point2d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal ConstrainedDelaunayTriangulation2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The triangulation as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[ConstrainedDelaunayTriangulation2<{0}>: VertexCount={1}, FaceCount={2}]",
                Kernel.Name, VertexCount, TriangleCount);
        }

        /// <summary>
        /// A deep copy of the triangulation.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public ConstrainedDelaunayTriangulation2<K> Copy()
        {
            return new ConstrainedDelaunayTriangulation2<K>(Kernel.Copy(Ptr));
        }

        /// <summary>
        /// Compute the convex of the triagulation.
        /// </summary>
        /// <returns>The convex hull polygon.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Polygon2<K> ComputeHull()
        {
            int count = VertexCount;
            if (count < 3)
                throw new InvalidOperationException("Trianglution must have at lest 3 points to compute the hull.");

            var points = ArrayCache.Point2dArray(count);
            GetPoints(points, count);

            var hull = ConvexHull2<K>.Instance;
            return hull.CreateHull(points, count);
        }

    }

    /// <summary>
    /// The abstract triangulation class.
    /// </summary>
    public abstract class ConstrainedDelaunayTriangulation2 : BaseTriangulation2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal ConstrainedDelaunayTriangulation2(CGALKernel kernel)
            : base(kernel.ConstrainedDelaunayTriangulationKernel2)
        {
            TriangulationKernel = Kernel as ConstrainedDelaunayTriangulationKernel2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="points"></param>
        internal ConstrainedDelaunayTriangulation2(CGALKernel kernel, Point2d[] points)
            : base(kernel.ConstrainedDelaunayTriangulationKernel2, points)
        {
            TriangulationKernel = Kernel as ConstrainedDelaunayTriangulationKernel2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal ConstrainedDelaunayTriangulation2(CGALKernel kernel, IntPtr ptr)
            : base(kernel.ConstrainedDelaunayTriangulationKernel2, ptr)
        {
            TriangulationKernel = Kernel as ConstrainedDelaunayTriangulationKernel2;
        }

        /// <summary>
        /// The kernel with the functions unique to the constrained triangulation.
        /// </summary>
        protected private ConstrainedDelaunayTriangulationKernel2 TriangulationKernel { get; private set; }

        /// <summary>
        /// The number of constrainted edges in the triangulation.
        /// </summary>
        public int ConstrainedEdgeCount => TriangulationKernel.ConstrainedEdgesCount(Ptr);

        /// <summary>
        /// Move the vertex.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="point"></param>
        /// <param name="vertex">The moved vertex</param>
        /// <returns>True if the vertex was found.</returns>
        public bool MoveVertex(int index, Point2d point, out TriVertex2 vertex)
        {
            return TriangulationKernel.MoveVertex(Ptr, index, point, true, out vertex);
        }

        /// <summary>
        /// Insert the polygons points into the triangulation.
        /// May not retain the poylgons edges.
        /// </summary>
        /// <param name="polygon"></param>
        public void Insert(Polygon2 polygon)
        {
            TriangulationKernel.InsertPolygon(Ptr, polygon.Ptr);
        }

        /// <summary>
        /// Insert the polygons points into the triangulation.
        /// May not retain the poylgons edges.
        /// </summary>
        /// <param name="pwh"></param>
        public void Insert(PolygonWithHoles2 pwh)
        {
            TriangulationKernel.InsertPolygonWithHoles(Ptr, pwh.Ptr);
        }

        /// <summary>
        /// Insert the polygons points and the edges as constraints into the triangulation.
        /// Will retatin the poylgons edges.
        /// </summary>
        /// <param name="polygon">The polygon to insert.</param>
        public void InsertConstraint(Polygon2 polygon)
        {
            TriangulationKernel.InsertPolygonConstraint(Ptr, polygon.Ptr);
        }

        /// <summary>
        /// Insert the polygons points and the edges as constraints into the triangulation.
        /// Will retatin the poylgons edges.
        /// </summary>
        /// <param name="pwh">The polygon to insert.</param>
        public void InsertConstraint(PolygonWithHoles2 pwh)
        {
            TriangulationKernel.InsertPolygonWithHolesConstraint(Ptr, pwh.Ptr);
        }

        /// <summary>
        /// Get the number of constrainted edges incident to this vertex.
        /// </summary>
        /// <param name="vertIndex">The vertex index in the triagulation.</param>
        /// <returns>The number of constrainted edges to the vertex.</returns>
        public int IncidentConstraintCount(int vertIndex)
        {
            return TriangulationKernel.IncidentConstraintCount(Ptr, vertIndex);
        }

        /// <summary>
        /// Does this vertex have a constrainted edge.
        /// </summary>
        /// <param name="vertIndex">The vertex index in the triagulation.</param>
        /// <returns>Does this vertex have a constrainted edge.</returns>
        public bool HasIncidentConstraint(int vertIndex)
        {
            return TriangulationKernel.HasIncidentConstraints(Ptr, vertIndex);
        }

        /// <summary>
        /// Add a segment as a constraint.
        /// </summary>
        /// <param name="segment">The segment to add.</param>
        public void InsertConstraint(Segment2d segment)
        {
            InsertConstraint(segment.A, segment.B);
        }

        /// <summary>
        /// Add the two points as a segment constraint.
        /// </summary>
        /// <param name="a">The segments point a.</param>
        /// <param name="b">The segments point b.</param>
        public void InsertConstraint(Point2d a, Point2d b)
        {
            TriangulationKernel.InsertSegmentConstraintFromPoints(Ptr, a, b);
        }

        /// <summary>
        /// Add a list of segments as constraint to the triangulation.
        /// </summary>
        /// <param name="segments">The segment array.</param>
        /// <param name="count">The length of the segment array.</param>
        public void InsertConstraints(Segment2d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);
            TriangulationKernel.InsertSegmentConstraints(Ptr, segments, count);
        }

        /// <summary>
        /// Get a array of all the constraint edges in the triangulation.
        /// </summary>
        /// <param name="constraints">The edge array.</param>
        /// <param name="count">The ararys length.</param>
        public void GetConstraints(TriEdge2[] constraints, int count)
        {
            ErrorUtil.CheckArray(constraints, count);
            TriangulationKernel.GetConstraints(Ptr, constraints, count);
        }

        /// <summary>
        /// Get a array of all the constraint segments in the triangulation.
        /// </summary>
        /// <param name="constraints">The segment array.</param>
        /// <param name="count">The ararys length.</param>
        public void GetConstraints(Segment2d[] constraints, int count)
        {
            ErrorUtil.CheckArray(constraints, count);
            TriangulationKernel.GetConstraints(Ptr, constraints, count);
        }

        /// <summary>
        /// Get the constraints incident to the vertex.
        /// </summary>
        /// <param name="vertexIndex">The vertex index in the triangulation.</param>
        /// <param name="constraints">The array of edges.</param>
        /// <param name="count">The ararys length.</param>
        public void GetIncidentConstraints(int vertexIndex, TriEdge2[] constraints, int count)
        {
            ErrorUtil.CheckArray(constraints, count);
            TriangulationKernel.GetIncidentConstraints(Ptr, vertexIndex, constraints, count);
        }

        /// <summary>
        /// Remove a constraint between a face and its neighbour.
        /// </summary>
        /// <param name="faceIndex">The faces index in the triangultion.</param>
        /// <param name="neighbourIndex">The neighbours index in the faces neighbour array between 0-2.</param>
        public void RemoveConstraint(int faceIndex, int neighbourIndex)
        {
            if (neighbourIndex < 0 || neighbourIndex > 2)
                return;

            TriangulationKernel.RemoveConstraint(Ptr, faceIndex, neighbourIndex);
        }

        /// <summary>
        /// Remove all constraints incident to a vertex.
        /// </summary>
        /// <param name="vertexIndex">The vertex index in the triangulation.</param>
        public void RemoveIncidentConstraints(int vertexIndex)
        {
            TriangulationKernel.RemoveIncidentConstraints(Ptr, vertexIndex);
        }

        /// <summary>
        /// Get the triangle indices for domain in the triangultion.
        /// Used to triangulate polygons.
        /// </summary>
        /// <param name="indices">The indices.</param>
        internal void GetConstrainedDomainIndices(List<int> indices)
        {
            int count = IndiceCount;
            if (count == 0) return;

            int[] tmp = new int[count];
            count = TriangulationKernel.MarkDomains(Ptr, tmp, tmp.Length);

            for (int i = 0; i < count; i++)
                indices.Add(tmp[i]); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("IsValid = " + IsValid());
            builder.AppendLine("BuildStamp = " + BuildStamp);
            builder.AppendLine("VertexCount = " + VertexCount);
            builder.AppendLine("TriangleCount = " + TriangleCount);
            builder.AppendLine("IndiceCount = " + IndiceCount);
            builder.AppendLine("Constrained edges = " + ConstrainedEdgeCount);
        }

    }
}
