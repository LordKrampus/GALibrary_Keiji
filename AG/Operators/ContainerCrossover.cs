using GA.Operators;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using GA.Structures.Utilities;
using System;

namespace GALibrary.Operators
{
    public class ContainerCrossover<T, E, F, G, H> : Crossover<T, G, H>
        where T : ContainerChromosome<GeneChromosome<DynamicChromosome<E, F, G, H>, E, H>, E, F, G, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
        where F : IChromosome<G, H> where G : IGene<H>
    {
        public ContainerCrossover(double factor) : base(factor)
        { }

        public override T[] Apply(T a, T b)
        {
            if (!base.SortApply()) return new T[] { a, b };

            E[][] sections = new E[2][];

            sections[0] = a.GetFlatSequence();
            sections[1] = b.GetFlatSequence();

            E[][] aSections;
            E[][] bSections;

            int individualSize = sections[0].Length;
            int slicePoint = base._sorter.SortBefore(individualSize - 1);

            UtilChromosome.SplitSectionsInGenes<E, H>(sections[0], individualSize, slicePoint, out aSections);
            UtilChromosome.SplitSectionsInGenes<E, H>(sections[1], individualSize, slicePoint, out bSections);

            UtilChromosome.SwapSectionInGenesCombine<E, H>(sections[0], slicePoint, bSections[1], individualSize - slicePoint);
            UtilChromosome.SwapSectionInGenesCombine<E, H>(sections[1], slicePoint, aSections[1], individualSize - slicePoint);

            a.AddSequence(sections[0]);
            b.AddSequence(sections[1]);

            return new T[] { a, b };
        }
    }
}
