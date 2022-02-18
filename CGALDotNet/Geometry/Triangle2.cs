using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Triangle2<K> : Triangle2 where K : CGALKernel, new()
    {

        public Triangle2(Point2d a, Point2d b, Point2d c) : base(a, b, c, new K())
        {

        }

        internal Triangle2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Triangle2<{0}>: A={1}, B={2}, C={2}]",
                Kernel.KernelName, A, B, C);
        }

        public Triangle2<K> Transform(Point2d translation, Degree rotation, double scale)
        {
            var ptr = Kernel.Triangle2_Transform(Ptr, translation, rotation.radian, scale);
            return new Triangle2<K>(ptr);
        }
    }

    public abstract class Triangle2 : CGALObject
    {

        private Triangle2()
        {
       
        }

        internal Triangle2(Point2d a, Point2d b, Point2d c, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Triangle2_Create(a, b, c);
        }

        internal Triangle2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        public Point2d A
        {
            get { return Kernel.Segment2_GetVertex(Ptr, 0); }
            set { Kernel.Segment2_SetVertex(Ptr, 0, value); }
        }

        public Point2d B
        {
            get { return Kernel.Segment2_GetVertex(Ptr, 1); }
            set { Kernel.Segment2_SetVertex(Ptr, 1, value); }
        }

        public Point2d C
        {
            get { return Kernel.Segment2_GetVertex(Ptr, 2); }
            set { Kernel.Segment2_SetVertex(Ptr, 2, value); }
        }

        public bool IsDegenerate => Kernel.Triangle2_IsDegenerate(Ptr);

        public double Area
        {
            get
            {
                if (IsDegenerate)
                    return 0;
                else
                    return Kernel.Triangle2_Area(Ptr);
            }
        }

        public ORIENTATION Orientation
        {
            get
            {
                if (IsDegenerate)
                    return ORIENTATION.ZERO;
                else
                    return Kernel.Triangle2_Orientation(Ptr);
            }
        }
        
        public BOUNDED_SIDE BoundedSide(Point2d point)
        {
            if (IsDegenerate)
                return BOUNDED_SIDE.UNDETERMINED;
            else
                return Kernel.Triangle2_BoundedSide(Ptr, point);
        }

        public ORIENTED_SIDE OrientedSide(Point2d point)
        {
            if (IsDegenerate)
                return ORIENTED_SIDE.UNDETERMINED;
            else
                return Kernel.Triangle2_OrientedSide(Ptr, point);
        }

        protected override void ReleasePtr()
        {
            Kernel.Triangle2_Release(Ptr);
        }
    }
}
