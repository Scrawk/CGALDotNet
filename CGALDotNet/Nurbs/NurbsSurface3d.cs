using System;
using System.Collections.Generic;
using System.Linq;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{

	internal struct NurbsSurfaceParams3d
	{
		public int degreeU, degreeV;
		public List<double> knotsU, knotsV;
		public Vector4d[,] controlPoints;
	}

	/// <summary>
	/// Class for representing a non-rational NURBS surface
	/// </summary>
	public class NurbsSurface3d
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public NurbsSurface3d()
		{

		}

		/// <summary>
		/// Create a new surface.
		/// </summary>
		/// <param name="degree_u">The degree on the first dimension.</param>
		/// <param name="degree_v">The degree on the second dimension.</param>
		/// <param name="knots_u">The knots on the first dimension.</param>
		/// <param name="knots_v">The knots on the second dimension.</param>
		/// <param name="control_points">The control points in cartesion coordinates.</param>
		public NurbsSurface3d(int degree_u, int degree_v, IList<double> knots_u, IList<double> knots_v, Vector3d[,] control_points)
		{
			DegreeU = degree_u;
			DegreeV = degree_v;
			KnotsU = knots_u.ToArray();
			KnotsV = knots_v.ToArray();

			int width = control_points.GetLength(0);
			int height = control_points.GetLength(1);

			ControlPoints = new Vector4d[width, height];

			for (int j = 0; j < height; j++)
				for (int i = 0; i < width; i++)
					ControlPoints[i, j] = new Vector4d(control_points[i, j], 1);
		}

		/// <summary>
		/// Create a new surface.
		/// </summary>
		/// <param name="degree_u">The degree on the first dimension.</param>
		/// <param name="degree_v">The degree on the second dimension.</param>
		/// <param name="knots_u">The knots on the first dimension.</param>
		/// <param name="knots_v">The knots on the second dimension.</param>
		/// <param name="control_points">The control points in cartesion coordinates.</param>
		internal NurbsSurface3d(int degree_u, int degree_v, IList<double> knots_u, IList<double> knots_v, Vector4d[,] control_points)
		{
			DegreeU = degree_u;
			DegreeV = degree_v;
			KnotsU = knots_u.ToArray();
			KnotsV = knots_v.ToArray();

			int width = control_points.GetLength(0);
			int height = control_points.GetLength(1);

			ControlPoints = new Vector4d[width, height];

			for (int j = 0; j < height; j++)
				for (int i = 0; i < width; i++)
					ControlPoints[i, j] = new Vector4d(control_points[i, j].xyz, 1);
		}

		/// <summary>
		/// Is the surface rational.
		/// </summary>
		public bool IsRational => this is RationalNurbsSurface3d;

		/// <summary>
		/// The degree on the first dimension.
		/// </summary>
		public int DegreeU { get; protected set; }

		/// <summary>
		/// The degree on the second dimension.
		/// </summary>
		public int DegreeV { get; protected set; }

		/// <summary>
		/// The knots on the first dimension.
		/// </summary>
		public double[] KnotsU { get; protected set; }

		/// <summary>
		/// The knots on the second dimension.
		/// </summary>
		public double[] KnotsV { get; protected set; }

		public int ControlPointsWidth => ControlPoints.GetLength(0);

		public int ControlPointsHeight => ControlPoints.GetLength(1);

		internal Vector4d[,] ControlPoints { get; set; }

		public bool IsValid => NurbsCheck.SurfaceIsValid(this);

		public bool IsClosedU => NurbsCheck.SurfaceIsClosedU(this);

		public bool IsClosedV => NurbsCheck.SurfaceIsClosedV(this);

		/// <summary>
		/// Get the control point.
		/// </summary>
		/// <param name="i">The points first index.</param>
		/// <param name="j">The points second index.</param>
		/// <returns>The control point in cartesian coordinates.</returns>
		public Vector3d GetControlPoint(int i, int j)
		{
			return NurbsUtil.HomogenousToCartesian(ControlPoints[i, j]);
		}

		/// <summary>
		/// Get the control points
		/// </summary>
		/// <param name="points">The list to copy the points into.</param>
		public void GetControlPoints(List<Vector3d> points)
		{
			for (int j = 0; j < ControlPoints.GetLength(1); j++)
				for (int i = 0; i < ControlPoints.GetLength(0); i++)
				points.Add(NurbsUtil.HomogenousToCartesian(ControlPoints[i, j]));
		}

		/// <summary>
		/// Set the control point.
		/// </summary>
		/// <param name="i">The points first index.</param>
		/// <param name="j">The points second index.</param>
		/// <param name="point">The control point in cartesian coordinates.</param>
		public void SetControlPoint(int i, int j, Vector3d point)
		{
			ControlPoints[i, j] = new Vector4d(point, 1);
		}

		/// <summary>
		/// Get the point at parameter u,v.
		/// </summary>
		/// <param name="u">The parameter.</param>
		/// <returns>The point at u,v.</returns>
		public Vector3d Point(double u, double v)
		{
			return NurbsEval.SurfacePoint(this, u, v);
		}

		/// <summary>
		/// Get the tangent at parameter u,v.
		/// </summary>
		/// <param name="u">The parameter.</param>
		/// <returns>The tanget at u,v.</returns>
		public (Vector3d, Vector3d) Tangent(double u, double v)
		{
			return NurbsEval.SurfaceTangent(this, u, v);
		}

		/// <summary>
		/// Get the normal at parameter u,v.
		/// </summary>
		/// <param name="u">The parameter.</param>
		/// <returns>The normal at u,v.</returns>
		public Vector3d Normal(double u, double v)
		{
			return NurbsEval.SurfaceNormal(this, u, v);
		}

		/// <summary>
		/// Normlize the surfaces u knots so the first knot starts at 0
		/// and the last knot ends at 1.
		/// </summary>
		public void NormalizeKnotsU()
		{
			double fisrt = KnotsU[0];
			double last = KnotsU.Last();

			for (int i = 0; i < KnotsU.Length; i++)
				KnotsU[i] = CGALGlobal.Normalize(KnotsU[i], fisrt, last);
		}

		/// <summary>
		/// Normlize the surfaces v knots so the first knot starts at 0
		/// and the last knot ends at 1.
		/// </summary>
		public void NormalizeKnotsV()
		{
			double fisrt = KnotsV[0];
			double last = KnotsV.Last();

			for (int i = 0; i < KnotsV.Length; i++)
				KnotsV[i] = CGALGlobal.Normalize(KnotsV[i], fisrt, last);
		}

		/// <summary>
		/// Insert a new knot into the surface and return as a new surface.
		/// </summary>
		/// <param name="srf">The surface to insert the knot into.</param>
		/// <param name="u">The parameter to insert the knot at.</param>
		/// <param name="repeat">The number of times to repeat the knot.</param>
		/// <returns>A new surface with the inserted knots.</returns>
		public static NurbsSurface3d InsertKnotU(NurbsSurface3d srf, double u, int repeat = 1)
		{
			var x = NurbsModify.SurfaceKnotInsertU(srf, u, repeat);
			return new NurbsSurface3d(x.degreeU, x.degreeV, x.knotsU, x.knotsV, x.controlPoints);
		}

		/// <summary>
		/// Insert a new knot into the surface and return as a new surface.
		/// </summary>
		/// <param name="srf">The surface to insert the knot into.</param>
		/// <param name="v">The parameter to insert the knot at.</param>
		/// <param name="repeat">The number of times to repeat the knot.</param>
		/// <returns>A new surface with the inserted knots.</returns>
		public static NurbsSurface3d InsertKnotV(NurbsSurface3d srf, double v, int repeat = 1)
		{
			var x = NurbsModify.SurfaceKnotInsertV(srf, v, repeat);
			return new NurbsSurface3d(x.degreeU, x.degreeV, x.knotsU, x.knotsV, x.controlPoints);
		}

		/// <summary>
		/// Split the surface a the parameter and return the two new surfaces.
		/// </summary>
		/// <param name="srf">The surface to split.</param>
		/// <param name="u">The parameter to split the surface at</param>
		/// <returns>The two new surfaces.</returns>
		public static (NurbsSurface3d left, NurbsSurface3d right) SplitU(NurbsSurface3d srf, double u)
		{
			var x = NurbsModify.SurfaceSplitU(srf, u);

			var left = new NurbsSurface3d(x.left.degreeU, x.left.degreeV, x.left.knotsU, x.left.knotsV, x.left.controlPoints);
			var right = new NurbsSurface3d(x.right.degreeU, x.right.degreeV, x.right.knotsU, x.right.knotsV, x.right.controlPoints);

			left.NormalizeKnotsU();
			right.NormalizeKnotsU();

			return (left, right);
		}

		/// <summary>
		/// Split the surface a the parameter and return the two new surfaces.
		/// </summary>
		/// <param name="srf">The surface to split.</param>
		/// <param name="v">The parameter to split the surface at</param>
		/// <returns>The two new surfaces.</returns>
		public static (NurbsSurface3d, NurbsSurface3d) SplitV(NurbsSurface3d srf, double v)
		{
			var x = NurbsModify.SurfaceSplitV(srf, v);

			var left = new NurbsSurface3d(x.left.degreeU, x.left.degreeV, x.left.knotsU, x.left.knotsV, x.left.controlPoints);
			var right = new NurbsSurface3d(x.right.degreeU, x.right.degreeV, x.right.knotsU, x.right.knotsV, x.right.controlPoints);

			left.NormalizeKnotsV();
			right.NormalizeKnotsV();

			return (left, right);
		}
	}

	/// <summary>
	/// Class for representing a non-rational NURBS surface
	/// </summary>
	public class RationalNurbsSurface3d : NurbsSurface3d
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public RationalNurbsSurface3d()
		{

		}

		/// <summary>
		/// Ceate a new surface.
		/// </summary>
		/// <param name="degree_u">The degree on the first dimension.</param>
		/// <param name="degree_v">The degree on the second dimension.</param>
		/// <param name="knots_u">The knots on the first dimension.</param>
		/// <param name="knots_v">The knots on the second dimension.</param>
		/// <param name="control_points">The control points in cartesion coordinates.</param>
		/// <param name="weights">The weights.</param>
		public RationalNurbsSurface3d(int degree_u, int degree_v, IList<double> knots_u, IList<double> knots_v, Vector3d[,] control_points, double[,] weights)
		{
			DegreeU = degree_u;
			DegreeV = degree_v;
			KnotsU = knots_u.ToArray();
			KnotsV = knots_v.ToArray();

			int width = control_points.GetLength(0);
			int height = control_points.GetLength(1);

			ControlPoints = new Vector4d[width, height];

			for (int j = 0; j < height; j++)
				for (int i = 0; i < width; i++)
					ControlPoints[i, j] = NurbsUtil.CartesianToHomogenous(control_points[i, j], weights[i, j]);

		}

		/// <summary>
		/// Ceate a new surface.
		/// </summary>
		/// <param name="degree_u">The degree on the first dimension.</param>
		/// <param name="degree_v">The degree on the second dimension.</param>
		/// <param name="knots_u">The knots on the first dimension.</param>
		/// <param name="knots_v">The knots on the second dimension.</param>
		/// <param name="control_points">The control points in homogenous coordinates.</param>
		public RationalNurbsSurface3d(int degree_u, int degree_v, IList<double> knots_u, IList<double> knots_v, Vector4d[,] control_points)
		{
			DegreeU = degree_u;
			DegreeV = degree_v;
			KnotsU = knots_u.ToArray();
			KnotsV = knots_v.ToArray();

			ControlPoints = CGALGlobal.Copy(control_points);
		}

		/// <summary>
		/// Set the control point.
		/// </summary>
		/// <param name="i">The points first index.</param>
		/// <param name="j">The points second index.</param>
		/// <param name="point">The control point in cartesian coordinates.</param>
		/// <param name="weight">The control points weight.</param>
		public void SetControlPoint(int i, int j, Vector3d point, double weight)
		{
			ControlPoints[i,j] = NurbsUtil.CartesianToHomogenous(point, weight);
		}

		/// <summary>
		/// Insert a new knot into the surface and return as a new surface.
		/// </summary>
		/// <param name="srf">The surface to insert the knot into.</param>
		/// <param name="u">The parameter to insert the knot at.</param>
		/// <param name="repeat">The number of times to repeat the knot.</param>
		/// <returns>A new surface with the inserted knots.</returns>
		public static RationalNurbsSurface3d InsertKnotU(RationalNurbsSurface3d srf, double u, int repeat = 1)
		{
			var x = NurbsModify.SurfaceKnotInsertU(srf, u, repeat);
			return new RationalNurbsSurface3d(x.degreeU, x.degreeV, x.knotsU, x.knotsV, x.controlPoints);
		}

		/// <summary>
		/// Insert a new knot into the surface and return as a new surface.
		/// </summary>
		/// <param name="srf">The surface to insert the knot into.</param>
		/// <param name="v">The parameter to insert the knot at.</param>
		/// <param name="repeat">The number of times to repeat the knot.</param>
		/// <returns>A new surface with the inserted knots.</returns>
		public static RationalNurbsSurface3d InsertKnotV(RationalNurbsSurface3d srf, double v, int repeat = 1)
		{
			var x = NurbsModify.SurfaceKnotInsertV(srf, v, repeat);
			return new RationalNurbsSurface3d(x.degreeU, x.degreeV, x.knotsU, x.knotsV, x.controlPoints);
		}

		/// <summary>
		/// Split the surface a the parameter and return the two new surfaces.
		/// </summary>
		/// <param name="srf">The surface to split.</param>
		/// <param name="u">The parameter to split the surface at</param>
		/// <returns>The two new surfaces.</returns>
		public static (RationalNurbsSurface3d, RationalNurbsSurface3d) SplitU(RationalNurbsSurface3d srf, double u)
        {
			var x = NurbsModify.SurfaceSplitU(srf, u);

			var left = new RationalNurbsSurface3d(x.left.degreeU, x.left.degreeV, x.left.knotsU, x.left.knotsV, x.left.controlPoints);
			var right = new RationalNurbsSurface3d(x.right.degreeU, x.right.degreeV, x.right.knotsU, x.right.knotsV, x.right.controlPoints);

			left.NormalizeKnotsU();
			right.NormalizeKnotsU();

			return (left, right);
		}

		/// <summary>
		/// Split the surface a the parameter and return the two new surfaces.
		/// </summary>
		/// <param name="srf">The surface to split.</param>
		/// <param name="v">The parameter to split the surface at</param>
		/// <returns>The two new surfaces.</returns>
		public static (RationalNurbsSurface3d, RationalNurbsSurface3d) SplitV(RationalNurbsSurface3d srf, double v)
		{
			var x = NurbsModify.SurfaceSplitV(srf, v);

			var left = new RationalNurbsSurface3d(x.left.degreeU, x.left.degreeV, x.left.knotsU, x.left.knotsV, x.left.controlPoints);
			var right = new RationalNurbsSurface3d(x.right.degreeU, x.right.degreeV, x.right.knotsU, x.right.knotsV, x.right.controlPoints);

			left.NormalizeKnotsV();
			right.NormalizeKnotsV();

			return (left, right);
		}

	}

}

