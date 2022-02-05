using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNetGeometry.Numerics
{
    /// <summary>
    /// WARNING - Must match layout of unmanaged c++ CGAL struct in Index.h file.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Index2
    {
        public int first, second;

        public override string ToString()
        {
            return string.Format("[Index2: first={0}, second={1}]", first, second);
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Index3
    {
        public int first, second, third;

        public override string ToString()
        {
            return string.Format("[Index3: first={0}, second={1}, third={2}]", first, second, third);
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Index4
    {
        public int first, second, third, fourth;

        public override string ToString()
        {
            return string.Format("[Index4: first={0}, second={1}, third={2}, forth={3}]", first, second, third, fourth);
        }
    }
}
