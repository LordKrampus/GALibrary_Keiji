using System;
using System.Text;
using GA.Structures.Binaries;
using GA.Structures.Interfaces;

/*
namespace GA.Structures.Individuals
{
    public class CombineIndividual<T> : Individual<T> where T : IChromosome
    {
        public override int Size => ((ICombineChromosome)base._chromosome).Count;

        public CombineIndividual(T chromosome) : base(chromosome) { }

        public override object Clone()
        {
            T chromosome =  (T)_chromosome.Generate(0);

            Individual<T> newIndividual = new CombineIndividual<T>(chromosome);
            newIndividual.Fitness = Fitness;

            return newIndividual;
        }
    }
}
*/