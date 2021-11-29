using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
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
        public NefPolyhedron3(Plane3d plane, NEF_BOUNDARY boundary = NEF_BOUNDARY.INCLUDED) : base(new K(), plane, boundary)
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
            return string.Format("[NefPolyhedra3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FacetCount={3}]",
                Kernel.KernelName, VertexCount, HalfEdgeCount, FacetCount);
        }

        public NefPolyhedron3<K> Intersection(NefPolyhedron3<K> nef)
        {
            var ptr = Kernel.Intersection(Ptr, nef.Ptr);
            return new NefPolyhedron3<K>(ptr);
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

        public int EdgeCount => Kernel.EdgeCount(Ptr);

        public int FacetCount => Kernel.FacetCount(Ptr);

        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        public int HalfFacetCount => Kernel.HalfFacetCount(Ptr);

        public int VertexCount => Kernel.VertexCount(Ptr);

        public int VolumeCount => Kernel.VolumeCount(Ptr);

        public bool IsEmpty => Kernel.IsEmpty(Ptr);

        public bool IsSimple => Kernel.IsSimple(Ptr);

        public bool IsSpace => Kernel.IsSpace(Ptr);

        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        /// <summary>
        /// Print the nef polyhedron.
        /// </summary>
        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// Print the nef polyhedron into a string builder.
        /// </summary>
        /// <param name="builder"></param>
        public void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
            builder.AppendLine("EdgeCount = " + EdgeCount);
            builder.AppendLine("HalfFacetCount = " + HalfFacetCount);
            builder.AppendLine("VolumeCount = " + VolumeCount);
            builder.AppendLine("IsEmpty = " + IsEmpty);
            builder.AppendLine("IsSimple = " + IsSimple);
            builder.AppendLine("IsSpace = " + IsSpace);
            builder.AppendLine("IsValid = " + IsValid());
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
