using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Interfaces;
using GA.Structures.Utilities;

namespace GA.Operators
{
    public abstract class Mutation<T, E, F> : Operator<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {

        public Mutation(IFunction function, double factor) : base(function, factor) 
        { }

        public override T[] Apply(T[] parameters)
        {
            T[] chromosomes = new T[parameters.Length - 1];
            for (int i = 0; i < parameters.Length - 1; i++)
            {
                chromosomes[i] = this.Apply((T)parameters[i]);
            }

            return chromosomes;
        }

        protected abstract F GenerateMutationValue(E[] genes, int mutationPoint);

        public virtual T Apply(T a)
        {
            if (!base.SortApply()) return a;

            a.Genes = Apply(a.Genes);
            return a;
        }

        public E[] Apply(E[] genes)
        {
            int mutationPoint = base.GeneratePoint(genes);

            UtilChromosome.InvertValueInGenes<E, F>
                (genes, mutationPoint, this.GenerateMutationValue(genes, mutationPoint));

            return genes;
        }

    } // end : class
} // end : namespace
