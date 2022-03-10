using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CGALDotNet;
using CGALDotNetGeometry.Numerics;
using CGALDotNet.Eigen;

namespace CGALDotNetTest.Eigen
{
    [TestClass]
    public class EigenMatrix_Test
    {
        [TestMethod]
        public void Create()
        {
            int rows = 2;
            int cols = 3;

            var m1 = new EigenMatrix(rows, cols);

            var a = new double[rows, cols];
            var m2 = new EigenMatrix(a);

            var c = new EigenColumnVector[]
            {
                new EigenColumnVector(cols),
                new EigenColumnVector(cols)
            };

            var m3 = new EigenMatrix(c);

            Assert.AreEqual(rows, m1.Rows);
            Assert.AreEqual(cols, m1.Columns);

            Assert.AreEqual(rows, m2.Rows);
            Assert.AreEqual(cols, m2.Columns);

            Assert.AreEqual(rows, m3.Rows);
            Assert.AreEqual(cols, m3.Columns);
        }

        [TestMethod]
        public void Release()
        {
            var m = new EigenMatrix(1,1);
            m.Dispose();

            Assert.IsTrue(m.IsDisposed);
        }

        [TestMethod]
        public void RowColumnsLength()
        {
            var m = new EigenMatrix(2, 3);

            Assert.AreEqual(2, m.Rows);
            Assert.AreEqual(3, m.Columns);
            Assert.AreEqual(2 * 3, m.Length);
        }

        [TestMethod]
        public void ArrayAccessors()
        {
            var m = new EigenMatrix(2, 3);

            for (int i = 0; i < m.Length; i++)
                m[i] = i;

            for (int i = 0; i < m.Length; i++)
                Assert.AreEqual(i, m[i]);

            for (int y = 0; y < m.Columns; y++)
            {
                for (int x = 0; x < m.Rows; x++)
                {
                    m[x, y] = x + y * m.Rows;
                }
            }

            for (int y = 0; y < m.Columns; y++)
            {
                for (int x = 0; x < m.Rows; x++)
                {
                    int i = x + y * m.Rows;
                    Assert.AreEqual(i, m[i]);
                }
            }
        }

        [TestMethod]
        public void ScalarMul()
        {
           var m = EigenMatrix.Series(2, 3);

            m = m * 2;

            int i = 0;
            for (int x = 0; x < m.Rows; x++)
            {
                for (int y = 0; y < m.Columns; y++)
                {
                    Assert.AreEqual(i * 2, m[x, y]);
                    i++;
                }
            }
        }

        [TestMethod]
        public void ScalarDiv()
        {
            var m = EigenMatrix.Series(2, 3);

            m = m / 2.0;

            int i = 0;
            for (int x = 0; x < m.Rows; x++)
            {
                for (int y = 0; y < m.Columns; y++)
                {
                    Assert.AreEqual(i / 2.0, m[x, y]);
                    i++;
                }
            }
        }

        [TestMethod]
        public void VectorMul()
        {
            var m = EigenMatrix.Translate(new Point3d(1, 2, 3));

            var v = new EigenColumnVector(0, 0, 0, 1);

            v = m * v;

            Assert.AreEqual(1, v.x);
            Assert.AreEqual(2, v.y);
            Assert.AreEqual(3, v.z);
            Assert.AreEqual(1, v.w);
        }

        [TestMethod]
        public void MatrixMul()
        {
            var m1 = EigenMatrix.Series(2, 2);
            var m2 = EigenMatrix.Series(2, 2);

            var m = new EigenMatrix(2, 3, 6, 11);

            AssertX.AlmostEqual(m, m1 * m2);
        }

        [TestMethod]
        public void MatrixAdd()
        {
            var m1 = EigenMatrix.Series(2, 2);
            var m2 = EigenMatrix.Series(2, 2);

            var m = new EigenMatrix(0, 2, 4, 6);

            AssertX.AlmostEqual(m, m1 + m2);
        }

        [TestMethod]
        public void MatrixSub()
        {
            var m1 = EigenMatrix.Series(2, 2);
            var m2 = EigenMatrix.Series(2, 2);

            var m = new EigenMatrix(0, 0, 0, 0);

            AssertX.AlmostEqual(m, m1 - m2);
        }

        [TestMethod]
        public void EigenValues()
        {
            var m = new EigenMatrix(1, 2, 2, 3);

            if(m.EigenValues(out EigenColumnVector values))
            {
                values.Round(2);
                AssertX.AlmostEqual(new EigenColumnVector(-0.24, 4.24), values);
            }
            else
            {
                throw new Exception("Failed to find eigen values.");
            }
        }

        [TestMethod]
        public void EigenVectors()
        {
            var m = new EigenMatrix(1, 2, 2, 3);

            if (m.EigenVectors(out EigenMatrix vectors))
            {
                vectors.Round(3);
                AssertX.AlmostEqual(new EigenMatrix(-0.851, -0.526, 0.526, -0.851), vectors);
            }
            else
            {
                throw new Exception("Failed to find eigen values.");
            }
        }

        [TestMethod]
        public void EigenValuesVectors()
        {
            var m = new EigenMatrix(1, 2, 2, 3);

            if (m.EigenValuesAndVectors(out EigenColumnVector values, out EigenMatrix vectors))
            {
                values.Round(2);
                AssertX.AlmostEqual(new EigenColumnVector(-0.24, 4.24), values);

                vectors.Round(3);
                AssertX.AlmostEqual(new EigenMatrix(-0.851, -0.526, 0.526, -0.851), vectors);
            }
            else
            {
                throw new Exception("Failed to find eigen values and vectors.");
            }
        }

        [TestMethod]
        public void ColPivHouseholderQr()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.ColPivHouseholderQr(b1);
            x1.Round(2);

            var x2 = A.ColPivHouseholderQr(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }

        /*
        [TestMethod]
        public void PartialPivLu()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.PartialPivLu(b1);
            x1.Round(2);

            var x2 = A.PartialPivLu(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }
        */

        [TestMethod]
        public void FullPivLu()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.FullPivLu(b1);
            x1.Round(2);

            var x2 = A.FullPivLu(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }

        [TestMethod]
        public void HouseholderQr()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.HouseholderQr(b1);
            x1.Round(2);

            var x2 = A.HouseholderQr(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }

        /*
        [TestMethod]
        public void LLT()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.LLT(b1);
            x1.Round(2);

            var x2 = A.LLT(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }

        [TestMethod]
        public void LDLT()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.LDLT(b1);
            x1.Round(2);

            var x2 = A.LDLT(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }
        */

        [TestMethod]
        public void BdcSvd()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.BdcSvd(b1);
            x1.Round(2);

            var x2 = A.BdcSvd(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }

        [TestMethod]
        public void JacobiSvd()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.JacobiSvd(b1);
            x1.Round(2);

            var x2 = A.JacobiSvd(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }

        [TestMethod]
        public void FullPivHouseholderQR()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.FullPivHouseholderQR(b1);
            x1.Round(2);

            var x2 = A.FullPivHouseholderQR(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }

        [TestMethod]
        public void CompleteOrthogonalDecomposition()
        {
            var A = new EigenMatrix(3, 3);
            A.SetRow(0, 1, 2, 3);
            A.SetRow(1, 4, 5, 6);
            A.SetRow(2, 7, 8, 10);

            var b1 = new EigenColumnVector(3, 3, 4);

            var b2 = new EigenMatrix(3, 1);
            b2.SetColumn(0, 3, 3, 4);

            var x1 = A.CompleteOrthogonalDecomposition(b1);
            x1.Round(2);

            var x2 = A.CompleteOrthogonalDecomposition(b2);
            x2.Round(2);

            var x = new EigenColumnVector(-2, 1, 1);

            AssertX.AlmostEqual(x, x1);
            AssertX.AlmostEqual(x, x1);
        }

    }
}