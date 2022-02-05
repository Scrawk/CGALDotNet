using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

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
			return HomogeneousCurvePoint(crv, u).Cartesian;
		}

		/// Evaluate point on a nonrational NURBS curve
		/// </summary>
		/// <param name="degree">Degree of the given curve.</param>
		/// <param name="knots">Knot vector of the curve.</param>
		/// <param name="control_points">Control points of the curve in homogenous space.</param>
		/// <param name="u">Parameter to evaluate the curve at.</param>
		/// <returns>Resulting point on the curve at parameter u.</returns>
		private static HPoint2d HomogeneousCurvePoint(BaseNurbsCurve2d crv, double u)
		{
			var point = new HPoint2d();

			// Find span and corresponding non-zero basis functions
			int span = NurbsBasis.FindSpan(crv.Degree, crv.Knots, u);
			var N = NurbsBasis.BSplineBasis(crv.Degree, span, crv.Knots, u);

			// Compute point
			for (int j = 0; j <= crv.Degree; j++)
				point += crv.GetHomogeneousControlPoint(span - crv.Degree + j) * N[j];

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
			var Cwders = HomogeneousCurveDerivatives(crv, num_ders, u);

			var curve_ders = new Vector2d[num_ders + 1];
			for (int k = 0; k <= num_ders; k++)
				curve_ders[k] = Cwders[k].xy;

			return curve_ders;

		}

		/// <summary>
		/// Evaluate derivatives of a non-rational NURBS curve
		/// </summary>
		/// <param name="num_ders">Number of times to derivate.</param>
		/// <param name="u">Parameter to evaluate the derivatives at.</param>
		/// <returns>Derivatives of the curve at u.</returns>
		private static Vector3d[] HomogeneousCurveDerivatives(BaseNurbsCurve2d crv, int num_ders, double u)
		{
			var curve_ders = new Vector3d[num_ders + 1];

			// Find the span and corresponding non-zero basis functions & derivatives
			int span = NurbsBasis.FindSpan(crv.Degree, crv.Knots, u);
			var ders = NurbsBasis.BSplineDerBasis(crv.Degree, span, crv.Knots, u, num_ders);

			// Compute first num_ders derivatives
			int du = num_ders < crv.Degree ? num_ders : crv.Degree;
			for (int k = 0; k <= du; k++)
			{
				for (int j = 0; j <= crv.Degree; j++)
                {
					var point = crv.GetCartesianControlPoint(span - crv.Degree + j);
					var der = ders[k, j];
					curve_ders[k].x += point.x * der;
					curve_ders[k].y += point.y * der;
					//curve_ders[k].z += point.w * der;
				}
			}

			return curve_ders;
		}

		/// <summary>
		/// Evaluate point on a nonrational NURBS surface
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="u">Parameter to evaluate the surface at.</param>
		/// <param name="v">Parameter to evaluate the surface at.</param>
		/// <returns>Resulting point on the surface at (u, v).</returns>
		internal static Point3d CartesianSurfacePoint(BaseNurbsSurface3d srf, double u, double v)
		{
			/*
			if(srf.IsRational)
            {
				var surface = srf as RationalNurbsSurface3d;
				var cp = NurbsUtil.ToVector(surface.HomogeneousControlPoints);
				return TestSurfacePoint(srf.DegreeU, srf.DegreeV, srf.KnotsU, srf.KnotsV, cp, u, v).Point3d;

			}
            else
            {
				throw new Exception();
            }
			*/
			return HomogeneousSurfacePoint(srf, u, v).Cartesian;
		}

		/// <summary>
		/// Evaluate point on a nonrational NURBS surface
		/// </summary>
		/// <param name="u">Parameter to evaluate the surface at.</param>
		/// <param name="v">Parameter to evaluate the surface at.</param>
		/// <returns>Resulting point on the surface at (u, v).</returns>
		private static HPoint3d HomogeneousSurfacePoint(BaseNurbsSurface3d srf, double u, double v)
		{
			// Initialize result to 0s
			var point = new HPoint3d();

			// Find span and non-zero basis functions
			int span_u = NurbsBasis.FindSpan(srf.DegreeU, srf.KnotsU, u);
			int span_v = NurbsBasis.FindSpan(srf.DegreeV, srf.KnotsV, v);
			var Nu = NurbsBasis.BSplineBasis(srf.DegreeU, span_u, srf.KnotsU, u);
			var Nv = NurbsBasis.BSplineBasis(srf.DegreeV, span_v, srf.KnotsV, v);

			for (int i = 0; i <= srf.DegreeV; i++)
			{
				var temp = new HPoint3d();
				for (int k = 0; k <= srf.DegreeU; k++)
					temp += srf.GetHomogeneousControlPoint(span_u - srf.DegreeU + k, span_v - srf.DegreeV + i) * Nu[k];

				point += temp * Nv[i];
			}

			return point;
		}

		private static Vector4d TestSurfacePoint(int degree_u, int degree_v, IList<double> knots_u, IList<double> knots_v,
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
		/// Evaluate the two orthogonal tangents of a non-rational surface at the given
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="u">Parameter in the u-direction</param>
		/// <param name="v">Parameter in the v-direction</param>
		/// <returns>Tuple with unit tangents along u- and v-directions</returns>
		internal static void SurfaceTangent(BaseNurbsSurface3d srf, double u, double v, out Vector3d du, out Vector3d dv)
		{
			var ptder = SurfaceDerivatives(srf, 1, u, v);
			du = ptder[1, 0].Normalized;
			dv = ptder[0, 1].Normalized;
		}

		/// <summary>
		/// Evaluate the normal a non-rational surface at the given parameters
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="u">Parameter in the u-direction</param>
		/// <param name="v">Parameter in the v-direction</param>
		/// <returns>Unit normal at of the surface at (u, v)</returns>
		internal static Vector3d SurfaceNormal(BaseNurbsSurface3d srf, double u, double v)
		{
			var ptder = SurfaceDerivatives(srf, 1, u, v);
			var n = Vector3d.Cross(ptder[1, 0], ptder[0, 1]);
			return n.Normalized;
		}

		/// <summary>
		/// Evaluate derivatives on a non-rational NURBS surface
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="num_ders">Number of times to differentiate</param>
		/// <param name="u">Parameter to evaluate the surface at.</param>
		/// <param name="v">Parameter to evaluate the surface at.</param>
		/// <returns>Derivatives of the surface at (u, v).</returns>
		internal static Vector3d[,] SurfaceDerivatives(BaseNurbsSurface3d srf, int num_ders, double u, double v)
		{
			if (srf.IsRational)
			{
				var homo_ders = HomogeneousSurfaceDerivatives(srf, num_ders, u, v);

				var Aders = new Vector3d[num_ders + 1, num_ders + 1];

				for (int i = 0; i < homo_ders.GetLength(0); ++i)
					for (int j = 0; j < homo_ders.GetLength(1); ++j)
						Aders[i, j] = homo_ders[i, j].xyz;

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
				var homo_ders = HomogeneousSurfaceDerivatives(srf, num_ders, u, v);

				var surf_ders = new Vector3d[num_ders + 1, num_ders + 1];

				for (int i = 0; i < num_ders + 1; ++i)
					for (int j = 0; j < num_ders - i + 1; ++j)
						surf_ders[i, j] = homo_ders[i, j].xyz;

				return surf_ders;
			}
		}

		/// <summary>
		/// Evaluate derivatives on a non-rational NURBS surface
		/// </summary>
		/// <param name="num_ders">Number of times to differentiate.</param>
		/// <param name="u">Parameter to evaluate the surface at.</param>
		/// <param name="v">Parameter to evaluate the surface at.</param>
		/// <returns>Derivatives of the surface at (u, v).</returns>
		private static Vector4d[,] HomogeneousSurfaceDerivatives(BaseNurbsSurface3d srf, int num_ders, double u, double v)
		{
			var surf_ders = new Vector4d[num_ders + 1, num_ders + 1];

			// Find span and basis function derivatives
			int span_u = NurbsBasis.FindSpan(srf.DegreeU, srf.KnotsU, u);
			int span_v = NurbsBasis.FindSpan(srf.DegreeV, srf.KnotsV, v);
			var ders_u = NurbsBasis.BSplineDerBasis(srf.DegreeU, span_u, srf.KnotsU, u, num_ders);
			var ders_v = NurbsBasis.BSplineDerBasis(srf.DegreeV, span_v, srf.KnotsV, v, num_ders);

			// Number of non-zero derivatives is <= degree
			int du = Math.Min(num_ders, srf.DegreeU);
			int dv = Math.Min(num_ders, srf.DegreeV);

			var temp = new Vector4d[srf.DegreeV + 1];
			// Compute derivatives
			for (int k = 0; k <= du; k++)
			{
				for (int s = 0; s <= srf.DegreeV; s++)
				{
					temp[s] = new Vector4d();
					for (int r = 0; r <= srf.DegreeU; r++)
                    {
						var pw = srf.GetHomogeneousControlPoint(span_u - srf.DegreeU + r, span_v - srf.DegreeV + s);
						var der = ders_u[k, r];
						temp[s].x += pw.x * der;
						temp[s].y += pw.y * der;
						temp[s].z += pw.z * der;
						temp[s].w += pw.w * der;
					}
						
				}

				int dd = Math.Min(num_ders - k, dv);

				for (int l = 0; l <= dd; l++)
				{
					for (int s = 0; s <= srf.DegreeV; s++)
						surf_ders[k, l] += temp[s] * ders_v[l, s];
				}
			}

			return surf_ders;
		}

	}

}

