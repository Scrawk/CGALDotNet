namespace CGALDotNet.Polyhedra
{

    public struct FaceVertexCount
    {
        public int degenerate;
        public int triangles;
        public int quads;
        public int pentagons;
        public int hexagons;
        public int greater;

        public override string ToString()
        {
            return string.Format("[FaceVertexCount: Degenerate={0}, Triangles={1}, Quads={2}, Pentagons={3}, Hexagons={4}, Greater={5}]",
                degenerate, triangles, quads, pentagons, hexagons, greater);
        }

        public FaceVertexCountIndices Indices()
        {
            return new FaceVertexCountIndices(this);
        }

    }

    public struct FaceVertexCountIndices
    {
        public int[] triangles;
        public int[] quads;
        public int[] pentagons;
        public int[] hexagons;

        public FaceVertexCountIndices(FaceVertexCount fvc)
        {
            triangles = fvc.triangles > 0 ? new int[fvc.triangles * 3] : null;
            quads = fvc.quads > 0 ? new int[fvc.quads * 4] : null;
            pentagons = fvc.pentagons > 0 ? new int[fvc.pentagons * 5] : null;
            hexagons = fvc.hexagons > 0 ? new int[fvc.hexagons * 6] : null;
        }

        public override string ToString()
        {
            return string.Format("[FaceVertexCountIndices: Triangles={0}, Quads={1}, Pentagons={2}, Hexagons={3}]",
                Len(triangles), Len(quads), Len(pentagons), Len(hexagons));
        }

        public int triangleCount => Len(triangles);

        public int quadCount => Len(quads);

        public int pentagonCount => Len(pentagons);

        public int hexagonCount => Len(hexagons);

        private int Len(int[] array)
        {
            return array == null ? 0 : array.Length;
        }
    }
}
