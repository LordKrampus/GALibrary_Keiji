using System;
using GA.Structures.Interfaces;
using GA.Operators.Interfaces;
using GA.Utilities;
using GA.Functions.Interfaces;

namespace GA.Operators
{
    public abstract class Operator<T, E, F> : IOperator<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {
        protected Sorter sorter;

        private IFunction _function;
        private double _factor;

        public IFunction Function => this._function;
        public double Factor => this._factor;

        public Operator(IFunction function, double factor) 
        {
            sorter = new Sorter();

            this._function = function;
            this._factor = factor;
        }

        protected bool SortApply()
        {
            return this._factor >= 0.01f * sorter.SortBetween(1, 100);
        }

        protected virtual int GeneratePoint(T chromosome)
        {
            return sorter.SortBefore(chromosome.Genes.Length - 1);
        }

        protected virtual int GeneratePoint(E[] genes)
        {
            return sorter.SortBefore(genes.Length - 1);
        }

        public abstract T[] Apply(T[] parameters);
    }
}
