using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polyhedra
{
    public interface IMesh
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
        /// Clear the mesh.
        /// </summary>
        void Clear();

        /// <summary>
        /// Create a mesh from the points and indices.
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="triangles">The meshes triangles as a index array. Maybe null.</param>
        /// <param name="quads">The meshes quads as a index array. Maybe null.</param>
        void CreateMesh(Point3d[] points, int[] triangles, int[] quads);

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
        void CreateQuadMesh(Point3d[] points, int pointsCount, int[] indices, int indexCount);

        /// <summary>
        /// Create a mesh with quads and triangles
        /// </summary>
        /// <param name="points">The meshes points.</param>
        /// <param name="pointsCount">The point array length.</param>
        /// <param name="triangles">The meshes triangles.</param>
        /// <param name="triangleCount">The triangle array length.</param>
        /// <param name="quads">The meshes quads.</param>
        /// <param name="quadsCount">The quads array length.</param>
        void CreateTriangleQuadMesh(Point3d[] points, int pointsCount, int[] triangles, int triangleCount, int[] quads, int quadsCount);

        /// <summary>
        /// Get the triangle and quad indices.
        /// </summary>
        /// <param name="triangles">The meshes triangles as a index array. Maybe null.</param>
        /// <param name="quads">The meshes quads as a index array. Maybe null.</param>
        void GetIndices(int[] triangles, int[] quads);

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
        /// Get the meshes points.
        /// </summary>
        /// <param name="points">The array to copy the points into.</param>
        /// <param name="count">The ararys length.</param>
        void GetPoints(Point3d[] points, int count);

        /// <summary>
        /// Count the number of triangles, quads and polygons in the mesh.
        /// </summary>
        /// <returns>The number of triangles, quads and polygons in the mesh.</returns>
        FaceVertexCount GetFaceVertexCount();

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

    }
}
