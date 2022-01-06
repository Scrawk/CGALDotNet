using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.PolyHedra
{
    public struct SurfaceMeshVertex : IEquatable<SurfaceMeshVertex>
    {
        internal int index;

        public SurfaceMeshVertex(int index)
        {
            this.index = index;
        }

        public static bool operator ==(SurfaceMeshVertex v1, SurfaceMeshVertex v2)
        {
            return v1.index == v2.index;
        }

        public static bool operator !=(SurfaceMeshVertex v1, SurfaceMeshVertex v2)
        {
            return v1.index != v2.index;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SurfaceMeshVertex)) return false;
            SurfaceMeshVertex v = (SurfaceMeshVertex)obj;
            return this == v;
        }

        public bool Equals(SurfaceMeshVertex v)
        {
            return this == v;
        }

        public override int GetHashCode()
        {
            return index.GetHashCode();
        }
    }
}
