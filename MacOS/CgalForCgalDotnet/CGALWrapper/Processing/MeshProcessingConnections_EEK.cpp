#include "MeshProcessingConnections_EEK.h"
#include "MeshProcessingConnections.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Surface_mesh.h>
#include <CGAL/Polygon_mesh_processing/connected_components.h>
#include <CGAL/boost/graph/Face_filtered_graph.h>
#include <boost/property_map/property_map.hpp>
#include <boost/iterator/function_output_iterator.hpp>

void* MeshProcessingConnections_EEK_Create()
{
	return MeshProcessingConnections<EEK>::NewMeshProcessingConnections();
}

void MeshProcessingConnections_EEK_Release(void* ptr)
{
	MeshProcessingConnections<EEK>::DeleteMeshProcessingConnections(ptr);
}

//Polyhedron

int MeshProcessingConnections_EEK_ConnectedComponents_PH(void* meshPtr)
{
	return MeshProcessingConnections<EEK>::ConnectedComponents_PH(meshPtr);
}

int MeshProcessingConnections_EEK_ConnectedComponent_PH(void* ptr, void* meshPtr, int index)
{
	return MeshProcessingConnections<EEK>::ConnectedComponent_PH(ptr, meshPtr, index);
}

void MeshProcessingConnections_EEK_GetConnectedComponentsFaceIndex_PH(void* ptr, void* meshPtr, int* indices, int count)
{
	MeshProcessingConnections<EEK>::GetConnectedComponentFaceIndex_PH(ptr, meshPtr, indices, count);
}

int MeshProcessingConnections_EEK_SplitConnectedComponents_PH(void* ptr, void* meshPtr)
{
	return MeshProcessingConnections<EEK>::SplitConnectedComponents_PH(ptr, meshPtr);
}

void MeshProcessingConnections_EEK_GetSplitConnectedComponents_PH(void* ptr, void** meshPtrs, int count)
{
	MeshProcessingConnections<EEK>::GetSplitConnectedComponents_PH(ptr, meshPtrs, count);
}

int MeshProcessingConnections_EEK_KeepLargeConnectedComponents_PH(void* meshPtr, int threshold_value)
{
	return MeshProcessingConnections<EEK>::KeepLargeConnectedComponents_PH(meshPtr, threshold_value);
}

int MeshProcessingConnections_EEK_KeepLargestConnectedComponents_PH(void* meshPtr, int nb_components_to_keep)
{
	return MeshProcessingConnections<EEK>::KeepLargestConnectedComponents_PH(meshPtr, nb_components_to_keep);
}

//Surface Mesh

int MeshProcessingConnections_EEK_ConnectedComponents_SM(void* meshPtr)
{
	return MeshProcessingConnections<EEK>::ConnectedComponents_SM(meshPtr);
}

int MeshProcessingConnections_EEK_ConnectedComponent_SM(void* ptr, void* meshPtr, int index)
{
	return MeshProcessingConnections<EEK>::ConnectedComponent_SM(ptr, meshPtr, index);
}

void MeshProcessingConnections_EEK_GetConnectedComponentsFaceIndex_SM(void* ptr, void* meshPtr, int* indices, int count)
{
	MeshProcessingConnections<EEK>::GetConnectedComponentFaceIndex_SM(ptr, meshPtr, indices, count);
}

int MeshProcessingConnections_EEK_SplitConnectedComponents_SM(void* ptr, void* meshPtr)
{
	return MeshProcessingConnections<EEK>::SplitConnectedComponents_SM(ptr, meshPtr);
}

void MeshProcessingConnections_EEK_GetSplitConnectedComponents_SM(void* ptr, void** meshPtrs, int count)
{
	MeshProcessingConnections<EEK>::GetSplitConnectedComponents_SM(ptr, meshPtrs, count);
}

int MeshProcessingConnections_EEK_KeepLargeConnectedComponents_SM(void* meshPtr, int threshold_value)
{
	return MeshProcessingConnections<EEK>::KeepLargeConnectedComponents_SM(meshPtr, threshold_value);
}

int MeshProcessingConnections_EEK_KeepLargestConnectedComponents_SM(void* meshPtr, int nb_components_to_keep)
{
	return MeshProcessingConnections<EEK>::KeepLargestConnectedComponents_SM(meshPtr, nb_components_to_keep);
}
