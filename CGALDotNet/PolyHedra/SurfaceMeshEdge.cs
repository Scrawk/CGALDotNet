using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polyhedra
{
    public struct SurfaceMeshEdge : IEquatable<SurfaceMeshEdge>
    {
        internal int index;

        public SurfaceMeshEdge(int index)
        {
            this.index = index;
        }

        public static bool operator ==(SurfaceMeshEdge v1, SurfaceMeshEdge v2)
        {
            return v1.index == v2.index;
        }

        public static bool operator !=(SurfaceMeshEdge v1, SurfaceMeshEdge v2)
        {
            return v1.index != v2.index;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SurfaceMeshEdge)) return false;
            SurfaceMeshEdge v = (SurfaceMeshEdge)obj;
            return this == v;
        }

        public bool Equals(SurfaceMeshEdge v)
        {
            return this == v;
        }

        public override int GetHashCode()
        {
            return index.GetHashCode();
        }
    }
}
