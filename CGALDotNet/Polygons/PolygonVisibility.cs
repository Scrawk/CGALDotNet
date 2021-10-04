using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polygons
{
    /// <summary>
    /// The generic polgon visibility class
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonVisibility<K> : PolygonVisibility where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of polygon visibility.
        /// </summary>
        public static readonly PolygonVisibility<K> Instance = new PolygonVisibility<K>();

        /// <summary>
        /// Create new polygon visibility.
        /// </summary>
        public PolygonVisibility() : base(new K())
        {

        }

        public void Test()
        {
            Kernel.Test();
        }

    }

    /// <summary>
    /// The abstract polygon visibility class.
    /// </summary>
    public abstract class PolygonVisibility : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonVisibility()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonVisibility(CGALKernel kernel)
        {
            Kernel = kernel.PolygonVisibilityKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The offset kernel.
        /// </summary>
        protected private PolygonVisibilityKernel Kernel { get; private set; }

        /// <summary>
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

        /// <summary>
        /// Check if the polygon is valid.
        /// Should be simple and ccw.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        /// <returns>True if valid</returns>
        public bool IsValid(Polygon2 polygon)
        {
            if (!CheckInput)
                return true;
            else
                return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        /// <summary>
        /// Check if the polygon is valid to offset.
        /// Should be simple and ccw.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected void CheckPolygon(Polygon2 polygon)
        {
            if (!CheckInput) return;

            if (!IsValid(polygon))
                throw new Exception("Poylgon must be simple and ccw to offset.");
        }

        /// <summary>
        /// Release the unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
