using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Meshing
{
    internal class SurfaceMesherKernel3_EIK : SurfaceMesherKernel3
    {
        internal static readonly SurfaceMesherKernel3_EIK Instance = new SurfaceMesherKernel3_EIK();

        internal override int VertexCount()
        {
            return SurfaceMesher3_EIK_VertexCount();
        }

        internal override int TriangleCount()
        {
            return SurfaceMesher3_EIK_TriangleCount();
        }

        internal override void ClearMesh()
        {
            SurfaceMesher3_EIK_ClearMesh();
        }

        internal override Point3d GetPoint(int i)
        {
            return SurfaceMesher3_EIK_GetPoint(i);
        }

        internal override TriangleIndex GetTriangle(int i)
        {
            return SurfaceMesher3_EIK_GetTriangle(i);
        }

        internal override void Generate(double angularBound, double radiusBound, double distanceBound, double radius)
        {
            SurfaceMesher3_EIK_Generate(angularBound, radiusBound, distanceBound, radius);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesher3_EIK_VertexCount();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int SurfaceMesher3_EIK_TriangleCount();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesher3_EIK_ClearMesh();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern Point3d SurfaceMesher3_EIK_GetPoint(int i);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern TriangleIndex SurfaceMesher3_EIK_GetTriangle(int i);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMesher3_EIK_Generate(double angularBound, double radiusBound, double distanceBound, double radius);
    }
}
