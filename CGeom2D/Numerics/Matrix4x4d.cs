using System;
using System.Collections;
using System.Runtime.InteropServices;

using CGeom2D.Points;

namespace CGeom2D.Numerics
{
    /// <summary>
    /// Matrix is column major. Data is accessed as: row + (column*4). 
    /// Matrices can be indexed like 2D arrays but in an expression like mat[a, b], 
    /// a refers to the row index, while b refers to the column index 
    /// (note that this is the opposite way round to Cartesian coordinates).
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix4x4d
	{

        /// <summary>
        /// The matrix
        /// </summary>
        public double m00, m10, m20, m30;
        public double m01, m11, m21, m31;
        public double m02, m12, m22, m32;
        public double m03, m13, m23, m33;

        /// <summary>
        /// The Matrix Idenity.
        /// </summary>
        static readonly public Matrix4x4d Identity = new Matrix4x4d(1, 0, 0, 0,
                                                                    0, 1, 0, 0,
                                                                    0, 0, 1, 0,
                                                                    0, 0, 0, 1);

        /// <summary>
        /// A matrix from the following varibles.
        /// </summary>
        public Matrix4x4d(double m00, double m01, double m02, double m03,
                          double m10, double m11, double m12, double m13,
                          double m20, double m21, double m22, double m23,
                          double m30, double m31, double m32, double m33)
        {
			this.m00 = m00; this.m01 = m01; this.m02 = m02; this.m03 = m03;
			this.m10 = m10; this.m11 = m11; this.m12 = m12; this.m13 = m13;
			this.m20 = m20; this.m21 = m21; this.m22 = m22; this.m23 = m23;
			this.m30 = m30; this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        /// <summary>
        /// A matrix from the following column vectors.
        /// </summary>
        public Matrix4x4d(Vector3d c0, Vector3d c1, Vector3d c2, Vector3d c3)
        {
            m00 = c0.x; m01 = c1.x; m02 = c2.x; m03 = c3.x;
            m10 = c0.y; m11 = c1.y; m12 = c2.y; m13 = c3.y;
            m20 = c0.z; m21 = c1.z; m22 = c2.z; m23 = c3.z;
            m30 = 0; m31 = 0; m32 = 0; m33 = 1;
        }

        /// <summary>
        /// A matrix from the following column vectors.
        /// </summary>
        public Matrix4x4d(Vector4d c0, Vector4d c1, Vector4d c2, Vector4d c3)
        {
            m00 = c0.x; m01 = c1.x; m02 = c2.x; m03 = c3.x;
            m10 = c0.y; m11 = c1.y; m12 = c2.y; m13 = c3.y;
            m20 = c0.z; m21 = c1.z; m22 = c2.z; m23 = c3.z;
            m30 = c0.w; m31 = c1.w; m32 = c2.w; m33 = c3.w;
        }

        /// <summary>
        /// A matrix from the following varibles.
        /// </summary>
        public Matrix4x4d(double v)
        {
			m00 = v; m01 = v; m02 = v; m03 = v;
			m10 = v; m11 = v; m12 = v; m13 = v;
			m20 = v; m21 = v; m22 = v; m23 = v;
			m30 = v; m31 = v; m32 = v; m33 = v;
        }

        /// <summary>
        /// A matrix copied from a array of varibles.
        /// </summary>
        public Matrix4x4d(double[,] m)
        {
            m00 = m[0,0]; m01 = m[0,1]; m02 = m[0,2]; m03 = m[0,3];
			m10 = m[1,0]; m11 = m[1,1]; m12 = m[1,2]; m13 = m[1,3];
			m20 = m[2,0]; m21 = m[2,1]; m22 = m[2,2]; m23 = m[2,3];
			m30 = m[3,0]; m31 = m[3,1]; m32 = m[3,2]; m33 = m[3,3];
        }
        
        /// <summary>
        /// Access the varible at index i
        /// </summary>
        unsafe public double this[int i]
        {
            get
            {
                if ((uint)i >= 16)
                    throw new IndexOutOfRangeException("Matrix4x4d index out of range.");

                fixed (Matrix4x4d* array = &this) { return ((double*)array)[i]; }
            }
            set
            {
                if ((uint)i >= 16)
                    throw new IndexOutOfRangeException("Matrix4x4d index out of range.");

                fixed (double* array = &m00) { array[i] = value; }
            }
        }

        /// <summary>
        /// Access the varible at index ij
        /// </summary>
        public double this[int i, int j]
        {
            get => this[i + j * 4];
            set => this[i + j * 4] = value;
        }

        /// <summary>
        /// The transpose of the matrix. The rows and columns are flipped.
        /// </summary>
        public Matrix4x4d Transpose
        {
            get
            {
                Matrix4x4d transpose = new Matrix4x4d();
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
        public double Determinant
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
        public Matrix4x4d Adjoint
        {
            get
            {
                return new Matrix4x4d(
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
        public Matrix4x4d Inverse
        {
            get
            {
                double det = Determinant;
                if(det != 0)
                    return Adjoint * (1.0 / det);
                else
                    return new Matrix4x4d();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double Trace
        {
            get
            {
                return m00 + m11 + m22 + m33;
            }
        }

        /// <summary>
        /// Multiply a vector by a matrix.
        /// </summary>
        public static Vector2d operator *(Matrix4x4d m, Vector2d v)
        {
            Vector4d v1 = v.xy00;
            Vector4d v2 = new Vector4d();

            v2.x = m.m00 * v1.x + m.m01 * v1.y + m.m02 * v1.z + m.m03 * v1.w;
            v2.y = m.m10 * v1.x + m.m11 * v1.y + m.m12 * v1.z + m.m13 * v1.w;
            v2.z = m.m20 * v1.x + m.m21 * v1.y + m.m22 * v1.z + m.m23 * v1.w;
            v2.w = m.m30 * v1.x + m.m31 * v1.y + m.m32 * v1.z + m.m33 * v1.w;

            return v2.xy;
        }

        /// <summary>
        /// Multiply a vector by a matrix.
        /// </summary>
        public static Vector3d operator *(Matrix4x4d m, Vector3d v)
        {
            Vector4d v1 = v.xyz0;
            Vector4d v2 = new Vector4d();

            v2.x = m.m00 * v1.x + m.m01 * v1.y + m.m02 * v1.z + m.m03 * v1.w;
            v2.y = m.m10 * v1.x + m.m11 * v1.y + m.m12 * v1.z + m.m13 * v1.w;
            v2.z = m.m20 * v1.x + m.m21 * v1.y + m.m22 * v1.z + m.m23 * v1.w;
            v2.w = m.m30 * v1.x + m.m31 * v1.y + m.m32 * v1.z + m.m33 * v1.w;

            return v2.xyz;
        }

        /// <summary>
        /// Multiply a vector by a matrix.
        /// </summary>
        public static Vector4d operator *(Matrix4x4d m, Vector4d v)
        {
            Vector4d v2 = new Vector4d();

            v2.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z + m.m03 * v.w;
            v2.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z + m.m13 * v.w;
            v2.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z + m.m23 * v.w;
            v2.w = m.m30 * v.x + m.m31 * v.y + m.m32 * v.z + m.m33 * v.w;

            return v2;
        }

        /// <summary>
        /// Multiply a point by a matrix.
        /// </summary>
        public static Point2d operator *(Matrix4x4d m, Point2d v)
        {
            Point4d v1 = v.xy01;
            Point4d v2 = new Point4d();

            v2.x = m.m00 * v1.x + m.m01 * v1.y + m.m02 * v1.z + m.m03 * v1.w;
            v2.y = m.m10 * v1.x + m.m11 * v1.y + m.m12 * v1.z + m.m13 * v1.w;
            v2.z = m.m20 * v1.x + m.m21 * v1.y + m.m22 * v1.z + m.m23 * v1.w;
            v2.w = m.m30 * v1.x + m.m31 * v1.y + m.m32 * v1.z + m.m33 * v1.w;

            return v2.xy;
        }

        /// <summary>
        /// Multiply a point by a matrix.
        /// </summary>
        public static Point3d operator *(Matrix4x4d m, Point3d v)
        {
            Point4d v1 = v.xyz1;
            Point4d v2 = new Point4d();

            v2.x = m.m00 * v1.x + m.m01 * v1.y + m.m02 * v1.z + m.m03 * v1.w;
            v2.y = m.m10 * v1.x + m.m11 * v1.y + m.m12 * v1.z + m.m13 * v1.w;
            v2.z = m.m20 * v1.x + m.m21 * v1.y + m.m22 * v1.z + m.m23 * v1.w;
            v2.w = m.m30 * v1.x + m.m31 * v1.y + m.m32 * v1.z + m.m33 * v1.w;

            return v2.xyz;
        }

        /// <summary>
        /// Multiply a point by a matrix.
        /// </summary>
        public static Point4d operator *(Matrix4x4d m, Point4d v)
        {
            Point4d v2 = new Point4d();

            v2.x = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z + m.m03 * v.w;
            v2.y = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z + m.m13 * v.w;
            v2.z = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z + m.m23 * v.w;
            v2.w = m.m30 * v.x + m.m31 * v.y + m.m32 * v.z + m.m33 * v.w;

            return v2;
        }

        /// <summary>
        /// Add two matrices.
        /// </summary>
        public static Matrix4x4d operator +(Matrix4x4d m1, Matrix4x4d m2)
        {
            Matrix4x4d m3 = new Matrix4x4d();
            m3.m00 = m1.m00 + m2.m00;
            m3.m01 = m1.m01 + m2.m01;
            m3.m02 = m1.m02 + m2.m02;
            m3.m03 = m1.m03 + m2.m03;

            m3.m10 = m1.m10 + m2.m10;
            m3.m11 = m1.m11 + m2.m11;
            m3.m12 = m1.m12 + m2.m12;
            m3.m13 = m1.m13 + m2.m13;

            m3.m20 = m1.m20 + m2.m20;
            m3.m21 = m1.m21 + m2.m21;
            m3.m22 = m1.m22 + m2.m22;
            m3.m23 = m1.m23 + m2.m23;

            m3.m30 = m1.m30 + m2.m30;
            m3.m31 = m1.m31 + m2.m31;
            m3.m32 = m1.m32 + m2.m32;
            m3.m33 = m1.m33 + m2.m33;

            return m3;
        }

        /// <summary>
        /// Subtract two matrices.
        /// </summary>
        public static Matrix4x4d operator -(Matrix4x4d m1, Matrix4x4d m2)
        {
            Matrix4x4d m3 = new Matrix4x4d();
            m3.m00 = m1.m00 - m2.m00;
            m3.m01 = m1.m01 - m2.m01;
            m3.m02 = m1.m02 - m2.m02;
            m3.m03 = m1.m03 - m2.m03;

            m3.m10 = m1.m10 - m2.m10;
            m3.m11 = m1.m11 - m2.m11;
            m3.m12 = m1.m12 - m2.m12;
            m3.m13 = m1.m13 - m2.m13;

            m3.m20 = m1.m20 - m2.m20;
            m3.m21 = m1.m21 - m2.m21;
            m3.m22 = m1.m22 - m2.m22;
            m3.m23 = m1.m23 - m2.m23;

            m3.m30 = m1.m30 - m2.m30;
            m3.m31 = m1.m31 - m2.m31;
            m3.m32 = m1.m32 - m2.m32;
            m3.m33 = m1.m33 - m2.m33;
            return m3;
        }

        /// <summary>
        /// Multiply two matrices.
        /// </summary>
        public static Matrix4x4d operator *(Matrix4x4d m1, Matrix4x4d m2)
        {
            Matrix4x4d m3 = new Matrix4x4d();
  
            m3.m00 = m1.m00 * m2.m00 + m1.m01 * m2.m10 + m1.m02 * m2.m20 + m1.m03 * m2.m30;
            m3.m01 = m1.m00 * m2.m01 + m1.m01 * m2.m11 + m1.m02 * m2.m21 + m1.m03 * m2.m31;
            m3.m02 = m1.m00 * m2.m02 + m1.m01 * m2.m12 + m1.m02 * m2.m22 + m1.m03 * m2.m32;
            m3.m03 = m1.m00 * m2.m03 + m1.m01 * m2.m13 + m1.m02 * m2.m23 + m1.m03 * m2.m33;

            m3.m10 = m1.m10 * m2.m00 + m1.m11 * m2.m10 + m1.m12 * m2.m20 + m1.m13 * m2.m30;
            m3.m11 = m1.m10 * m2.m01 + m1.m11 * m2.m11 + m1.m12 * m2.m21 + m1.m13 * m2.m31;
            m3.m12 = m1.m10 * m2.m02 + m1.m11 * m2.m12 + m1.m12 * m2.m22 + m1.m13 * m2.m32;
            m3.m13 = m1.m10 * m2.m03 + m1.m11 * m2.m13 + m1.m12 * m2.m23 + m1.m13 * m2.m33;

            m3.m20 = m1.m20 * m2.m00 + m1.m21 * m2.m10 + m1.m22 * m2.m20 + m1.m23 * m2.m30;
            m3.m21 = m1.m20 * m2.m01 + m1.m21 * m2.m11 + m1.m22 * m2.m21 + m1.m23 * m2.m31;
            m3.m22 = m1.m20 * m2.m02 + m1.m21 * m2.m12 + m1.m22 * m2.m22 + m1.m23 * m2.m32;
            m3.m23 = m1.m20 * m2.m03 + m1.m21 * m2.m13 + m1.m22 * m2.m23 + m1.m23 * m2.m33;

            m3.m30 = m1.m30 * m2.m00 + m1.m31 * m2.m10 + m1.m32 * m2.m20 + m1.m33 * m2.m30;
            m3.m31 = m1.m30 * m2.m01 + m1.m31 * m2.m11 + m1.m32 * m2.m21 + m1.m33 * m2.m31;
            m3.m32 = m1.m30 * m2.m02 + m1.m31 * m2.m12 + m1.m32 * m2.m22 + m1.m33 * m2.m32;
            m3.m33 = m1.m30 * m2.m03 + m1.m31 * m2.m13 + m1.m32 * m2.m23 + m1.m33 * m2.m33;
            return m3;
        }

        /// <summary>
        /// Multiply a matrix by a scalar.
        /// </summary>
        public static Matrix4x4d operator *(Matrix4x4d m1, double s)
        {
            Matrix4x4d m2 = new Matrix4x4d();
            m2.m00 = m1.m00 * s;
            m2.m01 = m1.m01 * s;
            m2.m02 = m1.m02 * s;
            m2.m03 = m1.m03 * s;

            m2.m10 = m1.m10 * s;
            m2.m11 = m1.m11 * s;
            m2.m12 = m1.m12 * s;
            m2.m13 = m1.m13 * s;

            m2.m20 = m1.m20 * s;
            m2.m21 = m1.m21 * s;
            m2.m22 = m1.m22 * s;
            m2.m23 = m1.m23 * s;

            m2.m30 = m1.m30 * s;
            m2.m31 = m1.m31 * s;
            m2.m32 = m1.m32 * s;
            m2.m33 = m1.m33 * s;
            return m2;
        }

        /// <summary>
        /// Multiply a matrix by a scalar.
        /// </summary>
        public static Matrix4x4d operator *(double s, Matrix4x4d m1)
        {
            Matrix4x4d m2 = new Matrix4x4d();
            m2.m00 = m1.m00 * s;
            m2.m01 = m1.m01 * s;
            m2.m02 = m1.m02 * s;
            m2.m03 = m1.m03 * s;

            m2.m10 = m1.m10 * s;
            m2.m11 = m1.m11 * s;
            m2.m12 = m1.m12 * s;
            m2.m13 = m1.m13 * s;

            m2.m20 = m1.m20 * s;
            m2.m21 = m1.m21 * s;
            m2.m22 = m1.m22 * s;
            m2.m23 = m1.m23 * s;

            m2.m30 = m1.m30 * s;
            m2.m31 = m1.m31 * s;
            m2.m32 = m1.m32 * s;
            m2.m33 = m1.m33 * s;
            return m2;
        }

        /// <summary>
        /// Are these matrices equal.
        /// </summary>
        public static bool operator ==(Matrix4x4d m1, Matrix4x4d m2)
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
        public static bool operator !=(Matrix4x4d m1, Matrix4x4d m2)
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
			if(!(obj is Matrix4x4d)) return false;

			Matrix4x4d mat = (Matrix4x4d)obj;

			return this == mat;
		}

        /// <summary>
		/// Are these matrices equal.
		/// </summary>
        public bool Equals (Matrix4x4d mat)
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

                for (int i = 0; i < 16; i++)
                    hash = (hash * 16777619) ^ this[i].GetHashCode();

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
        private double Minor(int r0, int r1, int r2, int c0, int c1, int c2)
        {
			return 	this[r0, c0] * (this[r1, c1] * this[r2, c2] - this[r2, c1] * this[r1, c2]) -
					this[r0, c1] * (this[r1, c0] * this[r2, c2] - this[r2, c0] * this[r1, c2]) +
					this[r0, c2] * (this[r1, c0] * this[r2, c1] - this[r2, c0] * this[r1, c1]);
        }

        /// <summary>
        /// The inverse of the matrix.
        /// A matrix multipled by its inverse is the idenity.
        /// </summary>
        public bool TryInverse(ref Matrix4x4d mInv)
        {
            double det = Determinant;

            if (det == 0)
                return false;

            mInv = Adjoint * (1.0 / det);
            return true;
        }

        /// <summary>
        /// Get the ith column as a vector.
        /// </summary>
        public Vector4d GetColumn(int iCol)
		{
			return new Vector4d(this[0, iCol], this[1, iCol], this[2, iCol], this[3, iCol]);
		}
		
		/// <summary>
		/// Set the ith column from a vector.
		/// </summary>
		public void SetColumn(int iCol, Vector4d v)
		{
			this[0, iCol] = v.x;
			this[1, iCol] = v.y;
			this[2, iCol] = v.z;
			this[3, iCol] = v.w;
		}
		
		/// <summary>
		/// Get the ith row as a vector.
		/// </summary>
		public Vector4d GetRow(int iRow)
		{
			return new Vector4d(this[iRow, 0], this[iRow, 1], this[iRow, 2], this[iRow, 3]);
		}
		
		/// <summary>
		/// Set the ith row from a vector.
		/// </summary>
		public void SetRow(int iRow, Vector4d v)
		{
			this[iRow, 0] = v.x;
			this[iRow, 1] = v.y;
			this[iRow, 2] = v.z;
			this[iRow, 3] = v.w;
		}

        /// <summary>
        /// Convert to a 3 dimension matrix.
        /// </summary>
        public Matrix3x3d ToMatrix3x3d()
        {
            Matrix3x3d mat = new Matrix3x3d();

            mat.m00 = m00; mat.m01 = m01; mat.m02 = m02;
            mat.m10 = m10; mat.m11 = m11; mat.m12 = m12;
            mat.m20 = m20; mat.m21 = m21; mat.m22 = m22;

            return mat;
        }

        /// <summary>
        /// Create a translation, rotation and scale.
        /// </summary>
        static public Matrix4x4d TranslateRotateScale(Vector3d t, Quaternion3d r, Vector3d s)
        {
            Matrix4x4d T = Translate(t);
            Matrix4x4d R = r.ToMatrix4x4d();
            Matrix4x4d S = Scale(s);

            return T * R * S;
        }

        /// <summary>
        /// Create a translation and rotation.
        /// </summary>
        static public Matrix4x4d TranslateRotate(Vector3d t, Quaternion3d r)
        {
            Matrix4x4d T = Translate(t);
            Matrix4x4d R = r.ToMatrix4x4d();

            return T * R;
        }

        /// <summary>
        /// Create a translation and scale.
        /// </summary>
        static public Matrix4x4d TranslateScale(Vector3d t, Vector3d s)
        {
            Matrix4x4d T = Translate(t);
            Matrix4x4d S = Scale(s);

            return T * S;
        }

        /// <summary>
        /// Create a rotation and scale.
        /// </summary>
        static public Matrix4x4d RotateScale(Quaternion3d r, Vector3d s)
        {
            Matrix4x4d R = r.ToMatrix4x4d();
            Matrix4x4d S = Scale(s);

            return R * S;
        }

        /// <summary>
        /// Create a translation out of a vector.
        /// </summary>
        static public Matrix4x4d Translate(Vector3d v)
        {
            return new Matrix4x4d(	1, 0, 0, v.x,
                                    0, 1, 0, v.y,
                                    0, 0, 1, v.z,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a scale out of a vector.
        /// </summary>
        static public Matrix4x4d Scale(Vector3d v)
        {
            return new Matrix4x4d(	v.x, 0, 0, 0,
                                    0, v.y, 0, 0,
                                    0, 0, v.z, 0,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a scale out of a vector.
        /// </summary>
        static public Matrix4x4d Scale(double s)
        {
            return new Matrix4x4d(s, 0, 0, 0,
                                  0, s, 0, 0,
                                  0, 0, s, 0,
                                  0, 0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a angle.
        /// </summary>
        static public Matrix4x4d RotateX(Radian radian)
        {
            double ca = Math.Cos(radian.angle);
            double sa = Math.Sin(radian.angle);

            return new Matrix4x4d(1, 0, 0, 0,
                                    0, ca, -sa, 0,
                                    0, sa, ca, 0,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a angle.
        /// </summary>
        static public Matrix4x4d RotateY(Radian radian)
        {
            double ca = Math.Cos(radian.angle);
            double sa = Math.Sin(radian.angle);

            return new Matrix4x4d(ca, 0, sa, 0,
                                    0, 1, 0, 0,
                                    -sa, 0, ca, 0,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a angle.
        /// </summary>
        static public Matrix4x4d RotateZ(Radian radian)
        {
            double ca = Math.Cos(radian.angle);
            double sa = Math.Sin(radian.angle);

            return new Matrix4x4d(ca, -sa, 0, 0,
                                    sa, ca, 0, 0,
                                    0, 0, 1, 0,
                                    0, 0, 0, 1);
        }

        /// <summary>
        /// Create a rotation out of a vector.
        /// </summary>
        static public Matrix4x4d Rotate(Vector3d euler)
        {
            return Quaternion3d.FromEuler(euler).ToMatrix4x4d();
        }

		/// <summary>
		/// Creates the matrix need to look at target from position.
		/// </summary>
		static public Matrix4x4d LookAt(Vector3d position, Vector3d target, Vector3d Up)
		{
			
			Vector3d zaxis = (position - target).Normalized;
			Vector3d xaxis = Vector3d.Cross(Up, zaxis).Normalized;
			Vector3d yaxis = Vector3d.Cross(zaxis, xaxis);
			
			return new Matrix4x4d(	xaxis.x, xaxis.y, xaxis.z, -Vector3d.Dot(xaxis, position),
			                      	yaxis.x, yaxis.y, yaxis.z, -Vector3d.Dot(yaxis, position),
			                      	zaxis.x, zaxis.y, zaxis.z, -Vector3d.Dot(zaxis, position),
			                      	0, 0, 0, 1);
		}


    }

}

























