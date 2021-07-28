using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Geometry
{
    public interface IGeometry2d
    {

        /// <summary>
        /// Check if the geometries intersects.
        /// </summary>
        /// <param name="geometry">The geometry to check.</param>
        /// <returns>True if there is a intersection.</returns>
        bool DoIntersect(IGeometry2d geometry);

        /// <summary>
        /// Find the intersection with this geometry.
        /// </summary>
        /// <param name="geometry">The geometry to check.</param>
        /// <returns>The intersection result.</returns>
        IntersectionResult2d Intersection(IGeometry2d geometry);

        /// <summary>
        /// Transform the geometry by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        void Transform(Matrix2x2d m);

        /// <summary>
        /// Transform the geometry by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        void Transform(Matrix3x3d m);

        /// <summary>
        /// Transform the geometry by the matrix.
        /// </summary>
        /// <param name="m">The transform.</param>
        void Transform(Matrix4x4d m);

    }
}
