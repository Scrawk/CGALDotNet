using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Eigen
{
    /// <summary>
    /// 
    /// </summary>
    public class EigenColumnVector : EigenVector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimension"></param>
        public EigenColumnVector(int dimension)
        {
            Ptr = EigenColumnVector_CreateVector(dimension);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public EigenColumnVector(double x, double y)
        {
            Ptr = EigenColumnVector_CreateVector(2);
            this[0] = x;
            this[1] = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public EigenColumnVector(double x, double y, double z)
        {
            Ptr = EigenColumnVector_CreateVector(3);
            this[0] = x;
            this[1] = y;
            this[2] = z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public EigenColumnVector(double x, double y, double z, double w)
        {
            Ptr = EigenColumnVector_CreateVector(4);
            this[0] = x;
            this[1] = y;
            this[2] = z;
            this[3] = w;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public EigenColumnVector(IList<double> list)
        {
            Ptr = EigenColumnVector_CreateVector(list.Count);
            for (int i = 0; i < list.Count; i++)
                this[i] = list[i];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal EigenColumnVector(IntPtr ptr) : base(ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public override double this[int i]
        {
            get { return EigenColumnVector_Get(Ptr, i); }
            set { EigenColumnVector_Set(Ptr, i, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public override int Dimension => EigenColumnVector_Dimension(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public override double Magnitude => EigenColumnVector_Norm(Ptr);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[EigenColumnVector: Dimension={0}]", Dimension);
        }

        /// <summary>
        /// 
        /// </summary>
        public EigenColumnVector Normalized => new EigenColumnVector(EigenColumnVector_Normalized(Ptr));

        /// <summary>
        /// 
        /// </summary>
        public EigenRowVector Transpose => new EigenRowVector(EigenColumnVector_Transpose(Ptr));

        /// <summary>
        /// 
        /// </summary>
        public EigenColumnVector Adjoint => new EigenColumnVector(EigenColumnVector_Adjoint(Ptr));

        /// <summary>
        /// 
        /// </summary>
        public EigenColumnVector Conjugate => new EigenColumnVector(EigenColumnVector_Conjugate(Ptr));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double Dot(EigenColumnVector v1, EigenColumnVector v2)
        {
            AreSameSize(v1, v2);
            return EigenColumnVector_Dot(v1.Ptr, v2.Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Normalize()
        {
            EigenColumnVector_Normalize(Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimension"></param>
        public override void Resize(int dimension)
        {
            EigenColumnVector_Resize(Ptr, dimension);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static EigenColumnVector Random(int dimension, double min, double max, int seed)
        {
            var ptr = EigenColumnVector_CreateVector(dimension);
            var v = new EigenColumnVector(ptr);
            var rnd = new Random(seed);
            double range = max - min;

            for (int i = 0; i < v.Dimension; i++)
                v[i] = min + rnd.NextDouble() * range;

            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void ReleasePtr()
        {
            EigenColumnVector_Release(Ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenColumnVector_CreateVector(int dimension);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void EigenColumnVector_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int EigenColumnVector_Rows(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int EigenColumnVector_Dimension(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double EigenColumnVector_Get(IntPtr ptr, int x);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void EigenColumnVector_Set(IntPtr ptr, int x, double value);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double EigenColumnVector_Dot(IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenColumnVector_Normalized(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void EigenColumnVector_Normalize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double EigenColumnVector_Norm(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenColumnVector_Transpose(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenColumnVector_Adjoint(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenColumnVector_Conjugate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void EigenColumnVector_Resize(IntPtr ptr, int dimension);
    }
}
