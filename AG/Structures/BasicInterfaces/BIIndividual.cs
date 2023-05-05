using GA.Structures.Interfaces;
using System;


namespace GA.Structures.BasicInterfaces
{
    public interface BIIndividual
    {
        public BIChromosome ObjChromosome { get; }

        public double Value { get; }
        public int Size { get; }
        public double Fitness { get; set; }
    }
}
