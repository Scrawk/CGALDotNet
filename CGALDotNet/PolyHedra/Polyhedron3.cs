using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;

namespace CGALDotNet.PolyHedra
{
    [Flags]
    public enum POLYHEDRON_CHECK
    {
        NONE = 0,
        ARRAY_BOUNDS = 1,
        ALL = ~0
    }

    /// <summary>
    /// Generic polygon definition.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class Polyhedra3<K> : Polyhedra3 where K : CGALKernel, new()
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Polyhedra3() : base(new K())
        {

        }

        /// <summary>
        /// Create from a set of points.
        /// </summary>
        /// <param name="points">The polygons points.</param>
        public Polyhedra3(Point3d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polygons pointer.</param>
        internal Polyhedra3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polygon as a string.
        /// </summary>
        /// <returns>The polygon as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Polyhedra3<{0}>:]",
                Kernel.Name);
        }

    }

    /// <summary>
    /// The abstract polyhedra definition.
    /// </summary>
    public abstract class Polyhedra3 : CGALObject //, IEnumerable<Point3d>
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Polyhedra3()
        {

        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polygon kernel.</param>
        internal Polyhedra3(CGALKernel kernel)
        {
            Kernel = kernel.PolyhedronKernel3;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polygon kernel.</param>
        /// <param name="points">The points to construct from.</param>
        internal Polyhedra3(CGALKernel kernel, Point3d[] points)
        {
            Kernel = kernel.PolyhedronKernel3;
            Ptr = Kernel.Create();
            //SetPoints(points);
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polygon kernel.</param>
        /// <param name="ptr">The polygons pointer.</param>
        internal Polyhedra3(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolyhedronKernel3;
        }

        /// <summary>
        /// The polyhedron kernel.
        /// Contains the functions to the unmanaged CGAL polygon.
        /// </summary>
        protected private PolyhedronKernel3 Kernel { get; private set; }

        /// <summary>
        /// What checks should the polygon do.
        /// </summary>
        public POLYHEDRON_CHECK CheckFlag = POLYHEDRON_CHECK.ALL;

        /// <summary>
        /// Clear the polygon of all points.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        /*

        /// <summary>
        /// Translate the polygon.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Translate(Ptr, translation);
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        public void Rotate(Radian rotation)
        {
            Kernel.Rotate(Ptr, rotation.angle);
        }

        /// <summary>
        /// Scale the polygon.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Scale(Ptr, scale);
            IsUpdated = false;
        }

        /// <summary>
        /// Transform the polygon with a TRS matrix.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point2d translation, Radian rotation, double scale)
        {
            Kernel.Transform(Ptr, translation, rotation.angle, scale);
            IsUpdated = false;
        }

        /// <summary>
        /// Enumerate all points in the polygon.
        /// </summary>
        /// <returns>Each point in polygon.</returns>
        public IEnumerator<Point2d> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return GetPoint(i);
        }

        /// <summary>
        /// Enumerate all points in the polygon.
        /// </summary>
        /// <returns>Each point in polygon.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Return all the points in the polygon in a array.
        /// </summary>
        /// <returns>The array.</returns>
        public Point2d[] ToArray()
        {
            var points = new Point2d[Count];
            GetPoints(points);
            return points;
        }

        /// <summary>
        /// Return all the points in the polygon in a list.
        /// </summary>
        /// <returns>The list.</returns>
        public List<Point2d> ToList()
        {
            var points = new List<Point2d>(Count);
            for (int i = 0; i < Count; i++)
                points.Add(GetPoint(i));

            return points;
        }
        */

        /// <summary>
        /// Print the polygon.
        /// </summary>
        public void Print()
        {
            var builder = new StringBuilder();
            //Print(builder);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// Release the unmanaged pointer.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

    }
}
