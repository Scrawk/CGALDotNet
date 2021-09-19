using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Triangulations;

namespace CGALDotNet.Polygons
{
    /// <summary>
    /// Poylgon with holes consists of a boundary and holes.
    /// </summary>
    public enum POLYGON_ELEMENT 
    { 
        BOUNDARY, 
        HOLE
    }

    /// <summary>
    /// Generic polygon definition.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class PolygonWithHoles2<K> : PolygonWithHoles2 where K : CGALKernel, new()
    {
        /// <summary>
        /// Default constuctor.
        /// </summary>
        public PolygonWithHoles2() : base(new K())
        {

        }

        /// <summary>
        /// Construct polygon with the boundary.
        /// </summary>
        /// <param name="boundary">A CCW polygon.</param>
        public PolygonWithHoles2(Polygon2<K> boundary) : base(new K(), boundary)
        {

        }

        /// <summary>
        /// Construct polygon with the boundary points
        /// </summary>
        /// <param name="boundary">A CCW set of points.</param>
        public PolygonWithHoles2(Point2d[] boundary) : base(new K(), boundary)
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polygons pointer.</param>
        internal PolygonWithHoles2(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polygon as a string.
        /// </summary>
        /// <returns>The polygon as a string.</returns>
        public override string ToString()
        {
            return string.Format("[PolygonWithHoles2<{0}>: IsUnbounded={1}, HoleCount={2}]", 
                Kernel.Name, IsUnbounded, HoleCount);
        }

        /// <summary>
        /// Create a deep copy of the polygon.
        /// </summary>
        /// <returns>The copy.</returns>
        public PolygonWithHoles2<K> Copy()
        {
            return new PolygonWithHoles2<K>(Kernel.Copy(Ptr));
        }

        /// <summary>
        /// Create a deep copy of the polygon element.
        /// </summary>
        /// <param name="element">The element type to copy.</param>
        /// <param name="index">If element os a hole thiss is the holes index.</param>
        /// <returns>The copy.</returns>
        public Polygon2<K> Copy(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                CheckIsBounded();
                var ptr = Kernel.CopyPolygon(Ptr, BOUNDARY_INDEX);

                if (ptr != IntPtr.Zero)
                    return new Polygon2<K>(ptr);
                else
                    throw new InvalidOperationException("Failed to find boundary.");
            }
            else
            {
                ErrorUtil.CheckBounds(index, HoleCount);
                return new Polygon2<K>(Kernel.CopyPolygon(Ptr, index));
            }
        }

        /// <summary>
        /// Add a hole from a set of points.
        /// </summary>
        /// <param name="points">A CW set of points.</param>
        public void AddHole(Point2d[] points)
        {
            AddHole(new Polygon2<K>(points));
        }

        /// <summary>
        /// Create a copy of boundary and hole polygons.
        /// </summary>
        /// <returns>The list of polygons.</returns>
        public List<Polygon2<K>> ToList()
        {
            int count = HoleCount;
            if (!IsUnbounded)
                count++;

            var polygons = new List<Polygon2<K>>(count);

            if (!IsUnbounded)
                polygons.Add(Copy(POLYGON_ELEMENT.BOUNDARY));

            for (int i = 0; i < HoleCount; i++)
                polygons.Add(Copy(POLYGON_ELEMENT.HOLE, i));

            return polygons;
        }

        /// <summary>
        /// Triangulate the polygon.
        /// </summary>
        /// <param name="indices">The triangle indices.</param>
        public void Triangulate(List<int> indices)
        {
            var ct = new ConstrainedTriangulation2<K>();
            ct.InsertPolygonConstraint(this);
            ct.GetConstrainedDomainIndices(indices);
        }

        /// <summary>
        /// Do the polygons intersect.
        /// </summary>
        /// <param name="polygon">The other polygon.</param>
        /// <returns>Do the polygons intersect.</returns>
        public bool Intersects(Polygon2<K> polygon)
        {
            return PolygonBoolean2<K>.Instance.DoIntersect(polygon, this);
        }

        /// <summary>
        /// Do the polygons intersect.
        /// </summary>
        /// <param name="polygon">The other polygon.</param>
        /// <returns>Do the polygons intersect.</returns>
        public bool Intersects(PolygonWithHoles2<K> polygon)
        {
            return PolygonBoolean2<K>.Instance.DoIntersect(polygon, this);
        }

        /// <summary>
        /// Connect all the holes of the polygon 
        /// and return as a polygon.
        /// </summary>
        /// <returns>The connected polygon.</returns>
        public Polygon2<K> ConnectHoles()
        {
            var ptr = Kernel.ConnectHoles(Ptr);
            return new Polygon2<K>(ptr);
        }
    }

    /// <summary>
    /// The abstract polygon definition.
    /// </summary>
    public abstract class PolygonWithHoles2 : CGALObject
    {
        protected const int BOUNDARY_INDEX = -1;

        /// <summary>
        /// Default constructor.
        /// </summary>
        private PolygonWithHoles2()
        {
            CheckFlag = POLYGON_CHECK.ALL;
        }

        /// <summary>
        /// Construct polygon with the kernel.
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonWithHoles2(CGALKernel kernel)
        {
            CheckFlag = POLYGON_CHECK.ALL;
            Kernel = kernel.PolygonWithHolesKernel2;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Construct the polygon with the kernel and boundary.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="boundary">A CCW polygon.</param>
        internal PolygonWithHoles2(CGALKernel kernel, Polygon2 boundary)
        {
            CheckFlag = POLYGON_CHECK.ALL;
            Kernel = kernel.PolygonWithHolesKernel2;
            CheckBoundary(boundary);
            Ptr = Kernel.CreateFromPolygon(boundary.Ptr);
            IsUnbounded = false;
        }

        /// <summary>
        /// Construct the polygon with the kernel and boundary.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="boundary">A CCW set of points.</param>
        internal PolygonWithHoles2(CGALKernel kernel, Point2d[] boundary)
        {
            CheckFlag = POLYGON_CHECK.ALL;
            Kernel = kernel.PolygonWithHolesKernel2;
            Ptr = Kernel.Create();
            SetPoints(POLYGON_ELEMENT.BOUNDARY, boundary, 0);
            IsUnbounded = false;
        }

        /// <summary>
        /// Construct the polygon with the kernel and pointer.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonWithHoles2(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            CheckFlag = POLYGON_CHECK.ALL;
            Kernel = kernel.PolygonWithHolesKernel2;
            HoleCount = Kernel.HoleCount(Ptr);
        }

        /// <summary>
        /// Is the polygon unbounded. 
        /// ie no boundary polygon has been set.
        /// </summary>
        public bool IsUnbounded { get; protected set; }

        /// <summary>
        /// The number of holes in polygon.
        /// </summary>
        public int HoleCount { get; protected set; }

        /// <summary>
        /// The polygon kernel.
        /// </summary>
        protected private PolygonWithHolesKernel2 Kernel { get; private set; }

        /// <summary>
        /// What checks should the polygon do.
        /// </summary>
        public POLYGON_CHECK CheckFlag { get; set; }

        /// <summary>
        /// Clear the polygon.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
            IsUnbounded = true;
            HoleCount = 0;
        }

        /// <summary>
        /// Get the number of points of a polygon element.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns></returns>
        public int PointCount(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.PointCount(Ptr, BOUNDARY_INDEX);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                return Kernel.PointCount(Ptr, index);
            }
        }

        /// <summary>
        /// Remove a polygon.
        /// Can remove the boundary or a hole.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Remove(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                Kernel.ClearBoundary(Ptr);
                IsUnbounded = true;
            }
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                Kernel.RemoveHole(Ptr, index);
                HoleCount--;
            }
        }

        /// <summary>
        /// Reverse the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Reverse(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.ReversePolygon(Ptr, BOUNDARY_INDEX);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                Kernel.ReversePolygon(Ptr, index);
            }
        }

        /// <summary>
        /// Get a polygons point.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="pointIndex">The index of the point in the polygon.</param>
        /// <param name="holeIndex">If element type is a hole this is the holes index.</param>
        /// <returns></returns>
        public Point2d GetPoint(POLYGON_ELEMENT element, int pointIndex, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                int count = Kernel.PointCount(Ptr, BOUNDARY_INDEX);

                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(pointIndex, count);

                return Kernel.GetPoint(Ptr, BOUNDARY_INDEX, pointIndex);
            }
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(holeIndex, HoleCount);

                int count = Kernel.PointCount(Ptr, holeIndex);

                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(pointIndex, count);

                return Kernel.GetPoint(Ptr, holeIndex, pointIndex);
            }
        }

        /// <summary>
        /// Get the points in the polygon element.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="points">The point array to copy points into.</param>
        /// <param name="holeIndex">If element type is a hole this is the holes index.</param>
        public void GetPoints(POLYGON_ELEMENT element, Point2d[] points, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                int count = Kernel.PointCount(Ptr, BOUNDARY_INDEX);

                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(points, 0, count);

                Kernel.GetPoints(Ptr, points, BOUNDARY_INDEX, 0, count);
            }
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(holeIndex, HoleCount);

                int count = Kernel.PointCount(Ptr, holeIndex);

                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(points, 0, count);

                Kernel.GetPoints(Ptr, points, holeIndex, 0, count);
            }
        }

        /// <summary>
        /// Get all the points in the polygon boundary and holes.
        /// </summary>
        /// <param name="points">The point array to copy into.</param>
        public void GetAllPoints(List<Point2d> points)
        {
            int count = PointCount(POLYGON_ELEMENT.BOUNDARY);
            var arr = new Point2d[count];
            GetPoints(POLYGON_ELEMENT.BOUNDARY, arr);
            points.AddRange(arr);

            for(int i = 0; i < HoleCount; i++)
            {
                count = PointCount(POLYGON_ELEMENT.HOLE, i);
                arr = new Point2d[count];
                GetPoints(POLYGON_ELEMENT.HOLE, arr, i);
                points.AddRange(arr);
            }
        }

        /// <summary>
        /// Set a polygons point.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="pointIndex">The index of the point in the polygon.</param>
        /// <param name="point">The point to set.</param>
        /// <param name="holeIndex">If element type is a hole this is the holes index.</param>
        public void SetPoint(POLYGON_ELEMENT element, int pointIndex, Point2d point, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                int count = Kernel.PointCount(Ptr, BOUNDARY_INDEX);

                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(pointIndex, count);

                Kernel.SetPoint(Ptr, BOUNDARY_INDEX, pointIndex, point);
            }
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(holeIndex, HoleCount);

                int count = Kernel.PointCount(Ptr, holeIndex);

                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(pointIndex, count);

                Kernel.SetPoint(Ptr, holeIndex, pointIndex, point);
            }
        }

        /// <summary>
        /// Set all the points in the polygon. If the point array is longer
        /// than the polygon is current the extra points are appended to the end.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="points">The points to set.</param>
        /// <param name="holeIndex">If element type is a hole this is the holes index.</param>
        public void SetPoints(POLYGON_ELEMENT element, Point2d[] points, int holeIndex = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
            {
                int count = Kernel.PointCount(Ptr, BOUNDARY_INDEX);
                count = Math.Max(count, points.Length);

                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(points, 0, count);

                Kernel.SetPoints(Ptr, points, BOUNDARY_INDEX, 0, count);
                IsUnbounded = count > 0;
            }
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(holeIndex, HoleCount);

                int count = Kernel.PointCount(Ptr, holeIndex);
                count = Math.Max(count, points.Length);

                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(points, 0, count);

                Kernel.SetPoints(Ptr, points, holeIndex, 0, count);
            }
        }

        /// <summary>
        /// Add a polygon as a holes.
        /// Holes must simple and CW.
        /// </summary>
        /// <param name="polygon">The hole polygon.</param>
        public void AddHole(Polygon2 polygon)
        {
            CheckHole(this, polygon);
            Kernel.AddHoleFromPolygon(Ptr, polygon.Ptr);
            HoleCount++;
        }

        /// <summary>
        /// Find if the polygon has a boundary.
        /// </summary>
        /// <returns>True if the polygon has a boundary.</returns>
        public bool FindIfUnbounded()
        {
            return Kernel.IsUnbounded(Ptr);
        }

        /// <summary>
        /// Find the polygons bounding box.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The polygons bounding box.</returns>
        public Box2d FindBoundingBox(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.GetBoundingBox(Ptr, BOUNDARY_INDEX);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                return Kernel.GetBoundingBox(Ptr, index);
            }
        }

        /// <summary>
        /// Find if the polygon is simple.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>True if the polygon is simple.</returns>
        public bool FindIfSimple(POLYGON_ELEMENT element, int index = 0)
        {
            if(element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.IsSimple(Ptr, BOUNDARY_INDEX);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                return Kernel.IsSimple(Ptr, index);
            }
        }

        /// <summary>
        /// Find if the polygon is convex.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>True if polygon is convex.</returns>
        public bool FindIfConvex(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.IsConvex(Ptr, BOUNDARY_INDEX);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                return Kernel.IsConvex(Ptr, index);
            }
        }

        /// <summary>
        /// Find the orientation of polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The orientation of the polygon.</returns>
        public ORIENTATION FindOrientation(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.Orientation(Ptr, BOUNDARY_INDEX);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                return Kernel.Orientation(Ptr, index);
            }
        }

        /// <summary>
        /// Find the orientated side the point is on.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="point"></param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The orientated side of point compared to the polygon.</returns>
        public ORIENTED_SIDE OrientedSide(POLYGON_ELEMENT element, Point2d point, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.OrientedSide(Ptr, BOUNDARY_INDEX, point);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                return Kernel.OrientedSide(Ptr, index, point);
            }
        }

        /// <summary>
        /// The signed area of the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// </summary>
        /// <returns>The signed area is positive if polygon is ccw 
        /// and negation if cw.</returns>
        public double FindSignedArea(POLYGON_ELEMENT element, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                return Kernel.SignedArea(Ptr, BOUNDARY_INDEX);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                return Kernel.SignedArea(Ptr, index);
            }
        }

        /// <summary>
        /// The area of the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        /// <returns>The polygons area.</returns>
        public double FindArea(POLYGON_ELEMENT element, int index = 0)
        {
            return Math.Abs(FindSignedArea(element, index));
        }

        /// <summary>
        /// Release the unmanaged resoures.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

        /// <summary>
        /// Does the polygon fully contain the other polygon.
        /// </summary>
        /// <param name="polygon">The other polygon.</param>
        /// <param name="inculdeBoundary">Should the boundary be included.</param>
        /// <returns>True if the polygon is contained within this polygon.</returns>
        private bool ContainsPolygon(Polygon2 polygon, bool inculdeBoundary = true)
        {
            for (int i = 0; i < polygon.Count; i++)
            {
                if (!ContainsPoint(polygon.GetPoint(i), inculdeBoundary))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Does this polygon contain the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="inculdeBoundary">Should points on the boundary be 
        /// counted as being inside the polygon.</param>
        /// <returns>True if the polygon contain the point.</returns>
        public bool ContainsPoint(Point2d point, bool inculdeBoundary = true)
        {
            var orientation = FindOrientation(POLYGON_ELEMENT.BOUNDARY);
            return Kernel.ContainsPoint(Ptr, point, orientation, inculdeBoundary);
        }

        /// <summary>
        /// Translate the polygon.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point2d translation)
        {
            Kernel.Translate(Ptr, BOUNDARY_INDEX, translation);

            int count = HoleCount;
            for (int i = 0; i < count; i++)
                Kernel.Translate(Ptr, i, translation);
        }

        /// <summary>
        /// Translate the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Translate(POLYGON_ELEMENT element, Point2d translation, int index = 0)
        {
            if(element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Translate(Ptr, BOUNDARY_INDEX, translation);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                Kernel.Translate(Ptr, index, translation);
            }
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="rotation">The amount to rotate in radians.</param>
        public void Rotate(Radian rotation)
        {
            Kernel.Rotate(Ptr, BOUNDARY_INDEX, rotation.angle);

            int count = HoleCount;
            for (int i = 0; i < count; i++)
                Kernel.Rotate(Ptr, i, rotation.angle);
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="rotation">The amount to rotate in radians.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Rotate(POLYGON_ELEMENT element, Radian rotation, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Rotate(Ptr, BOUNDARY_INDEX, rotation.angle);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                Kernel.Rotate(Ptr, index, rotation.angle);
            }
        }

        /// <summary>
        /// Rotate the polygon.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(double scale)
        {
            Kernel.Scale(Ptr, BOUNDARY_INDEX, scale);

            int count = HoleCount;
            for (int i = 0; i < count; i++)
                Kernel.Scale(Ptr, i, scale);
        }

        /// <summary>
        /// Scale the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="scale">The amount to scale.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Scale(POLYGON_ELEMENT element, double scale, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Scale(Ptr, BOUNDARY_INDEX, scale);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                Kernel.Scale(Ptr, index, scale);
            }
        }

        /// <summary>
        /// Transform the polygon.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate in radians.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point2d translation, Radian rotation, double scale)
        {
            Kernel.Transform(Ptr, BOUNDARY_INDEX, translation, rotation.angle, scale);

            int count = HoleCount;
            for (int i = 0; i < count; i++)
                Kernel.Transform(Ptr, i, translation, rotation.angle, scale);
        }

        /// <summary>
        /// Transform the polygon.
        /// </summary>
        /// <param name="element">The element type.</param>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate in radians.</param>
        /// <param name="scale">The amount to scale.</param>
        /// <param name="index">If element type is a hole this is the holes index.</param>
        public void Transform(POLYGON_ELEMENT element, Point2d translation, Radian rotation, double scale, int index = 0)
        {
            if (element == POLYGON_ELEMENT.BOUNDARY)
                Kernel.Transform(Ptr, BOUNDARY_INDEX, translation, rotation.angle, scale);
            else
            {
                if (CheckFlag.HasFlag(POLYGON_CHECK.ARRAY_BOUNDS))
                    ErrorUtil.CheckBounds(index, HoleCount);

                Kernel.Transform(Ptr, index, translation, rotation.angle, scale);
            }
        }

        /// <summary>
        /// Print debug infomation.
        /// </summary>
        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// Print debug infomation.
        /// </summary>
        /// <param name="builder"></param>
        public void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("Is unbounded = " + IsUnbounded);

            if (!IsUnbounded)
            {
                var element = POLYGON_ELEMENT.BOUNDARY;
                builder.AppendLine("Boundary point count = " + PointCount(element));
                builder.AppendLine("Boundary is simple = " + FindIfSimple(element));
                builder.AppendLine("Boundary is convex = " + FindIfConvex(element));
                builder.AppendLine("Boundary orientation = " + FindOrientation(element));
                builder.AppendLine("Boundary signed Area = " + FindSignedArea(element));
            }

            for (int i = 0; i < HoleCount; i++)
            {
                builder.AppendLine("");
                var element = POLYGON_ELEMENT.HOLE;
                builder.AppendLine("Hole " + i + " point count = " + PointCount(element, i));
                builder.AppendLine("Hole " + i + " is simple = " + FindIfSimple(element, i));
                builder.AppendLine("Hole " + i + " is convex = " + FindIfConvex(element, i));
                builder.AppendLine("Hole " + i + " is orientation = " + FindOrientation(element, i));
                builder.AppendLine("Hole " + i + " is signed area = " + FindSignedArea(element, i));
                builder.AppendLine();
            }
        }

        /// <summary>
        /// Is this polygon a valid boundary.
        /// Must be simple and ccw.
        /// </summary>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public static bool IsValidBoundary(Polygon2 polygon)
        {
            if (!polygon.CheckFlag.HasFlag(POLYGON_CHECK.IS_VALID_BOUNDARY))
                return true;

            return polygon.IsSimple && polygon.IsCounterClockWise;
        }

        /// <summary>
        /// Is the polygon a valid hole for the polygon with holes.
        /// Holes must be simple, cw and be fully contained in the polygon.
        /// </summary>
        /// <param name="pwh"></param>
        /// <param name="polygon"></param>
        /// <returns></returns>
        public static bool IsValidHole(PolygonWithHoles2 pwh, Polygon2 polygon)
        {
            if (!polygon.CheckFlag.HasFlag(POLYGON_CHECK.IS_VALID_HOLE))
                return true;

            return polygon.IsSimple && polygon.IsClockWise && pwh.ContainsPolygon(polygon);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polygon"></param>
        protected void CheckBoundary(Polygon2 polygon)
        {
            if (!IsValidBoundary(polygon))
                throw new Exception("Boundary must be simple and counter clock wise.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pwh"></param>
        /// <param name="polygon"></param>
        protected void CheckHole(PolygonWithHoles2 pwh, Polygon2 polygon)
        {
            if (!IsValidHole(pwh, polygon))
                throw new Exception("Polygon must be simple, clock wise and not intersect the boundary or holes to be a polygon hole.");
        }

        /// <summary>
        /// 
        /// </summary>
        protected void CheckIsBounded()
        {
            if (IsUnbounded)
                throw new NullReferenceException("This is not a valid operation on a unbounded polygon.");
        }
    }
}
