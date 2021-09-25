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
		internal static Point2d HomogenousToCartesian(HPoint2d pt)
		{
			return pt.Cartesian;
		}


		/// <summary>
		/// Convert an nd point in homogenous coordinates to an (n-1)d point in cartesian
		/// coordinates by perspective division
		/// </summary>
		/// <param name="pt">Point in homogenous coordinates</param>
		/// <returns>Point in cartesian coordinates</returns>
		internal static Point3d HomogenousToCartesian(HPoint3d pt)
		{
			return pt.Cartesian;
		}

		/// <summary>
		/// Convert an nd point in cartesian coordinates to an (n+1)d point in homogenous coordinates
		/// </summary>
		/// <param name="pt">Point in cartesian coordinates</param>
		/// <param name="w">Weight</param>
		/// <returns>point in homogenous coordinates</returns>
		internal static HPoint2d CartesianToHomogenous(Point2d pt, double w)
		{
			return new HPoint2d(pt.x * w, pt.y * w, w);
		}

		/// <summary>
		/// Convert an nd point in cartesian coordinates to an (n+1)d point in homogenous coordinates
		/// </summary>
		/// <param name="pt">Point in cartesian coordinates</param>
		/// <param name="w">Weight</param>
		/// <returns>point in homogenous coordinates</returns>
		internal static HPoint3d CartesianToHomogenous(Point3d pt, double w)
		{
			return new HPoint3d(pt.x * w, pt.y * w, pt.z * w, w);
		}

		/// <summary>
		/// Convert an (n+1)d point to an nd point without perspective division
		/// by truncating the last dimension
		/// </summary>
		/// <param name="pt">Point in homogenous coordinates</param>
		/// <returns>Input point in cartesian coordinates</returns>
		internal static Point2d TruncateHomogenous(HPoint2d pt)
		{
			return new Point2d(pt.x, pt.y);
		}

		/// <summary>
		/// Convert an (n+1)d point to an nd point without perspective division
		/// by truncating the last dimension
		/// </summary>
		/// <param name="pt">Point in homogenous coordinates</param>
		/// <returns>Input point in cartesian coordinates</returns>
		internal static Point3d TruncateHomogenous(HPoint3d pt)
		{
			return new Point3d(pt.x, pt.y, pt.z);
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

