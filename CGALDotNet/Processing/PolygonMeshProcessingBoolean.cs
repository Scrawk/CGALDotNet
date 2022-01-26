using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Geometry;
using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    public enum POLYHEDRA_BOOLEAN
    {
        UNION,
        INTERSECT,
        DIFFERENCE
    };

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonMeshProcessingBoolean<K> : PolygonMeshProcessingBoolean where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingBoolean<K> Instance = new PolygonMeshProcessingBoolean<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingBoolean() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingBoolean(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingBoolean<{0}>: ]", Kernel.KernelName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Op(POLYHEDRA_BOOLEAN op, Polyhedron3<K> mesh1, Polyhedron3<K> mesh2, out Polyhedron3<K> result)
        {
            switch (op)
            {
                case POLYHEDRA_BOOLEAN.UNION:
                    return Union(mesh1, mesh2, out result);
                case POLYHEDRA_BOOLEAN.INTERSECT:
                    return Intersection(mesh1, mesh2, out result);
                case POLYHEDRA_BOOLEAN.DIFFERENCE:
                    return Difference(mesh1, mesh2, out result);
            }

            result = null;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Op(POLYHEDRA_BOOLEAN op, SurfaceMesh3<K> mesh1, SurfaceMesh3<K> mesh2, out SurfaceMesh3<K> result)
        {
            switch (op)
            {
                case POLYHEDRA_BOOLEAN.UNION:
                    return Union(mesh1, mesh2, out result);
                case POLYHEDRA_BOOLEAN.INTERSECT:
                    return Intersection(mesh1, mesh2, out result);
                case POLYHEDRA_BOOLEAN.DIFFERENCE:
                    return Difference(mesh1, mesh2, out result);
            }

            result = null;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Union(Polyhedron3<K> mesh1, Polyhedron3<K> mesh2, out Polyhedron3<K> result)
        {
            CheckIsValidException(mesh1);
            CheckIsValidException(mesh2);

            if (Kernel.Union_PH(mesh1.Ptr, mesh2.Ptr, out IntPtr resultPtr))
            {
                result = new Polyhedron3<K>(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Union(SurfaceMesh3<K> mesh1, SurfaceMesh3<K> mesh2, out SurfaceMesh3<K> result)
        {
            CheckIsValidException(mesh1);
            CheckIsValidException(mesh2);

            if (Kernel.Union_SM(mesh1.Ptr, mesh2.Ptr, out IntPtr resultPtr))
            {
                result = new SurfaceMesh3<K>(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Difference(Polyhedron3<K> mesh1, Polyhedron3<K> mesh2, out Polyhedron3<K> result)
        {
            CheckIsValidException(mesh1);
            CheckIsValidException(mesh2);

            if (Kernel.Difference_PH(mesh1.Ptr, mesh2.Ptr, out IntPtr resultPtr))
            {
                result = new Polyhedron3<K>(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Difference(SurfaceMesh3<K> mesh1, SurfaceMesh3<K> mesh2, out SurfaceMesh3<K> result)
        {
            CheckIsValidException(mesh1);
            CheckIsValidException(mesh2);

            if (Kernel.Difference_SM(mesh1.Ptr, mesh2.Ptr, out IntPtr resultPtr))
            {
                result = new SurfaceMesh3<K>(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Intersection(Polyhedron3<K> mesh1, Polyhedron3<K> mesh2, out Polyhedron3<K> result)
        {
            CheckIsValidException(mesh1);
            CheckIsValidException(mesh2);

            if (Kernel.Intersection_PH(mesh1.Ptr, mesh2.Ptr, out IntPtr resultPtr))
            {
                result = new Polyhedron3<K>(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mesh1"></param>
        /// <param name="mesh2"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool Intersection(SurfaceMesh3<K> mesh1, SurfaceMesh3<K> mesh2, out SurfaceMesh3<K> result)
        {
            CheckIsValidException(mesh1);
            CheckIsValidException(mesh2);

            if (Kernel.Intersection_PH(mesh1.Ptr, mesh2.Ptr, out IntPtr resultPtr))
            {
                result = new SurfaceMesh3<K>(resultPtr);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PolygonMeshProcessingBoolean : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingBoolean()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingBoolean(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMeshProcessingBooleanKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingBoolean(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonMeshProcessingBooleanKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingBooleanKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

