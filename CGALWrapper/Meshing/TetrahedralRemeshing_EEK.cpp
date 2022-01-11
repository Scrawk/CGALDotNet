#include "TetrahedralRemeshing_EEK.h"

#include "TetrahedralRemeshing.h"

#include <CGAL/Tetrahedral_remeshing/Remeshing_triangulation_3.h>
#include <CGAL/tetrahedral_remeshing.h>

void* TetrahedralRemeshing_EEK_Create()
{
	return TetrahedralRemeshing<EEK>::NewTetrahedralRemeshing();
}

void TetrahedralRemeshing_EEK_Release(void* ptr)
{
	TetrahedralRemeshing<EEK>::DeleteTetrahedralRemeshing(ptr);
}

void TetrahedralRemeshing_EEK_GetPoints(void* ptr, Point3d* points, int count)
{
	TetrahedralRemeshing<EEK>::GetPoints(ptr, points, count);
}

int TetrahedralRemeshing_EEK_Remesh(void* ptr, double targetLength, int iterations, Point3d* points, int count)
{
	/*
	typedef typename CGAL::Tetrahedral_remeshing::Remeshing_triangulation_3<EIK> Remeshing_triangulation;
	typedef typename Remeshing_triangulation::Point Point;

	std::vector<Point> points;
	points.push_back(Point(1, 0, 0));
	points.push_back(Point(0, 1, 0));
	points.push_back(Point(0, 0, 1));
	points.push_back(Point(0, 0, 0));

	Remeshing_triangulation tr = Remeshing_triangulation(points.begin(), points.end());

	CGAL::tetrahedral_isotropic_remeshing(tr, target_edge_length, CGAL::parameters::number_of_iterations(iterations));

	std::cout << "Number of cells " << tr.number_of_cells() << std::endl;

	for (auto v = tr.vertices_begin(); v != tr.vertices_end(); ++v)
	{
		auto p = v->point();
		buffer.push_back(Point3d::FromCGAL<EIK>(p));
	}
	*/

	return TetrahedralRemeshing<EIK>::Remesh(ptr, targetLength, iterations, points, count);
}
