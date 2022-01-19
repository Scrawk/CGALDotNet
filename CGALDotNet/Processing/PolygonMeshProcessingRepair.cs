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
    public sealed class PolygonMeshProcessingRepair<K> : PolygonMeshProcessingRepair where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingRepair<K> Instance = new PolygonMeshProcessingRepair<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingRepair() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingRepair(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingRepair<{0}>: ]", Kernel.KernelName);
        }

        /// <summary>
        /// Find the number of degenerate edges in the mesh.
        /// </summary>
        /// <param name="poly">The polygon mesh.</param>
        /// <returns>The number of degenerate edges in the mesh.</returns>
        //public int DegenerateHalfEdgeCount(Polyhedron3<K> poly)
        //{
        //    return Kernel.DegenerateHalfEdgeCount(poly.Ptr);
        //}

        /// <summary>
        /// Find the number of degenerate faces in the mesh.
        /// </summary>
        /// <param name="poly">A triangle polygon mesh.</param>
        /// <returns>The number of degenerate faces in the mesh.</returns>
        public int DegenerateTriangleCount(Polyhedron3<K> poly)
        {
            if (!CheckIsValidTriangle(poly)) return 0;

            return Kernel.DegenerateTriangleCount(poly.Ptr);
        }

        /// <summary>
        /// Checks whether a triangle face is needle.
        /// A triangle is said to be a needle if its longest edge is much longer than its shortest edge.
        /// </summary>
        /// <param name="poly">A triangle polygon mesh.</param>
        /// <param name="threshold">A bound on the ratio of the longest edge length and the shortest edge length.</param>
        /// <returns>The number of needle triangles.</returns>
        public int NeedleTriangleCount(Polyhedron3<K> poly, double threshold)
        {
            if (!CheckIsValidTriangle(poly)) return 0;

            return Kernel.NeedleTriangleCount(poly.Ptr, threshold);
        }

        /// <summary>
        /// Collects the non-manifold vertices (if any) present in the mesh.
        /// A non-manifold vertex v is returned via one incident halfedge h such that target(h, pm) = v 
        /// for all the umbrellas that v appears in (an umbrella being the set of faces incident to all 
        /// the halfedges reachable by walking around v using hnext = prev(opposite(h, pm), pm), starting from h).
        /// </summary>
        /// <param name="poly">A triangle polygon mesh.</param>
        /// <returns>The non manifold vertex count.</returns>
        public int NonManifoldVertexCount(Polyhedron3<K> poly)
        {
            if (!CheckIsValidTriangle(poly)) return 0;

            return Kernel.NonManifoldVertexCount(poly.Ptr);
        }

        /// <summary>
        /// Cleans a given polygon soup through various repairing operations.
        ///
        /// More precisely, this function carries out the following tasks, in the same order as they are listed:
        ///
        /// merging of duplicate points.
        /// simplification of polygons to remove geometrically identical consecutive vertices;
        /// splitting of "pinched" polygons, that is polygons in which a geometric position appears more than once.The splitting process results in multiple non-pinched polygons;
        /// removal of invalid polygons, that is polygons with fewer than 2 vertices;
        /// removal of duplicate polygons.
        /// removal of isolated points.
        /// </summary>
        /// <param name="poly">The polygon mesh.</param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool RepairPolygonSoup(Polyhedron3<K> poly)
        {
            Kernel.RepairPolygonSoup(poly.Ptr);
            return true;
        }

        /// <summary>
        /// stitches together, whenever possible, two halfedges belonging to the same boundary cycle.
        /// Two border halfedges h1 and h2 can be stitched if the points associated to the source and
        /// target vertices of h1 are the same as those of the target and source vertices of h2, respectively.
        /// </summary>
        /// <param name="poly">The polygon mesh.</param>
        /// <returns>The number of stiched boundaries.</returns>
        public int StitchBoundaryCycles(Polyhedron3<K> poly)
        {
            if (!CheckIsValid(poly)) return 0;
            return Kernel.StitchBoundaryCycles(poly.Ptr);
        }

        /// <summary>
        /// Stitches together border halfedges in a polygon mesh.
        /// </summary>
        /// <param name="poly">The polygon mesh.</param>
        /// <returns>The number of stiched borders.</returns>
        public int StitchBorders(Polyhedron3<K> poly)
        {
            if (!CheckIsValid(poly)) return 0;
            return Kernel.StitchBorders(poly.Ptr);
        }

        /// <summary>
        /// Extracts boundary cycles and merges the duplicated vertices of each cycle.
        /// </summary>
        /// <param name="poly">The polygon mesh.</param>
        /// <returns>The number of vertices that were merged.</returns>
        public int MergeDuplicatedVerticesInBoundaryCycle(Polyhedron3<K> poly)
        {
            if (!CheckIsValid(poly)) return 0;
            return Kernel.MergeDuplicatedVerticesInBoundaryCycle(poly.Ptr);
        }

        /// <summary>
        /// Removes the isolated vertices from any polygon mesh.
        /// A vertex is considered isolated if it is not incident to any simplex of higher dimension.
        /// </summary>
        /// <param name="poly">The polygon mesh.</param>
        /// <returns>The number of vertices that were removed.</returns>
        public int RemoveIsolatedVertices(Polyhedron3<K> poly)
        {
            return Kernel.RemoveIsolatedVertices(poly.Ptr);
        }

        /// <summary>
        /// Splits the mesh into unconnected triangle and quad faces.
        /// </summary>
        /// <param name="poly">The polygon mesh.</param>
        /// <param name="triangles">The triangle indices array.</param>
        /// <param name="triangleCount">The triangle indices arrays length.</param>
        /// <param name="quads">The quad indices array.</param>
        /// <param name="quadCount">The quads indices arrays length.</param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool PolygonMeshToPolygonSoup(Polyhedron3<K> poly, int[] triangles, int triangleCount, int[] quads, int quadCount)
        {
            if (!CheckIsValid(poly)) 
                return false;

            Kernel.PolygonMeshToPolygonSoup(poly.Ptr, triangles, triangleCount, quads, quadCount);
            return true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PolygonMeshProcessingRepair : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingRepair()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingRepair(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMeshProcessingRepairKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingRepair(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonMeshProcessingRepairKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingRepairKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

