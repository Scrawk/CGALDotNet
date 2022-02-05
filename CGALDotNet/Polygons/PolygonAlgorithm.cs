using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polygons
{
    public abstract class PolygonAlgorithm : CGALObject
    {
        /// <summary>
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

        /// <summary>
        /// Check if the polygon is valid to offset.
        /// Should be simple and ccw.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected void CheckPolygon(Polygon2 polygon)
        {
            if (polygon == null)
                throw new NullReferenceException("The polygon is null.");

            if (!CheckInput) return;

            if (!polygon.IsValid())
                throw new InvalidOperationException("Polygon2 must be simple and ccw.");
        }

        /// <summary>
        /// Check if the polygon is valid to offset.
        /// Should be simple and ccw.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected void CheckPolygon(PolygonWithHoles2 polygon)
        {
            if (polygon == null)
                throw new NullReferenceException("The polygon is null.");

            if (!CheckInput) return;

            if (!polygon.IsValid())
                throw new InvalidOperationException("PolygonWithHoles2 must be simple and ccw and all holes must be simple and cw.");
        }
    }
}
