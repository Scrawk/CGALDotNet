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
        protected void CheckIsValid(Polyhedron3 polyhedron)
        {
            if (!CheckInput) return;

            if (!polyhedron.FindIfValid())
                throw new Exception("polyhedron is not valid.");
        }

        /// <summary>
        /// Check if the polyhedron is valid.
        /// </summary>
        /// <param name="polygon">The polygon to check.</param>
        protected void CheckIsValidAndTriangle(Polyhedron3 polyhedron)
        {
            if (!CheckInput) return;

            if (!polyhedron.FindIfValid())
                throw new Exception("polyhedron is not valid.");

           // if (!polyhedron.IsTriangle)
            //    throw new Exception("polyhedron must be a pure triangle mesh.");
        }
    }
}
