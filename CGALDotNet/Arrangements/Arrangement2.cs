using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

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
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class Arrangement2<K> : Arrangement2 where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public Arrangement2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal Arrangement2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Arrangement2<{0}>: Vertices={1}, HalfEdges={2}, Faces={3}, Locator={4}]",
                Kernel.Name, VertexCount, HalfEdgeCount, FaceCount, Locator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Assign(Arrangement2<K> other)
        {
            Kernel.Assign(Ptr, other.Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Arrangement2<K> Overlay(Arrangement2<K> other)
        {
            var ptr = Kernel.Overlay(Ptr, other.Ptr);
            return new Arrangement2<K>(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Arrangement2<K> Copy()
        {
            var copy = new Arrangement2<K>();
            Kernel.Assign(copy.Ptr, Ptr);
            return copy;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="nonIntersecting"></param>
        public void InsertPolygon(Polygon2<K> polygon, bool nonIntersecting)
        {
            Kernel.InsertPolygon(Ptr, polygon.Ptr, nonIntersecting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="nonIntersecting"></param>
        public void InsertPolygon(PolygonWithHoles2<K> polygon, bool nonIntersecting)
        {
            Kernel.InsertPolygon(Ptr, polygon.Ptr, nonIntersecting);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Arrangement2 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private Arrangement2()
        {
            CreateLocator(ARR_LOCATOR.WALK);   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal Arrangement2(CGALKernel kernel)
        {
            Kernel = kernel.ArrangementKernel2;
            Ptr = Kernel.Create();
            CreateLocator(ARR_LOCATOR.WALK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal Arrangement2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.ArrangementKernel2;
            CreateLocator(ARR_LOCATOR.WALK);
        }

        /// <summary>
        /// 
        /// </summary>
        protected private ArrangementKernel2 Kernel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int IsolatedVerticesCount => Kernel.IsolatedVerticesCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int VerticesAtInfinityCount => Kernel.VerticesAtInfinityCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int EdgeCount => Kernel.EdgeCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int FaceCount => Kernel.FaceCount(Ptr) - UnboundedFaceCount;

        /// <summary>
        /// 
        /// </summary>
        public int UnboundedFaceCount => Kernel.UnboundedFaceCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public ARR_LOCATOR Locator { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEmpty => Kernel.IsEmpty(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public ARRANGEMENT_CHECK CheckFlag = ARRANGEMENT_CHECK.ALL;

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="points"></param>
        public void GetPoints(Point2d[] points)
        {
            if (points == null || points.Length == 0)  
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(points, 0, VertexCount);

            Kernel.GetPoints(Ptr, points, 0, points.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segments"></param>
        public void GetSegments(Segment2d[] segments)
        {
            if (segments == null || segments.Length == 0) 
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(segments, 0, EdgeCount);

            Kernel.GetSegments(Ptr, segments, 0, segments.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices"></param>
        public void GetVertices(ArrVertex2[] vertices)
        {
            if (vertices == null || vertices.Length == 0) 
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(vertices, 0, VertexCount);

            Kernel.GetVertices(Ptr, vertices, 0, vertices.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool GetVertex(int index, out ArrVertex2 vertex)
        {
            return Kernel.GetVertex(Ptr, index, out vertex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="edges"></param>
        public void GetHalfEdges(ArrHalfEdge2[] edges)
        {
            if (edges == null || edges.Length == 0)
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(edges, 0, HalfEdgeCount);

            Kernel.GetHalfEdges(Ptr, edges, 0, edges.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="edge"></param>
        /// <returns></returns>
        public bool GetHalfEdge(int index, out ArrHalfEdge2 edge)
        {
            return Kernel.GetHalfEdge(Ptr, index, out edge);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="faces"></param>
        public void GetFaces(ArrFace2[] faces)
        {
            if (faces == null || faces.Length == 0)
                return;

            if (CheckFlag.HasFlag(ARRANGEMENT_CHECK.ARRAY_BOUNDS))
                ErrorUtil.CheckBounds(faces, 0, FaceCount);

            Kernel.GetFaces(Ptr, faces, 0, faces.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="face"></param>
        /// <returns></returns>
        public bool GetFace(int index, out ArrFace2 face)
        {
            return Kernel.GetFace(Ptr, index, out face);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator"></param>
        public void CreateLocator(ARR_LOCATOR locator)
        {
            if (Locator == locator)
                return;

            Locator = locator;
            Kernel.CreateLocator(Ptr, locator);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ReleaseLocator()
        {
            if (Locator == ARR_LOCATOR.NONE)
                return;

            Locator = ARR_LOCATOR.NONE;
            Kernel.ReleaseLocator(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool PointQuery(Point2d point, out ArrQuery result)
        {
            return Kernel.PointQuery(Ptr, point, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="results"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="up"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool RayQuery(Point2d point, bool up, out ArrQuery result)
        {
            return Kernel.RayQuery(Ptr, point, up, out result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="face"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool LocateVertex(Point2d point, out ArrVertex2 vertex)
        {
            vertex = new ArrVertex2();
            if (Kernel.PointQuery(Ptr, point, out ArrQuery result))
            {
                if (result.Element == ARR_ELEMENT_HIT.VERTEX)
                {
                    Kernel.GetVertex(Ptr, result.Index, out vertex);
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
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="edge"></param>
        /// <returns></returns>
        public bool LocateHalfEdge(Point2d point, out ArrHalfEdge2 edge)
        {
            edge = new ArrHalfEdge2();
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
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
        public bool IntersectsSegment(Segment2d segment)
        {
            return Kernel.IntersectsSegment(Ptr, segment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public void InsertPoint(Point2d point)
        {
            Kernel.InsertPoint(Ptr, point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="nonIntersecting"></param>
        public void InsertSegment(Point2d a, Point2d b, bool nonIntersecting)
        {
            Kernel.InsertSegment(Ptr, new Segment2d(a, b), nonIntersecting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="nonIntersecting"></param>
        public void InsertSegment(Segment2d segment, bool nonIntersecting)
        {
            Kernel.InsertSegment(Ptr, segment, nonIntersecting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="nonItersecting"></param>
        public void InsertSegments(Segment2d[] segments, bool nonItersecting)
        {
            if (segments == null || segments.Length == 0)
                return;

            Kernel.InsertSegments(Ptr, segments, 0, segments.Length, nonItersecting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveVertex(int index)
        {
            return Kernel.RemoveVertexByIndex(Ptr, index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool RemoveVertex(Point2d point)
        {
            return Kernel.RemoveVertexByPoint(Ptr, point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool RemoveEdge(int index)
        {
            return Kernel.RemoveEdgeByIndex(Ptr, index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
