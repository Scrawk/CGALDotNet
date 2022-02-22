using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNet.Polyhedra;
using CGALDotNet.Polylines;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class MeshProcessingFeatures<K> : MeshProcessingFeatures where K : CGALKernel, new()
    {

        /// <summary>
        /// 
        /// </summary>
        public static readonly MeshProcessingFeatures<K> Instance = new MeshProcessingFeatures<K>();

        /// <summary>
        /// 
        /// </summary>
        public MeshProcessingFeatures() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MeshProcessingFeatures(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// Detects the edges that are considered to be sharp with respect to the given angle bound.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="feature_angle">Angle in deg gives the maximum angle between 
        /// the two normal vectors of adjacent triangles. For an edge of the input polygon mesh, 
        /// if the angle between the two normal vectors of its incident facets is bigger than 
        /// the given bound, then the edge is marked as being a feature edge.</param>
        /// <param name="featureEdges">The halfedge indices of the edges that count as sharp.</param>
        public void DetectSharpEdges(Polyhedron3<K> mesh, Degree feature_angle, List<int> featureEdges)
        {
            CheckIsValidException(mesh);
            int num_edges = Kernel.DetectSharpEdges_PH(Ptr, mesh.Ptr, feature_angle.angle);

            GetFeatureEdges(MESH_TYPE.POLYHEDRON, mesh.Ptr, num_edges, featureEdges);
        }

        /// <summary>
        /// Detects the edges that are considered to be sharp with respect to the given angle bound.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="feature_angle">Angle in deg gives the maximum angle between 
        /// the two normal vectors of adjacent triangles. For an edge of the input polygon mesh, 
        /// if the angle between the two normal vectors of its incident facets is bigger than 
        /// the given bound, then the edge is marked as being a feature edge.</param>
        /// <param name="featureEdges">The halfedge indices of the edges that count as sharp.</param>
        public void DetectSharpEdges(SurfaceMesh3<K> mesh, Degree feature_angle, List<int> featureEdges)
        {
            CheckIsValidException(mesh);
            int num_edges = Kernel.DetectSharpEdges_SM(Ptr, mesh.Ptr, feature_angle.angle);

            GetFeatureEdges(MESH_TYPE.SURFACE_MESH, mesh.Ptr, num_edges, featureEdges);
        }

        /// <summary>
        /// Find the min, max and average edge lengths in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <returns>The min, max and average edge lengths in the mesh.</returns>
        public MinMaxAvg EdgeLengthMinMaxAvg(Polyhedron3<K> mesh)
        {
            CheckIsValidException(mesh);
            return Kernel.EdgeLengthMinMaxAvg_PH(mesh.Ptr);
        }

        /// <summary>
        /// Find the min, max and average edge lengths in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <returns>The min, max and average edge lengths in the mesh.</returns>
        public MinMaxAvg EdgeLengthMinMaxAvg(SurfaceMesh3<K> mesh)
        {
            CheckIsValidException(mesh);
            return Kernel.EdgeLengthMinMaxAvg_SM(mesh.Ptr);
        }

        /// <summary>
        /// Find the min, max and average face areas in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <returns>The min, max and average face areas in the mesh.</returns>
        public MinMaxAvg FaceAreaMinMaxAvg(Polyhedron3<K> mesh)
        {
            CheckIsValidException(mesh);
            return Kernel.FaceAreaMinMaxAvg_PH(mesh.Ptr);
        }

        /// <summary>
        /// Find the min, max and average face areas in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <returns>The min, max and average face areas in the mesh.</returns>
        public MinMaxAvg FaceAreaMinMaxAvg(SurfaceMesh3<K> mesh)
        {
            CheckIsValidException(mesh);
            return Kernel.FaceAreaMinMaxAvg_SM(mesh.Ptr);
        }

        /// <summary>
        /// Detects the sharp edges of mesh according to angle as the DetectSharpEdges function does. 
        /// The sharp edges are then used to define a segmentation of a mesh, that is done by computing 
        /// a surface patch id for each face.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="feature_angle">Angle in deg gives the maximum angle between 
        /// the two normal vectors of adjacent triangles. For an edge of the input polygon mesh, 
        /// if the angle between the two normal vectors of its incident facets is bigger than 
        /// the given bound, then the edge is marked as being a feature edge.</param>
        /// <param name="featureEdges">The halfedge indices of the edges that count as sharp.</param>
        /// <param name="featurePatches">The face indices for each patch found.</param>
        public void SharpEdgesSegmentation(SurfaceMesh3<K> mesh, Degree feature_angle, List<int> featureEdges, List<List<int>> featurePatches)
        {
            CheckIsValidException(mesh);
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
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="feature_angle">Angle in deg gives the maximum angle between 
        /// the two normal vectors of adjacent triangles. For an edge of the input polygon mesh, 
        /// if the angle between the two normal vectors of its incident facets is bigger than 
        /// the given bound, then the edge is marked as being a feature edge.</param>
        /// <param name="featurePatches">The face indices for each patch found.</param>
        public void SharpEdgesSegmentation(SurfaceMesh3<K> mesh, Degree feature_angle, List<List<int>> featurePatches)
        {
            CheckIsValidException(mesh);
            var count = Kernel.SharpEdgesSegmentation_SM(Ptr, mesh.Ptr, feature_angle.angle);

            int num_patches = count.second;

            GetFeaturePatches(MESH_TYPE.SURFACE_MESH, mesh.Ptr, num_patches, featurePatches);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshProcessingFeatures<{0}>: ]", Kernel.Name);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MeshProcessingFeatures : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal MeshProcessingFeatures(CGALKernel kernel)
        {
            Kernel = kernel.MeshProcessingFeaturesKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal MeshProcessingFeatures(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.MeshProcessingFeaturesKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        private MeshProcessingFeatures()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        internal MeshProcessingFeaturesKernel Kernel { get; private set; }

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

