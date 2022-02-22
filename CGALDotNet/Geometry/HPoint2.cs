using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class HPoint2<K> : HPoint2 where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public HPoint2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public HPoint2(double v) : base(v, v, 1, new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public HPoint2(double x, double y) : base(x, y, 1, new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        public HPoint2(double x, double y, double w) : base(x, y, w, new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal HPoint2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[HPoint2<{0}>: x={1}, y={2}, w={3}]",
                Kernel.Name, x, y, w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HPoint2<K> Copy()
        {
            return new HPoint2<K>(Kernel.HPoint2_Copy(Ptr));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class HPoint2 : CGALObject
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal HPoint2(CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.HPoint2_Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="w"></param>
        /// <param name="kernel"></param>
        internal HPoint2(double x, double y, double w, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.HPoint2_CreateFromPoint(new HPoint2d(x, y, w));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal HPoint2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        /// <summary>
        /// 
        /// </summary>
        protected private GeometryKernel2 Kernel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.HPoint2_Release(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        protected override void ReleasePtr(IntPtr ptr)
        {
            Kernel.HPoint2_Release(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        public double x
        {
            get { return Kernel.HPoint2_GetX(Ptr); }
            set { Kernel.HPoint2_SetX(Ptr, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public double y
        {
            get { return Kernel.HPoint2_GetY(Ptr); }
            set { Kernel.HPoint2_SetY(Ptr, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public double w
        {
            get { return Kernel.HPoint2_GetW(Ptr); }
            set { Kernel.HPoint2_SetW(Ptr, value); }
        }

        /// <summary>
        /// Round the point.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            this.x = Math.Round(x, digits);
            this.y = Math.Round(y, digits);
            this.w = Math.Round(w, digits);
        }

        /// <summary>
        /// Clamp the point.
        /// </summary>
        /// <param name="min">The points min value.</param>
        /// <param name="max">The points max value.</param>
        public void Clamp(double min, double max)
        {
            this.x = MathUtil.Clamp(x, min, max);
            this.y = MathUtil.Clamp(y, min, max);
            this.w = MathUtil.Clamp(w, min, max);
        }

        /// <summary>
        /// Clamp the point.
        /// </summary>
        public void Clamp01()
        {
            this.x = MathUtil.Clamp01(x);
            this.y = MathUtil.Clamp01(y);
            this.w = MathUtil.Clamp01(y);
        }
    }
}
