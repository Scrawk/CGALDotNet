
#include "Polyline2_EEK.h"
#include "Polyline2.h"

void* Polyline2_EEK_Create()
{
	return Polyline2<EEK>::NewPolyline2();

}
void* Polyline2_EEK_CreateWithCount(int count)
{
	return Polyline2<EEK>::NewPolyline2(count);
}

void Polyline2_EEK_Release(void* ptr)
{
	Polyline2<EEK>::DeletePolyline2(ptr);
}

int Polyline2_EEK_Count(void* ptr)
{
	return Polyline2<EEK>::Count(ptr);
}

void* Polyline2_EEK_Copy(void* ptr)
{
	return Polyline2<EEK>::Copy(ptr);
}

void* Polyline2_EEK_Convert(void* ptr, CGAL_KERNEL k)
{
	switch (k)
	{
	case CGAL_KERNEL::EXACT_PREDICATES_INEXACT_CONSTRUCTION:
		return Polyline2<EEK>::Convert<EIK>(ptr);

	case CGAL_KERNEL::EXACT_PREDICATES_EXACT_CONSTRUCTION:
		return Polyline2<EEK>::Convert<EEK>(ptr);

	default:
		return Polyline2<EEK>::Convert<EEK>(ptr);
	}
}

void Polyline2_EEK_Clear(void* ptr)
{
	Polyline2<EEK>::Clear(ptr);
}

int Polyline2_EEK_Capacity(void* ptr)
{
	return Polyline2<EEK>::Capacity(ptr);
}

void Polyline2_EEK_Resize(void* ptr, int count)
{
	Polyline2<EEK>::Resize(ptr, count);
}

void Polyline2_EEK_Reverse(void* ptr)
{
	Polyline2<EEK>::Reverse(ptr);
}

void Polyline2_EEK_ShrinkToFit(void* ptr)
{
	Polyline2<EEK>::ShrinkToFit(ptr);
}

void Polyline2_EEK_Erase(void* ptr, int index) 
{
	Polyline2<EEK>::Erase(ptr, index);
}

void Polyline2_EEK_EraseRange(void* ptr, int start, int count)
{
	Polyline2<EEK>::Erase(ptr, start, count);
}

void Polyline2_EEK_Insert(void* ptr, int index, Point2d point)
{
	Polyline2<EEK>::Insert(ptr, index, point);
}

void Polyline2_EEK_InsertRange(void* ptr, int start, int count, Point2d* points)
{
	Polyline2<EEK>::Insert(ptr, start, count, points);
}

BOOL Polyline2_EEK_IsClosed(void* ptr, double threshold)
{
	return Polyline2<EEK>::IsClosed(ptr, threshold);
}

double Polyline2_EEK_SqLength(void* ptr)
{
	return Polyline2<EEK>::SqLength(ptr);
}

Point2d Polyline2_EEK_GetPoint(void* ptr, int index)
{
	return Polyline2<EEK>::GetPoint(ptr, index);
}

void Polyline2_EEK_GetPoints(void* ptr, Point2d* points, int count)
{
	Polyline2<EEK>::GetPoints(ptr, points, count);
}

void Polyline2_EEK_GetSegments(void* ptr, Segment2d* segments, int count)
{
	Polyline2<EEK>::GetSegments(ptr, segments, count);
}

void Polyline2_EEK_SetPoint(void* ptr, int index, const Point2d& point)
{
	Polyline2<EEK>::SetPoint(ptr, index, point);
}

void Polyline2_EEK_SetPoints(void* ptr, Point2d* points, int count)
{
	Polyline2<EEK>::SetPoints(ptr, points, count);
}

void Polyline2_EEK_Translate(void* ptr, const Point2d& translation)
{
	Polyline2<EEK>::Translate(ptr, translation);
}

void Polyline2_EEK_Rotate(void* ptr, double rotation)
{
	Polyline2<EEK>::Rotate(ptr, rotation);
}

void Polyline2_EEK_Scale(void* ptr, double scale)
{
	Polyline2<EEK>::Scale(ptr, scale);
}

void Polyline2_EEK_Transform(void* ptr, const Point2d& translation, double rotation, double scale)
{
	Polyline2<EEK>::Transform(ptr, translation, rotation, scale);
}

