using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonMeshProcessingConnections<K> : PolygonMeshProcessingConnections where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingConnections<K> Instance = new PolygonMeshProcessingConnections<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingConnections() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingConnections(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingConnections<{0}>: ]", Kernel.KernelName);
        }

        public int UnconnectedComponents(Polyhedron3<K> mesh)
        {
            return Kernel.ConnectedComponents_PH(mesh.Ptr);
        }

        public int UnconnectedComponents(SurfaceMesh3<K> mesh)
        {
            return Kernel.ConnectedComponents_SM(mesh.Ptr);
        }

        public int ConnectedFaces(Polyhedron3<K> mesh, int faceIndex)
        {
            return Kernel.ConnectedComponent_PH(mesh.Ptr, faceIndex);
        }

        public int ConnectedFaces(SurfaceMesh3<K> mesh, int faceIndex)
        {
            return Kernel.ConnectedComponent_SM(mesh.Ptr, faceIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="results"></param>
        public void SplitUnconnectedComponents(Polyhedron3<K> mesh, List<Polyhedron3<K>> results)
        {
            int count = Kernel.SplitConnectedComponents_PH(Ptr, mesh.Ptr);
            if (count == 0) return;

            var ptrs = new IntPtr[count];
            Kernel.GetSplitConnectedComponents_PH(Ptr, ptrs, count);

            for (int i = 0; i < count; i++)
                results.Add( new Polyhedron3<K>(ptrs[i]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="results"></param>
        public void SplitUnconnectedComponents(SurfaceMesh3<K> mesh, List<SurfaceMesh3<K>> results)
        {
            int count = Kernel.SplitConnectedComponents_SM(Ptr, mesh.Ptr);
            if (count == 0) return;

            var ptrs = new IntPtr[count];
            Kernel.GetSplitConnectedComponents_SM(Ptr, ptrs, count);

            for (int i = 0; i < count; i++)
                results.Add(new SurfaceMesh3<K>(ptrs[i]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="num_components_to_keep"></param>
        /// <returns></returns>
        public int KeepLargestComponents(Polyhedron3<K> mesh, int num_components_to_keep)
        {
            return Kernel.KeepLargestConnectedComponents_PH(mesh.Ptr, num_components_to_keep);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="num_components_to_keep"></param>
        /// <returns></returns>
        public int KeepLargestComponents(SurfaceMesh3<K> mesh, int num_components_to_keep)
        {
            return Kernel.KeepLargestConnectedComponents_SM(mesh.Ptr, num_components_to_keep);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PolygonMeshProcessingConnections : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingConnections()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingConnections(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMeshProcessingConnectionsKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingConnections(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonMeshProcessingConnectionsKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingConnectionsKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

