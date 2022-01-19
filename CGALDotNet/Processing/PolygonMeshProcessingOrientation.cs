using System;
using System.Collections.Generic;
using System.Text;

using CGALDotNet.Polyhedra;

namespace CGALDotNet.Processing
{

    public enum ORIENTATE
    {
        ORIENT,
        ORIENTATE_TO_BOUND_A_VOLUME,
        REVERSE_FACE_ORIENTATIONS
    }

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
        public bool DoesBoundAVolume(Polyhedron3<K> poly)
        {
            CheckIsValidClosedTriangleException(poly);
            return Kernel.DoesBoundAVolume(poly.Ptr);
        }

        /// <summary>
        /// Tests whether a closed triangle mesh has a positive orientation.
        /// A closed triangle mesh is considered to have a positive orientation
        /// if the normal vectors to all its faces point outside the domain bounded 
        /// by the triangle mesh.The normal vector to each face is chosen pointing
        /// on the side of the face where its sequence of vertices is seen counterclockwise.
        /// </summary>
        /// <param name="poly">A closed triangle mesh.</param>
        public bool IsOutwardOriented(Polyhedron3<K> poly)
        {
            CheckIsValidClosedTriangleException(poly);
            return Kernel.IsOutwardOriented(poly.Ptr);
        }

        /// <summary>
        /// Orient the faces in the mesh.
        /// </summary>
        /// <param name="orientate">The orientation method.</param>
        /// <param name="poly">A valid closed triangle mesh.</param>
        public void Orient(ORIENTATE orientate, Polyhedron3<K> poly)
        {
            switch (orientate)
            {
                case ORIENTATE.ORIENT:
                    Orient(poly);
                    break;
                case ORIENTATE.ORIENTATE_TO_BOUND_A_VOLUME:
                    OrientToBoundAVolume(poly);
                    break;
                case ORIENTATE.REVERSE_FACE_ORIENTATIONS:
                    ReverseFaceOrientations(poly);
                    break;
            }
        }

        /// <summary>
        /// Makes each connected component of a closed triangulated surface mesh inward or outward oriented.
        /// </summary>
        /// <param name="poly">A closed triangle mesh.</param>
        public void Orient(Polyhedron3<K> poly)
        {
            CheckIsValidClosedTriangleException(poly);
            Kernel.Orient(poly.Ptr);
        }

        /// <summary>
        /// Orients the connected components of tm to make it bound a volume.
        /// </summary>
        /// <param name="poly">A closed triangle mesh.</param>
        public void OrientToBoundAVolume(Polyhedron3<K> poly)
        {
            CheckIsValidClosedTriangleException(poly);
            Kernel.OrientToBoundAVolume(poly.Ptr);
        }

        /// <summary>
        /// Reverses for each face the order of the vertices along the face boundary.
        /// </summary>
        /// <param name="poly">A valid mesh.</param>
        public void ReverseFaceOrientations(Polyhedron3<K> poly)
        {
            CheckIsValidException(poly);
            Kernel.ReverseFaceOrientations(poly.Ptr);
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

