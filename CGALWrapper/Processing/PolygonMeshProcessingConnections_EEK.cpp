#include "PolygonMeshProcessingConnections_EEK.h"
#include "PolygonMeshProcessingConnections.h"

#include <CGAL/Polyhedron_3.h>
#include <CGAL/Surface_mesh.h>
#include <CGAL/Polygon_mesh_processing/connected_components.h>
#include <CGAL/boost/graph/Face_filtered_graph.h>
#include <boost/property_map/property_map.hpp>
#include <boost/iterator/function_output_iterator.hpp>

void* PolygonMeshProcessingConnections_EEK_Create()
{
	return PolygonMeshProcessingConnections<EEK>::NewPolygonMeshProcessingConnections();
}

void PolygonMeshProcessingConnections_EEK_Release(void* ptr)
{
	PolygonMeshProcessingConnections<EEK>::DeletePolygonMeshProcessingConnections(ptr);
}

//Polyhedron

int PolygonMeshProcessingConnections_EEK_ConnectedComponents_PH(void* meshPtr)
{
	return PolygonMeshProcessingConnections<EEK>::ConnectedComponents_PH(meshPtr);
}

int PolygonMeshProcessingConnections_EEK_ConnectedComponent_PH(void* meshPtr, int index)
{
	return PolygonMeshProcessingConnections<EEK>::ConnectedComponent_PH(meshPtr, index);
}

int PolygonMeshProcessingConnections_EEK_SplitConnectedComponents_PH(void* ptr, void* meshPtr)
{
	return PolygonMeshProcessingConnections<EEK>::SplitConnectedComponents_PH(ptr, meshPtr);
}

void PolygonMeshProcessingConnections_EEK_GetSplitConnectedComponents_PH(void* ptr, void** meshPtrs, int count)
{
	PolygonMeshProcessingConnections<EEK>::GetSplitConnectedComponents_PH(ptr, meshPtrs, count);
}

int PolygonMeshProcessingConnections_EEK_KeepLargestConnectedComponents_PH(void* meshPtr, int nb_components_to_keep)
{
	return PolygonMeshProcessingConnections<EEK>::KeepLargestConnectedComponents_PH(meshPtr, nb_components_to_keep);
}

//Surface Mesh

int PolygonMeshProcessingConnections_EEK_ConnectedComponents_SM(void* meshPtr)
{
	return PolygonMeshProcessingConnections<EEK>::ConnectedComponents_SM(meshPtr);
}

int PolygonMeshProcessingConnections_EEK_ConnectedComponent_SM(void* meshPtr, int index)
{
	return PolygonMeshProcessingConnections<EEK>::ConnectedComponent_SM(meshPtr, index);
}

int PolygonMeshProcessingConnections_EEK_SplitConnectedComponents_SM(void* ptr, void* meshPtr)
{
	return PolygonMeshProcessingConnections<EEK>::SplitConnectedComponents_SM(ptr, meshPtr);
}

void PolygonMeshProcessingConnections_EEK_GetSplitConnectedComponents_SM(void* ptr, void** meshPtrs, int count)
{
	PolygonMeshProcessingConnections<EEK>::GetSplitConnectedComponents_SM(ptr, meshPtrs, count);
}

int PolygonMeshProcessingConnections_EEK_KeepLargestConnectedComponents_SM(void* meshPtr, int nb_components_to_keep)
{
	return PolygonMeshProcessingConnections<EEK>::KeepLargestConnectedComponents_SM(meshPtr, nb_components_to_keep);
}
