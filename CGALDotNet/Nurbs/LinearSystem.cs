using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;

namespace CGALDotNet.Nurbs
{
    /// <summary>
    /// Used to solve linear systems of equation.
    /// https://en.wikipedia.org/wiki/LU_decomposition
    /// </summary>
    public class LinearSystem
    {

        /// <summary>
        /// Matrix A changed so that it contains a copy of both 
        /// matrices L-E and U as A=(L-E)+U such that P*A=L*U.
        /// </summary>
        public double[,] PA;

        /// <summary>
        ///  The permutation matrix is not stored as a matrix, 
        ///  but in an integer vector P of size N+1 
        ///  containing column indexes where the permutation
        ///  matrix has "1". The last element P[N] = S + N,
        ///  where S is the number of row exchanges needed 
        ///  for determinant computation, det(P)=(-1)^S
        /// </summary>
        private int[] P;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LinearSystem()
        {

        }

        /// <summary>
        /// Construct a linear system from matrix A.
        /// </summary>
        /// <param name="A">The matrix to decompose.</param>
        public LinearSystem(double[,] A)
        {
            Decompose(A);
        }

        /// <summary>
        /// The description of the linear system.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[LinearSystem: PA={0}]", PA);
        }

        /// <summary>
        /// Decompose matrix A.
        /// </summary>
        /// <param name="A">Matrix A that is part of the linear system Ax.</param>
        /// <param name="eps">small tolerance number to detect failure 
        /// when the matrix is near degenerate</param>
        /// <returns>If the decompositon was successful.</returns>
        public bool Decompose(double[,] A, double eps = 1e-6)
        {
            if (A.GetLength(0) != A.GetLength(1))
                throw new ArgumentException("Matrix needs to be square.");

            int N = A.GetLength(0);
            PA = NurbsUtil.Copy(A);

            int i, j, k, imax;
            double maxA, absA;

            P = new int[N + 1];

            //Unit permutation matrix, P[N] initialized with N
            for (i = 0; i <= N; i++)
                P[i] = i;

            for (i = 0; i < N; i++)
            {
                maxA = 0.0;
                imax = i;

                for (k = i; k < N; k++)
                    if ((absA = Math.Abs(PA[k, i])) > maxA)
                    {
                        maxA = absA;
                        imax = k;
                    }

                //failure, matrix is degenerate
                if (maxA < eps) return false;

                if (imax != i)
                {
                    //pivoting P
                    j = P[i];
                    P[i] = P[imax];
                    P[imax] = j;

                    //pivoting rows of A
                    SwapRows(PA, i, imax);

                    //counting pivots starting from N (for determinant)
                    P[N]++;
                }

                for (j = i + 1; j < N; j++)
                {
                    PA[j, i] /= PA[i, i];

                    for (k = i + 1; k < N; k++)
                        PA[j, k] -= PA[j, i] * PA[i, k];
                }
            }

            return true;
        }

        /// <summary>
        /// Solve the linear system for the input vector.
        /// </summary>
        /// <param name="b">The vector in Ax=b.</param>
        /// <param name="x">The solution vector of Ax=b.</param>
        public void Solve(double[] b, double[] x)
        {
            int N = PA.GetLength(0);

            for (int i = 0; i < N; i++)
            {
                x[i] = b[P[i]];

                for (int k = 0; k < i; k++)
                    x[i] -= PA[i, k] * x[k];
            }

            for (int i = N - 1; i >= 0; i--)
            {
                for (int k = i + 1; k < N; k++)
                    x[i] -= PA[i, k] * x[k];

                x[i] = x[i] / PA[i, i];
            }

        }

        /// <summary>
        /// Swap the rows i and k in the matrix.
        /// </summary>
        private void SwapRows(double[,] matrix, int i, int k)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                double tmp = matrix[i, j];
                matrix[i, j] = matrix[k, j];
                matrix[k, j] = tmp;
            }
        }

    }
}
