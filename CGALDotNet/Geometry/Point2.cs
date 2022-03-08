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
    public sealed class Point2<K> : Point2 where K : CGALKernel, new()
    {

        /// <summary>
        /// The unit x point.
        /// </summary>
        public readonly static Point2<K> UnitX = new Point2<K>(1, 0);

        /// <summary>
        /// The unit y point.
        /// </summary>
	    public readonly static Point2<K> UnitY = new Point2<K>(0, 1);

        /// <summary>
        /// A point of zeros.
        /// </summary>
	    public readonly static Point2<K> Zero = new Point2<K>(0);

        /// <summary>
        /// A point of ones.
        /// </summary>
        public readonly static Point2<K> One = new Point2<K>(1);

        /// <summary>
        /// A point of halfs.
        /// </summary>
        public readonly static Point2<K> Half = new Point2<K>(0.5);

        /// <summary>
        /// 
        /// </summary>
        public Point2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        public Point2(double v) : base(v, v, new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point2(double x, double y) : base(x, y, new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal Point2(IntPtr ptr) : base(new K(), ptr)
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
            return string.Format("[Point2<{0}>: x={1}, y={2}]",
                KernelName, x, y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Point2<K> Copy()
        {
            return new Point2<K>(Kernel.Point2_Copy(Ptr));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Point2 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal Point2(CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Point2_Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="kernel"></param>
        internal Point2(double x, double y, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Point2_CreateFromPoint(new Point2d(x,y));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal Point2(CGALKernel kernel, IntPtr ptr) : base(ptr)
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
            Kernel.Point2_Release(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        protected override void ReleasePtr(IntPtr ptr)
        {
            Kernel.Point2_Release(ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        public double x
        {
            get { return Kernel.Point2_GetX(Ptr); }
            set { Kernel.Point2_SetX(Ptr, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public double y
        {
            get { return Kernel.Point2_GetY(Ptr); }
            set { Kernel.Point2_SetY(Ptr, value); }
        }

        /// <summary>
        /// Round the point.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            this.x = Math.Round(x, digits);
            this.y = Math.Round(y, digits);
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
        }

        /// <summary>
        /// Clamp the point.
        /// </summary>
        public void Clamp01()
        {
            this.x = MathUtil.Clamp01(x);
            this.y = MathUtil.Clamp01(y);
        }

        /// <summary>
        /// Convert to another kernel.
        /// Must provide a different kernel to convert to or
        /// just a deep copy will be returned.
        /// </summary>
        /// <returns>The shape with another kernel type.</returns>
        public Point2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.Point2_Convert(Ptr, e);
            return new Point2<T>(ptr);
        }
    }
}
