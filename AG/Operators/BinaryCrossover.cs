using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;

namespace GA.Operators
{
    public class BinaryCrossover : Crossover<BinaryChromosome, BinaryGene, bool> 
    {

        public BinaryCrossover(IFunction function, double factor) : base(function, factor) { }

    }
}
