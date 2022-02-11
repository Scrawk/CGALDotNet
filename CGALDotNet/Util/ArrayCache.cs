using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet
{
    /// <summary>
    /// Cache to reuse arrays.
    /// Thread safe?
    /// </summary>
    public class ArrayCache
    {
        [ThreadStatic]
        public static bool Disable = false;

        [ThreadStatic]
        private static Point2d[] m_points2d;

        [ThreadStatic]
        private static Segment2d[] m_segments2d;

        [ThreadStatic]
        private static Point3d[] m_points3d;

        [ThreadStatic]
        private static HPoint3d[] m_hpoints3d;

        [ThreadStatic]
        private static int[] m_int1, m_int2;

        public void Clear()
        {
            m_points2d = null;
            m_segments2d = null;
            m_points3d = null;
            m_hpoints3d = null;
            m_int1 = null;
            m_int2 = null;
        }

        /// <summary>
        /// Returns a array of Point2d objects that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <param name="clear">Should the array be cleared first.</param>
        /// <returns>Returns a array of Point2d objects that is at least the size of count.</returns>
        public static Point2d[] Point2dArray(int count, bool clear = false)
        {
            if (MakeNewArray(m_points2d, count))
                m_points2d = new Point2d[count];

            if(clear)
                Array.Clear(m_points3d, 0, m_points3d.Length);

            return m_points2d;
        }

        /// <summary>
        /// Returns a array of Segment2d objects that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <param name="clear">Should the array be cleared first.</param>
        /// <returns>Returns a array of Segment2d objects that is at least the size of count.</returns>
        public static Segment2d[] Segment2dArray(int count, bool clear = false)
        {
            if (MakeNewArray(m_segments2d, count))
                m_segments2d = new Segment2d[count];

            if (clear)
                Array.Clear(m_segments2d, 0, m_segments2d.Length);

            return m_segments2d;
        }

        /// <summary>
        /// Returns a array of Point3d objects that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <param name="clear">Should the array be cleared first.</param>
        /// <returns>Returns a array of Point3d objects that is at least the size of count.</returns>
        public static Point3d[] Point3dArray(int count, bool clear = false)
        {
            if (MakeNewArray(m_points3d, count))
                m_points3d = new Point3d[count];

            if (clear)
                Array.Clear(m_points3d, 0, m_points3d.Length);

            return m_points3d;
        }

        /// <summary>
        /// Returns a array of HPoint3d objects that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <param name="clear">Should the array be cleared first.</param>
        /// <returns>Returns a array of HPoint3d objects that is at least the size of count.</returns>
        public static HPoint3d[] HPoint3dArray(int count, bool clear = false)
        {
            if (MakeNewArray(m_hpoints3d, count))
                m_hpoints3d = new HPoint3d[count];

            if (clear)
                Array.Clear(m_hpoints3d, 0, m_hpoints3d.Length);

            return m_hpoints3d;
        }

        /// <summary>
        /// Returns a array of ints that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <param name="clear">Should the array be cleared first.</param>
        /// <returns>Returns a array of ints that is at least the size of count.</returns>
        public static int[] IntArray1(int count, bool clear = false)
        {
            if (MakeNewArray(m_int1, count))
                m_int1 = new int[count];

            if (clear)
                Array.Clear(m_int1, 0, m_int1.Length);

            return m_int1;
        }

        /// <summary>
        /// Returns a array of ints that is at least the size of count.
        /// </summary>
        /// <param name="count">The minimum size of the array.</param>
        /// <param name="clear">Should the array be cleared first.</param>
        /// <returns>Returns a array of ints that is at least the size of count.</returns>
        public static int[] IntArray2(int count, bool clear = false)
        {
            if (MakeNewArray(m_int2, count))
                m_int2 = new int[count];

            if (clear)
                Array.Clear(m_int2, 0, m_int2.Length);

            return m_int2;
        }

        /// <summary>
        /// Should a new array be created.
        /// </summary>
        /// <param name="arr">The current array.</param>
        /// <param name="count">The required new array size.</param>
        /// <returns>Creates a new array if disabled, the current one is null or to small.</returns>
        private static bool MakeNewArray(Array arr, int count)
        {
            return (Disable || arr == null || arr.Length < count);
        }

    }
}
