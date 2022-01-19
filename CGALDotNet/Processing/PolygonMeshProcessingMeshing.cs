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
    public sealed class PolygonMeshProcessingMeshing<K> : PolygonMeshProcessingMeshing where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingMeshing<K> Instance = new PolygonMeshProcessingMeshing<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingMeshing() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingMeshing(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingMeshing<{0}>: ]", Kernel.KernelName);
        }


        /// <summary>
        /// This function extrudes the open surface mesh input and puts the result in output.
        /// The mesh generated is a closed surface mesh with a bottom and top part, 
        /// both having the same graph combinatorics as input 
        /// (except that the orientation of the faces of the bottom part is reversed). 
        /// The bottom and the top parts are connected by a triangle strip between boundary cycles.
        /// The coordinates of the points associated to the vertices of the bottom and top part 
        /// are first initialized to the same value as the corresponding vertices of input. 
        /// Then for each vertex, a call to bot and top is done for the vertices of the 
        /// bottom part and the top part, respectively.
        /// Result may be self intersecting.
        /// </summary>
        /// <param name="poly"></param>
        //public void Extrude(Polyhedron3<K> poly)
        //{
        //    Kernel.Extrude(poly.Ptr);
        //}

        /// <summary>
        /// fairs a region on a triangle mesh.
        /// The points of the selected vertices are relocated to yield an as-smooth-as-possible surface patch,
        /// based on solving a linear bi-Laplacian system with boundary constraints, described in [3].
        /// The optional parameter fairing_continuity gives the ability to control the tangential continuity C n of the output mesh.
        /// The region described by vertices might contain multiple disconnected components.
        /// Note that the mesh connectivity is not altered in any way, only vertex locations get updated.
        /// Fairing might fail if fixed vertices, which are used as boundary conditions, 
        /// do not suffice to solve constructed linear system.
        /// Note that if the vertex range to which fairing is applied contains all the vertices of the triangle mesh, 
        /// fairing does not fail, but the mesh gets shrinked to CGAL::ORIGIN.
        /// <summary>
        /// <returns></returns>
        //public bool Fair(Polyhedron3<K> poly)
        //{
        //    return Kernel.Fair(poly.Ptr);
        //}

        /// <summary>
        /// Refines a triangle mesh
        /// </summary>
        /// <param name="poly">A valid triangle mesh.</param>
        /// <param name="density_control_factor">a factor to control density of the output mesh, 
        /// where larger values lead to denser refinements. Defalus to sqrt of 2.</param>
        /// <returns>The number of new vertices.</returns>
        public int Refine(Polyhedron3<K> poly, double density_control_factor = CGALGlobal.SQRT2)
        {
            if (density_control_factor <= 0)
                return 0;

            if (!CheckIsValidTriangle(poly)) return 0;

            poly.SetIsUpdatedToFalse();
            return Kernel.Refine(poly.Ptr, density_control_factor);
        }

        /// <summary>
        /// Remeshes a triangulated region of a polygon mesh.
        /// This operation sequentially performs edge splits, edge collapses, edge flips, 
        /// tangential relaxation and projection to the initial surface to generate 
        /// a smooth mesh with a prescribed edge length.
        /// </summary>
        /// <param name="poly">A valid triangle mesh.</param>
        /// <param name="iterations"></param>
        /// <param name="target_edge_length">the edge length that is targeted in the remeshed patch. 
        /// If 0 is passed then only the edge-flip, tangential relaxation, and projection steps will be done.</param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool IsotropicRemeshing(Polyhedron3<K> poly, int iterations, double target_edge_length)
        {
            if (!CheckIsValidTriangle(poly)) 
                return false;

            if (target_edge_length < 0)
                target_edge_length = 0;

            poly.SetIsUpdatedToFalse();
            Kernel.IsotropicRemeshing(poly.Ptr, iterations, target_edge_length);
            return true;
        }

        /// <summary>
        /// randomly perturbs the locations of vertices of a triangulated surface mesh.
        /// By default, the vertices are re-projected onto the input surface after 
        /// perturbation.Note that no geometric checks are done after the perturbation 
        /// (face orientation might become incorrect and self-intersections might be introduced).
        /// </summary>
        /// <param name="poly">A valid polygon mesh.</param>
        /// <param name="perturbation_max_size">The maximun amount a vertex will be pertured. Must be greater tha 0.</param>
        //public void RandomPerturbation(Polyhedron3<K> poly, double perturbation_max_size)
        //{
        //    if (!CheckIsValid(poly)) return;
        //
        //   if (perturbation_max_size <= 0)
        //       return;
        //
        //    poly.SetIsUpdatedToFalse();
        //   Kernel.RandomPerturbation(poly.Ptr, perturbation_max_size);
        //}

        /// <summary>
        /// Smooths a triangulatedpolygon mesh.
        /// This function attempts to make the triangle angle and area distributions as uniform 
        /// as possible by moving(non-constrained) vertices.
        /// Angle-based smoothing does not change the combinatorial information of the mesh.
        /// Area-based smoothing might change the combinatorial information, unless specified otherwise.
        /// It is also possible to make the smoothing algorithm "safer" by rejecting moves that, 
        /// when applied, would worsen the quality of the mesh, e.g.that would decrease the value
        /// of the smallest angle around a vertex or create self-intersections.
        /// Optionally, the points are reprojected after each iteration.
        /// </summary>
        /// <param name="poly">A valid triangle mesh.</param>
        //public void SmoothMesh(Polyhedron3<K> poly)
        //{
        //    if (!CheckIsValidTriangle(poly)) return;
        //    Kernel.SmoothMesh(poly.Ptr);
        //}

        /// <summary>
        /// smooths the overall shape of the mesh by using the mean curvature flow.
        /// The effect depends on the curvature of each area and on a time step which 
        /// represents the amount by which vertices are allowed to move.
        /// The result conformally maps the initial surface to a sphere.
        /// </summary>
        /// <param name="poly">A valid triangle mesh.</param>
        //public void SmoothShape(Polyhedron3<K> poly)
        //{
        //    if (!CheckIsValidTriangle(poly)) return;
        //    Kernel.SmoothShape(poly.Ptr);
        //}

        /// <summary>
        /// splits the edges listed in edges into sub-edges that are not longer than the given threshold max_length.
        /// Note this function is useful to split constrained edges before calling isotropic_remeshing() with protection
        /// of constraints activated (to match the constrained edge length required by the remeshing algorithm to be guaranteed to terminate)
        /// </summary>
        /// <param name="poly">A polygon mesh.</param>
        /// <param name="target_edge_length">The edge length above which an edge from edges is split into to sub-edges</param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool SplitLongEdges(Polyhedron3<K> poly, double target_edge_length)
        {
            if (!CheckIsValid(poly) || target_edge_length <= 0) 
                return false;

            poly.SetIsUpdatedToFalse();
            Kernel.SplitLongEdges(poly.Ptr, target_edge_length);
            return true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PolygonMeshProcessingMeshing : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingMeshing()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingMeshing(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMeshProcessingMeshingKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingMeshing(CGALKernel kernel, IntPtr ptr)
        {
            Kernel = kernel.PolygonMeshProcessingMeshingKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingMeshingKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

