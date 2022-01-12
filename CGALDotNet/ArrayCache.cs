using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet
{
    internal static class ArrayCache
    {

        private static Point2d[] m_points2d;

        private static Segment2d[] m_segments2d;

        private static Point3d[] m_points3d;

        internal static Point2d[] Point2dArray(int count)
        {
            if(m_points2d == null || m_points2d.Length < count)
                m_points2d = new Point2d[count];

            return m_points2d;
        }

        internal static Segment2d[] Segment2dArray(int count)
        {
            if (m_segments2d == null || m_segments2d.Length < count)
                m_segments2d = new Segment2d[count];

            return m_segments2d;
        }

        internal static Point3d[] Point3dArray(int count)
        {
            if (m_points3d == null || m_points3d.Length < count)
                m_points3d = new Point3d[count];

            return m_points3d;
        }

    }
}
