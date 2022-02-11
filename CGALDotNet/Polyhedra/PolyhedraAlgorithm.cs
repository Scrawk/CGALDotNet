using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polyhedra
{
    public abstract class PolyhedraAlgorithm : CGALObject
    {
        /// <summary>
        /// 
        /// </summary>
        internal PolyhedraAlgorithm()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ptr"></param>
        internal PolyhedraAlgorithm(IntPtr ptr) : base(ptr)
        {

        }

        /// <summary>
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

        /// <summary>
        /// Check if the mesh is valid.
        /// </summary>
        /// <param name="mesh">The mesh to check.</param>
        protected void CheckIsValidException(IMesh mesh)
        {
            if (mesh == null)
                throw new NullReferenceException("The mesh is null.");

            if (!CheckInput) return;

            if (!mesh.IsValid)
                throw new InvalidOperationException("The mesh is not valid.");
        }

        /// <summary>
        /// Check if the mesh is valid.
        /// </summary>
        /// <param name="mesh">The mesh to check.</param>
        protected bool CheckIsValid(IMesh mesh)
        {
            if (mesh == null)
                throw new NullReferenceException("The mesh is null.");

            if (!CheckInput) return true;
            return mesh.IsValid;
        }

        /// <summary>
        /// Check if the mesh is a valid triangle mesh.
        /// </summary>
        /// <param name="mesh">The mesh to check.</param>
        protected void CheckIsValidTriangleException(IMesh mesh)
        {
            if (mesh == null)
                throw new NullReferenceException("The mesh is null.");

            if (!CheckInput) return;

            if (!mesh.IsValid)
                throw new InvalidOperationException("The mesh is not valid.");

           if (!mesh.IsTriangle)
                throw new InvalidOperationException("The mesh must be a pure triangle mesh.");
        }

        /// <summary>
        /// Check if the mesh is a valid triangle mesh.
        /// </summary>
        /// <param name="mesh">The mesh to check.</param>
        protected bool CheckIsValidTriangle(IMesh mesh)
        {
            if (mesh == null)
                throw new NullReferenceException("The mesh is null.");

            if (!CheckInput) return true;
            return mesh.IsValidTriangleMesh;
        }

        /// <summary>
        /// Check if the mesh is a valid closed mesh.
        /// </summary>
        /// <param name="mesh">The mesh to check.</param>
        protected void CheckIsValidClosedException(IMesh mesh)
        {
            if (mesh == null)
                throw new NullReferenceException("The mesh is null.");

            if (!CheckInput) return;

            if (!mesh.IsValid)
                throw new InvalidOperationException("The mesh is not valid.");

            if (!mesh.IsClosed)
                throw new InvalidOperationException("The mesh must be a closed mesh.");
        }

        /// <summary>
        /// Check if the mesh is a valid closed mesh.
        /// </summary>
        /// <param name="mesh">The polygon to check.</param>
        protected bool CheckIsValidClosed(IMesh mesh)
        {
            if (mesh == null)
                throw new NullReferenceException("The mesh is null.");

            if (!CheckInput) return true;
            return mesh.IsValidClosedMesh;
        }

        /// <summary>
        /// Check if the mesh is a valid triangle mesh.
        /// </summary>
        /// <param name="mesh">The mesh to check.</param>
        protected void CheckIsValidClosedTriangleException(IMesh mesh)
        {
            if (mesh == null)
                throw new NullReferenceException("The mesh is null.");

            if (!CheckInput) return;

            if (!mesh.IsValid)
                throw new InvalidOperationException("The mesh is not valid.");

            if (!mesh.IsTriangle)
                throw new InvalidOperationException("The mesh must be a pure triangle mesh.");

            if (!mesh.IsClosed)
                throw new InvalidOperationException("The mesh must be a closed mesh.");
        }

        /// <summary>
        /// Check if the mesh is a valid triangle mesh.
        /// </summary>
        /// <param name="mesh">The mesh to check.</param>
        protected bool CheckIsValidClosedTriangle(IMesh mesh)
        {
            if (mesh == null)
                throw new NullReferenceException("The mesh mesh is null.");

            if (!CheckInput) return true;
            return mesh.IsValidClosedTriangleMesh;
        }

    }
}
