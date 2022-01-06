using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polygons;
using CGALDotNet.Geometry;

namespace CGALDotNet.Meshing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class ConformingTriangulation2<K> : ConformingTriangulation2 where K : CGALKernel, new()
    {
        /// <summary>
        /// A static instance of the triangulation.
        /// </summary>
        public static readonly ConformingTriangulation2<K> Instance = new ConformingTriangulation2<K>();

        /// <summary>
        /// 
        /// </summary>
        public ConformingTriangulation2() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        public ConformingTriangulation2(Point2d[] points) : base(new K(), points)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal ConformingTriangulation2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The triangulation as a string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[ConformingTriangulation2<{0}>: VertexCount={1}, FaceCount={2}]",
                Kernel.KernelName, VertexCount, TriangleCount);
        }

        /// <summary>
        /// A deep copy of the triangulation.
        /// </summary>
        /// <returns>The deep copy.</returns>
        public ConformingTriangulation2<K> Copy()
        {
            return new ConformingTriangulation2<K>(Kernel.Copy(Ptr));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class ConformingTriangulation2 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private ConformingTriangulation2()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal ConformingTriangulation2(CGALKernel kernel)
        {
            Kernel = kernel.ConformingTriangulationKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="points"></param>
        internal ConformingTriangulation2(CGALKernel kernel, Point2d[] points)
        {
            Kernel = kernel.ConformingTriangulationKernel2;
            Ptr = Kernel.Create();
            Insert(points, points.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal ConformingTriangulation2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.ConformingTriangulationKernel2;
            Ptr = ptr;
        }

        /// <summary>
        /// The number of verices in the triangulation.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// The number of triangles in the triangulation.
        /// </summary>
        public int TriangleCount => Kernel.FaceCount(Ptr);

        /// <summary>
        /// The number of indices need to represent the
        /// triangulation (number of triangles * 3).
        /// </summary>
        public int IndiceCount => TriangleCount * 3;

        /// <summary>
        /// The conforming triangulation kernel.
        /// </summary>
        internal ConformingTriangulationKernel2 Kernel { get; private set; }

        /// <summary>
        /// Clear the triangulation.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        public void Insert(Point2d point)
        {
            Kernel.InsertPoint(Ptr, point);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="count"></param>
        public void Insert(Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.InsertPoints(Ptr, points, count);
        }

        /// <summary>
        /// Insert the polygons points into the triangulation.
        /// May not retain the poylgons edges.
        /// </summary>
        /// <param name="polygon"></param>
        public void Insert(Polygon2 polygon)
        {
            Kernel.InsertPolygon(Ptr, polygon.Ptr);
        }

        /// <summary>
        /// Insert the polygons points into the triangulation.
        /// May not retain the poylgons edges.
        /// </summary>
        /// <param name="pwh"></param>
        public void Insert(PolygonWithHoles2 pwh)
        {
            Kernel.InsertPolygonWithHoles(Ptr, pwh.Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="count"></param>
        public void GetPoints( Point2d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="count"></param>
        public void GetIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetIndices(Ptr, indices, count);
        }

        /// <summary>
        /// Translate the triangulation.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Transform(Ptr, translation, 0, 1);
        }

        /// <summary>
        /// Rotate the triangulation.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        public void Rotate(Radian rotation)
        {
            Kernel.Transform(Ptr, Point2d.Zero, rotation.angle, 1);
        }

        /// <summary>
        /// Scale the triangulation.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Transform(Ptr, Point2d.Zero, 0, scale);
        }

        /// <summary>
        /// Transform the triangulation with a TRS matrix.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point2d translation, Radian rotation, double scale)
        {
            Kernel.Transform(Ptr, translation, rotation.angle, scale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void InsertConstraint(Point2d a, Point2d b)
        {
            Kernel.InsertSegmentConstraint(Ptr, a, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segment"></param>
        public void InsertConstraint(Segment2d segment)
        {
            Kernel.InsertSegmentConstraint(Ptr, segment.A, segment.B);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segments"></param>
        /// <param name="count"></param>
        public void InsertConstraints(Segment2d[] segments, int count)
        {
            ErrorUtil.CheckArray(segments, count);
            Kernel.InsertSegmentConstraints(Ptr, segments, count);
        }

        /// <summary>
        /// Insert the polygons points and the edges as constraints into the triangulation.
        /// Will retatin the poylgons edges.
        /// </summary>
        /// <param name="polygon">The polygon to insert.</param>
        public void InsertConstraint(Polygon2 polygon)
        {
            Kernel.InsertPolygonConstraint(Ptr, polygon.Ptr);
        }

        /// <summary>
        /// Insert the polygons points and the edges as constraints into the triangulation.
        /// Will retatin the poylgons edges.
        /// </summary>
        /// <param name="pwh">The polygon to insert.</param>
        public void InsertConstraint(PolygonWithHoles2 pwh)
        {
            Kernel.InsertPolygonWithHolesConstraint(Ptr, pwh.Ptr);
        }

        /// <summary>
        /// Make the mesh delaunay.
        /// </summary>
        public void MakeDelaunay()
        {
            Kernel.MakeDelaunay(Ptr);
        }

        /// <summary>
        /// Make the mesh 
        /// </summary>
        public void MakeGabriel()
        {
            Kernel.MakeGabriel(Ptr);
        }

        /// <summary>
        /// Refine the mesh into smaller triangles.
        /// </summary>
        /// <param name="angleBounds">Default shape bound. 0.125 corresponds to abound 20.6 degree. Max 0.125 value.</param>
        /// <param name="lengthBounds">Upper bound on the length of the longest edge.</param>
        public void Refine(double angleBounds, double lengthBounds)
        {
            if (angleBounds > 0.125)
                angleBounds = 0.125;

            Kernel.RefineAndOptimize(Ptr, 0, angleBounds, lengthBounds);
        }

        /// <summary>
        /// Refine the mesh into smaller triangles.
        /// </summary>
        /// <param name="angleBounds">Default shape bound. 0.125 corresponds to abound 20.6 degree. Max 0.125 value.</param>
        /// <param name="lengthBounds">Upper bound on the length of the longest edge.</param>
        /// <param name="seeds">Seeds point in polygons that are not to be refined.</param>
        public void Refine(double angleBounds, double lengthBounds, Point2d[] seeds)
        {
            if (angleBounds > 0.125)
                angleBounds = 0.125;

            Kernel.RefineAndOptimizeWithSeeds(Ptr, 0, angleBounds, lengthBounds, seeds, seeds.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
        }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
