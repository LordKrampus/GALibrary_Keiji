using System;
using GA.Structures.Individuals;
using GA.Structures.Interfaces;

namespace GA.Methods.Interfaces
{
    public interface ISelectionMethod<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {
        public bool IsMinimization { get; set; }
        public bool IsAllowClonage { get; set; }

        public IIndividual<T, E, F>[] RunSelection(int SelectionSize);
        public void SetupPopulation(IIndividual<T, E, F>[] population);
    }
}
