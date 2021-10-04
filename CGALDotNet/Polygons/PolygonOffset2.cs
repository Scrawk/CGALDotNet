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
        /// <param name="result">The offset polygon</param>
        public bool CreateInteriorOffset(Polygon2<K> polygon, double offset, out Polygon2<K> result)
        {
            result = null;
            CheckPolygon(polygon);

            Kernel.CreateInteriorOffset(Ptr, polygon.Ptr, offset);

            int count = BufferSize();
            if (count > 0)
            {
                var ptr = GetBufferedPolygon(0);
                result = new Polygon2<K>(ptr);
                ClearBuffer();
                return true;
            }
            else
            {
                ClearBuffer();
                return false;
            }
        }

        /// <summary>
        /// Create a exterior offset.
        /// </summary>
        /// <param name="polygon">The polygon to offset.</param>
        /// <param name="offset">The offset amount</param>
        /// <param name="result">The offset polygon</param>
        public bool CreateExteriorOffset(Polygon2<K> polygon, double offset, out Polygon2<K> result)
        {
            result = null;
            CheckPolygon(polygon);

            Kernel.CreateExteriorOffset(Ptr, polygon.Ptr, offset);

            int count = BufferSize();

            //First polygon seems to be the bounding box
            //for some reason. Dont want this so remove.
            if (count >= 2)
            {
                var ptr = GetBufferedPolygon(1);
                result = new Polygon2<K>(ptr);
                ClearBuffer();
                return true;
            }
            else
            {
                ClearBuffer();
                return false;
            }
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
