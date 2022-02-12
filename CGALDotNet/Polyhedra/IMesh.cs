using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Polyhedra
{
    public interface IMesh : IEnumerable<Point3d>
    {

        /// <summary>
        /// Number of vertices.
        /// </summary>
        int VertexCount { get; }

        /// <summary>
        /// Number of faces.
        /// </summary>
        int FaceCount { get; }

        /// <summary>
        /// Number of halfedges.
        /// </summary>
        int HalfedgeCount { get; }

        /// <summary>
        /// Number of border edges.
        /// Since each border edge of a polyhedral surface has exactly one 
        /// border halfedge, this number is equal to size of border halfedges.
        /// </summary>
        int BorderEdgeCount { get; }

        /// <summary>
        /// Returns true if the polyhedral surface is combinatorially consistent.
        /// Must be a valid mesh to check many other properties.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Returns true if there are no border edges.
        /// </summary>
        bool IsClosed { get; }

        /// <summary>
        /// Returns true if all faces are triangles.
        /// </summary>
        bool IsTriangle { get; }

        /// <summary>
        /// Returns true if all faces are quads.
        /// </summary>
        bool IsQuad { get; }

        /// <summary>
        /// Is this a valid triangle mesh.
        /// </summary>
        bool IsValidTriangleMesh { get; }

        /// <summary>
        /// Is this a valid closed mesh.
        /// </summary>
        bool IsValidClosedMesh { get; }

        /// <summary>
        /// Is this a valid closed triangle mesh.
        /// </summary>
        bool IsValidClosedTriangleMesh { get; }

        /// <summary>
        /// The current build stamp.
        /// </summary>
        int BuildStamp { get; }

        /// <summary>
        /// Clear the mesh.
        /// </summary>
        void Clear();

        /// <summary>
        /// Clear the normal maps.
        /// </summary>
        /// <param name="vertices">True to clear the vertex normal map.</param>
        /// <param name="faces">True to clear the face normal map. </param>
        void ClearNormalMaps(bool vertices, bool faces);

        /// <summary>
        /// Create a mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="triangles">The meshes triangles as a index array. Maybe null.</param>
        /// <param name="quads">The meshes quads as a index array. Maybe null.</param>
        void CreateMesh(Point3d[] points, int[] triangles, int[] quads = null);

        /// <summary>
        /// Create a triangle mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="pointCount">The point arrays length.</param>
        /// <param name="indices">The meshes trinagles as a index array.</param>
        /// <param name="indexCount">The indices array length.</param>
        void CreateTriangleMesh(Point3d[] points, int pointCount, int[] indices, int indexCount);

        /// <summary>
        /// Create a quad mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="pointCount">The point arrays length.</param>
        /// <param name="indices">The meshes trinagles as a index array.</param>
        /// <param name="indexCount">The indices array length.</param>
        void CreateQuadMesh(Point3d[] points, int pointCount, int[] indices, int indexCount);

        /// <summary>
        /// Create a mesh with quads and triangles.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="pointsCount">The point array length.</param>
        /// <param name="triangles">The meshes triangles.</param>
        /// <param name="triangleCount">The triangle array length.</param>
        /// <param name="quads">The meshes quads.</param>
        /// <param name="quadsCount">The quads array length.</param>
        void CreateTriangleQuadMesh(Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadsCount);

        /// <summary>
        /// Create a mesh with riangles, quads, pentagons and hexagons.
        /// </summary>
        /// <param name="points">The meshs points.</param>
        /// <param name="pointsCount">The length of the point array.</param>
        /// <param name="indices">The faces indices.</param>
        void CreatePolygonalMesh(Point3d[] points, int pointsCount, PolygonalIndices indices);

        /// <summary>
        /// Create a mesh consisting of one polygon face.
        /// </summary>
        /// <param name="points">The faces points</param>
        /// <param name="count">The length of the point array.</param>
        /// <param name="xz">Should the y coord of the points be used for the z coord.</param>
        void CreatePolygonMesh(Point2d[] points, int count, bool xz);

        /// <summary>
        /// Get the triangle and quad indices.
        /// </summary>
        /// <param name="triangles">The meshes triangles as a index array. Maybe null.</param>
        /// <param name="quads">The meshes quads as a index array. Maybe null.</param>
        void GetIndices(int[] triangles, int[] quads = null);

        /// <summary>
        /// Get the meshes triangles.
        /// </summary>
        /// <param name="triangles">The meshes triangles.</param>
        /// <param name="trianglesCount">The triangle array length.</param>
        void GetTriangleIndices(int[] triangles, int trianglesCount);

        /// <summary>
        /// Get the meshes quads.
        /// </summary>
        /// <param name="quads">The meshes quads.</param>
        /// <param name="quadsCount">The quads array length.</param>
        void GetQuadIndices(int[] quads, int quadsCount);

        /// <summary>
        /// Get the meshes triangles and quads.
        /// </summary>
        /// <param name="triangles">The meshes triangles.</param>
        /// <param name="trianglesCount">The triangle array length.</param>
        /// <param name="quads">The meshes quads.</param>
        /// <param name="quadsCount">The quads array length.</param>
        void GetTriangleQuadIndices(int[] triangles, int trianglesCount, int[] quads, int quadsCount);

        /// <summary>
        /// Get the meshes triangles, quads, pentagons and hexagons.
        /// </summary>
        /// <returns>The indices.</returns>
        PolygonalIndices GetPolygonalIndices();

        /*
        /// <summary>
        /// Get the dual meshes triangles, quads, pentagons and hexagons.
        /// A dual mesh is were faces become vertices and vertices become faces.
        /// </summary>
        /// <param name="indices">The faces indices</param>
        PolygonalIndices GetDualPolygonalIndices();
        */

        /// <summary>
        /// Array accessor for the polygon.
        /// Getting a point wraps around the polygon.
        /// </summary>
        /// <param name="i">The points index.</param>
        /// <returns>The vertices point.</returns>
        Point3d this[int i] { get; set; }

        /// <summary>
        /// Get the vertices point.
        /// </summary>
        /// <param name="index">The vertex index in the mesh.</param>
        /// <returns>The vertices point.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If index is out of range.</exception>
        Point3d GetPoint(int index);

        /// <summary>
        /// Get the points in the mesh.
        /// </summary>
        /// <param name="points">The array to copy points into.</param>
        /// <param name="count">The point array length.</param>
        void GetPoints(Point3d[] points, int count);

        /// <summary>
        /// Set the point at the index.
        /// </summary>
        /// <param name="index">The points index</param>
        /// <param name="point">The points</param>am>
        /// <exception cref="ArgumentOutOfRangeException">If index is out of range.</exception>
        void SetPoint(int index, Point3d point);

        /// <summary>
        /// Set the points from a array.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The point arrays length.</param>
        void SetPoints(Point3d[] points, int count);

        /// <summary>
        /// Get a halfedges segment.
        /// </summary>
        /// <param name="index">The halfedges index.</param>
        /// <param name="segment">The segment.</param>
        /// <returns>True if halfedge found.</returns>
        bool GetSegment(int index, out Segment3d segment);

        /// <summary>
        /// Get a segment for  each halfedge in the mesh.
        /// </summary>
        /// <param name="segments">The segment array.</param>
        /// <param name="count">The segment array length.</param>
        void GetSegments(Segment3d[] segments, int count);

        /// <summary>
        /// Get the faces triangle. 
        /// Presumes face is a triangle with no checks.
        /// </summary>
        /// <param name="index">The faces index.</param>
        /// <param name="triangle">The faces triangle</param>
        /// <returns></returns>
        bool GetTriangle(int index, out Triangle3d triangle);

        /// <summary>
        /// Get a triangle for each face in the mesh.
        /// Presumes all faces are triangles with no checks.
        /// </summary>
        /// <param name="triangles">The trainagle array.</param>
        /// <param name="count">The traingle  arrays length.</param>
        void GetTriangles(Triangle3d[] triangles, int count);

        /// <summary>
        /// Get the mesh vertex.
        /// </summary>
        /// <param name="index">The vertices index.</param>
        /// <param name="vertex">The vertex.</param>
        /// <returns>True if the vertex was found.</returns>
        bool GetVertex(int index, out MeshVertex3 vertex);

        /// <summary>
        /// Get the vertices in the mesh.
        /// </summary>
        /// <param name="vertices">The vertex array.</param>
        /// <param name="count">The vertex array length.</param>
        void GetVertices(MeshVertex3[] vertices, int count);

        /// <summary>
        /// Get the mesh face.
        /// </summary>
        /// <param name="index">The faces index.</param>
        /// <param name="face">The face.</param>
        /// <returns>True if the face was found.</returns>
        bool GetFace(int index, out MeshFace3 face);
 
        /// <summary>
        /// Get the faces in the mesh.
        /// </summary>
        /// <param name="faces">The face array.</param>
        /// <param name="count">The face array length.</param>
        void GetFaces(MeshFace3[] faces, int count);

        /// <summary>
        /// Get the mesh halfedge.
        /// </summary>
        /// <param name="index">The halfedges index.</param>
        /// <param name="halfedge">The halfedge.</param>
        /// <returns>True if the halfedge was found.</returns>
        bool GetHalfedge(int index, out MeshHalfedge3 halfedge);

        /// <summary>
        /// Get the halfedges in the mesh.
        /// </summary>
        /// <param name="halfedges">The halfedge array.</param>
        /// <param name="count">The halfedge array length.</param>
        void GetHalfedges(MeshHalfedge3[] halfedges, int count);

        /// <summary>
        /// Count the number of triangles, quads and polygons in the mesh.
        /// </summary>
        /// <returns>The number of triangles, quads and polygons in the mesh.</returns>
        PolygonalCount GetPolygonalCount();

        /// <summary>
        /// Count the number of triangles, quads and polygons in the dual mesh.
        /// A dual mesh is were faces become vertices and vertices become faces.
        /// </summary>
        /// <returns>The number of triangles, quads and polygons in the mesh.</returns>
        PolygonalCount GetDualPolygonalCount();

        /// <summary>
        /// Get a centroid (the avergae face position) for each face in the mesh.
        /// </summary>
        /// <param name="points">The point array.</param>
        /// <param name="count">The points arrays lemgth.</param>
        void GetCentroids(Point3d[] points, int count);

        /// <summary>
        /// Computes the vertex normals if needed.
        /// </summary>
        void ComputeVertexNormals();

        /// <summary>
        /// Computes the face normals if needed.
        /// </summary>
        void ComputeFaceNormals();

        /// <summary>
        /// Get the vertex normals.
        /// </summary>
        /// <param name="normals">The normals array.</param>
        /// <param name="count">The normals array length.</param>
        void GetVertexNormals(Vector3d[] normals, int count);

        /// <summary>
        /// Get the face normals.
        /// </summary>
        /// <param name="normals">The normals array.</param>
        /// <param name="count">The normals array length.</param>
        void GetFaceNormals(Vector3d[] normals, int count);

        /// <summary>
        /// Translate each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        void Translate(Point3d translation);

        /// <summary>
        /// Rotate each point in the mesh.
        /// </summary>
        /// <param name="rotation">The amount to rotate.</param>
        void Rotate(Quaternion3d rotation);

        /// <summary>
        /// Scale each point in the mesh.
        /// </summary>
        /// <param name="scale">The amount to scale.</param>
        void Scale(Point3d scale);

        /// <summary>
        /// Transform each point in the mesh.
        /// </summary>
        /// <param name="translation">The amount to translate.</param>
        /// <param name="rotation">The amount to rotate.</param>
        /// <param name="scale">The amount to scale.</param>
        void Transform(Point3d translation, Quaternion3d rotation, Point3d scale);

        /// <summary>
        /// Make all faces triangles.
        /// </summary>
        void Triangulate();

        /// <summary>
        /// Read data from a off file into the pollyhedron.
        /// </summary>
        /// <param name="filename">The files name.</param>
        void ReadOFF(string filename);

        /// <summary>
        /// Write data from a off file into the pollyhedron.
        /// </summary>
        /// <param name="filename">The files name.</param>
        void WriteOFF(string filename);

        /// <summary>
        /// Print the mesh into a string builder.
        /// </summary>
        /// <param name="builder"></param>
        void Print(StringBuilder builder);

        /// <summary>
        /// Reverses the orientation of the vertices in each face.
        /// </summary>
        void ReverseFaceOrientation();

        /// <summary>
        /// Find what side of the mesh the lies in.
        /// </summary>
        /// <param name="point">The point to check.</param>
        /// <returns>ON_BOUNDED_SIDE if point inside mesh, 
        /// ON_UNBOUNDED_SIDE if point not inside, 
        /// ON_BOUNDARY if point is on the surface.</returns>
        public BOUNDED_SIDE BoundedSide(Point3d point);

        /// <summary>
        /// Does the mesh contain the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="includeBoundary">If point is on the boundary does it count a being contained.</param>
        /// <returns>True if the poly contains the point</returns>
        bool ContainsPoint(Point3d point, bool includeBoundary = true);

        /// <summary>
        /// Locate the face the rays hits.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <returns>The hit result.</returns>
        MeshHitResult LocateFace(Ray3d ray);

        /// <summary>
        /// Find the face closest to the point.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>The hit result.</returns>
        MeshHitResult ClosestFace(Point3d point);

        /// <summary>
        /// Locate the face hit by the ray.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <param name="face">The hit face.</param>
        /// <returns>True if the ray hit a face.</returns>
        bool LocateFace(Ray3d ray, out MeshFace3 face);

        /// <summary>
        /// Locate the vertex hit by the ray.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <param name="radius">The distance the vertex has to be within hit point.</param>
        /// <param name="vertex">The hit vertex.</param>
        /// <returns>True if the ray hit a vertex.</returns>
        bool LocateVertex(Ray3d ray, double radius, out MeshVertex3 vertex);

        /// <summary>
        /// Locate the edge hit by the ray.
        /// </summary>
        /// <param name="ray">The ray.</param>
        /// <param name="radius">The distance the edge has to be within hit point.</param>
        /// <param name="edge">The hit edge.</param>
        /// <returns>True if the ray hit a edge.</returns>
        bool LocateHalfedge(Ray3d ray, double radius, out MeshHalfedge3 edge);

    }
}
