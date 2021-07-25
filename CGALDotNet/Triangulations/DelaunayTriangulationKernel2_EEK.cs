using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    internal sealed class DelaunayTriangulationKernel2_EEK : DelaunayTriangulationKernel2
    {

        internal static readonly DelaunayTriangulationKernel2 Instance = new DelaunayTriangulationKernel2_EEK();

        internal override string Name => "EEK";

        public override string ToString()
        {
            return string.Format("[DelaunayTriangulationKernel2<{0}>: ]", Name);
        }

        internal override IntPtr Create()
        {
            return DelaunayTriangulation2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            DelaunayTriangulation2_EEK_Release(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            DelaunayTriangulation2_EEK_Clear(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return DelaunayTriangulation2_EEK_Copy(ptr);
        }

        internal override bool IsValid(IntPtr ptr)
        {
            return DelaunayTriangulation2_EEK_IsValid(ptr);
        }

        internal override int VertexCount(IntPtr ptr)
        {
            return DelaunayTriangulation2_EEK_VertexCount(ptr);
        }

        internal override int FaceCount(IntPtr ptr)
        {
            return DelaunayTriangulation2_EEK_FaceCount(ptr);
        }

        internal override void InsertPoint(IntPtr ptr, Point2d point)
        {
            DelaunayTriangulation2_EEK_InsertPoint(ptr, point);
        }

        internal override void InsertPoints(IntPtr ptr, Point2d[] points, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_InsertPoints(ptr, points, startIndex, count);
        }

        internal override void InsertPolygon(IntPtr triPtr, IntPtr polyPtr)
        {
            DelaunayTriangulation2_EEK_InsertPolygon(triPtr, polyPtr);
        }

        internal override void InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr)
        {
            DelaunayTriangulation2_EEK_InsertPolygonWithHoles(triPtr, pwhPtr);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_GetPoints(ptr, points, startIndex, count);
        }

        internal override void GetIndices(IntPtr ptr, int[] indices, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_GetIndices(ptr, indices, startIndex, count);
        }

        internal override bool GetVertex(IntPtr ptr, int index, out TriVertex2 vertex)
        {
            return DelaunayTriangulation2_EEK_GetVertex(ptr, index, out vertex);
        }

        internal override void GetVertices(IntPtr ptr, TriVertex2[] vertices, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_GetVertices(ptr, vertices, startIndex, count);
        }

        internal override bool GetFace(IntPtr ptr, int index, out TriFace2 face)
        {
            return DelaunayTriangulation2_EEK_GetFace(ptr, index, out face);
        }

        internal override bool GetSegment(IntPtr ptr, int faceIndex, int neighbourIndex, out Segment2d segment)
        {
            return DelaunayTriangulation2_EEK_GetSegment(ptr, faceIndex, neighbourIndex, out segment);
        }

        internal override bool GetTriangle(IntPtr ptr, int faceIndex, out Triangle2d triangle)
        {
            return DelaunayTriangulation2_EEK_GetTriangle(ptr, faceIndex, out triangle);
        }


        internal override void GetTriangles(IntPtr ptr, Triangle2d[] triangles, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_GetTriangles(ptr, triangles, startIndex, count);
        }

        internal override bool GetCircumcenter(IntPtr ptr, int faceIndex, out Point2d circumcenter)
        {
            return DelaunayTriangulation2_EEK_GetCircumcenter(ptr, faceIndex, out circumcenter);
        }

        internal override void GetCircumcenters(IntPtr ptr, [Out] Point2d[] circumcenters, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_GetCircumcenters(ptr, circumcenters, startIndex, count);
        }

        internal override void GetFaces(IntPtr ptr, TriFace2[] faces, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_GetFaces(ptr, faces, startIndex, count);
        }

        internal override bool LocateFace(IntPtr ptr, Point2d point, out TriFace2 face)
        {
            return DelaunayTriangulation2_EEK_LocateFace(ptr, point, out face);
        }

        internal override bool MoveVertex(IntPtr ptr, int index, Point2d point, bool ifNoCollision, out TriVertex2 vertex)
        {
            return DelaunayTriangulation2_EEK_MoveVertex(ptr, index, point, ifNoCollision, out vertex);
        }

        internal override bool RemoveVertex(IntPtr ptr, int index)
        {
            return DelaunayTriangulation2_EEK_RemoveVertex(ptr, index);
        }

        internal override bool FlipEdge(IntPtr ptr, int faceIndex, int neighbour)
        {
            return DelaunayTriangulation2_EEK_FlipEdge(ptr, faceIndex, neighbour);
        }

        //Delaunay only

        internal override int VoronoiSegmentCount(IntPtr ptr)
        {
            return DelaunayTriangulation2_EEK_VoronoiSegmentCount(ptr);
        }

        internal override int VoronoiRayCount(IntPtr ptr)
        {
            return DelaunayTriangulation2_EEK_VoronoiRayCount(ptr);
        }

        internal override void GetVoronoiSegments(IntPtr ptr, Segment2d[] segments, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_GetVoronoiSegments(ptr, segments, startIndex, count);
        }

        internal override void GetVoronoiRays(IntPtr ptr, Ray2d[] rays, int startIndex, int count)
        {
            DelaunayTriangulation2_EEK_GetVoronoiRays(ptr, rays, startIndex, count);
        }

        internal override void VoronoiCount(IntPtr ptr, out int numSegments, out int numRays)
        {
            DelaunayTriangulation2_EEK_VoronoiCount(ptr, out numSegments, out numRays);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr DelaunayTriangulation2_EEK_Create();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_Release(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_Clear(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr DelaunayTriangulation2_EEK_Copy(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_IsValid(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int DelaunayTriangulation2_EEK_VertexCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int DelaunayTriangulation2_EEK_FaceCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_InsertPoint(IntPtr ptr, Point2d point);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_InsertPoints(IntPtr ptr, [In] Point2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_InsertPolygon(IntPtr triPtr, IntPtr polyPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_GetIndices(IntPtr ptr, [Out] int[] indices, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_GetVertex(IntPtr ptr, int index, [Out] out TriVertex2 vertex);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_GetVertices(IntPtr ptr, [Out] TriVertex2[] vertices, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_GetFace(IntPtr ptr, int index, [Out] out TriFace2 triFace);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_GetFaces(IntPtr ptr, [Out] TriFace2[] faces, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_GetSegment(IntPtr ptr, int faceIndex, int neighbourIndex, [Out] out Segment2d segment);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_GetTriangle(IntPtr ptr, int faceIndex, [Out] out Triangle2d triangle);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_GetTriangles(IntPtr ptr, [Out] Triangle2d[] triangles, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_GetCircumcenter(IntPtr ptr, int faceIndex, [Out] out Point2d circumcenter);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_GetCircumcenters(IntPtr ptr, [Out] Point2d[] circumcenters, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_LocateFace(IntPtr ptr, Point2d point, [Out] out TriFace2 face);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_MoveVertex(IntPtr ptr, int index, Point2d point, bool ifNoCollision, [Out] out TriVertex2 vertex);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_RemoveVertex(IntPtr ptr, int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool DelaunayTriangulation2_EEK_FlipEdge(IntPtr ptr, int faceIndex, int neighbour);

        //Delaunay only

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int DelaunayTriangulation2_EEK_VoronoiSegmentCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int DelaunayTriangulation2_EEK_VoronoiRayCount(IntPtr ptr);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_GetVoronoiSegments(IntPtr ptr, [Out] Segment2d[] segments, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_GetVoronoiRays(IntPtr ptr, [Out] Ray2d[] rays, int startIndex, int count);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DelaunayTriangulation2_EEK_VoronoiCount(IntPtr ptr, [Out] out int numSegments, [Out] out int numRays);

    }
}
