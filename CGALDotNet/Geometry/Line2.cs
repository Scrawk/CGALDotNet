using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Geometry
{

    public sealed class Line2<K> : Line2 where K : CGALKernel, new()
    {

        public Line2(double a, double b, double c) : base(a, b, c, new K())
        {

        }

        internal Line2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public Line2<K> Opposite => new Line2<K>(Kernel.Line2_Opposite(Ptr));

        public override string ToString()
        {
            return string.Format("[Line2<{0}>: A={1}, B={2}, C={3}]",
                Kernel.KernelName, A, B, C);
        }

        public Line2<K> Perpendicular(Point2d point)
        {
            var ptr = Kernel.Line2_Perpendicular(Ptr, point);
            return new Line2<K>(ptr);
        }

        public Line2<K> Transform(Point2d translation, Degree rotation, double scale)
        {
            var ptr = Kernel.Line2_Transform(Ptr, translation, rotation.radian, scale);    
            return new Line2<K>(ptr);
        }
    }

    public abstract class Line2 : CGALObject
    {
        private Line2()
        {

        }

        internal Line2(double a, double b, double c, CGALKernel kernel)
        {
            Kernel = kernel.GeometryKernel2;
            Ptr = Kernel.Line2_Create(a, b, c);
        }

        internal Line2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.GeometryKernel2;
        }

        protected private GeometryKernel2 Kernel { get; private set; }

        public double A => Kernel.Line2_GetA(Ptr);

        public double B => Kernel.Line2_GetB(Ptr);

        public double C => Kernel.Line2_GetC(Ptr);

        public bool IsDegenerate => Kernel.Line2_IsDegenerate(Ptr);

        public bool IsHorizontal => Kernel.Line2_IsHorizontal(Ptr);

        public bool IsVertical => Kernel.Line2_IsVertical(Ptr); 

        public Vector2d Vector => Kernel.Line2_Vector(Ptr);

        public bool HasOn(Point2d point)
        {
            return Kernel.Line2_HasOn(Ptr, point);
        }

        public bool HasOnNegativeSide(Point2d point)
        {
            return Kernel.Line2_HasOnNegativeSide(Ptr, point);  
        }

        public bool HasOnPositiveSide(Point2d point)
        {
            return Kernel.Line2_HasOnPositiveSide(Ptr, point);  
        }

        public double X_On_Y(double y)
        {
            return Kernel.Line2_X_On_Y(Ptr, y);
        }

        public double Y_On_X(double x)
        {
            return Kernel.Line2_Y_On_X(Ptr, x);
        }

        protected override void ReleasePtr()
        {
            Kernel.Line2_Release(Ptr);
        }
    }
}
