using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Meshing
{
    /*

    public struct SurfaceMesherParams
    {
        /// <summary>
        /// a lower bound on the minimum angle in degrees of the surface mesh facets.
        /// </summary>
        public double AngularBound;

        /// <summary>
        /// an upper bound on the radius of surface Delaunay balls. 
        /// A surface Delaunay ball is a ball circumscribing a facet, 
        /// centered on the surface and empty of vertices. 
        /// Such a ball exists for each facet of the current surface mesh. 
        /// Indeed the current surface mesh is the Delaunay triangulation of the 
        /// current sampling restricted to the surface which is just the set of 
        /// facets in the three dimensional Delaunay triangulation of the 
        /// sampling that have a Delaunay surface ball.
        /// </summary>
        public double RadiusBound;

        /// <summary>
        /// an upper bound on the center-center distances of the surface mesh facets. 
        /// The center-center distance of a surface mesh facet is the distance between 
        /// the facet circumcenter and the center of its surface Delaunay ball.
        /// </summary>
        public double DistanceBound;

        /// <summary>
        /// The default param.
        /// </summary>
        public static SurfaceMesherParams Default
        {
            get
            {
                var param = new SurfaceMesherParams();
                param.AngularBound = 30;
                param.RadiusBound = 0.1;
                param.DistanceBound = 0.1;

                return param;
            }
        }
    }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="indices"></param>
        /// <param name="bounds"></param>
        /// <param name="param"></param>
        public void Generate(List<Point3d> vertices, List<int> indices, Box2d bounds, SurfaceMesherParams param)
        {
            double radius = bounds.Size.Magnitude;
            Kernel.Generate(param.AngularBound, param.RadiusBound, param.DistanceBound, radius);

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
    */
}
