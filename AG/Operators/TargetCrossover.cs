using System;
using GA.Functions.Interfaces;
using GA.Structures.Interfaces;
using GA.Structures.Utilities;

namespace GA.Operators
{
    public class TargetCrossover<T, E, F> : Crossover<T, E, F> where T : ITargetChromosome<E, F> where E : IGene<F>
    {
        private Crossover<T, E, F> _covered;

        public TargetCrossover(IFunction function, double factor, Crossover<T, E, F> covered) : base(function, factor) 
        {
            this._covered = covered;
        }

        protected override int GeneratePoint(T chromosome)
        {
            return chromosome.Target;
        }

        public override T[] Apply(T a, T b)
        {
            if (!base.SortApply()) return new T[] { a, b };

            E[][] aSections = new E[2][];
            E[][] bSections = new E[2][];

            int individualSize = a.Genes.Length;
            int slicePoint = this.GeneratePoint(a);

            UtilChromosome.SplitSectionsInChromosome<T, E, F>(a, individualSize, slicePoint, out aSections);
            UtilChromosome.SplitSectionsInChromosome<T, E, F>(b, individualSize, slicePoint, out bSections);

            this._covered.Apply(aSections[0], bSections[0]);
            this._covered.Apply(aSections[1], bSections[1]);

            a.Genes = aSections[0].Concat(aSections[1]).ToArray();
            b.Genes = bSections[0].Concat(bSections[1]).ToArray();

            return new T[] { a, b };
        }
    } // end : class (Crossover<>:IOperation<>)
} // end : namespace (*.Operacoes)


/*
if (!base.SortApply()) return new T[] { a, b };

E[][] aSections = new E[4][];
E[][] bSections = new E[4][];

int individualSize = a.Genes.Length;
int[] slicePoints = new int[] 
    { base._sorter.SortBefore(a.Target), a.Target, base._sorter.SortBetween(a.Target, individualSize)};
UtilChromosome.SplitSectionsInChromosome<T, E, F>(a, individualSize, slicePoints, 3, out aSections);
UtilChromosome.SplitSectionsInChromosome<T, E, F>(b, individualSize, slicePoints, 3, out bSections);

UtilChromosome.SwapSectionInChromosome<T, E, F>(a, slicePoints[0], bSections[1], a.Target - slicePoints[0]);
UtilChromosome.SwapSectionInChromosome<T, E, F>(a, slicePoints[2], bSections[3], individualSize - slicePoints[2]);

UtilChromosome.SwapSectionInChromosome<T, E, F>(b, slicePoints[0], aSections[1], a.Target - slicePoints[0]);
UtilChromosome.SwapSectionInChromosome<T, E, F>(b, slicePoints[2], aSections[3], individualSize - slicePoints[2]);

return new T[] { a, b };
*/