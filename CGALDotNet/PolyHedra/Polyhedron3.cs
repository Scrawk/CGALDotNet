using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Processing;

namespace CGALDotNet.Polyhedra
{

    /// <summary>
    /// Generic polyhedron definition.
    /// A polyhedral surface Polyhedron_3 consists of vertices, edges, 
    /// facets and an incidence relation on them.
    //  Each edge is represented by two halfedges with opposite orientations.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class Polyhedron3<K> : Polyhedron3 where K : CGALKernel, new()
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Polyhedron3() : base(new K())
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polyhedrons pointer.</param>
        internal Polyhedron3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The polyhdron as a string.
        /// </summary>
        /// <returns>The polyhedron as a string.</returns>
        public override string ToString()
        {
            return string.Format("[Polyhedron3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FaceCount={3}]",
                Kernel.KernelName, VertexCount, HalfEdgeCount, FaceCount);
        }

        /// <summary>
        /// Create a deep copy of the polyhedron.
        /// </summary>
        /// <returns>A deep copy of the polyhedron.</returns>
        public Polyhedron3<K> Copy()
        {
            return new Polyhedron3<K>(Kernel.Copy(Ptr));
        }

        /// <summary>
        /// Subdive the polyhedron.
        /// </summary>
        /// <param name="iterations">The number of iterations to perfrom.</param>
        /// <param name="method">The subdivision method.</param>
        public override void Subdivide(int iterations, SUBDIVISION_METHOD method = SUBDIVISION_METHOD.SQRT3)
        {
            try
            {
                var sub = SubdivisionSurface<K>.Instance;
                sub.Subdivide(method, this, iterations);
                IsUpdated = false;
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };
        }

        /// <summary>
        /// Simplify the polyhedra.
        /// </summary>
        /// <param name="stop_ratio">A number between 0-1 that represents the percentage of vertices to remove.</param>
        public override void Simplify(double stop_ratio)
        {
            try
            {
                var sim = SurfaceSimplification<K>.Instance;
                sim.Simplify(this, stop_ratio);
                IsUpdated = false;
            }
            catch (NotImplementedException) { }
            catch (NotSupportedException) { };
        }

    }

    /// <summary>
    /// The abstract polyhedra definition.
    /// </summary>
    public abstract class Polyhedron3 : CGALObject
    {
        /// <summary>
        /// Cached values found by running Update.
        /// </summary>
        private bool m_isValid;
        private bool m_isClosed;
        private bool m_isTriangle;
        private bool m_isQuad;

        /// <summary>
        /// Default constructor.
        /// </summary>
        private Polyhedron3()
        {

        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        internal Polyhedron3(CGALKernel kernel)
        {
            Kernel = kernel.PolyhedronKernel3;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        /// <param name="ptr">The polyhedrons pointer.</param>
        internal Polyhedron3(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolyhedronKernel3;
        }

        /// <summary>
        /// The polyhedron kernel.
        /// Contains the functions to the unmanaged CGAL polhedron.
        /// </summary>
        protected private PolyhedronKernel3 Kernel { get; private set; }

        /// <summary>
        /// Number of vertices.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// Number of faces.
        /// </summary>
        public int FaceCount => Kernel.FaceCount(Ptr);

        /// <summary>
        /// Number of half edges.
        /// </summary>
        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        /// <summary>
        /// Number of border edges.
        /// Since each border edge of a polyhedral surface has exactly one 
        /// border halfedge, this number is equal to size of border halfedges.
        /// </summary>
        public int BorderEdgeCount => Kernel.BorderEdgeCount(Ptr);

        /// <summary>
        /// Number of border halfedges.
        /// </summary>
        public int BorderHalfEdgeCount => Kernel.BorderHalfEdgeCount(Ptr);

        /// <summary>
        /// Returns true if the polyhedral surface is combinatorially consistent.
        /// Must be a valid mesh to check many other properties.
        /// </summary>
        public bool IsValid
        {
            get
            {
                Update();
                return m_isValid;
            }
            protected set
            {
                m_isValid = value;
            }
        }

        /// <summary>
        /// Returns true if there are no border edges.
        /// </summary>
        public bool IsClosed
        {
            get
            {
                Update();
                return m_isClosed;
            }
            protected set
            {
                m_isClosed = value;
            }
        }

        /// <summary>
        /// Returns true if all faces are triangles.
        /// </summary>
        public bool IsTriangle
        {
            get
            {
                Update();
                return m_isTriangle;
            }
            protected set
            {
                m_isTriangle = value;
            }
        }

        /// <summary>
        /// Returns true if all faces are quads.
        /// </summary>
        public bool IsQuad
        {
            get
            {
                Update();
                return m_isQuad;
            }
            protected set
            {
                m_isQuad = value;
            }
        }

        /// <summary>
        /// Has the update function been called.
        /// </summary>
        protected bool IsUpdated { get; set; }

        /// <summary>
        /// returns true if the polyhedral surface is combinatorially consistent.
        // For level == 1 the normalization of the border edges is checked too.
        // This method checks that each face is at least a triangle and that the
        // two incident facets of a non-border edge are distinct.
        /// </summary>
        /// <returns></returns>
        public bool FindIfValid(int level = 0)
        {
            return Kernel.IsValid(Ptr, level);
        }

        /// <summary>
        /// Clear the polyhedron.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// A tetrahedron is added to the polyhedral surface
        /// with its vertices initialized to p1, p2, p3, and p4.
        /// </summary>
        public void MakeTetrahedron(Point3d p1, Point3d p2, Point3d p3, Point3d p4)
        {
            Kernel.MakeTetrahedron(Ptr, p1, p2, p3, p4);
            IsUpdated = false;
        }

        /// <summary>
        /// A triangle with border edges is added to the 
        /// polyhedral surface with its vertices initialized to p1, p2, and p3.
        /// </summary>
        public void MakeTriangle(Point3d p1, Point3d p2, Point3d p3)
        {
            Kernel.MakeTriangle(Ptr, p1, p2, p3);
            IsUpdated = false;
        }

        /// <summary>
        /// Create a mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="triangles">The meshes triangles as a index array. Maybe null.</param>
        /// <param name="quads">The meshes quads as a index array. Maybe null.</param>
        public void CreateMesh(Point3d[] points, int[] triangles, int[] quads)
        {
            bool hasTriangles = triangles != null && triangles.Length > 0;
            bool hasquads = quads != null && quads.Length > 0;

            if (hasTriangles && hasquads)
                CreateTriangleQuadMesh(points, triangles, quads);
            else if (hasTriangles)
                CreateTriangleMesh(points, triangles);
            else if (hasquads)
                CreateQuadMesh(points, quads);
        }

        /// <summary>
        /// Create a triangle mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="indices">The meshes triangles as a index array.</param>
        public void CreateTriangleMesh(Point3d[] points, int[] triangles)
        {
            ErrorUtil.CheckArray(points, points.Length);
            ErrorUtil.CheckArray(triangles, triangles.Length);

            Clear();
            IsUpdated = false;
            Kernel.CreateTriangleMesh(Ptr, points, points.Length, triangles, triangles.Length);
        }

        /// <summary>
        /// Create a quad mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="quads">The meshes quads as a index array.</param>
        public void CreateQuadMesh(Point3d[] points, int[] quads)
        {
            ErrorUtil.CheckArray(points, points.Length);
            ErrorUtil.CheckArray(quads, quads.Length);

            Clear();
            IsUpdated = false;
            Kernel.CreateQuadMesh(Ptr, points, points.Length, quads, quads.Length);
        }

        /// <summary>
        /// Create a triangle mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="triangles">The meshes triangles as a index array.</param>
        /// <param name="quads">The meshes quads as a index array.</param>
        public void CreateTriangleQuadMesh(Point3d[] points, int[] triangles, int[] quads)
        {
            ErrorUtil.CheckArray(points, points.Length);
            ErrorUtil.CheckArray(triangles, triangles.Length);
            ErrorUtil.CheckArray(quads, quads.Length);

            Clear();
            IsUpdated = false;
            Kernel.CreateTriangleQuadMesh(Ptr, points, points.Length, triangles, triangles.Length, quads, quads.Length);
        }

        /// <summary>
        /// Get the meshes points.
        /// </summary>
        /// <param name="points">The array to copy the points into.</param>
        /// <param name="count">The ararys length.</param>
        public void GetPoints(Point3d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.GetPoints(Ptr, points, count);
        }

        /// <summary>
        /// Count the number of triangles, quads and polygons in the mesh.
        /// </summary>
        /// <returns>The number of triangles, quads and polygons in the mesh.</returns>
        public PrimativeCount GetPrimativeCount()
        {
            return Kernel.GetPrimativeCount(Ptr);
        }

        /// <summary>
        /// Get the meshes triangle indices.
        /// </summary>
        /// <param name="indices">The array to copy the indices into.</param>
        /// <param name="count">The ararys length.</param>
        public void GetTriangleIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetTriangleIndices(Ptr, indices, count);
        }

        /// <summary>
        /// Get the meshes quad indices.
        /// </summary>
        /// <param name="indices">The array to copy the indices into.</param>
        /// <param name="count">The ararys length.</param>
        public void GetQuadIndices(int[] indices, int count)
        {
            ErrorUtil.CheckArray(indices, count);
            Kernel.GetQuadIndices(Ptr, indices, count);
        }

        /// <summary>
        /// Translate each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        public void Translate(Point3d translation)
        {
            var m = Matrix4x4d.Translate(translation);
            Kernel.Transform(Ptr, m);
            IsUpdated = false;
        }

        /// <summary>
        /// Rotate each point in the mesh.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        public void Rotate(Quaternion3d rotation)
        {
            var m = rotation.ToMatrix4x4d();
            Kernel.Transform(Ptr, m);
            IsUpdated = false;
        }

        /// <summary>
        /// Scale each point in the mesh.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        public void Scale(Point3d scale)
        {
            var m = Matrix4x4d.Scale(scale);
            Kernel.Transform(Ptr, m);
            IsUpdated = false;
        }

        /// <summary>
        /// Transform each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        public void Transform(Point3d translation, Quaternion3d rotation, Point3d scale)
        {
            var m = Matrix4x4d.TranslateRotateScale(translation, rotation, scale);
            Kernel.Transform(Ptr, m);
            IsUpdated = false;
        }

        /// <summary>
        /// Reverses facet orientations (incl. plane equations if supported).
        /// </summary>
        internal void InsideOut()
        {
            if (!IsValid) return;

            Kernel.InsideOut(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// Make all faces triangles.
        /// </summary>
        public void Triangulate()
        {
            if (!IsValid || IsTriangle) return;

            Kernel.Triangulate(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// sorts halfedges such that the non-border edges precede the border edges.
        /// For each border edge the halfedge iterator will reference the halfedge 
        /// incident to the facet right before the halfedge incident to the hole.
        /// </summary>
        public void NormalizeBorder()
        {
            if (!IsValid) return;

            Kernel.NormalizeBorder(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// returns true if the border halfedges are in normalized representation, 
        /// which is when enumerating all halfedges with the iterator: 
        /// The non-border edges precede the border edges and for border edges,
        /// the second halfedge is the border halfedge.
        /// </summary>
        /// <returns></returns>
        public bool NormalizedBorderIsValid()
        {
            return Kernel.NormalizedBorderIsValid(Ptr);
        }

        /// <summary>
        /// Find what side of the polyhedron the lies in.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>ON_BOUNDED_SIDE if point inside mesh, 
        /// ON_UNBOUNDED_SIDE if point not inside, 
        /// ON_BOUNDARY if point is on the surface.</returns>
        public BOUNDED_SIDE BoundedSide(Point3d point)
        {
            if (IsValid) 
                return Kernel.SideOfTriangleMesh(Ptr, point);
            else
                return BOUNDED_SIDE.UNDETERMINED;

        }

        /// <summary>
        /// Does the mesh contain the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="includeBoundary">If point is on the boundary does it count a being contained.</param>
        /// <returns>True if the poly contains the point</returns>
        public bool ContainsPoint(Point3d point, bool includeBoundary = true)
        {
            var side = BoundedSide(point);

            if (side == BOUNDED_SIDE.UNDETERMINED)
                return false;

            if (side == BOUNDED_SIDE.ON_BOUNDED_SIDE)
                return true;

            if (includeBoundary && side == BOUNDED_SIDE.ON_BOUNDARY)
                return true;

            return false;
        }

        /// <summary>
        /// makes each connected component of a closed 
        /// triangulated surface mesh inward or outward oriented.
        /// Must be a closed triangle mesh.
        /// </summary>
        public void Orient()
        {
            if (!IsValid) return;
            Kernel.Orient(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// Orients the connected components of poly to 
        /// make it bound a volume.
        /// Must be a closed triangle mesh.
        /// </summary>
        public void OrientToBoundingVolume()
        {
            if (!IsValid) return;
            Kernel.OrientToBoundingVolume(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// Reverses for each face in face_range the order of 
        /// the vertices along the face boundary.
        /// The function does not perform any control
        /// and if the orientation change of the faces
        /// makes the polygon mesh invalid, the behavior is undefined.
        /// </summary>
        public void ReverseOreintation()
        {
            if (!IsValid) return;
            Kernel.ReverseFaceOrientations(Ptr);
            IsUpdated = false;
        }

        /// <summary>
        /// Tests if a set of faces of a triangulated surface mesh self-intersects.
        /// Must be a triangle mesh.
        /// </summary>
        /// <returns>True/Fasle if a valid triangle polyhedra,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED DoesSelfIntersect()
        {
            if (IsValid && IsTriangle)
                return Kernel.DoesSelfIntersect(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Computes the area of a range of faces
        /// of a given triangulated surface mesh.
        /// </summary>
        /// <returns>The area or 0 if poyhedron is not valid triangle mesh.</returns>
        public double FindArea()
        {
            if (IsValid && IsTriangle)
                return Kernel.Area(Ptr);
            else
                return 0;

        }

        /// <summary>
        /// computes the centroid of a volume bounded 
        /// by a closed triangulated surface mesh.
        /// </summary>
        /// <returns>The centroid or 0 if poyhedron is not valid.</returns>
        public Point3d FindCentroid()
        {
            if (IsValid)
                return Kernel.Centroid(Ptr);
            else
                return Point3d.Zero;
        }

        /// <summary>
        /// Computes the volume of the domain bounded by a 
        /// closed triangulated surface mesh.
        /// </summary>
        /// <returns>The volume or 0 if poyhedron is not valid closed triangle mesh.</returns>
        public double FindVolume()
        {
            if (IsValid && IsTriangle && IsClosed)
                return Kernel.Volume(Ptr);
            else
                return 0;
        }

        /// <summary>
        /// Returns true if there are no border edges.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfClosed()
        {
            if (IsValid)
                return Kernel.IsClosed(Ptr).ToBoolOrUndetermined();
            else 
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Returns true if all vertices have exactly two incident edges.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfBivalent()
        {
            if (IsValid)
                return Kernel.IsPureBivalent(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Returns true if all vertices have exactly three incident edges.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfTrivalent()
        {
            if (IsValid)
                return Kernel.IsPureTrivalent(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Returns true if all faces are triangles.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfTriangleMesh()
        {
            if (IsValid)
                return (Kernel.IsPureTriangle(Ptr) == 0).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Returns true if all faces are quads.
        /// </summary>
        /// <returns>True/Fasle if valid, or UNDETERMINED if not a valid polyhedra.</returns>
        public BOOL_OR_UNDETERMINED FindIfQuadMesh()
        {
            if (IsValid)
                return (Kernel.IsPureQuad(Ptr) == 0).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Indicates if the polyhedron bounds a volume.
        /// Must be a closed and triangulated.
        /// </summary>
        /// <returns>True/Fasle if a valid triangle closed polyhedra,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED FindIfDoesBoundAVolume()
        {
            if (IsValid && IsTriangle && IsClosed)
                return Kernel.DoesBoundAVolume(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Tests whether a closed triangle mesh has a positive orientation.
        /// A closed triangle mesh is considered to have a positive orientation 
        /// if the normal vectors to all its faces point outside the domain 
        /// bounded by the triangle mesh.The normal vector to each face is 
        /// chosen pointing on the side of the face where its sequence of 
        /// vertices is seen counterclockwise.
        /// Must be a closed triangle mesh free from self-intersections to be tested.
        /// </summary>
        /// <returns>True/Fasle if a valid triangle closed polyhedra,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED FindIfIsOutwardOriented()
        {
            if (IsValid && IsTriangle && IsClosed)
                return Kernel.IsOutwardOriented(Ptr).ToBoolOrUndetermined();
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Builds the aabb tree used for location.
        /// Tree will be automatically built if need so not 
        /// actually necessary to call this function.
        /// </summary>
        public void BuildAABBTree()
        {
            Kernel.BuildAABBTree(Ptr);
        }

        /// <summary>
        /// Will delete the aabb tree.
        /// </summary>
        public void ReleaseAABBTree()
        {
            Kernel.ReleaseAABBTree(Ptr);
        }

        /// <summary>
        /// Returns true if there exists a face of this poly and 
        /// a face of other poly which intersect, and false otherwise.
        /// Must be a triangle mesh
        /// </summary>
        /// <param name="poly">The other triangle poly.</param>
        /// <param name="test_bounded_sides">If test_bounded_sides is set to true, 
        /// the overlap of bounded sides are tested as well. In that case, the meshes must be closed.</param>
        /// <returns>True/Fasle if a valid triangle closed polyhedra,or UNDETERMINED if not.</returns>
        public BOOL_OR_UNDETERMINED DoIntersect(Polyhedron3 poly, bool test_bounded_sides = true)
        {
            if (IsValid && IsTriangle && poly.IsValid && poly.IsTriangle)
            {
                //if test bounded side both must be closed meshes.
                //If not test bounded side does not matter if not closed.
                if ((test_bounded_sides && IsClosed && poly.IsClosed) || !test_bounded_sides)
                {
                    return Kernel.DoIntersects(Ptr, poly.Ptr, test_bounded_sides).ToBoolOrUndetermined();
                }
                else
                    return BOOL_OR_UNDETERMINED.UNDETERMINED;
            }
            else
                return BOOL_OR_UNDETERMINED.UNDETERMINED;
        }

        /// <summary>
        /// Subdive the polyhedron.
        /// </summary>
        /// <param name="iterations">The number of iterations to perfrom.</param>
        /// <param name="method">The subdivision method.</param>
        public abstract void Subdivide(int iterations, SUBDIVISION_METHOD method = SUBDIVISION_METHOD.SQRT3);

        /// <summary>
        /// Simplify the polyhedra.
        /// </summary>
        /// <param name="stop_ratio">A number between 0-1 that represents the percentage of vertices to remove.</param>
        public abstract void Simplify(double stop_ratio);

        /// <summary>
        /// Read data from a off file into the pollyhedron.
        /// </summary>
        /// <param name="filename">The files name.</param>
        public void ReadOFF(string filename)
        {
            Kernel.ReadOFF(Ptr, filename);
            IsUpdated = false;
        }

        /// <summary>
        /// Write data from a off file into the pollyhedron.
        /// </summary>
        /// <param name="filename">The files name.</param>
        public void WriteOFF(string filename)
        {
            Kernel.WriteOFF(Ptr, filename);
        }

        /// <summary>
        /// Update the polyhedron if needed.
        /// </summary>
        protected void Update()
        {
            if (IsUpdated) return;
            IsUpdated = true;

            if (FindIfValid())
            {
                m_isValid = true;
                m_isClosed = FindIfClosed() == BOOL_OR_UNDETERMINED.TRUE;
                m_isTriangle = FindIfTriangleMesh() == BOOL_OR_UNDETERMINED.TRUE;
                m_isQuad = FindIfQuadMesh() == BOOL_OR_UNDETERMINED.TRUE;
            }
            else
            {
                m_isValid = false;
                m_isClosed = false;
                m_isTriangle = false;
                m_isQuad = false;   
            }
        }

        /// <summary>
        /// Print the polyhedron into a string builder.
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            Update();
            builder.AppendLine(ToString());
            builder.AppendLine("HalfEdgeCount = " + HalfEdgeCount);
            builder.AppendLine("BorderEdgeCount = " + BorderEdgeCount);
            builder.AppendLine("BorderHalfEdgeCount = " + BorderHalfEdgeCount);
            builder.AppendLine("IsValid = " + IsValid);
            builder.AppendLine("NormalizedBorderIsValid = " + NormalizedBorderIsValid());
            builder.AppendLine("IsClosed = " + IsClosed);
            builder.AppendLine("IsTriangle = " + IsTriangle);
            builder.AppendLine("IsQuad = " + IsQuad);
            builder.AppendLine("IsBivalent = " + FindIfBivalent());
            builder.AppendLine("IsTrivalent = " + FindIfTrivalent());
            builder.AppendLine("DoesSelfIntersect = " + DoesSelfIntersect());
            builder.AppendLine("Area = " + FindArea());
            builder.AppendLine("Volume = " + FindVolume());
            builder.AppendLine("DoesBoundAVolume = " + FindIfDoesBoundAVolume());
            builder.AppendLine("IsOutwardOriented = " + FindIfIsOutwardOriented());
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
