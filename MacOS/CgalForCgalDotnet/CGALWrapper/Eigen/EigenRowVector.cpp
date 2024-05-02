#include "EigenRowVector.h"
#include <Eigen/Dense>

typedef Eigen::Matrix<double, Eigen::Dynamic, 1> ColumnVector;
typedef Eigen::Matrix<double, 1, Eigen::Dynamic> RowVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, Eigen::Dynamic> Matrix;

void* EigenRowVector_CreateVector(int columns)
{
	auto v = new RowVector(1, columns);
	for (int i = 0; i < columns; i++)
		(*v)(i) = 0;

	return v;
}

void EigenRowVector_Release(void* ptr)
{
	auto obj = static_cast<RowVector*>(ptr);
	if (obj != nullptr)
	{
		delete obj;
		obj = nullptr;
	}
}

RowVector* CastToRowVector(void* ptr)
{
	return static_cast<RowVector*>(ptr);
}

RowVector* NewRowVector(const RowVector& v)
{
	return new RowVector(1, v.cols());
}

RowVector* NewRowVector()
{
	return new RowVector();
}

ColumnVector* NewColumnVector();

int EigenRowVector_Dimension(void* ptr)
{
	auto m = CastToRowVector(ptr);
	return (int)m->cols();
}

double EigenRowVector_Get(void* ptr, int x)
{
	auto m = CastToRowVector(ptr);
	return (*m)(x);
}

void EigenRowVector_Set(void* ptr, int x, double value)
{
	auto m = CastToRowVector(ptr);
	(*m)(x) = value;
}

double EigenRowVector_Dot(void* ptr1, void* ptr2)
{
	auto v1 = CastToRowVector(ptr1);
	auto v2 = CastToRowVector(ptr2);

	return v1->dot(*v2);
}

void* EigenRowVector_Normalized(void* ptr)
{
	auto v = CastToRowVector(ptr);
	auto n = NewRowVector(*v);

	(*n) = v->normalized();
	return n;
}

void EigenRowVector_Normalize(void* ptr)
{
	auto v = CastToRowVector(ptr);
	v->normalize();
}

double EigenRowVector_Norm(void* ptr)
{
	auto v = CastToRowVector(ptr);
	return v->norm();
}

void* EigenRowVector_Transpose(void* ptr)
{
	auto v1 = CastToRowVector(ptr);
	auto v2 = NewColumnVector();
	(*v2) = v1->transpose();
	return v2;
}

void* EigenRowVector_Adjoint(void* ptr)
{
	auto v1 = CastToRowVector(ptr);
	auto v2 = NewRowVector();
	(*v2) = v1->adjoint();
	return v2;
}

void* EigenRowVector_Conjugate(void* ptr)
{
	auto v1 = CastToRowVector(ptr);
	auto v2 = NewRowVector();
	(*v2) = v1->conjugate();
	return v2;
}

void EigenRowVector_Resize(void* ptr, int dimension)
{
	auto v = CastToRowVector(ptr);
	v->resize(dimension);
}


