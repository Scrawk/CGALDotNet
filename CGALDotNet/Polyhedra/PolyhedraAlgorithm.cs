using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Polyhedra
{
    public abstract class PolyhedraAlgorithm : CGALObject
    {
        /// <summary>
        /// Should the input polygon be checked.
        /// Can disable for better performance if 
        /// it is know all input if valid.
        /// </summary>
        public bool CheckInput = true;

        /// <summary>
        /// Check if the polyhedron is valid.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected void CheckIsValidException(Polyhedron3 polyhedron)
        {
            if (polyhedron == null)
                throw new NullReferenceException("The polyhedron mesh is null.");

            if (!CheckInput) return;

            if (!polyhedron.FindIfValid())
                throw new InvalidOperationException("polyhedron is not valid.");
        }

        /// <summary>
        /// Check if the polyhedron is valid.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected bool CheckIsValid(Polyhedron3 polyhedron)
        {
            if (polyhedron == null)
                throw new NullReferenceException("The polyhedron mesh is null.");

            if (!CheckInput) return true;
            return polyhedron.IsValid;
        }

        /// <summary>
        /// Check if the polyhedron is a valid triangle mesh.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected void CheckIsValidTriangleException(Polyhedron3 polyhedron)
        {
            if (polyhedron == null)
                throw new NullReferenceException("The polyhedron mesh is null.");

            if (!CheckInput) return;

            if (!polyhedron.IsValid)
                throw new InvalidOperationException("polyhedron is not valid.");

           if (!polyhedron.IsTriangle)
                throw new InvalidOperationException("polyhedron must be a pure triangle mesh.");
        }

        /// <summary>
        /// Check if the polyhedron is a valid triangle mesh.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected bool CheckIsValidTriangle(Polyhedron3 polyhedron)
        {
            if (polyhedron == null)
                throw new NullReferenceException("The polyhedron mesh is null.");

            if (!CheckInput) return true;
            return polyhedron.IsValidTriangleMesh;
        }

        /// <summary>
        /// Check if the polyhedron is a valid triangle mesh.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected void CheckIsValidClosedTriangleException(Polyhedron3 polyhedron)
        {
            if (polyhedron == null)
                throw new NullReferenceException("The polyhedron mesh is null.");

            if (!CheckInput) return;

            if (!polyhedron.IsValid)
                throw new InvalidOperationException("polyhedron is not valid.");

            if (!polyhedron.IsTriangle)
                throw new InvalidOperationException("polyhedron must be a pure triangle mesh.");

            if (!polyhedron.IsClosed)
                throw new InvalidOperationException("polyhedron must be a closed mesh.");
        }

        /// <summary>
        /// Check if the polyhedron is a valid triangle mesh.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected bool CheckIsValidClosedTriangle(Polyhedron3 polyhedron)
        {
            if (polyhedron == null)
                throw new NullReferenceException("The polyhedron mesh is null.");

            if (!CheckInput) return true;
            return polyhedron.IsValidClosedTriangleMesh;
        }

    }
}
