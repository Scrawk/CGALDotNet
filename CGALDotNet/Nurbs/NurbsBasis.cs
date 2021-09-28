using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{

	internal static class NurbsBasis
	{

		/// <summary>
		/// Find the span of the given parameter in the knot vector.
		/// </summary>
		/// <param name="degree">Degree of the curve.</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="u">Parameter value.</param>
		/// <returns>Span index into the knot vector such that (span - 1) less than u less tha or equal span</returns>
		internal static int FindSpan(int degree, IList<double> knots, double u)
		{
			// index of last control point
			int n = knots.Count - degree - 2;
			double eps = 1e-9f;

			// For values of u that lies outside the domain
			if (u > (knots[n + 1] - eps))
				return n;

			if (u < (knots[degree] + eps))
				return degree;

			// Binary search

			int low = degree;
			int high = n + 1;
			int mid = (int)Math.Floor((low + high) / 2.0);

			while (u < knots[mid] || u >= knots[mid + 1])
			{
				if (u < knots[mid])
					high = mid;
				else
					low = mid;

				mid = (int)Math.Floor((low + high) / 2.0);
			}

			return mid;
		}

		/// <summary>
		/// Compute all non-zero B-spline basis functions
		/// </summary>
		/// <param name="deg">Degree of the basis function.</param>
		/// <param name="knots">Knot vector corresponding to the basis functions.</param>
		/// <param name="u">Parameter to evaluate the basis functions at.</param>
		/// <returns>N Values of (deg+1) non-zero basis functions.</returns>
		internal static double[] BSplineBasis(int deg, int span, IList<double> knots, double u)
		{
			var N = new double[deg + 1];
			var left = new double[deg + 1];
			var right = new double[deg + 1];

			double saved = 0.0, temp = 0.0;

			N[0] = 1.0;

			for (int j = 1; j <= deg; j++)
			{
				left[j] = (u - knots[span + 1 - j]);
				right[j] = knots[span + j] - u;
				saved = 0.0;

				for (int r = 0; r < j; r++)
				{
					temp = N[r] / (right[r + 1] + left[j - r]);
					N[r] = saved + right[r + 1] * temp;
					saved = left[j - r] * temp;
				}

				N[j] = saved;
			}

			return N;
		}

	}

}

