
#include "Polyline3_EIK.h"
#include "Polyline3.h"

void* Polyline3_EIK_Create()
{
	return Polyline3<EIK>::NewPolyline3();

}
void* Polyline3_EIK_CreateWithCount(int count)
{
	return Polyline3<EIK>::NewPolyline3(count);
}

void Polyline3_EIK_Release(void* ptr)
{
	Polyline3<EIK>::DeletePolyline3(ptr);
}

int Polyline3_EIK_Count(void* ptr)
{
	return Polyline3<EIK>::Count(ptr);
}

void* Polyline3_EIK_Copy(void* ptr)
{
	return Polyline3<EIK>::Copy(ptr);
}

void* Polyline3_EIK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Polyline3<EIK>::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Polyline3<EIK>::Convert<EEK>(ptr);

	default:
		return Polyline3<EIK>::Convert<EIK>(ptr);
	}
}

void Polyline3_EIK_Clear(void* ptr)
{
	Polyline3<EIK>::Clear(ptr);
}

int Polyline3_EIK_Capacity(void* ptr)
{
	return Polyline3<EIK>::Capacity(ptr);
}

void Polyline3_EIK_Resize(void* ptr, int count)
{
	Polyline3<EIK>::Resize(ptr, count);
}

void Polyline3_EIK_Reverse(void* ptr)
{
	Polyline3<EIK>::Reverse(ptr);
}

void Polyline3_EIK_ShrinkToFit(void* ptr)
{
	Polyline3<EIK>::ShrinkToFit(ptr);
}

void Polyline3_EIK_Erase(void* ptr, int index)
{
	Polyline3<EIK>::Erase(ptr, index);
}

void Polyline3_EIK_EraseRange(void* ptr, int start, int count)
{
	Polyline3<EIK>::Erase(ptr, start, count);
}

void Polyline3_EIK_Insert(void* ptr, int index, Point3d point)
{
	Polyline3<EIK>::Insert(ptr, index, point);
}

void Polyline3_EIK_InsertRange(void* ptr, int start, int count, Point3d* points)
{
	Polyline3<EIK>::Insert(ptr, start, count, points);
}

BOOL Polyline3_EIK_IsClosed(void* ptr, double threshold)
{
	return Polyline3<EIK>::IsClosed(ptr, threshold);
}

double Polyline3_EIK_SqLength(void* ptr)
{
	return Polyline3<EIK>::SqLength(ptr);
}

Point3d Polyline3_EIK_GetPoint(void* ptr, int index)
{
	return Polyline3<EIK>::GetPoint(ptr, index);
}

void Polyline3_EIK_GetPoints(void* ptr, Point3d* points, int count)
{
	Polyline3<EIK>::GetPoints(ptr, points, count);
}

void Polyline3_EIK_GetSegments(void* ptr, Segment3d* segments, int count)
{
	Polyline3<EIK>::GetSegments(ptr, segments, count);
}

void Polyline3_EIK_SetPoint(void* ptr, int index, const Point3d& point)
{
	Polyline3<EIK>::SetPoint(ptr, index, point);
}

void Polyline3_EIK_SetPoints(void* ptr, Point3d* points, int count)
{
	Polyline3<EIK>::SetPoints(ptr, points, count);
}

void Polyline3_EIK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	Polyline3<EIK>::Transform(ptr, matrix);
}

