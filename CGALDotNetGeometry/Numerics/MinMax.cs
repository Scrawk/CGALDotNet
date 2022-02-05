using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CGALDotNetGeometry.Numerics
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct MinMax
    {
        public double Min;
        public double Max;

        public override string ToString()
        {
            return String.Format("[MinMax: Min={0}, Max={1}]", Min, Max);
        }
    }

    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct MinMaxAvg
    {
        public double Min;
        public double Max;
        public double Average;

        public override string ToString()
        {
            return String.Format("[MinMax: Min={0}, Max={1}, Average={2}]", Min, Max, Average);
        }
    }
}
