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
    public sealed class Ray2<K> : Ray2 where K : CGALKernel, new()
    {
        /// <summary>
        /// The unit x ray.
        /// </summary>
        public readonly static Ray2<K> UnitX = new Ray2<K>(Point2d.Zero, Vector2d.UnitX);

        /// <summary>
        /// The unit y ray.
        /// </summary>
	    public readonly static Ray2<K> UnitY = new Ray2<K>(Point2d.Zero, Vector2d.UnitY);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public Ray2(Point2d position, Vector2d direction) 
            : base(position, direction, new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal Ray2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[Ray2<{0}>: Position={1}, Direction={2}]",
                Kernel.Name, Position, Direction);
        }

        /// <summary>
        /// 
        /// </summary>
        public Ray2<K> Opposite => new Ray2<K>(Kernel.Ray2_Opposite(Ptr));

        /// <summary>
        /// 
        /// </summary>
        public Line2<K> Line => new Line2<K>(Kernel.Ray2_Line(Ptr));

        /// <summary>
        /// Translate the shape.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Ray2_Transform(Ptr, translation, 0, 1);
        }

        /// <summary>
        /// Rotate the shape.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Degree rotation)
        {
            Kernel.Ray2_Transform(Ptr, Point2d.Zero, rotation.radian, 1);
        }

        /// <summary>
        /// Scale the shape.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Ray2_Transform(Ptr, Point2d.Zero, 0, scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="translation"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        public void Transform(Point2d translation, Degree rotation, double scale)
        {
            Kernel.Ray2_Transform(Ptr, translation, rotation.radian, scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Ray2<K> Copy()
        {
            return new Ray2<K>(Kernel.Ray2_Copy(Ptr));
        }


    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Ray2 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private Ray2()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        /// <param name="kernel"></param>
        internal Ray2(Point2d position, Vector2d direction, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Ray2_Create(position, direction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal Ray2(CGALKernel kernel, IntPtr ptr) : base(ptr)
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
        public Ray2d Shape => new Ray2d(Position, Direction);

        /// <summary>
        /// 
        /// </summary>
        public bool IsDegenerate => Kernel.Ray2_IsDegenerate(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public bool IsHorizontal => Kernel.Ray2_IsHorizontal(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public bool IsVertical => Kernel.Ray2_IsVertical(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public Point2d Position => Kernel.Ray2_Source(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public Vector2d Direction => Kernel.Ray2_Vector(Ptr);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool HasOn(Point2d point)
        {
            return Kernel.Ray2_HasOn(Ptr, point);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Ray2_Release(Ptr);
        }

        /// <summary>
        /// Round the shape.
        /// </summary>
        /// <param name="digits">The number of digits to round to.</param>
        public void Round(int digits)
        {
            Position.Round(digits);
            Direction.Round(digits);
        }

        /// <summary>
        /// Convert to another kernel.
        /// Must provide a different kernel to convert to or
        /// just a deep copy will be returned.
        /// </summary>
        /// <returns>The shape with another kernel type.</returns>
        public Ray2<T> Convert<T>() where T : CGALKernel, new()
        {
            var k = typeof(T).Name;
            var e = CGALEnum.ToKernelEnum(k);
            var ptr = Kernel.Ray2_Convert(Ptr, e);
            return new Ray2<T>(ptr);
        }
    }
}
