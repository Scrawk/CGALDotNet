using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Extensions
{
    public static class PrimativeExtensions
    {
        internal static BOOL_OR_UNDETERMINED ToBoolOrUndetermined(this bool b)
        {
            return b ? BOOL_OR_UNDETERMINED.TRUE : BOOL_OR_UNDETERMINED.FALSE;
        }

    }
}
