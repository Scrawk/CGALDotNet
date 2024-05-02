#pragma once

#include "../CGALWrapper.h"
#include "../Geometry/Geometry2.h"
#include "../Geometry/Geometry3.h"
#include <CGAL/enum.h>

extern "C"
{

	CGALWRAPPER_API void* EigenMatrix_Create(int rows, int columns);

	CGALWRAPPER_API void* EigenMatrix_CreateIdentity(int rows, int columns);

	CGALWRAPPER_API void EigenMatrix_Release(void* ptr);

	CGALWRAPPER_API int EigenMatrix_Rows(void* ptr);

	CGALWRAPPER_API int EigenMatrix_Columns(void* ptr);

	CGALWRAPPER_API double EigenMatrix_GetXY(void* ptr, int x, int y);

	CGALWRAPPER_API void EigenMatrix_SetXY(void* ptr, int x, int y, double value);

	CGALWRAPPER_API double EigenMatrix_GetX(void* ptr, int x);

	CGALWRAPPER_API void EigenMatrix_SetX(void* ptr, int x, double value);

	CGALWRAPPER_API void* EigenMatrix_Transpose(void* ptr);

	CGALWRAPPER_API void* EigenMatrix_Conjugate(void* ptr);

	CGALWRAPPER_API void* EigenMatrix_Adjoint(void* ptr);

	CGALWRAPPER_API void* EigenMatrix_Inverse(void* ptr);

	CGALWRAPPER_API BOOL EigenMatrix_IsInvertible(void* ptr);

	CGALWRAPPER_API void* EigenMatrix_TryInverse(void* ptr);

	CGALWRAPPER_API double EigenMatrix_Determinant(void* ptr);

	CGALWRAPPER_API double EigenMatrix_Trace(void* ptr);

	CGALWRAPPER_API BOOL EigenMatrix_IsIdentity(void* ptr);

	CGALWRAPPER_API BOOL EigenMatrix_IsDiagonal(void* ptr);

	CGALWRAPPER_API BOOL EigenMatrix_IsUpperTriangular(void* ptr);

	CGALWRAPPER_API BOOL EigenMatrix_IsLowerTriangular(void* ptr);

	CGALWRAPPER_API void* EigenMatrix_MulScalar(void* ptr1, double s);

	CGALWRAPPER_API void* EigenMatrix_DivideScalar(void* ptr1, double s);

	CGALWRAPPER_API void* EigenMatrix_MulMatrix(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_AddMatrix(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_SubMatrix(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_MulColumnVector(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_MulRowVector(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_Block(void* ptr, int startRox, int startCol, int blockRows, int blockCols);

	CGALWRAPPER_API void* EigenMatrix_Reshaped(void* ptr, int rows, int cols);

	CGALWRAPPER_API void* EigenMatrix_ColPivHouseholderQr_Vec(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_ColPivHouseholderQr_Mat(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_PartialPivLu_Vec(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_PartialPivLu_Mat(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_FullPivLu_Vec(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_FullPivLu_Mat(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_HouseholderQr_Vec(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_HouseholderQr_Mat(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_LLT_Vec(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_LLT_Mat(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_LDLT_Vec(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_LDLT_Mat(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_BdcSvd_Vec(void* ptr1, void* ptr2, int options);

	CGALWRAPPER_API void* EigenMatrix_BdcSvd_Mat(void* ptr1, void* ptr2, int options);

	CGALWRAPPER_API void* EigenMatrix_JacobiSvd_Vec(void* ptr1, void* ptr2, int options);

	CGALWRAPPER_API void* EigenMatrix_JacobiSvd_Mat(void* ptr1, void* ptr2, int options);

	CGALWRAPPER_API void* EigenMatrix_FullPivHouseholderQr_Vec(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_FullPivHouseholderQr_Mat(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_CompleteOrthogonalDecomposition_Vec(void* ptr1, void* ptr2);

	CGALWRAPPER_API void* EigenMatrix_CompleteOrthogonalDecomposition_Mat(void* ptr1, void* ptr2);

	CGALWRAPPER_API double EigenMatrix_RelativeError_Vec(void* ptr1, void* ptr2, void* ptr3);

	CGALWRAPPER_API double EigenMatrix_RelativeError_Mat(void* ptr1, void* ptr2, void* ptr3);

	CGALWRAPPER_API void* EigenMatrix_Eigenvalues(void* ptr);

	CGALWRAPPER_API void* EigenMatrix_Eigenvectors(void* ptr);

	CGALWRAPPER_API BOOL EigenMatrix_EigenValuesVectors(void* ptr, void** values, void** vectors);
}



