using System;

using GA.Structures;
using GA.Structures.Interfaces;
using GA.Operators.Interfaces;
using GA.Operators;
using GA.Utilities;
using GA.Structures.Utilities;

namespace GA.Operators
{
    public abstract class Crossover<T, E, F> : Operator<T, E, F> where T : IChromosome<E, F> where E: IGene<F>
    {
        public Crossover(double factor) : base(factor) 
        { }

        public override T[] Apply(T[] arguments)
        {
            return this.Apply((T)arguments[0], (T)arguments[1]);
        }

        public virtual T[] Apply(T a, T b)
        {
            if (!base.SortApply()) return new T[] { a, b };

            E[][] sections;

            sections = this.Apply(a.Genes, b.Genes);
            a.Genes = sections[0];
            b.Genes = sections[1];

            return new T[] { a, b };
        }

        public E[][] Apply(E[] a, E[] b)
        {
            E[][] aSections;
            E[][] bSections;

            int individualSize = a.Length;
            int slicePoint = base.GeneratePoint(a);

            UtilChromosome.SplitSectionsInGenes<E, F>(a, individualSize, slicePoint, out aSections);
            UtilChromosome.SplitSectionsInGenes<E, F>(b, individualSize, slicePoint, out bSections);

            UtilChromosome.SwapSectionInChromosome<E, F>(a, slicePoint, bSections[1], individualSize - slicePoint);
            UtilChromosome.SwapSectionInChromosome<E, F>(b, slicePoint, aSections[1], individualSize - slicePoint);

            return new E[][] { a, b };
        }

    } // end : class (Crossover<>:IOperation<>)
} // end : namespace (*.Operacoes)
