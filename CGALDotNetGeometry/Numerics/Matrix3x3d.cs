using System;
using System.Collections;
using System.Runtime.InteropServices;

using REAL = System.Double;
using VECTOR2 = CGALDotNetGeometry.Numerics.Vector2d;
using VECTOR3 = CGALDotNetGeometry.Numerics.Vector3d;
using POINT2 = CGALDotNetGeometry.Numerics.Point2d;
using POINT3 = CGALDotNetGeometry.Numerics.Point3d;

namespace CGALDotNetGeometry.Numerics
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
        public REAL m00, m10, m20;
        public REAL m01, m11, m21;
        public REAL m02, m12, m22;

        /// <summary>
        /// The Matrix Idenity.
        /// </summary>
        static readonly public Matrix3x3d Identity = new Matrix3x3d(1, 0, 0, 0, 1, 0, 0, 0, 1);

        /// <summary>
        /// A matrix from the following varibles.
        /// </summary>
        public Matrix3x3d(REAL m00, REAL m01, REAL m02,
                          REAL m10, REAL m11, REAL m12,
                          REAL m20, REAL m21, REAL m22)
        {
            this.m00 = m00; this.m01 = m01; this.m02 = m02;
            this.m10 = m10; this.m11 = m11; this.m12 = m12;
            this.m20 = m20; this.m21 = m21; this.m22 = m22;
        }

        /// <summary>
        /// A matrix from the following column vectors.
        /// </summary>
        public Matrix3x3d(VECTOR3 c0, VECTOR3 c1, VECTOR3 c2)
        {
            m00 = c0.x; m01 = c1.x; m02 = c2.x;
            m10 = c0.y; m11 = c1.y; m12 = c2.y;
            m20 = c0.z; m21 = c1.z; m22 = c2.z;
        }

        /// <summary>
        /// A matrix from the following varibles.
        /// </summary>
        public Matrix3x3d(REAL v)
        {
            m00 = v; m01 = v; m02 = v;
            m10 = v; m11 = v; m12 = v;
            m20 = v; m21 = v; m22 = v;
        }

        /// <summary>
        /// A matrix copied from a array of varibles.
        /// </summary>
        public Matrix3x3d(REAL[,] m)
        {
            m00 = m[0, 0]; m01 = m[0, 1]; m02 = m[0, 2];
            m10 = m[1, 0]; m11 = m[1, 1]; m12 = m[1, 2];
            m20 = m[2, 0]; m21 = m[2, 1]; m22 = m[2, 2];
        }

        /// <summary>
        /// Access the varible at index i
        /// </summary>
        unsafe public REAL this[int i]
        {
            get
            {
                if ((uint)i >= 9)
                    throw new IndexOutOfRangeException("Matrix3x3d index out of range.");

                fixed (Matrix3x3d* array = &this) { return ((REAL*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 9)
                    throw new IndexOutOfRangeException("Matrix3x3d index out of range.");

                fixed (REAL* array = &m00) { array[i] = value; }
            }
        }

        /// <summary>
        /// Access the varible at index ij
        /// </summary>
        public REAL this[int i, int j]
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
        public REAL Determinant
        {
            get
            {
                REAL cofactor00 = m11 * m22 - m12 * m21;
                REAL cofactor10 = m12 * m20 - m10 * m22;
                REAL cofactor20 = m10 * m21 - m11 * m20;

                REAL det = m00 * cofactor00 + m01 * cofactor10 + m02 * cofactor20;

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

        public REAL Trace
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
        /// Multiply a vector by a matrix.
        /// </summary>
        public static VECTOR2 operator *(Matrix3x3d m, VECTOR2 v)
        {
            VECTOR2 kProd = new VECTOR2();

            kProd.x = m.m00 * v.x + m.m01 * v.y;
            kProd.y = m.m10 * v.x + m.m11 * v.y;

            return kProd;
        }

        /// <summary>
        /// Multiply  a vector by a matrix.
        /// </summary>
        public static VECTOR3 operator *(Matrix3x3d m, VECTOR3 v)
        {
            VECTOR3 kProd = new VECTOR3();

            kProd.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z;
            kProd.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z;
            kProd.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z;

            return kProd;
        }

        /// <summary>
        /// Multiply a point by a matrix.
        /// </summary>
        public static POINT2 operator *(Matrix3x3d m, POINT2 v)
        {
            POINT2 kProd = new POINT2();

            kProd.x = m.m00 * v.x + m.m01 * v.y + m.m02;
            kProd.y = m.m10 * v.x + m.m11 * v.y + m.m12;

            return kProd;
        }

        /// <summary>
        /// Multiply a point by a matrix.
        /// </summary>
        public static POINT3 operator *(Matrix3x3d m, POINT3 v)
        {
            POINT3 kProd = new POINT3();

            kProd.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z;
            kProd.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z;
            kProd.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z;

            return kProd;
        }

        /// <summary>
        /// Multiply a matrix by a scalar.
        /// </summary>
        public static Matrix3x3d operator *(Matrix3x3d m1, REAL s)
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
        public static Matrix3x3d operator *(REAL s, Matrix3x3d m1)
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
        /// Are these matrices equal.
        /// </summary>
        public static bool AlmostEqual(Matrix3x3d m0, Matrix3x3d m1, REAL eps = MathUtil.EPS_64)
        {
            if (Math.Abs(m0.m00 - m1.m00) > eps) return false;
            if (Math.Abs(m0.m10 - m1.m10) > eps) return false;
            if (Math.Abs(m0.m20 - m1.m20) > eps) return false;

            if (Math.Abs(m0.m01 - m1.m01) > eps) return false;
            if (Math.Abs(m0.m11 - m1.m11) > eps) return false;
            if (Math.Abs(m0.m21 - m1.m21) > eps) return false;

            if (Math.Abs(m0.m02 - m1.m02) > eps) return false;
            if (Math.Abs(m0.m12 - m1.m12) > eps) return false;
            if (Math.Abs(m0.m22 - m1.m22) > eps) return false;

            return true;
        }

        /// <summary>
        /// Matrices hash code. 
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = (int)MathUtil.HASH_PRIME_1;
                for (int i = 0; i < 9; i++)
                    hash = (hash * MathUtil.HASH_PRIME_2) ^ this[i].GetHashCode();
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

            REAL det = m00 * mInv.m00 + m01 * mInv.m10 + m02 * mInv.m20;

            if (MathUtil.IsZero(det))
                return false;

            REAL invDet = 1.0 / det;

            mInv.m00 *= invDet; mInv.m01 *= invDet; mInv.m02 *= invDet;
            mInv.m10 *= invDet; mInv.m11 *= invDet; mInv.m12 *= invDet;
            mInv.m20 *= invDet; mInv.m21 *= invDet; mInv.m22 *= invDet;

            return true;
        }

        /// <summary>
        /// Get the ith column as a vector.
        /// </summary>
        public VECTOR3 GetColumn(int iCol)
        {
			return new VECTOR3(this[0, iCol], this[1, iCol], this[2, iCol]);
        }

        /// <summary>
        /// Set the ith column from avector.
        /// </summary>
        public void SetColumn(int iCol, VECTOR3 v)
        {
			this[0, iCol] = v.x;
			this[1, iCol] = v.y;
			this[2, iCol] = v.z;
        }

        /// <summary>
        /// Get the ith row as a vector.
        /// </summary>
        public VECTOR3 GetRow(int iRow)
        {
			return new VECTOR3(this[iRow, 0], this[iRow, 1], this[iRow, 2]);
        }

        /// <summary>
        /// Set the ith row from avector.
        /// </summary>
        public void SetRow(int iRow, VECTOR3 v)
        {
			this[iRow, 0] = v.x;
			this[iRow, 1] = v.y;
			this[iRow, 2] = v.z;
        }

        /// <summary>
        /// Convert to a REAL precision 4 dimension matrix.
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
        static public Matrix3x3d Translate(VECTOR2 v)
        {
            return new Matrix3x3d(1, 0, v.x,
                                  0, 1, v.y,
                                  0, 0, 1);
        }

        /// <summary>
        /// Create a translation out of a point.
        /// </summary>
        static public Matrix3x3d Translate(POINT2 v)
        {
            return new Matrix3x3d(1, 0, v.x,
                                  0, 1, v.y,
                                  0, 0, 1);
        }

        /// <summary>
        /// Create a scale out of a vector.
        /// </summary>
        static public Matrix3x3d Scale(VECTOR2 v)
        {
            return new Matrix3x3d(v.x, 0, 0,
                                  0, v.y, 0,
                                  0, 0, 1);

        }

        /// <summary>
        /// Create a scale out of a point.
        /// </summary>
        static public Matrix3x3d Scale(POINT2 v)
        {
            return new Matrix3x3d(v.x, 0, 0,
                                  0, v.y, 0,
                                  0, 0, 1);

        }

        /// <summary>
        /// Create a scale out of a vector.
        /// </summary>
        static public Matrix3x3d Scale(REAL s)
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
            REAL ca = Math.Cos(radian.angle);
            REAL sa = Math.Sin(radian.angle);

            return new Matrix3x3d(1, 0, 0,
                                  0, ca, -sa,
                                  0, sa, ca);
        }

        /// <summary>
        /// Create a rotation out of a angle.
        /// </summary>
        static public Matrix3x3d RotateY(Radian radian)
        {
            REAL ca = Math.Cos(radian.angle);
            REAL sa = Math.Sin(radian.angle);

            return new Matrix3x3d(ca, 0, sa,
                                  0, 1, 0,
                                  -sa, 0, ca);
        }

        /// <summary>
        /// Create a rotation out of a angle.
        /// </summary>
        static public Matrix3x3d RotateZ(Radian radian)
        {
            REAL ca = Math.Cos(radian.angle);
            REAL sa = Math.Sin(radian.angle);

            return new Matrix3x3d(ca, -sa, 0,
                                  sa, ca, 0,
                                  0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a vector.
        /// </summary>
        static public Matrix3x3d Rotate(VECTOR3 euler)
        {
            return Quaternion3d.FromEuler(euler).ToMatrix3x3d();
        }

    }

}

























