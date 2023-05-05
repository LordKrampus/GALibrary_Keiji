using System;

using GA.Utilities;
using GA.Operators.Interfaces;
using GA.Structures.Interfaces;
using GA.Structures.Utilities;
using GA.Structures;
using GA.Structures.Binaries;

namespace GA.Operators
{
    public class TargetMutation<T, E, F>: Mutation<T, E, F> where T : ITargetChromosome<E, F> where E : IGene<F>
    {
        private Mutation<T, E, F> _covered;

        public TargetMutation(Mutation<T, E, F> covered, double factor) : base(factor) 
        {
            this._covered = covered;
        }

        protected override int GeneratePoint(T chromosome)
        {
            return chromosome.Target;
        }
        protected override F GenerateMutationValue(E[] genes, int mutationPoint)
        {
            throw new NotImplementedException();
        }

        public override T Apply(T a)
        {
            if (!base.SortApply()) return a;

            E[][] sections = new E[2][];

            int individualSize = a.Genes.Length;
            int slicePoint = this.GeneratePoint(a);

            UtilChromosome.SplitSectionsInChromosome<T, E, F>(a, individualSize, slicePoint, out sections);
            this._covered.Apply(sections[0]);
            this._covered.Apply(sections[1]);

            return a;
        } 
    }
}
