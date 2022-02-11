using System;
using System.Collections.Generic;
using System.Linq;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Nurbs
{

	public static class NurbsMake
	{
		/// <summary>
		/// 0) build knot vector for curve by normalized chord length
		/// 1) construct effective basis function in square matrix
		/// 2) construct set of coordinattes to interpolate vector
		/// 3) set of control points
		/// 4) solve in all 3 dimensions
		/// </summary>
		/// <param name="degree">The degree of the curve.</param>
		/// <param name="points">The points to interp curve from.</param>
		/// <returns>A curve that passes through all the points.</returns>
		public static NurbsCurve2d FromPoints(int degree, IList<Point2d> points)
		{
			if (points.Count < degree + 1)
				throw new Exception("You need to supply at least degree + 1 points.");

			int columns = points.Count;
			var us = new double[columns];

			for (int i = 1; i < columns; i++)
			{
				var chord = (points[i] - points[i - 1]).Magnitude;
				var last = us[i - 1];
				us[i] = last + chord;
			}

			//normalize
			var max = us[columns - 1];
			for (int i = 1; i < columns; i++)
				us[i] = us[i] / max;

			var knots = new List<double>(degree + 1);
			NurbsUtil.AddRange(knots, degree + 1, 0);

			//we need two more control points, two more knots
			int start = 1;
			int end = columns - degree;
			double invDegree = 1.0 / degree;

			for (int i = start; i < end; i++)
			{
				double weightSums = 0;
				for (int j = 0; j < degree; j++)
					weightSums += us[i + j];

				knots.Add(weightSums * invDegree);
			}

			NurbsUtil.AddRange(knots, degree + 1, 1);

			var A = new double[columns, columns];

			for (int i = 0; i < columns; i++)
			{
				double u = us[i];
				int span = NurbsBasis.FindSpan(degree, knots, u);
				var basisFuncs = NurbsBasis.BSplineBasis(degree, span, knots, u);
				int ls = span - degree;

				for (int j = 0; j < basisFuncs.Length; j++)
					A[i, j + ls] = basisFuncs[j];
			}

			//for each dimension, solve
			const int rows = 2;
			var solutions = new double[rows, columns];

			var system = new LinearSystem(A);
			var b = new double[columns];
			var x = new double[columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
					b[j] = points[j][i];

				system.Solve(b, x);

				for (int j = 0; j < columns; j++)
					solutions[i, j] = x[j];
			}

			var controlPts = new List<Point2d>(columns);
			for (int j = 0; j < columns; j++)
			{
				var v = new Point2d();

				v.x = solutions[0, j];
				v.y = solutions[1, j];

				controlPts.Add(v);
			}

			return new NurbsCurve2d(degree, knots, controlPts);
		}

		/// <summary>
		/// Create a bezier curve from the control points.
		/// </summary>
		/// <param name="controlPoints">Points in counter-clockwise form.</param>
		/// <returns></returns>
		public static NurbsCurve2d BezierCurve(IList<Point2d> controlPoints)
		{
			int count = controlPoints.Count;
			int degree = count - 1;

			var knots = new double[count * 2];
			for (int i = 0; i < count; i++)
			{
				knots[i] = 0;
				knots[count + i] = 1;
			}

			return new NurbsCurve2d(degree, knots, controlPoints);
		}

		/// <summary>
		/// Create a rational bezier curve from the control points and weights.
		/// </summary>
		/// <param name="controlPoints">Points in counter-clockwise form.</param>
		/// <returns></returns>
		public static RationalNurbsCurve2d RationalBezierCurve(IList<HPoint2d> controlPoints)
		{
			int count = controlPoints.Count;
			int degree = count - 1;

			var knots = new double[count * 2];
			for (int i = 0; i < count; i++)
			{
				knots[i] = 0;
				knots[count + i] = 1;
			}

			return new RationalNurbsCurve2d(degree, knots, controlPoints);
		}

		/// <summary>
		/// Create an Circle.
		/// </summary>
		/// <param name="center"></param>
		/// <param name="radius">the radius</param>
		public static RationalNurbsCurve2d Circle(Point2d center, double radius)
		{
			var unitX = Vector2d.UnitX;
			var unitY = Vector2d.UnitY;
			return EllipseArc(center, radius, radius, 0, Math.PI * 2, unitX, unitY);
		}

		/// <summary>
		/// Create an Arc.
		/// </summary>
		/// <param name="center"></param>
		/// <param name="radius">the radius</param>
		/// <param name="startAngle">start angle of the ellipse arc, between 0 and 2pi, where 0 points at the xaxis</param>
		/// <param name="endAngle">end angle of the arc, between 0 and 2pi, greater than the start angle</param>
		public static RationalNurbsCurve2d Arc(Point2d center, double radius, double startAngle, double endAngle)
		{
			var unitX = Vector2d.UnitX;
			var unitY = Vector2d.UnitY;
			return EllipseArc(center, radius, radius, startAngle, endAngle, unitX, unitY);
		}

		/// <summary>
		/// Create an Ellipse.
		/// </summary>
		/// <param name="center"></param>
		/// <param name="xradius">the x radius</param>
		/// <param name="yradius">the y radius</param>
		public static RationalNurbsCurve2d Ellipse(Point2d center, double xradius, double yradius)
		{
			var unitX = Vector2d.UnitX;
			var unitY = Vector2d.UnitY;
			return EllipseArc(center, xradius, yradius, 0, Math.PI * 2, unitX, unitY);
		}

		/// <summary>
		/// Create an EllipseArc.
		/// </summary>
		/// <param name="center"></param>
		/// <param name="xradius">the x radius</param>
		/// <param name="yradius">the y radius</param>
		/// <param name="startAngle">start angle of the ellipse arc, between 0 and 2pi, where 0 points at the xaxis</param>
		/// <param name="endAngle">end angle of the arc, between 0 and 2pi, greater than the start angle</param>
		public static RationalNurbsCurve2d EllipseArc(Point2d center, double xradius, double yradius, double startAngle, double endAngle)
		{
			var unitX = Vector2d.UnitX;
			var unitY = Vector2d.UnitY;
			return EllipseArc(center, xradius, yradius, startAngle, endAngle, unitX, unitY);
		}

		/// <summary>
		/// Generate the control points, weights, and knots of an elliptical arc.
		/// (Corresponds to Algorithm A7.1 from Piegl and Tiller)
		/// </summary>
		/// <param name="center"></param>
		/// <param name="xradius">the x radius</param>
		/// <param name="yradius">the y radius</param>
		/// <param name="startAngle">start angle of the ellipse arc, between 0 and 2pi, where 0 points at the xaxis</param>
		/// <param name="endAngle">end angle of the arc, between 0 and 2pi, greater than the start angle</param>
		/// <param name="xaxis">the x axis</param>
		/// <param name="yaxis">the y axis</param>
		/// <returns></returns>
		public static RationalNurbsCurve2d EllipseArc(Point2d center, double xradius, double yradius, double startAngle, double endAngle, Vector2d xaxis, Vector2d yaxis)
		{
			//if the end angle is less than the start angle, do a circle
			if (endAngle < startAngle)
				endAngle = 2.0 * Math.PI + startAngle;

			double theta = endAngle - startAngle;
			int numArcs = 0;

			//how many arcs?
			if (theta <= Math.PI / 2.0)
				numArcs = 1;
			else
			{
				if (theta <= Math.PI)
					numArcs = 2;
				else if (theta <= 3 * Math.PI / 2.0)
					numArcs = 3;
				else
					numArcs = 4;
			}

			double dtheta = theta / numArcs;
			double w1 = Math.Cos(dtheta / 2.0);

			var P0 = center + (xaxis * (xradius * Math.Cos(startAngle))) + (yaxis * (yradius * Math.Sin(startAngle)));
			var T0 = (yaxis * Math.Cos(startAngle)) - (xaxis * Math.Sin(startAngle));

			var controlPoints = new Point2d[numArcs * 2 + 1];
			var knots = new double[2 * numArcs + 3 + 1];

			int index = 0;
			double angle = startAngle;

			var weights = new double[numArcs * 2 + 1];

			controlPoints[0] = P0;
			weights[0] = 1;

			for (int i = 1; i < numArcs + 1; i++)
			{
				angle += dtheta;
				var P2 = center + (xaxis * (xradius * Math.Cos(angle))) + (yaxis * (yradius * Math.Sin(angle)));

				weights[index + 2] = 1;
				controlPoints[index + 2] = P2;

				var T2 = (yaxis * Math.Cos(angle)) - (xaxis * Math.Sin(angle));

				CurveCurveIntersection result;
				IntersectRays(P0, T0 * (1.0 / T0.Magnitude), P2, T2 * (1.0 / T2.Magnitude), out result);

				var P1 = P0 + (T0 * result.u0);

				weights[index + 1] = w1;
				controlPoints[index + 1] = P1;

				index += 2;

				if (i < numArcs)
				{
					P0 = P2;
					T0 = T2;
				}
			}

			int j = 2 * numArcs + 1;

			for (int i = 0; i < 3; i++)
			{
				knots[i] = 0;
				knots[i + j] = 1;
			}

			switch (numArcs)
			{
				case 2:
					knots[3] = knots[4] = 0.5;
					break;
				case 3:
					knots[3] = knots[4] = 1.0 / 3.0;
					knots[5] = knots[6] = 2.0 / 3.0;
					break;
				case 4:
					knots[3] = knots[4] = 0.25;
					knots[5] = knots[6] = 0.5;
					knots[7] = knots[8] = 0.75;
					break;
			}

			return new RationalNurbsCurve2d(2, knots, controlPoints, weights);
		}

		private struct CurveCurveIntersection
		{
			//where the intersection took place
			//public Vector3d point0;

			//where the intersection took place on the second curve
			//public Vector3d point1;

			//the parameter on the first curve
			public double u0;

			//the parameter on the second curve
			public double u1;
		}

		/// <summary>
		/// Find the closest parameter on two rays, see http://geomalgorithms.com/a07-_distance.html
		/// </summary>
		/// <param name="a0">origin for ray 1</param>
		/// <param name="a">direction of ray 1, assumed normalized</param>
		/// <param name="b0">origin for ray 2</param>
		/// <param name="b">direction of ray 2, assumed normalized</param>
		/// <param name="result">The intersection result.</param>
		/// <returns></returns>
		private static bool IntersectRays(Point2d a0, Vector2d a, Point2d b0, Vector2d b, out CurveCurveIntersection result)
		{
			result = new CurveCurveIntersection();

			var dab = Vector2d.Dot(a, b);
			var dab0 = Vector2d.Dot(a, b0.Vector2d);
			var daa0 = Vector2d.Dot(a, a0.Vector2d);
			var dbb0 = Vector2d.Dot(b, b0.Vector2d);
			var dba0 = Vector2d.Dot(b, a0.Vector2d);
			var daa = Vector2d.Dot(a, a);
			var dbb = Vector2d.Dot(b, b);
			var div = daa * dbb - dab * dab;

			//parallel case
			if (MathUtil.IsZero(div))
				return false;

			var num = dab * (dab0 - daa0) - daa * (dbb0 - dba0);

			result.u1 = num / div;
			result.u0 = (dab0 - daa0 + result.u1 * dab) / daa;

			//result.point0 = (a0 + a * result.u0).xy0;
			//result.point1 = (b0 + b * result.u1).xy0;

			return true;
		}
	}

}









