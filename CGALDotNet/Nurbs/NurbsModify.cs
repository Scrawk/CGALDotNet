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
		internal static NurbsCurveParams2d CurveKnotInsert(NurbsCurve2d crv, double u, int repeat = 1)
		{
			var param = new NurbsCurveParams2d();
			param.degree = crv.Degree;

			CurveKnotInsert(crv.Degree, crv.Knots, crv.ControlPoints, u, repeat, out param.knots, out param.controlPoints);

			return param;
		}

		/// <summary>
		/// Insert knots in the curve
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="u">Parameter to insert knot at</param>
		/// <param name="repeat">Number of times to insert</param>
		/// <returns>New curve with repeat knots inserted at u</returns>
		internal static NurbsCurveParams3d CurveKnotInsert(NurbsCurve3d crv, double u, int repeat = 1)
		{
			var param = new NurbsCurveParams3d();
			param.degree = crv.Degree;

			CurveKnotInsert(crv.Degree, crv.Knots, crv.ControlPoints, u, repeat, out param.knots, out param.controlPoints);

			return param;
		}

		/// <summary>
		/// Insert knots in the surface along u-direction
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="u">Knot value to insert</param>
		/// <param name="repeat">Number of times to insert</param>
		/// <returns>New Surface object after knot insertion</returns>
		internal static NurbsSurfaceParams3d SurfaceKnotInsertU(NurbsSurface3d srf, double u, int repeat = 1)
		{
			var param = new NurbsSurfaceParams3d();
			param.degreeU = srf.DegreeU;
			param.degreeV = srf.DegreeV;
			param.knotsV = new List<double>(srf.KnotsV);

			SurfaceKnotInsert(srf.DegreeU, srf.KnotsU, srf.ControlPoints, u, repeat, true,
				out param.knotsU, out param.controlPoints);

			return param;
		}

		/// <summary>
		/// Insert knots in the surface along v-direction
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="v">Knot value to insert</param>
		/// <param name="repeat">Number of times to insert</param>
		/// <returns>New Surface object after knot insertion</returns>
		internal static NurbsSurfaceParams3d SurfaceKnotInsertV(NurbsSurface3d srf, double v, int repeat = 1)
		{
			var param = new NurbsSurfaceParams3d();
			param.degreeU = srf.DegreeU;
			param.degreeV = srf.DegreeV;
			param.knotsU = new List<double>(srf.KnotsU);

			SurfaceKnotInsert(srf.DegreeV, srf.KnotsV, srf.ControlPoints, v, repeat, false,
				out param.knotsV, out param.controlPoints);

			return param;
		}

		/// <summary>
		/// Split a curve into two
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="u">Parameter to split at</param>
		/// <returns>Tuple with first half and second half of the curve</returns>
		internal static (NurbsCurveParams2d left, NurbsCurveParams2d right) CurveSplit(NurbsCurve2d crv, double u)
		{
			var leftParam = new NurbsCurveParams2d();
			var rightParam = new NurbsCurveParams2d();

			leftParam.degree = crv.Degree;
			rightParam.degree = crv.Degree;

			CurveSplit(crv.Degree, crv.Knots, crv.ControlPoints, u,
				out leftParam.knots, out leftParam.controlPoints,
				out rightParam.knots, out rightParam.controlPoints);

			return (leftParam, rightParam);
		}

		/// <summary>
		/// Split a curve into two
		/// </summary>
		/// <param name="crv">Curve object</param>
		/// <param name="u">Parameter to split at</param>
		/// <returns>Tuple with first half and second half of the curve</returns>
		internal static (NurbsCurveParams3d left, NurbsCurveParams3d right) CurveSplit(NurbsCurve3d crv, double u)
		{
			var leftParam = new NurbsCurveParams3d();
			var rightParam = new NurbsCurveParams3d();

			leftParam.degree = crv.Degree;
			rightParam.degree = crv.Degree;

			CurveSplit(crv.Degree, crv.Knots, crv.ControlPoints, u,
				out leftParam.knots, out leftParam.controlPoints,
				out rightParam.knots, out rightParam.controlPoints);

			return (leftParam, rightParam);
		}

		/// <summary>
		/// Split a surface into two along u-direction
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="u">Parameter along u-direction to split the surface</param>
		/// <returns>Tuple with first and second half of the surfaces</returns>
		internal static (NurbsSurfaceParams3d left, NurbsSurfaceParams3d right) SurfaceSplitU(NurbsSurface3d srf, double u)
		{
			var leftParam = new NurbsSurfaceParams3d();
			leftParam.degreeU = srf.DegreeU;
			leftParam.degreeV = srf.DegreeV;
			leftParam.knotsV = new List<double>(srf.KnotsV);

			var rightParam = new NurbsSurfaceParams3d();
			rightParam.degreeU = srf.DegreeU;
			rightParam.degreeV = srf.DegreeV;
			rightParam.knotsV = new List<double>(srf.KnotsV);

			SurfaceSplit(srf.DegreeU, srf.KnotsU, srf.ControlPoints, u, true,
				out leftParam.knotsU, out leftParam.controlPoints,
				out rightParam.knotsU, out rightParam.controlPoints);

			return (leftParam, rightParam);
		}

		/// <summary>
		/// Split a surface into two along v-direction
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <param name="v">Parameter along v-direction to split the surface</param>
		/// <returns>Tuple with first and second half of the surfaces</returns>
		internal static (NurbsSurfaceParams3d left, NurbsSurfaceParams3d right) SurfaceSplitV(NurbsSurface3d srf, double v)
		{
			var leftParam = new NurbsSurfaceParams3d();
			leftParam.degreeU = srf.DegreeU;
			leftParam.degreeV = srf.DegreeV;
			leftParam.knotsU = new List<double>(srf.KnotsU);

			var rightParam = new NurbsSurfaceParams3d();
			rightParam.degreeU = srf.DegreeU;
			rightParam.degreeV = srf.DegreeV;
			rightParam.knotsU = new List<double>(srf.KnotsU);

			SurfaceSplit(srf.DegreeV, srf.KnotsV, srf.ControlPoints, v, false,
				out leftParam.knotsV, out leftParam.controlPoints,
				out rightParam.knotsV, out rightParam.controlPoints);

			return (leftParam, rightParam);
		}

		/// <summary>
		///  Insert knots in the curve
		/// </summary>
		/// <param name="deg">Degree of the curve</param>
		/// <param name="knots">Knot vector of the curve</param>
		/// <param name="cp">Control points of the curve</param>
		/// <param name="u">Parameter to insert knot(s) at</param>
		/// <param name="r">Number of times to insert knot</param>
		/// <param name="new_knots">Updated knot vector</param>
		/// <param name="new_cp">Updated control pointss</param>
		private static void CurveKnotInsert(int deg, IList<double> knots, IList<Vector3d> cp, double u, int r,
			out List<double> new_knots, out List<Vector3d> new_cp)
		{
			int k = NurbsBasis.FindSpan(deg, knots, u);
			int s = NurbsCheck.KnotMultiplicity(knots, k);
			int L;

			if (s == deg)
				throw new Exception("s == deg");

			if ((r + s) > deg)
				r = deg - s;

			// Insert new knots between span and (span + 1)
			new_knots = new List<double>(knots.Count + r);
			CGALGlobal.AddRange(new_knots, knots.Count + r, 0);

			for (int i = 0; i < k + 1; ++i)
				new_knots[i] = knots[i];

			for (int i = 1; i < r + 1; ++i)
				new_knots[k + i] = u;

			for (int i = k + 1; i < knots.Count; ++i)
				new_knots[i + r] = knots[i];

			// Copy unaffected control points
			new_cp = new List<Vector3d>(cp.Count + r);
			CGALGlobal.AddRange(new_cp, cp.Count + r, Vector3d.Zero);

			for (int i = 0; i < k - deg + 1; ++i)
				new_cp[i] = cp[i];

			for (int i = k - s; i < cp.Count; ++i)
				new_cp[i + r] = cp[i];

			// Copy affected control points
			var tmp = new List<Vector3d>(deg - s + 1);

			for (int i = 0; i < deg - s + 1; ++i)
				tmp.Add(cp[k - deg + i]);

			// Modify affected control points
			for (int j = 1; j <= r; ++j)
			{
				L = k - deg + j;
				for (int i = 0; i < deg - j - s + 1; ++i)
				{
					var a = (u - knots[L + i]) / (knots[i + k + 1] - knots[L + i]);
					tmp[i] = tmp[i] * (1 - a) + tmp[i + 1] * a;
				}
				new_cp[L] = tmp[0];
				new_cp[k + r - j - s] = tmp[deg - j - s];
			}

			L = k - deg + r;
			for (int i = L + 1; i < k - s; ++i)
				new_cp[i] = tmp[i - L];

		}

		/// <summary>
		///  Insert knots in the curve
		/// </summary>
		/// <param name="deg">Degree of the curve</param>
		/// <param name="knots">Knot vector of the curve</param>
		/// <param name="cp">Control points of the curve</param>
		/// <param name="u">Parameter to insert knot(s) at</param>
		/// <param name="r">Number of times to insert knot</param>
		/// <param name="new_knots">Updated knot vector</param>
		/// <param name="new_cp">Updated control pointss</param>
		private static void CurveKnotInsert(int deg, IList<double> knots, IList<Vector4d> cp, double u, int r,
			out List<double> new_knots, out List<Vector4d> new_cp)
		{
			int k = NurbsBasis.FindSpan(deg, knots, u);
			int s = NurbsCheck.KnotMultiplicity(knots, k);
			int L;

			if (s == deg)
				throw new Exception("s == deg");

			if ((r + s) > deg)
				r = deg - s;

			// Insert new knots between span and (span + 1)
			new_knots = new List<double>(knots.Count + r);
			CGALGlobal.AddRange(new_knots, knots.Count + r, 0);

			for (int i = 0; i < k + 1; ++i)
				new_knots[i] = knots[i];

			for (int i = 1; i < r + 1; ++i)
				new_knots[k + i] = u;

			for (int i = k + 1; i < knots.Count; ++i)
				new_knots[i + r] = knots[i];

			// Copy unaffected control points
			new_cp = new List<Vector4d>(cp.Count + r);
			CGALGlobal.AddRange(new_cp, cp.Count + r, Vector4d.Zero);

			for (int i = 0; i < k - deg + 1; ++i)
				new_cp[i] = cp[i];

			for (int i = k - s; i < cp.Count; ++i)
				new_cp[i + r] = cp[i];

			// Copy affected control points
			var tmp = new List<Vector4d>(deg - s + 1);

			for (int i = 0; i < deg - s + 1; ++i)
				tmp.Add(cp[k - deg + i]);

			// Modify affected control points
			for (int j = 1; j <= r; ++j)
			{
				L = k - deg + j;
				for (int i = 0; i < deg - j - s + 1; ++i)
				{
					var a = (u - knots[L + i]) / (knots[i + k + 1] - knots[L + i]);
					tmp[i] = tmp[i] * (1 - a) + tmp[i + 1] * a;
				}
				new_cp[L] = tmp[0];
				new_cp[k + r - j - s] = tmp[deg - j - s];
			}

			L = k - deg + r;
			for (int i = L + 1; i < k - s; ++i)
				new_cp[i] = tmp[i - L];

		}

		/// <summary>
		/// Insert knots in the surface along one direction
		/// </summary>
		/// <param name="degree">Degree of the surface along which to insert knot</param>
		/// <param name="knots">Knot vector</param>
		/// <param name="cp">2D array of control points</param>
		/// <param name="knot">Knot value to insert</param>
		/// <param name="r">Number of times to insert</param>
		/// <param name="along_u">Whether inserting along u-direction</param>
		/// <param name="new_knots">Updated knot vector</param>
		/// <param name="new_cp">Updated control points</param>
		/// <returns></returns>
		internal static void SurfaceKnotInsert(int degree, IList<double> knots,
			Vector4d[,] cp, double knot, int r, bool along_u,
			out List<double> new_knots, out Vector4d[,] new_cp)
		{
			int span = NurbsBasis.FindSpan(degree, knots, knot);
			int s = NurbsCheck.KnotMultiplicity(knots, span);
			int L;

			if (s == degree)
				throw new Exception("s == degree");

			if ((r + s) > degree)
				r = degree - s;

			// Create a new knot vector
			new_knots = new List<double>(knots.Count + r);
			CGALGlobal.AddRange(new_knots, knots.Count + r, 0);

			for (int i = 0; i <= span; ++i)
				new_knots[i] = knots[i];

			for (int i = 1; i <= r; ++i)
				new_knots[span + i] = knot;

			for (int i = span + 1; i < knots.Count; ++i)
				new_knots[i + r] = knots[i];

			// Compute alpha
			var alpha = new double[degree - s, r + 1];

			for (int j = 1; j <= r; ++j)
			{
				L = span - degree + j;
				for (int i = 0; i <= degree - j - s; ++i)
					alpha[i, j] = (knot - knots[L + i]) / (knots[i + span + 1] - knots[L + i]);
			}

			// Create a temporary container for affected control points per row/column
			var tmp = new List<Vector4d>(degree + 1);

			if (along_u)
			{
				int width = cp.GetLength(0);
				int height = cp.GetLength(1);

				// Create new control points with additional rows
				new_cp = new Vector4d[width + r, height];

				// Update control points
				// Each row is a u-isocurve, each col is a v-isocurve
				for (int col = 0; col < height; ++col)
				{
					// Copy unaffected control points
					for (int i = 0; i <= span - degree; ++i)
						new_cp[i, col] = cp[i, col];

					for (int i = span - s; i < width; ++i)
						new_cp[i + r, col] = cp[i, col];

					// Copy affected control points to temp array
					tmp.Clear();
					for (int i = 0; i < degree - s + 1; ++i)
						tmp.Add(cp[span - degree + i, col]);

					// Insert knot
					for (int j = 1; j <= r; ++j)
					{
						L = span - degree + j;
						for (int i = 0; i <= degree - j - s; ++i)
						{
							var a = alpha[i, j];
							tmp[i] = tmp[i] * (1 - a) + tmp[i + 1] * a;
						}
						new_cp[L, col] = tmp[0];
						new_cp[span + r - j - s, col] = tmp[degree - j - s];
					}

					L = span - degree + r;
					for (int i = L + 1; i < span - s; ++i)
						new_cp[i, col] = tmp[i - L];
				}
			}
			else
			{
				int width = cp.GetLength(0);
				int height = cp.GetLength(1);

				// Create new control points with additional columns
				new_cp = new Vector4d[width, height + r];

				// Update control points
				// Each row is a u-isocurve, each col is a v-isocurve
				for (int row = 0; row < width; ++row)
				{
					// Copy unaffected control points
					for (int i = 0; i <= span - degree; ++i)
						new_cp[row, i] = cp[row, i];

					for (int i = span - s; i < height; ++i)
						new_cp[row, i + r] = cp[row, i];

					// Copy affected control points to temp array
					tmp.Clear();
					for (int i = 0; i < degree - s + 1; ++i)
						tmp.Add(cp[row, span - degree + i]);

					// Insert knot
					for (int j = 1; j <= r; ++j)
					{
						L = span - degree + j;
						for (int i = 0; i <= degree - j - s; ++i)
						{
							var a = alpha[i, j];
							tmp[i] = tmp[i] * (1 - a) + tmp[i + 1] * a;
						}
						new_cp[row, L] = tmp[0];
						new_cp[row, span + r - j - s] = tmp[degree - j - s];
					}

					L = span - degree + r;
					for (int i = L + 1; i < span - s; ++i)
						new_cp[row, i] = tmp[i - L];
				}
			}
		}

		/// <summary>
		/// Split the curve into two
		/// </summary>
		/// <param name="degree"></param>
		/// <param name="knots"></param>
		/// <param name="control_points"></param>
		/// <param name="u"></param>
		/// <param name="left_knots"></param>
		/// <param name="left_control_points"></param>
		/// <param name="right_knots"></param>
		/// <param name="right_control_points"></param>
		private static void CurveSplit(int degree, IList<double> knots, IList<Vector3d> control_points, double u,
			out List<double> left_knots, out List<Vector3d> left_control_points,
			out List<double> right_knots, out List<Vector3d> right_control_points)
		{
			List<double> tmp_knots;
			List<Vector3d> tmp_cp;

			int span = NurbsBasis.FindSpan(degree, knots, u);
			int r = degree - NurbsCheck.KnotMultiplicity(knots, span);

			CurveKnotInsert(degree, knots, control_points, u, r, out tmp_knots, out tmp_cp);

			left_knots = new List<double>();
			right_knots = new List<double>();
			left_control_points = new List<Vector3d>();
			right_control_points = new List<Vector3d>();

			int span_l = NurbsBasis.FindSpan(degree, tmp_knots, u) + 1;
			for (int i = 0; i < span_l; ++i)
				left_knots.Add(tmp_knots[i]);

			left_knots.Add(u);

			for (int i = 0; i < degree + 1; ++i)
				right_knots.Add(u);

			for (int i = span_l; i < tmp_knots.Count; ++i)
				right_knots.Add(tmp_knots[i]);

			int ks = span - degree + 1;
			for (int i = 0; i < ks + r; ++i)
				left_control_points.Add(tmp_cp[i]);

			for (int i = ks + r - 1; i < tmp_cp.Count; ++i)
				right_control_points.Add(tmp_cp[i]);

		}

		/// <summary>
		/// Split the curve into two
		/// </summary>
		/// <param name="degree"></param>
		/// <param name="knots"></param>
		/// <param name="control_points"></param>
		/// <param name="u"></param>
		/// <param name="left_knots"></param>
		/// <param name="left_control_points"></param>
		/// <param name="right_knots"></param>
		/// <param name="right_control_points"></param>
		private static void CurveSplit(int degree, IList<double> knots, IList<Vector4d> control_points, double u,
			out List<double> left_knots, out List<Vector4d> left_control_points,
			out List<double> right_knots, out List<Vector4d> right_control_points)
		{
			List<double> tmp_knots;
			List<Vector4d> tmp_cp;

			int span = NurbsBasis.FindSpan(degree, knots, u);
			int r = degree - NurbsCheck.KnotMultiplicity(knots, span);

			CurveKnotInsert(degree, knots, control_points, u, r, out tmp_knots, out tmp_cp);

			left_knots = new List<double>();
			right_knots = new List<double>();
			left_control_points = new List<Vector4d>();
			right_control_points = new List<Vector4d>();

			int span_l = NurbsBasis.FindSpan(degree, tmp_knots, u) + 1;
			for (int i = 0; i < span_l; ++i)
				left_knots.Add(tmp_knots[i]);

			left_knots.Add(u);

			for (int i = 0; i < degree + 1; ++i)
				right_knots.Add(u);

			for (int i = span_l; i < tmp_knots.Count; ++i)
				right_knots.Add(tmp_knots[i]);

			int ks = span - degree + 1;
			for (int i = 0; i < ks + r; ++i)
				left_control_points.Add(tmp_cp[i]);

			for (int i = ks + r - 1; i < tmp_cp.Count; ++i)
				right_control_points.Add(tmp_cp[i]);

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="degree">Degree of surface along given direction</param>
		/// <param name="knots">Knot vector of surface along given direction</param>
		/// <param name="control_points">Array of control points</param>
		/// <param name="u">Parameter to split curve</param>
		/// <param name="along_u">Whether the direction to split along is the u-direction</param>
		/// <param name="left_knots">Knots of the left part of the curve</param>
		/// <param name="left_control_points">Control points of the left part of the curve</param>
		/// <param name="right_knots">Knots of the right part of the curve</param>
		/// <param name="right_control_points">Control points of the right part of the curve</param>
		internal static void SurfaceSplit(int degree, IList<double> knots, Vector4d[,] control_points, double u, bool along_u,
			out List<double> left_knots, out Vector4d[,] left_control_points,
			out List<double> right_knots, out Vector4d[,] right_control_points)
		{
			List<double> tmp_knots;
			Vector4d[,] tmp_cp;

			int span = NurbsBasis.FindSpan(degree, knots, u);
			int r = degree - NurbsCheck.KnotMultiplicity(knots, span);

			SurfaceKnotInsert(degree, knots, control_points, u, r, along_u, out tmp_knots, out tmp_cp);

			left_knots = new List<double>();
			right_knots = new List<double>();

			int span_l = NurbsBasis.FindSpan(degree, tmp_knots, u) + 1;
			for (int i = 0; i < span_l; ++i)
				left_knots.Add(tmp_knots[i]);

			left_knots.Add(u);

			for (int i = 0; i < degree + 1; ++i)
				right_knots.Add(u);

			for (int i = span_l; i < tmp_knots.Count; ++i)
				right_knots.Add(tmp_knots[i]);

			int width = tmp_cp.GetLength(0);
			int height = tmp_cp.GetLength(1);
			int ks = span - degree + 1;

			if (along_u)
			{
				int ii = 0;
				left_control_points = new Vector4d[ks + r, height];

				for (int i = 0; i < ks + r; ++i)
				{
					for (int j = 0; j < height; ++j)
					{
						left_control_points[ii % width, ii / width] = tmp_cp[i, j];
						ii++;
					}
				}

				ii = 0;
				right_control_points = new Vector4d[width - ks - r + 1, height];

				for (int i = ks + r - 1; i < width; ++i)
				{
					for (int j = 0; j < height; ++j)
					{
						right_control_points[ii % width, ii / width] = tmp_cp[i, j];
						ii++;
					}
				}
			}
			else
			{
				int ii = 0;
				left_control_points = new Vector4d[width, ks + r];

				for (int i = 0; i < width; ++i)
				{
					for (int j = 0; j < ks + r; ++j)
					{
						left_control_points[ii % width, ii / width] = tmp_cp[i, j];
						ii++;
					}
				}

				ii = 0;
				right_control_points = new Vector4d[width, height - ks - r + 1];

				for (int i = 0; i < width; ++i)
				{
					for (int j = ks + r - 1; j < height; ++j)
					{
						right_control_points[ii % width, ii / width] = tmp_cp[i, j];
						ii++;
					}
				}
			}
		}

	}

}

