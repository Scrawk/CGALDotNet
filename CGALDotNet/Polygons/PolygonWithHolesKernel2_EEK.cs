using CGALDotNetGeometry.Numerics;
using System;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonWithHolesKernel2_EEK : PolygonWithHolesKernel2
    {
        internal override string Name => "EEK";

        internal static readonly PolygonWithHolesKernel2_EEK Instance = new PolygonWithHolesKernel2_EEK();

        internal override IntPtr Create()
        {
            return PolygonWithHoles2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonWithHoles2_EEK_Release(ptr);
        }

        internal override int HoleCount(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_HoleCount(ptr);
        }

        internal override int PointCount(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_PointCount(ptr, index);
        }

        internal override IntPtr Copy(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_Copy(ptr);
        }

        internal override IntPtr Convert(IntPtr ptr, CGAL_KERNEL k)
        {
            return PolygonWithHoles2_EEK_Convert(ptr, k);   
        }

        internal override void Clear(IntPtr ptr)
        {
            PolygonWithHoles2_EEK_Clear(ptr);
        }

        internal override void ClearBoundary(IntPtr ptr)
        {
            PolygonWithHoles2_EEK_ClearBoundary(ptr);
        }

        internal override void ClearHoles(IntPtr ptr)
        {
            PolygonWithHoles2_EEK_ClearHoles(ptr);
        }

        internal override IntPtr CreateFromPolygon(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_CreateFromPolygon(ptr);
        }

        internal override IntPtr CreateFromPoints(Point2d[] points, int count)
        {
            return PolygonWithHoles2_EEK_CreateFromPoints(points, count);
        }

        internal override Point2d GetPoint(IntPtr ptr, int polyIndex, int pointIndex)
        {
            return PolygonWithHoles2_EEK_GetPoint(ptr, polyIndex, pointIndex);
        }

        internal override void GetPoints(IntPtr ptr, Point2d[] points, int polyIndex, int count)
        {
            PolygonWithHoles2_EEK_GetPoints(ptr, points, polyIndex, count);
        }

        internal override void SetPoint(IntPtr ptr, int polyIndex, int pointIndex, Point2d point)
        {
            PolygonWithHoles2_EEK_SetPoint(ptr, polyIndex, pointIndex, point);
        }

        internal override void SetPoints(IntPtr ptr, Point2d[] points, int polyIndex, int count)
        {
            PolygonWithHoles2_EEK_SetPoints(ptr, points, polyIndex, count);
        }

        internal override void AddHoleFromPolygon(IntPtr pwhPtr, IntPtr polygonPtr)
        {
            PolygonWithHoles2_EEK_AddHoleFromPolygon(pwhPtr, polygonPtr);
        }

        internal override void AddHoleFromPoints(IntPtr ptr, Point2d[] points, int count)
        {
            PolygonWithHoles2_EEK_AddHoleFromPoints(ptr, points, count);
        }

        internal override void RemoveHole(IntPtr ptr, int index)
        {
            PolygonWithHoles2_EEK_RemoveHole(ptr, index);
        }

        internal override IntPtr CopyPolygon(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_CopyPolygon(ptr, index);
        }

        internal override void ReversePolygon(IntPtr ptr, int index)
        {
            PolygonWithHoles2_EEK_ReversePolygon(ptr, index);
        }

        internal override bool IsUnbounded(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_IsUnbounded(ptr);
        }

        internal override Box2d GetBoundingBox(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_GetBoundingBox(ptr, index);
        }

        internal override bool IsSimple(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_IsSimple(ptr, index);
        }

        internal override bool IsConvex(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_IsConvex(ptr, index);
        }

        internal override ORIENTATION Orientation(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_Orientation(ptr, index);
        }

        internal override ORIENTED_SIDE OrientedSide(IntPtr ptr, int index, Point2d point)
        {
            return PolygonWithHoles2_EEK_OrientedSide(ptr, index, point);
        }

        internal override double SignedArea(IntPtr ptr, int index)
        {
            return PolygonWithHoles2_EEK_SignedArea(ptr, index);
        }

        internal override void Translate(IntPtr ptr, int index, Point2d translation)
        {
            PolygonWithHoles2_EEK_Translate(ptr, index, translation);
        }

        internal override void Rotate(IntPtr ptr, int index, double rotation)
        {
            PolygonWithHoles2_EEK_Rotate(ptr, index, rotation);
        }

        internal override void Scale(IntPtr ptr, int index, double scale)
        {
            PolygonWithHoles2_EEK_Scale(ptr, index, scale);
        }

        internal override void Transform(IntPtr ptr, int index, Point2d translation, double rotation, double scale)
        {
            PolygonWithHoles2_EEK_Transform(ptr, index, translation, rotation, scale);
        }

        internal override bool ContainsPoint(IntPtr ptr, Point2d point, ORIENTATION orientation, bool inculdeBoundary)
        {
            return PolygonWithHoles2_EEK_ContainsPoint(ptr, point, orientation, inculdeBoundary);
        }

        internal override IntPtr ConnectHoles(IntPtr ptr)
        {
            return PolygonWithHoles2_EEK_ConnectHoles(ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonWithHoles2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonWithHoles2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonWithHoles2_EEK_HoleCount(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonWithHoles2_EEK_PointCount(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonWithHoles2_EEK_Copy(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonWithHoles2_EEK_Convert(IntPtr ptr, CGAL_KERNEL k);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_Clear(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_ClearBoundary(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_ClearHoles(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonWithHoles2_EEK_CreateFromPolygon(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonWithHoles2_EEK_CreateFromPoints(Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point2d PolygonWithHoles2_EEK_GetPoint(IntPtr ptr, int polyIndex, int pointIndex);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_GetPoints(IntPtr ptr, [Out] Point2d[] points, int polyIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_SetPoint(IntPtr ptr, int polyIndex, int pointIndex, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_SetPoints(IntPtr ptr, Point2d[] points, int polyIndex, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_AddHoleFromPolygon(IntPtr pwhPtr, IntPtr polygonPtr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_AddHoleFromPoints(IntPtr ptr, Point2d[] points, int count);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_RemoveHole(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonWithHoles2_EEK_CopyPolygon(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_ReversePolygon(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonWithHoles2_EEK_IsUnbounded(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Box2d PolygonWithHoles2_EEK_GetBoundingBox(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonWithHoles2_EEK_IsSimple(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonWithHoles2_EEK_IsConvex(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTATION PolygonWithHoles2_EEK_Orientation(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern ORIENTED_SIDE PolygonWithHoles2_EEK_OrientedSide(IntPtr ptr, int index, Point2d point);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double PolygonWithHoles2_EEK_SignedArea(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_Translate(IntPtr ptr, int index, Point2d translation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_Rotate(IntPtr ptr, int index, double rotation);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_Scale(IntPtr ptr, int index, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonWithHoles2_EEK_Transform(IntPtr ptr, int index, Point2d translation, double rotation, double scale);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonWithHoles2_EEK_ContainsPoint(IntPtr ptr, Point2d point, ORIENTATION orientation,bool inculdeBoundary);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonWithHoles2_EEK_ConnectHoles(IntPtr ptr);
    }
}
