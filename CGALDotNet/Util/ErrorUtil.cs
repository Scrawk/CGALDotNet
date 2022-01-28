using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet
{
    internal static class ErrorUtil
    {
        /// <summary>
        /// Check a array that is passed to the c++ dll.
        /// If the array is invalid it will cause a hard crash.
        /// Array can be null if count is 0;
        /// </summary>
        /// <param name="array"></param>
        /// <param name="count"></param>
        internal static void CheckArray(Array array, int count)
        {
            if (array == null && count == 0)
                return;

            if(array == null)
                throw new InvalidArrayExeception("Array is null.");

            if (count < 0)
                throw new InvalidArrayExeception("Count must be >= zero.");

            if (array.Length < count)
                throw new InvalidArrayExeception("Array length is less than count.");
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

    public class CGALUnmanagedResourcesNotReleasedExeception : Exception
    {
        public CGALUnmanagedResourcesNotReleasedExeception()
        {
        }

        public CGALUnmanagedResourcesNotReleasedExeception(string message)
            : base(message)
        {
        }

        public CGALUnmanagedResourcesNotReleasedExeception(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InvalidArrayExeception : Exception
    {
        public InvalidArrayExeception()
        {
        }

        public InvalidArrayExeception(string message)
            : base(message)
        {
        }

        public InvalidArrayExeception(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
