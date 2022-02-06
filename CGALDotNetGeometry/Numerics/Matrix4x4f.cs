using System;
using System.Collections;
using System.Runtime.InteropServices;

using REAL = System.Single;
using VECTOR2 = CGALDotNetGeometry.Numerics.Vector2f;
using VECTOR3 = CGALDotNetGeometry.Numerics.Vector3f;
using VECTOR4 = CGALDotNetGeometry.Numerics.Vector4f;
using POINT2 = CGALDotNetGeometry.Numerics.Point2f;
using POINT3 = CGALDotNetGeometry.Numerics.Point3f;
using POINT4 = CGALDotNetGeometry.Numerics.Point4f;

namespace CGALDotNetGeometry.Numerics
{
    /// <summary>
    /// Matrix is column major. Data is accessed as: row + (column*4). 
    /// Matrices can be indexed like 2D arrays but in an expression like mat[a, b], 
    /// a refers to the row index, while b refers to the column index 
    /// (note that this is the opposite way round to Cartesian coordinates).
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4x4f : IEquatable<Matrix4x4f>
	{

        /// <summary>
        /// The matrix
        /// </summary>
        public REAL m00, m10, m20, m30;
        public REAL m01, m11, m21, m31;
        public REAL m02, m12, m22, m32;
        public REAL m03, m13, m23, m33;

        /// <summary>
        /// The Matrix Idenity.
        /// </summary>
        static readonly public Matrix4x4f Identity = new Matrix4x4f(1, 0, 0, 0,
                                                                    0, 1, 0, 0,
                                                                    0, 0, 1, 0,
                                                                    0, 0, 0, 1);

        /// <summary>
        /// A matrix from the following varibles.
        /// </summary>
        public Matrix4x4f(REAL m00, REAL m01, REAL m02, REAL m03,
                          REAL m10, REAL m11, REAL m12, REAL m13,
                          REAL m20, REAL m21, REAL m22, REAL m23,
                          REAL m30, REAL m31, REAL m32, REAL m33)
        {
			this.m00 = m00; this.m01 = m01; this.m02 = m02; this.m03 = m03;
			this.m10 = m10; this.m11 = m11; this.m12 = m12; this.m13 = m13;
			this.m20 = m20; this.m21 = m21; this.m22 = m22; this.m23 = m23;
			this.m30 = m30; this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        /// <summary>
        /// A matrix from the following column vectors.
        /// </summary>
        public Matrix4x4f(VECTOR4 c0, VECTOR4 c1, VECTOR4 c2, VECTOR4 c3)
        {
            m00 = c0.x; m01 = c1.x; m02 = c2.x; m03 = c3.x;
            m10 = c0.y; m11 = c1.y; m12 = c2.y; m13 = c3.y;
            m20 = c0.z; m21 = c1.z; m22 = c2.z; m23 = c3.z;
            m30 = c0.w; m31 = c1.w; m32 = c2.w; m33 = c3.w;
        }

        /// <summary>
        /// A matrix from the following varibles.
        /// </summary>
        public Matrix4x4f(REAL v)
        {
			m00 = v; m01 = v; m02 = v; m03 = v;
			m10 = v; m11 = v; m12 = v; m13 = v;
			m20 = v; m21 = v; m22 = v; m23 = v;
			m30 = v; m31 = v; m32 = v; m33 = v;
        }

        /// <summary>
        /// A matrix copied from a array of varibles.
        /// </summary>
        public Matrix4x4f(REAL[,] m)
        {
            m00 = m[0,0]; m01 = m[0,1]; m02 = m[0,2]; m03 = m[0,3];
			m10 = m[1,0]; m11 = m[1,1]; m12 = m[1,2]; m13 = m[1,3];
			m20 = m[2,0]; m21 = m[2,1]; m22 = m[2,2]; m23 = m[2,3];
			m30 = m[3,0]; m31 = m[3,1]; m32 = m[3,2]; m33 = m[3,3];
        }

        /// <summary>
        /// Access the varible at index i
        /// </summary>
        unsafe public REAL this[int i]
        {
            get
            {
                if ((uint)i >= 16)
                    throw new IndexOutOfRangeException("Matrix4x4f index out of range.");

                fixed (Matrix4x4f* array = &this) { return ((REAL*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 16)
                    throw new IndexOutOfRangeException("Matrix4x4f index out of range.");

                fixed (REAL* array = &m00) { array[i] = value; }
            }
        }

        /// <summary>
        /// Access the varible at index ij
        /// </summary>
        public REAL this[int i, int j]
        {
            get => this[i + j * 4];
            set => this[i + j * 4] = value;
        }

        /// <summary>
        /// The transpose of the matrix. The rows and columns are flipped.
        /// </summary>
        public Matrix4x4f Transpose
        {
            get
            {
                Matrix4x4f transpose = new Matrix4x4f();
                transpose.m00 = m00;
                transpose.m01 = m10;
                transpose.m02 = m20;
                transpose.m03 = m30;

                transpose.m10 = m01;
                transpose.m11 = m11;
                transpose.m12 = m21;
                transpose.m13 = m31;

                transpose.m20 = m02;
                transpose.m21 = m12;
                transpose.m22 = m22;
                transpose.m23 = m32;

                transpose.m30 = m03;
                transpose.m31 = m13;
                transpose.m32 = m23;
                transpose.m33 = m33;

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
                return (m00 * Minor(1, 2, 3, 1, 2, 3) -
                        m01 * Minor(1, 2, 3, 0, 2, 3) +
                        m02 * Minor(1, 2, 3, 0, 1, 3) -
                        m03 * Minor(1, 2, 3, 0, 1, 2));
            }
        }

        /// <summary>
        /// The adjoint of a matrix. 
        /// </summary>
        public Matrix4x4f Adjoint
        {
            get
            {
                return new Matrix4x4f(
                        Minor(1, 2, 3, 1, 2, 3),
                        -Minor(0, 2, 3, 1, 2, 3),
                        Minor(0, 1, 3, 1, 2, 3),
                        -Minor(0, 1, 2, 1, 2, 3),

                        -Minor(1, 2, 3, 0, 2, 3),
                        Minor(0, 2, 3, 0, 2, 3),
                        -Minor(0, 1, 3, 0, 2, 3),
                        Minor(0, 1, 2, 0, 2, 3),

                        Minor(1, 2, 3, 0, 1, 3),
                        -Minor(0, 2, 3, 0, 1, 3),
                        Minor(0, 1, 3, 0, 1, 3),
                        -Minor(0, 1, 2, 0, 1, 3),

                        -Minor(1, 2, 3, 0, 1, 2),
                        Minor(0, 2, 3, 0, 1, 2),
                        -Minor(0, 1, 3, 0, 1, 2),
                        Minor(0, 1, 2, 0, 1, 2));
            }
        }

        /// <summary>
        /// The inverse of the matrix.
        /// A matrix multipled by its inverse is the idenity.
        /// </summary>
        public Matrix4x4f Inverse
        {
            get
            {
                return Adjoint * MathUtil.SafeInv(Determinant);
            }
        }

        public REAL Trace
        {
            get
            {
                return m00 + m11 + m22 + m33;
            }
        }

        /// <summary>
        /// Add two matrices.
        /// </summary>
        public static Matrix4x4f operator +(Matrix4x4f m1, Matrix4x4f m2)
        {
            Matrix4x4f kSum = new Matrix4x4f();
            kSum.m00 = m1.m00 + m2.m00;
            kSum.m01 = m1.m01 + m2.m01;
            kSum.m02 = m1.m02 + m2.m02;
            kSum.m03 = m1.m03 + m2.m03;

            kSum.m10 = m1.m10 + m2.m10;
            kSum.m11 = m1.m11 + m2.m11;
            kSum.m12 = m1.m12 + m2.m12;
            kSum.m13 = m1.m13 + m2.m13;

            kSum.m20 = m1.m20 + m2.m20;
            kSum.m21 = m1.m21 + m2.m21;
            kSum.m22 = m1.m22 + m2.m22;
            kSum.m23 = m1.m23 + m2.m23;

            kSum.m30 = m1.m30 + m2.m30;
            kSum.m31 = m1.m31 + m2.m31;
            kSum.m32 = m1.m32 + m2.m32;
            kSum.m33 = m1.m33 + m2.m33;

            return kSum;
        }

        /// <summary>
        /// Subtract two matrices.
        /// </summary>
        public static Matrix4x4f operator -(Matrix4x4f m1, Matrix4x4f m2)
        {
            Matrix4x4f kSum = new Matrix4x4f();
            kSum.m00 = m1.m00 - m2.m00;
            kSum.m01 = m1.m01 - m2.m01;
            kSum.m02 = m1.m02 - m2.m02;
            kSum.m03 = m1.m03 - m2.m03;

            kSum.m10 = m1.m10 - m2.m10;
            kSum.m11 = m1.m11 - m2.m11;
            kSum.m12 = m1.m12 - m2.m12;
            kSum.m13 = m1.m13 - m2.m13;

            kSum.m20 = m1.m20 - m2.m20;
            kSum.m21 = m1.m21 - m2.m21;
            kSum.m22 = m1.m22 - m2.m22;
            kSum.m23 = m1.m23 - m2.m23;

            kSum.m30 = m1.m30 - m2.m30;
            kSum.m31 = m1.m31 - m2.m31;
            kSum.m32 = m1.m32 - m2.m32;
            kSum.m33 = m1.m33 - m2.m33;
            return kSum;
        }

        /// <summary>
        /// Multiply two matrices.
        /// </summary>
        public static Matrix4x4f operator *(Matrix4x4f m1, Matrix4x4f m2)
        {
            Matrix4x4f kProd = new Matrix4x4f();
   
            kProd.m00 = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20 + m1.m03 * m2.m30;
            kProd.m01 = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21 + m1.m03 * m2.m31;
            kProd.m02 = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22 + m1.m03 * m2.m32;
            kProd.m03 = m1.m00 * m2.m03 + m1.m01 * m2.m13 + m1.m02 * m2.m23 + m1.m03 * m2.m33;

            kProd.m10 = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20 + m1.m13 * m2.m30;
            kProd.m11 = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21 + m1.m13 * m2.m31;
            kProd.m12 = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22 + m1.m13 * m2.m32;
            kProd.m13 = m1.m10 * m2.m03 + m1.m11 * m2.m13 + m1.m12 * m2.m23 + m1.m13 * m2.m33;

            kProd.m20 = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20 + m1.m23 * m2.m30;
            kProd.m21 = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21 + m1.m23 * m2.m31;
            kProd.m22 = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22 + m1.m23 * m2.m32;
            kProd.m23 = m1.m20 * m2.m03 + m1.m21 * m2.m13 + m1.m22 * m2.m23 + m1.m23 * m2.m33;

            kProd.m30 = m1.m30 * m2.m00 + m1.m31 * m2.m10 + m1.m32 * m2.m20 + m1.m33 * m2.m30;
            kProd.m31 = m1.m30 * m2.m01 + m1.m31 * m2.m11 + m1.m32 * m2.m21 + m1.m33 * m2.m31;
            kProd.m32 = m1.m30 * m2.m02 + m1.m31 * m2.m12 + m1.m32 * m2.m22 + m1.m33 * m2.m32;
            kProd.m33 = m1.m30 * m2.m03 + m1.m31 * m2.m13 + m1.m32 * m2.m23 + m1.m33 * m2.m33;
            return kProd;
        }

        /// <summary>
        /// Multiply a vector by a matrix.
        /// Acts like z is 0, and w is 0.
        /// </summary>
        public static VECTOR2 operator *(Matrix4x4f m, VECTOR2 v)
        {
            VECTOR2 kProd = new VECTOR2();

            kProd.x = m.m00 * v.x + m.m01 * v.y;
            kProd.y = m.m10 * v.x + m.m11 * v.y;

            return kProd;
        }

        /// <summary>
        /// Multiply a vector by a matrix.
        /// Acts like w is 0.
        /// </summary>
        public static VECTOR3 operator *(Matrix4x4f m, VECTOR3 v)
        {
            VECTOR3 kProd = new VECTOR3();

            kProd.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z;
            kProd.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z;
            kProd.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z;

            return kProd;
        }

        /// <summary>
        /// Multiply a point by a matrix.
        /// Acts like z is 0, and w is 1.
        /// </summary>
        public static POINT2 operator *(Matrix4x4f m, POINT2 v)
        {
            POINT2 kProd = new POINT2();

            kProd.x = m.m00 * v.x + m.m01 * v.y + m.m03;
            kProd.y = m.m10 * v.x + m.m11 * v.y + m.m13;

            return kProd;
        }

        /// <summary>
        /// Multiply a point by a matrix.
        /// Acts like w is 1.
        /// </summary>
        public static POINT3 operator *(Matrix4x4f m, POINT3 v)
        {
            POINT3 kProd = new POINT3();

            kProd.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z + m.m03;
            kProd.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z + m.m13;
            kProd.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z + m.m23;

            return kProd;
        }

        /// <summary>
        /// Multiply a vector by a matrix.
        /// </summary>
        public static VECTOR4 operator *(Matrix4x4f m, VECTOR4 v)
        {
            VECTOR4 kProd = new VECTOR4();

            kProd.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z + m.m03 * v.w;
            kProd.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z + m.m13 * v.w;
            kProd.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z + m.m23 * v.w;
            kProd.w = m.m30 * v.x + m.m31 * v.y + m.m32 * v.z + m.m33 * v.w;

            return kProd;
        }

        /// <summary>
        /// Multiply a point by a matrix.
        /// </summary>
        public static POINT4 operator *(Matrix4x4f m, POINT4 v)
        {
            POINT4 kProd = new POINT4();

            kProd.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z + m.m03 * v.w;
            kProd.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z + m.m13 * v.w;
            kProd.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z + m.m23 * v.w;
            kProd.w = m.m30 * v.x + m.m31 * v.y + m.m32 * v.z + m.m33 * v.w;

            return kProd;
        }

        /// <summary>
        /// Multiply a matrix by a scalar.
        /// </summary>
        public static Matrix4x4f operator *(Matrix4x4f m1, REAL s)
        {
            Matrix4x4f kProd = new Matrix4x4f();
            kProd.m00 = m1.m00 * s;
            kProd.m01 = m1.m01 * s;
            kProd.m02 = m1.m02 * s;
            kProd.m03 = m1.m03 * s;

            kProd.m10 = m1.m10 * s;
            kProd.m11 = m1.m11 * s;
            kProd.m12 = m1.m12 * s;
            kProd.m13 = m1.m13 * s;

            kProd.m20 = m1.m20 * s;
            kProd.m21 = m1.m21 * s;
            kProd.m22 = m1.m22 * s;
            kProd.m23 = m1.m23 * s;

            kProd.m30 = m1.m30 * s;
            kProd.m31 = m1.m31 * s;
            kProd.m32 = m1.m32 * s;
            kProd.m33 = m1.m33 * s;
            return kProd;
        }

        /// <summary>
        /// Multiply a matrix by a scalar.
        /// </summary>
        public static Matrix4x4f operator *(REAL s, Matrix4x4f m1)
        {
            Matrix4x4f kProd = new Matrix4x4f();
            kProd.m00 = m1.m00 * s;
            kProd.m01 = m1.m01 * s;
            kProd.m02 = m1.m02 * s;
            kProd.m03 = m1.m03 * s;

            kProd.m10 = m1.m10 * s;
            kProd.m11 = m1.m11 * s;
            kProd.m12 = m1.m12 * s;
            kProd.m13 = m1.m13 * s;

            kProd.m20 = m1.m20 * s;
            kProd.m21 = m1.m21 * s;
            kProd.m22 = m1.m22 * s;
            kProd.m23 = m1.m23 * s;

            kProd.m30 = m1.m30 * s;
            kProd.m31 = m1.m31 * s;
            kProd.m32 = m1.m32 * s;
            kProd.m33 = m1.m33 * s;
            return kProd;
        }

        /// <summary>
        /// Are these matrices equal.
        /// </summary>
        public static bool operator ==(Matrix4x4f m1, Matrix4x4f m2)
        {

          if (m1.m00 != m2.m00) return false;
          if (m1.m01 != m2.m01) return false;
          if (m1.m02 != m2.m02) return false;
          if (m1.m03 != m2.m03) return false;

          if (m1.m10 != m2.m10) return false;
          if (m1.m11 != m2.m11) return false;
          if (m1.m12 != m2.m12) return false;
          if (m1.m13 != m2.m13) return false;

          if (m1.m20 != m2.m20) return false;
          if (m1.m21 != m2.m21) return false;
          if (m1.m22 != m2.m22) return false;
          if (m1.m23 != m2.m23) return false;

          if (m1.m30 != m2.m30) return false;
          if (m1.m31 != m2.m31) return false;
          if (m1.m32 != m2.m32) return false;
          if (m1.m33 != m2.m33) return false;

          return true;
        }

        /// <summary>
        /// Are these matrices not equal.
        /// </summary>
        public static bool operator !=(Matrix4x4f m1, Matrix4x4f m2)
        {
          if (m1.m00 != m2.m00) return true;
          if (m1.m01 != m2.m01) return true;
          if (m1.m02 != m2.m02) return true;
          if (m1.m03 != m2.m03) return true;

          if (m1.m10 != m2.m10) return true;
          if (m1.m11 != m2.m11) return true;
          if (m1.m12 != m2.m12) return true;
          if (m1.m13 != m2.m13) return true;

          if (m1.m20 != m2.m20) return true;
          if (m1.m21 != m2.m21) return true;
          if (m1.m22 != m2.m22) return true;
          if (m1.m23 != m2.m23) return true;

          if (m1.m30 != m2.m30) return true;
          if (m1.m31 != m2.m31) return true;
          if (m1.m32 != m2.m32) return true;

            return false;
        }

		/// <summary>
		/// Are these matrices equal.
		/// </summary>
		public override bool Equals (object obj)
		{
			if(!(obj is Matrix4x4f)) return false;

			Matrix4x4f mat = (Matrix4x4f)obj;

			return this == mat;
		}

        /// <summary>
		/// Are these matrices equal.
		/// </summary>
        public bool Equals (Matrix4x4f mat)
		{
			return this == mat;
		}

        /// <summary>
        /// Are these matrices equal.
        /// </summary>
        public static bool AlmostEqual(Matrix4x4f m0, Matrix4x4f m1, REAL eps = MathUtil.EPS_32)
        {
            if (Math.Abs(m0.m00 - m1.m00) > eps) return false;
            if (Math.Abs(m0.m10 - m1.m10) > eps) return false;
            if (Math.Abs(m0.m20 - m1.m20) > eps) return false;
            if (Math.Abs(m0.m30 - m1.m30) > eps) return false;

            if (Math.Abs(m0.m01 - m1.m01) > eps) return false;
            if (Math.Abs(m0.m11 - m1.m11) > eps) return false;
            if (Math.Abs(m0.m21 - m1.m21) > eps) return false;
            if (Math.Abs(m0.m31 - m1.m31) > eps) return false;

            if (Math.Abs(m0.m02 - m1.m02) > eps) return false;
            if (Math.Abs(m0.m12 - m1.m12) > eps) return false;
            if (Math.Abs(m0.m22 - m1.m22) > eps) return false;
            if (Math.Abs(m0.m32 - m1.m32) > eps) return false;

            if (Math.Abs(m0.m03 - m1.m03) > eps) return false;
            if (Math.Abs(m0.m13 - m1.m13) > eps) return false;
            if (Math.Abs(m0.m23 - m1.m23) > eps) return false;
            if (Math.Abs(m0.m33 - m1.m33) > eps) return false;

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
                for (int i = 0; i < 16; i++)
                    hash = (hash * MathUtil.HASH_PRIME_2) ^ this[i].GetHashCode();
                return hash;
            }
		}

        /// <summary>
        /// A matrix as a string.
        /// </summary>
        public override string ToString()
        {
            return  this[0, 0] + "," + this[0, 1] + "," + this[0, 2] + "," + this[0, 3] + "\n" +
                    this[1, 0] + "," + this[1, 1] + "," + this[1, 2] + "," + this[1, 3] + "\n" +
                    this[2, 0] + "," + this[2, 1] + "," + this[2, 2] + "," + this[2, 3] + "\n" +
					this[3, 0] + "," + this[3, 1] + "," + this[3, 2] + "," + this[3, 3];
        }

        /// <summary>
        /// The minor of a matrix. 
        /// </summary>
        private REAL Minor(int r0, int r1, int r2, int c0, int c1, int c2)
        {
			return 	this[r0, c0] * (this[r1, c1] * this[r2, c2] - this[r2, c1] * this[r1, c2]) -
					this[r0, c1] * (this[r1, c0] * this[r2, c2] - this[r2, c0] * this[r1, c2]) +
					this[r0, c2] * (this[r1, c0] * this[r2, c1] - this[r2, c0] * this[r1, c1]);
        }

        /// <summary>
        /// The inverse of the matrix.
        /// A matrix multipled by its inverse is the idenity.
        /// </summary>
        public bool TryInverse(ref Matrix4x4f mInv)
        {

            REAL det = Determinant;

            if (MathUtil.IsZero(det))
                return false;

            mInv = Adjoint * (1.0f / det);
            return true;
        }

        /// <summary>
        /// Get the ith column as a vector.
        /// </summary>
        public VECTOR4 GetColumn(int iCol)
        {
			return new VECTOR4(this[0, iCol], this[1, iCol], this[2, iCol], this[3, iCol]);
        }

        /// <summary>
        /// Set the ith column from a vector.
        /// </summary>
        public void SetColumn(int iCol, VECTOR4 v)
        {
			this[0, iCol] = v.x;
			this[1, iCol] = v.y;
			this[2, iCol] = v.z;
			this[3, iCol] = v.w;
        }

        /// <summary>
        /// Get the ith row as a vector.
        /// </summary>
        public VECTOR4 GetRow(int iRow)
        {
			return new VECTOR4(this[iRow, 0], this[iRow, 1], this[iRow, 2], this[iRow, 3]);
        }

        /// <summary>
        /// Set the ith row from a vector.
        /// </summary>
        public void SetRow(int iRow, VECTOR4 v)
        {
			this[iRow, 0] = v.x;
			this[iRow, 1] = v.y;
			this[iRow, 2] = v.z;
			this[iRow, 3] = v.w;
        }

        /// <summary>
        /// Convert to a 3 dimension matrix.
        /// </summary>
        public Matrix3x3f ToMatrix3x3f()
        {
            Matrix3x3f mat = new Matrix3x3f();

			mat.m00 = m00; mat.m01 = m01; mat.m02 = m02;
			mat.m10 = m10; mat.m11 = m11; mat.m12 = m12;
			mat.m20 = m20; mat.m21 = m21; mat.m22 = m22;

            return mat;
        }

        /// <summary>
        /// Create a translation, rotation and scale.
        /// </summary>
        static public Matrix4x4f TranslateRotateScale(Point3f t, Quaternion3f r, Point3f s)
        {
            Matrix4x4f T = Translate(t);
            Matrix4x4f R = r.ToMatrix4x4f();
            Matrix4x4f S = Scale(s);

            return T * R * S;
        }

        /// <summary>
        /// Create a translation and rotation.
        /// </summary>
        static public Matrix4x4f TranslateRotate(Point3f t, Quaternion3f r)
        {
            Matrix4x4f T = Translate(t);
            Matrix4x4f R = r.ToMatrix4x4f();

            return T * R;
        }

        /// <summary>
        /// Create a translation and scale.
        /// </summary>
        static public Matrix4x4f TranslateScale(Point3f t, Point3f s)
        {
            Matrix4x4f T = Translate(t);
            Matrix4x4f S = Scale(s);

            return T * S;
        }

        /// <summary>
        /// Create a rotation and scale.
        /// </summary>
        static public Matrix4x4f RotateScale(Quaternion3f r, Point3f s)
        {
            Matrix4x4f R = r.ToMatrix4x4f();
            Matrix4x4f S = Scale(s);

            return R * S;
        }

        /// <summary>
        /// Create a translation out of a vector.
        /// </summary>
        static public Matrix4x4f Translate(Point3f v)
        {
            return new Matrix4x4f(	1, 0, 0, v.x,
                                    0, 1, 0, v.y,
                                    0, 0, 1, v.z,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a scale out of a vector.
        /// </summary>
        static public Matrix4x4f Scale(Point3f v)
        {
            return new Matrix4x4f(	v.x, 0, 0, 0,
                                    0, v.y, 0, 0,
                                    0, 0, v.z, 0,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a scale out of a vector.
        /// </summary>
        static public Matrix4x4f Scale(REAL s)
        {
            return new Matrix4x4f(s, 0, 0, 0,
                                  0, s, 0, 0,
                                  0, 0, s, 0,
                                  0, 0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a angle in degrees.
        /// </summary>
        static public Matrix4x4f RotateX(Radian radian)
        {
            REAL a = (REAL)radian.angle;
			REAL ca = MathUtil.Cos(a);
			REAL sa = MathUtil.Sin(a);

            return new Matrix4x4f(	1, 0, 0, 0,
                                    0, ca, -sa, 0,
                                    0, sa, ca, 0,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a angle in degrees.
        /// </summary>
        static public Matrix4x4f RotateY(Radian radian)
        {
            REAL a = (REAL)radian.angle;
            REAL ca = MathUtil.Cos(a);
            REAL sa = MathUtil.Sin(a);

            return new Matrix4x4f(	ca, 0, sa, 0,
                                    0, 1, 0, 0,
                                    -sa, 0, ca, 0,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a angle in degrees.
        /// </summary>
        static public Matrix4x4f RotateZ(Radian radian)
        {
            REAL a = (REAL)radian.angle;
            REAL ca = MathUtil.Cos(a);
            REAL sa = MathUtil.Sin(a);

            return new Matrix4x4f(	ca, -sa, 0, 0,
                                    sa, ca, 0, 0,
                                    0, 0, 1, 0,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a vector.
        /// </summary>
        static public Matrix4x4f Rotate(VECTOR3 euler)
        {
            return Quaternion3f.FromEuler(euler).ToMatrix4x4f();
        }

        /// <summary>
        /// Create a perspective matrix.
        /// </summary>
        static public Matrix4x4f Perspective(REAL fovy, REAL aspect, REAL zNear, REAL zFar)
        {
			REAL f = 1.0f / (REAL)Math.Tan((fovy * Math.PI / 180.0) / 2.0);
            return new Matrix4x4f(	f / aspect, 0, 0, 0,
                                    0, f, 0, 0,
                                    0, 0, (zFar + zNear) / (zNear - zFar), (2.0f * zFar * zNear) / (zNear - zFar),
                                    0, 0, -1, 0);
        }

        /// <summary>
        /// Create a ortho matrix.
        /// </summary>
        static public Matrix4x4f Ortho(REAL xRight, REAL xLeft, REAL yTop, REAL yBottom, REAL zNear, REAL zFar)
        {
            REAL tx, ty, tz;
            tx = -(xRight + xLeft) / (xRight - xLeft);
            ty = -(yTop + yBottom) / (yTop - yBottom);
            tz = -(zFar + zNear) / (zFar - zNear);
            return new Matrix4x4f(	2.0f / (xRight - xLeft), 0, 0, tx,
                                    0, 2.0f / (yTop - yBottom), 0, ty,
                                    0, 0, -2.0f / (zFar - zNear), tz,
                                    0, 0, 0, 1);
        }

		/// <summary>
		/// Creates the matrix need to look at target from position.
		/// </summary>
		static public Matrix4x4f LookAt(Point3f position, Point3f target, VECTOR3 Up)
		{
			
			VECTOR3 zaxis = Point3f.Direction(target, position);
			VECTOR3 xaxis = VECTOR3.Cross(Up, zaxis).Normalized;
			VECTOR3 yaxis = VECTOR3.Cross(zaxis, xaxis);
			
			return new Matrix4x4f(	xaxis.x, xaxis.y, xaxis.z, -VECTOR3.Dot(xaxis, position),
			                      	yaxis.x, yaxis.y, yaxis.z, -VECTOR3.Dot(yaxis, position),
			                      	zaxis.x, zaxis.y, zaxis.z, -VECTOR3.Dot(zaxis, position),
			                      	0, 0, 0, 1);
		}


    }

}

























