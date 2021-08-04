using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    public static class ConformingTriangulation
    {

        public static void MakeConforming(Point2d[] points, int startIndex, int count)
        {
            ConformingTriangulation2_EEK_MakeConforming(points, startIndex, count);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ConformingTriangulation2_EEK_MakeConforming([In] Point2d[] points, int startIndex, int count);
    }
}
