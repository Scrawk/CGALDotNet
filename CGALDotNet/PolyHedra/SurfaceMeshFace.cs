using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.PolyHedra
{
    public struct SurfaceMeshFace : IEquatable<SurfaceMeshFace>
    {
        internal int index;

        public SurfaceMeshFace(int index)
        {
            this.index = index;
        }

        public static bool operator ==(SurfaceMeshFace v1, SurfaceMeshFace v2)
        {
            return v1.index == v2.index;
        }

        public static bool operator !=(SurfaceMeshFace v1, SurfaceMeshFace v2)
        {
            return v1.index != v2.index;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SurfaceMeshFace)) return false;
            SurfaceMeshFace v = (SurfaceMeshFace)obj;
            return this == v;
        }

        public bool Equals(SurfaceMeshFace v)
        {
            return this == v;
        }

        public override int GetHashCode()
        {
            return index.GetHashCode();
        }
    }
}
