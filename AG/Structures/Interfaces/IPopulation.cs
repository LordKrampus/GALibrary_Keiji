using System;
using GA.Structures.BasicInterfaces;
using GA.Structures.Individuals;

namespace GA.Structures.Interfaces
{
    public interface IPopulation<T> : BIPopulation, ICloneable where T : BIChromosome
    {
        public IIndividual<T>[] Individuals { get; }
        public IIndividual<T> BestIndividual { get; }
        public IIndividual<T> CacheBestIndividual { get; }

        public new object Clone();
    }
}
