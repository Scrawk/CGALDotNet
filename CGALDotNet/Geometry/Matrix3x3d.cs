using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace CGALDotNet.Geometry
{
    /// <summary>
    /// Matrix is column major. Data is accessed as: row + (column*3). 
    /// Matrices can be indexed like 2D arrays but in an expression like mat[a, b], 
    /// a refers to the row index, while b refers to the column index 
    /// (note that this is the opposite way round to Cartesian coordinates).
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix3x3d
    {
        /// <summary>
        /// The matrix
        /// </summary>
        public double m00, m10, m20;
        public double m01, m11, m21;
        public double m02, m12, m22;

        /// <summary>
        /// The Matrix Idenity.
        /// </summary>
        static readonly public Matrix3x3d Identity = new Matrix3x3d(1, 0, 0, 0, 1, 0, 0, 0, 1);

        /// <summary>
        /// A matrix from the following varibles.
        /// </summary>
        public Matrix3x3d(double m00, double m01, double m02,
                          double m10, double m11, double m12,
                          double m20, double m21, double m22)
        {
            this.m00 = m00; this.m01 = m01; this.m02 = m02;
            this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m20 = m20; this.m21 = m21; this.m22 = m22;
        }

        /// <summary>
        /// A matrix from the following column vectors.
        /// </summary>
        public Matrix3x3d(Vector3d c0, Vector3d c1, Vector3d c2)
        {
            m00 = c0.x; m01 = c1.x; m02 = c2.x;
            m10 = c0.y; m11 = c1.y; m12 = c2.y;
            m20 = c0.z; m21 = c1.z; m22 = c2.z;
        }

        /// <summary>
        /// A matrix from the following varibles.
        /// </summary>
        public Matrix3x3d(double v)
        {
            m00 = v; m01 = v; m02 = v;
            m10 = v; m11 = v; m12 = v;
            m20 = v; m21 = v; m22 = v;
        }

        /// <summary>
        /// A matrix copied from a array of varibles.
        /// </summary>
        public Matrix3x3d(double[,] m)
        {
            m00 = m[0, 0]; m01 = m[0, 1]; m02 = m[0, 2];
            m10 = m[1, 0]; m11 = m[1, 1]; m12 = m[1, 2];
            m20 = m[2, 0]; m21 = m[2, 1]; m22 = m[2, 2];
        }

        /// <summary>
        /// Access the varible at index i
        /// </summary>
        unsafe public double this[int i]
        {
            get
            {
                if ((uint)i >= 9)
                    throw new IndexOutOfRangeException("Matrix3x3d index out of range.");

                fixed (Matrix3x3d* array = &this) { return ((double*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 9)
                    throw new IndexOutOfRangeException("Matrix3x3d index out of range.");

                fixed (double* array = &m00) { array[i] = value; }
            }
        }

        /// <summary>
        /// Access the varible at index ij
        /// </summary>
        public double this[int i, int j]
        {
            get => this[i + j * 3];
            set => this[i + j * 3] = value;
        }

        /// <summary>
        /// The transpose of the matrix. The rows and columns are flipped.
        /// </summary>
        public Matrix3x3d Transpose
        {
            get
            {
                Matrix3x3d transpose = new Matrix3x3d();

                transpose.m00 = m00;
                transpose.m01 = m10;
                transpose.m02 = m20;

                transpose.m10 = m01;
                transpose.m11 = m11;
                transpose.m12 = m21;

                transpose.m20 = m02;
                transpose.m21 = m12;
                transpose.m22 = m22;

                return transpose;
            }
        }

        /// <summary>
        /// The determinate of a matrix. 
        /// </summary>
        public double Determinant
        {
            get
            {
                double cofactor00 = m11 * m22 - m12 * m21;
                double cofactor10 = m12 * m20 - m10 * m22;
                double cofactor20 = m10 * m21 - m11 * m20;

                double det = m00 * cofactor00 + m01 * cofactor10 + m02 * cofactor20;

                return det;
            }
        }

        /// <summary>
        /// The inverse of the matrix.
        /// A matrix multipled by its inverse is the idenity.
        /// </summary>
        public Matrix3x3d Inverse
        {
            get
            {
                Matrix3x3d inverse = Identity;
                TryInverse(ref inverse);
                return inverse;
            }
        }

        public double Trace
        {
            get
            {
                return m00 + m11 + m22;
            }
        }

        /// <summary>
        /// Add two matrices.
        /// </summary>
        public static Matrix3x3d operator +(Matrix3x3d m1, Matrix3x3d m2)
        {
            Matrix3x3d kSum = new Matrix3x3d();
            kSum.m00 = m1.m00 + m2.m00;
            kSum.m01 = m1.m01 + m2.m01;
            kSum.m02 = m1.m02 + m2.m02;

            kSum.m10 = m1.m10 + m2.m10;
            kSum.m11 = m1.m11 + m2.m11;
            kSum.m12 = m1.m12 + m2.m12;

            kSum.m20 = m1.m20 + m2.m20;
            kSum.m21 = m1.m21 + m2.m21;
            kSum.m22 = m1.m22 + m2.m22;

            return kSum;
        }

        /// <summary>
        /// Subtract two matrices.
        /// </summary>
        public static Matrix3x3d operator -(Matrix3x3d m1, Matrix3x3d m2)
        {
            Matrix3x3d kSum = new Matrix3x3d();
            kSum.m00 = m1.m00 - m2.m00;
            kSum.m01 = m1.m01 - m2.m01;
            kSum.m02 = m1.m02 - m2.m02;

            kSum.m10 = m1.m10 - m2.m10;
            kSum.m11 = m1.m11 - m2.m11;
            kSum.m12 = m1.m12 - m2.m12;

            kSum.m20 = m1.m20 - m2.m20;
            kSum.m21 = m1.m21 - m2.m21;
            kSum.m22 = m1.m22 - m2.m22;
            return kSum;
        }

        /// <summary>
        /// Multiply two matrices.
        /// </summary>
        public static Matrix3x3d operator *(Matrix3x3d m1, Matrix3x3d m2)
        {
            Matrix3x3d kProd = new Matrix3x3d();

            kProd.m00 = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20;
            kProd.m01 = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21;
            kProd.m02 = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22;

            kProd.m10 = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20;
            kProd.m11 = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21;
            kProd.m12 = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22;

            kProd.m20 = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20;
            kProd.m21 = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21;
            kProd.m22 = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22;

            return kProd;
        }

        /// <summary>
        /// Multiply a matrix by a scalar.
        /// </summary>
        public static Matrix3x3d operator *(Matrix3x3d m1, double s)
        {
            Matrix3x3d kProd = new Matrix3x3d();
            kProd.m00 = m1.m00 * s;
            kProd.m01 = m1.m01 * s;
            kProd.m02 = m1.m02 * s;

            kProd.m10 = m1.m10 * s;
            kProd.m11 = m1.m11 * s;
            kProd.m12 = m1.m12 * s;

            kProd.m20 = m1.m20 * s;
            kProd.m21 = m1.m21 * s;
            kProd.m22 = m1.m22 * s;

            return kProd;
        }

        /// <summary>
        /// Multiply a matrix by a scalar.
        /// </summary>
        public static Matrix3x3d operator *(double s, Matrix3x3d m1)
        {
            Matrix3x3d kProd = new Matrix3x3d();
            kProd.m00 = m1.m00 * s;
            kProd.m01 = m1.m01 * s;
            kProd.m02 = m1.m02 * s;

            kProd.m10 = m1.m10 * s;
            kProd.m11 = m1.m11 * s;
            kProd.m12 = m1.m12 * s;

            kProd.m20 = m1.m20 * s;
            kProd.m21 = m1.m21 * s;
            kProd.m22 = m1.m22 * s;

            return kProd;
        }

        /// <summary>
        /// Are these matrices equal.
        /// </summary>
        public static bool operator ==(Matrix3x3d m1, Matrix3x3d m2)
        {

            if (m1.m00 != m2.m00) return false;
            if (m1.m01 != m2.m01) return false;
            if (m1.m02 != m2.m02) return false;

            if (m1.m10 != m2.m10) return false;
            if (m1.m11 != m2.m11) return false;
            if (m1.m12 != m2.m12) return false;

            if (m1.m20 != m2.m20) return false;
            if (m1.m21 != m2.m21) return false;
            if (m1.m22 != m2.m22) return false;

            return true;
        }

        /// <summary>
        /// Are these matrices not equal.
        /// </summary>
        public static bool operator !=(Matrix3x3d m1, Matrix3x3d m2)
        {
            if (m1.m00 != m2.m00) return true;
            if (m1.m01 != m2.m01) return true;
            if (m1.m02 != m2.m02) return true;

            if (m1.m10 != m2.m10) return true;
            if (m1.m11 != m2.m11) return true;
            if (m1.m12 != m2.m12) return true;

            if (m1.m20 != m2.m20) return true;
            if (m1.m21 != m2.m21) return true;
            if (m1.m22 != m2.m22) return true;

            return false;
        }

        /// <summary>
        /// Are these matrices equal.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is Matrix3x3d)) return false;

			Matrix3x3d mat = (Matrix3x3d)obj;

            return this == mat;
        }

        /// <summary>
        /// Are these matrices equal.
        /// </summary>
        public bool Equals(Matrix3x3d mat)
        {
            return this == mat;
        }

        /// <summary>
        /// Matrices hash code. 
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)2166136261;

                for (int i = 0; i < 9; i++)
                    hash = (hash * 16777619) ^ this[i].GetHashCode();

                return hash;
            }
        }

        /// <summary>
        /// A matrix as a string.
        /// </summary>
        public override string ToString()
        {
            return this[0, 0] + "," + this[0, 1] + "," + this[0, 2] + "\n" +
                    this[1, 0] + "," + this[1, 1] + "," + this[1, 2] + "\n" +
                    this[2, 0] + "," + this[2, 1] + "," + this[2, 2];
        }

        /// <summary>
        /// The Inverse of the matrix copied into mInv.
        /// Returns false if the matrix has no inverse.
        /// A matrix multipled by its inverse is the idenity.
        /// Invert a 3x3 using cofactors.  This is about 8 times faster than
        /// the Numerical Recipes code which uses Gaussian elimination.
        /// </summary>
        public bool TryInverse(ref Matrix3x3d mInv)
        {
            mInv.m00 = m11 * m22 - m12 * m21;
            mInv.m01 = m02 * m21 - m01 * m22;
            mInv.m02 = m01 * m12 - m02 * m11;
            mInv.m10 = m12 * m20 - m10 * m22;
            mInv.m11 = m00 * m22 - m02 * m20;
            mInv.m12 = m02 * m10 - m00 * m12;
            mInv.m20 = m10 * m21 - m11 * m20;
            mInv.m21 = m01 * m20 - m00 * m21;
            mInv.m22 = m00 * m11 - m01 * m10;

            double det = m00 * mInv.m00 + m01 * mInv.m10 + m02 * mInv.m20;

            if (det == 0)
                return false;

            double invDet = 1.0 / det;

            mInv.m00 *= invDet; mInv.m01 *= invDet; mInv.m02 *= invDet;
            mInv.m10 *= invDet; mInv.m11 *= invDet; mInv.m12 *= invDet;
            mInv.m20 *= invDet; mInv.m21 *= invDet; mInv.m22 *= invDet;

            return true;
        }

        /// <summary>
        /// Get the ith column as a vector.
        /// </summary>
        public Vector3d GetColumn(int iCol)
        {
			return new Vector3d(this[0, iCol], this[1, iCol], this[2, iCol]);
        }

        /// <summary>
        /// Set the ith column from avector.
        /// </summary>
        public void SetColumn(int iCol, Vector3d v)
        {
			this[0, iCol] = v.x;
			this[1, iCol] = v.y;
			this[2, iCol] = v.z;
        }

        /// <summary>
        /// Get the ith row as a vector.
        /// </summary>
        public Vector3d GetRow(int iRow)
        {
			return new Vector3d(this[iRow, 0], this[iRow, 1], this[iRow, 2]);
        }

        /// <summary>
        /// Set the ith row from avector.
        /// </summary>
        public void SetRow(int iRow, Vector3d v)
        {
			this[iRow, 0] = v.x;
			this[iRow, 1] = v.y;
			this[iRow, 2] = v.z;
        }

        /// <summary>
        /// Convert to a double precision 4 dimension matrix.
        /// </summary>
        public Matrix4x4d ToMatrix4x4d()
        {
            return new Matrix4x4d(m00, m01, m02, 0.0f,
                                  m10, m11, m12, 0.0f,
                                  m20, m21, m22, 0.0f,
                                  0.0f, 0.0f, 0.0f, 0.0f);
        }

        /// <summary>
        /// Create a translation out of a vector.
        /// </summary>
        static public Matrix3x3d Translate(Vector2d v)
        {
            return new Matrix3x3d(1, 0, v.x,
                                  0, 1, v.y,
                                  0, 0, 1);
        }

        /// <summary>
        /// Create a scale out of a vector.
        /// </summary>
        static public Matrix3x3d Scale(Vector2d v)
        {
            return new Matrix3x3d(v.x, 0, 0,
                                  0, v.y, 0,
                                  0, 0, 1);

        }

        /// <summary>
        /// Create a scale out of a vector.
        /// </summary>
        static public Matrix3x3d Scale(double s)
        {
            return new Matrix3x3d(s, 0, 0,
                                  0, s, 0,
                                  0, 0, 1);

        }

        /// <summary>
        /// Create a rotation out of a angle.
        /// </summary>
        static public Matrix3x3d RotateX(Radian radian)
        {
            double ca = Math.Cos(radian.angle);
            double sa = Math.Sin(radian.angle);

            return new Matrix3x3d(1, 0, 0,
                                  0, ca, -sa,
                                  0, sa, ca);
        }

        /// <summary>
        /// Create a rotation out of a angle.
        /// </summary>
        static public Matrix3x3d RotateY(Radian radian)
        {
            double ca = Math.Cos(radian.angle);
            double sa = Math.Sin(radian.angle);

            return new Matrix3x3d(ca, 0, sa,
                                  0, 1, 0,
                                  -sa, 0, ca);
        }

        /// <summary>
        /// Create a rotation out of a angle.
        /// </summary>
        static public Matrix3x3d RotateZ(Radian radian)
        {
            double ca = Math.Cos(radian.angle);
            double sa = Math.Sin(radian.angle);

            return new Matrix3x3d(ca, -sa, 0,
                                  sa, ca, 0,
                                  0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a vector.
        /// </summary>
        static public Matrix3x3d Rotate(Vector3d euler)
        {
            return Quaternion3d.FromEuler(euler).ToMatrix3x3d();
        }

    }

}

























