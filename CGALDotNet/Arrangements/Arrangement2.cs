using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.DCEL;

namespace CGALDotNet.Arrangements
{
    [Flags]
    public enum ARRANGEMENT_CHECK
    {
        NONE = 0,
        ARRAY_BOUNDS = 1,
        ALL = ~0
    };

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
    public abstract class Arrangement2 : CGALObject, IDCELModel
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
        /// The dimension of the point struct in the DCEL vertex
        /// </summary>
        public int Dimension => 2;

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
        /// What checks should the arrangement.
        /// </summary>
        public ARRANGEMENT_CHECK CheckFlag = ARRANGEMENT_CHECK.ALL;

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
        /// 
        /// <returns></returns>
        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        /// <summary>
        /// Get a copy of all the points in the arrangement.
        /// </summary>
        /// <param name="points">A point array that is the length of the vertex count.</param>
        public void GetPoints(Point2d[] points)
        {
            if (points == null || points.Length == 0)  
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(points, 0, VertexCount);

            Kernel.GetPoints(Ptr, points, 0, points.Length);
        }

        /// <summary>
        /// Get a copy of all the segments in the arrangment.
        /// </summary>
        /// <param name="segments">A segment array that is the length of the edge count.</param>
        public void GetSegments(Segment2d[] segments)
        {
            if (segments == null || segments.Length == 0) 
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(segments, 0, EdgeCount);

            Kernel.GetSegments(Ptr, segments, 0, segments.Length);
        }

        /// <summary>
        /// Get a copy of all the vertices in the arrangement.
        /// </summary>
        /// <param name="vertices">A vertices array that is the length of the vertex count.</param>
        public void GetVertices(ArrVertex2[] vertices)
        {
            if (vertices == null || vertices.Length == 0) 
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(vertices, 0, VertexCount);

            Kernel.GetVertices(Ptr, vertices, 0, vertices.Length);
        }

        /// <summary>
        /// Get the DCEL vertices that can be use to reconstruct 
        /// the model as a DCEL data sturcture.
        /// </summary>
        /// <param name="vertices">The array vertices</param>
        public void GetDCELVertices(DCELVertex[] vertices)
        {
            if (vertices == null || vertices.Length == 0)
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(vertices, 0, VertexCount);

            var arrVerts = new ArrVertex2[vertices.Length];
            Kernel.GetVertices(Ptr, arrVerts, 0, arrVerts.Length);

            for (int i = 0; i < arrVerts.Length; i++)
                vertices[i] = new DCELVertex(null, arrVerts[i]);
                
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
        public void GetHalfEdges(ArrHalfEdge2[] edges)
        {
            if (edges == null || edges.Length == 0)
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(edges, 0, HalfEdgeCount);

            Kernel.GetHalfEdges(Ptr, edges, 0, edges.Length);
        }

        /// <summary>
        /// Get the DCEL edhe that can be use to reconstruct 
        /// the model as a DCEL data sturcture.
        /// </summary>
        /// <param name="halfEdges">The array edges</param>
        public void GetDCELHalfEdges(DCELHalfEdge[] edges)
        {
            if (edges == null || edges.Length == 0)
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(edges, 0, HalfEdgeCount);

            var arrEdges = new ArrHalfEdge2[edges.Length];
            Kernel.GetHalfEdges(Ptr, arrEdges, 0, arrEdges.Length);

            for (int i = 0; i < arrEdges.Length; i++)
                edges[i] = new DCELHalfEdge(null, arrEdges[i]);
        }

        /// <summary>
        /// Get the half edge from the arrangement.
        /// </summary>
        /// <param name="index">The index of the half edge.</param>
        /// <param name="edge">The half edge.</param>
        /// <returns>True if the half edge was found.</returns>
        public bool GetHalfEdge(int index, out ArrHalfEdge2 edge)
        {
            return Kernel.GetHalfEdge(Ptr, index, out edge);
        }

        /// <summary>
        /// Get a copy of all the faces in the arrangement.
        /// </summary>
        /// <param name="faces">A face array that is the length of the facee count.</param>
        public void GetFaces(ArrFace2[] faces)
        {
            if (faces == null || faces.Length == 0)
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(faces, 0, FaceCount);

            Kernel.GetFaces(Ptr, faces, 0, faces.Length);
        }

        /// <summary>
        /// Get the DCEL faces that can be use to reconstruct 
        /// the model as a DCEL data sturcture.
        /// </summary>
        /// <param name="faces">The array faces</param>
        public void GetDCELFaces(DCELFace[] faces)
        {
            if (faces == null || faces.Length == 0)
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(faces, 0, FaceCount);

            var arrFaces = new ArrFace2[faces.Length];
            Kernel.GetFaces(Ptr, arrFaces, 0, arrFaces.Length);

            for (int i = 0; i < arrFaces.Length; i++)
                faces[i] = new DCELFace(null, arrFaces[i]);
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
            if (points == null || points.Length == 0)
                return false;

            if (results == null || results.Length == 0)
                return false;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(results, 0, points.Length);

            return Kernel.BatchedPointQuery(Ptr, points, results, 0, points.Length);
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
        /// Locate the face the point hits.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="face">The face the point has hit.</param>
        /// <returns>True if the point hit a face.</returns>
        public bool LocateFace(Point2d point, out DCELFace face)
        {
            face = new DCELFace(null);
            if (LocateFace(point, out ArrFace2 f))
            {
                face.Index = f.Index;
                face.HalfEdgeIndex = f.HalfEdgeIndex;
                return true;
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
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="b">The segments end point.</param>
        /// <param name="nonIntersecting">True if the segment is know not to 
        /// hit anything currently in the arrangement.</param>
        public void InsertSegment(Segment2d segment, bool nonIntersecting)
        {
            Kernel.InsertSegment(Ptr, segment, nonIntersecting);
        }

        /// <summary>
        /// Insert a array of segments into the arrangement.
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="b">The segments end point.</param>
        /// <param name="nonIntersecting">True if the segments are known not to 
        /// hit anything currently in the arrangement.</param>
        public void InsertSegments(Segment2d[] segments, bool nonItersecting)
        {
            if (segments == null || segments.Length == 0)
                return;

            Kernel.InsertSegments(Ptr, segments, 0, segments.Length, nonItersecting);
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
        /// <param name="printElements"></param>
        public void Print(bool printElements = false)
        {
            var builder = new StringBuilder();
            Print(builder, printElements);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="printElements"></param>
        public void Print(StringBuilder builder, bool printElements = false)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Isolated Vertex Count = " + IsolatedVerticesCount);
            builder.AppendLine("Vertex at Infinity Count = " + VerticesAtInfinityCount);
            builder.AppendLine("Edge Count = " + EdgeCount);
            builder.AppendLine("Unbounded Face Count = " + UnboundedFaceCount);

            if(printElements)
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
        public void PrintVertices(StringBuilder builder)
        {
            builder.AppendLine("Arrangement Vertices.\n");

            var vertices = new ArrVertex2[VertexCount];
            GetVertices(vertices);

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

            var edges = new ArrHalfEdge2[HalfEdgeCount];
            GetHalfEdges(edges);

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
            GetFaces(faces);

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
