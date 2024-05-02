#include "VersionNumber.h"
// #include "Eigen\src\Core\util\Macros.h"
#include <Eigen/src/Core/util/Macros.h>

int CGALGlobal_VersionNumber()
{
	return CGAL_VERSION_NR;

	//CGAL_VERSION_MAJOR (CGAL_VERSION_NR/10000000%100)
	//CGAL_VERSION_MINOR (CGAL_VERSION_NR/100000%100)
	//CGAL_VERSION_PATCH (CGAL_VERSION_NR/10000%10)
	// CGAL_VERSION_BUILD (CGAL_VERSION_NR%10000)

	//CGAL_VERSION_NUMBER(M, m, b)
	//CGAL_VERSION_NUMBER(x, y, z) (1000001 + 10000 * x + 100 * y + 10 * z) * 1000
}

Index3 CGALGlobal_EigenVersionNumber()
{
	return { EIGEN_WORLD_VERSION, EIGEN_MAJOR_VERSION , EIGEN_MINOR_VERSION };
}
