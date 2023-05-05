using System;
using GA.Structures.BasicInterfaces;
using GA.Structures.Individuals;
using GA.Structures.Interfaces;

namespace GA.Structures.Populations
{
    public class Population<T, E, F> : IPopulation<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {
        private IIndividual<T, E, F>[] _individuals;
        private int _size;

        private int _generation;
        private bool _biggerIsBest;

        private IIndividual<T, E, F>? _bestIndividual;

        public IIndividual<T, E, F>[] Individuals => _individuals;
        public BIIndividual[] ObjIndividuals => _individuals;
        public int Size => _size;

        public int Generation
        { get => _generation; set => _generation = value; }
        public bool BiggerIsBest => _biggerIsBest;

        public double Mean
        {
            get
            {
                double mean = 0;
                foreach (IIndividual<T, E, F> individual in Individuals)
                    mean += individual.Fitness;
                mean /= Size;
                return mean;
            }
        }

        public IIndividual<T, E, F> BestIndividual
        {
            get
            {
                this._bestIndividual = this._individuals[0];
                foreach (IIndividual<T, E, F> individual in Individuals)
                {
                    if (this._bestIndividual.Fitness < individual.Fitness && BiggerIsBest ||
                        individual.Fitness < this._bestIndividual.Fitness && !BiggerIsBest)
                        this._bestIndividual = individual;
                }
                return this._bestIndividual;
            }
        }
        public IIndividual<T, E, F>? CacheBestIndividual => this._bestIndividual;

        public Population(IIndividual<T, E, F>[] individuals, int size, bool biggerIsBest = true)
        {
            this._individuals = individuals;
            this._size = size;
            this._biggerIsBest = biggerIsBest;
            this._generation = 0;

            this._bestIndividual = null;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return
                $"({Generation}) .individual: {BestIndividual.ToString()} \t.Mmean: {Mean}";
        }

    } // end : class
} // end : namespace
