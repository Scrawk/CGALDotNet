using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    internal sealed class PolygonBooleanKernel2_EEK : PolygonBooleanKernel2
    {

        internal static readonly PolygonBooleanKernel2 Instance = new PolygonBooleanKernel2_EEK();

        internal override string Name => "EEK";

        internal override void ClearBuffer()
        {
            PolygonBoolean2_EEK_ClearBuffer();
        }

        internal override IntPtr CopyBufferItem(int index)
        {
            return PolygonBoolean2_EEK_CopyBufferItem(index);
        }

        internal override bool DoIntersect(Polygon2 poly1, Polygon2 poly2)
        {
            return PolygonBoolean2_EEK_DoIntersect_P_P(poly1.Ptr, poly2.Ptr);
        }

        internal override bool DoIntersect(Polygon2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_DoIntersect_P_PWH(poly1.Ptr, poly2.Ptr);
        }

        internal override bool DoIntersect(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_DoIntersect_PWH_PWH(poly1.Ptr, poly2.Ptr);
        }

        internal override int Intersect(Polygon2 poly1, Polygon2 poly2)
        {
            return PolygonBoolean2_EEK_Intersect_P_P(poly1.Ptr, poly2.Ptr);
        }

        internal override int Intersect(Polygon2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_Intersect_P_PWH(poly1.Ptr, poly2.Ptr);
        }

        internal override int Intersect(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_Intersect_PWH_PWH(poly1.Ptr, poly2.Ptr);
        }

        internal override bool Join(Polygon2 poly1, Polygon2 poly2, out IntPtr result)
        {
            return PolygonBoolean2_EEK_Join_P_P(poly1.Ptr, poly2.Ptr, out result);
        }

        internal override bool Join(Polygon2 poly1, PolygonWithHoles2 poly2, out IntPtr result)
        {
            return PolygonBoolean2_EEK_Join_P_PWH(poly1.Ptr, poly2.Ptr, out result);
        }

        internal override bool Join(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2, out IntPtr result)
        {
            return PolygonBoolean2_EEK_Join_PWH_PWH(poly1.Ptr, poly2.Ptr, out result);
        }

        internal override int Difference(Polygon2 poly1, Polygon2 poly2)
        {
            return PolygonBoolean2_EEK_Difference_P_P(poly1.Ptr, poly2.Ptr);
        }

        internal override int Difference(Polygon2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_Difference_P_PWH(poly1.Ptr, poly2.Ptr);
        }

        internal override int Difference(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_Difference_PWH_PWH(poly1.Ptr, poly2.Ptr);
        }

        internal override int SymmetricDifference(PolygonWithHoles2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_SymmetricDifference_PWH_PWH(poly1.Ptr, poly2.Ptr);
        }

        internal override int SymmetricDifference(Polygon2 poly1, Polygon2 poly2)
        {
            return PolygonBoolean2_EEK_SymmetricDifference_P_P(poly1.Ptr, poly2.Ptr);
        }

        internal override int SymmetricDifference(Polygon2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_SymmetricDifference_P_PWH(poly1.Ptr, poly2.Ptr);
        }

        internal override int Complement(PolygonWithHoles2 poly)
        {
            return PolygonBoolean2_EEK_Complement_PWH(poly.Ptr);
        }

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void PolygonBoolean2_EEK_ClearBuffer();

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr PolygonBoolean2_EEK_CopyBufferItem(int index);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_P_P(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_P_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_PWH_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_Join_P_P(IntPtr ptr1, IntPtr ptr2, out IntPtr result);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_Join_P_PWH(IntPtr ptr1, IntPtr ptr2, out IntPtr result);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool PolygonBoolean2_EEK_Join_PWH_PWH(IntPtr ptr1, IntPtr ptr2, out IntPtr result);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_Intersect_P_P(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_Intersect_P_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_Intersect_PWH_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_Difference_P_P(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_Difference_P_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_Difference_PWH_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_SymmetricDifference_P_P(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_SymmetricDifference_P_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_SymmetricDifference_PWH_PWH(IntPtr ptr1, IntPtr ptr2);

        [DllImport("CGALWrapper.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int PolygonBoolean2_EEK_Complement_PWH(IntPtr ptr);
    }
}
