using System;
using GA.Structures.Binaries;

namespace GA.Structures.Interfaces
{
    public interface BIChromosome
    {
        public BIGene[] ObjGenes { get; set; }

        public double Value { get; }
        public double MaxValue { get; }

        public BIChromosome Generate(int length);
    }
}
