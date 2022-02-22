using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Triangulations
{
    internal class ConstrainedDelaunayTriangulationKernel2_EEK : ConstrainedDelaunayTriangulationKernel2
    {
        internal override string Name => "EEK";

        internal static readonly ConstrainedDelaunayTriangulationKernel2 Instance = new ConstrainedDelaunayTriangulationKernel2_EEK();

        internal override IntPtr Create()
        {
            return ConstrainedDelaunayTriangulation2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            ConstrainedDelaunayTriangulation2_EEK_Release(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            ConstrainedDelaunayTriangulation2_EEK_Clear(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EEK_Copy(ptr);
        }

        internal override void SetIndices(IntPtr ptr)
        {
            ConstrainedDelaunayTriangulation2_EEK_SetIndices(ptr);
        }

        internal override int BuildStamp(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EEK_BuildStamp(ptr);
        }

        internal override bool IsValid(IntPtr ptr, int level)
        {
            return ConstrainedDelaunayTriangulation2_EEK_IsValid(ptr, level);
        }

        internal override int VertexCount(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EEK_VertexCount(ptr);
        }

        internal override int FaceCount(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EEK_FaceCount(ptr);
        }

        internal override void InsertPoint(IntPtr ptr, Point2d point)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertPoint(ptr, point);
        }

        internal override void InsertPoints(IntPtr ptr, Point2d[] points, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertPoints(ptr, points, count);
        }

        internal override void InsertPolygon(IntPtr triPtr, IntPtr polyPtr)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertPolygon(triPtr, polyPtr);
        }

        internal override void InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertPolygonWithHoles(triPtr, pwhPtr);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetPoints(ptr, points, count);
        }

        internal override void GetIndices(IntPtr ptr, int[] indices, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetIndices(ptr, indices, count);
        }

        internal override bool GetVertex(IntPtr ptr, int index, out TriVertex2 vertex)
        {
            return ConstrainedDelaunayTriangulation2_EEK_GetVertex(ptr, index, out vertex);
        }

        internal override void GetVertices(IntPtr ptr, TriVertex2[] vertices, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetVertices(ptr, vertices, count);
        }

        internal override bool GetFace(IntPtr ptr, int index, out TriFace2 face)
        {
            return ConstrainedDelaunayTriangulation2_EEK_GetFace(ptr, index, out face);
        }

        internal override void GetFaces(IntPtr ptr, TriFace2[] faces, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetFaces(ptr, faces, count);
        }

        internal override bool GetSegment(IntPtr ptr, int faceIndex, int neighbourIndex, out Segment2d segment)
        {
            return ConstrainedDelaunayTriangulation2_EEK_GetSegment(ptr, faceIndex, neighbourIndex, out segment);
        }

        internal override bool GetTriangle(IntPtr ptr, int faceIndex, out Triangle2d triangle)
        {
            return ConstrainedDelaunayTriangulation2_EEK_GetTriangle(ptr, faceIndex, out triangle);
        }

        internal override void GetTriangles(IntPtr ptr, Triangle2d[] triangles, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetTriangles(ptr, triangles, count);
        }

        internal override bool GetCircumcenter(IntPtr ptr, int faceIndex, out Point2d circumcenter)
        {
            return ConstrainedDelaunayTriangulation2_EEK_GetCircumcenter(ptr, faceIndex, out circumcenter);
        }

        internal override void GetCircumcenters(IntPtr ptr, [Out] Point2d[] circumcenters, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetCircumcenters(ptr, circumcenters, count);
        }

        internal override int NeighbourIndex(IntPtr ptr, int faceIndex, int index)
        {
            return ConstrainedDelaunayTriangulation2_EEK_NeighbourIndex(ptr, faceIndex, index);
        }

        internal override bool LocateFace(IntPtr ptr, Point2d point, out TriFace2 face)
        {
            return ConstrainedDelaunayTriangulation2_EEK_LocateFace(ptr, point, out face);
        }

        internal override bool MoveVertex(IntPtr ptr, int index, Point2d point, bool ifNoCollision, out TriVertex2 vertex)
        {
            return ConstrainedDelaunayTriangulation2_EEK_MoveVertex(ptr, index, point, ifNoCollision, out vertex);
        }

        internal override bool RemoveVertex(IntPtr ptr, int index)
        {
            return ConstrainedDelaunayTriangulation2_EEK_RemoveVertex(ptr, index);
        }

        internal override bool FlipEdge(IntPtr ptr, int faceIndex, int neighbour)
        {
            return ConstrainedDelaunayTriangulation2_EEK_FlipEdge(ptr, faceIndex, neighbour);
        }

        //Constrained only.

        internal override int ConstrainedEdgesCount(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EEK_ConstrainedEdgesCount(ptr);
        }

        internal override bool HasIncidentConstraints(IntPtr ptr, int index)
        {
            return ConstrainedDelaunayTriangulation2_EEK_HasIncidentConstraints(ptr, index);
        }

        internal override int IncidentConstraintCount(IntPtr ptr, int index)
        {
            return ConstrainedDelaunayTriangulation2_EEK_IncidentConstraintCount(ptr, index);
        }

        internal override void InsertSegmentConstraintFromPoints(IntPtr ptr, Point2d a, Point2d b)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertSegmentConstraintFromPoints(ptr, a, b);
        }

        internal override void InsertSegmentConstraintFromVertices(IntPtr ptr, int vertIndex1, int vertIndex2)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertSegmentConstraintFromVertices(ptr, vertIndex1, vertIndex2);
        }

        internal override void InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertSegmentConstraints(ptr, segments, count);
        }

        internal override void InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertPolygonConstraint(triPtr, polyPtr);
        }

        internal override void InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr)
        {
            ConstrainedDelaunayTriangulation2_EEK_InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
        }

        internal override void GetConstraints(IntPtr ptr, TriEdge2[] constraints, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetEdgeConstraints(ptr, constraints, count);
        }

        internal override void GetConstraints(IntPtr ptr, Segment2d[] constraints, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetSegmentConstraints(ptr, constraints, count);
        }

        internal override void GetIncidentConstraints(IntPtr ptr, int vertexIndex, TriEdge2[] constraints, int count)
        {
            ConstrainedDelaunayTriangulation2_EEK_GetIncidentConstraints(ptr, vertexIndex, constraints, count);
        }

        internal override void RemoveConstraint(IntPtr ptr, int faceIndex, int neighbourIndex)
        {
            ConstrainedDelaunayTriangulation2_EEK_RemoveConstraint(ptr, faceIndex, neighbourIndex);
        }

        internal override void RemoveIncidentConstraints(IntPtr ptr, int vertexIndex)
        {
            ConstrainedDelaunayTriangulation2_EEK_RemoveIncidentConstraints(ptr, vertexIndex);
        }

        internal override int MarkDomains(IntPtr ptr, int[] indices, int count)
        {
            return ConstrainedDelaunayTriangulation2_EEK_MarkDomains(ptr, indices, count);
        }

        internal override void Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            ConstrainedDelaunayTriangulation2_EEK_Transform(ptr, translation, rotation, scale);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConstrainedDelaunayTriangulation2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConstrainedDelaunayTriangulation2_EEK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_SetIndices(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_BuildStamp(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_IsValid(IntPtr ptr, int level);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_VertexCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_FaceCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertPoint(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertPoints(IntPtr ptr, [In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertPolygon(IntPtr triPtr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetIndices(IntPtr ptr, [Out] int[] indices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_GetVertex(IntPtr ptr, int index, [Out] out TriVertex2 vertex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetVertices(IntPtr ptr, [Out] TriVertex2[] vertices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_GetFace(IntPtr ptr, int index, [Out] out TriFace2 triFace);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetFaces(IntPtr ptr, [Out] TriFace2[] faces, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_GetSegment(IntPtr ptr, int faceIndex, int neighbourIndex, [Out] out Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_GetTriangle(IntPtr ptr, int faceIndex, [Out] out Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetTriangles(IntPtr ptr, [Out] Triangle2d[] triangles, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_GetCircumcenter(IntPtr ptr, int faceIndex, [Out] out Point2d circumcenter);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetCircumcenters(IntPtr ptr, [Out] Point2d[] circumcenters, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_NeighbourIndex(IntPtr ptr, int faceIndex, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_LocateFace(IntPtr ptr, Point2d point, [Out] out TriFace2 face);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_MoveVertex(IntPtr ptr, int index, Point2d point, bool ifNoCollision, [Out] out TriVertex2 vertex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_RemoveVertex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_FlipEdge(IntPtr ptr, int faceIndex, int neighbour);

        //Constrained only.

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_ConstrainedEdgesCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EEK_HasIncidentConstraints(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_IncidentConstraintCount(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertSegmentConstraintFromPoints(IntPtr ptr, Point2d a, Point2d b);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertSegmentConstraintFromVertices(IntPtr ptr, int vertIndex1, int vertIndex2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertSegmentConstraints(IntPtr ptr, [In] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetEdgeConstraints(IntPtr ptr, [Out] TriEdge2[] constraints, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetSegmentConstraints(IntPtr ptr, [Out] Segment2d[] constraints, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_GetIncidentConstraints(IntPtr ptr, int vertexIndex, [Out] TriEdge2[] constraints, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_RemoveConstraint(IntPtr ptr, int faceIndex, int neighbourIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_RemoveIncidentConstraints(IntPtr ptr, int vertexIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_GetPolygonIndices(IntPtr ptrTri, IntPtr polyPtr, [Out] int[] indices, int count, ORIENTATION orientation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_GetPolygonWithHolesIndices(IntPtr ptrTri, IntPtr pwhPtr, [Out] int[] indices, int count, ORIENTATION orientation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EEK_MarkDomains(IntPtr ptr, [Out] int[] indices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EEK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

    }
}
