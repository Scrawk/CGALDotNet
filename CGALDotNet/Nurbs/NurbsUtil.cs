using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{
	internal static class NurbsUtil
	{
		/// <summary>
		/// Convert an nd point in homogenous coordinates to an (n-1)d point in cartesian
		/// coordinates by perspective division
		/// </summary>
		/// <param name="pt">Point in homogenous coordinates</param>
		/// <returns>Point in cartesian coordinates</returns>
		internal static Vector2d HomogenousToCartesian(Vector3d pt)
		{
			return pt.xy / pt.z;
		}


		/// <summary>
		/// Convert an nd point in homogenous coordinates to an (n-1)d point in cartesian
		/// coordinates by perspective division
		/// </summary>
		/// <param name="pt">Point in homogenous coordinates</param>
		/// <returns>Point in cartesian coordinates</returns>
		internal static Vector3d HomogenousToCartesian(Vector4d pt)
		{
			return pt.xyz / pt.w;
		}

		/// <summary>
		/// Convert an nd point in cartesian coordinates to an (n+1)d point in homogenous coordinates
		/// </summary>
		/// <param name="pt">Point in cartesian coordinates</param>
		/// <param name="w">Weight</param>
		/// <returns>point in homogenous coordinates</returns>
		internal static Vector3d CartesianToHomogenous(Vector2d pt, double w)
		{
			return new Vector3d(pt * w, w);
		}

		/// <summary>
		/// Convert an nd point in cartesian coordinates to an (n+1)d point in homogenous coordinates
		/// </summary>
		/// <param name="pt">Point in cartesian coordinates</param>
		/// <param name="w">Weight</param>
		/// <returns>point in homogenous coordinates</returns>
		internal static Vector4d CartesianToHomogenous(Vector3d pt, double w)
		{
			return new Vector4d(pt * w, w);
		}

		/// <summary>
		/// Convert an (n+1)d point to an nd point without perspective division
		/// by truncating the last dimension
		/// </summary>
		/// <param name="pt">Point in homogenous coordinates</param>
		/// <returns>Input point in cartesian coordinates</returns>
		internal static Vector2d TruncateHomogenous(Vector3d pt)
		{
			return pt.xy;
		}

		/// <summary>
		/// Convert an (n+1)d point to an nd point without perspective division
		/// by truncating the last dimension
		/// </summary>
		/// <param name="pt">Point in homogenous coordinates</param>
		/// <returns>Input point in cartesian coordinates</returns>
		internal static Vector3d TruncateHomogenous(Vector4d pt)
		{
			return pt.xyz;
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

