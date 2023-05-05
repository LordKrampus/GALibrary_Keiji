using GA.Structures.Interfaces;
using GA.Methods.Interfaces;
using GA.Utilities;
using System;
using GA.Structures.Individuals;

namespace GA.Methods
{
    public class Tournament<T, E, F>: ISelectionMethod<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {
        private Sorter _sorter;

        private bool _isMinimization;
        private bool _isAllowClonage;

        private List<IIndividual<T, E, F>> _population;
        private List<IIndividual<T, E, F>> _arena;

        public int _arenaSize;
        public int _populationSize;

        public bool IsMinimization { get => this._isMinimization; set => this._isMinimization = value; }
        public bool IsAllowClonage { get => this._isAllowClonage; set => this._isAllowClonage = value; }

        public Tournament(int arenaSize = 3, bool isMinimization = false, bool isAllowClonage = true) 
        {
            this._sorter = new Sorter();
            this._isMinimization = isMinimization;
            this._isAllowClonage = isAllowClonage;

            this._population = new List<IIndividual<T, E, F>>();
            this._arena = new List<IIndividual<T, E, F>>();

            this._arenaSize = arenaSize;
            this._populationSize = 0;
        }

        public void SetupPopulation(IIndividual<T, E, F>[] population)
        {
            this._population.Clear();
            this._populationSize = population.Length;

            foreach (Individual<T, E, F> individual in population)
                this._population.Add(individual);
        }

        public IIndividual<T, E, F>[] RunSelection(int SelectionSize)
        {
            IIndividual<T, E, F>[] individuals = new Individual<T, E, F>[SelectionSize];

            for (int i = 0; i < SelectionSize; i++)
                individuals[i] = this.Proced();

            return individuals;
        }

        public IIndividual<T, E, F> Proced()
        {
            IIndividual<T, E, F> individual;
            int index;
            for (int i = 0; i < this._arenaSize; i++)
            {
                index = this._sorter.SortBefore(this._populationSize - 1);
                individual = this._population[index];
                //this._population.Remove(individual);

                this._arena.Add(individual);
            }

            individual = this._arena[0];
            for (int i = 1; i < this._arenaSize; i++)
            {
                if (individual.Fitness < this._arena[i].Fitness && !this.IsMinimization ||
                    this._arena[i].Fitness < individual.Fitness && this.IsMinimization)
                {
                    individual = this._arena[i];
                }
            }

            if (!this.IsAllowClonage)
            {
                this._population.Remove(individual);
                this._populationSize--;
            }

            this._arena.Clear();
            return (IIndividual<T, E, F>)individual.Clone();
        }

    }
}
