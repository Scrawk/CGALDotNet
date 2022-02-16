using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using CGALDotNetGeometry.Numerics;
using CGALDotNetGeometry.Shapes;

namespace CGALDotNet.Eigen
{
	public enum EIGEN_SOLVER
    {
		COL_PIV_HOUSEHOLDER_QR,
		PARTIAL_PIV_LU,
		FULL_PIV_LU,
		HOUSEHOLDER_QR,
		LLT,
		LDLT,
		BDCSVD,
		JACOBI_SVD,
		FULL_PIV_HOUSEHOLDER_QR,
		COMPLETE_ORTH_DECOM
	}

	public class EigenMatrix : CGALObject
	{
		/// <summary>
		/// Create a new matrix filled with zeros.
		/// </summary>
		/// <param name="rows">The number of rows.</param>
		/// <param name="columns">The number of columns.</param>
		public EigenMatrix(int rows, int columns)
		{
			if (rows <= 0)
				throw new ArgumentException("Row vectors count can not be <= zero.");

			if (columns <= 0)
				throw new ArgumentException("Column vectors count can not be <= zero.");

			Ptr = EigenMatrix_Create(rows, columns);
		}

		/// <summary>
		/// Create a new matrix fill with the array contents.
		/// </summary>
		/// <param name="array">The array.</param>
		public EigenMatrix(double[,] array)
		{
			int rowsCount = array.GetLength(0);
			int columnsCount = array.GetLength(1);

			if (rowsCount == 0)
				throw new ArgumentException("Row vectors count can not be zero.");

			if (columnsCount == 0)
				throw new ArgumentException("Column vectors count can not be zero.");

			Ptr = EigenMatrix_Create(rowsCount, columnsCount);

			for (int i = 0; i < rowsCount; i++)
			{
				for (int j = 0; j < columnsCount; j++)
				{
					this[i, j] = array[i, j];
				}
			}
		}

		/// <summary>
		/// Create a new matrix filled with the contents of the column vectors.
		/// All column vectors must have the same dimension.
		/// </summary>
		/// <param name="columns"></param>
		public EigenMatrix(IList<EigenColumnVector> columns)
		{
			if (columns.Count == 0)
				throw new ArgumentException("Column vectors count can not be zero.");

			int rowsCount = columns.Count;
			int columnsCount = columns[0].Dimension;
			Ptr = EigenMatrix_Create(rowsCount, columnsCount);

			for (int i = 0; i < rowsCount; i++)
			{
				if (columns[i].Dimension != columnsCount)
					throw new ArgumentException("Column vector is not the same size as fisrt column vector.");

				for (int j = 0; j < columnsCount; j++)
				{
					this[i, j] = columns[i][j];
				}
			}
		}

		/// <summary>
		/// Create a new matrix from a pointer.
		/// </summary>
		/// <param name="ptr"></param>
		internal EigenMatrix(IntPtr ptr) : base(ptr)
		{
			
		}

		/// <summary>
		/// Create a identity matrix.
		/// </summary>
		/// <param name="size">The number of rows and columns of the matrix. Must be square.</param>
		/// <returns>The identity matrix.</returns>
		public static EigenMatrix Identity(int size)
		{
			if (size <= 0)
				throw new ArgumentException("Size can not be <= zero.");

			var ptr = EigenMatrix_CreateIdentity(size, size);
			return new EigenMatrix(ptr);
		}

		/// <summary>
		/// Create a new matrix fill with random numbers.
		/// </summary>
		/// <param name="rows">The number of rows.</param>
		/// <param name="columns">The number columns.</param>
		/// <param name="min">The minimum random number generated.</param>
		/// <param name="max">The maximum random number generated.</param>
		/// <param name="seed">The random generators seed.</param>
		/// <returns>The matrix.</returns>
		public static EigenMatrix Random(int rows, int columns, double min, double max, int seed)
		{
			var m = new EigenMatrix(rows, columns);
			var rnd = new Random(seed);
			double range = max - min;

			for (int i = 0; i < m.Length; i++)
				m[i] = min + rnd.NextDouble() * range;

			return m;
		}

		/// <summary>
		/// The number of rows in the matrix.
		/// </summary>
		public int Rows => EigenMatrix_Rows(Ptr);

		/// <summary>
		/// The number of columns in the matrix.
		/// </summary>
		public int Columns => EigenMatrix_Columns(Ptr);

		/// <summary>
		/// The total size of the matrix which is 
		/// the rows times the number of columns.
		/// </summary>
		public int Length => Rows * Columns;

		/// <summary>
		/// The single dimension array accessor.
		/// </summary>
		/// <param name="i">The array index.</param>
		/// <returns>The value at the index i.</returns>
		public double this[int i]
		{
			get { return EigenMatrix_GetX(Ptr, i); }
			set { EigenMatrix_SetX(Ptr, i, value); }
		}

		/// <summary>
		/// The double dimension array accessor.
		/// </summary>
		/// <param name="i">The row index.</param>
		/// <param name="j">The column index.</param>
		/// <returns>The value at the index i,j.</returns>
		public double this[int i, int j]
		{
			get { return EigenMatrix_GetXY(Ptr, i, j); }
			set { EigenMatrix_SetXY(Ptr, i, j, value); }
		}

		/// <summary>
		/// The matrix string info.
		/// </summary>
		/// <returns>The matrix string info.</returns>
		public override string ToString()
		{
			return String.Format("[EigenMatrix: Rows={0}, Columns={1}]", Rows, Columns);
		}

		/// <summary>
		/// The matrix transposed.
		/// Flips a matrix over its diagonal that is, 
		/// it switches the row and column indices of the matrix.
		/// </summary>
		public EigenMatrix Transpose
		{
			get
			{
				var ptr = EigenMatrix_Transpose(Ptr);
				return new EigenMatrix(ptr);
			}
		}

		/// <summary>
		/// The matrices conjugate.
		/// The matrix obtained by replacing each element a(ij) with its complex conjugate, A^=(a^(ij)).
		/// </summary>
		public EigenMatrix Conjugate
		{
			get
			{
				var ptr = EigenMatrix_Conjugate(Ptr);
				return new EigenMatrix(ptr);
			}
		}

		/// <summary>
		/// The matrices adjoint.
		/// The transpose of its cofactor matrix.
		/// </summary>
		public EigenMatrix Adjoint
		{
			get
			{
				var ptr = EigenMatrix_Adjoint(Ptr);
				return new EigenMatrix(ptr);
			}
		}

		/// <summary>
		/// Is the matrix invertible.
		/// </summary>
		public bool IsInvertible
		{
			get
			{
				if(IsSquare) return false;
				return EigenMatrix_IsInvertible(Ptr);
			}
		}

		/// <summary>
		/// The inverse of a square matrix A, 
		/// sometimes called a reciprocal matrix, 
		/// is a matrix A^(-1) such that AA^(-1)=I.
		/// DOes not check if the matrix is invertible.
		/// </summary>
		public EigenMatrix Inverse
		{
			get
			{
				CheckIfSqaure(this);
				var ptr = EigenMatrix_Inverse(Ptr);
				return new EigenMatrix(ptr);
			}
		}

		/// <summary>
		/// The determinant is a scalar value that is a 
		/// function of the entries of a square matrix.
		/// </summary>
		public double Determinant
		{
			get
			{
				CheckIfSqaure(this);
				return EigenMatrix_Determinant(Ptr);
			}
		}

		/// <summary>
		/// The trace of a square matrix is defined to be the 
		/// sum of elements on the main diagonal from the upper left to the lower right.
		/// </summary>
		public double Trace
        {
			get
			{
				CheckIfSqaure(this);
				return EigenMatrix_Trace(Ptr);
			}
		}

		/// <summary>
		/// A square matrix has the same number of rows and columns.
		/// </summary>
		public bool IsSquare => Rows == Columns;

		/// <summary>
		/// A diagonal matrix is a matrix in which the entries 
		/// outside the main diagonal are all zero.
		/// </summary>
		public bool IsDiagonal => EigenMatrix_IsDiagonal(Ptr);

		/// <summary>
		/// A square matrix is called upper triangular 
		/// if all the entries below the main diagonal are zero.
		/// </summary>
		public bool IsUpperTriangular => EigenMatrix_IsUpperTriangular(Ptr);

		/// <summary>
		/// A square matrix is called lower triangular 
		/// if all the entries above the main diagonal are zero.
		/// </summary>
		public bool IsLowerTriangular => EigenMatrix_IsLowerTriangular(Ptr);

		/// <summary>
		/// Multiple each component in matrix by the scalar.
		/// </summary>
		/// <param name="m">The matrix.</param>
		/// <param name="s">The scalar.</param>
		/// <returns>The matrix with each component multiplied by the scalar.</returns>
		public static EigenMatrix operator *(EigenMatrix m, double s)
		{
			return new EigenMatrix(EigenMatrix_MulScalar(m.Ptr, s));
		}

		/// <summary>
		/// Divide each component in matrix by the scalar.
		/// </summary>
		/// <param name="m">The matrix.</param>
		/// <param name="s">The scalar.</param>
		/// <returns>The matrix with each component divided by the scalar.</returns>
		public static EigenMatrix operator /(EigenMatrix m, double s)
		{
			return new EigenMatrix(EigenMatrix_DivideScalar(m.Ptr, s));
		}

		/// <summary>
		/// Multiple the two matrices.
		/// The first matrices number of columns must 
		/// the same as the second matrices number of rows.
		/// </summary>
		/// <param name="m1">The first matrix.</param>
		/// <param name="m2">The second matrix.</param>
		/// <returns>The product matrix.</returns>
		public static EigenMatrix operator *(EigenMatrix m1, EigenMatrix m2)
		{
			IsValidProduct(m1, m2);
			return new EigenMatrix(EigenMatrix_MulMatrix(m1.Ptr, m2.Ptr));
		}

		/// <summary>
		/// Add two matrices.
		/// The matrices must be the same size.
		/// </summary>
		/// <param name="m1">The first matrix.</param>
		/// <param name="m2">The second matrix.</param>
		/// <returns>A matrix where each compoent is the sum of the other two matrices.</returns>
		public static EigenMatrix operator +(EigenMatrix m1, EigenMatrix m2)
		{
			AreSameSize(m1, m2);
			return new EigenMatrix(EigenMatrix_AddMatrix(m1.Ptr, m2.Ptr));
		}

		/// <summary>
		/// Subtract two matrices.
		/// The matrices must be the same size.
		/// </summary>
		/// <param name="m1">The first matrix.</param>
		/// <param name="m2">The second matrix.</param>
		/// <returns>A matrix where each compoent is the difference of the other two matrices.</returns>
		public static EigenMatrix operator -(EigenMatrix m1, EigenMatrix m2)
		{
			AreSameSize(m1, m2);
			return new EigenMatrix(EigenMatrix_SubMatrix(m1.Ptr, m2.Ptr));
		}

		/// <summary>
		/// Multiple a matrix and a column vector.
		/// </summary>
		/// <param name="m">The matrix.</param>
		/// <param name="v">The column vector.</param>
		/// <returns>The product column vector.</returns>
		public static EigenColumnVector operator *(EigenMatrix m, EigenColumnVector v)
		{
			IsValidProduct(m, v);
			return new EigenColumnVector(EigenMatrix_MulColumnVector(m.Ptr, v.Ptr));
		}

		/// <summary>
		/// Is this matrix the identity matrix.
		/// </summary>
		/// <param name="eps">The threshold the values in the 
		/// matrix can be to the expected value.</param>
		/// <returns>Is this matrix the identity matrix.</returns>
		public bool IsIdentity(double eps = MathUtil.DEG_TO_RAD_64)
		{
			if (!IsSquare) return false;

			for (int y = 0; y < Columns; y++)
			{
				for (int x = 0; x < Rows; x++)
				{
					if (x == y)
					{
						if (!MathUtil.IsOne(this[x, y], eps))
							return false;
					}
					else
					{
						if (!MathUtil.IsZero(this[x, y], eps))
							return false;
					}
				}
			}

			return true;
		}

		/// <summary>
		/// Is this matrix filled with zeros.
		/// </summary>
		/// <param name="eps">The threshold the values in the 
		/// matrix can be to the expected value.</param>
		/// <returns>Is this matrix filled with zeros.</returns>
		public bool IsZero(double eps = MathUtil.DEG_TO_RAD_64)
		{
			for (int y = 0; y < Columns; y++)
			{
				for (int x = 0; x < Rows; x++)
				{
					if (!MathUtil.IsZero(this[x, y], eps))
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Are all the values in this matrix positive.
		/// </summary>
		/// <returns>Are all the values in this matrix positive.</returns>
		public bool IsPositive()
		{
			for (int y = 0; y < Columns; y++)
			{
				for (int x = 0; x < Rows; x++)
				{
					if (this[x, y] < 0)
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Does the matrix have a component that is nan.
		/// </summary>
		/// <returns>Does the matrix have a component that is nan.</returns>
		public bool HasNAN()
		{
			for (int y = 0; y < Columns; y++)
			{
				for (int x = 0; x < Rows; x++)
				{
					if (double.IsNaN(this[x, y]))
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Replaces all nan values in the matrix with 0.
		/// </summary>
		public void NoNAN()
		{
			for (int y = 0; y < Columns; y++)
			{
				for (int x = 0; x < Rows; x++)
				{
					if (double.IsNaN(this[x, y]))
						this[x, y] = 0;
				}
			}
		}

		/// <summary>
		/// Are all the values in the matrix finite (non-infinite and non-nan).
		/// </summary>
		/// <returns>Are all the values in the matrix finite (non-infinite and non-nan).</returns>
		public bool IsFinite()
		{
			for (int y = 0; y < Columns; y++)
			{
				for (int x = 0; x < Rows; x++)
				{
					if (!MathUtil.IsFinite(this[x, y]))
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Replaces all infinite and nan values in matrix with 0.
		/// </summary>
		public void MakeFinite()
		{
			for (int y = 0; y < Columns; y++)
			{
				for (int x = 0; x < Rows; x++)
				{
					if (!MathUtil.IsFinite(this[x, y]))
						this[x, y] = 0;
				}
			}
		}

		/// <summary>
		/// Are all the values in the matrix the same.
		/// </summary>
		/// <param name="eps">The threshold the values in the 
		/// matrix can be to the expected value.</param>
		/// <returns>Are all the values in the matrix the same.</returns>
		public bool IsConst(double eps = MathUtil.EPS_64)
		{
			var value = this[0];
			for (int y = 0; y < Columns; y++)
			{
				for (int x = 0; x < Rows; x++)
				{
					if (!MathUtil.AlmostEqual(this[x, y], value, eps))
						return false;
				}
			}

			return true;
		}

		/// <summary>
		/// Create a sub matrix from this matrix.
		/// </summary>
		/// <param name="startRow">The row to start at.</param>
		/// <param name="startCol">THe column to start at.</param>
		/// <param name="rows">The number of rows.</param>
		/// <param name="cols">The number of columns.</param>
		/// <returns>A sub matrix from this matrix.</returns>
		public EigenMatrix SubMatrix(int startRow, int startCol, int rows, int cols)
		{
			var ptr = EigenMatrix_Block(Ptr, startRow, startCol, rows, cols);
			return new EigenMatrix(ptr);
		}

		/// <summary>
		/// Create a sub matrix from this matrix.
		/// </summary>
		/// <param name="rows">The number of rows.</param>
		/// <param name="cols">The number of columns.</param>
		/// <returns>A sub matrix from this matrix.</returns>
		public EigenMatrix SubMatrix(int rows, int cols)
		{
			var ptr = EigenMatrix_Reshaped(Ptr, rows, cols);
			return new EigenMatrix(ptr);
		}

		/// <summary>
		/// Solve the linear system.
		/// </summary>
		/// <param name="v">The vector to solve.</param>
		/// <param name="solver">The solver type.</param>
		/// <returns>The solution vector.</returns>
		public EigenColumnVector Solve(EigenColumnVector v, EIGEN_SOLVER solver = EIGEN_SOLVER.COL_PIV_HOUSEHOLDER_QR)
		{
            switch (solver)
            {
                case EIGEN_SOLVER.COL_PIV_HOUSEHOLDER_QR:
					return ColPivHouseholderQr(v);
                case EIGEN_SOLVER.PARTIAL_PIV_LU:
					return PartialPivLu(v);
                case EIGEN_SOLVER.FULL_PIV_LU:
					return FullPivLu(v);	
                case EIGEN_SOLVER.HOUSEHOLDER_QR:
					return HouseholderQr(v);	
                case EIGEN_SOLVER.LLT:
					return LLT(v);
                case EIGEN_SOLVER.LDLT:
					return LDLT(v);
                case EIGEN_SOLVER.BDCSVD:
					return BdcSvd(v);
                case EIGEN_SOLVER.JACOBI_SVD:
                    return JacobiSvd(v);
				case EIGEN_SOLVER.FULL_PIV_HOUSEHOLDER_QR:
					return FullPivHouseholderQR(v);
				case EIGEN_SOLVER.COMPLETE_ORTH_DECOM:
					return CompleteOrthogonalDecomposition(v);
				default:
					return ColPivHouseholderQr(v);
            }
        }

		/// <summary>
		/// Solve the linear system.
		/// </summary>
		/// <param name="v">The vector to solve.</param>
		/// <param name="solver">The solver type.</param>
		/// <returns>The solution vector.</returns>
		public EigenMatrix Solve(EigenMatrix v, EIGEN_SOLVER solver = EIGEN_SOLVER.COL_PIV_HOUSEHOLDER_QR)
		{
			switch (solver)
			{
				case EIGEN_SOLVER.COL_PIV_HOUSEHOLDER_QR:
					return ColPivHouseholderQr(v);
				case EIGEN_SOLVER.PARTIAL_PIV_LU:
					return PartialPivLu(v);
				case EIGEN_SOLVER.FULL_PIV_LU:
					return FullPivLu(v);
				case EIGEN_SOLVER.HOUSEHOLDER_QR:
					return HouseholderQr(v);
				case EIGEN_SOLVER.LLT:
					return LLT(v);
				case EIGEN_SOLVER.LDLT:
					return LDLT(v);
				case EIGEN_SOLVER.BDCSVD:
					return BdcSvd(v);
				case EIGEN_SOLVER.JACOBI_SVD:
					return JacobiSvd(v);
				case EIGEN_SOLVER.FULL_PIV_HOUSEHOLDER_QR:
					return FullPivHouseholderQR(v);
				case EIGEN_SOLVER.COMPLETE_ORTH_DECOM:
					return CompleteOrthogonalDecomposition(v);
				default:
					return ColPivHouseholderQr(v);
			}
		}

		public EigenColumnVector ColPivHouseholderQr(EigenColumnVector v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_ColPivHouseholderQr_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix ColPivHouseholderQr(EigenMatrix m)
		{
			IsValidProduct(this, m);
			var ptr = EigenMatrix_ColPivHouseholderQr_Mat(Ptr, m.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector PartialPivLu(EigenColumnVector v)
		{
			IsValidProduct(this, v);

			if (!IsInvertible)
				throw new InvalidOperationException("Matrix must be invertible for PartialPivLu solver.");

			var ptr = EigenMatrix_PartialPivLu_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix PartialPivLu(EigenMatrix v)
		{
			IsValidProduct(this, v);

			if (!IsInvertible)
				throw new InvalidOperationException("Matrix must be invertible for PartialPivLu solver.");

			var ptr = EigenMatrix_PartialPivLu_Mat(Ptr, v.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector FullPivLu(EigenColumnVector v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_FullPivLu_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix FullPivLu(EigenMatrix v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_FullPivLu_Mat(Ptr, v.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector HouseholderQr(EigenColumnVector v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_HouseholderQr_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix HouseholderQr(EigenMatrix v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_HouseholderQr_Mat(Ptr, v.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector LLT(EigenColumnVector v)
		{
			IsValidProduct(this, v);

			if (!IsPositive())
				throw new InvalidOperationException("Matrix must be positive for LLT solver.");

			var ptr = EigenMatrix_LLT_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix LLT(EigenMatrix v)
		{
			IsValidProduct(this, v);

			if (!IsPositive())
				throw new InvalidOperationException("Matrix must be positive for LLT solver.");

			var ptr = EigenMatrix_LLT_Mat(Ptr, v.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector LDLT(EigenColumnVector v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_LDLT_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix LDLT(EigenMatrix m)
		{
			IsValidProduct(this, m);
			var ptr = EigenMatrix_LDLT_Mat(Ptr, m.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector BdcSvd(EigenColumnVector v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_BdcSvd_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix BdcSvd(EigenMatrix v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_BdcSvd_Mat(Ptr, v.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector JacobiSvd(EigenColumnVector v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_JacobiSvd_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix JacobiSvd(EigenMatrix v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_JacobiSvd_Mat(Ptr, v.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector FullPivHouseholderQR(EigenColumnVector v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_FullPivHouseholderQr_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix FullPivHouseholderQR(EigenMatrix v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_FullPivHouseholderQr_Mat(Ptr, v.Ptr);
			return new EigenMatrix(ptr);
		}

		public EigenColumnVector CompleteOrthogonalDecomposition(EigenColumnVector v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_CompleteOrthogonalDecomposition_Vec(Ptr, v.Ptr);
			return new EigenColumnVector(ptr);
		}

		public EigenMatrix CompleteOrthogonalDecomposition(EigenMatrix v)
		{
			IsValidProduct(this, v);
			var ptr = EigenMatrix_CompleteOrthogonalDecomposition_Mat(Ptr, v.Ptr);
			return new EigenMatrix(ptr);
		}

		/// <summary>
		/// Find the relative error from the linear system.
		/// </summary>
		/// <param name="v">The vector that was solved.</param>
		/// <param name="x">The vector that was the solution.</param>
		/// <returns>The relative error.</returns>
		public double RelativeError(EigenColumnVector v, EigenColumnVector x)
		{
			IsValidProduct(this, v);
			return EigenMatrix_RelativeError_Vec(Ptr, v.Ptr, x.Ptr);
		}

		/// <summary>
		/// Find the relative error from the linear system.
		/// </summary>
		/// <param name="v">The vector that was solved.</param>
		/// <param name="x">The vector that was the solution.</param>
		/// <returns>The relative error.</returns>
		public double RelativeError(EigenMatrix v, EigenMatrix x)
		{
			IsValidProduct(this, v);
			return EigenMatrix_RelativeError_Mat(Ptr, v.Ptr, x.Ptr);
		}

		/// <summary>
		/// Find the eigen values of the matrix.
		/// </summary>
		/// <param name="values">The eigen values if found, null otherwise.</param>
		/// <returns>True if the values could be determined.</returns>
		public bool EigenValues(out EigenColumnVector values)
		{
			var ptr = EigenMatrix_Eigenvalues(Ptr);
			if (ptr != IntPtr.Zero)
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

		/// <summary>
		/// Find the eigen vectors of the matrix.
		/// </summary>
		/// <param name="vectors">The eigen vectors if found, null otherwise.</param>
		/// <returns>True if the vectors could be determined.</returns>
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

		/// <summary>
		/// Try and find the inverse of the matrix.
		/// </summary>
		/// <param name="inverse">The inverse if found, null otherwise.</param>
		/// <returns>True if the inverse was found.</returns>
		public bool TryInverse(out EigenMatrix inverse)
        {
			inverse = null;
			if(!IsSquare) return false;

			var ptr = EigenMatrix_TryInverse(Ptr);
			if(ptr != IntPtr.Zero)
            {
				inverse = new EigenMatrix(ptr);
				return true;
            }
			else
            {
				return false;
            }
        }

		public EigenRowVector GetRow(int row)
		{
			CheckRows(this, row + 1);
			var v = new EigenRowVector(Rows);
			for (int i = 0; i < Columns; i++)
				v[i] = this[row, i];

			return v;
		}

		public void SetRow(int row, EigenRowVector v)
		{
			AreSameSize(this, v);
			for (int i = 0; i < Rows; i++)
				this[row, i] = v[i];
		}

		public void SetRow(int column, double x, double y)
		{
			CheckSize(this, 2, column + 1);
			this[0, column] = x;
			this[1, column] = y;
		}

		public void SetRow(int column, double x, double y, double z)
		{
			CheckSize(this, 3, column + 1);
			this[0, column] = x;
			this[1, column] = y;
			this[2, column] = z;
		}

		public void SetRow(int column, double x, double y, double z, double w)
		{
			CheckSize(this, 4, column + 1);
			this[0, column] = x;
			this[1, column] = y;
			this[2, column] = z;
			this[3, column] = w;
		}

		public EigenColumnVector GetColumn(int column)
		{
			CheckColumns(this, column + 1);
			var v = new EigenColumnVector(Rows);
			for (int i = 0; i < Rows; i++)
				v[i] = this[i, column];

			return v;
		}

		public void SetColumn(int column, EigenColumnVector v)
		{
			AreSameSize(this, v);
			for (int i = 0; i < Rows; i++)
				this[i, column] = v[i];
		}

		public void SetColumn(int row, double x, double y)
		{
			CheckSize(this, row + 1, 2);
			this[row, 0] = x;
			this[row, 1] = y;
		}

		public void SetColumn(int row, double x, double y, double z)
		{
			CheckSize(this, row + 1, 3);
			this[row, 0] = x;
			this[row, 1] = y;
			this[row, 2] = z;
		}

		public void SetColumn(int row, double x, double y, double z, double w)
		{
			CheckSize(this, row + 1, 4);
			this[row, 0] = x;
			this[row, 1] = y;
			this[row, 2] = z;
			this[row, 3] = w;
		}

		public void Round(int digits)
		{
			for (int i = 0; i < Length; i++)
				this[i] = Math.Round(this[i], digits);
		}

		public override void Print(StringBuilder builder)
		{
			builder.AppendLine(this.ToString());

			for (int x = 0; x < Rows; x++)
			{
				for (int y = 0; y < Columns; y++)
				{
					builder.Append(this[x, y].ToString());

					if (y != Columns - 1)
						builder.Append(",");
				}

				builder.AppendLine();
			}
		}

		internal static void CheckIfSqaure(EigenMatrix m)
		{
			if (!m.IsSquare)
				throw new InvalidOperationException("Matrix must be Square.");
		}

		internal static void IsValidProduct(EigenMatrix m, EigenColumnVector v)
		{
			if (v.Dimension != m.Columns)
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

		internal static void AreSameSize(EigenMatrix m, EigenRowVector v)
		{
			if (m.Rows != v.Dimension)
				throw new InvalidOperationException("Matrix must have the same number of rows as vector dimension.");
		}

		internal static void AreSameSize(EigenMatrix m, EigenColumnVector v)
		{
			if (m.Columns != v.Dimension)
				throw new InvalidOperationException("Matrix must have the same number of columns as vector dimension.");
		}

		internal static void CheckSize(EigenMatrix m, int rows, int columns)
		{
			if (rows > m.Rows)
				throw new InvalidOperationException(String.Format("Matrix must have at least {0} rows.", rows));

			if (columns > m.Columns)
				throw new InvalidOperationException(String.Format("Matrix must have at least {0} columns.", columns));
		}

		internal static void CheckRows(EigenMatrix m, int rows)
		{
			if (rows > m.Rows)
				throw new InvalidOperationException(String.Format("Matrix must have at least {0} rows.", rows));
		}

		internal static void CheckColumns(EigenMatrix m, int columns)
		{
			if (columns > m.Columns)
				throw new InvalidOperationException(String.Format("Matrix must have at least {0} rows.", columns));
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
		private static extern IntPtr EigenMatrix_ColPivHouseholderQr_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_ColPivHouseholderQr_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_PartialPivLu_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_PartialPivLu_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_FullPivLu_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_FullPivLu_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_HouseholderQr_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_HouseholderQr_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_LLT_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_LLT_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_LDLT_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_LDLT_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_BdcSvd_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_BdcSvd_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_JacobiSvd_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_JacobiSvd_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_FullPivHouseholderQr_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_FullPivHouseholderQr_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_CompleteOrthogonalDecomposition_Vec(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_CompleteOrthogonalDecomposition_Mat(IntPtr ptr1, IntPtr ptr2);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double EigenMatrix_RelativeError_Vec(IntPtr ptr1, IntPtr ptr2, IntPtr ptr3);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern double EigenMatrix_RelativeError_Mat(IntPtr ptr1, IntPtr ptr2, IntPtr ptr3);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Eigenvalues(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_Eigenvectors(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern bool EigenMatrix_IsInvertible(IntPtr ptr);

		[DllImport(DLL_NAME, CallingConvention = CDECL)]
		private static extern IntPtr EigenMatrix_TryInverse(IntPtr ptr);
    }
}
