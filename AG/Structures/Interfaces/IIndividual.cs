using GA.Structures.BasicInterfaces;
using GA.Structures.Generics;
using System;

namespace GA.Structures.Interfaces
{
    public interface IIndividual<T> : BIIndividual, ICloneable where T : BIChromosome
    {
        public T Chromosome { get; }
    }
}
