using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polygons;
using CGALDotNet.Arrangements;
using CGALDotNet.Triangulations;
using CGALDotNet.Hulls;

namespace CGALDotNet
{
    public abstract class CGALKernel
    {
        internal abstract PolygonKernel2 PolygonKernel2 { get; }

        internal abstract PolygonWithHolesKernel2 PolygonWithHolesKernel2 { get; }

        internal abstract PolygonBooleanKernel2 PolygonBooleanKernel2 { get; }

        internal abstract PolygonPartitionKernel2 PolygonPartitionKernel2 { get; }

        internal abstract PolygonSimplificationKernel2 PolygonSimplificationKernel2 { get; }

        internal abstract ArrangementKernel2 ArrangementKernel2 { get; }

        internal abstract TriangulationKernel2 TriangulationKernel2 { get; }

        internal abstract DelaunayTriangulationKernel2 DelaunayTriangulationKernel2 { get; }

        internal abstract ConstrainedTriangulationKernel2 ConstrainedTriangulationKernel2 { get; }

        internal abstract ConvexHullKernel2 ConvexHullKernel2 { get; }
    }

    public class EEK : CGALKernel
    {
        public static readonly EEK Instance = new EEK();

        internal override PolygonKernel2 PolygonKernel2 => PolygonKernel2_EEK.Instance;

        internal override PolygonWithHolesKernel2 PolygonWithHolesKernel2 => PolygonWithHolesKernel2_EEK.Instance;

        internal override PolygonBooleanKernel2 PolygonBooleanKernel2 => PolygonBooleanKernel2_EEK.Instance;

        internal override PolygonPartitionKernel2 PolygonPartitionKernel2 => PolygonPartitionKernel2_EEK.Instance;

        internal override PolygonSimplificationKernel2 PolygonSimplificationKernel2 => PolygonSimplificationKernel2_EEK.Instance;

        internal override ArrangementKernel2 ArrangementKernel2 => ArrangementKernel2_EEK.Instance;

        internal override TriangulationKernel2 TriangulationKernel2 => TriangulationKernel2_EEK.Instance;

        internal override DelaunayTriangulationKernel2 DelaunayTriangulationKernel2 => DelaunayTriangulationKernel2_EEK.Instance;

        internal override ConstrainedTriangulationKernel2 ConstrainedTriangulationKernel2 => ConstrainedTriangulationKernel2_EEK.Instance;

        internal override ConvexHullKernel2 ConvexHullKernel2 => ConvexHullKernel2_EEK.Instance;
    }
}
