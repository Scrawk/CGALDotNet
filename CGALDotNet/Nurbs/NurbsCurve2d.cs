using System;
using System.Collections.Generic;
using System.Linq;

using CGALDotNetGeometry.Numerics;


/// <summary>
/// Not part of CGAL.
/// Implementation found https://github.com/pboyer/verb and https://github.com/pradeep-pyro/tinynurbs
/// </summary>
namespace CGALDotNet.Nurbs
{
	internal struct NurbsCurveParams2d
	{
		public int degree;
		public List<double> knots;
		public List<HPoint2d> controlPoints;
	}

	/// <summary>
	/// Class for holding a polynomial B-spline curve
	/// </summary>
	public abstract class BaseNurbsCurve2d
	{

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BaseNurbsCurve2d()
		{

		}

		/// <summary>
		/// Is this a rational curve.
		/// </summary>
		public abstract bool IsRational { get; }

		/// <summary>
		/// The curves degree.
		/// </summary>
		public abstract int Degree { get; }

		/// <summary>
		/// The curves knots.
		/// </summary>
		public double[] Knots { get; protected set; }

		/// <summary>
		/// The number of control points.
		/// </summary>
		public abstract int Count { get; }

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
		public abstract Point2d GetCartesianControlPoint(int i);

		/// <summary>
		/// Get the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <returns>The control point in homogeneous coordinates.</returns>
		public abstract HPoint2d GetHomogeneousControlPoint(int i);

		/// <summary>
		/// Get the control points
		/// </summary>
		/// <param name="points">The list to copy the points into.</param>
		public abstract void GetCartesianControlPoints(List<Point2d> points);

		/// <summary>
		/// Set the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <param name="point">The control point in cartesian coordinates.</param>
		public abstract void SetCartesianControlPoint(int i, Point2d point);

		/// <summary>
		/// Get the point at parameter u.
		/// </summary>
		/// <param name="u">The parameter.</param>
		/// <returns>The point at u.</returns>
		public Point2d CartesianPoint(double u)
        {
			return NurbsEval.CartesianCurvePoint(this, u);
		}

		/// <summary>
		/// Sample a curves points in a range of equally spaced parametric intervals.
		/// </summary>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <param name="points">The list of sampled points.</param>
		public abstract void GetCartesianPoints(List<Point2d> points, int samples);

		/// <summary>
		/// Translate the triangulation.
		/// </summary>
		/// <param name="translation">The amount to translate.</param>
		public void Translate(Point2d translation)
        {
			Transform(translation, Radian.A0, 1);
        }

		/// <summary>
		/// Rotate the triangulation.
		/// </summary>
		/// <param name="rotation">The amount to rotate in radians.</param>
		public void Rotate(Radian rotation)
        {
			Transform(Point2d.Zero, rotation, 1);
		}

		/// <summary>
		/// Scale the triangulation.
		/// </summary>
		/// <param name="scale">The amount to scale.</param>
		public void Scale(double scale)
        {
			Transform(Point2d.Zero, Radian.A0, scale);
		}

		/// <summary>
		/// Transform the triangulation with a TRS matrix.
		/// </summary>
		/// <param name="translation">The amount to translate.</param>
		/// <param name="rotation">The amount to rotate.</param>
		/// <param name="scale">The amount to scale.</param>
		public abstract void Transform(Point2d translation, Radian rotation, double scale);

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
		/// Sample a curves tangents in a range of equally spaced parametric intervals.
		/// </summary>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <param name="tangents">The list of sampled points.</param>
		public void GetTangents(List<Vector2d> tangents, int samples)
		{
			NurbsTess.GetTangents(this, tangents, 0, 1, samples);
		}

		/// <summary>
		/// Get the tangent at parameter u.
		/// </summary>
		/// <param name="u">The parameter.</param>
		/// <returns>The tangent at u.</returns>
		public Vector2d Normal(double u, bool ccw = false)
		{
			return NurbsEval.CurveNormal(this, u, ccw);
		}

		/// <summary>
		/// Sample a curves tangents in a range of equally spaced parametric intervals.
		/// </summary>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <param name="normals">The list of sampled points.</param>
		public void GetNormals(List<Vector2d> normals, int samples, bool ccw = false)
		{
			NurbsTess.GetNormals(this, normals, 0, 1, samples, ccw);
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
				Knots[i] = MathUtil.Normalize(Knots[i], fisrt, last);
		}

	}

	/// <summary>
	/// Class for holding a polynomial B-spline curve
	/// </summary>
	public class NurbsCurve2d : BaseNurbsCurve2d
	{

		private int m_degree;

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
		public NurbsCurve2d(int degree, IList<double> knots, IList<Point2d> control_points)
		{
			m_degree = degree;
			Knots = knots.ToArray();

			CartesianControlPoints = new Point2d[control_points.Count];
			for (int i = 0; i < control_points.Count; i++)
				CartesianControlPoints[i] = control_points[i];
		}

		/// <summary>
		/// Create a curve new curve.
		/// </summary>
		/// <param name="degree">The curves degree.</param>
		/// <param name="knots">The curves knots.</param>
		/// <param name="control_points">The curves control points in cartesian coordinates.</param>
		internal NurbsCurve2d(int degree, IList<double> knots, IList<HPoint2d> control_points)
		{
			m_degree = degree;
			Knots = knots.ToArray();

			CartesianControlPoints = new Point2d[control_points.Count];
			for (int i = 0; i < control_points.Count; i++)
				CartesianControlPoints[i] = control_points[i].Cartesian;

		}

		/// <summary>
		/// Is this a rational curve.
		/// </summary>
		public override bool IsRational => false;

		/// <summary>
		/// The curves degree.
		/// </summary>
		public override int Degree => m_degree;

		/// <summary>
		/// The number of control points.
		/// </summary>
		public override int Count => CartesianControlPoints.Length;

		/// <summary>
		/// The curves control points in cartesian coordinates.
		/// </summary>
		internal Point2d[] CartesianControlPoints { get; set; }

		/// <summary>
		/// Get the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <returns>The control point in cartesian coordinates.</returns>
		public override Point2d GetCartesianControlPoint(int i)
		{
			return CartesianControlPoints[i];
		}

		/// <summary>
		/// Get the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <returns>The control point in homogeneous coordinates.</returns>
		public override HPoint2d GetHomogeneousControlPoint(int i)
        {
			return CartesianControlPoints[i].Homogenous;
		}

		/// <summary>
		/// Get the control points
		/// </summary>
		/// <param name="points">The list to copy the points into.</param>
		public override void GetCartesianControlPoints(List<Point2d> points)
		{
			for (int i = 0; i < CartesianControlPoints.Length; i++)
				points.Add(CartesianControlPoints[i]);
		}

		/// <summary>
		/// Set the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <param name="point">The control point in cartesian coordinates.</param>
		public override void SetCartesianControlPoint(int i, Point2d point)
		{
			CartesianControlPoints[i] = point;
		}

		/// <summary>
		/// Sample a curves points in a range of equally spaced parametric intervals.
		/// </summary>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <param name="points">The list of sampled points.</param>
		public override void GetCartesianPoints(List<Point2d> points, int samples)
		{
			NurbsTess.GetCartesianPoints(this, points, 0, 1, samples);
		}

		/// <summary>
		/// Transform the triangulation with a TRS matrix.
		/// </summary>
		/// <param name="translation">The amount to translate.</param>
		/// <param name="rotation">The amount to rotate.</param>
		/// <param name="scale">The amount to scale.</param>
		public override void Transform(Point2d translation, Radian radian, double scale)
		{
			Matrix4x4d T = Matrix4x4d.Translate(translation.xy0);
			Matrix4x4d R = Matrix3x3d.RotateZ(radian).ToMatrix4x4d();
			Matrix4x4d S = Matrix4x4d.Scale(scale);

			var M = T * R * S;

			for (int i = 0; i < Count; i++)
				CartesianControlPoints[i] = (M * CartesianControlPoints[i].xy01).xy;
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
			var param = NurbsModify.CurveKnotInsert(crv, u, repeat);
			return new NurbsCurve2d(param.degree, param.knots, param.controlPoints);
		}

		/// <summary>
		/// Split the curve a the parameter and return the two new curves.
		/// </summary>
		/// <param name="crv">The curve to split.</param>
		/// <param name="u">The parameter to split the curve at</param>
		/// <returns>The two new curves.</returns>
		public static void Split(NurbsCurve2d crv, double u, out NurbsCurve2d left, out NurbsCurve2d right)
		{
			NurbsCurveParams2d leftParam, rightParam;
			NurbsModify.CurveSplit(crv, u, out leftParam, out rightParam);

			left = new NurbsCurve2d(leftParam.degree, leftParam.knots, leftParam.controlPoints);
			right = new NurbsCurve2d(rightParam.degree, rightParam.knots, rightParam.controlPoints);

			left.NormalizeKnots();
			right.NormalizeKnots();
		}

	}

	/// <summary>
	/// Class for holding a polynomial B-spline curve
	/// </summary>
	public class RationalNurbsCurve2d : BaseNurbsCurve2d
	{

		private int m_degree;

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
		public RationalNurbsCurve2d(int degree, IList<double> knots, IList<Point2d> control_points, IList<double> weights)
		{
			m_degree = degree;
			Knots = knots.ToArray();

			HomogeneousControlPoints = new HPoint2d[control_points.Count];
			for (int i = 0; i < control_points.Count; i++)
				HomogeneousControlPoints[i] = control_points[i].ToHomogenous(weights[i]);
		}

		/// <summary>
		/// Create a curve new curve.
		/// </summary>
		/// <param name="degree">The curves degree.</param>
		/// <param name="knots">The curves knots.</param>
		/// <param name="control_points">The curves control points in cartesian coordinates.</param>
		internal RationalNurbsCurve2d(int degree, IList<double> knots, IList<HPoint2d> control_points)
		{
			m_degree = degree;
			Knots = knots.ToArray();

			HomogeneousControlPoints = new HPoint2d[control_points.Count];
			for (int i = 0; i < control_points.Count; i++)
				HomogeneousControlPoints[i] = control_points[i];

		}

		/// <summary>
		/// Is this a rational curve.
		/// </summary>
		public override bool IsRational => true;

		/// <summary>
		/// The curves degree.
		/// </summary>
		public override int Degree => m_degree;

		/// <summary>
		/// The number of control points.
		/// </summary>
		public override int Count => HomogeneousControlPoints.Length;

		/// <summary>
		/// The curves control points in homogegous coordinates.
		/// </summary>
		internal HPoint2d[] HomogeneousControlPoints { get; set; }

		/// <summary>
		/// Get the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <returns>The control point in cartesian coordinates.</returns>
		public override Point2d GetCartesianControlPoint(int i)
		{
			return HomogeneousControlPoints[i].Cartesian;
		}

		/// <summary>
		/// Get the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <returns>The control point in homogeneous coordinates.</returns>
		public override HPoint2d GetHomogeneousControlPoint(int i)
		{
			return HomogeneousControlPoints[i];
		}

		/// <summary>
		/// Get the control points
		/// </summary>
		/// <param name="points">The list to copy the points into.</param>
		public override void GetCartesianControlPoints(List<Point2d> points)
		{
			for (int i = 0; i < HomogeneousControlPoints.Length; i++)
				points.Add(HomogeneousControlPoints[i].Cartesian);
		}

		/// <summary>
		/// Set the control point.
		/// </summary>
		/// <param name="i">The points index.</param>
		/// <param name="point">The control point in cartesian coordinates.</param>
		public override void SetCartesianControlPoint(int i, Point2d point)
		{
			HomogeneousControlPoints[i] = point.Homogenous;
		}

		/// <summary>
		/// Sample a curves points in a range of equally spaced parametric intervals.
		/// </summary>
		/// <param name="samples">The numbers times to sample the curve.</param>
		/// <param name="points">The list of sampled points.</param>
		public override void GetCartesianPoints(List<Point2d> points, int samples)
		{
			NurbsTess.GetCartesianPoints(this, points, 0, 1, samples);
		}


		/// <summary>
		/// Transform the triangulation with a TRS matrix.
		/// </summary>
		/// <param name="translation">The amount to translate.</param>
		/// <param name="rotation">The amount to rotate.</param>
		/// <param name="scale">The amount to scale.</param>
		public override void Transform(Point2d translation, Radian radian, double scale)
		{
			Matrix4x4d T = Matrix4x4d.Translate(translation.xy0);
			Matrix4x4d R = Matrix3x3d.RotateZ(radian).ToMatrix4x4d();
			Matrix4x4d S = Matrix4x4d.Scale(scale);

			var M = T * R * S;

			for (int i = 0; i < Count; i++)
            {
				var pointw = HomogeneousControlPoints[i];
				var point = (M * pointw.Cartesian.xy01).xy;
				HomogeneousControlPoints[i] = point.ToHomogenous(pointw.w);
			}
				
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
			var param = NurbsModify.CurveKnotInsert(crv, u, repeat);
			return new RationalNurbsCurve2d(param.degree, param.knots, param.controlPoints);
		}

		/// <summary>
		/// Split the curve a the parameter and return the two new curves.
		/// </summary>
		/// <param name="crv">The curve to split.</param>
		/// <param name="u">The parameter to split the curve at</param>
		/// <returns>The two new curves.</returns>
		public static void Split(RationalNurbsCurve2d crv, double u, out RationalNurbsCurve2d left, out RationalNurbsCurve2d right)
		{
			NurbsCurveParams2d leftParam, rightParam;
			NurbsModify.CurveSplit(crv, u, out leftParam, out rightParam);

			left = new RationalNurbsCurve2d(leftParam.degree, leftParam.knots, leftParam.controlPoints);
			right = new RationalNurbsCurve2d(rightParam.degree, rightParam.knots, rightParam.controlPoints);

			left.NormalizeKnots();
			right.NormalizeKnots();
		}

	}

}












