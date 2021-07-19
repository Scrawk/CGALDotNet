using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Arrangements
{
    public enum ARR_LOCATOR
    {
        NAIVE = 0,
        WALK = 1,
        LANDMARKS = 2,
        TRAPEZOID = 3
    };

    public struct ArrPointQueryResult
    {
        public ARR_ELEMENT Element;
        public int Index;

        public override string ToString()
        {
            return string.Format("[ArrPointQueryResult: Element={0}, Index={1}]", Element, Index);
        }
    }
 
}
