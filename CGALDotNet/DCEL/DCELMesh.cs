using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Arrangements;
using CGALDotNet.Geometry;

namespace CGALDotNet.DCEL
{
    public class DCELMesh
    {

        public DCELMesh()
        {
            Vertices = new List<DCELVertex>();
            HalfEdges = new List<DCELHalfEdge>();
            Faces = new List<DCELFace>();
        }

        public DCELMesh(IDCELModel model)
        {
            Vertices = new List<DCELVertex>(model.VertexCount);
            HalfEdges = new List<DCELHalfEdge>(model.HalfEdgeCount);
            Faces = new List<DCELFace>(model.FaceCount);

            BuildFromModel(model);
        }

        public int Dimension => Model.Dimension;

        private List<DCELVertex> Vertices;

        private List<DCELHalfEdge> HalfEdges;

        private List<DCELFace> Faces;

        private IDCELModel Model;

        public override string ToString()
        {
            return string.Format("[DCELMesh: Vertices={0}, HalfEdges={1}, Faces={2}]",
                Vertices.Count, HalfEdges.Count, Faces.Count);
        }

        public void BuildFromModel(IDCELModel model)
        {
            Model = model;
            CreateVertices();
            CreateHalfEdges();
            CreateFaces();
        }

        public int VertexCount => Vertices.Count;

        public int HalfEdgeCount => HalfEdges.Count;

        public int FaceCount => Faces.Count;

        public DCELVertex GetVertex(int index)
        {
            return Vertices[index];
        }

        public void AddVertex(DCELVertex vertex)
        {
            vertex.Mesh = this;
            Vertices.Add(vertex);
        }

        public DCELHalfEdge GetHalfEdge(int index)
        {
            return HalfEdges[index];
        }

        public void AddHalfEdge(DCELHalfEdge edge)
        {
            edge.Mesh = this;
            HalfEdges.Add(edge);
        }

        public DCELFace GetFace(int index)
        {
            return Faces[index];
        }

        public void AddFace(DCELFace face)
        {
            face.Mesh = this;
            Faces.Add(face);
        }

        public bool InVerticesBounds(int i)
        {
            return !(i < 0 || i >= VertexCount);
        }

        public bool InHalfEdgeBounds(int i)
        {
            return !(i < 0 || i >= HalfEdgeCount);
        }

        public bool InFaceBounds(int i)
        {
            return !(i < 0 || i >= FaceCount);
        }

        public IEnumerable<DCELVertex> EnumerateVertices()
        {
            foreach (var vert in Vertices)
                yield return vert;
        }

        public IEnumerable<DCELHalfEdge> EnumerateEdges()
        {
            foreach (var edge in HalfEdges)
                yield return edge;
        }

        public IEnumerable<DCELFace> EnumerateFaces()
        {
            foreach (var face in Faces)
                yield return face;
        }

        private void CreateVertices()
        {
            Vertices.Clear();

            int count = Model.VertexCount;
            if (count <= 0) return;

            Model.GetDCELVertices(this);
        }

        private void CreateFaces()
        {
            Faces.Clear();

            int count = Model.FaceCount;
            if (count <= 0) return;

            Model.GetDCELFaces(this);
        }

        private void CreateHalfEdges()
        {
            HalfEdges.Clear();

            int count = Model.HalfEdgeCount;
            if (count <= 0) return;

            Model.GetDCELHalfEdges(this);
        }

        /// <summary>
        /// Locate the face the point hits.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <param name="face">The face the point has hit.</param>
        /// <returns>True if the point hit a face.</returns>
        public bool LocateFace(Point2d point, out DCELFace face)
        {
            if( Model.LocateFace(point, this, out face))
            {
                face.Mesh = this;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Locate the closest vertex in the hit face
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="vertex">The closest vertex.</param>
        /// <returns>True if point hit a face and found a vertex.</returns>
        public bool LocateVertex(Point2d point, out DCELVertex vertex)
        {
            //First check if point directly hits a vertex.
            if(Model.LocateVertex(point, this, out vertex))
                return true;

            //Locate the face the point hit.
            vertex = new DCELVertex();
            if (LocateFace(point, out DCELFace face))
            {
                //Find the closest vertex in the face to the point.
                double min = double.PositiveInfinity;
                DCELVertex closest = new DCELVertex();
               
                foreach(var vert in face.EnumerateVertices())
                {
                    int v = vert.Index;
                    if (v == -1) continue;

                    var sqdist = Point2d.SqrDistance(vertex.Point.xy, point);
                    if (sqdist < min)
                    {
                        min = sqdist;
                        closest = vertex;
                    }

                }

                //Face had no valid vertices.
                //Should not happen but check anyway.
                if (min == double.PositiveInfinity)
                    return false;
                else
                {
                    vertex = closest;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Locate the closest edge in the hit face.
        /// </summary>
        /// <param name="point">The point</param>
        /// <param name="edge">The closest edge.</param>
        /// <returns>True if the point hit a face and found a edge.</returns>
        public bool LocateEdge(Point2d point, out DCELHalfEdge edge)
        {
            //First check if point directly hits a edge.
            if (Model.LocateHalfEdge(point, this, out edge))
                return true;

            //Locate the face the point hit.
            edge = new DCELHalfEdge();
            if (LocateFace(point, out DCELFace face))
            {
                //Find the closest edge to the point in the face.
                double min = double.PositiveInfinity;
                DCELHalfEdge closest = new DCELHalfEdge();

                foreach (var e in face.EnumerateEdges())
                {
                    if (e.SourceIndex == -1 || e.TargetIndex == -1) continue;

                    var p1 = e.SourcePoint.xy;
                    var p2 = e.TargetPoint.xy;

                        var seg = new Segment2d(p1, p2);
                        var sqdist = seg.SqrDistance(point);

                        if (sqdist < min)
                        {
                            min = sqdist;
                            closest =e;
                        }
                    
                }

                //Face had no valid vertices.
                //Should not happen but check anyway.
                if (min == double.PositiveInfinity)
                    return false;
                else
                {
                    edge = closest;
                    return true;
                }
            }

            return false;
        }

        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        public void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());

            builder.AppendLine();

            foreach (var vert in Vertices)
                builder.AppendLine(vert.ToString());

            builder.AppendLine();

            foreach (var halfEdge in HalfEdges)
                builder.AppendLine(halfEdge.ToString());

            builder.AppendLine();

            foreach (var face in Faces)
                builder.AppendLine(face.ToString());
        }
    }
}
