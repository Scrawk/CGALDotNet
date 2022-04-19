using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polylines;
using CGALDotNet.Polygons;
using CGALDotNet.Arrangements;
using CGALDotNet.Triangulations;
using CGALDotNet.Hulls;
using CGALDotNet.Polyhedra;
using CGALDotNet.Meshing;
using CGALDotNet.Processing;

namespace CGALDotNet
{
    public abstract class CGALKernel
    {

        internal abstract GeometryKernel2 GeometryKernel2 { get; }

        internal abstract PolylineKernel2 PolylineKernel2 { get; }

        internal abstract PolylineKernel3 PolylineKernel3 { get; }

        internal abstract PolygonKernel2 PolygonKernel2 { get; }

        internal abstract PolygonWithHolesKernel2 PolygonWithHolesKernel2 { get; }

        internal abstract PolygonBooleanKernel2 PolygonBooleanKernel2 { get; }

        internal abstract PolygonPartitionKernel2 PolygonPartitionKernel2 { get; }

        internal abstract PolygonSimplificationKernel2 PolygonSimplificationKernel2 { get; }

        internal abstract PolygonOffsetKernel2 PolygonOffsetKernel2 { get; }

        internal abstract PolygonMinkowskiKernel PolygonMinkowskiKernel { get; }

        internal abstract PolygonVisibilityKernel PolygonVisibilityKernel { get; }

        internal abstract ArrangementKernel2 ArrangementKernel2 { get; }

        internal abstract SweepLineKernel SweepLineKernel { get; }

        internal abstract TriangulationKernel2 TriangulationKernel2 { get; }

        internal abstract TriangulationKernel3 TriangulationKernel3 { get; }

        internal abstract DelaunayTriangulationKernel2 DelaunayTriangulationKernel2 { get; }

        internal abstract DelaunayTriangulationKernel3 DelaunayTriangulationKernel3 { get; }

        internal abstract ConstrainedTriangulationKernel2 ConstrainedTriangulationKernel2 { get; }

        internal abstract ConstrainedDelaunayTriangulationKernel2 ConstrainedDelaunayTriangulationKernel2 { get; }

        internal abstract ConformingTriangulationKernel2 ConformingTriangulationKernel2 { get; }

        internal abstract ConvexHullKernel2 ConvexHullKernel2 { get; }

        internal abstract ConvexHullKernel3 ConvexHullKernel3 { get; }

        internal abstract PolyhedronKernel3 PolyhedronKernel3 { get; }

        internal abstract NefPolyhedronKernel3 NefPolyhedronKernel3 { get; }

        internal abstract SurfaceMeshKernel3 SurfaceMeshKernel3 { get; }

        internal abstract TetrahedralRemeshingKernel TetrahedralRemeshingKernel  { get; }

        internal abstract SurfaceSubdivisionKernel SurfaceSubdivisionKernel { get; }

        internal abstract SurfaceSimplificationKernel SurfaceSimplificationKernel { get; }

        internal abstract SkinSurfaceMeshingKernel SkinSurfaceMeshingKernel { get; }

        internal abstract MeshProcessingMeshingKernel MeshProcessingMeshingKernel { get; }

        internal abstract MeshProcessingRepairKernel MeshProcessingRepairKernel { get; }

        internal abstract MeshProcessingOrientationKernel MeshProcessingOrientationKernel { get; }

        internal abstract MeshProcessingBooleanKernel MeshProcessingBooleanKernel { get; }

        internal abstract MeshProcessingConnectionsKernel MeshProcessingConnectionsKernel { get; }

        internal abstract MeshProcessingSlicerKernel MeshProcessingSlicerKernel { get; }

        internal abstract MeshProcessingFeaturesKernel MeshProcessingFeaturesKernel { get; }

        internal abstract MeshProcessingLocateKernel MeshProcessingLocateKernel { get; }

        internal abstract HeatMethodKernel HeatMethodKernel { get; }
    }

    public class EIK : CGALKernel
    {
        public static readonly EIK Instance = new EIK();

        internal override GeometryKernel2 GeometryKernel2 => GeometryKernel2_EIK.Instance;

        internal override PolylineKernel2 PolylineKernel2 => PolylineKernel2_EIK.Instance;

        internal override PolylineKernel3 PolylineKernel3 => PolylineKernel3_EIK.Instance;

        internal override PolygonKernel2 PolygonKernel2 => PolygonKernel2_EIK.Instance;

        internal override PolygonWithHolesKernel2 PolygonWithHolesKernel2 => PolygonWithHolesKernel2_EIK.Instance;

        internal override PolygonBooleanKernel2 PolygonBooleanKernel2 => PolygonBooleanKernel2_EIK.Instance;

        internal override PolygonPartitionKernel2 PolygonPartitionKernel2 => PolygonPartitionKernel2_EIK.Instance;

        internal override PolygonSimplificationKernel2 PolygonSimplificationKernel2 => PolygonSimplificationKernel2_EIK.Instance;

        internal override PolygonOffsetKernel2 PolygonOffsetKernel2 => PolygonOffsetKernel2_EIK.Instance;

        internal override PolygonMinkowskiKernel PolygonMinkowskiKernel => PolygonMinkowskiKernel_EIK.Instance;

        internal override PolygonVisibilityKernel PolygonVisibilityKernel => PolygonVisibilityKernel_EIK.Instance;

        internal override ArrangementKernel2 ArrangementKernel2 => throw new NotImplementedException();

        internal override SweepLineKernel SweepLineKernel => SweepLineKernel_EIK.Instance;

        internal override TriangulationKernel2 TriangulationKernel2 => TriangulationKernel2_EIK.Instance;

        internal override TriangulationKernel3 TriangulationKernel3 => throw new NotImplementedException();

        internal override DelaunayTriangulationKernel2 DelaunayTriangulationKernel2 => DelaunayTriangulationKernel2_EIK.Instance;

        internal override DelaunayTriangulationKernel3 DelaunayTriangulationKernel3 => throw new NotImplementedException();

        internal override ConstrainedTriangulationKernel2 ConstrainedTriangulationKernel2 => ConstrainedTriangulationKernel2_EIK.Instance;

        internal override ConstrainedDelaunayTriangulationKernel2 ConstrainedDelaunayTriangulationKernel2 => throw new NotImplementedException();

        internal override ConformingTriangulationKernel2 ConformingTriangulationKernel2 => ConformingTriangulationKernel2_EIK.Instance;

        internal override ConvexHullKernel2 ConvexHullKernel2 => ConvexHullKernel2_EIK.Instance;

        internal override ConvexHullKernel3 ConvexHullKernel3 => ConvexHullKernel3_EIK.Instance;

        internal override PolyhedronKernel3 PolyhedronKernel3 => PolyhedronKernel3_EIK.Instance;

        internal override NefPolyhedronKernel3 NefPolyhedronKernel3 => NefPolyhedronKernel3_EIK.Instance;

        internal override SurfaceMeshKernel3 SurfaceMeshKernel3 => SurfaceMeshKernel3_EIK.Instance;

        internal override TetrahedralRemeshingKernel TetrahedralRemeshingKernel => throw new NotImplementedException();

        internal override SurfaceSubdivisionKernel SurfaceSubdivisionKernel => SurfaceSubdivisionKernel_EIK.Instance;

        internal override SurfaceSimplificationKernel SurfaceSimplificationKernel => SurfaceSimplificationKernel_EIK.Instance;

        internal override SkinSurfaceMeshingKernel SkinSurfaceMeshingKernel => throw new NotImplementedException();

        internal override MeshProcessingMeshingKernel MeshProcessingMeshingKernel => MeshProcessingMeshingKernel_EIK.Instance;

        internal override MeshProcessingRepairKernel MeshProcessingRepairKernel => MeshProcessingRepairKernel_EIK.Instance;

        internal override MeshProcessingOrientationKernel MeshProcessingOrientationKernel => MeshProcessingOrientationKernel_EIK.Instance;

        internal override MeshProcessingBooleanKernel MeshProcessingBooleanKernel => MeshProcessingBooleanKernel_EIK.Instance;

        internal override MeshProcessingConnectionsKernel MeshProcessingConnectionsKernel => MeshProcessingConnectionsKernel_EIK.Instance;

        internal override MeshProcessingSlicerKernel MeshProcessingSlicerKernel => MeshProcessingSlicerKernel_EIK.Instance;

        internal override MeshProcessingFeaturesKernel MeshProcessingFeaturesKernel => MeshProcessingFeaturesKernel_EIK.Instance;

        internal override MeshProcessingLocateKernel MeshProcessingLocateKernel => MeshProcessingLocateKernel_EIK.Instance;

        internal override HeatMethodKernel HeatMethodKernel => HeatMethodKernel_EIK.Instance;
    }

    public class EEK : CGALKernel
    {
        public static readonly EEK Instance = new EEK();

        internal override GeometryKernel2 GeometryKernel2 => GeometryKernel2_EEK.Instance;

        internal override PolylineKernel2 PolylineKernel2 => PolylineKernel2_EEK.Instance;

        internal override PolylineKernel3 PolylineKernel3 => PolylineKernel3_EEK.Instance;

        internal override PolygonKernel2 PolygonKernel2 => PolygonKernel2_EEK.Instance;

        internal override PolygonWithHolesKernel2 PolygonWithHolesKernel2 => PolygonWithHolesKernel2_EEK.Instance;

        internal override PolygonBooleanKernel2 PolygonBooleanKernel2 => PolygonBooleanKernel2_EEK.Instance;

        internal override PolygonPartitionKernel2 PolygonPartitionKernel2 => PolygonPartitionKernel2_EEK.Instance;

        internal override PolygonSimplificationKernel2 PolygonSimplificationKernel2 => PolygonSimplificationKernel2_EEK.Instance;

        internal override PolygonOffsetKernel2 PolygonOffsetKernel2 => PolygonOffsetKernel2_EEK.Instance;

        internal override PolygonMinkowskiKernel PolygonMinkowskiKernel => PolygonMinkowskiKernel_EEK.Instance;

        internal override PolygonVisibilityKernel PolygonVisibilityKernel => PolygonVisibilityKernel_EEK.Instance;

        internal override ArrangementKernel2 ArrangementKernel2 => ArrangementKernel2_EEK.Instance;

        internal override SweepLineKernel SweepLineKernel => SweepLineKernel_EEK.Instance;

        internal override TriangulationKernel2 TriangulationKernel2 => TriangulationKernel2_EEK.Instance;

        internal override TriangulationKernel3 TriangulationKernel3 => TriangulationKernel3_EEK.Instance;

        internal override DelaunayTriangulationKernel2 DelaunayTriangulationKernel2 => DelaunayTriangulationKernel2_EEK.Instance;

        internal override DelaunayTriangulationKernel3 DelaunayTriangulationKernel3 => DelaunayTriangulationKernel3_EEK.Instance;

        internal override ConstrainedTriangulationKernel2 ConstrainedTriangulationKernel2 => ConstrainedTriangulationKernel2_EEK.Instance;

        internal override ConstrainedDelaunayTriangulationKernel2 ConstrainedDelaunayTriangulationKernel2 => ConstrainedDelaunayTriangulationKernel2_EEK.Instance;

        internal override ConformingTriangulationKernel2 ConformingTriangulationKernel2 => ConformingTriangulationKernel2_EEK.Instance;

        internal override ConvexHullKernel2 ConvexHullKernel2 => ConvexHullKernel2_EEK.Instance;

        internal override ConvexHullKernel3 ConvexHullKernel3 => ConvexHullKernel3_EEK.Instance;

        internal override PolyhedronKernel3 PolyhedronKernel3 => PolyhedronKernel3_EEK.Instance;

        internal override NefPolyhedronKernel3 NefPolyhedronKernel3 => NefPolyhedronKernel3_EEK.Instance;

        internal override SurfaceMeshKernel3 SurfaceMeshKernel3 => SurfaceMeshKernel3_EEK.Instance;

        internal override TetrahedralRemeshingKernel TetrahedralRemeshingKernel => TetrahedralRemeshingKernel_EEK.Instance;

        internal override SurfaceSubdivisionKernel SurfaceSubdivisionKernel => SurfaceSubdivisionKernel_EEK.Instance;

        internal override SurfaceSimplificationKernel SurfaceSimplificationKernel => throw new NotSupportedException();

        internal override SkinSurfaceMeshingKernel SkinSurfaceMeshingKernel => SkinSurfaceMeshingKernel_EEK.Instance;

        internal override MeshProcessingMeshingKernel MeshProcessingMeshingKernel => MeshProcessingMeshingKernel_EEK.Instance;

        internal override MeshProcessingRepairKernel MeshProcessingRepairKernel => MeshProcessingRepairKernel_EEK.Instance;

        internal override MeshProcessingOrientationKernel MeshProcessingOrientationKernel => MeshProcessingOrientationKernel_EEK.Instance;

        internal override MeshProcessingBooleanKernel MeshProcessingBooleanKernel => MeshProcessingBooleanKernel_EEK.Instance;

        internal override MeshProcessingConnectionsKernel MeshProcessingConnectionsKernel => MeshProcessingConnectionsKernel_EEK.Instance;

        internal override MeshProcessingSlicerKernel MeshProcessingSlicerKernel => MeshProcessingSlicerKernel_EEK.Instance;

        internal override MeshProcessingFeaturesKernel MeshProcessingFeaturesKernel => MeshProcessingFeaturesKernel_EEK.Instance;

        internal override MeshProcessingLocateKernel MeshProcessingLocateKernel => MeshProcessingLocateKernel_EEK.Instance;

        internal override HeatMethodKernel HeatMethodKernel => HeatMethodKernel_EEK.Instance;
    }

}
