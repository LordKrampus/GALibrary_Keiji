using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;
using System;

namespace GA.Operators
{
    public class BinaryMutation : Mutation<BinaryChromosome, BinaryGene, bool>
    {
        public BinaryMutation(double factor) : base(factor) { }

        protected override bool GenerateMutationValue(BinaryGene[] genes, int mutationPoint)
        {
            return !genes[mutationPoint].Value;
        }
    }
}
