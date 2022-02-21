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
        /// Vector information.
        /// </summary>
        /// <returns>The vectors string information.</returns>
        public override string ToString()
        {
            return string.Format("[Vector2<{0}>: x={1}, y={2}]",
                Kernel.KernelName, x, y);
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
    }
}
