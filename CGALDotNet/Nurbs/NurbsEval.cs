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
		internal static Vector2d CurvePoint(NurbsCurve2d crv, double u)
		{
			if (crv.IsRational)
			{
				// Compute point using homogenous coordinates
				Vector3d pointw = CurvePoint(crv.Degree, crv.Knots, crv.ControlPoints, u);
				// Convert back to cartesian coordinates
				return NurbsUtil.HomogenousToCartesian(pointw);
			}
			else
			{
				// Compute point using homogenous coordinates but since curve is not
				// rational the points xyz position will end up cartesian.
				Vector3d pointw = CurvePoint(crv.Degree, crv.Knots, crv.ControlPoints, u);
				return pointw.xy;
			}
		}

		/// <summary>
		/// Evaluate point on a nonrational NURBS curve
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="u">Parameter to evaluate the curve at.</param>
		/// <returns>Resulting point on the curve at parameter u.</returns>
		internal static Vector3d CurvePoint(NurbsCurve3d crv, double u)
		{
			if (crv.IsRational)
			{
				// Compute point using homogenous coordinates
				Vector4d pointw = CurvePoint(crv.Degree, crv.Knots, crv.ControlPoints, u);
				// Convert back to cartesian coordinates
				return NurbsUtil.HomogenousToCartesian(pointw);
			}
			else
			{
				// Compute point using homogenous coordinates but since curve is not
				// rational the points xyz position will end up cartesian.
				Vector4d pointw = CurvePoint(crv.Degree, crv.Knots, crv.ControlPoints, u);
				return pointw.xyz;
			}
		}

		/// <summary>
		/// Evaluate derivatives of a non-rational NURBS curve
		/// E.g. curve_ders[n] is the nth derivative at u, where 0 less than n less than or equal num_ders.
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="num_ders">Number of times to derivate.</param>
		/// <param name="u">Parameter to evaluate the derivatives at.</param>
		/// <returns>Derivatives of the curve at u.</returns>
		internal static Vector2d[] CurveDerivatives(NurbsCurve2d crv, int num_ders, double u)
		{
			if (crv.IsRational)
			{
				// Derivatives of Cw
				var Cwders = CurveDerivatives(crv.Degree, crv.Knots, crv.ControlPoints, num_ders, u);

				// Split Cwders into coordinates and weights
				var Aders = new List<Vector2d>(Cwders.Length);
				var wders = new List<double>(Cwders.Length);

				foreach (var val in Cwders)
				{
					Aders.Add(NurbsUtil.TruncateHomogenous(val));
					wders.Add(val.z);
				}

				var curve_ders = new Vector2d[num_ders + 1];

				// Compute rational derivatives
				for (int k = 0; k <= num_ders; k++)
				{
					var v = Aders[k];
					for (int i = 1; i <= k; i++)
						v -= curve_ders[k - i] * NurbsUtil.Binomial(k, i) * wders[i];

					curve_ders[k] = v / wders[0];
				}

				return curve_ders;
			}
			else
			{
				// Compute rational derivatives but since curve is not
				// rational the points xyz position will end up cartesian.
				var Cwders = CurveDerivatives(crv.Degree, crv.Knots, crv.ControlPoints, num_ders, u);

				var curve_ders = new Vector2d[num_ders + 1];

				for (int k = 0; k <= num_ders; k++)
					curve_ders[k] = Cwders[k].xy;

				return curve_ders;
			}
		}

		/// <summary>
		/// Evaluate derivatives of a non-rational NURBS curve
		/// E.g. curve_ders[n] is the nth derivative at u, where 0 less or equal than n less than or equal num_ders.
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="num_ders">Number of times to derivate.</param>
		/// <param name="u">Parameter to evaluate the derivatives at.</param>
		/// <returns>Derivatives of the curve at u.</returns>
		internal static Vector3d[] CurveDerivatives(NurbsCurve3d crv, int num_ders, double u)
		{
			if (crv.IsRational)
			{
				// Derivatives of Cw
				var Cwders = CurveDerivatives(crv.Degree, crv.Knots, crv.ControlPoints, num_ders, u);

				// Split Cwders into coordinates and weights
				var Aders = new List<Vector3d>(Cwders.Length);
				var wders = new List<double>(Cwders.Length);

				foreach (var val in Cwders)
				{
					Aders.Add(NurbsUtil.TruncateHomogenous(val));
					wders.Add(val.w);
				}

				var curve_ders = new Vector3d[num_ders + 1];

				// Compute rational derivatives
				for (int k = 0; k <= num_ders; k++)
				{
					var v = Aders[k];
					for (int i = 1; i <= k; i++)
						v -= curve_ders[k - i] * NurbsUtil.Binomial(k, i) * wders[i];

					curve_ders[k] = v / wders[0];
				}

				return curve_ders;
			}
			else
			{
				// Compute rational derivatives but since curve is not
				// rational the points xyz position will end up cartesian.
				var Cwders = CurveDerivatives(crv.Degree, crv.Knots, crv.ControlPoints, num_ders, u);

				var curve_ders = new Vector3d[num_ders + 1];

				for (int k = 0; k <= num_ders; k++)
					curve_ders[k] = Cwders[k].xyz;

				return curve_ders;
			}
		}

		/// <summary>
		/// Evaluate the tangent of a B-spline curve
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <returns>Unit tangent of the curve at u.</returns>
		internal static Vector2d CurveTangent(NurbsCurve2d crv, double u)
		{
			var ders = CurveDerivatives(crv, 1, u);
			return ders[1].Normalized;
		}

		/// <summary>
		/// Evaluate the tangent of a B-spline curve
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <returns>Unit tangent of the curve at u.</returns>
		internal static Vector3d CurveTangent(NurbsCurve3d crv, double u)
		{
			var ders = CurveDerivatives(crv, 1, u);
			return ders[1].Normalized;
		}

		/// <summary>
		/// Evaluate point on a nonrational NURBS surface
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="u">Parameter to evaluate the surface at.</param>
		/// <param name="v">Parameter to evaluate the surface at.</param>
		/// <returns>Resulting point on the surface at (u, v).</returns>
		internal static Vector3d SurfacePoint(NurbsSurface3d srf, double u, double v)
		{
			if (srf.IsRational)
			{
				// Compute point using homogenous coordinates
				var pointw = SurfacePoint(srf.DegreeU, srf.DegreeV, srf.KnotsU, srf.KnotsV,srf.ControlPoints, u, v);
				// Convert back to cartesian coordinates
				return NurbsUtil.HomogenousToCartesian(pointw);
			}
			else
			{
				// Compute point using homogenous coordinates but since surface is not
				// rational the points xyz position will end up cartesian.
				var pointw = SurfacePoint(srf.DegreeU, srf.DegreeV, srf.KnotsU, srf.KnotsV, srf.ControlPoints, u, v);
				return pointw.xyz;
			}
		}

		/// <summary>
		/// Evaluate derivatives on a non-rational NURBS surface
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="num_ders">Number of times to differentiate</param>
		/// <param name="u">Parameter to evaluate the surface at.</param>
		/// <param name="v">Parameter to evaluate the surface at.</param>
		/// <returns>Derivatives of the surface at (u, v).</returns>
		internal static Vector3d[,] SurfaceDerivatives(NurbsSurface3d srf, int num_ders, double u, double v)
		{
			if(srf.IsRational)
            {
				var homo_ders = SurfaceDerivatives(srf.DegreeU, srf.DegreeV, srf.KnotsU, srf.KnotsV, srf.ControlPoints, num_ders, u, v);

				var Aders = new Vector3d[num_ders + 1, num_ders + 1];

				for (int i = 0; i < homo_ders.GetLength(0); ++i)
					for (int j = 0; j < homo_ders.GetLength(1); ++j)
						Aders[i, j] = NurbsUtil.TruncateHomogenous(homo_ders[i, j]);

				var surf_ders = new Vector3d[num_ders + 1, num_ders + 1];

				for (int k = 0; k < num_ders + 1; ++k)
				{
					for (int l = 0; l < num_ders - k + 1; ++l)
					{
						var der = Aders[k, l];

						for (int j = 1; j < l + 1; ++j)
						{
							der -= surf_ders[k, l - j] * (homo_ders[0, j].w * NurbsUtil.Binomial(l, j));
						}

						for (int i = 1; i < k + 1; ++i)
						{
							der -= surf_ders[k - i, l] * (homo_ders[i, 0].w * NurbsUtil.Binomial(k, i));

							var tmp = new Vector3d();
							for (int j = 1; j < l + 1; ++j)
							{
								tmp -= surf_ders[k - 1, l - j] * (homo_ders[i, j].w * NurbsUtil.Binomial(l, j));
							}

							der -= tmp * NurbsUtil.Binomial(k, i);
						}

						der *= 1 / homo_ders[0, 0].w;
						surf_ders[k, l] = der;
					}
				}

				return surf_ders;
			}
			else
            {
				var homo_ders = SurfaceDerivatives(srf.DegreeU, srf.DegreeV, srf.KnotsU, srf.KnotsV, srf.ControlPoints, num_ders, u, v);

				var surf_ders = new Vector3d[num_ders + 1, num_ders + 1];

				for (int i = 0; i < num_ders + 1; ++i)
					for (int j = 0; j < num_ders - i + 1; ++j)
						surf_ders[i, j] = homo_ders[i, j].xyz;

				return surf_ders;
			}
		}

		/// <summary>
		/// Evaluate the two orthogonal tangents of a non-rational surface at the given
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="u">Parameter in the u-direction</param>
		/// <param name="v">Parameter in the v-direction</param>
		/// <returns>Tuple with unit tangents along u- and v-directions</returns>
		internal static (Vector3d, Vector3d) SurfaceTangent(NurbsSurface3d srf, double u, double v)
		{
			var ptder = SurfaceDerivatives(srf, 1, u, v);
			var du = ptder[1, 0];
			var dv = ptder[0, 1];

			return (du.Normalized, dv.Normalized);
		}

		/// <summary>
		/// Evaluate the normal a non-rational surface at the given parameters
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="u">Parameter in the u-direction</param>
		/// <param name="v">Parameter in the v-direction</param>
		/// <returns>Unit normal at of the surface at (u, v)</returns>
		internal static Vector3d SurfaceNormal(NurbsSurface3d srf, double u, double v)
		{
			var ptder = SurfaceDerivatives(srf, 1, u, v);
			var n = Vector3d.Cross(ptder[0, 1], ptder[1, 0]);
			return n.Normalized;
		}

		/// <summary>
		/// Evaluate point on a nonrational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the given curve.</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve.</param>
		/// <param name="u">Parameter to evaluate the curve at.</param>
		/// <returns>Resulting point on the curve at parameter u.</returns>
		private static Vector3d CurvePoint(int degree, IList<double> knots, IList<Vector3d> control_points, double u)
		{
			var point = new Vector3d();

			// Find span and corresponding non-zero basis functions
			int span = NurbsBasis.FindSpan(degree, knots, u);
			var N = NurbsBasis.BSplineBasis(degree, span, knots, u);

			// Compute point
			for (int j = 0; j <= degree; j++)
				point += control_points[span - degree + j] * N[j];

			return point;
		}

		/// <summary>
		/// Evaluate point on a nonrational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the given curve.</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve.</param>
		/// <param name="u">Parameter to evaluate the curve at.</param>
		/// <returns>Resulting point on the curve at parameter u.</returns>
		private static Vector4d CurvePoint(int degree, IList<double> knots, IList<Vector4d> control_points, double u)
		{
			var point = new Vector4d();

			// Find span and corresponding non-zero basis functions
			int span = NurbsBasis.FindSpan(degree, knots, u);
			var N = NurbsBasis.BSplineBasis(degree, span, knots, u);

			// Compute point
			for (int j = 0; j <= degree; j++)
				point += control_points[span - degree + j] * N[j];

			return point;
		}

		/// <summary>
		/// Evaluate derivatives of a non-rational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the curve</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve.</param>
		/// <param name="num_ders">Number of times to derivate.</param>
		/// <param name="u">Parameter to evaluate the derivatives at.</param>
		/// <returns>Derivatives of the curve at u.</returns>
		private static Vector3d[] CurveDerivatives(int degree, IList<double> knots, IList<Vector3d> control_points, int num_ders, double u)
		{
			var curve_ders = new Vector3d[num_ders + 1];

			// Find the span and corresponding non-zero basis functions & derivatives
			int span = NurbsBasis.FindSpan(degree, knots, u);
			var ders = NurbsBasis.BSplineDerBasis(degree, span, knots, u, num_ders);

			// Compute first num_ders derivatives
			int du = num_ders < degree ? num_ders : degree;
			for (int k = 0; k <= du; k++)
			{
				//curve_ders[k] = new Vector4d();
				for (int j = 0; j <= degree; j++)
					curve_ders[k] += control_points[span - degree + j] * ders[k, j];
			}

			return curve_ders;
		}

		/// <summary>
		/// Evaluate derivatives of a non-rational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the curve</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve.</param>
		/// <param name="num_ders">Number of times to derivate.</param>
		/// <param name="u">Parameter to evaluate the derivatives at.</param>
		/// <returns>Derivatives of the curve at u.</returns>
		private static Vector4d[] CurveDerivatives(int degree, IList<double> knots, IList<Vector4d> control_points, int num_ders, double u)
		{
			var curve_ders = new Vector4d[num_ders + 1];

			// Find the span and corresponding non-zero basis functions & derivatives
			int span = NurbsBasis.FindSpan(degree, knots, u);
			var ders = NurbsBasis.BSplineDerBasis(degree, span, knots, u, num_ders);

			// Compute first num_ders derivatives
			int du = num_ders < degree ? num_ders : degree;
			for (int k = 0; k <= du; k++)
			{
				//curve_ders[k] = new Vector4d();
				for (int j = 0; j <= degree; j++)
					curve_ders[k] += control_points[span - degree + j] * ders[k, j];
			}

			return curve_ders;
		}

		/// <summary>
		/// Evaluate point on a nonrational NURBS surface
		/// </summary>
		/// <param name="degree_u">Degree of the given surface in u-direction.</param>
		/// <param name="degree_v">Degree of the given surface in v-direction.</param>
		/// <param name="knots_u">Knot vector of the surface in u-direction.</param>
		/// <param name="knots_v">Knot vector of the surface in v-direction.</param>
		/// <param name="control_points">Control points of the surface in a 2d array.</param>
		/// <param name="u">Parameter to evaluate the surface at.</param>
		/// <param name="v">Parameter to evaluate the surface at.</param>
		/// <returns>Resulting point on the surface at (u, v).</returns>
		private static Vector4d SurfacePoint(int degree_u, int degree_v, IList<double> knots_u, IList<double> knots_v,
			Vector4d[,] control_points, double u, double v)
		{
			// Initialize result to 0s
			var point = new Vector4d();

			// Find span and non-zero basis functions
			int span_u = NurbsBasis.FindSpan(degree_u, knots_u, u);
			int span_v = NurbsBasis.FindSpan(degree_v, knots_v, v);
			var Nu = NurbsBasis.BSplineBasis(degree_u, span_u, knots_u, u);
			var Nv = NurbsBasis.BSplineBasis(degree_v, span_v, knots_v, v);

			for (int l = 0; l <= degree_v; l++)
			{
				var temp = new Vector4d();
				for (int k = 0; k <= degree_u; k++)
					temp += control_points[span_u - degree_u + k, span_v - degree_v + l] * Nu[k];

				point += temp * Nv[l];
			}

			return point;
		}

		/// <summary>
		/// Evaluate derivatives on a non-rational NURBS surface
		/// </summary>
		/// <param name="degree_u">Degree of the given surface in u-direction.</param>
		/// <param name="degree_v">Degree of the given surface in v-direction.</param>
		/// <param name="knots_u">Knot vector of the surface in u-direction.</param>
		/// <param name="knots_v">Knot vector of the surface in v-direction.</param>
		/// <param name="control_points">Control points of the surface in a 2d array.</param>
		/// <param name="num_ders">Number of times to differentiate.</param>
		/// <param name="u">Parameter to evaluate the surface at.</param>
		/// <param name="v">Parameter to evaluate the surface at.</param>
		/// <returns>Derivatives of the surface at (u, v).</returns>
		private static Vector4d[,] SurfaceDerivatives(int degree_u, int degree_v, IList<double> knots_u,
					IList<double> knots_v, Vector4d[,] control_points, int num_ders, double u, double v)
		{
			var surf_ders = new Vector4d[num_ders + 1, num_ders + 1];

			// Find span and basis function derivatives
			int span_u = NurbsBasis.FindSpan(degree_u, knots_u, u);
			int span_v = NurbsBasis.FindSpan(degree_v, knots_v, v);
			var ders_u = NurbsBasis.BSplineDerBasis(degree_u, span_u, knots_u, u, num_ders);
			var ders_v = NurbsBasis.BSplineDerBasis(degree_v, span_v, knots_v, v, num_ders);

			// Number of non-zero derivatives is <= degree
			int du = Math.Min(num_ders, degree_u);
			int dv = Math.Min(num_ders, degree_v);

			var temp = new Vector4d[degree_v + 1];
			// Compute derivatives
			for (int k = 0; k <= du; k++)
			{
				for (int s = 0; s <= degree_v; s++)
				{
					temp[s] = new Vector4d();
					for (int r = 0; r <= degree_u; r++)
						temp[s] += control_points[span_u - degree_u + r, span_v - degree_v + s] * ders_u[k, r];
				}

				int dd = Math.Min(num_ders - k, dv);

				for (int l = 0; l <= dd; l++)
				{
					for (int s = 0; s <= degree_v; s++)
						surf_ders[k, l] += temp[s] * ders_v[l, s];
				}
			}

			return surf_ders;
		}

	}

}

