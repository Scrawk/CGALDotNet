using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{

	internal static class NurbsEval
	{

		/// <summary>
		/// Evaluate point on a nonrational NURBS curve
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="u">Parameter to evaluate the curve at.</param>
		/// <returns>Resulting point on the curve at parameter u.</returns>
		internal static Point2d CartesianCurvePoint(BaseNurbsCurve2d crv, double u)
		{
			if (crv.IsRational)
			{
				var curve = crv as RationalNurbsCurve2d;
				HPoint2d pointw = HomogeneousCurvePoint(crv.Degree, crv.Knots, curve.HomogeneousControlPoints, u);
				return pointw.Cartesian;
			}
			else
			{
				var curve = crv as NurbsCurve2d;
				Point2d point = CartesianCurvePoint(crv.Degree, crv.Knots, curve.CartesianControlPoints, u);
				return point;
			}
		}

		/// Evaluate point on a nonrational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the given curve.</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve in homogenous space.</param>
		/// <param name="u">Parameter to evaluate the curve at.</param>
		/// <returns>Resulting point on the curve at parameter u.</returns>
		private static HPoint2d HomogeneousCurvePoint(int degree, IList<double> knots, IList<HPoint2d> control_points, double u)
		{
			var point = new HPoint2d();

			// Find span and corresponding non-zero basis functions
			int span = NurbsBasis.FindSpan(degree, knots, u);
			var N = NurbsBasis.BSplineBasis(degree, span, knots, u);

			// Compute point
			for (int j = 0; j <= degree; j++)
				point += control_points[span - degree + j] * N[j];

			return point;
		}

		/// Evaluate point on a nonrational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the given curve.</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve in homogenous space.</param>
		/// <param name="u">Parameter to evaluate the curve at.</param>
		/// <returns>Resulting point on the curve at parameter u.</returns>
		private static Point2d CartesianCurvePoint(int degree, IList<double> knots, IList<Point2d> control_points, double u)
		{
			var point = new Point2d();

			// Find span and corresponding non-zero basis functions
			int span = NurbsBasis.FindSpan(degree, knots, u);
			var N = NurbsBasis.BSplineBasis(degree, span, knots, u);

			// Compute point
			for (int j = 0; j <= degree; j++)
				point += control_points[span - degree + j] * N[j];

			return point;
		}

	}

}

