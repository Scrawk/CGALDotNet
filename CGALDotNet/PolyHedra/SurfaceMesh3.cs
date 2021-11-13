using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.PolyHedra
{

    /// <summary>
    /// The generic surface mesh class.
    /// </summary>
    /// <typeparam name="K">The kernel type</typeparam>
    public sealed class SurfaceMesh3<K> : SurfaceMesh3 where K : CGALKernel, new()
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceMesh3() : base(new K())
        {

        }

        /// <summary>
        /// The mesh as a string.
        /// </summary>
        /// <returns>The mesh as a string.</returns>
        public override string ToString()
        {
            return string.Format("[SurfaceMesh3<{0}>: VertexCount={1}, HalfEdgeCount={2}, FaceCount={3}]",
                Kernel.Name, VertexCount, HalfEdgeCount, FaceCount);
        }
    }

    /// <summary>
    /// The surface mesh abstract base class.
    /// </summary>
    public abstract class SurfaceMesh3 : CGALObject
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        private SurfaceMesh3()
        {

        }

        /// <summary>
        /// Construct mesh with the kernel.
        /// </summary>
        /// <param name="kernel">The kernel</param>
        internal SurfaceMesh3(CGALKernel kernel)
        {
            Kernel = kernel.SurfaceMeshKernel3;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// The meshes kernel type.
        /// </summary>
        protected private SurfaceMeshKernel3 Kernel { get; private set; }

        public int VertexCount => Kernel.VertexCount(Ptr);

        public int HalfEdgeCount => Kernel.HalfEdgeCount(Ptr);

        public int EdgeCount => Kernel.EdgeCount(Ptr);

        public int FaceCount => Kernel.FaceCount(Ptr);

        public int AddVertex(Point3d point)
        {
            return Kernel.AddVertex(Ptr, point);
        }

        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        public int AddEdge(int v0, int v1)
        {
            return Kernel.AddEdge(Ptr, v0, v1);
        }

        public int AddFace(int v0, int v1, int v2)
        {
            return Kernel.AddFace(Ptr, v0, v1, v2);
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
