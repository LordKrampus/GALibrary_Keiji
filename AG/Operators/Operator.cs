using System;
using GA.Structures.Interfaces;
using GA.Operators.Interfaces;
using GA.Utilities;

namespace GA.Operators
{
    public abstract class Operator<T, E, F> : IOperator<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {
        protected Sorter _sorter;
        protected double _factor;

        public double Factor => this._factor;

        public Operator(double factor) 
        {
            this._factor = factor;
            this._sorter = new Sorter();
        }

        protected bool SortApply()
        {
            return this._factor >= 0.01f * this._sorter.SortBetween(1, 100);
        }

        protected virtual int GeneratePoint(T chromosome)
        {
            return this._sorter.SortBefore(chromosome.Genes.Length - 1);
        }

        protected virtual int GeneratePoint(E[] genes)
        {
            return this._sorter.SortBefore(genes.Length - 1);
        }

        public abstract T[] Apply(T[] parameters);
    }
}
