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
    public sealed class MeshProcessingConnections<K> : MeshProcessingConnections where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly MeshProcessingConnections<K> Instance = new MeshProcessingConnections<K>();

        /// <summary>
        /// 
        /// </summary>
        public MeshProcessingConnections() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MeshProcessingConnections(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshProcessingConnections<{0}>: ]", Kernel.Name);
        }

        /*
        /// <summary>
        /// Returns the number of unconnect components in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <returns>Returns the number of unconnect components in the mesh.</returns>
        public int UnconnectedComponents(Polyhedron3<K> mesh)
        {
            CheckIsValidException(mesh);
            return Kernel.ConnectedComponents_PH(mesh.Ptr);
        }
        */

        /// <summary>
        /// Returns the number of unconnect components in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <returns>Returns the number of unconnect components in the mesh.</returns>
        public int UnconnectedComponents(SurfaceMesh3<K> mesh)
        {
            CheckIsValidException(mesh);
            return Kernel.ConnectedComponents_SM(mesh.Ptr);
        }

        /// <summary>
        /// Returns a list of face indices that are part of the same component as the provided face index.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="faceIndex">The faces index in the mesh.</param>
        /// <param name="results">A list of face indices that are part of the same component as the provided face index.</param>
        public void ConnectedFaces(Polyhedron3<K> mesh, int faceIndex, List<int> results)
        {
            CheckIsValidException(mesh);

            int count = Kernel.ConnectedComponent_PH(Ptr, mesh.Ptr, faceIndex);
            if (count == 0) return;

            var indices = new int[count];
            Kernel.GetConnectedComponentsFaceIndex_PH(Ptr, mesh.Ptr, indices, count);
            results.AddRange(indices);
        }

        /// <summary>
        /// Returns a list of face indices that are part of the same component as the provided face index.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="faceIndex">The faces index in the mesh.</param>
        /// <param name="results">A list of face indices that are part of the same component as the provided face index.</param>
        public void ConnectedFaces(SurfaceMesh3<K> mesh, int faceIndex, List<int> results)
        {
            CheckIsValidException(mesh);

            int count = Kernel.ConnectedComponent_SM(Ptr, mesh.Ptr, faceIndex);
            if (count == 0) return;

            var indices = new int[count];
            Kernel.GetConnectedComponentsFaceIndex_SM(Ptr, mesh.Ptr, indices, count);
            results.AddRange(indices);
        }

        /// <summary>
        /// Split each component in the mesh into individual meshes.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="results">The split meshes.</param>
        public void SplitUnconnectedComponents(Polyhedron3<K> mesh, List<Polyhedron3<K>> results)
        {
            CheckIsValidException(mesh);

            int count = Kernel.SplitConnectedComponents_PH(Ptr, mesh.Ptr);
            if (count == 0) return;

            var ptrs = new IntPtr[count];
            Kernel.GetSplitConnectedComponents_PH(Ptr, ptrs, count);

            for (int i = 0; i < count; i++)
                results.Add( new Polyhedron3<K>(ptrs[i]));
        }

        /// <summary>
        /// Split each component in the mesh into individual meshes.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="results">The split meshes.</param>
        public void SplitUnconnectedComponents(SurfaceMesh3<K> mesh, List<SurfaceMesh3<K>> results)
        {
            CheckIsValidException(mesh);

            int count = Kernel.SplitConnectedComponents_SM(Ptr, mesh.Ptr);
            if (count == 0) return;

            var ptrs = new IntPtr[count];
            Kernel.GetSplitConnectedComponents_SM(Ptr, ptrs, count);

            for (int i = 0; i < count; i++)
                results.Add(new SurfaceMesh3<K>(ptrs[i]));
        }

        /// <summary>
        /// Removes connected components with less than a given number of faces.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="threshold_value">The number of faces a component must have so that it is kept</param>
        /// <returns>The number of components removed.</returns>
        public int KeepLargeComponents(Polyhedron3<K> mesh, int threshold_value)
        {
            CheckIsValidException(mesh);
            return Kernel.KeepLargeConnectedComponents_PH(mesh.Ptr, threshold_value);
        }

        /// <summary>
        /// Removes connected components with less than a given number of faces.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="threshold_value">The number of faces a component must have so that it is kept</param>
        /// <returns>The number of components removed.</returns>
        public int KeepLargeComponents(SurfaceMesh3<K> mesh, int threshold_value)
        {
            CheckIsValidException(mesh);
            return Kernel.KeepLargeConnectedComponents_SM(mesh.Ptr, threshold_value);
        }

        /// <summary>
        /// Removes the small connected components and all isolated vertices.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="num_components_to_keep">Keep this number of the largest connected components.</param>
        /// <returns>The number of components removed.</returns>
        public int KeepLargestComponents(Polyhedron3<K> mesh, int num_components_to_keep)
        {
            CheckIsValidException(mesh);
            return Kernel.KeepLargestConnectedComponents_PH(mesh.Ptr, num_components_to_keep);
        }

        /// <summary>
        /// Removes the small connected components and all isolated vertices.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="num_components_to_keep">Keep this number of the largest connected components.</param>
        /// <returns>The number of components removed.</returns>
        public int KeepLargestComponents(SurfaceMesh3<K> mesh, int num_components_to_keep)
        {
            CheckIsValidException(mesh);
            return Kernel.KeepLargestConnectedComponents_SM(mesh.Ptr, num_components_to_keep);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MeshProcessingConnections : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private MeshProcessingConnections()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal MeshProcessingConnections(CGALKernel kernel)
        {
            Kernel = kernel.MeshProcessingConnectionsKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal MeshProcessingConnections(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.MeshProcessingConnectionsKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal MeshProcessingConnectionsKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

