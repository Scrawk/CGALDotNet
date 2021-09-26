using System;
using System.Collections.Generic;
using System.Linq;

using CGALDotNet.Geometry;

namespace CGALDotNet.Nurbs
{
	internal struct NurbsCurveParams2d
	{
		public int degree;
		public List<double> knots;
		public List<Vector3d> controlPoints;
	}

	/// <summary>
	/// Class for holding a polynomial B-spline curve
	/// </summary>
	public class NurbsCurve2d
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public NurbsCurve2d()
		{

		}

		/// <summary>
		/// Create a curve new curve.
		/// </summary>
		/// <param name="degree">The curves degree.</param>
		/// <param name="knots">The curves knots.</param>
		/// <param name="control_points">The curves control points.</param>
		public NurbsCurve2d(int degree, IList<double> knots, IList<Vector2d> control_points)
		{
			Degree = degree;
			Knots = knots.ToArray();

			ControlPoints = new Vector3d[control_points.Count];
			for (int i = 0; i < control_points.Count; i++)
				SetControlPoint(i, control_points[i]);
		}

		/// <summary>
		/// Create a curve new curve.
		/// </summary>
		/// <param name="degree">The curves degree.</param>
		/// <param name="knots">The curves knots.</param>
		/// <param name="control_points">The curves control points in cartesian coordinates.</param>
		internal NurbsCurve2d(int degree, IList<double> knots, IList<Vector3d> control_points)
		{
			Degree = degree;
			Knots = knots.ToArray();

			ControlPoints = new Vector3d[control_points.Count];
			for (int i = 0; i < control_points.Count; i++)
				ControlPoints[i] = new Vector3d(control_points[i].xy, 1);

		}

		/// <summary>
		/// Is this a rational curve.
		/// </summary>
		public bool IsRational => this is RationalNurbsCurve2d;

		/// <summary>
		/// The curves degree.
		/// </summary>
		public int Degree { get; protected set; }

		/// <summary>
		/// The curves knots.
		/// </summary>
		public double[] Knots { get; protected set; }

		/// <summary>
		/// The number of control points.
		/// </summary>
		public int ControlCount => ControlPoints.Length;

		/// <summary>
		/// The curves control points in homogenous coordinates.
		/// The w coordinate stores the weight.
		/// If the curve is not rational then this is 1 by default.
		/// </summary>
		internal Vector3d[] ControlPoints { get; set; }

		/// <summary>
		/// Is this a valid curve.
		/// </summary>
		public bool IsValid => NurbsCheck.CurveIsValid(this);

		/// <summary>
		/// Is this a closed curve.
		/// </summary>
		public bool IsClosed => NurbsCheck.CurveIsClosed(this);

		/// <summary>
		/// Get the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <returns>The control point in cartesian coordinates.</returns>
		public Vector2d GetControlPoint(int i)
		{
			return NurbsUtil.HomogenousToCartesian(ControlPoints[i]);
		}

		/// <summary>
		/// Get the control points
		/// </summary>
		/// <param name="points">The list to copy the points into.</param>
		public void GetControlPoints(List<Vector2d> points)
		{
			for (int i = 0; i < ControlPoints.Length; i++)
				points.Add(NurbsUtil.HomogenousToCartesian(ControlPoints[i]));
		}

		/// <summary>
		/// Set the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <param name="point">The control point in cartesian coordinates.</param>
		public void SetControlPoint(int i, Vector2d point)
		{
			ControlPoints[i] = new Vector3d(point, 1);
		}

		/// <summary>
		/// Get the point at parameter u.
		/// </summary>
		/// <param name="u">The parameter.</param>
		/// <returns>The point at u.</returns>
		public Vector2d Point(double u)
		{
			return NurbsEval.CurvePoint(this, u);
		}

		/// <summary>
		/// Get the tangent at parameter u.
		/// </summary>
		/// <param name="u">The parameter.</param>
		/// <returns>The tangent at u.</returns>
		public Vector2d Tangent(double u)
		{
			return NurbsEval.CurveTangent(this, u);
		}

		/// <summary>
		/// Sample a curves points in a range of equally spaced parametric intervals.
		/// </summary>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <param name="points">The list of sampled points.</param>
		public void GetPoints(List<Vector2d> points, int samples)
		{
			NurbsTess.GetPoints(this, points, 0, 1, samples);
		}

		/// <summary>
		/// Sample a curves points in a range of equally spaced parametric intervals.
		/// </summary>
		/// <param name="start">The parameter to start sampling.</param>
		/// <param name="end">The parameter to end sampling.</param>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <param name="points">The list of sampled points.</param>
		public void GetPoints(List<Vector2d> points, double start, double end, int samples)
		{
			NurbsTess.GetPoints(this, points, start, end, samples);
		}

		/// <summary>
		/// Sample a curves tangents in a range of equally spaced parametric intervals.
		/// </summary>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <param name="tangents">The list of sampled points.</param>
		public void GetTangents(List<Vector2d> tangents, int samples)
		{
			NurbsTess.GetTangents(this, tangents, 0, 1, samples);
		}

		/// <summary>
		/// Estimate the length of the curve.
		/// </summary>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <returns>The estimated length.</returns>
		public double EstimateLength(int samples)
		{
			return NurbsTess.EstimateLength(this, 0, 1, samples);
		}

		/// <summary>
		/// Normlize the curves knots so the first knot starts at 0
		/// and the last knot ends at 1.
		/// </summary>
		public void NormalizeKnots()
		{
			double fisrt = Knots[0];
			double last = Knots.Last();

			for (int i = 0; i < Knots.Length; i++)
				Knots[i] = CGALGlobal.Normalize(Knots[i], fisrt, last);
		}

		/// <summary>
		/// Insert a new knot into the curve and return as a new curve.
		/// </summary>
		/// <param name="crv">The curve to insert the knot into.</param>
		/// <param name="u">The parameter to insert the knot at.</param>
		/// <param name="repeat">The number of times to repeat the knot.</param>
		/// <returns>A new curve with the inserted knots.</returns>
		public static NurbsCurve2d InsertKnot(NurbsCurve2d crv, double u, int repeat = 1)
		{
			var x = NurbsModify.CurveKnotInsert(crv, u, repeat);
			return new NurbsCurve2d(x.degree, x.knots, x.controlPoints);
		}

		/// <summary>
		/// Split the curve a the parameter and return the two new curves.
		/// </summary>
		/// <param name="crv">The curve to split.</param>
		/// <param name="u">The parameter to split the curve at</param>
		/// <returns>The two new curves.</returns>
		public static (NurbsCurve2d left, NurbsCurve2d right) Split(NurbsCurve2d crv, double u)
		{
			var x = NurbsModify.CurveSplit(crv, u);

			var left = new NurbsCurve2d(x.left.degree, x.left.knots, x.left.controlPoints);
			var right = new NurbsCurve2d(x.right.degree, x.right.knots, x.right.controlPoints);

			left.NormalizeKnots();
			right.NormalizeKnots();

			return (left, right);
		}

	}

	/// <summary>
	/// Class for holding a rational B-spline curve
	/// </summary>
	public class RationalNurbsCurve2d : NurbsCurve2d
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public RationalNurbsCurve2d()
		{

		}

		/// <summary>
		/// Create a curve new curve.
		/// </summary>
		/// <param name="degree">The curves degree.</param>
		/// <param name="knots">The curves knots.</param>
		/// <param name="control_points">The curves control points.</param>
		/// <param name="weights">The curves weights.</param>
		public RationalNurbsCurve2d(int degree, IList<double> knots, IList<Vector2d> control_points, IList<double> weights)
		{
			Degree = degree;
			Knots = knots.ToArray();

			ControlPoints = new Vector3d[control_points.Count];
			for (int i = 0; i < control_points.Count; i++)
				SetControlPoint(i, control_points[i], weights[i]);
		}

		/// <summary>
		/// Create a curve new curve.
		/// </summary>
		/// <param name="degree">The curves degree.</param>
		/// <param name="knots">The curves knots.</param>
		/// <param name="control_points">The curves control points in homogenous coordinates 
		/// with the weight as the w coordinate.</param>
		public RationalNurbsCurve2d(int degree, IList<double> knots, IList<Vector3d> control_points)
		{
			Degree = degree;
			Knots = knots.ToArray();

			ControlPoints = new Vector3d[control_points.Count];
			for (int i = 0; i < control_points.Count; i++)
				ControlPoints[i] = control_points[i];
		}

		/// <summary>
		/// Set the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <param name="point">The control point in cartesian coordinates.</param>
		/// <param name="weight">The control points weight.</param>
		public void SetControlPoint(int i, Vector2d point, double weight)
		{
			ControlPoints[i] = NurbsUtil.CartesianToHomogenous(point, weight);
		}

		/// <summary>
		/// Insert a new knot into the curve and return as a new curve.
		/// </summary>
		/// <param name="crv">The curve to insert the knot into.</param>
		/// <param name="u">The parameter to insert the knot at.</param>
		/// <param name="repeat">The number of times to repeat the knot.</param>
		/// <returns>A new curve with the inserted knots.</returns>
		public static RationalNurbsCurve2d InsertKnot(RationalNurbsCurve2d crv, double u, int repeat = 1)
		{
			var x = NurbsModify.CurveKnotInsert(crv, u, repeat);
			return new RationalNurbsCurve2d(x.degree, x.knots, x.controlPoints);
		}

		/// <summary>
		/// Split the curve a the parameter and return the two new curves.
		/// </summary>
		/// <param name="crv">The curve to split.</param>
		/// <param name="u">The parameter to split the curve at</param>
		/// <returns>The two new curves.</returns>
		public static (RationalNurbsCurve2d left, RationalNurbsCurve2d right) Split(RationalNurbsCurve2d crv, double u)
		{
			var x = NurbsModify.CurveSplit(crv, u);

			var left = new RationalNurbsCurve2d(x.left.degree, x.left.knots, x.left.controlPoints);
			var right = new RationalNurbsCurve2d(x.right.degree, x.right.knots, x.right.controlPoints);

			left.NormalizeKnots();
			right.NormalizeKnots();

			return (left, right);
		}

	}

}












