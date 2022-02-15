using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Eigen
{
    public class EigenRowVector : EigenVector
    {

        public EigenRowVector(int dimension)
        {
            Ptr = EigenRowVector_CreateVector(dimension);
        }

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

        public EigenRowVector(double x, double y, double z, double w)
        {
            Ptr = EigenRowVector_CreateVector(4);
            this[0] = x;
            this[1] = y;
            this[2] = z;
            this[3] = w;
        }

        public EigenRowVector(IList<double> list)
        {
            Ptr = EigenRowVector_CreateVector(list.Count);
            for(int i = 0; i < list.Count; i++)    
                this[i] = list[i];
        }

        internal EigenRowVector(IntPtr ptr) : base(ptr)
        {

        }

        public override double this[int i]
        {
            get { return EigenRowVector_Get(Ptr, i); }
            set { EigenRowVector_Set(Ptr, i, value); }
        }

        public override int Dimension => EigenRowVector_Dimension(Ptr);

        public override double Magnitude => EigenRowVector_Norm(Ptr);

        public override string ToString()
        {
            return String.Format("[EigenRowVector: Dimension={0}]", Dimension);
        }

        public EigenRowVector Normalized => new EigenRowVector(EigenRowVector_Normalized(Ptr));

        public EigenColumnVector Transpose => new EigenColumnVector(EigenRowVector_Transpose(Ptr));

        public EigenRowVector Adjoint => new EigenRowVector(EigenRowVector_Adjoint(Ptr));

        public EigenRowVector Conjugate => new EigenRowVector(EigenRowVector_Conjugate(Ptr));

        public static double Dot(EigenRowVector v1, EigenRowVector v2)
        {
            AreSameSize(v1, v2);
            return EigenRowVector_Dot(v1.Ptr, v2.Ptr);
        }

        public override void Normalize()
        {
            EigenRowVector_Normalize(Ptr);
        }

        public override void Resize(int dimension)
        {
            EigenRowVector_Resize(Ptr, dimension);
        }

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
