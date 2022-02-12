#include "EigenMatrix.h"
#include <Eigen/Dense>

typedef Eigen::Matrix<double, Eigen::Dynamic, Eigen::Dynamic> Matrix;

void* EigenMatrix_Create(int rows, int columns)
{
	return new Matrix(rows, columns);
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

double EigenMatrix_Get(void* ptr, int x, int y)
{
	auto m = CastToMatrix(ptr);
	return (*m)(x, y);
}

void EigenMatrix_Set(void* ptr, int x, int y, double value)
{
	auto m = CastToMatrix(ptr);
	(*m)(x, y) = value;
}


