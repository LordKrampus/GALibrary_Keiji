using GA.Structures.BasicInterfaces;
using GA.Structures.Generics;
using System;

namespace GA.Structures.Interfaces
{
    public interface IIndividual<T, E, F> : BIIndividual, ICloneable where T : IChromosome<E, F> where E : IGene<F>
    {
        public T Chromosome { get; }
    }
}
