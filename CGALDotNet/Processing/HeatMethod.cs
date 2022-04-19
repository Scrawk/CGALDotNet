using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNetGeometry.Numerics;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    public sealed class HeatMethod<K> : HeatMethod where K : CGALKernel, new()
    {

        public static readonly HeatMethod<K> Instance = new HeatMethod<K>();

        public HeatMethod() : base(new K())
        {

        }

        internal HeatMethod(IntPtr ptr) : base(new K(), ptr)
        {

        }

        public override string ToString()
        {
            return string.Format("[HeatMethod<{0}>: ]", Kernel.Name);
        }

        public double EstimateGeodesicDistances(SurfaceMesh3<K> mesh, int index, bool useIDT, List<double> distances)
        {
            int count = Kernel.EstimateGeodesicDistances_SM(Ptr, mesh.Ptr, index, useIDT);

            double max = double.NegativeInfinity;
            for (int i = 0; i < count; i++)
            {
                var dist = GetDistance(i);

                if (dist > max)
                    max = dist;

                distances.Add(dist);
            }

            ClearDistances();

            return max;
        }

        public double EstimateGeodesicDistances(Polyhedron3<K> mesh, int index, List<double> distances)
        {
            int count = Kernel.EstimateGeodesicDistances_PH(Ptr, mesh.Ptr, index, false);

            double max = double.NegativeInfinity;
            for (int i = 0; i < count; i++)
            {
                var dist = GetDistance(i);

                if (dist > max)
                    max = dist;

                distances.Add(dist);
            }

            ClearDistances();

            return max;
        }

    }

    public abstract class HeatMethod : PolyhedraAlgorithm
    {

        private HeatMethod()
        {

        }

        internal HeatMethod(CGALKernel kernel)
        {
            Kernel = kernel.HeatMethodKernel;
            Ptr = Kernel.Create();
        }

        internal HeatMethod(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.HeatMethodKernel;
            Ptr = ptr;
        }

        internal HeatMethodKernel Kernel { get; private set; }

        protected double GetDistance(int index)
        {
            return Kernel.GetDistance(Ptr, index);
        }
        protected void ClearDistances()
        {
            Kernel.ClearDistances(Ptr);
        }

        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }

    }

}
