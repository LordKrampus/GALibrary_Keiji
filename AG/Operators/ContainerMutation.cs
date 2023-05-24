using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using GA.Structures.Utilities;
using System;
using static System.Collections.Specialized.BitVector32;

namespace GALibrary.Operators
{
    public class ContainerMutation<T, E, F, G, H> : Mutation<T, G, H>
       where T : ContainerChromosome<GeneChromosome<DynamicChromosome<E, F, G, H>, E, H>, E, F, G, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
       where F : IChromosome<G, H> where G : IGene<H>
    {
        public ContainerMutation(IFunction function, double factor) : base(function, factor)
        { }

        protected override H GenerateMutationValue(G[] genes, int mutationPoint)
        {
            throw new NotImplementedException();
        }

        public override T Apply(T a)
        {
            if (!base.SortApply()) return a;

            E[] sequence = a.GetFlatSequence();

            int mpA, mpB;
            int individualSize = sequence.Length;

            mpA = sorter.SortBefore(individualSize - 1);
            mpB = sorter.SortBefore(individualSize - 1);

            UtilChromosome.InvertGeneInSequence<E, H>(sequence, mpA, mpB);

            a.AddSequence(sequence);

            return a;
        }
    }
}
