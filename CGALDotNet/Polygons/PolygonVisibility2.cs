using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;

namespace CGALDotNet.Polygons
{
    public sealed class PolygonVisibility2<K> : PolygonVisibility2 where K : CGALKernel, new()
    {

    }

    public abstract class PolygonVisibility2 : CGALObject
    {
        protected override void ReleasePtr()
        {
            
        }
    }
}
