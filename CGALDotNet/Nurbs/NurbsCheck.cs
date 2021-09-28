using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{

	internal static class NurbsCheck
	{

		/// <summary>
		/// Returns the mulitplicity of the knot at index
		/// </summary>
		/// <param name="knots">Knot vector</param>
		/// <param name="index">index Index of knot of interest</param>
		/// <returns>Multiplicity (>= 1)</returns>
		internal static int KnotMultiplicity(IList<double> knots, int index)
		{
			double u = knots[index];

			int mult = 0;
			for (int i = index; i < knots.Count; ++i)
			{
				int idx = index + 1;
				if (CGALGlobal.IsZero(u - knots[idx]))
				{
					++mult;
				}
			}
			return mult;
		}

		/// <summary>
		/// Returns whether the curve is valid
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <returns>Whether valid</returns>
		internal static bool CurveIsValid(BaseNurbsCurve2d crv)
		{
			return CurveIsValid(crv.Degree, crv.Knots, crv.Count);
		}


		/// <summary>
		/// Checks whether the curve is closed
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <returns>Whether closed</returns>
		internal static bool CurveIsClosed(BaseNurbsCurve2d crv)
		{
			if(crv.IsRational)
            {
				var curve = crv as RationalNurbsCurve2d;
				return IsArray1Closed(crv.Degree, curve.HomogeneousControlPoints) &&
						IsKnotVectorClosed(crv.Degree, crv.Knots);
			}
			else
            {
				var curve = crv as NurbsCurve2d;
				return IsArray1Closed(crv.Degree, curve.CartesianControlPoints) &&
					IsKnotVectorClosed(crv.Degree, crv.Knots);
			}

		}


		/// <summary>
		/// Checks if the relation between degree, number of knots, and
		/// number of control points is valid
		/// </summary>
		/// <param name="degree">The degree</param>
		/// <param name="num_knots">Number of knot values</param>
		/// <param name="num_ctrl_pts">Number of control points</param>
		/// <returns>Whether the relationship is valid</returns>
		private static bool IsValidRelation(int degree, int num_knots, int num_ctrl_pts)
		{
			return (num_knots - degree - 1) == num_ctrl_pts;
		}

		/// <summary>
		/// Whether the knots are in ascending order
		/// </summary>
		/// <param name="knots">Knot vector</param>
		/// <returns>Whether monotonic</returns>
		private static bool IsKnotVectorMonotonic(IList<double> knots)
		{
			if (knots.Count <= 1) return true;

			for (int i = 1; i < knots.Count; i++)
			{
				if (knots[i - 1] > knots[i]) return false;
			}

			return true;
		}

		/// <summary>
		/// Returns whether the curve is valid
		/// </summary>
		/// <param name="degree">Degree of curve</param>
		/// <param name="knots">Knot vector of curve</param>
		/// <param name="numControlPoints">The number of control points.</param>
		/// <returns>Whether valid</returns>
		private static bool CurveIsValid(int degree, IList<double> knots, int numControlPoints)
		{
			if (degree < 1 || degree > 9)
				return false;

			if (!IsValidRelation(degree, knots.Count, numControlPoints))
				return false;

			if (!IsKnotVectorMonotonic(knots))
				return false;

			return true;
		}

		/// <summary>
		/// Returns whether the given knot vector is closed by checking the
		/// periodicity of knot vectors near the start and end
		/// </summary>
		/// <param name="degree">Degree of curve/surface</param>
		/// <param name="knots">Knot vector of curve/surface</param>
		/// <returns>Whether knot vector is closed</returns>
		private static bool IsKnotVectorClosed(int degree, IList<double> knots)
		{
			for (int i = 0; i < degree - 1; ++i)
			{
				int j = knots.Count - degree + i;
				if (!CGALGlobal.IsZero((knots[i + 1] - knots[i]) - (knots[j + 1] - knots[j])))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Returns whether the given knot vector is closed by checking the
		/// periodicity of knot vectors near the start and end
		/// </summary>
		/// <param name="degree">Degree of curve/surface</param>
		/// <param name="control_points">Array of any control points</param>
		/// <returns>Whether knot vector is closed</returns>
		private static bool IsArray1Closed(int degree, IList<Point2d> control_points)
		{
			for (int i = 0; i < degree; ++i)
			{
				int j = control_points.Count - degree + i;

				var pi = control_points[i];
				var pj = control_points[j];

				//check the control points
				if (!CGALGlobal.IsZero((pi - pj).Magnitude))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Returns whether the given knot vector is closed by checking the
		/// periodicity of knot vectors near the start and end
		/// </summary>
		/// <param name="degree">Degree of curve/surface</param>
		/// <param name="control_points">Array of any control points</param>
		/// <returns>Whether knot vector is closed</returns>
		private static bool IsArray1Closed(int degree, IList<HPoint2d> control_points)
		{
			for (int i = 0; i < degree; ++i)
			{
				int j = control_points.Count - degree + i;

				var pi = control_points[i].Cartesian;
				var pj = control_points[j].Cartesian;

				//check the weights
				if (!CGALGlobal.IsZero(control_points[i].w - control_points[j].w))
					return false;

				//check the control points
				if (!CGALGlobal.IsZero((pi - pj).Magnitude))
					return false;
			}
			return true;
		}

	}

}

