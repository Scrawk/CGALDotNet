using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Geometry
{

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
                Kernel.Name, Min, Max);
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
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The geometry kernel.</param>
        internal IsoRectangle2(Point2d min, Point2d max, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.IsoRectangle_Create(min, max);
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

        public Point2d Min
        {
            get { return Kernel.IsoRectangle_GetMin(Ptr);  }
        }

        public Point2d Max
        {
            get { return Kernel.IsoRectangle_GetMax(Ptr); }
        }

        public double Area
        {
            get { return Kernel.IsoRectangle_Area(Ptr); }
        }

        public BOUNDED_SIDE BoundedSide(Point2d point)
        {
            return Kernel.IsoRectangle_BoundedSide(Ptr, point);
        }

        public bool ContainsPoint(Point2d point, bool includeBoundary)
        {
            return Kernel.IsoRectangle_ContainsPoint(Ptr, point, includeBoundary);
        }

        /// <summary>
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.IsoRectangle_Release(Ptr);
        }
    }
 }
