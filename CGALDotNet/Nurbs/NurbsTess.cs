using System;
using System.Collections.Generic;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Nurbs
{

    internal static class NurbsTess
    {

        /// <summary>
        /// Sample a curves points in a range of equally spaced parametric intervals.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <param name="points">The list of sampled points.</param>
        internal static void GetCartesianPoints(BaseNurbsCurve2d curve, List<Point2d> points, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                points.Add(curve.CartesianPoint(u));
            }
        }

        /// <summary>
        /// Sample a curves tangents in a range of equally spaced parametric intervals.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <param name="tangents">The list of sampled points.</param>
        internal static void GetTangents(BaseNurbsCurve2d curve, List<Vector2d> tangents, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                tangents.Add(curve.Tangent(u));
            }
        }

        /// <summary>
        /// Sample a curves tangents in a range of equally spaced parametric intervals.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <param name="normals">The list of sampled points.</param>
        internal static void GetNormals(BaseNurbsCurve2d curve, List<Vector2d> normals, double start, double end, int numSamples, bool ccw = true)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                normals.Add(curve.Normal(u, ccw));
            }
        }

        /// <summary>
        /// Estimate the length of the curve.
        /// </summary>
        /// <param name="curve">NurbsCurveData object</param>
        /// <param name="start">start parameter for sampling</param>
        /// <param name="end">end parameter for sampling</param>
        /// <param name="numSamples">integer number of samples</param>
        /// <returns>The curves estmated length.</returns>
        internal static double EstimateLength(BaseNurbsCurve2d curve, double start, double end, int numSamples)
        {
            if (numSamples < 2)
                numSamples = 2;

            double span = (end - start) / (numSamples - 1);

            double len = 0;
            var previous = new Point2d();

            for (int i = 0; i < numSamples; i++)
            {
                double u = start + span * i;
                var point = curve.CartesianPoint(u);
       
                if (i > 0)
                    len += Point2d.Distance(previous, point);

                previous = point;
            }

            return len;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srf"></param>
        /// <param name="points"></param>
        /// <param name="startU"></param>
        /// <param name="endU"></param>
        /// <param name="numSamplesU"></param>
        /// <param name="startV"></param>
        /// <param name="endV"></param>
        /// <param name="numSamplesV"></param>
        internal static void GetCartesianPoints(BaseNurbsSurface3d srf, Point3d[,] points, 
            double startU, double endU, int numSamplesU, 
            double startV, double endV, int numSamplesV)
        {
            if (numSamplesU < 2)
                numSamplesU = 2;

            if (numSamplesV < 2)
                numSamplesV = 2;

            double spanU = (endU - startU) / (numSamplesU - 1);
            double spanV = (endV - startV) / (numSamplesV - 1);

            for (int j = 0; j < numSamplesV; j++)
            {
                for (int i = 0; i < numSamplesU; i++)
                {
                    double u = startU + spanU * i;
                    double v = startV + spanV * j;
                    points[i, j] = srf.CartesianPoint(u, v);
                }
        
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srf"></param>
        /// <param name="normals"></param>
        /// <param name="startU"></param>
        /// <param name="endU"></param>
        /// <param name="numSamplesU"></param>
        /// <param name="startV"></param>
        /// <param name="endV"></param>
        /// <param name="numSamplesV"></param>
        internal static void GetNormals(BaseNurbsSurface3d srf, Vector3d[,] normals,
             double startU, double endU, int numSamplesU,
            double startV, double endV, int numSamplesV)
        {
            if (numSamplesU < 2)
                numSamplesU = 2;

            if (numSamplesV < 2)
                numSamplesV = 2;

            double spanU = (endU - startU) / (numSamplesU - 1);
            double spanV = (endV - startV) / (numSamplesV - 1);

            for (int j = 0; j < numSamplesV; j++)
            {
                for (int i = 0; i < numSamplesU; i++)
                {
                    double u = startU + spanU * i;
                    double v = startV + spanV * j;
                    normals[i, j] = srf.Normal(u, v);
                }

            }
        }

    }

}