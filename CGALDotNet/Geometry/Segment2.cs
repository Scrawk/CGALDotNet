using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Segment2<K> : Segment2 where K : CGALKernel, new()
    {

        /// <summary>
        /// A horizontal line on the x axis.
        /// </summary>
        public readonly static Segment2<K> Horizontal 
            = new Segment2<K>(new Point2d(-1, 0), new Point2d(1, 0));

        /// <summary>
        /// A vertical line on the y axis.
        /// </summary>
	    public readonly static Segment2<K> Vertical 
            = new Segment2<K>(new Point2d(0, -1), new Point2d(0, 1));


        public Segment2(Point2d a, Point2d b) : base(a, b, new K())
        {

        }

        internal Segment2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Segment2<{0}>: A={1}, B={2}]",
                Kernel.KernelName, A, B);
        }

        public Line2<K> Line => new Line2<K>(Kernel.Segment2_Line(Ptr));

        public void Transform(Point2d translation, Degree rotation, double scale)
        {
            Kernel.Segment2_Transform(Ptr, translation, rotation.radian, scale);
        }

        public Segment2<K> Copy()
        {
            return new Segment2<K>(Kernel.Segment2_Copy(Ptr));
        }
    }

    public abstract class Segment2 : CGALObject
    {

        private Segment2()
        {

        }

        internal Segment2(Point2d a, Point2d b, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Segment2_Create(a, b);
        }

        internal Segment2(CGALKernel kernel, IntPtr ptr) : base(ptr)
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

        public Point2d Min => Kernel.Segment2_Min(Ptr);

        public Point2d Max => Kernel.Segment2_Max(Ptr);

        public bool IsDegenerate => Kernel.Segment2_IsDegenerate(Ptr);

        public bool IsHorizontal => Kernel.Segment2_IsHorizontal(Ptr);  

        public bool IsVertical => Kernel.Segment2_IsVertical(Ptr);

        public Vector2d Vector => Kernel.Segment2_Vector(Ptr);

        public double SqrLength => Kernel.Segment2_SqrLength(Ptr);  

        public bool HasOn(Point2d point)
        {
            return Kernel.Line2_HasOn(Ptr, point);
        }

        protected override void ReleasePtr()
        {
            Kernel.Segment2_Release(Ptr);
        }
    }
}
