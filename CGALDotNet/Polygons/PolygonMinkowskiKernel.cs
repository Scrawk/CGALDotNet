using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    internal abstract class PolygonMinkowskiKernel : CGALObjectKernel
    {
        internal abstract IntPtr Create();

        internal abstract void Release(IntPtr ptr);

		internal abstract IntPtr MinkowskiSum(IntPtr polyPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSumPWH(IntPtr pwhPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSum_SSAB(IntPtr polyPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSum_OptimalConvex(IntPtr polyPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSum_HertelMehlhorn(IntPtr polyPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSum_GreeneConvex(IntPtr polyPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSum_Vertical(IntPtr polyPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSumPWH_Vertical(IntPtr pwhPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSum_Triangle(IntPtr polyPtr1, IntPtr polyPtr2);

		internal abstract IntPtr MinkowskiSumPWH_Triangle(IntPtr pwhPtr1, IntPtr polyPtr2);
	}

}
