using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Geometry2.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct TriangleIndex
    {
        public int A, B, C;
    }
}
