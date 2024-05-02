
#include <iostream>
#include "EigenMatrix.h"
#include <Eigen/Dense>
#include <Eigen/LU>

typedef Eigen::Matrix<double, Eigen::Dynamic, 1> ColumnVector;
typedef Eigen::Matrix<double, 1, Eigen::Dynamic> RowVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, Eigen::Dynamic> Matrix;

ColumnVector* CastToColumnVector(void* ptr);

ColumnVector* NewColumnVector();

ColumnVector* NewColumnVector(const ColumnVector& v);

RowVector* CastToRowVector(void* ptr);

RowVector* NewRowVector();

RowVector* NewRowVector(const RowVector& v);

void* EigenMatrix_Create(int rows, int columns)
{
	auto m = new Matrix(rows, columns);
	for (int y = 0; y < columns; y++)
		for (int x = 0; x < rows; x++)
			(*m)(x, y) = 0;

	return m;
}

void* EigenMatrix_CreateIdentity(int rows, int columns)
{
	auto m = new Matrix(rows, columns);
	for (int y = 0; y < columns; y++)
	{
		for (int x = 0; x < rows; x++)
		{
			if (x == y)
				(*m)(x,y) = 1;
			else
				(*m)(x, y) = 0;
		}
	}

	return m;
}

void EigenMatrix_Release(void* ptr)
{
	auto obj = static_cast<Matrix*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

Matrix* CastToMatrix(void* ptr)
{
	return static_cast<Matrix*>(ptr);
}

Matrix* NewMatrix(const Matrix& m)
{
	return new Matrix(m.rows(), m.cols());
}

Matrix* NewMatrix()
{
	return new Matrix();
}

int EigenMatrix_Rows(void* ptr)
{
	auto m = CastToMatrix(ptr);
	return (int)m->rows();
}

int EigenMatrix_Columns(void* ptr)
{
	auto m = CastToMatrix(ptr);
	return (int)m->cols();
}

double EigenMatrix_GetXY(void* ptr, int x, int y)
{
	auto m = CastToMatrix(ptr);
	return (*m)(x, y);
}

void EigenMatrix_SetXY(void* ptr, int x, int y, double value)
{
	auto m = CastToMatrix(ptr);
	(*m)(x, y) = value;
}

double EigenMatrix_GetX(void* ptr, int x)
{
	auto m = CastToMatrix(ptr);
	return (*m)(x);
}

void EigenMatrix_SetX(void* ptr, int x, double value)
{
	auto m = CastToMatrix(ptr);
	(*m)(x) = value;
}

void* EigenMatrix_Transpose(void* ptr)
{
	auto m = CastToMatrix(ptr);
	auto m2 = NewMatrix();
	(*m2) = m->transpose();
	return m2;
}

void* EigenMatrix_Conjugate(void* ptr)
{
	auto m = CastToMatrix(ptr);
	auto m2 = NewMatrix();
	(*m2) = m->conjugate();
	return m2;
}

void* EigenMatrix_Adjoint(void* ptr)
{
	auto m = CastToMatrix(ptr);
	auto m2 = NewMatrix();
	(*m2) = m->adjoint();
	return m2;
}

void* EigenMatrix_Inverse(void* ptr)
{
	auto m = CastToMatrix(ptr);
	auto m2 = NewMatrix();
	(*m2) = m->inverse();
	return m2;
}

BOOL EigenMatrix_IsInvertible(void* ptr)
{
	auto m = CastToMatrix(ptr);
	Eigen::FullPivLU<Matrix> lu(*m);

	return lu.isInvertible();
}

void* EigenMatrix_TryInverse(void* ptr)
{
	auto m = CastToMatrix(ptr);
	Eigen::FullPivLU<Matrix> lu(*m);

	if (lu.isInvertible())
	{
		auto inv = NewMatrix();
		(*inv) = lu.inverse();
		return inv;
	}
	else
	{
		return nullptr;
	}
}

double EigenMatrix_Determinant(void* ptr)
{
	auto m = CastToMatrix(ptr);
	return m->determinant();
}

double EigenMatrix_Trace(void* ptr)
{
	auto m = CastToMatrix(ptr);
	return m->trace();
}

BOOL EigenMatrix_IsIdentity(void* ptr)
{
	auto m = CastToMatrix(ptr);
	return m->isIdentity();
}

BOOL EigenMatrix_IsDiagonal(void* ptr)
{
	auto m = CastToMatrix(ptr);
	return m->isDiagonal();
}

BOOL EigenMatrix_IsUpperTriangular(void* ptr)
{
	auto m = CastToMatrix(ptr);
	return m->isUpperTriangular();
}

BOOL EigenMatrix_IsLowerTriangular(void* ptr)
{
	auto m = CastToMatrix(ptr);
	return m->isLowerTriangular();
}

void* EigenMatrix_MulScalar(void* ptr1, double s)
{
	auto m1 = CastToMatrix(ptr1);
	auto m = NewMatrix(*m1);
	(*m) = (*m1) * s;
	return m;
}

void* EigenMatrix_DivideScalar(void* ptr1, double s)
{
	auto m1 = CastToMatrix(ptr1);
	auto m = NewMatrix(*m1);
	(*m) = (*m1) / s;
	return m;
}

void* EigenMatrix_MulMatrix(void* ptr1, void* ptr2)
{
	auto m1 = CastToMatrix(ptr1);
	auto m2 = CastToMatrix(ptr2);
	auto m = NewMatrix(*m1);
	(*m) = (*m1) * (*m2);
	return m;
}

void* EigenMatrix_AddMatrix(void* ptr1, void* ptr2)
{
	auto m1 = CastToMatrix(ptr1);
	auto m2 = CastToMatrix(ptr2);
	auto m = NewMatrix(*m1);
	(*m) = (*m1) + (*m2);
	return m;
}

void* EigenMatrix_SubMatrix(void* ptr1, void* ptr2)
{
	auto m1 = CastToMatrix(ptr1);
	auto m2 = CastToMatrix(ptr2);
	auto m = NewMatrix(*m1);
	(*m) = (*m1) - (*m2);
	return m;
}

void* EigenMatrix_MulColumnVector(void* ptr1, void* ptr2)
{
	auto m1 = CastToMatrix(ptr1);
	auto v2 = CastToColumnVector(ptr2);
	auto v = NewColumnVector(*v2);
	(*v) = (*m1) * (*v2);
	return v;
}

void* EigenMatrix_MulRowVector(void* ptr1, void* ptr2)
{
	auto m1 = CastToMatrix(ptr1);
	auto v2 = CastToRowVector(ptr2);
	auto v = NewRowVector(*v2);
	(*v) = (*m1) * (*v2);
	return v;
}

void* EigenMatrix_Block(void* ptr, int startRox, int startCol, int blockRows, int blockCols)
{
	auto m = CastToMatrix(ptr);
	auto m2 = NewMatrix();
	(*m2) = m->block(startRox, startCol, blockRows, blockCols);
	return m2;
}

void* EigenMatrix_Reshaped(void* ptr, int rows, int cols)
{
	auto m = CastToMatrix(ptr);
	auto m2 = NewMatrix();
	(*m2) = m->reshaped(rows, cols);
	return m2;
}

void* EigenMatrix_ColPivHouseholderQr_Vec(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->colPivHouseholderQr().solve(*v);
	return x;
}

void* EigenMatrix_ColPivHouseholderQr_Mat(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->colPivHouseholderQr().solve(*v);
	return x;
}

void* EigenMatrix_PartialPivLu_Vec(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->partialPivLu().solve(*v);
	return x;
}

void* EigenMatrix_PartialPivLu_Mat(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->partialPivLu().solve(*v);
	return x;
}

void* EigenMatrix_FullPivLu_Vec(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->fullPivLu().solve(*v);
	return x;
}

void* EigenMatrix_FullPivLu_Mat(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->fullPivLu().solve(*v);
	return x;
}

void* EigenMatrix_HouseholderQr_Vec(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->householderQr().solve(*v);
	return x;
}

void* EigenMatrix_HouseholderQr_Mat(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->householderQr().solve(*v);
	return x;
}

void* EigenMatrix_LLT_Vec(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->llt().solve(*v);
	return x;
}

void* EigenMatrix_LLT_Mat(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->llt().solve(*v);
	return x;
}

void* EigenMatrix_LDLT_Vec(void* ptr1, void* ptr2)
{
	auto m1 = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m1->ldlt().solve(*v);
	return x;
}

void* EigenMatrix_LDLT_Mat(void* ptr1, void* ptr2)
{
	auto m1 = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m1->ldlt().solve(*v);
	return x;
}

void* EigenMatrix_BdcSvd_Vec(void* ptr1, void* ptr2, int options)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->bdcSvd(options).solve(*v);
	return x;
}

void* EigenMatrix_BdcSvd_Mat(void* ptr1, void* ptr2, int options)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->bdcSvd(options).solve(*v);
	return x;
}

void* EigenMatrix_JacobiSvd_Vec(void* ptr1, void* ptr2, int options)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->jacobiSvd(options).solve(*v);
	return x;
}

void* EigenMatrix_JacobiSvd_Mat(void* ptr1, void* ptr2, int options)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->jacobiSvd(options).solve(*v);
	return x;
}

void* EigenMatrix_FullPivHouseholderQr_Vec(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->fullPivHouseholderQr().solve(*v);
	return x;
}

void* EigenMatrix_FullPivHouseholderQr_Mat(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->fullPivHouseholderQr().solve(*v);
	return x;
}

void* EigenMatrix_CompleteOrthogonalDecomposition_Vec(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToColumnVector(ptr2);
	auto x = NewColumnVector();

	(*x) = m->completeOrthogonalDecomposition().solve(*v);
	return x;
}

void* EigenMatrix_CompleteOrthogonalDecomposition_Mat(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastToMatrix(ptr2);
	auto x = NewMatrix();

	(*x) = m->completeOrthogonalDecomposition().solve(*v);
	return x;
}

double EigenMatrix_RelativeError_Vec(void* ptr1, void* ptr2, void* ptr3)
{
	auto A = CastToMatrix(ptr1);
	auto b = CastToColumnVector(ptr2);
	auto x = CastToColumnVector(ptr3);

	return ((*A) * (*x) - (*b)).norm() / b->norm();
}

double EigenMatrix_RelativeError_Mat(void* ptr1, void* ptr2, void* ptr3)
{
	auto A = CastToMatrix(ptr1);
	auto b = CastToMatrix(ptr2);
	auto x = CastToMatrix(ptr3);

	return ((*A) * (*x) - (*b)).norm() / b->norm();
}

void* EigenMatrix_Eigenvalues(void* ptr)
{
	auto m = CastToMatrix(ptr);

	Eigen::SelfAdjointEigenSolver<Matrix> solver(*m);

	if (solver.info() != Eigen::Success)
		return nullptr;
	else
	{
		auto x = NewColumnVector();
		(*x) = solver.eigenvalues();

		return x;
	}
}

void* EigenMatrix_Eigenvectors(void* ptr)
{
	auto m = CastToMatrix(ptr);

	Eigen::SelfAdjointEigenSolver<Matrix> solver(*m);

	if (solver.info() != Eigen::Success)
		return nullptr;
	else
	{
		auto x = NewMatrix();
		(*x) = solver.eigenvectors();

		return x;
	}
}

BOOL EigenMatrix_EigenValuesVectors(void* ptr, void** values, void** vectors)
{
	auto m = CastToMatrix(ptr);

	Eigen::SelfAdjointEigenSolver<Matrix> solver(*m);
	*values = nullptr;
	*vectors = nullptr;

	if (solver.info() != Eigen::Success)
	{
		return FALSE;
	}
	else
	{
		auto _values = solver.eigenvalues();
		auto _vectors = solver.eigenvectors();

		auto v = NewColumnVector(_values);
		for (auto i = 0; i < _values.size(); i++)
			(*v)[i] = _values[i];

		auto m = NewMatrix(_vectors);
		for (auto i = 0; i < _vectors.size(); i++)
			(*m)(i) = _vectors(i);

		(*values) = v;
		(*vectors) = m;

		return TRUE;
	}
}



