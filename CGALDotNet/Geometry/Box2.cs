using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// The generic Box wrapper for a CGAL object.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class Box2<K> : Box2 where K : CGALKernel, new()
    {

        /// <summary>
        /// Create box from min and max values.
        /// </summary>
        /// <param name="min">The min x and y value.</param>
        /// <param name="max">The max x and y value.</param>
        public Box2(double min, double max) : 
            base(new Point2d(min), new Point2d(max), new K())
        {

        }

        /// <summary>
        /// Create box from min and max points.
        /// </summary>
        /// <param name="min">The min point.</param>
        /// <param name="max">The max point.</param>
        public Box2(Point2d min, Point2d max) : 
            base(min, max, new K())
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The iso rectangle pointer.</param>
        internal Box2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The type of kernel object uses.
        /// </summary>
        public string KernelName => Kernel.Name;

        /// <summary>
        /// The iso rectangle as a string.
        /// </summary>
        /// <returns>The iso rectangle as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Box2<{0}>: Min={1}, Max={2}]", 
                KernelName, Min, Max);
        }

        /// <summary>
        /// Translate the shape.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Box2_Transform(Ptr, translation, 0, 1);
        }

        /// <summary>
        /// Rotate the shape.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Degree rotation)
        {
            Kernel.Box2_Transform(Ptr, Point2d.Zero, rotation.radian, 1);
        }

        /// <summary>
        /// Scale the shape.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Box2_Transform(Ptr, Point2d.Zero, 0, scale);
        }

        /// <summary>
        /// Transform the rectangle.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point2d translation, Degree rotation, double scale)
        {
            Kernel.Box2_Transform(Ptr, translation, rotation.radian, scale);
        }

        /// <summary>
        /// Create a deep copy of the rectangle.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public Box2<K> Copy()
        {
            var ptr = Kernel.Box2_Copy(Ptr);
            return new Box2<K>(ptr);
        }

    }

    /// <summary>
    /// The abstract iso rectangle definition.
    /// </summary>
    public abstract class Box2 : CGALObject
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Box2()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="kernel"></param>
        internal Box2(Point2d min, Point2d max, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Box2_Create(min, max);
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The geometry kernel.</param>
        /// <param name="ptr">The Box pointer.</param>
        internal Box2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        /// <summary>
        /// The iso rectangle kernel.
        /// Contains the functions to the unmanaged CGAL object.
        /// </summary>
        protected private GeometryKernel2 Kernel { get; private set; }

        /// <summary>
        /// Convert to shape struct.
        /// </summary>
        public Box2d Shape => new Box2d(Min, Max);

        /// <summary>
        /// The rectangles min point.
        /// </summary>
        public Point2d Min
        {
            get { return Kernel.Box2_GetMin(Ptr);  }
            set {  Kernel.Box2_SetMin(Ptr, value); }
        }

        /// <summary>
        /// The rectangles max point.
        /// </summary>
        public Point2d Max
        {
            get { return Kernel.Box2_GetMax(Ptr); }
            set { Kernel.Box2_SetMax(Ptr, value); }
        }

        /// <summary>
        /// The rectangles area.
        /// </summary>
        public double Area
        {
            get 
            {
                if (IsDegenerate)
                    return 0;
                else
                    return Kernel.Box2_Area(Ptr); 
            }
        }

        /// <summary>
        /// Is the rectangle degenerate.
        /// </summary>
        public bool IsDegenerate => Kernel.Box2_IsDegenerate(Ptr);

        /// <summary>
        /// The side the rectangle the point is on.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>If the point is iside, outside or on boundary.</returns>
        public BOUNDED_SIDE BoundedSide(Point2d point)
        {
            if (IsDegenerate)
                return BOUNDED_SIDE.UNDETERMINED;
            else
                return Kernel.Box2_BoundedSide(Ptr, point);
        }

        /// <summary>
        /// Does the rectangle contain the point.
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="includeBoundary">Should a point on 
        /// the boundary count as being inside.</param>
        /// <returns>Does the rectangle contain the point</returns>
        public bool ContainsPoint(Point2d point, bool includeBoundary = true)
        {
            if (IsDegenerate)
                return false;
            else
                return Kernel.Box2_ContainsPoint(Ptr, point, includeBoundary);
        }

        /// <summary>
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Box2_Release(Ptr);
        }

        /// <summary>
        /// Round the shape.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            this.Min = Min.Rounded(digits);
            this.Max = Max.Rounded(digits);
        }

        /// <summary>
        /// Convert to another kernel.
        /// Must provide a different kernel to convert to or
        /// just a deep copy will be returned.
        /// </summary>
        /// <returns>The shape with another kernel type.</returns>
        public Box2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.Box2_Convert(Ptr, e);
            return new Box2<T>(ptr);
        }

    }
 }
