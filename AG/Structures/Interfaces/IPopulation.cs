using System;
using GA.Structures.BasicInterfaces;
using GA.Structures.Individuals;

namespace GA.Structures.Interfaces
{
    public interface IPopulation<T, E, F> : BIPopulation, ICloneable where T : IChromosome<E, F> where E : IGene<F>
    {
        public IIndividual<T, E, F>[] Individuals { get; }
        public IIndividual<T, E, F> BestIndividual { get; }
        public IIndividual<T, E, F> CacheBestIndividual { get; }

        public new object Clone();
    }
}
