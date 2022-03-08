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
    public sealed class Triangle2<K> : Triangle2 where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public Triangle2(Point2d a, Point2d b, Point2d c) : base(a, b, c, new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal Triangle2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Triangle2<{0}>: A={1}, B={2}, C={2}]",
                Kernel.Name, A, B, C);
        }

        /// <summary>
        /// Translate the shape.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Triangle2_Transform(Ptr, translation, 0, 1);
        }

        /// <summary>
        /// Rotate the shape.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Degree rotation)
        {
            Kernel.Triangle2_Transform(Ptr, Point2d.Zero, rotation.radian, 1);
        }

        /// <summary>
        /// Scale the shape.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Triangle2_Transform(Ptr, Point2d.Zero, 0, scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public void Transform(Point2d translation, Degree rotation, double scale)
        {
            Kernel.Triangle2_Transform(Ptr, translation, rotation.radian, scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Triangle2<K> Copy()
        {
            return new Triangle2<K>(Kernel.Triangle2_Copy(Ptr));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Triangle2 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private Triangle2()
        {
       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="kernel"></param>
        internal Triangle2(Point2d a, Point2d b, Point2d c, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Triangle2_Create(a, b, c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal Triangle2(CGALKernel kernel, IntPtr ptr) : base(ptr)
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
        public Triangle2d Shape => new Triangle2d(A, B, C);

        /// <summary>
        /// 
        /// </summary>
        public Point2d A
        {
            get { return Kernel.Triangle2_GetVertex(Ptr, 0); }
            set { Kernel.Triangle2_SetVertex(Ptr, 0, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point2d B
        {
            get { return Kernel.Triangle2_GetVertex(Ptr, 1); }
            set { Kernel.Triangle2_SetVertex(Ptr, 1, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Point2d C
        {
            get { return Kernel.Triangle2_GetVertex(Ptr, 2); }
            set { Kernel.Triangle2_SetVertex(Ptr, 2, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDegenerate => Kernel.Triangle2_IsDegenerate(Ptr);

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public BOUNDED_SIDE BoundedSide(Point2d point)
        {
            if (IsDegenerate)
                return BOUNDED_SIDE.UNDETERMINED;
            else
                return Kernel.Triangle2_BoundedSide(Ptr, point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public ORIENTED_SIDE OrientedSide(Point2d point)
        {
            if (IsDegenerate)
                return ORIENTED_SIDE.UNDETERMINED;
            else
                return Kernel.Triangle2_OrientedSide(Ptr, point);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Triangle2_Release(Ptr);
        }

        /// <summary>
        /// Round the shape.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            A.Round(digits);
            B.Round(digits);
            C.Round(digits);
        }

        /// <summary>
        /// Convert to another kernel.
        /// Must provide a different kernel to convert to or
        /// just a deep copy will be returned.
        /// </summary>
        /// <returns>The shape with another kernel type.</returns>
        public Triangle2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.Triangle2_Convert(Ptr, e);
            return new Triangle2<T>(ptr);
        }
    }
}
