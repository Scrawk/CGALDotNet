using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet
{
    internal static class ErrorUtil
    {

        internal static void CheckBounds(int index, int count)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");
        }

        internal static void CheckBounds(Array array, int index, int count)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");

            if (index >= array.Length)
                throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.");
        }
    }

    public class CGALUnmanagedResourcesReleasedExeception : Exception
    {
        public CGALUnmanagedResourcesReleasedExeception()
        {
        }

        public CGALUnmanagedResourcesReleasedExeception(string message)
            : base(message)
        {
        }

        public CGALUnmanagedResourcesReleasedExeception(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
