using GA.Structures.BasicInterfaces;
using GA.Structures.Interfaces;
using System;

namespace GA.Algoritmos
{
    public interface BIGeneticAlgorithm
    {
        public BIPopulation ObjPopulation { get; set; }
        public BIIndividual? ObjBestIndividual { get; }
        public BIIndividual[] ObjCacheBestIndividuals { get; }

        public int PopulationSize { get; set; }
        public int IndividualSize { get; set; }
        public int LimitGenerations { get; set; }

        public double CrossoverRate { get; set; }
        public double MutationRate { get; set; }

        public int Generation { get; }
        public bool HasFinished { get; }

        public double Mean { get; }

        public string[] CacheGenerations { get; }
        public double[] CacheMeans { get; }

        public void Run();
        public void RunStep();
    }
}
