using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Extensions
{

    public static class ArrayExtension
    {
        public static bool IsFinite(this Point2d[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].IsFinite)
                    return false;
            }

            return true;
        }

        public static void MakeFinite(this Point2d[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].IsFinite)
                    array[i] = array[i].Finite;
            }
        }

        public static bool IsFinite(this Point3d[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].IsFinite)
                    return false;
            }

            return true;
        }

        public static void MakeFinite(this Point3d[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].IsFinite)
                    array[i] = array[i].Finite;
            }
        }

        public static bool IsFinite(this List<Point2d> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (!array[i].IsFinite)
                    return false;
            }

            return true;
        }

        public static void MakeFinite(this List<Point2d> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (!array[i].IsFinite)
                    array[i] = array[i].Finite;
            }
        }

        public static bool IsFinite(this List<Point3d> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (!array[i].IsFinite)
                    return false;
            }

            return true;
        }

        public static void MakeFinite(this List<Point3d> array)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (!array[i].IsFinite)
                    array[i] = array[i].Finite;
            }
        }

        public static bool HasNullIndex(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].IsNullIndex())
                    return true;
            }

            return false;
        }

        public static int[] RemoveNullTriangles(this int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length / 3; i++)
            {
                int i0 = array[i * 3 + 0];
                int i1 = array[i * 3 + 1];
                int i2 = array[i * 3 + 2];

                if (i0.IsNullIndex() ||
                    i1.IsNullIndex() ||
                    i2.IsNullIndex())
                    continue;

                count += 3;    
            }

            int j = 0;
            var new_array = new int[count];
            for (int i = 0; i < array.Length / 3; i++)
            {
                int i0 = array[i * 3 + 0];
                int i1 = array[i * 3 + 1];
                int i2 = array[i * 3 + 2];

                if (i0.IsNullIndex() ||
                    i1.IsNullIndex()  ||
                    i2.IsNullIndex())
                    continue;

                new_array[j * 3 + 0] = i0;
                new_array[j * 3 + 1] = i1;
                new_array[j * 3 + 2] = i2;

                j++;
            }

            return new_array;
        }

        public static int[] RemoveNullQuads(this int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length / 4; i++)
            {
                int i0 = array[i * 4 + 0];
                int i1 = array[i * 4 + 1];
                int i2 = array[i * 4 + 2];
                int i3 = array[i * 4 + 3];

                if (i0.IsNullIndex() ||
                    i1.IsNullIndex() ||
                    i2.IsNullIndex() ||
                    i3.IsNullIndex())
                    continue;

                count += 4;
            }

            int j = 0;
            var new_array = new int[count];
            for (int i = 0; i < array.Length / 4; i++)
            {
                int i0 = array[i * 4 + 0];
                int i1 = array[i * 4 + 1];
                int i2 = array[i * 4 + 2];
                int i3 = array[i * 4 + 3];

                if (i0.IsNullIndex() ||
                   i1.IsNullIndex() ||
                   i2.IsNullIndex() ||
                   i3.IsNullIndex())
                    continue;

                new_array[j * 4 + 0] = i0;
                new_array[j * 4 + 1] = i1;
                new_array[j * 4 + 2] = i2;
                new_array[j * 4 + 3] = i3;

                j++;
            }

            return new_array;
        }
    }

}
