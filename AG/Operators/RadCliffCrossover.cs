using System;

using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;
using GALibrary.Structures.Real;

namespace GA.Operators
{
    public class RadcliffeCrossover : RealCrossover
    {
        public RadcliffeCrossover(double beta, bool isSum, double factor) : base(beta, isSum, factor) 
        { }

        public override RealGene[][] Apply(RealGene[] aE, RealGene[] bE)
        {
            int length = aE.Length;
            RealGene[] fA, fB;

            base.GenerateChild(aE, bE, base.Beta, (1 - base.Beta), out fA, length);
            base.GenerateChild(aE, bE, (1 - base.Beta), base.Beta, out fB, length);

            return new RealGene[][] { fA, fB };
        }
    }
}
