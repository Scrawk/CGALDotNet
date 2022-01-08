using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polygons;

namespace CGALDotNet.Triangulations
{

    /// <summary>
    /// Base triangulation class for Triangulation, DelaunayTriangulation 
    /// and ConstrainedTriangulation.
    /// </summary>
    public abstract class BaseTriangulation3 : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        private BaseTriangulation3()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="points"></param>
        internal BaseTriangulation3(BaseTriangulationKernel3 kernel, Point3d[] points)
        {
            Kernel = kernel;
            Ptr = Kernel.Create();
            Insert(points, points.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal BaseTriangulation3(BaseTriangulationKernel3 kernel)
        {
            Kernel = kernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal BaseTriangulation3(BaseTriangulationKernel3 kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel;
        }

        /// <summary>
        /// The triangulations kernel.
        /// </summary>
        protected private BaseTriangulationKernel3 Kernel { get; private set; }

        /// <summary>
        /// A number that will change if the unmanaged 
        /// triangulation model changes.
        /// </summary>
        public int BuildStamp => Kernel.BuildStamp(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int VertexCount => Kernel.VertexCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int CellCount => Kernel.CellCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int FiniteCellCount => Kernel.FiniteCellCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int EdgeCount => Kernel.EdgeCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int FiniteEdgeCount => Kernel.FiniteEdgeCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int FacetCount => Kernel.FacetCount(Ptr);

        /// <summary>
        /// 
        /// </summary>
        public int FiniteFacetCount =>  Kernel.FiniteFacetCount(Ptr);

        /// <summary>
        /// Clear the triangulation.
        /// </summary>
        public void Clear()
        {
            Kernel.Clear(Ptr);
        }

        public bool IsValid()
        {
            return Kernel.IsValid(Ptr);
        }

        /// <summary>
        /// Force the face and vertex indices to be set.
        /// </summary>
        public void ForceSetIndices()
        {
            Kernel.SetIndices(Ptr);
        }

        public void Insert(Point3d point)
        {
            Kernel.InsertPoint(Ptr, point);
        }

        public void Insert(Point3d[] points, int count)
        {
            ErrorUtil.CheckArray(points, count);
            Kernel.InsertPoints(Ptr, points, count);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Print()
        {
            var builder = new StringBuilder();
            Print(builder);
            Console.WriteLine(builder.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Print(StringBuilder builder)
        {
            builder.AppendLine(ToString());
        }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}
