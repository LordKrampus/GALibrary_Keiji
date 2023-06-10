using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;
using GALibrary.Structures.Real;

namespace GA.Operators
{
    public class RealMutation : Mutation<RealChromosome, RealGene, double> 
    {
        public RealMutation(IFunction function, double factor) : base(function, factor) 
        { }

        protected override double GenerateMutationValue(RealGene[] genes, int mutationPoint)
        {
            return sorter.SortContinue(base.Function.LInfs[mutationPoint], base.Function.LSups[mutationPoint]);
        }
    }
}
