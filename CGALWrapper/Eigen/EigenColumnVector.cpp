#include "EigenColumnVector.h"
#include <Eigen/Dense>

typedef Eigen::Matrix<double, 1, Eigen::Dynamic> ColumnVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, 1> RowVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, Eigen::Dynamic> Matrix;

void* EigenColumnVector_CreateVector(int columns)
{
	auto v = new ColumnVector(1, columns);
	for (int i = 0; i < columns; i++)
		(*v)(i) = 0;

	return v;
}

void EigenColumnVector_Release(void* ptr)
{
	auto obj = static_cast<ColumnVector*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

ColumnVector* CastColumnVector(void* ptr)
{
	return static_cast<ColumnVector*>(ptr);
}

ColumnVector* NewColumnVector(const ColumnVector& v)
{
	return new ColumnVector(1, v.cols());
}

ColumnVector* NewColumnVector()
{
	return new ColumnVector();
}

RowVector* NewRowVector();

int EigenColumnVector_Dimension(void* ptr)
{
	auto m = CastColumnVector(ptr);
	return (int)m->cols();
}

double EigenColumnVector_Get(void* ptr, int x)
{
	auto m = CastColumnVector(ptr);
	return (*m)(x);
}

void EigenColumnVector_Set(void* ptr, int x, double value)
{
	auto m = CastColumnVector(ptr);
	(*m)(x) = value;
}

double EigenColumnVector_Dot(void* ptr1, void* ptr2)
{
	auto v1 = CastColumnVector(ptr1);
	auto v2 = CastColumnVector(ptr2);

	return v1->dot(*v2);
}

void* EigenColumnVector_Normalized(void* ptr)
{
	auto v = CastColumnVector(ptr);
	auto n = NewColumnVector(*v);

	(*n) = v->normalized();
	return n;
}

void EigenColumnVector_Normalize(void* ptr)
{
	auto v = CastColumnVector(ptr);
	v->normalize();
}

double EigenColumnVector_Norm(void* ptr)
{
	auto v = CastColumnVector(ptr);
	return v->norm();
}

void* EigenColumnVector_Transpose(void* ptr)
{
	auto v1 = CastColumnVector(ptr);
	auto v2 = NewRowVector();
	(*v2) = v1->transpose();
	return v2;
}

void* EigenColumnVector_Adjoint(void* ptr)
{
	auto v1 = CastColumnVector(ptr);
	auto v2 = NewColumnVector();
	(*v2) = v1->adjoint();
	return v2;
}

void* EigenColumnVector_Conjugate(void* ptr)
{
	auto v1 = CastColumnVector(ptr);
	auto v2 = NewColumnVector();
	(*v2) = v1->conjugate();
	return v2;
}

void EigenColumnVector_Resize(void* ptr, int dimension)
{
	auto v = CastColumnVector(ptr);
	v->resize(dimension);
}


