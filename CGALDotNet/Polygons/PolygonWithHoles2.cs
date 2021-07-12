using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public class PolygonWithHoles2 : CGALObject
    {
        public PolygonWithHoles2()
        {

        }

        internal PolygonWithHoles2(IntPtr ptr) : base(ptr)
        {

        }

        protected override void ReleasePtr()
        {
            PolygonWithHoles2_EEK_Release(Ptr);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonWithHoles2_EEK_Release(IntPtr ptr);
    }
}
