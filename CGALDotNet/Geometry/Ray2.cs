using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Ray2<K> : Ray2 where K : CGALKernel, new()
    {

        public Ray2(Point2d position, Vector2d direction) 
            : base(position, direction, new K())
        {

        }

        internal Ray2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[Ray2<{0}>: Position={1}, Direction={2}]",
                Kernel.KernelName, Position, Direction);
        }

        public Ray2<K> Opposite => new Ray2<K>(Kernel.Ray2_Opposite(Ptr));

        public Line2<K> Line => new Line2<K>(Kernel.Ray2_Line(Ptr));

        public Ray2<K> Transform(Point2d translation, Degree rotation, double scale)
        {
            var ptr = Kernel.Ray2_Transform(Ptr, translation, rotation.radian, scale);
            return new Ray2<K>(ptr);
        }

    }

    public abstract class Ray2 : CGALObject
    {

        private Ray2()
        {

        }

        internal Ray2(Point2d position, Vector2d direction, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Ray2_Create(position, direction);
        }

        internal Ray2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        public bool IsDegenerate => Kernel.Ray2_IsDegenerate(Ptr);

        public bool IsHorizontal => Kernel.Ray2_IsHorizontal(Ptr);

        public bool IsVertical => Kernel.Ray2_IsVertical(Ptr);

        public Point2d Position => Kernel.Ray2_Source(Ptr);

        public Vector2d Direction => Kernel.Ray2_Vector(Ptr);

        public bool HasOn(Point2d point)
        {
            return Kernel.Ray2_HasOn(Ptr, point);
        }

        protected override void ReleasePtr()
        {
            Kernel.Ray2_Release(Ptr);
        }
    }
}
