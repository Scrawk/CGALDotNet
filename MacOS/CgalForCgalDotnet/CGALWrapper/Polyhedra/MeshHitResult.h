#pragma once
#include "../CGALWrapper.h"
#include "../Geometry/Geometry3.h"

struct MeshHitResult
{
    int face;

    Point3d point;

    Point3d coord;

    //BOOL on_face_border;
    //BOOL on_edge;
    //BOOL on_mesh_border;
    //BOOL on_vertex;
};
