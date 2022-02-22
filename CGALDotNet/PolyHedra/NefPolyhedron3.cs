using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
    public enum NEF_BOUNDARY : int
    {
        EXCLUDED,
        INCLUDED
    }

    public enum NEF_CONTENT : int
    {
        EMPTY,
        COMPLETE
    }

    public enum NEF_INTERSECTION : int
    {
        CLOSED_HALFSPACE,
        OPEN_HALFSPACE,
        PLANE_ONLY
    }


    /// <summary>
    /// Generic nef polyhedron definition.
    /// A 3D Nef polyhedron is a subset of the 3-dimensional space that is the result of forming
    /// complements and intersections starting from a finite set H of 3-dimensional halfspaces.
    /// Nef polyhedra are closed under all binary set operations, i.e., intersection, union, 
    /// difference, complement, and under the topological operations boundary, closure, and interior.
    /// </summary>
    /// <typeparam name="K">The kernel type.</typeparam>
    public sealed class NefPolyhedron3<K> : NefPolyhedron3 where K : CGALKernel, new()
    {
        /// <summary>
        /// creates a Nef polyhedron and initializes it to the empty 
        /// set if plane == EMPTY and to the whole space if space == COMPLETE.
        /// </summary>
        /// <param name="space">The nef's space</param>
        public NefPolyhedron3(NEF_CONTENT space = NEF_CONTENT.EMPTY) : base(new K(), space)
        {

        }

        /// <summary>
        /// creates a Nef polyhedron containing the halfspace on the 
        /// negative side of plane including plane if boundary==INCLUDED, 
        /// excluding plane if boundary==EXCLUDED.
        /// </summary>
        /// <param name="plane">The plane.</param>
        /// <param name="boundary">The boundary.</param>
        internal NefPolyhedron3(Plane3d plane, NEF_BOUNDARY boundary = NEF_BOUNDARY.INCLUDED) : base(new K(), plane, boundary)
        {

        }

        /// <summary>
        /// creates a Nef polyhedron, which represents the same point 
        /// set as the polyhedral surface.
        /// </summary>
        /// <param name="polyhedra">The polyhedron</param>
        public NefPolyhedron3(Polyhedron3 polyhedra) : base(new K(), polyhedra)
        {

        }

        /// <summary>
        /// Create from a pointer.
        /// </summary>
        /// <param name="ptr">The polyhedrons pointer.</param>
        internal NefPolyhedron3(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// The nef polyhdron as a string.
        /// </summary>
        /// <returns>The nef polyhedron as a string.</returns>
        public override string ToString()
        {
            return string.Format("[NefPolyhedra3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FaceCount={3}]",
                Kernel.Name, VertexCount, HalfEdgeCount, FaceCount);
        }

        /// <summary>
        /// Return the intersection of nef and nef1.
        /// </summary>
        /// <param name="nef"></param>
        /// <returns></returns>
        public NefPolyhedron3<K> Intersection(NefPolyhedron3<K> nef)
        {
            var ptr = Kernel.Intersection(Ptr, nef.Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Return the union of nef and nef1.
        /// </summary>
        /// <param name="nef"></param>
        /// <returns></returns>
        public NefPolyhedron3<K> Join(NefPolyhedron3<K> nef)
        {
            var ptr = Kernel.Join(Ptr, nef.Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Return the difference between nef and nef1.
        /// </summary>
        /// <param name="nef"></param>
        /// <returns></returns>
        public NefPolyhedron3<K> Difference(NefPolyhedron3<K> nef)
        {
            var ptr = Kernel.Difference(Ptr, nef.Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Return the symmetric difference of nef and nef1.
        /// </summary>
        /// <param name="nef"></param>
        /// <returns></returns>
        public NefPolyhedron3<K> SymmetricDifference(NefPolyhedron3<K> nef)
        {
            var ptr = Kernel.SymmetricDifference(Ptr, nef.Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Returns the complement of nef. 
        /// </summary>
        /// <returns></returns>
        public NefPolyhedron3<K> Complement()
        {
            var ptr = Kernel.Complement(Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Returns the interior of nef. 
        /// </summary>
        /// <returns></returns>
        public NefPolyhedron3<K> Interior()
        {
            var ptr = Kernel.Interior(Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Returns the boundary of nef. 
        /// </summary>
        /// <returns></returns>
        public NefPolyhedron3<K> Boundary()
        {
            var ptr = Kernel.Boundary(Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Returns the closure of nef.
        /// </summary>
        /// <returns></returns>
        public NefPolyhedron3<K> Closure()
        {
            var ptr = Kernel.Closure(Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Returns the regularization, i.e. the closure of the interior, of nef.
        /// </summary>
        /// <returns></returns>
        public NefPolyhedron3<K> Regularization()
        {
            var ptr = Kernel.Regularization(Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Returns the MinkowskiSum.
        /// </summary>
        /// <returns></returns>
        public NefPolyhedron3<K> MinkowskiSum(NefPolyhedron3<K> nef)
        {
            var ptr = Kernel.MinkowskiSum(Ptr, nef.Ptr);
            return new NefPolyhedron3<K>(ptr);
        }

        /// <summary>
        /// Converts nef into a Polyhedron.
        /// nef must be simple to convert.
        /// </summary>
        /// <param name="poly">The result of the conversion.</param>
        /// <returns>True if nef is simple and the conversion was successful.</returns>
        public bool ConvertToPolyhedron(out Polyhedron3<K> poly)
        {
            if (IsSimple)
            {
                var ptr = Kernel.ConvertToPolyhedron(Ptr);
                poly = new Polyhedron3<K>(ptr);
                return true;
            }
            else
            {
                poly = null;
                return false;
            }
        }

        /// <summary>
        /// Converts nef into a surface mesh.
        /// nef must be simple to convert.
        /// </summary>
        /// <param name="mesh">The result of the conversion.</param>
        /// <returns>True if nef is simple and the conversion was successful.</returns>
        public bool ConvertToSurfaceMesh(out SurfaceMesh3<K> mesh)
        {
            if (IsSimple)
            {
                var ptr = Kernel.ConvertToSurfaceMesh(Ptr);
                mesh = new SurfaceMesh3<K>(ptr);
                return true;
            }
            else
            {
                mesh = null;
                return false;
            }
        }

        /// <summary>
        /// Get a list of the nef volumes.
        /// </summary>
        /// <param name="volumes">Get a list of the nef volumes.</param>
        public void GetVolumes(List<Polyhedron3<K>> volumes)
        {
            int count = VolumeCount;
            if (count == 0) return;

            var array = new IntPtr[count];
            Kernel.GetVolumes(Ptr, array, count);

            for(int i = 0; i < array.Length; i++)
                volumes.Add(new Polyhedron3<K>(array[i]));
        }
    }

    /// <summary>
    /// The abstract nef polyhedra definition.
    /// </summary>
    public abstract class NefPolyhedron3 : CGALObject
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        private NefPolyhedron3()
        {

        }

        /// <summary>
        /// creates a Nef polyhedron and initializes it to the empty 
        /// set if plane == EMPTY and to the whole space if space == COMPLETE.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        /// <param name="space">The nef's space</param>
        public NefPolyhedron3(CGALKernel kernel, NEF_CONTENT space)
        {
            Kernel = kernel.NefPolyhedronKernel3;
            Ptr = Kernel.CreateFromSpace(space);
        }

        /// <summary>
        /// creates a Nef polyhedron containing the halfspace on the 
        /// negative side of plane including plane if boundary==INCLUDED, 
        /// excluding plane if boundary==EXCLUDED.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        /// <param name="plane">The plane.</param>
        /// <param name="boundary">The boundary.</param>
        public NefPolyhedron3(CGALKernel kernel, Plane3d plane, NEF_BOUNDARY boundary)
        {
            Kernel = kernel.NefPolyhedronKernel3;
            Ptr = Kernel.CreateFromPlane(plane, boundary);
        }

        /// <summary>
        /// creates a Nef polyhedron, which represents the same point 
        /// set as the polyhedral surface.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        /// <param name="polyhedra">The polyhedron</param>
        public NefPolyhedron3(CGALKernel kernel, Polyhedron3 polyhedra)
        {
            Kernel = kernel.NefPolyhedronKernel3;
            Ptr = Kernel.CreateFromPolyhedron(polyhedra.Ptr);
        }

        /// <summary>
        /// Construct with a new kernel.
        /// </summary>
        /// <param name="kernel">The polyhedron kernel.</param>
        /// <param name="ptr">The polyhedrons pointer.</param>
        internal NefPolyhedron3(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.NefPolyhedronKernel3;
        }

        /// <summary>
        /// The polyhedron kernel.
        /// Contains the functions to the unmanaged CGAL polhedron.
        /// </summary>
        protected private NefPolyhedronKernel3 Kernel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int EdgeCount => Kernel.EdgeCount(Ptr);

        /// <summary>
        /// Return the number of halfedge pairs.
        /// </summary>
        public int FaceCount => Kernel.FacetCount(Ptr);

        /// <summary>
        /// Return the number of halfedges.
        /// </summary>
        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        /// <summary>
        /// Return the number of faces.
        /// </summary>
        public int HalfFaceCount => Kernel.HalfFacetCount(Ptr);

        /// <summary>
        /// Return the number of vertices.
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// Return the number of volumes.
        /// </summary>
        public int VolumeCount => Kernel.VolumeCount(Ptr);

        /// <summary>
        /// Returns true, if nef is the empty point set.
        /// </summary>
        public bool IsEmpty => Kernel.IsEmpty(Ptr);

        /// <summary>
        /// Rreturns true, if nef is a 2-manifold.
        /// </summary>
        public bool IsSimple => Kernel.IsSimple(Ptr);

        /// <summary>
        /// Returns true, if nef is the complete 3D space.
        /// </summary>
        public bool IsSpace => Kernel.IsSpace(Ptr);

        /// <summary>
        /// Make nef the empty set if space == EMPTY and the complete 
        /// 3D space if space == COMPLETE.
        /// </summary>
        public void Clear(NEF_CONTENT space = NEF_CONTENT.EMPTY)
        {
            Kernel.Clear(Ptr, space);
        }

        /// <summary>
        /// Checks the integrity of nef.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        /// <summary>
        /// Decompose the nef into convex volumes.
        /// </summary>
        public void ConvexDecomposition()
        {
            Kernel.ConvexDecomposition(Ptr);
        }

        /// <summary>
        /// Print the nef polyhedron into a string builder.
        /// </summary>
        /// <param name="builder"></param>
        public override void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("VertexCount = " + VertexCount);
            builder.AppendLine("EdgeCount = " + EdgeCount);
            builder.AppendLine("FaceCount = " + FaceCount);
            builder.AppendLine("HalfFaceCount = " + HalfFaceCount);
            builder.AppendLine("VolumeCount = " + VolumeCount);
            builder.AppendLine("IsValid = " + IsValid());
            builder.AppendLine("IsEmpty = " + IsEmpty);
            builder.AppendLine("IsSimple = " + IsSimple);
            builder.AppendLine("IsSpace = " + IsSpace);
            
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
