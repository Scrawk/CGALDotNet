using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet
{
    internal static class ErrorUtil
    {

        internal static void CheckBounds(int index, int count)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");
        }

        internal static void CheckBounds(Point2d[] points, int index, int count)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");

            if (index >= points.Length)
                throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");
        }
    }
}
