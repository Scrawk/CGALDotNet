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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public Segment2(Point2d a, Point2d b) : base(a, b, new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal Segment2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Segment2<{0}>: A={1}, B={2}]",
                Kernel.Name, A, B);
        }

        /// <summary>
        /// 
        /// </summary>
        public Line2<K> Line => new Line2<K>(Kernel.Segment2_Line(Ptr));

        /// <summary>
        /// Translate the shape.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Segment2_Transform(Ptr, translation, 0, 1);
        }

        /// <summary>
        /// Rotate the shape.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Degree rotation)
        {
            Kernel.Segment2_Transform(Ptr, Point2d.Zero, rotation.radian, 1);
        }

        /// <summary>
        /// Scale the shape.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Segment2_Transform(Ptr, Point2d.Zero, 0, scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public void Transform(Point2d translation, Degree rotation, double scale)
        {
            Kernel.Segment2_Transform(Ptr, translation, rotation.radian, scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Segment2<K> Copy()
        {
            return new Segment2<K>(Kernel.Segment2_Copy(Ptr));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Segment2 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private Segment2()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="kernel"></param>
        internal Segment2(Point2d a, Point2d b, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Segment2_Create(a, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal Segment2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        /// <summary>
        /// 
        /// </summary>
        protected private GeometryKernel2 Kernel { get; private set; }

        /// <summary>
        /// Convert to shape struct.
        /// </summary>
        public Segment2d Shape => new Segment2d(A, B);

        /// <summary>
        /// 
        /// </summary>
        public Point2d A
        {
            get { return Kernel.Segment2_GetVertex(Ptr, 0); }
            set { Kernel.Segment2_SetVertex(Ptr, 0, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point2d B
        {
            get { return Kernel.Segment2_GetVertex(Ptr, 1); }
            set { Kernel.Segment2_SetVertex(Ptr, 1, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point2d Min => Kernel.Segment2_Min(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public Point2d Max => Kernel.Segment2_Max(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public bool IsDegenerate => Kernel.Segment2_IsDegenerate(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public bool IsHorizontal => Kernel.Segment2_IsHorizontal(Ptr);  

        /// <summary>
        /// 
        /// </summary>
        public bool IsVertical => Kernel.Segment2_IsVertical(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public Vector2d Vector => Kernel.Segment2_Vector(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public double SqrLength => Kernel.Segment2_SqrLength(Ptr);  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool HasOn(Point2d point)
        {
            return Kernel.Line2_HasOn(Ptr, point);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Segment2_Release(Ptr);
        }

        /// <summary>
        /// Round the shape.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            A.Round(digits);
            B.Round(digits);
        }

        /// <summary>
        /// Convert to another kernel.
        /// Must provide a different kernel to convert to or
        /// just a deep copy will be returned.
        /// </summary>
        /// <returns>The shape with another kernel type.</returns>
        public Segment2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.Segment2_Convert(Ptr, e);
            return new Segment2<T>(ptr);
        }
    }
}
