using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Meshing
{

    /// <summary>
    /// The generic surface mesher class.
    /// </summary>
    /// <typeparam name="K">The kernel type</typeparam>
    public sealed class SurfaceMesher3<K> : SurfaceMesher3 where K : CGALKernel, new()
    {
        /// <summary>
        /// The static instance.
        /// </summary>
        public static readonly SurfaceMesher3<K> Instance = new SurfaceMesher3<K>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceMesher3() : base(new K())
        {

        }
    }

    /// <summary>
    /// The surface mesher abstract base class.
    /// </summary>
    public abstract class SurfaceMesher3 : CGALObject
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        private SurfaceMesher3()
        {

        }

        /// <summary>
        /// Construct mesher with the kernel.
        /// </summary>
        /// <param name="kernel">The kernel</param>
        internal SurfaceMesher3(CGALKernel kernel)
        {
            Kernel = kernel.SurfaceMesherKernel3;
            //Ptr = Kernel.Create();
        }

        /// <summary>
        /// The meshes kernel type.
        /// </summary>
        protected private SurfaceMesherKernel3 Kernel { get; private set; }

        public void Generate(List<Point3d> vertices, List<int> indices)
        {
            Kernel.Generate();

            int count = VertexCount();
            for (int i = 0; i < count; i++)
            {
                vertices.Add(GetPoint(i));
            }

            count = TriangleCount();
            for (int i = 0; i < count; i++)
            {
                var tri = GetTriangle(i);
                indices.Add(tri.A);
                indices.Add(tri.B);
                indices.Add(tri.C);
            }

            ClearMesh();
        }

        private int VertexCount()
        {
            return Kernel.VertexCount();
        }

        private int TriangleCount()
        {
            return Kernel.TriangleCount();
        }

        private void ClearMesh()
        {
            Kernel.ClearMesh();
        }

        private Point3d GetPoint(int i)
        {
            return Kernel.GetPoint(i);
        }

        private TriangleIndex GetTriangle(int i)
        {
            return Kernel.GetTriangle(i);
        }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            //Kernel.Release(Ptr);
        }
    }
}
