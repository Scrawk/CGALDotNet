using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Eigen
{
    public class EigenMatrix : CGALObject
    {

		public EigenMatrix(int rows, int columns)
        {
			Ptr = EigenMatrix_Create(rows, columns);
        }

		internal EigenMatrix(IntPtr ptr) : base(ptr)
		{
;
		}

		public static EigenMatrix Identity(int rows, int columns)
        {
			var ptr = EigenMatrix_CreateIdentity(rows, columns);
			return new EigenMatrix(ptr);
		}

		public static EigenMatrix Random(int rows, int columns, double min, double max, int seed)
		{
			var ptr = EigenMatrix_Create(rows, columns);
			var m = new EigenMatrix(ptr);
			var rnd = new Random(seed);
			double range = max - min;

			for (int i = 0; i < m.Length; i++)
				m[i] = min + rnd.NextDouble() * range;

			return m;
		}

		public int Rows => EigenMatrix_Rows(Ptr);

		public int Columns => EigenMatrix_Columns(Ptr);

		public int Length => Rows * Columns;

		public double this[int i]
        {
			get { return EigenMatrix_GetX(Ptr, i);  }
			set { EigenMatrix_SetX(Ptr, i, value); }
		}

		public double this[int i, int j]
		{
			get { return EigenMatrix_GetXY(Ptr, i, j); }
			set { EigenMatrix_SetXY(Ptr, i, j, value); }
		}

		public override string ToString()
        {
            return String.Format("[EigenMatrix: Rows={0}, Columns={1}]", Rows, Columns);
        }

		public EigenMatrix Transpose
        {
            get
            {
				var ptr = EigenMatrix_Transpose(Ptr);
				return new EigenMatrix(ptr);
			}
        }

		public EigenMatrix Conjugate
		{
			get
			{
				var ptr = EigenMatrix_Conjugate(Ptr);
				return new EigenMatrix(ptr);
			}
		}

		public EigenMatrix Adjoint
		{
			get
			{
				var ptr = EigenMatrix_Adjoint(Ptr);
				return new EigenMatrix(ptr);
			}
		}

		public EigenMatrix Inverse
		{
			get
			{
				var ptr = EigenMatrix_Inverse(Ptr);
				return new EigenMatrix(ptr);
			}
		}

		public double Determinant => EigenMatrix_Determinant(Ptr);

		public double Trace => EigenMatrix_Trace(Ptr);

		public bool IsSquare => Rows == Columns;

		public bool IsIdentity => EigenMatrix_IsIdentity(Ptr);

		public bool IsDiagonal => EigenMatrix_IsDiagonal(Ptr);

		public bool IsUpperTriangular => EigenMatrix_IsUpperTriangular(Ptr);

		public bool IsLowerTriangular => EigenMatrix_IsLowerTriangular(Ptr);

		public static EigenMatrix operator *(EigenMatrix m, double s)
        {
			return new EigenMatrix(EigenMatrix_MulScalar(m.Ptr, s));
        }

		public static EigenMatrix operator /(EigenMatrix m, double s)
		{
			return new EigenMatrix(EigenMatrix_DivideScalar(m.Ptr, s));
		}

		public static EigenMatrix operator *(EigenMatrix m1, EigenMatrix m2)
		{
			IsValidProduct(m1, m2);
			return new EigenMatrix(EigenMatrix_MulMatrix(m1.Ptr, m2.Ptr));
		}

		public static EigenMatrix operator +(EigenMatrix m1, EigenMatrix m2)
		{
			AreSameSize(m1, m2);
			return new EigenMatrix(EigenMatrix_AddMatrix(m1.Ptr, m2.Ptr));
		}

		public static EigenMatrix operator -(EigenMatrix m1, EigenMatrix m2)
		{
			AreSameSize(m1, m2);
			return new EigenMatrix(EigenMatrix_SubMatrix(m1.Ptr, m2.Ptr));
		}

		public static EigenColumnVector operator *(EigenMatrix m, EigenColumnVector v)
		{
			IsValidProduct(m, v);
			return new EigenColumnVector(EigenMatrix_MulColumnVector(m.Ptr, v.Ptr));
		}

		public EigenMatrix Block(int startRox, int startCol, int blockRows, int blockCols)
        {
			var ptr = EigenMatrix_Block(Ptr, startRox, startCol, blockRows, blockCols);
			return new EigenMatrix(ptr);
		}

		public EigenMatrix Reshaped(int rows, int cols)
		{
			var ptr = EigenMatrix_Reshaped(Ptr, rows, cols);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector ColPivHouseholderQr(EigenColumnVector v)
        {
			IsValidProduct(this, v);
			var ptr = EigenMatrix_ColPivHouseholderQr(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenColumnVector PartialPivLu(EigenColumnVector v)
        {
			IsValidProduct(this, v);
			var ptr = EigenMatrix_PartialPivLu(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenColumnVector FullPivLu(EigenColumnVector v)
        {
			IsValidProduct(this, v);
			var ptr = EigenMatrix_FullPivLu(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenColumnVector HouseholderQr(EigenColumnVector v)
        {
			IsValidProduct(this, v);
			var ptr = EigenMatrix_HouseholderQr(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenColumnVector LLT(EigenColumnVector v)
        {
			IsValidProduct(this, v);
			var ptr = EigenMatrix_LLT(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenColumnVector BdcSvd(EigenColumnVector v)
        {
			IsValidProduct(this, v);
			var ptr = EigenMatrix_BdcSvd(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenColumnVector JacobiSvd(EigenColumnVector v)
        {
			IsValidProduct(this, v);
			var ptr = EigenMatrix_JacobiSvd(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		internal double RelativeError(EigenColumnVector v, EigenColumnVector x)
        {
			IsValidProduct(this, v);
			return EigenMatrix_RelativeError(Ptr, v.Ptr, x.Ptr);
        }

		public bool EigenValues(out EigenColumnVector values)
        {
			var ptr = EigenMatrix_Eigenvalues(Ptr);
			if(ptr != IntPtr.Zero)
            {
				values = new EigenColumnVector(ptr);
				return true;
			}
			else
            {
				values = null;
				return false;
            }
		}

		public bool EigenVectors(out EigenMatrix vectors)
		{
			var ptr = EigenMatrix_Eigenvectors(Ptr);
			if (ptr != IntPtr.Zero)
			{
				vectors = new EigenMatrix(ptr);
				return true;
			}
			else
			{
				vectors = null;
				return false;
			}
		}

		public EigenColumnVector GetRow(int i)
        {
			var v = new EigenColumnVector(Rows);
			for(int j = 0; j < Rows; j++)
				v[j] = this[j, i];

			return v;
        }

		public void SetRow(int i, EigenColumnVector v)
		{
			for(int j = 0; j < Rows; j++)
				this[j, i] = v[j];
		}

		public EigenColumnVector GetColumn(int i)
		{
			var v = new EigenColumnVector(Rows);
			for(int j = 0; j < Rows; j++)
				v[j] = this[i, j];

			return v;
		}

		public void SetColumn(int i, EigenColumnVector v)
		{
			for(int j = 0; j < Rows; j++)
				this[i, j] = v[j];
		}

		public void Round(int digits)
        {
			for(int i = 0; i < Length; i++)
				this[i] = Math.Round(this[i], digits);
        }

		public override void Print(StringBuilder builder)
        {
			builder.AppendLine(this.ToString());

			builder.AppendLine("Determinate " + Determinant);
			builder.AppendLine("Trace " + Trace);
			builder.AppendLine("IsIdentity " + IsIdentity);
			builder.AppendLine("IsSquare " + IsSquare);
			builder.AppendLine("IsUpperTriangular " + IsUpperTriangular);
			builder.AppendLine("IsLowerTriangular " + IsLowerTriangular);
			builder.AppendLine("IsDiagonal " + IsDiagonal);

			builder.AppendLine();

			for (int y = 0; y < Columns; y++)
            {
				for (int x = 0; x < Rows; x++)
				{
					builder.Append(this[x,y].ToString());

					if (x != Rows - 1)
						builder.Append(",");
				}

				builder.AppendLine();
			}
        }

		internal static void IsValidProduct(EigenMatrix m, EigenColumnVector v)
		{
			if (v.Dimension != m.Rows)
				throw new InvalidOperationException("Matrix must have same number of columns as vectors dimension.");
		}

		internal static void IsValidProduct(EigenMatrix m1, EigenMatrix m2)
		{
			if (m1.Columns != m2.Rows)
				throw new InvalidOperationException("Matrix1 must have same number of columns as matrix2 has rows.");
		}

		internal static void AreSameSize(EigenMatrix m1, EigenMatrix m2)
		{
			if (m1.Rows != m2.Rows)
				throw new InvalidOperationException("Matrix1 must be the same size as matrix2.");

			if (m1.Columns != m2.Columns)
				throw new InvalidOperationException("Matrix1 must be the same size as matrix2.");
		}

		protected override void ReleasePtr()
        {
            EigenMatrix_Release(Ptr);
        }


		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Create(int rows, int columns);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_CreateIdentity(int rows, int columns);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void EigenMatrix_Release(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int EigenMatrix_Rows(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern int EigenMatrix_Columns(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double EigenMatrix_GetXY(IntPtr ptr, int x, int y);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void EigenMatrix_SetXY(IntPtr ptr, int x, int y, double value);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double EigenMatrix_GetX(IntPtr ptr, int x);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern void EigenMatrix_SetX(IntPtr ptr, int x, double value);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Transpose(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Conjugate(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Adjoint(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Inverse(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double EigenMatrix_Determinant(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double EigenMatrix_Trace(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool EigenMatrix_IsIdentity(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool EigenMatrix_IsDiagonal(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool EigenMatrix_IsUpperTriangular(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool EigenMatrix_IsLowerTriangular(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_MulScalar(IntPtr ptr1, double s);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_DivideScalar(IntPtr ptr1, double s);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_MulMatrix(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_AddMatrix(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_SubMatrix(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_MulColumnVector(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Block(IntPtr ptr, int startRox, int startCol, int blockRows, int blockCols);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Reshaped(IntPtr ptr, int rows, int cols);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_ColPivHouseholderQr(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_PartialPivLu(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_FullPivLu(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_HouseholderQr(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_LLT(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_BdcSvd(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_JacobiSvd(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double EigenMatrix_RelativeError(IntPtr ptr1, IntPtr ptr2, IntPtr ptr3);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Eigenvalues(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Eigenvectors(IntPtr ptr);
	}
}
