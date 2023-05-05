using GA.Algoritmos;
using GA.Structures.Individuals;
using GA.Structures.Interfaces;
using System;

namespace GA.Algoritmos
{
    public interface IGeneticAlgorithm<T, E, F> : BIGeneticAlgorithm where T: IChromosome<E, F> where E : IGene<F>
    {
        public IPopulation<T, E, F> Population { get; }
        public IIndividual<T, E, F>? BestIndividual { get; }
        public IIndividual<T, E, F>[] CacheBestIndividuals { get; }
    }
}
