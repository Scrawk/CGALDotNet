#include "EigenRowVector.h"
#include <Eigen/Dense>

typedef Eigen::Matrix<double, 1, Eigen::Dynamic> ColumnVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, 1> RowVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, Eigen::Dynamic> Matrix;

void* EigenRowVector_CreateVector(int rows)
{
	auto v = new RowVector(rows, 1);
	for (int i = 0; i < rows; i++)
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

RowVector* CastRowVector(void* ptr)
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
	auto m = CastRowVector(ptr);
	return (int)m->rows();
}

double EigenRowVector_Get(void* ptr, int x)
{
	auto m = CastRowVector(ptr);
	return (*m)(x);
}

void EigenRowVector_Set(void* ptr, int x, double value)
{
	auto m = CastRowVector(ptr);
	(*m)(x) = value;
}

double EigenRowVector_Dot(void* ptr1, void* ptr2)
{
	auto v1 = CastRowVector(ptr1);
	auto v2 = CastRowVector(ptr2);

	return v1->dot(*v2);
}

void* EigenRowVector_Normalized(void* ptr)
{
	auto v = CastRowVector(ptr);
	auto n = NewRowVector(*v);

	(*n) = v->normalized();
	return n;
}

void EigenRowVector_Normalize(void* ptr)
{
	auto v = CastRowVector(ptr);
	v->normalize();
}

double EigenRowVector_Norm(void* ptr)
{
	auto v = CastRowVector(ptr);
	return v->norm();
}

void* EigenRowVector_Transpose(void* ptr)
{
	auto v1 = CastRowVector(ptr);
	auto v2 = NewColumnVector();
	(*v2) = v1->transpose();
	return v2;
}

void* EigenRowVector_Adjoint(void* ptr)
{
	auto v1 = CastRowVector(ptr);
	auto v2 = NewRowVector();
	(*v2) = v1->adjoint();
	return v2;
}

void* EigenRowVector_Conjugate(void* ptr)
{
	auto v1 = CastRowVector(ptr);
	auto v2 = NewRowVector();
	(*v2) = v1->conjugate();
	return v2;
}

void EigenRowVector_Resize(void* ptr, int dimension)
{
	auto v = CastRowVector(ptr);
	v->resize(dimension);
}


