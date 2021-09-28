using System;
using System.Collections.Generic;
using System.Text;

namespace CGALDotNet.Triangulations
{
    public struct  MeshOptimizeParams
    {
        public const double MAX_ANGLE_BOUNDS = 0.125;

        /// <summary>
        /// The termination of the algorithm is guaranteed when criteria are shape 
        /// criteria corresponding to a bound on smallest angles not less than 20.7 degrees 
        /// (this corresponds to a radius-edge ratio bound not less than 2–√). 
        /// Any size criteria that are satisfied by small enough triangle can be 
        /// added to the set of criteria without compromising the termination.
        /// Note that, in the presence of input angles smaller than 60 degrees, 
        /// some bad shaped triangles can appear in the final mesh in the neighboring of small angles
        /// </summary>
        public double AngleBounds;

        /// <summary>
        /// 
        /// </summary>
        public double LengthBounds;

        /// <summary>
        /// Time limit is used to set up, in seconds, 
        /// a CPU time limit after which the optimization process is stopped. 
        /// This time is measured using CGAL::Timer. 
        /// The default value is 0 and means that there is no time limit.
        /// </summary>
        public double TimeLimit;

        /// <summary>
        /// Max iteration number sets a limit on the number of performed iterations. 
        /// The default value of 0 means that there is no limit on the number 
        /// of performed iterations.
        /// </summary>
        public int MaxIterationNumber;

        /// <summary>
        /// Convergence is a stopping criterion based on convergence the 
        /// optimization process is stopped, 
        /// when at the last iteration, the displacement of any vertex is 
        /// less than a given fraction of the length of the shortest edge 
        /// incident to that vertex. The parameter convergence gives the threshold ratio.
        /// Precondition 0 ≤ convergence ≤ 1
        /// </summary>
        public double Convergence;

        /// <summary>
        /// Freeze_bound is designed to reduce running time of each optimization iteration. 
        /// Any vertex that has a displacement less than a given fraction of the length 
        /// of its shortest incident edge, is frozen (i.e. is not relocated). 
        /// The parameter freeze_bound gives the threshold ratio. The default value is 0.001. 
        /// If it is set to 0, freezing of vertices is disabled.
        /// Precondition 0 ≤ freeze_bound ≤ 1
        /// </summary>
        public double FreezeBound;

        /// <summary>
        /// If mark is set to true, the mesh domain is the union of the bounded connected
        /// components including at least one seed. If mark is false, the domain is the union 
        /// of the bounded components including no seed. Note that the unbounded component 
        /// of the plane is never optimized. The default value is false.
        /// </summary>
        public bool Mark;

        public MeshOptimizeParams Default
        {
            get
            {
                MeshOptimizeParams param = new MeshOptimizeParams();
                param.AngleBounds = 0.125;
                param.LengthBounds = 0.5;
                param.MaxIterationNumber = 0;
                param.TimeLimit = 0;
                param.Convergence = 0.001;
                param.FreezeBound = 0.001;
                param.Mark = false;
                return param;
            }
        }
    }
}
