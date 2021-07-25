using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Triangulations
{

    public sealed class ConstrainedTriangulation2<K> : ConstrainedTriangulation2 where K : CGALKernel, new()
    {

        public static readonly ConstrainedTriangulation2<K> Instance = new ConstrainedTriangulation2<K>();

        public ConstrainedTriangulation2() : base(new K())
        {
            Console.WriteLine("ConstrainedTriangulation2<K>");
        }

        public ConstrainedTriangulation2(Point2d[] points) : base(new K(), points)
        {

        }

        public ConstrainedTriangulation2(Polygon2<K> polygon) : base(new K())
        {
            InsertPolygonConstraint(polygon);
        }

        public ConstrainedTriangulation2(PolygonWithHoles2<K> polygon) : base(new K())
        {
            InsertPolygonConstraint(polygon);
        }

        internal ConstrainedTriangulation2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[ConstrainedTriangulation2<{0}>: VertexCount={1}, FaceCount={2}]",
                Kernel.Name, VertexCount, FaceCount);
        }

        public ConstrainedTriangulation2<K> Copy()
        {
            return new ConstrainedTriangulation2<K>(Kernel.Copy(Ptr));
        }

        public void InsertPolygon(Polygon2<K> polygon)
        {
            Kernel.InsertPolygon(Ptr, polygon.Ptr);
        }

        public void InsertPolygon(PolygonWithHoles2<K> pwh)
        {
            Kernel.InsertPolygonWithHoles(Ptr, pwh.Ptr);
        }

        public void InsertPolygonConstraint(Polygon2<K> polygon)
        {
            TriangulationKernel.InsertPolygonConstraint(Ptr, polygon.Ptr);
        }

        public void InsertPolygonConstraint(PolygonWithHoles2<K> pwh)
        {
            TriangulationKernel.InsertPolygonWithHolesConstraint(Ptr, pwh.Ptr);
        }

    }

    public abstract class ConstrainedTriangulation2 : BaseTriangulation2
    {

        internal ConstrainedTriangulation2(CGALKernel kernel) 
            : base(kernel.ConstrainedTriangulationKernel2)
        {
            TriangulationKernel = Kernel as ConstrainedTriangulationKernel2;
        }

        internal ConstrainedTriangulation2(CGALKernel kernel, Point2d[] points)
            : base(kernel.ConstrainedTriangulationKernel2, points)
        {
            TriangulationKernel = Kernel as ConstrainedTriangulationKernel2;
        }

        internal ConstrainedTriangulation2(CGALKernel kernel, IntPtr ptr) 
            : base(kernel.ConstrainedTriangulationKernel2, ptr)
        {
            TriangulationKernel = Kernel as ConstrainedTriangulationKernel2;
        }

        protected private ConstrainedTriangulationKernel2 TriangulationKernel { get; private set; }

        public int ConstrainedEdgeCount => TriangulationKernel.ConstrainedEdgesCount(Ptr);

        public int IncidentConstraintCount(int vertIndex)
        {
            return TriangulationKernel.IncidentConstraintCount(Ptr, vertIndex);
        }

        public bool HasIncidentConstraint(int vertIndex)
        {
            return TriangulationKernel.HasIncidentConstraints(Ptr, vertIndex);
        }

        public void InsertSegmentConstraint(Segment2d segment)
        {
            InsertSegmentConstraint(segment.A, segment.B);
        }

        public void InsertSegmentConstraint(Point2d a, Point2d b)
        {
            TriangulationKernel.InsertSegmentConstraintFromPoints(Ptr, a, b);
        }

        public void InsertSegmentConstraints(Segment2d[] segments)
        {
            TriangulationKernel.InsertSegmentConstraints(Ptr, segments, 0, segments.Length);
        }

        public void GetConstraints(TriEdgeConstraint2[] constraints)
        {
            TriangulationKernel.GetConstraints(Ptr, constraints, 0, constraints.Length);
        }

        public void GetIncidentConstraints(int vertexIndex, TriEdgeConstraint2[] constraints)
        {
            TriangulationKernel.GetIncidentConstraints(Ptr, vertexIndex, constraints, 0, constraints.Length);
        }

        public void RemoveConstraint(int faceIndex, int neighbourIndex)
        {
            TriangulationKernel.RemoveConstraint(Ptr, faceIndex, neighbourIndex);
        }

        public void RemoveIncidentConstraints(int vertexIndex)
        {
            TriangulationKernel.RemoveIncidentConstraints(Ptr, vertexIndex);
        }

        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Is valid = " + IsValid());
            builder.AppendLine("Constrained edges = " + ConstrainedEdgeCount);
        }

    }
}
