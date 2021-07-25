using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Triangulations
{
    public struct TriEdgeConstraint2
    {
        public int FaceIndex0;
        public int FaceIndex1;

        public override string ToString()
        {
            return string.Format("[TriEdgeConstraint2: Face0={0}, Face1={1},]",
                    FaceIndex0, FaceIndex1);
        }

        unsafe public int this[int i]
        {
            get
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("TriEdgeConstraint2 vertex index out of range.");

                fixed (TriEdgeConstraint2* array = &this) { return ((int*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 2)
                    throw new IndexOutOfRangeException("TriEdgeConstraint2 vertex index out of range.");

                fixed (int* array = &FaceIndex0) { array[i] = value; }
            }
        }
    }
}
