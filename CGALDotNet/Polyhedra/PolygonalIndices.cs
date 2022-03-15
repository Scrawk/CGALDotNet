using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polyhedra
{
    public struct PolygonalIndices
    {
        public int[] triangles;
        public int[] quads;
        public int[] pentagons;
        public int[] hexagons;


        public PolygonalIndices(PolygonalCount count)
        {
            triangles = count.triangles > 0 ? new int[count.triangles * 3] : null;
            quads = count.quads > 0 ? new int[count.quads * 4] : null;
            pentagons = count.pentagons > 0 ? new int[count.pentagons * 5] : null;
            hexagons = count.hexagons > 0 ? new int[count.hexagons * 6] : null;
        }

        public override string ToString()
        {
            return string.Format("[PolygonalIndices: Triangles={0}, Quads={1}, Pentagons={2}, Hexagons={3}]",
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

        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        public void Print(StringBuilder builder)
        {
            if (triangleCount != 0)
            {
                builder.AppendLine("Triangles " + triangleCount);

                for (int i = 0; i < triangleCount / 3; i++)
                {
                    int i0 = triangles[i * 3 + 0];
                    int i1 = triangles[i * 3 + 1];
                    int i2 = triangles[i * 3 + 2];
                    builder.AppendLine(i0 + " " + i1 + " " + i2);
                }
            }

            if (quadCount != 0)
            {
                builder.AppendLine("Quads " + quadCount);

                for (int i = 0; i < quadCount / 4; i++)
                {
                    int i0 = quads[i * 4 + 0];
                    int i1 = quads[i * 4 + 1];
                    int i2 = quads[i * 4 + 2];
                    int i3 = quads[i * 4 + 3];
                    builder.AppendLine(i0 + " " + i1 + " " + i2 + " " + i3);
                }
            }

            if (pentagonCount != 0)
            {
                builder.AppendLine("Pentagons " + pentagonCount);

                for (int i = 0; i < pentagonCount / 5; i++)
                {
                    int i0 = pentagons[i * 5 + 0];
                    int i1 = pentagons[i * 5 + 1];
                    int i2 = pentagons[i * 5 + 2];
                    int i3 = pentagons[i * 5 + 3];
                    int i4 = pentagons[i * 5 + 4];
                    builder.AppendLine(i0 + " " + i1 + " " + i2 + " " + i3 + " " + i4);
                }
            }

            if (hexagonCount != 0)
            {
                builder.AppendLine("Hexagons " + hexagonCount);

                for (int i = 0; i < hexagonCount / 6; i++)
                {
                    int i0 = hexagons[i * 6 + 0];
                    int i1 = hexagons[i * 6 + 1];
                    int i2 = hexagons[i * 6 + 2];
                    int i3 = hexagons[i * 6 + 3];
                    int i4 = hexagons[i * 6 + 4];
                    int i5 = hexagons[i * 6 + 5];
                    builder.AppendLine(i0 + " " + i1 + " " + i2 + " " + i3 + " " + i4 + " " + i5);
                }
            }

        }
    }
}
