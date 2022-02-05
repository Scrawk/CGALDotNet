using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

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
				if (MathUtil.IsZero(u - knots[idx]))
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
			return IsArray1Closed(crv) && IsKnotVectorClosed(crv);

		}

		/// <summary>
		/// Returns whether the surface is valid
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <returns>Whether valid</returns>
		internal static bool SurfaceIsValid(BaseNurbsSurface3d srf)
		{
			return SurfaceIsValid(srf.DegreeU, srf.DegreeV, srf.KnotsU, srf.KnotsV, srf.Width, srf.Height);
		}

		/// <summary>
		/// Checks whether the surface is closed along u-direction
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <returns>Whether closed along u-direction</returns>
		internal static bool SurfaceIsClosedU(BaseNurbsSurface3d srf)
		{
			return IsArray2ClosedU(srf) && IsKnotVectorClosedU(srf);
		}

		/// <summary>
		/// Checks whether the surface is closed along v-direction
		/// </summary>
		/// <param name="srf">Surface object</param>
		/// <returns>Whether closed along v-direction</returns>
		internal static bool SurfaceIsClosedV(BaseNurbsSurface3d srf)
		{
			return IsArray2ClosedV(srf) && IsKnotVectorClosedV(srf);
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
		/// Returns whether the surface is valid
		/// </summary>
		/// <param name="degree_u">Degree of surface along u-direction</param>
		/// <param name="degree_v">Degree of surface along v-direction</param>
		/// <param name="knots_u">Knot vector of surface along u-direction</param>
		/// <param name="knots_v">Knot vector of surface along v-direction</param>
		/// <param name="controlPointsLen0">The number of control point in first dimension.</param>
		/// <param name="controlPointsLen1">The number of control point in second dimension.</param>
		/// <returns>Whether valid</returns>
		private static bool SurfaceIsValid(int degree_u, int degree_v, IList<double> knots_u, IList<double> knots_v, int controlPointsLen0, int controlPointsLen1)
		{
			if (degree_u < 1 || degree_u > 9 || degree_v < 1 || degree_v > 9)
				return false;

			if (!IsValidRelation(degree_u, knots_u.Count, controlPointsLen0) ||
				!IsValidRelation(degree_v, knots_v.Count, controlPointsLen1))
				return false;

			if (!IsKnotVectorMonotonic(knots_u) || !IsKnotVectorMonotonic(knots_v))
				return false;

			return true;
		}

		/// <summary>
		/// Returns whether the given knot vector is closed by checking the
		/// periodicity of knot vectors near the start and end
		/// </summary>
		/// <returns>Whether knot vector is closed</returns>
		private static bool IsKnotVectorClosed(BaseNurbsCurve2d crv)
		{
			for (int i = 0; i < crv.Degree - 1; ++i)
			{
				int j = crv.Knots.Length - crv.Degree + i;
				if (!MathUtil.IsZero((crv.Knots[i + 1] - crv.Knots[i]) - (crv.Knots[j + 1] - crv.Knots[j])))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Returns whether the given knot vector is closed by checking the
		/// periodicity of knot vectors near the start and end
		/// </summary>
		/// <returns>Whether knot vector is closed</returns>
		private static bool IsKnotVectorClosedU(BaseNurbsSurface3d srv)
		{
			for (int i = 0; i < srv.DegreeU - 1; ++i)
			{
				int j = srv.KnotsU.Length - srv.DegreeU + i;
				if (!MathUtil.IsZero((srv.KnotsU[i + 1] - srv.KnotsU[i]) - (srv.KnotsU[j + 1] - srv.KnotsU[j])))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Returns whether the given knot vector is closed by checking the
		/// periodicity of knot vectors near the start and end
		/// </summary>
		/// <returns>Whether knot vector is closed</returns>
		private static bool IsKnotVectorClosedV(BaseNurbsSurface3d srv)
		{
			for (int i = 0; i < srv.DegreeV - 1; ++i)
			{
				int j = srv.KnotsV.Length - srv.DegreeV + i;
				if (!MathUtil.IsZero((srv.KnotsV[i + 1] - srv.KnotsV[i]) - (srv.KnotsV[j + 1] - srv.KnotsV[j])))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Returns whether the given knot vector is closed by checking the
		/// periodicity of knot vectors near the start and end
		/// </summary>
		/// <returns>Whether knot vector is closed</returns>
		private static bool IsArray1Closed(BaseNurbsCurve2d crv)
		{
			for (int i = 0; i < crv.Degree; ++i)
			{
				int j = crv.Count - crv.Degree + i;

				var pi = crv.GetCartesianControlPoint(i);
				var pj = crv.GetCartesianControlPoint(j);

				//check the weights
				if (!MathUtil.IsZero(crv.GetHomogeneousControlPoint(i).w - crv.GetHomogeneousControlPoint(j).w))
					return false;

				//check the control points
				if (!MathUtil.IsZero((pi - pj).Magnitude))
					return false;
			}
			return true;
		}

		/// <summary>
		/// Returns whether the 2D array is closed along the u-direction
		/// i.e., along rows.
		/// </summary>
		/// <returns>Whether closed along u-direction</returns>
		private static bool IsArray2ClosedU(BaseNurbsSurface3d srv)
		{
			for (int i = 0; i < srv.DegreeU; ++i)
			{
				for (int j = 0; j < srv.Height; ++j)
				{
					int k = srv.Height - srv.DegreeU + i;

					var pij = srv.GetCartesianControlPoint(i, j);
					var pkj = srv.GetCartesianControlPoint(k, j);

					//Check the weights
					if (!MathUtil.IsZero(srv.GetHomogeneousControlPoint(i, j).w - srv.GetHomogeneousControlPoint(k, j).w))
						return false;

					//Check the control points
					if (!MathUtil.IsZero((pij - pkj).Magnitude))
						return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Returns whether the 2D array is closed along the v-direction
		/// i.e., along columns.
		/// </summary>
		/// <returns>Whether closed along v-direction</returns>
		private static bool IsArray2ClosedV(BaseNurbsSurface3d srv)
		{
			for (int i = 0; i < srv.Width; ++i)
			{
				for (int j = 0; j < srv.DegreeV; j++)
				{
					int k = srv.Width - srv.DegreeV + i;

					var pij = srv.GetCartesianControlPoint(i, j);
					var pik = srv.GetCartesianControlPoint(k, j);

					//Check the weights
					if (!MathUtil.IsZero(srv.GetHomogeneousControlPoint(i, j).w - srv.GetHomogeneousControlPoint(i, k).w))
						return false;

					if (!MathUtil.IsZero((pij - pik).Magnitude))
						return false;
				}
			}
			return true;
		}

	}

}

