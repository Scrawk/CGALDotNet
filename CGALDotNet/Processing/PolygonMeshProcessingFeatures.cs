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

        /// <summary>
        /// Detects the edges that are considered to be sharp with respect to the given angle bound.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="feature_angle">Angle in deg gives the maximum angle between 
        /// the two normal vectors of adjacent triangles. For an edge of the input polygon mesh, 
        /// if the angle between the two normal vectors of its incident facets is bigger than 
        /// the given bound, then the edge is marked as being a feature edge.</param>
        /// <param name="featureEdges">The halfedge indices of the edges that count as sharp.</param>
        public void DetectSharpEdges(Polyhedron3<K> mesh, Degree feature_angle, List<int> featureEdges)
        {
            int num_edges = Kernel.DetectSharpEdges_PH(Ptr, mesh.Ptr, feature_angle.angle);

            GetFeatureEdges(MESH_TYPE.POLYHEDRON, mesh.Ptr, num_edges, featureEdges);
        }

        /// <summary>
        /// Detects the edges that are considered to be sharp with respect to the given angle bound.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="feature_angle">Angle in deg gives the maximum angle between 
        /// the two normal vectors of adjacent triangles. For an edge of the input polygon mesh, 
        /// if the angle between the two normal vectors of its incident facets is bigger than 
        /// the given bound, then the edge is marked as being a feature edge.</param>
        /// <param name="featureEdges">The halfedge indices of the edges that count as sharp.</param>
        public void DetectSharpEdges(SurfaceMesh3<K> mesh, Degree feature_angle, List<int> featureEdges)
        {
            int num_edges = Kernel.DetectSharpEdges_SM(Ptr, mesh.Ptr, feature_angle.angle);

            GetFeatureEdges(MESH_TYPE.SURFACE_MESH, mesh.Ptr, num_edges, featureEdges);
        }

        /// <summary>
        /// Detects the sharp edges of pmesh according to angle as the DetectSharpEdges function does. 
        /// The sharp edges are then used to define a segmentation of a mesh, that is done by computing 
        /// a surface patch id for each face.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="feature_angle">Angle in deg gives the maximum angle between 
        /// the two normal vectors of adjacent triangles. For an edge of the input polygon mesh, 
        /// if the angle between the two normal vectors of its incident facets is bigger than 
        /// the given bound, then the edge is marked as being a feature edge.</param>
        /// <param name="featureEdges">The halfedge indices of the edges that count as sharp.</param>
        /// <param name="featurePatches">The face indices for each patch found.</param>
        public void SharpEdgesSegmentation(SurfaceMesh3<K> mesh, Degree feature_angle, List<int> featureEdges, List<List<int>> featurePatches)
        {
            var count = Kernel.SharpEdgesSegmentation_SM(Ptr, mesh.Ptr, feature_angle.angle);

            int num_edges = count.first;
            int num_patches = count.second;

            GetFeatureEdges(MESH_TYPE.SURFACE_MESH, mesh.Ptr, num_edges, featureEdges);
            GetFeaturePatches(MESH_TYPE.SURFACE_MESH, mesh.Ptr, num_patches, featurePatches);
        }

        /// <summary>
        /// Detects the sharp edges of pmesh according to angle as the DetectSharpEdges function does. 
        /// The sharp edges are then used to define a segmentation of a mesh, that is done by computing 
        /// a surface patch id for each face.
        /// </summary>
        /// <param name="mesh">The mesh.</param>
        /// <param name="feature_angle">Angle in deg gives the maximum angle between 
        /// the two normal vectors of adjacent triangles. For an edge of the input polygon mesh, 
        /// if the angle between the two normal vectors of its incident facets is bigger than 
        /// the given bound, then the edge is marked as being a feature edge.</param>
        /// <param name="featurePatches">The face indices for each patch found.</param>
        public void SharpEdgesSegmentation(SurfaceMesh3<K> mesh, Degree feature_angle, List<List<int>> featurePatches)
        {
            var count = Kernel.SharpEdgesSegmentation_SM(Ptr, mesh.Ptr, feature_angle.angle);

            int num_patches = count.second;

            GetFeaturePatches(MESH_TYPE.SURFACE_MESH, mesh.Ptr, num_patches, featurePatches);
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
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="meshPtr"></param>
        /// <param name="num_edges"></param>
        /// <param name="featureEdges"></param>
        protected void GetFeatureEdges(MESH_TYPE type, IntPtr meshPtr, int num_edges, List<int> featureEdges)
        {
            if (num_edges == 0) return;
    
            if (type == MESH_TYPE.POLYHEDRON)
            {
                var indices = new int[num_edges];
                Kernel.GetSharpEdges_PH(Ptr, meshPtr, indices, num_edges);
                featureEdges.AddRange(indices);
            }
            else if (type == MESH_TYPE.SURFACE_MESH)
            {
                var indices = new int[num_edges];
                Kernel.GetSharpEdges_SM(Ptr, meshPtr, indices, num_edges);
                featureEdges.AddRange(indices);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="meshPtr"></param>
        /// <param name="num_patches"></param>
        /// <param name="featurePatches"></param>
        /// <exception cref="NotImplementedException"></exception>
        protected void GetFeaturePatches(MESH_TYPE type, IntPtr meshPtr, int num_patches, List<List<int>> featurePatches)
        {
            if (num_patches == 0) return;
 
            if (type == MESH_TYPE.POLYHEDRON)
            {
                throw new NotImplementedException();
            }
            else if (type == MESH_TYPE.SURFACE_MESH)
            {
                for (int i = 0; i < num_patches; i++)
                {
                    int num_faces = Kernel.GetPatchBufferFaceCount_SM(Ptr, i);
       
                    var faces = new List<int>();
                    for (int j = 0; j < num_faces; j++)
                    {
                        int index = Kernel.GetPatchBufferFaceIndex_SM(Ptr, i, j);
                        if (index == CGALGlobal.NULL_INDEX) continue;

                        faces.Add(index);
                    }

                    if(faces.Count > 0)
                        featurePatches.Add(faces);
                }

                Kernel.ClearPatchBuffer_SM(Ptr);
            }
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

