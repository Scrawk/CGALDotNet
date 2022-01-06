using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.PolyHedra
{
    public struct SurfaceMeshHalfedge : IEquatable<SurfaceMeshHalfedge>
    {
        internal int index;

        public SurfaceMeshHalfedge(int index)
        {
            this.index = index;
        }

        public static bool operator ==(SurfaceMeshHalfedge v1, SurfaceMeshHalfedge v2)
        {
            return v1.index == v2.index;
        }

        public static bool operator !=(SurfaceMeshHalfedge v1, SurfaceMeshHalfedge v2)
        {
            return v1.index != v2.index;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SurfaceMeshHalfedge)) return false;
            SurfaceMeshHalfedge v = (SurfaceMeshHalfedge)obj;
            return this == v;
        }

        public bool Equals(SurfaceMeshHalfedge v)
        {
            return this == v;
        }

        public override int GetHashCode()
        {
            return index.GetHashCode();
        }
    }
}
