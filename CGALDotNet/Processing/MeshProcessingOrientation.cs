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
    public sealed class MeshProcessingOrientation<K> : MeshProcessingOrientation where K : CGALKernel, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly MeshProcessingOrientation<K> Instance = new MeshProcessingOrientation<K>();

        /// <summary>
        /// 
        /// </summary>
        public MeshProcessingOrientation() : base(new K())
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal MeshProcessingOrientation(IntPtr ptr) : base(new K(), ptr)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[MeshProcessingOrientation<{0}>: ]", Kernel.Name);
        }

        /// <summary>
        /// Indicates if mesh bounds a volume.
        /// </summary>
        /// <param name="mesh">A closed triangle mesh.</param>
        public bool DoesBoundAVolume(Polyhedron3<K> mesh)
        {
            CheckIsValidClosedTriangleException(mesh);
            return Kernel.DoesBoundAVolume_PH(mesh.Ptr);
        }

        /// <summary>
        /// Indicates if mesh bounds a volume.
        /// </summary>
        /// <param name="mesh">A closed triangle mesh.</param>
        public bool DoesBoundAVolume(SurfaceMesh3<K> mesh)
        {
            CheckIsValidClosedTriangleException(mesh);
            return Kernel.DoesBoundAVolume_SM(mesh.Ptr);
        }

        /// <summary>
        /// Tests whether a closed triangle mesh has a positive orientation.
        /// A closed triangle mesh is considered to have a positive orientation
        /// if the normal vectors to all its faces point outside the domain bounded 
        /// by the triangle mesh.The normal vector to each face is chosen pointing
        /// on the side of the face where its sequence of vertices is seen counterclockwise.
        /// </summary>
        /// <param name="mesh">A closed triangle mesh.</param>
        public bool IsOutwardOriented(Polyhedron3<K> mesh)
        {
            CheckIsValidClosedTriangleException(mesh);
            return Kernel.IsOutwardOriented_PH(mesh.Ptr);
        }

        /// <summary>
        /// Tests whether a closed triangle mesh has a positive orientation.
        /// A closed triangle mesh is considered to have a positive orientation
        /// if the normal vectors to all its faces point outside the domain bounded 
        /// by the triangle mesh.The normal vector to each face is chosen pointing
        /// on the side of the face where its sequence of vertices is seen counterclockwise.
        /// </summary>
        /// <param name="mesh">A closed triangle mesh.</param>
        public bool IsOutwardOriented(SurfaceMesh3<K> mesh)
        {
            CheckIsValidClosedTriangleException(mesh);
            return Kernel.IsOutwardOriented_SM(mesh.Ptr);
        }

        /// <summary>
        /// Orient the faces in the mesh.
        /// </summary>
        /// <param name="orientate">The orientation method.</param>
        /// <param name="mesh">A valid closed triangle mesh.</param>
        public void Orient(ORIENTATE orientate, Polyhedron3<K> mesh)
        {
            switch (orientate)
            {
                case ORIENTATE.ORIENT:
                    Orient(mesh);
                    break;
                case ORIENTATE.ORIENTATE_TO_BOUND_A_VOLUME:
                    OrientToBoundAVolume(mesh);
                    break;
                case ORIENTATE.REVERSE_FACE_ORIENTATIONS:
                    ReverseFaceOrientations(mesh);
                    break;
            }
        }

        /// <summary>
        /// Orient the faces in the mesh.
        /// </summary>
        /// <param name="orientate">The orientation method.</param>
        /// <param name="mesh">A valid closed triangle mesh.</param>
        public void Orient(ORIENTATE orientate, SurfaceMesh3<K> mesh)
        {
            switch (orientate)
            {
                case ORIENTATE.ORIENT:
                    Orient(mesh);
                    break;
                case ORIENTATE.ORIENTATE_TO_BOUND_A_VOLUME:
                    OrientToBoundAVolume(mesh);
                    break;
                case ORIENTATE.REVERSE_FACE_ORIENTATIONS:
                    ReverseFaceOrientations(mesh);
                    break;
            }
        }

        /// <summary>
        /// Makes each connected component of a closed triangulated surface mesh inward or outward oriented.
        /// </summary>
        /// <param name="mesh">A closed triangle mesh.</param>
        public void Orient(Polyhedron3<K> mesh)
        {
            CheckIsValidClosedTriangleException(mesh);
            Kernel.Orient_PH(mesh.Ptr);
        }

        /// <summary>
        /// Makes each connected component of a closed triangulated surface mesh inward or outward oriented.
        /// </summary>
        /// <param name="mesh">A closed triangle mesh.</param>
        public void Orient(SurfaceMesh3<K> mesh)
        {
            CheckIsValidClosedTriangleException(mesh);
            Kernel.Orient_SM(mesh.Ptr);
        }

        /// <summary>
        /// Orients the connected components of tm to make it bound a volume.
        /// </summary>
        /// <param name="mesh">A closed triangle mesh.</param>
        public void OrientToBoundAVolume(Polyhedron3<K> mesh)
        {
            CheckIsValidClosedTriangleException(mesh);
            Kernel.OrientToBoundAVolume_PH(mesh.Ptr);
        }

        /// <summary>
        /// Orients the connected components of tm to make it bound a volume.
        /// </summary>
        /// <param name="mesh">A closed triangle mesh.</param>
        public void OrientToBoundAVolume(SurfaceMesh3<K> mesh)
        {
            CheckIsValidClosedTriangleException(mesh);
            Kernel.OrientToBoundAVolume_SM(mesh.Ptr);
        }

        /// <summary>
        /// Reverses for each face the order of the vertices along the face boundary.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        public void ReverseFaceOrientations(Polyhedron3<K> mesh)
        {
            CheckIsValidException(mesh);
            Kernel.ReverseFaceOrientations_PH(mesh.Ptr);
        }

        /// <summary>
        /// Reverses for each face the order of the vertices along the face boundary.
        /// </summary>
        /// <param name="mesh">A valid mesh.</param>
        public void ReverseFaceOrientations(SurfaceMesh3<K> mesh)
        {
            CheckIsValidException(mesh);
            Kernel.ReverseFaceOrientations_SM(mesh.Ptr);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MeshProcessingOrientation : PolyhedraAlgorithm
    {
        /// <summary>
        /// 
        /// </summary>
        private MeshProcessingOrientation()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        internal MeshProcessingOrientation(CGALKernel kernel)
        {
            Kernel = kernel.MeshProcessingOrientationKernel;
            Ptr = Kernel.Create();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kernel"></param>
        /// <param name="ptr"></param>
        internal MeshProcessingOrientation(CGALKernel kernel, IntPtr ptr) : base(ptr)
        {
            Kernel = kernel.MeshProcessingOrientationKernel;
            Ptr = ptr;
        }

        /// <summary>
        /// 
        /// </summary>
        internal MeshProcessingOrientationKernel Kernel { get; private set; }

        /// <summary>
        /// Release any unmanaged resources.
        /// </summary>
        protected override void ReleasePtr()
        {
            Kernel.Release(Ptr);
        }
    }
}

