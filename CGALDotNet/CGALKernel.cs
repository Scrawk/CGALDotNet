using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polygons;

namespace CGALDotNet
{
    public abstract class CGALKernel
    {
        internal abstract PolygonKernel2 PolygonKernel2 { get; }

        internal abstract PolygonWithHolesKernel2 PolygonWithHolesKernel2 { get; }

        internal abstract PolygonBooleanKernel2 PolygonBooleanKernel2 { get; }
    }

    public class EEK : CGALKernel
    {
        public static readonly EEK Instance = new EEK();

        internal override PolygonKernel2 PolygonKernel2 => PolygonKernel2_EEK.Instance;

        internal override PolygonWithHolesKernel2 PolygonWithHolesKernel2 => PolygonWithHolesKernel2_EEK.Instance;

        internal override PolygonBooleanKernel2 PolygonBooleanKernel2 => PolygonBooleanKernel2_EEK.Instance;
    }
}
