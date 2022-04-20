using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// The heat method is an algorithm that solves the single- or multiple-source shortest 
    /// path problem by returning an approximation of the geodesic distance for all vertices
    /// of a triangle mesh to the closest vertex in a given set of source vertices. 
    /// The geodesic distance between two vertices of a mesh is the distance when walking 
    /// on the surface, potentially through the interior of faces. Two vertices that are 
    /// close in 3D space may be far away on the surface.
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class HeatMethod<K> : HeatMethod where K : CGALKernel, new()
    {
        /// <summary>
        /// Create a static instance.
        /// </summary>
        public static readonly HeatMethod<K> Instance = new HeatMethod<K>();

        /// <summary>
        /// Create a new instance.
        /// </summary>
        public HeatMethod() : base(new K())
        {

        }

        /// <summary>
        /// Create a new instance from a existing pointer to a unmanaged object.
        /// </summary>
        /// <param name="ptr">The unmanaged objects pointer.</param>
        internal HeatMethod(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[HeatMethod<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Find the distances for each vertex in the mesh to the vertex at the provided index.
        /// </summary>
        /// <param name="mesh">The mesh containing the vertices.</param>
        /// <param name="index">The vertices index to find the distances to.</param>
        /// <param name="distances">The distances for each vertex in the mesh.</param>
        /// <param name="useIDT">Should the intrinsitic delaunay triangulation be used. 
        /// This will improve the results for meshes that have bad triangle quality.</param>
        /// <returns>The maximum distance value.</returns>
        public double EstimateGeodesicDistances(SurfaceMesh3<K> mesh, int index, List<double> distances, bool useIDT = true)
        {
            CheckIsValidTriangleException(mesh);

            int count = Kernel.EstimateGeodesicDistances_SM(Ptr, mesh.Ptr, index, useIDT);

            double max = GetDistances(count, distances);
            ClearDistances();

            return max;
        }

        /// <summary>
        /// Find the distances for each vertex in the mesh to the vertex at the provided index.
        /// </summary>
        /// <param name="mesh">The mesh containing the vertices.</param>
        /// <param name="index">The vertices index to find the distances to.</param>
        /// <param name="distances">The distances for each vertex in the mesh.
        /// This will improve the results for meshes that have bad triangle quality.</param>
        /// <returns>The maximum distance value.</returns>
        public double EstimateGeodesicDistances(Polyhedron3<K> mesh, int index, List<double> distances)
        {
            CheckIsValidTriangleException(mesh);

            int count = Kernel.EstimateGeodesicDistances_PH(Ptr, mesh.Ptr, index, false);

            double max = GetDistances(count, distances);
            ClearDistances();

            return max;
        }

    }


    public abstract class HeatMethod : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private HeatMethod()
        {

        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="kernel"></param>
        internal HeatMethod(CGALKernel kernel)
        {
            Kernel = kernel.HeatMethodKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// Create a new instance from a existing pointer to a unmanaged object.
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr">The unmanaged objects pointer.</param>
        internal HeatMethod(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.HeatMethodKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal HeatMethodKernel Kernel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="distances"></param>
        /// <returns></returns>
        protected double GetDistances(int count, List<double> distances)
        {
            double max = double.NegativeInfinity;
            for (int i = 0; i < count; i++)
            {
                var dist = GetDistance(i);

                if (dist > max)
                    max = dist;

                distances.Add(dist);
            }

            return max;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected double GetDistance(int index)
        {
            return Kernel.GetDistance(Ptr, index);
        }

        /// <summary>
        /// 
        /// </summary>
        protected void ClearDistances()
        {
            Kernel.ClearDistances(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

    }

}
