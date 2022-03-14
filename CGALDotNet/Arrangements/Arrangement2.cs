using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;
using CGALDotNet.Polygons;
using CGALDotNet.Triangulations;
using CGALDotNet.Meshing;

namespace CGALDotNet.Arrangements
{

    /// <summary>
    /// The generic arrangment class.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class Arrangement2<K> : Arrangement2 where K : CGALKernel, new()
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        public Arrangement2() : base(new K())
        {

        }

        /// <summary>
        /// Create a arrangement from a unmanaged ptr.
        /// </summary>
        /// <param name="ptr">The unmanaged pointer.</param>
        internal Arrangement2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The arrangement as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Arrangement2<{0}>: Vertices={1}, HalfEdges={2}, Faces={3}, Locator={4}]",
                Kernel.Name, VertexCount, HalfEdgeCount, FaceCount, Locator);
        }

        /// <summary>
        /// Assigns the contents of another arrangement. 
        /// </summary>
        /// <param name="other">The other arrangement.</param>
        public void Assign(Arrangement2<K> other)
        {
            Kernel.Assign(Ptr, other.Ptr);
        }

        /// <summary>
        /// Computes the overlay of two arrangements and return as a new arrangement.
        /// </summary>
        /// <param name="other">The other arrangement.</param>
        /// <returns>The overlay of both arrangements.</returns>
        public Arrangement2<K> Overlay(Arrangement2<K> other)
        {
            var ptr = Kernel.Overlay(Ptr, other.Ptr);
            return new Arrangement2<K>(ptr);
        }

        /// <summary>
        /// Create a deep copy of this arrangment.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public Arrangement2<K> Copy()
        {
            var copy = new Arrangement2<K>();
            Kernel.Assign(copy.Ptr, Ptr);
            return copy;
        }

        /// <summary>
        /// Insert the polygon into this arrangement.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="nonIntersecting">If the polygon intersects anything else in the arramgement.</param>
        public void InsertPolygon(Polygon2<K> polygon, bool nonIntersecting)
        {
            Kernel.InsertPolygon(Ptr, polygon.Ptr, nonIntersecting);
        }

        /// <summary>
        /// Insert the polygon into this arrangement.
        /// </summary>
        /// <param name="polygon">The polygon.</param>
        /// <param name="nonIntersecting">If the polygon intersects anything else in the arramgement.</param>
        public void InsertPolygon(PolygonWithHoles2<K> polygon, bool nonIntersecting)
        {
            Kernel.InsertPolygon(Ptr, polygon.Ptr, nonIntersecting);
        }

    }

    /// <summary>
    /// The abstract base class.
    /// </summary>
    public abstract class Arrangement2 : CGALObject
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        private Arrangement2()
        {
            CreateLocator(ARR_LOCATOR.WALK);   
        }

        /// <summary>
        /// Create a arrangement from the kernel.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        internal Arrangement2(CGALKernel kernel)
        {
            Kernel = kernel.ArrangementKernel2;
            Ptr = Kernel.Create();
            CreateLocator(ARR_LOCATOR.WALK);
        }

        /// <summary>
        /// Create a arrangement from the kernel and unmanaged pointer.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        /// <param name="ptr">The unmanaged pointer.</param>
        internal Arrangement2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.ArrangementKernel2;
            CreateLocator(ARR_LOCATOR.WALK);
        }

        /// <summary>
        /// The arrangements kernel.
        /// </summary>
        protected private ArrangementKernel2 Kernel { get; private set; }

        /// <summary>
        /// The number of vertices in the arrangement.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// The number of vertices in the arrangement that are i
        /// </summary>
        public int IsolatedVerticesCount => Kernel.IsolatedVerticesCount(Ptr);

        /// <summary>
        /// returns the number of arrangement vertices that lie at infinity a
        /// nd are not associated with valid points.
        /// Such vertices are not considered to be regular arrangement 
        /// vertices and VertexCount does not count them.
        /// </summary>
        public int VerticesAtInfinityCount => Kernel.VerticesAtInfinityCount(Ptr);

        /// <summary>
        /// The number of half edges.
        /// </summary>
        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        /// <summary>
        /// The number of edges. two half edges count as one edge.
        /// </summary>
        public int EdgeCount => Kernel.EdgeCount(Ptr);

        /// <summary>
        /// The number of faces in the arrangement not counting
        /// the unbounded face.
        /// </summary>
        public int FaceCount => Kernel.FaceCount(Ptr) - UnboundedFaceCount;

        /// <summary>
        /// returns the number of unbounded faces in the arrangement.
        /// Such faces are not considered to be regular arrangement 
        /// faces and FaceCount does not count them.
        /// </summary>
        public int UnboundedFaceCount => Kernel.UnboundedFaceCount(Ptr);

        /// <summary>
        /// The type of locator used to find element 
        /// in the arrangement when queried.
        /// Default is walk which is the best in most cases
        /// </summary>
        public ARR_LOCATOR Locator { get; private set; }

        /// <summary>
        /// Is the arrangement empty.
        /// </summary>
        public bool IsEmpty => Kernel.IsEmpty(Ptr);

        /// <summary>
        /// A number that will change if the unmanaged 
        /// arrangement model changes.
        /// </summary>
        public int BuildStamp => Kernel.BuildStamp(Ptr);

        /// <summary>
        /// Clear the arrangement.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        /// <summary>
        /// In particular, the functions checks the topological structure of the arrangement 
        /// and assures that it is valid. In addition, the function performs several simple 
        /// geometric tests to ensure the validity of some of the geometric properties of 
        /// the arrangement. Namely, it checks that all arrangement vertices are associated 
        /// with distinct points, and that the halfedges around every vertex are ordered clockwise.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        /// <summary>
        /// Get a copy of all the points in the arrangement.
        /// </summary>
        /// <param name="points">A point array that is the length of the vertex count.</param>
        /// <param name="count">The ararys length.</param>
        public void GetPoints(Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
        }

        /// <summary>
        /// Get a copy of all the segments in the arrangment.
        /// </summary>
        /// <param name="segments">A segment array that is the length of the edge count.</param>
        /// <param name="count">The ararys length.</param>
        public void GetSegments(Segment2d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);
            Kernel.GetSegments(Ptr, segments, count);
        }

        /// <summary>
        /// Get a copy of all the vertices in the arrangement.
        /// </summary>
        /// <param name="vertices">A vertices array that is the length of the vertex count.</param>
        /// <param name="count">The ararys length.</param>
        public void GetVertices(ArrVertex2[] vertices, int count)
        {
            ErrorUtil.CheckArray(vertices, count);
            Kernel.GetVertices(Ptr, vertices, count);
        }

        /// <summary>
        /// Get the vertex from the arrangement.
        /// </summary>
        /// <param name="index">The index of the vertex.</param>
        /// <param name="vertex">The vertex.</param>
        /// <returns>True if the vertex was found.</returns>
        public bool GetVertex(int index, out ArrVertex2 vertex)
        {
            return Kernel.GetVertex(Ptr, index, out vertex);
        }

        /// <summary>
        /// Get a copy of all the half edges in the arrangement.
        /// </summary>
        /// <param name="edges">A half edge array that is the length of the half edge count.</param>
        /// <param name="count">The ararys length.</param>
        public void GetHalfEdges(ArrHalfedge2[] edges, int count)
        {
            ErrorUtil.CheckArray(edges, count);
            Kernel.GetHalfEdges(Ptr, edges, count);
        }

        /// <summary>
        /// Get the half edge from the arrangement.
        /// </summary>
        /// <param name="index">The index of the half edge.</param>
        /// <param name="edge">The half edge.</param>
        /// <returns>True if the half edge was found.</returns>
        public bool GetHalfEdge(int index, out ArrHalfedge2 edge)
        {
            return Kernel.GetHalfEdge(Ptr, index, out edge);
        }

        /// <summary>
        /// Get a copy of all the faces in the arrangement.
        /// </summary>
        /// <param name="faces">A face array that is the length of the facee count.</param>
        /// <param name="count">The ararys length.</param>
        public void GetFaces(ArrFace2[] faces, int count)
        {
            ErrorUtil.CheckArray(faces, count);
            Kernel.GetFaces(Ptr, faces, count);
        }

        /// <summary>
        /// Get the face from the arrangement.
        /// </summary>
        /// <param name="index">The index of the half edge.</param>
        /// <param name="face">The face.</param>
        /// <returns>True if the face was found.</returns>
        public bool GetFace(int index, out ArrFace2 face)
        {
            return Kernel.GetFace(Ptr, index, out face);
        }

        /// <summary>
        /// Create the locator used to find query the arrangement.
        /// </summary>
        /// <param name="locator">The locator type.</param>
        public void CreateLocator(ARR_LOCATOR locator)
        {
            if (Locator == locator)
                return;

            Locator = locator;
            Kernel.CreateLocator(Ptr, locator);
        }

        /// <summary>
        /// Release the locator. Default will be used..
        /// Default is walk which is the best in most cases.
        /// </summary>
        public void ReleaseLocator()
        {
            if (Locator == ARR_LOCATOR.NONE)
                return;

            Locator = ARR_LOCATOR.NONE;
            Kernel.ReleaseLocator(Ptr);
        }

        /// <summary>
        /// Query what the point hits in the arrangment.
        /// </summary>
        /// <param name="point">The point to query.</param>
        /// <param name="result">What was hit.</param>
        /// <returns>True if something was hit.</returns>
        public bool PointQuery(Point2d point, out ArrQuery result)
        {
            return Kernel.PointQuery(Ptr, point, out result);
        }

        /// <summary>
        /// Query multiple points in the arrangment.
        /// </summary>
        /// <param name="points">The points to query.</param>
        /// <param name="results">The results for each point.</param>
        /// <returns>True if any point hit something.</returns>
        public bool BatchedPointQuery(Point2d[] points, ArrQuery[] results)
        {
            ErrorUtil.CheckArray(points, points.Length);
            ErrorUtil.CheckArray(results, results.Length);

            return Kernel.BatchedPointQuery(Ptr, points, results, points.Length);
        }

        /// <summary>
        /// Query using a ray going up or down (y axis) from the query point.
        /// </summary>
        /// <param name="point">The point to start at.</param>
        /// <param name="up">True to shoot ray up, false to shoot down.</param>
        /// <param name="result">The result of what was hits.</param>
        /// <returns>True if some thing was hit.</returns>
        public bool VerticalRayQuery(Point2d point, bool up, out ArrQuery result)
        {
            return Kernel.RayQuery(Ptr, point, up, out result);
        }

        /// <summary>
        /// Locate the vertex at this point.
        /// </summary>
        /// <param name="point">The point to locate vertex at.</param>
        /// <param name="vert">The vertex.</param>
        /// <returns>True if a vertex was located.</returns>
        public bool LocateVertex(Point2d point, out ArrVertex2 vert)
        {
            vert = new ArrVertex2();
            if (Kernel.PointQuery(Ptr, point, out ArrQuery result))
            {
                if (result.Element == ARR_ELEMENT_HIT.VERTEX)
                {
                    Kernel.GetVertex(Ptr, result.Index, out vert);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Locate the closest vertex in the hit face
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="radius">The radius te closest vertex has to be within.</param>
        /// <param name="vertex">The closest vertex.</param>
        /// <returns>True if point hit a face and found a vertex.</returns>
        public bool LocateVertex(Point2d point, double radius, out ArrVertex2 vertex)
        {
            //Locate the face the point hit.
            vertex = new ArrVertex2();
            if (LocateFace(point, out ArrFace2 face))
            {
                //Find the closest vertex in the face to the point.
                double min = double.PositiveInfinity;
                var closest = new ArrVertex2();

                foreach (var vert in face.EnumerateVertices(this))
                {
                    if (vert.Index == -1) continue;

                    var sqdist = Point2d.SqrDistance(vert.Point, point);
                    if (sqdist < min)
                    {
                        min = sqdist;
                        closest = vert;
                    }

                }

                if (min == double.PositiveInfinity || min > radius * radius)
                    return false;
                else
                {
                    vertex = closest;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Locate the edge at this point.
        /// </summary>
        /// <param name="point">The point to locate edge at.</param>
        /// <param name="edge">The edge.</param>
        /// <returns>True if a edge was located.</returns>
        public bool LocateEdge(Point2d point, out ArrHalfedge2 edge)
        {
            edge = new ArrHalfedge2();
            if (Kernel.PointQuery(Ptr, point, out ArrQuery result))
            {
                if (result.Element == ARR_ELEMENT_HIT.HALF_EDGE)
                {
                    Kernel.GetHalfEdge(Ptr, result.Index, out edge);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Locate the closest edge in the hit face.
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="edge">The closest edge.</param>
        /// <param name="radius">The radius from the point a edge counts as being clicked on.</param>
        /// <returns>True if the point hit a face and found a edge.</returns>
        public bool LocateEdge(Point2d point, double radius, out ArrHalfedge2 edge)
        {
            //Locate the face the point hit.
            edge = new ArrHalfedge2();
            if (LocateFace(point, out ArrFace2 face))
            {
                //Find the closest edge to the point in the face.
                double min = double.PositiveInfinity;
                var closest = new ArrHalfedge2();

                foreach (var e in face.EnumerateEdges(this))
                {
                    ArrVertex2 v1, v2;
                    if (!GetVertex(e.SourceIndex, out v1)) continue;
                    if (!GetVertex(e.TargetIndex, out v2)) continue;

                    var seg = new Segment2d(v1.Point, v2.Point);
                    var sqdist = seg.SqrDistance(point);

                    if (sqdist < min)
                    {
                        min = sqdist;
                        closest = e;
                    }

                }

                if (min == double.PositiveInfinity || min > radius * radius)
                    return false;
                else
                {
                    edge = closest;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Locate the faces at this point.
        /// </summary>
        /// <param name="point">The point to locate face at.</param>
        /// <param name="face">The face.</param>
        /// <returns>True if a face was located.</returns>
        public bool LocateFace(Point2d point, out ArrFace2 face)
        {
            face = new ArrFace2();
            if(Kernel.PointQuery(Ptr, point, out ArrQuery result))
            {
                if(result.Element == ARR_ELEMENT_HIT.FACE)
                {
                    Kernel.GetFace(Ptr, result.Index, out face);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Find if the arrangement has a element that intersects the segment.
        /// </summary>
        /// <param name="segment">The segment.</param>
        /// <returns>True if the segment intersects something in the arrangement.</returns>
        public bool IntersectsSegment(Segment2d segment)
        {
            return Kernel.IntersectsSegment(Ptr, segment);
        }

        /// <summary>
        /// Inserts a given point into a given arrangement.
        /// It uses a given point-location object to locate the given point in the given arrangement.
        /// If the point conincides with an existing vertex, there is nothing left to do. if it lies 
        /// on an edge, the edge is split at the point. Otherwise, the point is contained inside a face, 
        /// and is inserted as an isolated vertex inside this face.
        /// </summary>
        /// <param name="point">The point to insert.</param>
        public void InsertPoint(Point2d point)
        {
            Kernel.InsertPoint(Ptr, point);
        }

        /// <summary>
        /// Insert the segment in to the arrangement.
        /// </summary>
        /// <param name="a">The segments start point.</param>
        /// <param name="b">The segments end point.</param>
        /// <param name="nonIntersecting">True if the segment is know not to 
        /// hit anything currently in the arrangement.</param>
        public void InsertSegment(Point2d a, Point2d b, bool nonIntersecting)
        {
            Kernel.InsertSegment(Ptr, new Segment2d(a, b), nonIntersecting);
        }

        /// <summary>
        /// Insert a segment into the arrangement.
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="nonIntersecting">True if the segment is know not to 
        /// hit anything currently in the arrangement.</param>
        public void InsertSegment(Segment2d segment, bool nonIntersecting)
        {
            Kernel.InsertSegment(Ptr, segment, nonIntersecting);
        }

        /// <summary>
        /// Insert a array of segments into the arrangement.
        /// </summary>
        /// <param name="segments">The segment array</param>
        /// <param name="count">The segment arrays length.</param>
        /// <param name="nonIntersecting">True if the segments are known not to 
        /// hit anything currently in the arrangement.</param>
        public void InsertSegments(Segment2d[] segments, int count, bool nonIntersecting)
        {
            ErrorUtil.CheckArray(segments, count);
            Kernel.InsertSegments(Ptr, segments, count, nonIntersecting);
        }

        /// <summary>
        /// Attempts to removed a given vertex from a given arrangement.
        /// The vertex can be removed if it is either an isolated vertex, 
        /// (and has no incident edge,) or if it is a redundant vertex.That is, 
        /// it has exactly two incident edges, whose associated curves can be 
        /// merged to form a single x-monotone curve.The function returns a 
        /// boolean value that indicates whether it succeeded removing the 
        /// vertex from the arrangement.
        /// </summary>
        /// <param name="index">The index of the vertex in the arrangement.</param>
        /// <returns>True if the vertex was removed.</returns>
        public bool RemoveVertex(int index)
        {
            return Kernel.RemoveVertexByIndex(Ptr, index);
        }

        /// <summary>
        /// Attempts to removed a given vertex from a given arrangement.
        /// The vertex can be removed if it is either an isolated vertex, 
        /// (and has no incident edge,) or if it is a redundant vertex.That is, 
        /// it has exactly two incident edges, whose associated curves can be 
        /// merged to form a single x-monotone curve.The function returns a 
        /// boolean value that indicates whether it succeeded removing the 
        /// vertex from the arrangement.
        /// </summary>
        /// <param name="point">The poisition of the vertex in the arrangement.</param>
        /// <returns>True if the vertex was removed.</returns>
        public bool RemoveVertex(Point2d point)
        {
            return Kernel.RemoveVertexByPoint(Ptr, point);
        }

        /// <summary>
        /// Removes an edge at the index from the arrangement.
        /// Once the edge is removed, if the vertices associated with its endpoints 
        /// become isolated, they are removed as well.
        /// </summary>
        /// <param name="index">The index of the one of the half edges in the arrangement.</param>
        /// <returns>True if the edge was removed.</returns>
        public bool RemoveEdge(int index)
        {
            return Kernel.RemoveEdgeByIndex(Ptr, index);
        }

        /// <summary>
        /// Removes an edge at the index from the arrangement.
        /// Once the edge is removed, if the vertices associated with its endpoints 
        /// become isolated, they are removed as well.
        /// </summary>
        /// <param name="segment">A segment with the same positions as the edge in the arrangement.</param>
        /// <returns>True if the edge was removed.</returns>
        public bool RemoveEdge(Segment2d segment)
        {
            return Kernel.RemoveEdgeBySegment(Ptr, segment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="printElements"></param>
        public void Print(StringBuilder builder, bool printElements)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Isolated Vertex Count = " + IsolatedVerticesCount);
            builder.AppendLine("Vertex at Infinity Count = " + VerticesAtInfinityCount);
            builder.AppendLine("Edge Count = " + EdgeCount);
            builder.AppendLine("Unbounded Face Count = " + UnboundedFaceCount);

            if (printElements)
            {
                builder.AppendLine();

                PrintVertices(builder);
                PrintHalfEdges(builder);
                PrintFaces(builder);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Isolated Vertex Count = " + IsolatedVerticesCount);
            builder.AppendLine("Vertex at Infinity Count = " + VerticesAtInfinityCount);
            builder.AppendLine("Edge Count = " + EdgeCount);
            builder.AppendLine("Unbounded Face Count = " + UnboundedFaceCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void PrintVertices(StringBuilder builder)
        {
            builder.AppendLine("Arrangement Vertices.\n");

            var vertices = new ArrVertex2[VertexCount];
            GetVertices(vertices, vertices.Length);

            foreach (var v in vertices)
            {
                builder.AppendLine(v.ToString());
                builder.AppendLine("Index = " + v.Index);
                builder.AppendLine("Face Index = " + v.FaceIndex);
                builder.AppendLine("HalfEdge Index = " + v.HalfEdgeIndex);
                builder.AppendLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void PrintHalfEdges(StringBuilder builder)
        {
            builder.AppendLine("Arrangement Half Edges.\n");

            var edges = new ArrHalfedge2[HalfEdgeCount];
            GetHalfEdges(edges, edges.Length);

            foreach (var e in edges)
            {
                builder.AppendLine(e.ToString());
                builder.AppendLine("Index = " + e.Index);
                builder.AppendLine("Source Index = " + e.SourceIndex);
                builder.AppendLine("Target Index = " + e.TargetIndex);
                builder.AppendLine("Face Index = " + e.FaceIndex);
                builder.AppendLine("Next Index = " + e.NextIndex);
                builder.AppendLine("Previous Index = " + e.PreviousIndex);
                builder.AppendLine("Twin Index = " + e.TwinIndex);
                builder.AppendLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void PrintFaces(StringBuilder builder)
        {
            builder.AppendLine("Arrangement Faces.\n");

            var faces = new ArrFace2[FaceCount];
            GetFaces(faces, faces.Length);

            foreach (var e in faces)
            {
                builder.AppendLine(e.ToString());
                builder.AppendLine("Index = " + e.Index);
                builder.AppendLine("HalfEdge Index = " + e.HalfEdgeIndex);
                builder.AppendLine();
            }
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
