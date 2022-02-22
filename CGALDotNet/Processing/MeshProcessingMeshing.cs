using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class MeshProcessingMeshing<K> : MeshProcessingMeshing where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly MeshProcessingMeshing<K> Instance = new MeshProcessingMeshing<K>();

        /// <summary>
        /// 
        /// </summary>
        public MeshProcessingMeshing() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MeshProcessingMeshing(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshProcessingMeshing<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Fills output with a closed mesh bounding the volume swept by input when translating its vertices by dir.
        /// The mesh is oriented so that the faces corresponding to input in output have the same orientation.
        /// </summary>
        /// <param name="mesh">The a valid closed mesh.</param>
        /// <param name="dir">The direction vector.</param>
        /// <returns>The extuded mesh.</returns>
        public Polyhedron3<K> Extrude(Polyhedron3<K> mesh, Vector3d dir)
        {
            CheckIsValidClosedException(mesh);

            var ptr = Kernel.Extrude_PH(mesh.Ptr, dir);
            return new Polyhedron3<K>(ptr);
        }

        /// <summary>
        /// Fills output with a closed mesh bounding the volume swept by input when translating its vertices by dir.
        /// The mesh is oriented so that the faces corresponding to input in output have the same orientation.
        /// </summary>
        /// <param name="mesh">The a valid closed mesh.</param>
        /// <param name="dir">The direction vector.</param>
        /// <returns>The extuded mesh.</returns>
        public SurfaceMesh3<K> Extrude(SurfaceMesh3<K> mesh, Vector3d dir)
        {
            CheckIsValidClosedException(mesh);

            var ptr = Kernel.Extrude_SM(mesh.Ptr, dir);
            return new SurfaceMesh3<K>(ptr);
        }

        /// <summary>
        /// Fairs a region on a triangle mesh based on a ring of k vertices from the index vertex.
        /// The points of the selected vertices are relocated to yield an as-smooth-as-possible surface patch,
        /// based on solving a linear bi-Laplacian system with boundary constraints
        /// The region described by vertices might contain multiple disconnected components.
        /// Note that the mesh connectivity is not altered in any way, only vertex locations get updated.
        /// Fairing might fail if fixed vertices, which are used as boundary conditions, 
        /// do not suffice to solve constructed linear system.
        /// Note that if the vertex range to which fairing is applied contains all the vertices of the triangle mesh, 
        /// fairing does not fail, but the mesh gets shrinked to the origin.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="index">The vertex index in the mesh to start hthe k ring region from.</param>
        /// <param name="k_ring">The number of vertics to expand the region to.</param>
        /// <returns>If the fairing was successfully run.</returns>
        public bool Fair(Polyhedron3<K> mesh, int index, int k_ring)
        {
            CheckIsValidTriangle(mesh);

            var i = Kernel.Fair_PH(mesh.Ptr, index, k_ring);

            bool successful = i.first != 0;
            //int region_size = i.second;

            return successful;
        }

        /*

        /// <summary>
        /// Fairs a region on a triangle mesh based on a ring of k vertices from the index vertex.
        /// The points of the selected vertices are relocated to yield an as-smooth-as-possible surface patch,
        /// based on solving a linear bi-Laplacian system with boundary constraints
        /// The region described by vertices might contain multiple disconnected components.
        /// Note that the mesh connectivity is not altered in any way, only vertex locations get updated.
        /// Fairing might fail if fixed vertices, which are used as boundary conditions, 
        /// do not suffice to solve constructed linear system.
        /// Note that if the vertex range to which fairing is applied contains all the vertices of the triangle mesh, 
        /// fairing does not fail, but the mesh gets shrinked to the origin.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="index">The vertex index in the mesh to start hthe k ring region from.</param>
        /// <param name="k_ring">The number of vertics to expand the region to.</param>
        /// <returns>If the fairing was successfully run.</returns>
        public bool Fair(SurfaceMesh3<K> mesh, int index, int k_ring)
        {
            CheckIsValidTriangle(mesh);
        
            //TODO - need to implemt kring
            var i = Kernel.Fair_SM(mesh.Ptr, index, k_ring);
        
            bool successful = i.first != 0;
            //int region_size = i.second;
        
            return successful;
        }
        */

        /// <summary>
        /// Refines a triangle mesh
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="density_control_factor">a factor to control density of the output mesh, 
        /// where larger values lead to denser refinements. Defalus to sqrt of 2.</param>
        /// <returns>The number of new vertices added.</returns>
        public int Refine(Polyhedron3<K> mesh, double density_control_factor = MathUtil.SQRT2_64)
        {
            if (density_control_factor <= 0)
                return 0;

            CheckIsValidTriangleException(mesh);

            mesh.SetIsUpdatedToFalse();
            var count = Kernel.Refine_PH(mesh.Ptr, density_control_factor);

            int new_vertices = count.first;
            int new_faces = count.second;

            return new_vertices;
        }

        /// <summary>
        /// Refines a triangle mesh
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="density_control_factor">a factor to control density of the output mesh, 
        /// where larger values lead to denser refinements. Defalus to sqrt of 2.</param>
        /// <returns>The number of new vertices added.</returns>
        public int Refine(SurfaceMesh3<K> mesh, double density_control_factor = MathUtil.SQRT2_64)
        {
            if (density_control_factor <= 0)
                return 0;

            CheckIsValidTriangleException(mesh);

            mesh.SetIsUpdatedToFalse();
            var count = Kernel.Refine_SM(mesh.Ptr, density_control_factor);

            int new_vertices = count.first;
            int new_faces = count.second;

            return new_vertices;
        }

        /// <summary>
        /// Remeshes a triangulated region of a meshgon mesh.
        /// This operation sequentially performs edge splits, edge collapses, edge flips, 
        /// tangential relaxation and projection to the initial surface to generate 
        /// a smooth mesh with a prescribed edge length.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="iterations">The number of times to perform the remeshing.</param>
        /// <param name="target_edge_length">the edge length that is targeted in the remeshed patch. 
        /// If 0 is passed then only the edge-flip, tangential relaxation, and projection steps will be done.</param>
        /// <returns>The number of new vertices added.</returns>
        public int IsotropicRemeshing(Polyhedron3<K> mesh, double target_edge_length, int iterations = 1)
        {
            CheckIsValidTriangleException(mesh);

            if (target_edge_length < 0)
                target_edge_length = 0;

            mesh.SetIsUpdatedToFalse();
            return Kernel.IsotropicRemeshing_PH(mesh.Ptr, iterations, target_edge_length);
        }

        /// <summary>
        /// Remeshes a triangulated region of a meshgon mesh.
        /// This operation sequentially performs edge splits, edge collapses, edge flips, 
        /// tangential relaxation and projection to the initial surface to generate 
        /// a smooth mesh with a prescribed edge length.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="iterations">The number of times to perform the remeshing.</param>
        /// <param name="target_edge_length">the edge length that is targeted in the remeshed patch. 
        /// If 0 is passed then only the edge-flip, tangential relaxation, and projection steps will be done.</param>
        /// <returns>The number of new vertices added.</returns>
        public int IsotropicRemeshing(SurfaceMesh3<K> mesh, double target_edge_length, int iterations = 1)
        {
            CheckIsValidTriangleException(mesh);

            if (target_edge_length < 0)
                target_edge_length = 0;

            mesh.SetIsUpdatedToFalse();
            return Kernel.IsotropicRemeshing_SM(mesh.Ptr, iterations, target_edge_length);
        }

        /// <summary>
        /// randomly perturbs the locations of vertices of a triangulated surface mesh.
        /// By default, the vertices are re-projected onto the input surface after 
        /// perturbation.Note that no geometric checks are done after the perturbation 
        /// (face orientation might become incorrect and self-intersections might be introduced).
        /// </summary>
        /// <param name="mesh">A mesh.</param>
        /// <param name="perturbation_max_size">The maximun amount a vertex will be pertured. Must be greater tha 0.</param>
        public void RandomPerturbation(Polyhedron3<K> mesh, double perturbation_max_size)
        {
           if (perturbation_max_size <= 0)
               return;
        
            mesh.SetIsUpdatedToFalse();
           Kernel.RandomPerturbation_PH(mesh.Ptr, perturbation_max_size);
        }

        /// <summary>
        /// randomly perturbs the locations of vertices of a triangulated surface mesh.
        /// By default, the vertices are re-projected onto the input surface after 
        /// perturbation.Note that no geometric checks are done after the perturbation 
        /// (face orientation might become incorrect and self-intersections might be introduced).
        /// </summary>
        /// <param name="mesh">A mesh.</param>
        /// <param name="perturbation_max_size">The maximun amount a vertex will be pertured. Must be greater tha 0.</param>
        public void RandomPerturbation(SurfaceMesh3<K> mesh, double perturbation_max_size)
        {
            if (perturbation_max_size <= 0)
                return;

            mesh.SetIsUpdatedToFalse();
            Kernel.RandomPerturbation_SM(mesh.Ptr, perturbation_max_size);
        }

        /*

        /// <summary>
        /// Smooths a triangulated mesh.
        /// This function attempts to make the triangle angle and area distributions as uniform 
        /// as possible by moving(non-constrained) vertices.
        /// Angle-based smoothing does not change the combinatorial information of the mesh.
        /// Area-based smoothing might change the combinatorial information, unless specified otherwise.
        /// It is also possible to make the smoothing algorithm "safer" by rejecting moves that, 
        /// when applied, would worsen the quality of the mesh, e.g.that would decrease the value
        /// of the smallest angle around a vertex or create self-intersections.
        /// Optionally, the points are reprojected after each iteration.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="featureAngle">The edge angle that counts a feature and wont be smoothed.</param>
        /// <param name="iterations">The number of iterations for the sequence of the smoothing iterations performed</param>
        public void SmoothMeshByAngle(Polyhedron3<K> mesh, Degree featureAngle, int iterations = 1)
        {
            CheckIsValidTriangleException(mesh);
            if (featureAngle.angle <= 0 || iterations < 0) return;
        
            Kernel.SmoothMesh_PH(mesh.Ptr, featureAngle.angle, iterations);
        }
        */

        /// <summary>
        /// Smooths a triangulated mesh.
        /// This function attempts to make the triangle angle and area distributions as uniform 
        /// as possible by moving(non-constrained) vertices.
        /// Angle-based smoothing does not change the combinatorial information of the mesh.
        /// Area-based smoothing might change the combinatorial information, unless specified otherwise.
        /// It is also possible to make the smoothing algorithm "safer" by rejecting moves that, 
        /// when applied, would worsen the quality of the mesh, e.g.that would decrease the value
        /// of the smallest angle around a vertex or create self-intersections.
        /// Optionally, the points are reprojected after each iteration.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="featureAngle">The edge angle that counts a feature and wont be smoothed.</param>
        /// <param name="iterations">The number of iterations for the sequence of the smoothing iterations performed</param>
        public void SmoothMeshByAngle(SurfaceMesh3<K> mesh, Degree featureAngle, int iterations = 1)
        {
            CheckIsValidTriangleException(mesh);
            if (featureAngle.angle <= 0 || iterations < 0) return;

            Kernel.SmoothMesh_SM(mesh.Ptr, featureAngle.angle, iterations);
        }

        /*
        /// <summary>
        /// smooths the overall shape of the mesh by using the mean curvature flow.
        /// The effect depends on the curvature of each area and on a time step which 
        /// represents the amount by which vertices are allowed to move.
        /// The result conformally maps the initial surface to a sphere.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="timeStep">A time step that corresponds to the speed by which the surface is smoothed. 
        /// A larger time step results in faster convergence but details may be distorted to have a larger 
        /// extent compared to more iterations with a smaller step. Typical values scale in the interval (1e-6, 1].</param>
        /// <param name="iterations">The number of iterations for the sequence of the smoothing iterations performed.</param>
        public void SmoothShape(Polyhedron3<K> mesh, double timeStep = 0.0001, int iterations = 1)
        {
            CheckIsValidTriangleException(mesh);
            if (timeStep <= 0 || iterations < 0) return;
        
            Kernel.SmoothShape_PH(mesh.Ptr, timeStep, iterations);
        }
        */

        /*
        /// <summary>
        /// smooths the overall shape of the mesh by using the mean curvature flow.
        /// The effect depends on the curvature of each area and on a time step which 
        /// represents the amount by which vertices are allowed to move.
        /// The result conformally maps the initial surface to a sphere.
        /// </summary>
        /// <param name="mesh">A valid triangle mesh.</param>
        /// <param name="timeStep">A time step that corresponds to the speed by which the surface is smoothed. 
        /// A larger time step results in faster convergence but details may be distorted to have a larger 
        /// extent compared to more iterations with a smaller step. Typical values scale in the interval (1e-6, 1].</param>
        /// <param name="iterations">The number of iterations for the sequence of the smoothing iterations performed.</param>
        public void SmoothShape(SurfaceMesh3<K> mesh, double timeStep = 0.0001, int iterations = 1)
        {
            CheckIsValidTriangleException(mesh);
            if (timeStep <= 0 || iterations < 0) return;
        
            Kernel.SmoothShape_SM(mesh.Ptr, timeStep, iterations);
        }
        */

        /// <summary>
        /// splits the edges listed in edges into sub-edges that are not longer than the given threshold max_length.
        /// Note this function is useful to split constrained edges before calling isotropic_remeshing() with protection
        /// of constraints activated (to match the constrained edge length required by the remeshing algorithm to be guaranteed to terminate)
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="target_edge_length">The edge length above which an edge from edges is split into to sub-edges</param>
        /// <returns>The number of new edges added to the mesh.</returns>
        public int SplitLongEdges(Polyhedron3<K> mesh, double target_edge_length)
        {
            CheckIsValidException(mesh);

            if (target_edge_length <= 0) 
                return 0;

            mesh.SetIsUpdatedToFalse();
            int new_halfedges = Kernel.SplitLongEdges_PH(mesh.Ptr, target_edge_length);
            int new_edges = new_halfedges / 2;

            return new_edges;
        }

        /// <summary>
        /// splits the edges listed in edges into sub-edges that are not longer than the given threshold max_length.
        /// Note this function is useful to split constrained edges before calling isotropic_remeshing() with protection
        /// of constraints activated (to match the constrained edge length required by the remeshing algorithm to be guaranteed to terminate)
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="target_edge_length">The edge length above which an edge from edges is split into to sub-edges</param>
        /// <returns>The number of new edges added to the mesh.</returns>
        public int SplitLongEdges(SurfaceMesh3<K> mesh, double target_edge_length)
        {
            CheckIsValidException(mesh);

            if (target_edge_length <= 0)
                return 0;

            mesh.SetIsUpdatedToFalse();
            int new_halfedges = Kernel.SplitLongEdges_SM(mesh.Ptr, target_edge_length);
            int new_edges = new_halfedges / 2;

            return new_edges;
        }

        /// <summary>
        /// Triangulate a single face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="face">The faces index in the mesh.</param>
        /// <returns>True if successful.</returns>
        public bool TriangulateFace(Polyhedron3<K> mesh, int face)
        {
            CheckIsValidException(mesh);

            mesh.SetIsUpdatedToFalse();
            return Kernel.TriangulateFace_PH(mesh.Ptr, face);
        }

        /// <summary>
        /// Triangulate a single face in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="face">The faces index in the mesh.</param>
        /// <returns>True if successful.</returns>
        public bool TriangulateFace(SurfaceMesh3<K> mesh, int face)
        {
            CheckIsValidException(mesh);

            mesh.SetIsUpdatedToFalse();
            return Kernel.TriangulateFace_SM(mesh.Ptr, face);
        }

        /// <summary>
        /// Triangulate a range of faces in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="faces">The faces to triangulate.</param>
        /// <param name="count">The length of the face array.</param>
        /// <returns>True if successful.</returns>
        public bool TriangulateFaces(Polyhedron3<K> mesh, int[] faces, int count)
        {
            CheckIsValidException(mesh);
            ErrorUtil.CheckArray(faces, count);

            mesh.SetIsUpdatedToFalse();
            return Kernel.TriangulateFaces_PH(mesh.Ptr, faces, count);
        }

        /// <summary>
        /// Triangulate a range of faces in the mesh.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        /// <param name="faces">The faces to triangulate.</param>
        /// <param name="count">The length of the face array.</param>
        /// <returns>True if successful.</returns>
        public bool TriangulateFaces(SurfaceMesh3<K> mesh, int[] faces, int count)
        {
            CheckIsValidException(mesh);
            ErrorUtil.CheckArray(faces, count);

            mesh.SetIsUpdatedToFalse();
            return Kernel.TriangulateFaces_SM(mesh.Ptr, faces, count);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MeshProcessingMeshing : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private MeshProcessingMeshing()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal MeshProcessingMeshing(CGALKernel kernel)
        {
            Kernel = kernel.MeshProcessingMeshingKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal MeshProcessingMeshing(CGALKernel kernel, IntPtr ptr)
        {
            Kernel = kernel.MeshProcessingMeshingKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal MeshProcessingMeshingKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

