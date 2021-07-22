using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Triangulations
{
    public struct TriFace2
    {
        public int Index;

        public int VertexIndex0;
        public int VertexIndex1;
        public int VertexIndex2;

        public override string ToString()
        {
            return string.Format("[TriFace2: ]");
        }

        unsafe public int this[int i]
        {
            get
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("TriFace2 vertex index out of range.");

                fixed (TriFace2* array = &this) { return ((int*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 3)
                    throw new IndexOutOfRangeException("TriFace2 vertex index out of range.");

                fixed (int* array = &VertexIndex0) { array[i] = value; }
            }
        }
    }
}
