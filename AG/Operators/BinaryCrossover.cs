using System;

using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;

namespace GA.Operators
{
    public class BinaryCrossover : Crossover<BinaryChromosome, BinaryGene, bool> 
    {

        public BinaryCrossover(double factor) : base(factor) { }

    }
}
