using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// The generic IsoRectangle wrapper for a CGAL object.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class IsoRectangle2<K> : IsoRectangle2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public IsoRectangle2(Point2d min, Point2d max) : base(min, max, new K())
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The iso rectangle pointer.</param>
        internal IsoRectangle2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The iso rectangle as a string.
        /// </summary>
        /// <returns>The iso rectangle as a string.</returns>
        public override string ToString()
        {
            return string.Format("[IsoRectangle2<{0}>: Min={1}, Max={2}]", 
                Kernel.KernelName, Min, Max);
        }

        /// <summary>
        /// Transform the rectangle.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate</param>
        /// <param name="scale">The amount to scale.</param>
        /// <returns>The transformed rectangle.</returns>
        public IsoRectangle2<K> Transform(Point2d translation, Degree rotation, double scale)
        {
            var ptr = Kernel.Line2_Transform(Ptr, translation, rotation.radian, scale);
            return new IsoRectangle2<K>(ptr);
        }
    }

    /// <summary>
    /// The abstract iso rectangle definition.
    /// </summary>
    public abstract class IsoRectangle2 : CGALObject
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        private IsoRectangle2()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="kernel"></param>
        internal IsoRectangle2(Point2d min, Point2d max, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.IsoRectangle2_Create(min, max);
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The geometry kernel.</param>
        /// <param name="ptr">The IsoRectangle pointer.</param>
        internal IsoRectangle2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        /// <summary>
        /// The iso rectangle kernel.
        /// Contains the functions to the unmanaged CGAL object.
        /// </summary>
        protected private GeometryKernel2 Kernel { get; private set; }

        /// <summary>
        /// The rectangles min point.
        /// </summary>
        public Point2d Min
        {
            get { return Kernel.IsoRectangle2_GetMin(Ptr);  }
            set {  Kernel.IsoRectangle2_SetMin(Ptr, value); }
        }

        /// <summary>
        /// The rectangles max point.
        /// </summary>
        public Point2d Max
        {
            get { return Kernel.IsoRectangle2_GetMax(Ptr); }
            set { Kernel.IsoRectangle2_SetMax(Ptr, value); }
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
                    return Kernel.IsoRectangle2_Area(Ptr); 
            }
        }

        /// <summary>
        /// Is the rectangle degenerate.
        /// </summary>
        public bool IsDegenerate => Kernel.IsoRectangle2_IsDegenerate(Ptr);

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
                return Kernel.IsoRectangle2_BoundedSide(Ptr, point);
        }

        /// <summary>
        /// Does the rectangle contain the point.
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="includeBoundary">Should a point on 
        /// the boundary count as being inside.</param>
        /// <returns>Does the rectangle contain the point</returns>
        public bool ContainsPoint(Point2d point, bool includeBoundary)
        {
            if (IsDegenerate)
                return false;
            else
                return Kernel.IsoRectangle2_ContainsPoint(Ptr, point, includeBoundary);
        }

        /// <summary>
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.IsoRectangle2_Release(Ptr);
        }
    }
 }
