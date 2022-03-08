using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// Weighted point class
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class HPoint2<K> : HPoint2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Create a new weighted point.
        /// </summary>
        public HPoint2() : base(new K())
        {

        }

        /// <summary>
        /// Create a new weighted point from a value and weight as 1.
        /// </summary>
        /// <param name="v">The points value.</param>
        public HPoint2(double v) : base(v, v, 1, new K())
        {

        }

        /// <summary>
        /// Create a new weighted point from a x, y value and weight as 1.
        /// </summary>
        /// <param name="x">The points x value.</param>
        /// <param name="y">The points y value.</param>
        public HPoint2(double x, double y) : base(x, y, 1, new K())
        {

        }

        /// <summary>
        /// Create a new weighted point from a x, y value and weight as the w value.
        /// </summary>
        /// <param name="x">The points x value.</param>
        /// <param name="y">The points y value.</param>
        /// <param name="w">The points weight value.</param>
        public HPoint2(double x, double y, double w) : base(x, y, w, new K())
        {

        }

        /// <summary>
        /// Create a new weighted point from a pointer.
        /// </summary>
        /// <param name="ptr">The pointer.</param>
        internal HPoint2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The type of kernel object uses.
        /// </summary>
        public string KernelName => Kernel.Name;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[HPoint2<{0}>: x={1}, y={2}]",
                KernelName, x, y);
        }

        /// <summary>
        /// Create a deep copy of the point.
        /// </summary>
        /// <returns>The deep copy.</returns>
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
        /// Create a new weighted point.
        /// </summary>
        /// <param name="kernel">The points kernel.</param>
        internal HPoint2(CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.HPoint2_Create();
        }

        /// <summary>
        /// Create a new weighted point from a x, y value and weight as the w value.
        /// </summary>
        /// <param name="x">The points x value.</param>
        /// <param name="y">The points y value.</param>
        /// <param name="w">The points weight value.</param>
        /// <param name="kernel">The points kernel.</param>
        internal HPoint2(double x, double y, double w, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.HPoint2_CreateFromPoint(new HPoint2d(x, y, w));
        }

        /// <summary>
        /// Create a new weighted point from a existing ponter and kernel.
        /// </summary>
        /// <param name="kernel">The points kernel.</param>
        /// <param name="ptr">The points pointer</param>
        internal HPoint2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        /// <summary>
        /// The points kernel.
        /// </summary>
        protected private GeometryKernel2 Kernel { get; private set; }

        /// <summary>
        /// Release the pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.HPoint2_Release(Ptr);
        }

        /// <summary>
        /// Release the pointer.
        /// </summary>
        /// <param name="ptr">The pointer to release.</param>
        protected override void ReleasePtr(IntPtr ptr)
        {
            Kernel.HPoint2_Release(ptr);
        }

        /// <summary>
        /// Accessor or the points x value.
        /// </summary>
        public double x
        {
            get { return Kernel.HPoint2_GetX(Ptr); }
            set { Kernel.HPoint2_SetX(Ptr, value); }
        }

        /// <summary>
        /// ccessor or the points y value.
        /// </summary>
        public double y
        {
            get { return Kernel.HPoint2_GetY(Ptr); }
            set { Kernel.HPoint2_SetY(Ptr, value); }
        }


        //public double w
        //{
        //    get { return Kernel.HPoint2_GetW(Ptr); }
        //    set { Kernel.HPoint2_SetW(Ptr, value); }
        //}

        /// <summary>
        /// Round the point.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            this.x = Math.Round(x, digits);
            this.y = Math.Round(y, digits);
            //this.w = Math.Round(w, digits);
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
            //this.w = MathUtil.Clamp(w, min, max);
        }

        /// <summary>
        /// Clamp the point.
        /// </summary>
        public void Clamp01()
        {
            this.x = MathUtil.Clamp01(x);
            this.y = MathUtil.Clamp01(y);
            //this.w = MathUtil.Clamp01(w);
        }

        /// <summary>
        /// Convert to another kernel.
        /// Must provide a different kernel to convert to or
        /// just a deep copy will be returned.
        /// </summary>
        /// <returns>The shape with another kernel type.</returns>
        public HPoint2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.HPoint2_Convert(Ptr, e);
            return new HPoint2<T>(ptr);
        }
    }
}
