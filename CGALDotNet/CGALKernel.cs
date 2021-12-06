using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;
using CGALDotNet.Arrangements;
using CGALDotNet.Triangulations;
using CGALDotNet.Hulls;
using CGALDotNet.PolyHedra;
using CGALDotNet.Meshing;

namespace CGALDotNet
{
    public abstract class CGALKernel
    {

        internal abstract GeometryKernel2 GeometryKernel2 { get; }

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

        internal abstract DelaunayTriangulationKernel2 DelaunayTriangulationKernel2 { get; }

        internal abstract ConstrainedTriangulationKernel2 ConstrainedTriangulationKernel2 { get; }

        internal abstract ConformingTriangulationKernel2 ConformingTriangulationKernel2 { get; }

        internal abstract ConvexHullKernel2 ConvexHullKernel2 { get; }

        internal abstract PolyhedronKernel3 PolyhedronKernel3 { get; }

        internal abstract NefPolyhedronKernel3 NefPolyhedronKernel3 { get; }

        internal abstract SurfaceMeshKernel3 SurfaceMeshKernel3 { get; }

        internal abstract SurfaceMesherKernel3 SurfaceMesherKernel3 { get; }
    }

    public class EIK : CGALKernel
    {
        public static readonly EIK Instance = new EIK();

        internal override GeometryKernel2 GeometryKernel2 => throw new NotImplementedException();

        internal override PolygonKernel2 PolygonKernel2 => throw new NotImplementedException();

        internal override PolygonWithHolesKernel2 PolygonWithHolesKernel2 => throw new NotImplementedException();

        internal override PolygonBooleanKernel2 PolygonBooleanKernel2 => throw new NotImplementedException();

        internal override PolygonPartitionKernel2 PolygonPartitionKernel2 => throw new NotImplementedException();

        internal override PolygonSimplificationKernel2 PolygonSimplificationKernel2 => throw new NotImplementedException();

        internal override PolygonOffsetKernel2 PolygonOffsetKernel2 => throw new NotImplementedException();

        internal override PolygonMinkowskiKernel PolygonMinkowskiKernel => throw new NotImplementedException();

        internal override PolygonVisibilityKernel PolygonVisibilityKernel => throw new NotImplementedException();

        internal override ArrangementKernel2 ArrangementKernel2 => throw new NotImplementedException();

        internal override SweepLineKernel SweepLineKernel => throw new NotImplementedException();

        internal override TriangulationKernel2 TriangulationKernel2 => throw new NotImplementedException();

        internal override DelaunayTriangulationKernel2 DelaunayTriangulationKernel2 => throw new NotImplementedException();

        internal override ConstrainedTriangulationKernel2 ConstrainedTriangulationKernel2 => throw new NotImplementedException();

        internal override ConformingTriangulationKernel2 ConformingTriangulationKernel2 => throw new NotImplementedException();

        internal override ConvexHullKernel2 ConvexHullKernel2 => throw new NotImplementedException();

        internal override PolyhedronKernel3 PolyhedronKernel3 => throw new NotImplementedException();

        internal override NefPolyhedronKernel3 NefPolyhedronKernel3 => throw new NotImplementedException();

        internal override SurfaceMeshKernel3 SurfaceMeshKernel3 => throw new NotImplementedException();

        internal override SurfaceMesherKernel3 SurfaceMesherKernel3 => SurfaceMesherKernel3_EIK.Instance;
    }

    public class EEK : CGALKernel
    {
        public static readonly EEK Instance = new EEK();

        internal override GeometryKernel2 GeometryKernel2 => GeometryKernel2_EEK.Instance;

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

        internal override DelaunayTriangulationKernel2 DelaunayTriangulationKernel2 => DelaunayTriangulationKernel2_EEK.Instance;

        internal override ConstrainedTriangulationKernel2 ConstrainedTriangulationKernel2 => ConstrainedTriangulationKernel2_EEK.Instance;

        internal override ConformingTriangulationKernel2 ConformingTriangulationKernel2 => ConformingTriangulationKernel2_EEK.Instance;

        internal override ConvexHullKernel2 ConvexHullKernel2 => ConvexHullKernel2_EEK.Instance;

        internal override PolyhedronKernel3 PolyhedronKernel3 => PolyhedronKernel3_EEK.Instance;

        internal override NefPolyhedronKernel3 NefPolyhedronKernel3 => NefPolyhedronKernel3_EEK.Instance;

        internal override SurfaceMeshKernel3 SurfaceMeshKernel3 => SurfaceMeshKernel3_EEK.Instance;

        internal override SurfaceMesherKernel3 SurfaceMesherKernel3 => throw new NotImplementedException();
    }

}
