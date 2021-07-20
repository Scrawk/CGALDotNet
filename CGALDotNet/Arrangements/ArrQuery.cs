using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Arrangements
{
    public enum ARR_LOCATOR
    {
        NONE,
        NAIVE,
        WALK,
        LANDMARKS,
        TRAPEZOID
    };

    public enum ARR_ELEMENT_HIT
    {
        NONE,
        VERTEX,
        HALF_EDGE,
        FACE
    };

    public struct ArrQuery
    {
        public ARR_ELEMENT_HIT Element;

        public int Index;

        public override string ToString()
        {
            return string.Format("[ArrQuery: Element={0}, Index={1}]", Element, Index);
        }
    }
 
}
