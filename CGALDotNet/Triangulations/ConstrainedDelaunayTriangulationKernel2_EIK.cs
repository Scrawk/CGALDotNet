using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Triangulations
{
    internal class ConstrainedDelaunayTriangulationKernel2_EIK : ConstrainedDelaunayTriangulationKernel2
    {
        internal override string Name => "EIK";

        internal static readonly ConstrainedDelaunayTriangulationKernel2 Instance = new ConstrainedDelaunayTriangulationKernel2_EIK();

        internal override IntPtr Create()
        {
            return ConstrainedDelaunayTriangulation2_EIK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            ConstrainedDelaunayTriangulation2_EIK_Release(ptr);
        }

        internal override void Clear(IntPtr ptr)
        {
            ConstrainedDelaunayTriangulation2_EIK_Clear(ptr);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EIK_Copy(ptr);
        }

        internal override void SetIndices(IntPtr ptr)
        {
            ConstrainedDelaunayTriangulation2_EIK_SetIndices(ptr);
        }

        internal override int BuildStamp(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EIK_BuildStamp(ptr);
        }

        internal override bool IsValid(IntPtr ptr, int level)
        {
            return ConstrainedDelaunayTriangulation2_EIK_IsValid(ptr, level);
        }

        internal override int VertexCount(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EIK_VertexCount(ptr);
        }

        internal override int FaceCount(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EIK_FaceCount(ptr);
        }

        internal override void InsertPoint(IntPtr ptr, Point2d point)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertPoint(ptr, point);
        }

        internal override void InsertPoints(IntPtr ptr, Point2d[] points, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertPoints(ptr, points, count);
        }

        internal override void InsertPolygon(IntPtr triPtr, IntPtr polyPtr)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertPolygon(triPtr, polyPtr);
        }

        internal override void InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertPolygonWithHoles(triPtr, pwhPtr);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetPoints(ptr, points, count);
        }

        internal override void GetIndices(IntPtr ptr, int[] indices, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetIndices(ptr, indices, count);
        }

        internal override bool GetVertex(IntPtr ptr, int index, out TriVertex2 vertex)
        {
            return ConstrainedDelaunayTriangulation2_EIK_GetVertex(ptr, index, out vertex);
        }

        internal override void GetVertices(IntPtr ptr, TriVertex2[] vertices, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetVertices(ptr, vertices, count);
        }

        internal override bool GetFace(IntPtr ptr, int index, out TriFace2 face)
        {
            return ConstrainedDelaunayTriangulation2_EIK_GetFace(ptr, index, out face);
        }

        internal override void GetFaces(IntPtr ptr, TriFace2[] faces, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetFaces(ptr, faces, count);
        }

        internal override bool GetSegment(IntPtr ptr, int faceIndex, int neighbourIndex, out Segment2d segment)
        {
            return ConstrainedDelaunayTriangulation2_EIK_GetSegment(ptr, faceIndex, neighbourIndex, out segment);
        }

        internal override bool GetTriangle(IntPtr ptr, int faceIndex, out Triangle2d triangle)
        {
            return ConstrainedDelaunayTriangulation2_EIK_GetTriangle(ptr, faceIndex, out triangle);
        }

        internal override void GetTriangles(IntPtr ptr, Triangle2d[] triangles, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetTriangles(ptr, triangles, count);
        }

        internal override bool GetCircumcenter(IntPtr ptr, int faceIndex, out Point2d circumcenter)
        {
            return ConstrainedDelaunayTriangulation2_EIK_GetCircumcenter(ptr, faceIndex, out circumcenter);
        }

        internal override void GetCircumcenters(IntPtr ptr, [Out] Point2d[] circumcenters, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetCircumcenters(ptr, circumcenters, count);
        }

        internal override int NeighbourIndex(IntPtr ptr, int faceIndex, int index)
        {
            return ConstrainedDelaunayTriangulation2_EIK_NeighbourIndex(ptr, faceIndex, index);
        }

        internal override bool LocateFace(IntPtr ptr, Point2d point, out TriFace2 face)
        {
            return ConstrainedDelaunayTriangulation2_EIK_LocateFace(ptr, point, out face);
        }

        internal override bool MoveVertex(IntPtr ptr, int index, Point2d point, bool ifNoCollision, out TriVertex2 vertex)
        {
            return ConstrainedDelaunayTriangulation2_EIK_MoveVertex(ptr, index, point, ifNoCollision, out vertex);
        }

        internal override bool RemoveVertex(IntPtr ptr, int index)
        {
            return ConstrainedDelaunayTriangulation2_EIK_RemoveVertex(ptr, index);
        }

        internal override bool FlipEdge(IntPtr ptr, int faceIndex, int neighbour)
        {
            return ConstrainedDelaunayTriangulation2_EIK_FlipEdge(ptr, faceIndex, neighbour);
        }

        //Constrained only.

        internal override int ConstrainedEdgesCount(IntPtr ptr)
        {
            return ConstrainedDelaunayTriangulation2_EIK_ConstrainedEdgesCount(ptr);
        }

        internal override bool HasIncidentConstraints(IntPtr ptr, int index)
        {
            return ConstrainedDelaunayTriangulation2_EIK_HasIncidentConstraints(ptr, index);
        }

        internal override int IncidentConstraintCount(IntPtr ptr, int index)
        {
            return ConstrainedDelaunayTriangulation2_EIK_IncidentConstraintCount(ptr, index);
        }

        internal override void InsertSegmentConstraintFromPoints(IntPtr ptr, Point2d a, Point2d b)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertSegmentConstraintFromPoints(ptr, a, b);
        }

        internal override void InsertSegmentConstraintFromVertices(IntPtr ptr, int vertIndex1, int vertIndex2)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertSegmentConstraintFromVertices(ptr, vertIndex1, vertIndex2);
        }

        internal override void InsertSegmentConstraints(IntPtr ptr, Segment2d[] segments, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertSegmentConstraints(ptr, segments, count);
        }

        internal override void InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertPolygonConstraint(triPtr, polyPtr);
        }

        internal override void InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr)
        {
            ConstrainedDelaunayTriangulation2_EIK_InsertPolygonWithHolesConstraint(triPtr, pwhPtr);
        }

        internal override void GetConstraints(IntPtr ptr, TriEdge2[] constraints, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetEdgeConstraints(ptr, constraints, count);
        }

        internal override void GetConstraints(IntPtr ptr, Segment2d[] constraints, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetSegmentConstraints(ptr, constraints, count);
        }

        internal override void GetIncidentConstraints(IntPtr ptr, int vertexIndex, TriEdge2[] constraints, int count)
        {
            ConstrainedDelaunayTriangulation2_EIK_GetIncidentConstraints(ptr, vertexIndex, constraints, count);
        }

        internal override void RemoveConstraint(IntPtr ptr, int faceIndex, int neighbourIndex)
        {
            ConstrainedDelaunayTriangulation2_EIK_RemoveConstraint(ptr, faceIndex, neighbourIndex);
        }

        internal override void RemoveIncidentConstraints(IntPtr ptr, int vertexIndex)
        {
            ConstrainedDelaunayTriangulation2_EIK_RemoveIncidentConstraints(ptr, vertexIndex);
        }

        internal override int MarkDomains(IntPtr ptr, int[] indices, int count)
        {
            return ConstrainedDelaunayTriangulation2_EIK_MarkDomains(ptr, indices, count);
        }

        internal override void Transform(IntPtr ptr, Point2d translation, double rotation, double scale)
        {
            ConstrainedDelaunayTriangulation2_EIK_Transform(ptr, translation, rotation, scale);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConstrainedDelaunayTriangulation2_EIK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr ConstrainedDelaunayTriangulation2_EIK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_SetIndices(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_BuildStamp(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_IsValid(IntPtr ptr, int level);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_VertexCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_FaceCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertPoint(IntPtr ptr, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertPoints(IntPtr ptr, [In] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertPolygon(IntPtr triPtr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertPolygonWithHoles(IntPtr triPtr, IntPtr pwhPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetIndices(IntPtr ptr, [Out] int[] indices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_GetVertex(IntPtr ptr, int index, [Out] out TriVertex2 vertex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetVertices(IntPtr ptr, [Out] TriVertex2[] vertices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_GetFace(IntPtr ptr, int index, [Out] out TriFace2 triFace);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetFaces(IntPtr ptr, [Out] TriFace2[] faces, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_GetSegment(IntPtr ptr, int faceIndex, int neighbourIndex, [Out] out Segment2d segment);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_GetTriangle(IntPtr ptr, int faceIndex, [Out] out Triangle2d triangle);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetTriangles(IntPtr ptr, [Out] Triangle2d[] triangles, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_GetCircumcenter(IntPtr ptr, int faceIndex, [Out] out Point2d circumcenter);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetCircumcenters(IntPtr ptr, [Out] Point2d[] circumcenters, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_NeighbourIndex(IntPtr ptr, int faceIndex, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_LocateFace(IntPtr ptr, Point2d point, [Out] out TriFace2 face);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_MoveVertex(IntPtr ptr, int index, Point2d point, bool ifNoCollision, [Out] out TriVertex2 vertex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_RemoveVertex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_FlipEdge(IntPtr ptr, int faceIndex, int neighbour);

        //Constrained only.

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_ConstrainedEdgesCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool ConstrainedDelaunayTriangulation2_EIK_HasIncidentConstraints(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_IncidentConstraintCount(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertSegmentConstraintFromPoints(IntPtr ptr, Point2d a, Point2d b);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertSegmentConstraintFromVertices(IntPtr ptr, int vertIndex1, int vertIndex2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertSegmentConstraints(IntPtr ptr, [In] Segment2d[] segments, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertPolygonConstraint(IntPtr triPtr, IntPtr polyPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_InsertPolygonWithHolesConstraint(IntPtr triPtr, IntPtr pwhPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetEdgeConstraints(IntPtr ptr, [Out] TriEdge2[] constraints, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetSegmentConstraints(IntPtr ptr, [Out] Segment2d[] constraints, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_GetIncidentConstraints(IntPtr ptr, int vertexIndex, [Out] TriEdge2[] constraints, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_RemoveConstraint(IntPtr ptr, int faceIndex, int neighbourIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_RemoveIncidentConstraints(IntPtr ptr, int vertexIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_GetPolygonIndices(IntPtr ptrTri, IntPtr polyPtr, [Out] int[] indices, int count, ORIENTATION orientation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_GetPolygonWithHolesIndices(IntPtr ptrTri, IntPtr pwhPtr, [Out] int[] indices, int count, ORIENTATION orientation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int ConstrainedDelaunayTriangulation2_EIK_MarkDomains(IntPtr ptr, [Out] int[] indices, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void ConstrainedDelaunayTriangulation2_EIK_Transform(IntPtr ptr, Point2d translation, double rotation, double scale);

    }
}
