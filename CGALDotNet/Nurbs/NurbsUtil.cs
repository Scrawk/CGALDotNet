using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{
	internal static class NurbsUtil
	{

        /// <summary>
        /// Create a shallow copy of the array.
        /// </summary>
        /// <typeparam name="T">The arrays type</typeparam>
        /// <param name="array">The array to copy.</param>
        /// <returns>The copied array</returns>
        public static T[] Copy<T>(T[] array)
        {
            var dest = new T[array.Length];
            Array.Copy(array, dest, array.Length);
            return dest;
        }

        /// <summary>
        /// Create a shallow copy of the array.
        /// </summary>
        /// <typeparam name="T">The arrays type</typeparam>
        /// <param name="array">The array to copy.</param>
        /// <returns>The copied array</returns>
        public static T[,] Copy<T>(T[,] array)
        {
            var dest = new T[array.GetLength(0), array.GetLength(1)];
            Array.Copy(array, dest, array.Length);
            return dest;
        }

        /// <summary>
        /// Create a shallow copy of the array.
        /// </summary>
        /// <typeparam name="T">The arrays type</typeparam>
        /// <param name="array">The array to copy.</param>
        /// <returns>The copied array</returns>
        public static T[,,] Copy<T>(T[,,] array)
        {
            var dest = new T[array.GetLength(0), array.GetLength(1), array.GetLength(2)];
            Array.Copy(array, dest, array.Length);
            return dest;
        }

        /// <summary>
        /// Add the item to the list a number of times.
        /// </summary>
        /// <typeparam name="T">The lists type</typeparam>
        /// <param name="list">The list to add to.</param>
        /// <param name="count">The number of items to added</param>
        /// <param name="item">The item to add.</param>
        public static void AddRange<T>(List<T> list, int count, T item)
        {
            for (int i = 0; i < count; i++)
                list.Add(item);
        }

        /// <summary>
        /// Compute the binomial coefficient
        /// </summary>
        internal static uint Binomial(int n, int k)
		{
			uint result = 1;
			if (k > n)
			{
				return 0;
			}
			for (uint i = 1; i <= k; ++i)
			{
				result *= ((uint)n + 1 - i);
				result /= i;
			}

			return result;
		}

		/// <summary>
		/// Map numbers from one interval to another
		/// </summary>
		internal static double MapToRange(double val, double old_min, double old_max, double new_min, double new_max)
		{
			double old_range = old_max - old_min;
			double new_range = new_max - new_min;
			return (((val - old_min) * new_range) / old_range) + new_min;
		}

	}

}

