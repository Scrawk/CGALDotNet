using System;
using System.Collections.Generic;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{

	internal static class NurbsModify
	{
		/// <summary>
		/// Insert knots in the curve
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="u">Parameter to insert knot at</param>
		/// <param name="repeat">Number of times to insert</param>
		/// <returns>New curve with repeat knots inserted at u</returns>
		internal static NurbsCurveParams2d CurveKnotInsert(BaseNurbsCurve2d crv, double u, int repeat = 1)
		{
			var param = new NurbsCurveParams2d();
			param.degree = crv.Degree;

			CurveKnotInsert(crv, u, repeat, out param.knots, out param.controlPoints);
	
			return param;
		}

		/// <summary>
		/// Split a curve into two
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="u">Parameter to split at</param>
		/// <returns>Tuple with first half and second half of the curve</returns>
		internal static void CurveSplit(BaseNurbsCurve2d crv, double u, out NurbsCurveParams2d leftParam, out NurbsCurveParams2d rightParam)
		{
			leftParam = new NurbsCurveParams2d();
			rightParam = new NurbsCurveParams2d();

			leftParam.degree = crv.Degree;
			rightParam.degree = crv.Degree;

			CurveSplit(crv, u, out leftParam.knots, out leftParam.controlPoints, out rightParam.knots, out rightParam.controlPoints);
		}


		/// <summary>
		///  Insert knots in the curve
		/// </summary>
		/// <param name="crv">The curve to insert knots</param>
		/// <param name="u">Parameter to insert knot(s) at</param>
		/// <param name="r">Number of times to insert knot</param>
		/// <param name="new_knots">Updated knot vector</param>
		/// <param name="new_cp">Updated control pointss</param>
		private static void CurveKnotInsert(BaseNurbsCurve2d crv, double u, int r, out List<double> new_knots, out List<HPoint2d> new_cp)
		{
			int k = NurbsBasis.FindSpan(crv.Degree, crv.Knots, u);
			int s = NurbsCheck.KnotMultiplicity(crv.Knots, k);
			int L;

			if (s == crv.Degree)
				throw new Exception("s == crv.Degree");

			if ((r + s) > crv.Degree)
				r = crv.Degree - s;

			// Insert new knots between span and (span + 1)
			new_knots = new List<double>(crv.Knots.Length + r);
			NurbsUtil.AddRange(new_knots, crv.Knots.Length + r, 0);

			for (int i = 0; i < k + 1; ++i)
				new_knots[i] = crv.Knots[i];

			for (int i = 1; i < r + 1; ++i)
				new_knots[k + i] = u;

			for (int i = k + 1; i < crv.Knots.Length; ++i)
				new_knots[i + r] = crv.Knots[i];

			// Copy unaffected control points
			new_cp = new List<HPoint2d>(crv.Count + r);
			NurbsUtil.AddRange(new_cp, crv.Count + r, HPoint2d.Zero);

			for (int i = 0; i < k - crv.Degree + 1; ++i)
				new_cp[i] = crv.GetHomogeneousControlPoint(i);

			for (int i = k - s; i < crv.Count; ++i)
				new_cp[i + r] = crv.GetHomogeneousControlPoint(i);

			// Copy affected control points
			var tmp = new List<HPoint2d>(crv.Degree - s + 1);

			for (int i = 0; i < crv.Degree - s + 1; ++i)
				tmp.Add(crv.GetHomogeneousControlPoint(k - crv.Degree + i));

			// Modify affected control points
			for (int j = 1; j <= r; ++j)
			{
				L = k - crv.Degree + j;
				for (int i = 0; i < crv.Degree - j - s + 1; ++i)
				{
					var a = (u - crv.Knots[L + i]) / (crv.Knots[i + k + 1] - crv.Knots[L + i]);
					tmp[i] = tmp[i] * (1 - a) + tmp[i + 1] * a;
				}
				new_cp[L] = tmp[0];
				new_cp[k + r - j - s] = tmp[crv.Degree - j - s];
			}

			L = k - crv.Degree + r;
			for (int i = L + 1; i < k - s; ++i)
				new_cp[i] = tmp[i - L];

		}

		/// <summary>
		/// Split the curve into two
		/// </summary>
		/// <param name="crv"></param>
		/// <param name="u"></param>
		/// <param name="left_knots"></param>
		/// <param name="left_control_points"></param>
		/// <param name="right_knots"></param>
		/// <param name="right_control_points"></param>
		private static void CurveSplit(BaseNurbsCurve2d crv, double u,
			out List<double> left_knots, out List<HPoint2d> left_control_points,
			out List<double> right_knots, out List<HPoint2d> right_control_points)
		{
			List<double> tmp_knots;
			List<HPoint2d> tmp_cp;

			int span = NurbsBasis.FindSpan(crv.Degree, crv.Knots, u);
			int r = crv.Degree - NurbsCheck.KnotMultiplicity(crv.Knots, span);

			CurveKnotInsert(crv, u, r, out tmp_knots, out tmp_cp);

			left_knots = new List<double>();
			right_knots = new List<double>();
			left_control_points = new List<HPoint2d>();
			right_control_points = new List<HPoint2d>();

			int span_l = NurbsBasis.FindSpan(crv.Degree, tmp_knots, u) + 1;
			for (int i = 0; i < span_l; ++i)
				left_knots.Add(tmp_knots[i]);

			left_knots.Add(u);

			for (int i = 0; i < crv.Degree + 1; ++i)
				right_knots.Add(u);

			for (int i = span_l; i < tmp_knots.Count; ++i)
				right_knots.Add(tmp_knots[i]);

			int ks = span - crv.Degree + 1;
			for (int i = 0; i < ks + r; ++i)
				left_control_points.Add(tmp_cp[i]);

			for (int i = ks + r - 1; i < tmp_cp.Count; ++i)
				right_control_points.Add(tmp_cp[i]);

		}
	}

}

