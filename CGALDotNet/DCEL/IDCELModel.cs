using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.DCEL
{
    public interface IDCELModel
    {
        /// <summary>
        /// A number that will change if the unmanaged 
        /// model changes.
        /// </summary>
        int BuildStamp { get; }

        /// <summary>
        /// The dimension of the point struct in the DCEL vertex
        /// </summary>
        int Dimension { get; }

        /// <summary>
        /// The number of half edges.
        /// </summary>
        int VertexCount { get; }

        /// <summary>
        /// The number of half edges.
        /// </summary>
        int HalfEdgeCount { get; }

        /// <summary>
        /// The number of faces in the arrangement not counting
        /// the unbounded face.
        /// </summary>
        int FaceCount { get; }

        /// <summary>
        /// Get the DCEL vertices that can be use to reconstruct 
        /// the model as a DCEL data sturcture.
        /// </summary>
        void GetDCELVertices(DCELMesh mesh);

        /// <summary>
        /// Get the DCEL edhe that can be use to reconstruct 
        /// the model as a DCEL data sturcture.
        /// </summary>
        void GetDCELHalfEdges(DCELMesh mesh);

        /// <summary>
        /// Get the DCEL faces that can be use to reconstruct 
        /// the model as a DCEL data sturcture.
        /// </summary>
        void GetDCELFaces(DCELMesh mesh);

        /// <summary>
        /// Locate the vert the point hits.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="vert">The vert the point has hit.</param>
        /// <returns>True if the point hit a vert.</returns>
        bool LocateVertex(Point2d point, DCELMesh mesh, out DCELVertex vert);

        /// <summary>
        /// Locate the edge the point hits.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="vert">The vert the point has hit.</param>
        /// <returns>True if the point hit a vert.</returns>
        bool LocateHalfEdge(Point2d point, DCELMesh mesh, out DCELHalfEdge edge);

        /// <summary>
        /// Locate the face the point hits.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="mesh">The decel mesh.</param>
        /// <param name="face">The face the point has hit.</param>
        /// <returns>True if the point hit a face.</returns>
        bool LocateFace(Point2d point, DCELMesh mesh, out DCELFace face);



    }
}
