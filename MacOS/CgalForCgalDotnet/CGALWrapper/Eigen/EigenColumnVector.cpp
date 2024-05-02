#include "EigenColumnVector.h"
#include <Eigen/Dense>

typedef Eigen::Matrix<double, Eigen::Dynamic, 1> ColumnVector;
typedef Eigen::Matrix<double, 1, Eigen::Dynamic> RowVector;
typedef Eigen::Matrix<double, Eigen::Dynamic, Eigen::Dynamic> Matrix;

void* EigenColumnVector_CreateVector(int rows)
{
	auto v = new ColumnVector(rows, 1);
	for (int i = 0; i < rows; i++)
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

ColumnVector* CastToColumnVector(void* ptr)
{
	return static_cast<ColumnVector*>(ptr);
}

ColumnVector* NewColumnVector(const ColumnVector& v)
{
	return new ColumnVector(v.rows(), 1);
}

ColumnVector* NewColumnVector()
{
	return new ColumnVector();
}

RowVector* NewRowVector();

int EigenColumnVector_Dimension(void* ptr)
{
	auto m = CastToColumnVector(ptr);
	return (int)m->rows();
}

double EigenColumnVector_Get(void* ptr, int x)
{
	auto m = CastToColumnVector(ptr);
	return (*m)(x);
}

void EigenColumnVector_Set(void* ptr, int x, double value)
{
	auto m = CastToColumnVector(ptr);
	(*m)(x) = value;
}

double EigenColumnVector_Dot(void* ptr1, void* ptr2)
{
	auto v1 = CastToColumnVector(ptr1);
	auto v2 = CastToColumnVector(ptr2);

	return v1->dot(*v2);
}

void* EigenColumnVector_Normalized(void* ptr)
{
	auto v = CastToColumnVector(ptr);
	auto n = NewColumnVector(*v);

	(*n) = v->normalized();
	return n;
}

void EigenColumnVector_Normalize(void* ptr)
{
	auto v = CastToColumnVector(ptr);
	v->normalize();
}

double EigenColumnVector_Norm(void* ptr)
{
	auto v = CastToColumnVector(ptr);
	return v->norm();
}

void* EigenColumnVector_Transpose(void* ptr)
{
	auto v1 = CastToColumnVector(ptr);
	auto v2 = NewRowVector();
	(*v2) = v1->transpose();
	return v2;
}

void* EigenColumnVector_Adjoint(void* ptr)
{
	auto v1 = CastToColumnVector(ptr);
	auto v2 = NewColumnVector();
	(*v2) = v1->adjoint();
	return v2;
}

void* EigenColumnVector_Conjugate(void* ptr)
{
	auto v1 = CastToColumnVector(ptr);
	auto v2 = NewColumnVector();
	(*v2) = v1->conjugate();
	return v2;
}

void EigenColumnVector_Resize(void* ptr, int dimension)
{
	auto v = CastToColumnVector(ptr);
	v->resize(dimension);
}


