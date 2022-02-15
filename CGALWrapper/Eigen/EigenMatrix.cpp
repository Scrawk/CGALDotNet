
#include "EigenMatrix.h"
#include <Eigen/Dense>

typedef Eigen::Matrix<double, 1, Eigen::Dynamic> ColumnVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, 1> RowVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, Eigen::Dynamic> Matrix;

ColumnVector* CastColumnVector(void* ptr);

ColumnVector* NewColumnVector();

ColumnVector* NewColumnVector(const ColumnVector& v);

RowVector* CastRowVector(void* ptr);

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
	auto v2 = CastColumnVector(ptr2);
	auto v = NewColumnVector(*v2);
	(*v) = (*m1) * (*v2);
	return v;
}

void* EigenMatrix_MulRowVector(void* ptr1, void* ptr2)
{
	auto m1 = CastToMatrix(ptr1);
	auto v2 = CastRowVector(ptr2);
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

void* EigenMatrix_ColPivHouseholderQr(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastColumnVector(ptr2);
	auto x = NewColumnVector(*v);

	(*x) = m->colPivHouseholderQr().solve(*v);
	return x;
}

void* EigenMatrix_PartialPivLu(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastColumnVector(ptr2);
	auto x = NewColumnVector(*v);

	(*x) = m->partialPivLu().solve(*v);
	return x;
}

void* EigenMatrix_FullPivLu(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastColumnVector(ptr2);
	auto x = NewColumnVector(*v);

	(*x) = m->fullPivLu().solve(*v);
	return x;
}

void* EigenMatrix_HouseholderQr(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastColumnVector(ptr2);
	auto x = NewColumnVector(*v);

	(*x) = m->householderQr().solve(*v);
	return x;
}

void* EigenMatrix_LLT(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastColumnVector(ptr2);
	auto x = NewColumnVector(*v);

	(*x) = m->llt().solve(*v);
	return x;
}

void* EigenMatrix_BdcSvd(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastColumnVector(ptr2);
	auto x = NewColumnVector(*v);

	(*x) = m->bdcSvd().solve(*v);
	return x;
}

void* EigenMatrix_JacobiSvd(void* ptr1, void* ptr2)
{
	auto m = CastToMatrix(ptr1);
	auto v = CastColumnVector(ptr2);
	auto x = NewColumnVector(*v);

	(*x) = m->jacobiSvd().solve(*v);
	return x;
}

double EigenMatrix_RelativeError(void* ptr1, void* ptr2, void* ptr3)
{
	auto A = CastToMatrix(ptr1);
	auto b = CastColumnVector(ptr2);
	auto x = CastColumnVector(ptr3);

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


