using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CGALDotNet.Meshing
{
    public class SurfaceMeshGenerationKernel3_EEK : SurfaceMeshGenerationKernel3
    {
        internal override string Name => "EEK";

        public override void Generate()
        {
            SurfaceMeshGeneration3_EEK_Generate();
        }

        [DllImport(DLL_NAME, CallingConvention = CDECL)]
        private static extern void SurfaceMeshGeneration3_EEK_Generate();
    }
}
