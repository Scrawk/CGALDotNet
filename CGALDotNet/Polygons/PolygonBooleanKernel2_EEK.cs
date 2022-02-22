using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CGALDotNet.Polygons
{
    internal class PolygonBooleanKernel2_EEK : PolygonBooleanKernel2
    {
        internal override string Name => "EEK";

        internal static readonly PolygonBooleanKernel2 Instance = new PolygonBooleanKernel2_EEK();

        internal override IntPtr Create()
        {
            return PolygonBoolean2_EEK_Create();
        }

        internal override void Release(IntPtr ptr)
        {
            PolygonBoolean2_EEK_Release(ptr);
        }

        internal override void ClearBuffer(IntPtr ptr)
        {
            PolygonBoolean2_EEK_ClearBuffer(ptr);
        }

        internal override IntPtr CopyBufferItem(IntPtr ptr, int index)
        {
            return PolygonBoolean2_EEK_CopyBufferItem(ptr, index);
        }

        internal override bool DoIntersect(IntPtr ptr, Polygon2 poly1, Polygon2 poly2)
        {
            return PolygonBoolean2_EEK_DoIntersect_P_P(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override bool DoIntersect(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_DoIntersect_P_PWH(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override bool DoIntersect(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_DoIntersect_PWH_PWH(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int Intersect(IntPtr ptr, Polygon2 poly1, Polygon2 poly2)
        {
            return PolygonBoolean2_EEK_Intersect_P_P(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int Intersect(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_Intersect_P_PWH(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int Intersect(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_Intersect_PWH_PWH(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override bool Join(IntPtr ptr, Polygon2 poly1, Polygon2 poly2, out IntPtr result)
        {
            return PolygonBoolean2_EEK_Join_P_P(ptr, poly1.Ptr, poly2.Ptr, out result);
        }

        internal override bool Join(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2, out IntPtr result)
        {
            return PolygonBoolean2_EEK_Join_P_PWH(ptr, poly1.Ptr, poly2.Ptr, out result);
        }

        internal override bool Join(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2, out IntPtr result)
        {
            return PolygonBoolean2_EEK_Join_PWH_PWH(ptr, poly1.Ptr, poly2.Ptr, out result);
        }

        internal override int Difference(IntPtr ptr, Polygon2 poly1, Polygon2 poly2)
        {
            return PolygonBoolean2_EEK_Difference_P_P(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int Difference(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_Difference_P_PWH(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int Difference(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_Difference_PWH_PWH(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int SymmetricDifference(IntPtr ptr, PolygonWithHoles2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_SymmetricDifference_PWH_PWH(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int SymmetricDifference(IntPtr ptr, Polygon2 poly1, Polygon2 poly2)
        {
            return PolygonBoolean2_EEK_SymmetricDifference_P_P(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int SymmetricDifference(IntPtr ptr, Polygon2 poly1, PolygonWithHoles2 poly2)
        {
            return PolygonBoolean2_EEK_SymmetricDifference_P_PWH(ptr, poly1.Ptr, poly2.Ptr);
        }

        internal override int Complement(IntPtr ptr, PolygonWithHoles2 poly)
        {
            return PolygonBoolean2_EEK_Complement_PWH(ptr, poly.Ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonBoolean2_EEK_Create();

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonBoolean2_EEK_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void PolygonBoolean2_EEK_ClearBuffer(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr PolygonBoolean2_EEK_CopyBufferItem(IntPtr ptr, int index);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_P_P(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_P_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonBoolean2_EEK_DoIntersect_PWH_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonBoolean2_EEK_Join_P_P(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2, out IntPtr result);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonBoolean2_EEK_Join_P_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2, out IntPtr result);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern bool PolygonBoolean2_EEK_Join_PWH_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2, out IntPtr result);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_Intersect_P_P(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_Intersect_P_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_Intersect_PWH_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_Difference_P_P(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_Difference_P_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_Difference_PWH_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_SymmetricDifference_P_P(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_SymmetricDifference_P_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_SymmetricDifference_PWH_PWH(IntPtr ptr0, IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int PolygonBoolean2_EEK_Complement_PWH(IntPtr ptr0, IntPtr ptr1);
    }
}
