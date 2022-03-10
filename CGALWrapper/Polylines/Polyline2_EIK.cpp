
#include "Polyline2_EIK.h"
#include "Polyline2.h"

void* Polyline2_EIK_Create()
{
	return Polyline2<EIK>::NewPolyline2();

}
void* Polyline2_EIK_CreateWithCount(int count)
{
	return Polyline2<EIK>::NewPolyline2(count);
}

void Polyline2_EIK_Release(void* ptr)
{
	Polyline2<EIK>::DeletePolyline2(ptr);
}

int Polyline2_EIK_Count(void* ptr)
{
	return Polyline2<EIK>::Count(ptr);
}

void* Polyline2_EIK_Copy(void* ptr)
{
	return Polyline2<EIK>::Copy(ptr);
}

void* Polyline2_EIK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Polyline2<EIK>::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Polyline2<EIK>::Convert<EEK>(ptr);

	default:
		return Polyline2<EIK>::Convert<EIK>(ptr);
	}
}

void Polyline2_EIK_Clear(void* ptr)
{
	Polyline2<EIK>::Clear(ptr);
}

int Polyline2_EIK_Capacity(void* ptr)
{
	return Polyline2<EIK>::Capacity(ptr);
}

void Polyline2_EIK_Resize(void* ptr, int count)
{
	Polyline2<EIK>::Resize(ptr, count);
}

void Polyline2_EIK_Reverse(void* ptr)
{
	Polyline2<EIK>::Reverse(ptr);
}

void Polyline2_EIK_ShrinkToFit(void* ptr)
{
	Polyline2<EIK>::ShrinkToFit(ptr);
}

void Polyline2_EIK_Erase(void* ptr, int index)
{
	Polyline2<EIK>::Erase(ptr, index);
}

void Polyline2_EIK_EraseRange(void* ptr, int start, int count)
{
	Polyline2<EIK>::Erase(ptr, start, count);
}

void Polyline2_EIK_Insert(void* ptr, int index, Point2d point)
{
	Polyline2<EIK>::Insert(ptr, index, point);
}

void Polyline2_EIK_InsertRange(void* ptr, int start, int count, Point2d* points)
{
	Polyline2<EIK>::Insert(ptr, start, count, points);
}

BOOL Polyline2_EIK_IsClosed(void* ptr, double threshold)
{
	return Polyline2<EIK>::IsClosed(ptr, threshold);
}

double Polyline2_EIK_SqLength(void* ptr)
{
	return Polyline2<EIK>::SqLength(ptr);
}

Point2d Polyline2_EIK_GetPoint(void* ptr, int index)
{
	return Polyline2<EIK>::GetPoint(ptr, index);
}

void Polyline2_EIK_GetPoints(void* ptr, Point2d* points, int count)
{
	Polyline2<EIK>::GetPoints(ptr, points, count);
}

void Polyline2_EIK_GetSegments(void* ptr, Segment2d* segments, int count)
{
	Polyline2<EIK>::GetSegments(ptr, segments, count);
}

void Polyline2_EIK_SetPoint(void* ptr, int index, const Point2d& point)
{
	Polyline2<EIK>::SetPoint(ptr, index, point);
}

void Polyline2_EIK_SetPoints(void* ptr, Point2d* points, int count)
{
	Polyline2<EIK>::SetPoints(ptr, points, count);
}

void Polyline2_EIK_Translate(void* ptr, const Point2d& translation)
{
	Polyline2<EIK>::Translate(ptr, translation);
}

void Polyline2_EIK_Rotate(void* ptr, double rotation)
{
	Polyline2<EIK>::Rotate(ptr, rotation);
}

void Polyline2_EIK_Scale(void* ptr, double scale)
{
	Polyline2<EIK>::Scale(ptr, scale);
}

void Polyline2_EIK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	Polyline2<EIK>::Transform(ptr, translation, rotation, scale);
}

