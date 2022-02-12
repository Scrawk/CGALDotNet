using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Polyhedra
{
    public struct MeshHitResult
    {
        public bool Hit => Face != CGALGlobal.NULL_INDEX;

        public int Face;

        public Point3d Point;

        public Point3d Coord;

        public override string ToString()
        {
            return String.Format("[MeshHitResult: Hit={0}, Face={1}, Point={2}, Coord={3}]",
                Hit, Face, Point, Coord);    
        }

        public static MeshHitResult NoHitResult
        {
            get
            {
                var result = new MeshHitResult();
                result.Face = CGALGlobal.NULL_INDEX;
                return result;
            }

        }
    }
}
