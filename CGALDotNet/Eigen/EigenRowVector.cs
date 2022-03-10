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
    public class EigenRowVector : EigenVector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimension"></param>
        public EigenRowVector(int dimension)
        {
            Ptr = EigenRowVector_CreateVector(dimension);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public EigenRowVector(double x, double y)
        {
            Ptr = EigenRowVector_CreateVector(2);
            this[0] = x;
            this[1] = y;
        }

        public EigenRowVector(double x, double y, double z)
        {
            Ptr = EigenRowVector_CreateVector(3);
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
        public EigenRowVector(double x, double y, double z, double w)
        {
            Ptr = EigenRowVector_CreateVector(4);
            this[0] = x;
            this[1] = y;
            this[2] = z;
            this[3] = w;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public EigenRowVector(IList<double> list)
        {
            Ptr = EigenRowVector_CreateVector(list.Count);
            for(int i = 0; i < list.Count; i++)    
                this[i] = list[i];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal EigenRowVector(IntPtr ptr) : base(ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public override double this[int i]
        {
            get { return EigenRowVector_Get(Ptr, i); }
            set { EigenRowVector_Set(Ptr, i, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public override int Dimension => EigenRowVector_Dimension(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public override double Magnitude => EigenRowVector_Norm(Ptr);

        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("[EigenRowVector: Dimension={0}]", Dimension);
        }

        /// <summary>
        /// 
        /// </summary>
        public EigenRowVector Normalized => new EigenRowVector(EigenRowVector_Normalized(Ptr));

        /// <summary>
        /// 
        /// </summary>
        public EigenColumnVector Transpose => new EigenColumnVector(EigenRowVector_Transpose(Ptr));

        /// <summary>
        /// 
        /// </summary>
        public EigenRowVector Adjoint => new EigenRowVector(EigenRowVector_Adjoint(Ptr));
        
        /// <summary>
        /// 
        /// </summary>
        public EigenRowVector Conjugate => new EigenRowVector(EigenRowVector_Conjugate(Ptr));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double Dot(EigenRowVector v1, EigenRowVector v2)
        {
            AreSameSize(v1, v2);
            return EigenRowVector_Dot(v1.Ptr, v2.Ptr);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Normalize()
        {
            EigenRowVector_Normalize(Ptr);
        }

        public override void Resize(int dimension)
        {
            EigenRowVector_Resize(Ptr, dimension);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimension"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static EigenRowVector Random(int dimension, double min, double max, int seed)
        {
            var ptr = EigenRowVector_CreateVector(dimension);
            var v = new EigenRowVector(ptr);
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
            EigenRowVector_Release(Ptr);
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenRowVector_CreateVector(int dimension);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void EigenRowVector_Release(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int EigenRowVector_Rows(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern int EigenRowVector_Dimension(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double EigenRowVector_Get(IntPtr ptr, int x);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void EigenRowVector_Set(IntPtr ptr, int x, double value);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double EigenRowVector_Dot(IntPtr ptr1, IntPtr ptr2);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenRowVector_Normalized(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void EigenRowVector_Normalize(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern double EigenRowVector_Norm(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenRowVector_Transpose(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenRowVector_Adjoint(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern IntPtr EigenRowVector_Conjugate(IntPtr ptr);

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void EigenRowVector_Resize(IntPtr ptr, int dimension);
    }
}
