using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Extensions
{
    public static class EnumExtensions
    {
        internal static bool ToBool(this BOOL_OR_UNDETERMINED e)
        {
            return e == BOOL_OR_UNDETERMINED.TRUE;
        }
    }
}
