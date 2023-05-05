using System;

using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;

namespace GA.Operators
{
    public class BinaryCrossover<T> : Crossover<T, BinaryGene, bool> where T : BinaryChromosome
    {

        public BinaryCrossover(double factor) : base(factor) { }

    }
}
