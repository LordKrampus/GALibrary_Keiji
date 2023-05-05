using System;
using GA.Structures.Individuals;
using GA.Structures.Interfaces;

namespace GA.Procedures
{
    public class Elitismo<T, E, F> where T : IChromosome<E, F> where E: IGene<F>
    {
        public Elitismo() { }

        public IIndividual<T, E, F> Proced(IIndividual<T, E, F>[] population, bool isMinimization)
        {
            int populationSize = population.Length;
            IIndividual<T, E, F> bestIndividual;

            bestIndividual = population[0];
            for (int i = 1; i < populationSize; i++)
            {
                if (bestIndividual.Fitness < population[i].Fitness && !isMinimization ||
                    population[i].Fitness < bestIndividual.Fitness && isMinimization)
                    bestIndividual = population[i];
            }

            return (IIndividual<T, E, F>)bestIndividual.Clone();
        }

    }
}
