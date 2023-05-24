using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;
using GALibrary.Structures.Real;

namespace GA.Operators
{
    public class RadcliffeCrossover : RealCrossover
    {
        public RadcliffeCrossover(IFunction function, double factor, double beta, bool isSum) : base(function, factor, beta, isSum) 
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
