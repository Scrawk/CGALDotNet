using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// A Vector2 object with kernel type K.
    /// </summary>
    /// <typeparam name="K">The type of kernel.</typeparam>
    public sealed class Vector2<K> : Vector2 where K : CGALKernel, new()
    {

        /// <summary>
        /// The unit x vector.
        /// </summary>
        public readonly static Vector2<K> UnitX = new Vector2<K>(1, 0);

        /// <summary>
        /// The unit y vector.
        /// </summary>
	    public readonly static Vector2<K> UnitY = new Vector2<K>(0, 1);

        /// <summary>
        /// A vector of zeros.
        /// </summary>
	    public readonly static Vector2<K> Zero = new Vector2<K>(0);

        /// <summary>
        /// A vector of ones.
        /// </summary>
        public readonly static Vector2<K> One = new Vector2<K>(1);

        /// <summary>
        /// Create a new Vector.
        /// </summary>
        public Vector2() : base(new K())
        {

        }

        /// <summary>
        /// Create a new vector filled with the value.
        /// </summary>
        /// <param name="v">The value to fill.</param>
        public Vector2(double v) : base(v, v, new K())
        {

        }

        /// <summary>
        /// Create a new vector with the values x and y.
        /// </summary>
        /// <param name="x">The vectors x value.</param>
        /// <param name="y">The vectors y value.</param>
        public Vector2(double x, double y) : base(x, y, new K())
        {

        }

        /// <summary>
        /// Create a new vector from a existing pointer.
        /// </summary>
        /// <param name="ptr">The pointer object.</param>
        internal Vector2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The type of kernel object uses.
        /// </summary>
        public string KernelName => Kernel.Name;

        /// <summary>
        /// Vector information.
        /// </summary>
        /// <returns>The vectors string information.</returns>
        public override string ToString()
        {
            return string.Format("[Vector2<{0}>: x={1}, y={2}]",
                KernelName, x, y);
        }

        /// <summary>
        /// Create a deep copy of the vector.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public Vector2<K> Copy()
        {
            return new Vector2<K>(Kernel.Vector2_Copy(Ptr));
        }

    }

    /// <summary>
    /// The vectors abstract bass class.
    /// </summary>
    public abstract class Vector2 : CGALObject
    {
        /// <summary>
        /// Create a new vector with the kernel.
        /// </summary>
        /// <param name="kernel">The vectors kernel.</param>
        internal Vector2(CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Vector2_Create();
        }

        /// <summary>
        /// Create a new vector from the x and y values.
        /// </summary>
        /// <param name="x">The vectors x value.</param>
        /// <param name="y">The vectors y value.</param>
        /// <param name="kernel">The vectors kernel.</param>
        internal Vector2(double x, double y, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Vector2_CreateFromVector(new Vector2d(x, y));
        }

        /// <summary>
        /// Create a new vector from a existing pointer.
        /// </summary>
        /// <param name="kernel">The vectors kernel.</param>
        /// <param name="ptr">The existing pointer.</param>
        internal Vector2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        /// <summary>
        /// The vectors kernel.
        /// </summary>
        protected private GeometryKernel2 Kernel { get; private set; }

        /// <summary>
        /// The vectors sqr magnitude.
        /// </summary>
        public double Magnitude => Kernel.Vector2_Magnitude(Ptr);

        /// <summary>
        /// The vectors sqr magnitude.
        /// </summary>
        public double SqrMagnitude => Kernel.Vector2_SqrLength(Ptr);

        /// <summary>
        /// Access the x component.
        /// </summary>
        public double x
        {
            get { return Kernel.Vector2_GetX(Ptr); }
            set { Kernel.Vector2_SetX(Ptr, value); }
        }

        /// <summary>
        /// Access the y component.
        /// </summary>
        public double y
        {
            get { return Kernel.Vector2_GetY(Ptr); }
            set { Kernel.Vector2_SetY(Ptr, value); }
        }

        /// <summary>
        /// Release the vectors pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Vector2_Release(Ptr);
        }

        /// <summary>
        /// Release a pointer to a vector.
        /// </summary>
        /// <param name="ptr">The pointer to release.</param>
        protected override void ReleasePtr(IntPtr ptr)
        {
            Kernel.Vector2_Release(ptr);
        }

        /// <summary>
        /// Round the vector.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            this.x = Math.Round(x, digits);
            this.y = Math.Round(y, digits);
        }

        /// <summary>
        /// Clamp the vector.
        /// </summary>
        /// <param name="min">The vectors min value.</param>
        /// <param name="max">The vectors max value.</param>
        public void Clamp(double min, double max)
        {
            this.x = MathUtil.Clamp(x, min, max);
            this.y = MathUtil.Clamp(y, min, max);
        }

        /// <summary>
        /// Clamp the vector.
        /// </summary>
        public void Clamp01()
        {
            this.x = MathUtil.Clamp01(x);
            this.y = MathUtil.Clamp01(y);
        }

        /// <summary>
        /// Normalize the vector.
        /// </summary>
        public void Normalize()
        {
            Kernel.Vector2_Normalize(Ptr);
        }

        /// <summary>
        /// Convert to another kernel.
        /// Must provide a different kernel to convert to or
        /// just a deep copy will be returned.
        /// </summary>
        /// <returns>The shape with another kernel type.</returns>
        public Vector2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.Vector2_Convert(Ptr, e);
            return new Vector2<T>(ptr);
        }

    }
}
