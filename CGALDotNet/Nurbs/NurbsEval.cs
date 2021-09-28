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

		/// <summary>
		/// Evaluate the tangent of a B-spline curve
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <returns>Unit tangent of the curve at u.</returns>
		internal static Vector2d CurveTangent(BaseNurbsCurve2d crv, double u)
		{
			var ders = CurveDerivatives(crv, 1, u);
			return ders[1].Normalized;
		}

		/// <summary>
		/// Evaluate the tangent of a B-spline curve
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="ccw">Shouuld the normal be counter clock-wise to the tangent or clock-wise</param>
		/// <returns>Unit tangent of the curve at u.</returns>
		internal static Vector2d CurveNormal(BaseNurbsCurve2d crv, double u, bool ccw)
		{
			var ders = CurveDerivatives(crv, 1, u);

			if (ccw)
				return ders[1].Normalized.PerpendicularCCW;
			else
				return ders[1].Normalized.PerpendicularCW;
		}

		/// <summary>
		/// Evaluate derivatives of a non-rational NURBS curve
		/// E.g. curve_ders[n] is the nth derivative at u, where 0 less than n less than or equal num_ders.
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="num_ders">Number of times to derivate.</param>
		/// <param name="u">Parameter to evaluate the derivatives at.</param>
		/// <returns>Derivatives of the curve at u.</returns>
		internal static Vector2d[] CurveDerivatives(BaseNurbsCurve2d crv, int num_ders, double u)
		{
			if (crv.IsRational)
			{ 
				var curve = crv as RationalNurbsCurve2d;
				var Cwders = CurveDerivatives(crv.Degree, crv.Knots, curve.HomogeneousControlPoints, num_ders, u);

				var curve_ders = new Vector2d[num_ders + 1];
				for (int k = 0; k <= num_ders; k++)
					curve_ders[k] = Cwders[k].xy;

				return curve_ders;
			}
			else
			{
				var curve = crv as NurbsCurve2d;
				var Cwders = CurveDerivatives(crv.Degree, crv.Knots, curve.CartesianControlPoints, num_ders, u);

				var curve_ders = new Vector2d[num_ders + 1];
				for (int k = 0; k <= num_ders; k++)
					curve_ders[k] = Cwders[k].xy;

				return curve_ders;
			}
		}

		/// <summary>
		/// Evaluate derivatives of a non-rational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the curve</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve in Homogenous space.</param>
		/// <param name="num_ders">Number of times to derivate.</param>
		/// <param name="u">Parameter to evaluate the derivatives at.</param>
		/// <returns>Derivatives of the curve at u.</returns>
		private static Vector3d[] CurveDerivatives(int degree, IList<double> knots, IList<HPoint2d> control_points, int num_ders, double u)
		{
			var curve_ders = new Vector3d[num_ders + 1];

			// Find the span and corresponding non-zero basis functions & derivatives
			int span = NurbsBasis.FindSpan(degree, knots, u);
			var ders = NurbsBasis.BSplineDerBasis(degree, span, knots, u, num_ders);

			// Compute first num_ders derivatives
			int du = num_ders < degree ? num_ders : degree;
			for (int k = 0; k <= du; k++)
			{
				for (int j = 0; j <= degree; j++)
                {
					var point = control_points[span - degree + j].Cartesian;
					curve_ders[k].x += point.x * ders[k, j];
					curve_ders[k].y += point.y * ders[k, j];
					curve_ders[k].z += 1 * ders[k, j];
				}
			}

			return curve_ders;
		}

		/// <summary>
		/// Evaluate derivatives of a non-rational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the curve</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve in Homogenous space.</param>
		/// <param name="num_ders">Number of times to derivate.</param>
		/// <param name="u">Parameter to evaluate the derivatives at.</param>
		/// <returns>Derivatives of the curve at u.</returns>
		private static Vector3d[] CurveDerivatives(int degree, IList<double> knots, IList<Point2d> control_points, int num_ders, double u)
		{
			var curve_ders = new Vector3d[num_ders + 1];

			// Find the span and corresponding non-zero basis functions & derivatives
			int span = NurbsBasis.FindSpan(degree, knots, u);
			var ders = NurbsBasis.BSplineDerBasis(degree, span, knots, u, num_ders);

			// Compute first num_ders derivatives
			int du = num_ders < degree ? num_ders : degree;
			for (int k = 0; k <= du; k++)
			{
				for (int j = 0; j <= degree; j++)
				{
					curve_ders[k].x += control_points[span - degree + j].x * ders[k, j];
					curve_ders[k].y += control_points[span - degree + j].y * ders[k, j];
					curve_ders[k].z += 1 * ders[k, j];
				}
			}

			return curve_ders;
		}

	}

}

