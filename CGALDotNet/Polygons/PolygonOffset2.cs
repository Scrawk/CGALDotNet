using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polygons
{
    /// <summary>
    /// The generic polgon offset class
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonOffset2<K> : PolygonOffset2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Static instance of polygon offset.
        /// </summary>
        public static readonly PolygonOffset2<K> Instance = new PolygonOffset2<K>();

        /// <summary>
        /// Create new polygon offset.
        /// </summary>
        public PolygonOffset2() : base(new K())
        {

        }

        /// <summary>
        /// Create a interior offset.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="offset">The offset amount</param>
        /// <param name="results">The offset results</param>
        public void CreateInteriorOffset(Polygon2<K> polygon, double offset, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);

            Kernel.CreateInteriorOffset(Ptr, polygon.Ptr, offset);

            int count = BufferSize();
            for (int i = 0; i < count; i++)
            {
                var ptr = GetBufferedPolygon(i);
                results.Add(new Polygon2<K>(ptr));
            }

            ClearBuffer();
        }

        /// <summary>
        /// Create a exterior offset.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="offset">The offset amount</param>
        /// <param name="results">The offset results</param>
        public void CreateExteriorOffset(Polygon2<K> polygon, double offset, List<Polygon2<K>> results)
        {
            CheckPolygon(polygon);

            Kernel.CreateExteriorOffset(Ptr, polygon.Ptr, offset);

            int count = BufferSize();
            for (int i = 0; i < count; i++)
            {
                //First polygon seems to be the bounding box
                //for some reason. Dont want this so remove.
                if (i == 0) continue;

                var ptr = GetBufferedPolygon(i);
                results.Add(new Polygon2<K>(ptr));
            }

            ClearBuffer();
        }

    }

    /// <summary>
    /// The abstract polygon offset class.
    /// </summary>
    public abstract class PolygonOffset2 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonOffset2()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonOffset2(CGALKernel kernel)
        {
            Kernel = kernel.PolygonOffsetKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The offset kernel.
        /// </summary>
        protected private PolygonOffsetKernel2 Kernel { get; private set; }

        /// <summary>
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

        /// <summary>
        /// Get the number off polygons in the buffer.
        /// </summary>
        /// <returns></returns>
        protected int BufferSize()
        {
            return Kernel.PolygonBufferSize(Ptr);
        }

        /// <summary>
        /// Get the unmanaged point to the polygon at the buffer index
        /// </summary>
        /// <param name="index">The index in the buffer.</param>
        /// <returns>The pointer</returns>
        protected IntPtr GetBufferedPolygon(int index)
        {
            return Kernel.GetBufferedPolygon(Ptr, index);
        }

        /// <summary>
        /// Clear the buffer.
        /// </summary>
        protected void ClearBuffer()
        {
            Kernel.ClearPolygonBuffer(Ptr);
        }

        /// <summary>
        /// Check if the polygon is valid to offset.
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
