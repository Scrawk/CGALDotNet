using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polyhedra;
using CGALDotNet.Polylines;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonMeshProcessingFeatures<K> : PolygonMeshProcessingFeatures where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingFeatures<K> Instance = new PolygonMeshProcessingFeatures<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingFeatures() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingFeatures(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingFeatures<{0}>: ]", Kernel.KernelName);
        }

        public void DetectSharpEdges(Polyhedron3<EEK> mesh, Degree feature_angle, List<int> results)
        {
            int count = Kernel.DetectSharpEdges_PH(Ptr, mesh.Ptr, feature_angle.angle);
            if (count == 0) return;

            var indices = new int[count];
            Kernel.GetSharpEdges_PH(Ptr, mesh.Ptr, indices, count);
            results.AddRange(indices);
        }

        public void SharpEdgesSegmentation(SurfaceMesh3<K> mesh, Degree feature_angle)
        {
            var icount = Kernel.SharpEdgesSegmentation_PH(Ptr, mesh.Ptr, feature_angle.angle);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PolygonMeshProcessingFeatures : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingFeatures()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingFeatures(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMeshProcessingFeaturesKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingFeatures(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonMeshProcessingFeaturesKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingFeaturesKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

