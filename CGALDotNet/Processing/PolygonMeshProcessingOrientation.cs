using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class PolygonMeshProcessingOrientation<K> : PolygonMeshProcessingOrientation where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly PolygonMeshProcessingOrientation<K> Instance = new PolygonMeshProcessingOrientation<K>();

        /// <summary>
        /// 
        /// </summary>
        public PolygonMeshProcessingOrientation() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingOrientation(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[PolygonMeshProcessingOrientation<{0}>: ]", Kernel.KernelName);
        }

        /// <summary>
        /// Indicates if mesh bounds a volume.
        /// </summary>
        /// <param name="poly">A closed triangle mesh.</param>
        /// <returns>True/false result or undetermined if not a valid mesh.</returns>
        public BOOL_OR_UNDETERMINED DoesBoundAVolume(Polyhedron3<K> poly)
        {
            if (!CheckIsValidClosedTriangle(poly))
                return BOOL_OR_UNDETERMINED.UNDETERMINED;

            return Kernel.DoesBoundAVolume(poly.Ptr).ToBoolOrUndetermined();
        }

        /// <summary>
        /// Tests whether a closed triangle mesh has a positive orientation.
        /// A closed triangle mesh is considered to have a positive orientation
        /// if the normal vectors to all its faces point outside the domain bounded 
        /// by the triangle mesh.The normal vector to each face is chosen pointing
        /// on the side of the face where its sequence of vertices is seen counterclockwise.
        /// </summary>
        /// <param name="poly">A closed triangle mesh.</param>
        /// <returns>True/false result or undetermined if not a valid mesh.</returns>
        public BOOL_OR_UNDETERMINED IsOutwardOriented(Polyhedron3<K> poly)
        {
            if (!CheckIsValidClosedTriangle(poly))
                return BOOL_OR_UNDETERMINED.UNDETERMINED;

            return Kernel.IsOutwardOriented(poly.Ptr).ToBoolOrUndetermined();
        }

        /// <summary>
        /// Makes each connected component of a closed triangulated surface mesh inward or outward oriented.
        /// </summary>
        /// <param name="poly">A closed triangle mesh.</param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool Orient(Polyhedron3<K> poly)
        {
            if (!CheckIsValidClosedTriangle(poly))
                return false;

            Kernel.Orient(poly.Ptr);
            return true;
        }

        /// <summary>
        /// Orients the connected components of tm to make it bound a volume.
        /// </summary>
        /// <param name="poly">A closed triangle mesh.</param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool OrientToBoundAVolume(Polyhedron3<K> poly)
        {
            if (!CheckIsValidClosedTriangle(poly))
                return false;

            Kernel.OrientToBoundAVolume(poly.Ptr);
            return true;
        }

        /// <summary>
        /// Reverses for each face the order of the vertices along the face boundary.
        /// </summary>
        /// <param name="poly">A valid mesh.</param>
        /// <returns>True if function run or false if not a valid mesh.</returns>
        public bool ReverseFaceOrientations(Polyhedron3<K> poly)
        {
            if (!CheckIsValid(poly))
                return false;

            Kernel.ReverseFaceOrientations(poly.Ptr);
            return true;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PolygonMeshProcessingOrientation : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private PolygonMeshProcessingOrientation()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal PolygonMeshProcessingOrientation(CGALKernel kernel)
        {
            Kernel = kernel.PolygonMeshProcessingOrientationKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal PolygonMeshProcessingOrientation(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.PolygonMeshProcessingOrientationKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal PolygonMeshProcessingOrientationKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

