
#include "Polyline3_EEK.h"
#include "Polyline3.h"

void* Polyline3_EEK_Create()
{
	return Polyline3<EEK>::NewPolyline3();

}
void* Polyline3_EEK_CreateWithCount(int count)
{
	return Polyline3<EEK>::NewPolyline3(count);
}

void Polyline3_EEK_Release(void* ptr)
{
	Polyline3<EEK>::DeletePolyline3(ptr);
}

int Polyline3_EEK_Count(void* ptr)
{
	return Polyline3<EEK>::Count(ptr);
}

void* Polyline3_EEK_Copy(void* ptr)
{
	return Polyline3<EEK>::Copy(ptr);
}

void* Polyline3_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Polyline3<EEK>::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Polyline3<EEK>::Convert<EEK>(ptr);

	default:
		return Polyline3<EEK>::Convert<EEK>(ptr);
	}
}

void Polyline3_EEK_Clear(void* ptr)
{
	Polyline3<EEK>::Clear(ptr);
}

int Polyline3_EEK_Capacity(void* ptr)
{
	return Polyline3<EEK>::Capacity(ptr);
}

void Polyline3_EEK_Resize(void* ptr, int count)
{
	Polyline3<EEK>::Resize(ptr, count);
}

void Polyline3_EEK_Reverse(void* ptr)
{
	Polyline3<EEK>::Reverse(ptr);
}

void Polyline3_EEK_ShrinkToFit(void* ptr)
{
	Polyline3<EEK>::ShrinkToFit(ptr);
}

void Polyline3_EEK_Erase(void* ptr, int index)
{
	Polyline3<EEK>::Erase(ptr, index);
}

void Polyline3_EEK_EraseRange(void* ptr, int start, int count)
{
	Polyline3<EEK>::Erase(ptr, start, count);
}

void Polyline3_EEK_Insert(void* ptr, int index, Point3d point)
{
	Polyline3<EEK>::Insert(ptr, index, point);
}

void Polyline3_EEK_InsertRange(void* ptr, int start, int count, Point3d* points)
{
	Polyline3<EEK>::Insert(ptr, start, count, points);
}

BOOL Polyline3_EEK_IsClosed(void* ptr, double threshold)
{
	return Polyline3<EEK>::IsClosed(ptr, threshold);
}

double Polyline3_EEK_SqLength(void* ptr)
{
	return Polyline3<EEK>::SqLength(ptr);
}

Point3d Polyline3_EEK_GetPoint(void* ptr, int index)
{
	return Polyline3<EEK>::GetPoint(ptr, index);
}

void Polyline3_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	Polyline3<EEK>::GetPoints(ptr, points, count);
}

void Polyline3_EEK_GetSegments(void* ptr, Segment3d* segments, int count)
{
	Polyline3<EEK>::GetSegments(ptr, segments, count);
}

void Polyline3_EEK_SetPoint(void* ptr, int index, const Point3d& point)
{
	Polyline3<EEK>::SetPoint(ptr, index, point);
}

void Polyline3_EEK_SetPoints(void* ptr, Point3d* points, int count)
{
	Polyline3<EEK>::SetPoints(ptr, points, count);
}

void Polyline3_EEK_Transform(void* ptr, const Matrix4x4d& matrix)
{
	Polyline3<EEK>::Transform(ptr, matrix);
}

