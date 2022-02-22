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
    public sealed class MeshProcessingRepair<K> : MeshProcessingRepair where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly MeshProcessingRepair<K> Instance = new MeshProcessingRepair<K>();

        /// <summary>
        /// 
        /// </summary>
        public MeshProcessingRepair() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MeshProcessingRepair(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshProcessingRepair<{0}>: ]", Kernel.Name);
        }

        /*
        /// <summary>
        /// Find the number of degenerate edges in the mesh.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of degenerate edges in the mesh.</returns>
        public int DegenerateEdgeCount(Polyhedron3<K> mesh)
        {
            return Kernel.DegenerateEdgeCount_PM(mesh.Ptr);
        }
        */

        /// <summary>
        /// Find the number of degenerate edges in the mesh.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of degenerate edges in the mesh.</returns>
        public int DegenerateEdgeCount(SurfaceMesh3<K> mesh)
        {
            return Kernel.DegenerateEdgeCount_SM(mesh.Ptr);
        }

        /// <summary>
        /// Find the number of degenerate faces in the mesh.
        /// </summary>
        /// <param name="mesh">A triangle polygon mesh.</param>
        /// <returns>The number of degenerate faces in the mesh.</returns>
        public int DegenerateTriangleCount(Polyhedron3<K> mesh)
        {
            //CheckIsValidTriangleException(mesh);
            return Kernel.DegenerateTriangleCount_PH(mesh.Ptr);
        }

        /// <summary>
        /// Find the number of degenerate faces in the mesh.
        /// </summary>
        /// <param name="mesh">A triangle polygon mesh.</param>
        /// <returns>The number of degenerate faces in the mesh.</returns>
        public int DegenerateTriangleCount(SurfaceMesh3<K> mesh)
        {
            //CheckIsValidTriangleException(mesh);
            return Kernel.DegenerateTriangleCount_SM(mesh.Ptr);
        }

        /// <summary>
        /// Checks whether a triangle face is needle.
        /// A triangle is said to be a needle if its longest edge is much longer than its shortest edge.
        /// </summary>
        /// <param name="mesh">A triangle polygon mesh.</param>
        /// <param name="threshold">A bound on the ratio of the longest edge length and the shortest edge length.</param>
        /// <returns>The number of needle triangles.</returns>
        public int NeedleTriangleCount(Polyhedron3<K> mesh, double threshold)
        {
            //CheckIsValidTriangleException(mesh);
            return Kernel.NeedleTriangleCount_PH(mesh.Ptr, threshold);
        }

        /// <summary>
        /// Checks whether a triangle face is needle.
        /// A triangle is said to be a needle if its longest edge is much longer than its shortest edge.
        /// </summary>
        /// <param name="mesh">A triangle polygon mesh.</param>
        /// <param name="threshold">A bound on the ratio of the longest edge length and the shortest edge length.</param>
        /// <returns>The number of needle triangles.</returns>
        public int NeedleTriangleCount(SurfaceMesh3<K> mesh, double threshold)
        {
            //CheckIsValidTriangleException(mesh);
            return Kernel.NeedleTriangleCount_SM(mesh.Ptr, threshold);
        }

        /// <summary>
        /// Collects the non-manifold vertices (if any) present in the mesh.
        /// A non-manifold vertex v is returned via one incident halfedge h such that target(h, pm) = v 
        /// for all the umbrellas that v appears in (an umbrella being the set of faces incident to all 
        /// the halfedges reachable by walking around v using hnext = prev(opposite(h, pm), pm), starting from h).
        /// </summary>
        /// <param name="mesh">A triangle polygon mesh.</param>
        /// <returns>The non manifold vertex count.</returns>
        public int NonManifoldVertexCount(Polyhedron3<K> mesh)
        {
            //CheckIsValidTriangleException(mesh);
            return Kernel.NonManifoldVertexCount_PH(mesh.Ptr);
        }

        /// <summary>
        /// Collects the non-manifold vertices (if any) present in the mesh.
        /// A non-manifold vertex v is returned via one incident halfedge h such that target(h, pm) = v 
        /// for all the umbrellas that v appears in (an umbrella being the set of faces incident to all 
        /// the halfedges reachable by walking around v using hnext = prev(opposite(h, pm), pm), starting from h).
        /// </summary>
        /// <param name="mesh">A triangle polygon mesh.</param>
        /// <returns>The non manifold vertex count.</returns>
        public int NonManifoldVertexCount(SurfaceMesh3<K> mesh)
        {
            //CheckIsValidTriangleException(mesh);
            return Kernel.NonManifoldVertexCount_SM(mesh.Ptr);
        }

        /// <summary>
        /// Cleans a given polygon soup through various repairing operations.
        ///
        /// More precisely, this function carries out the following tasks, in the same order as they are listed:
        ///
        /// merging of duplicate points.
        /// simplification of polygons to remove geometrically identical consecutive vertices;
        /// splitting of "pinched" polygons, that is polygons in which a geometric position appears more than once.
        /// The splitting process results in multiple non-pinched polygons;
        /// removal of invalid polygons, that is polygons with fewer than 2 vertices;
        /// removal of duplicate polygons.
        /// removal of isolated points.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        public void RepairPolygonSoup(Polyhedron3<K> mesh)
        {
            mesh.SetIsUpdatedToFalse();
            Kernel.RepairPolygonSoup_PH(mesh.Ptr);
        }

        /// <summary>
        /// Cleans a given polygon soup through various repairing operations.
        ///
        /// More precisely, this function carries out the following tasks, in the same order as they are listed:
        ///
        /// merging of duplicate points.
        /// simplification of polygons to remove geometrically identical consecutive vertices;
        /// splitting of "pinched" polygons, that is polygons in which a geometric position appears more than once.
        /// The splitting process results in multiple non-pinched polygons;
        /// removal of invalid polygons, that is polygons with fewer than 2 vertices;
        /// removal of duplicate polygons.
        /// removal of isolated points.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        public void RepairPolygonSoup(SurfaceMesh3<K> mesh)
        {
            mesh.SetIsUpdatedToFalse();
            Kernel.RepairPolygonSoup_SM(mesh.Ptr);
        }

        /// <summary>
        /// stitches together, whenever possible, two halfedges belonging to the same boundary cycle.
        /// Two border halfedges h1 and h2 can be stitched if the points associated to the source and
        /// target vertices of h1 are the same as those of the target and source vertices of h2, respectively.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of stiched boundaries.</returns>
        public int StitchBoundaryCycles(Polyhedron3<K> mesh)
        {
            CheckIsValidException(mesh);
            mesh.SetIsUpdatedToFalse();
            return Kernel.StitchBoundaryCycles_PH(mesh.Ptr);
        }

        /// <summary>
        /// stitches together, whenever possible, two halfedges belonging to the same boundary cycle.
        /// Two border halfedges h1 and h2 can be stitched if the points associated to the source and
        /// target vertices of h1 are the same as those of the target and source vertices of h2, respectively.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of stiched boundaries.</returns>
        public int StitchBoundaryCycles(SurfaceMesh3<K> mesh)
        {
            CheckIsValidException(mesh);
            mesh.SetIsUpdatedToFalse();
            return Kernel.StitchBoundaryCycles_SM(mesh.Ptr);
        }

        /// <summary>
        /// Stitches together border halfedges in a polygon mesh.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of stiched borders.</returns>
        public int StitchBorders(Polyhedron3<K> mesh)
        {
            CheckIsValidException(mesh);
            mesh.SetIsUpdatedToFalse();
            return Kernel.StitchBorders_PH(mesh.Ptr);
        }

        /// <summary>
        /// Stitches together border halfedges in a polygon mesh.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of stiched borders.</returns>
        public int StitchBorders(SurfaceMesh3<K> mesh)
        {
            CheckIsValidException(mesh);
            mesh.SetIsUpdatedToFalse();
            return Kernel.StitchBorders_SM(mesh.Ptr);
        }

        /*

        /// <summary>
        /// Merges the duplicated vertices of the edges boundary cycle.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <param name="index">The index of a half edge in the boundary.</param>
        /// <returns></returns>
        public int MergeDuplicatedVerticesInBoundaryCycle(Polyhedron3<K> mesh, int index)
        {
            CheckIsValidException(mesh);
            mesh.SetIsUpdatedToFalse();
            return Kernel.MergeDuplicatedVerticesInBoundaryCycle_PH(mesh.Ptr, index);
        }

        /// <summary>
        /// Merges the duplicated vertices of the edges boundary cycle.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <param name="index">The index of a half edge in the boundary.</param>
        /// <returns></returns>
        public int MergeDuplicatedVerticesInBoundaryCycle(SurfaceMesh3<K> mesh, int index)
        {
            CheckIsValidException(mesh);
            mesh.SetIsUpdatedToFalse();
            return Kernel.MergeDuplicatedVerticesInBoundaryCycle_SM(mesh.Ptr, index);
        }

        /// <summary>
        /// Extracts boundary cycles and merges the duplicated vertices of each cycle.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of vertices that were merged.</returns>
        public int MergeDuplicatedVerticesInBoundaryCycles(Polyhedron3<K> mesh)
        {
            CheckIsValidException(mesh);
            mesh.SetIsUpdatedToFalse();
            return Kernel.MergeDuplicatedVerticesInBoundaryCycles_PH(mesh.Ptr);
        }

        /// <summary>
        /// Extracts boundary cycles and merges the duplicated vertices of each cycle.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of vertices that were merged.</returns>
        public int MergeDuplicatedVerticesInBoundaryCycles(SurfaceMesh3<K> mesh)
        {
            CheckIsValidException(mesh);
            mesh.SetIsUpdatedToFalse();
            return Kernel.MergeDuplicatedVerticesInBoundaryCycles_SM(mesh.Ptr);
        }

        */

        /// <summary>
        /// Removes the isolated vertices from any polygon mesh.
        /// A vertex is considered isolated if it is not incident to any simplex of higher dimension.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of vertices that were removed.</returns>
        public int RemoveIsolatedVertices(Polyhedron3<K> mesh)
        {
            mesh.SetIsUpdatedToFalse();
            return Kernel.RemoveIsolatedVertices_PH(mesh.Ptr);
        }

        /// <summary>
        /// Removes the isolated vertices from any polygon mesh.
        /// A vertex is considered isolated if it is not incident to any simplex of higher dimension.
        /// </summary>
        /// <param name="mesh">The polygon mesh.</param>
        /// <returns>The number of vertices that were removed.</returns>
        public int RemoveIsolatedVertices(SurfaceMesh3<K> mesh)
        {
            mesh.SetIsUpdatedToFalse();
            return Kernel.RemoveIsolatedVertices_SM(mesh.Ptr);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MeshProcessingRepair : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private MeshProcessingRepair()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal MeshProcessingRepair(CGALKernel kernel)
        {
            Kernel = kernel.MeshProcessingRepairKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal MeshProcessingRepair(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.MeshProcessingRepairKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal MeshProcessingRepairKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

