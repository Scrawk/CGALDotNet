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
                if (array[i] == CGALGlobal.NULL_INDEX)
                    return true;
            }

            return false;
        }
    }

}
