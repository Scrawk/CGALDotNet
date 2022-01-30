using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Extensions
{
    public static class BoolExtensions
    {
        internal static BOOL_OR_UNDETERMINED ToBoolOrUndetermined(this bool e)
        {
            return e ? BOOL_OR_UNDETERMINED.TRUE : BOOL_OR_UNDETERMINED.FALSE;
        }
    }
}
