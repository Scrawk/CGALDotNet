using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polyhedra
{
    public struct PrimativeCount
    {
        public int degenerate;
        public int three;
        public int four;
        public int five;
        public int six;
        public int greater;

        public override string ToString()
        {
            return string.Format("[PrimativeCount: Degenerate={0}, Three={1}, Four={2}, Five={3}, Six={4}, Greater={5}]",
                degenerate, three, four, five, six, greater);
        }

    }
}
