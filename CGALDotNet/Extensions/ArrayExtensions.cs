using System;
using System.Collections.Generic;

using CGALDotNet.Triangulations;

namespace CGALDotNet.Extensions
{
    public static class ArrayExtensions
    {
        public static void Round(this TriVertex2[] array, int digits)
        {
            if (digits < 0) return;
            for (int i = 0; i < array.Length; i++)
            {
                var p = array[i].Point;
                array[i].Point = p.Rounded(digits);
            }
        }

        public static void Round(this TriVertex3[] array, int digits)
        {
            if (digits < 0) return;
            for (int i = 0; i < array.Length; i++)
            {
                var p = array[i].Point;
                array[i].Point = p.Rounded(digits);
            }     
        }

    }
}
