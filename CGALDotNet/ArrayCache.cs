using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet
{
    /// <summary>
    /// Cache to reuse arrays.
    /// Thread safe?
    /// </summary>
    public class ArrayCache
    {
        [ThreadStatic]
        private static Point2d[] m_points2d;

        [ThreadStatic]
        private static Segment2d[] m_segments2d;

        [ThreadStatic]
        private static Point3d[] m_points3d;

        [ThreadStatic]
        private static HPoint3d[] m_hpoints3d;

        [ThreadStatic]
        private static int[] m_int;

        public void Clear()
        {
            m_points2d = null;
            m_segments2d = null;
            m_points3d = null;
            m_hpoints3d = null;
            m_int = null;
        }

        /// <summary>
        /// Returns a array of Point2d objects that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <returns>Returns a array of Point2d objects that is at least the size of count.</returns>
        public static Point2d[] Point2dArray(int count)
        {
            if(m_points2d == null || m_points2d.Length < count)
                m_points2d = new Point2d[count];

            return m_points2d;
        }

        /// <summary>
        /// Returns a array of Segment2d objects that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <returns>Returns a array of Segment2d objects that is at least the size of count.</returns>
        public static Segment2d[] Segment2dArray(int count)
        {
            if (m_segments2d == null || m_segments2d.Length < count)
                m_segments2d = new Segment2d[count];

            return m_segments2d;
        }

        /// <summary>
        /// Returns a array of Point3d objects that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <returns>Returns a array of Point3d objects that is at least the size of count.</returns>
        public static Point3d[] Point3dArray(int count)
        {
            if (m_points3d == null || m_points3d.Length < count)
                m_points3d = new Point3d[count];

            return m_points3d;
        }

        /// <summary>
        /// Returns a array of HPoint3d objects that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <returns>Returns a array of HPoint3d objects that is at least the size of count.</returns>
        public static HPoint3d[] HPoint3dArray(int count)
        {
            if (m_hpoints3d == null || m_hpoints3d.Length < count)
                m_hpoints3d = new HPoint3d[count];

            return m_hpoints3d;
        }

        /// <summary>
        /// Returns a array of ints that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <returns>Returns a array of ints that is at least the size of count.</returns>
        public static int[] IntArray(int count)
        {
            if (m_int == null || m_int.Length < count)
                m_int = new int[count];

            return m_int;
        }

    }
}
