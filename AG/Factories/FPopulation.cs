using System;
using GA.Structures.Binaries;
using GA.Structures.Interfaces;
using GA.Structures.Populations;
using GA.Factories;
using GA.Utilities;
using GA.Structures.Individuals;
using GA.Structures.BasicInterfaces;

namespace GA.Algoritmos.Factories
{
    public class FPopulation
    {
        private static FPopulation _instance;
        private Sorter _sorter;

        private FPopulation() 
        {
            this._sorter = new Sorter();
        }

        public static FPopulation Instance => _instance ??= new FPopulation();

        public static IPopulation<T, E, F> Reflection_CreatePopulation<T, E, F>(Type type, BIIndividual[] individuals, int populationSize, bool biggerIsBetter) 
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new Population<T, E, F>((IIndividual<T, E, F>[])individuals, populationSize, biggerIsBetter);
        }

        public BIPopulation? GeneratePopulation(Type tChromosome, Type tGene, Type tGeneValue, Type tPopulation, BIIndividual[] individuals, int populationSize, bool biggerIsBetter)
        {
            return (BIPopulation?)typeof(FPopulation).GetMethod("Reflection_CreatePopulation")?.
                MakeGenericMethod(new Type[] { tChromosome, tGene, tGeneValue }).
                Invoke(null, new object[] { tPopulation, individuals, populationSize, biggerIsBetter });
        }
    }
}
