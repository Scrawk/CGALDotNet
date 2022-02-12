#include "MeshProcessingConnections_EIK.h"
#include "MeshProcessingConnections.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Surface_mesh.h>
#include <CGAL/Polygon_mesh_processing/connected_components.h>
#include <CGAL/boost/graph/Face_filtered_graph.h>
#include <boost/property_map/property_map.hpp>
#include <boost/iterator/function_output_iterator.hpp>

void* MeshProcessingConnections_EIK_Create()
{
	return MeshProcessingConnections<EIK>::NewMeshProcessingConnections();
}

void MeshProcessingConnections_EIK_Release(void* ptr)
{
	MeshProcessingConnections<EIK>::DeleteMeshProcessingConnections(ptr);
}

//Polyhedron

int MeshProcessingConnections_EIK_ConnectedComponents_PH(void* meshPtr)
{
	return MeshProcessingConnections<EIK>::ConnectedComponents_PH(meshPtr);
}

int MeshProcessingConnections_EIK_ConnectedComponent_PH(void* ptr, void* meshPtr, int index)
{
	return MeshProcessingConnections<EIK>::ConnectedComponent_PH(ptr, meshPtr, index);
}

void MeshProcessingConnections_EIK_GetConnectedComponentsFaceIndex_PH(void* ptr, void* meshPtr, int* indices, int count)
{
	MeshProcessingConnections<EIK>::GetConnectedComponentFaceIndex_PH(ptr, meshPtr, indices, count);
}

int MeshProcessingConnections_EIK_SplitConnectedComponents_PH(void* ptr, void* meshPtr)
{
	return MeshProcessingConnections<EIK>::SplitConnectedComponents_PH(ptr, meshPtr);
}

void MeshProcessingConnections_EIK_GetSplitConnectedComponents_PH(void* ptr, void** meshPtrs, int count)
{
	MeshProcessingConnections<EIK>::GetSplitConnectedComponents_PH(ptr, meshPtrs, count);
}

int MeshProcessingConnections_EIK_KeepLargeConnectedComponents_PH(void* meshPtr, int threshold_value)
{
	return MeshProcessingConnections<EIK>::KeepLargeConnectedComponents_PH(meshPtr, threshold_value);
}

int MeshProcessingConnections_EIK_KeepLargestConnectedComponents_PH(void* meshPtr, int nb_components_to_keep)
{
	return MeshProcessingConnections<EIK>::KeepLargestConnectedComponents_PH(meshPtr, nb_components_to_keep);
}

//Surface Mesh

int MeshProcessingConnections_EIK_ConnectedComponents_SM(void* meshPtr)
{
	return MeshProcessingConnections<EIK>::ConnectedComponents_SM(meshPtr);
}

int MeshProcessingConnections_EIK_ConnectedComponent_SM(void* ptr, void* meshPtr, int index)
{
	return MeshProcessingConnections<EIK>::ConnectedComponent_SM(ptr, meshPtr, index);
}

void MeshProcessingConnections_EIK_GetConnectedComponentsFaceIndex_SM(void* ptr, void* meshPtr, int* indices, int count)
{
	MeshProcessingConnections<EIK>::GetConnectedComponentFaceIndex_SM(ptr, meshPtr, indices, count);
}

int MeshProcessingConnections_EIK_SplitConnectedComponents_SM(void* ptr, void* meshPtr)
{
	return MeshProcessingConnections<EIK>::SplitConnectedComponents_SM(ptr, meshPtr);
}

void MeshProcessingConnections_EIK_GetSplitConnectedComponents_SM(void* ptr, void** meshPtrs, int count)
{
	MeshProcessingConnections<EIK>::GetSplitConnectedComponents_SM(ptr, meshPtrs, count);
}

int MeshProcessingConnections_EIK_KeepLargeConnectedComponents_SM(void* meshPtr, int threshold_value)
{
	return MeshProcessingConnections<EIK>::KeepLargeConnectedComponents_SM(meshPtr, threshold_value);
}

int MeshProcessingConnections_EIK_KeepLargestConnectedComponents_SM(void* meshPtr, int nb_components_to_keep)
{
	return MeshProcessingConnections<EIK>::KeepLargestConnectedComponents_SM(meshPtr, nb_components_to_keep);
}
