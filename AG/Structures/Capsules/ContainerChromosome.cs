using GA.Structures.Generics;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Capsules
{
    public class ContainerChromosome<T, E, F, G, H> : 
        Chromosome<T, E> where T : GeneChromosome<E> where E : DynamicChromosome<F, G, H> where F : PersistentGene<G>
        where G : GeneChromosome<H> where H : BIChromosome
    {
        public override T[] Genes
        {
            set
            {
                BIGene[] sequence = value;

                // algoritmo de distribuicao
                /*
                int firstMatch;
                int e = 0;
                PersistentGene<E> gene;
                for (int i = 0; i < value.Length; i++)
                {
                    firstMatch = e;
                    gene = value[i] as PersistentGene<E>;
                    while (gene.Persistence > e - firstMatch)
                    {
                        if (e >= value.Length)
                        {
                            e = gene.Persistence;
                            firstMatch = 0;
                            break;
                        }

                        if (((IChromosome<T,>(IGene<E>)gene.Value).Value) + (BIChromosome)this._genes[e].Value <= (BIChromosome)this._genes[e].MaxValue)
                        {
                            e++;
                            continue;
                        }
                        else
                        {
                            e++;
                            firstMatch = e;
                            continue;
                        }
                    }

                    for (int j = firstMatch; j < e; j++)
                    {
                        this._genes[j].Add(value[i]);
                    }

                    if (e >= this._genes.Count)
                        e = 0;
                }
                */
            }
        }

        public override double Value
        {
            get
            {
                double value = 0;
                foreach (T chromosome in base.Genes)
                    value += chromosome.Value.Value;
                return value;
            }
        }

        public override double MaxValue
        {
            get
            {
                double value = 0;
                foreach(T chromosome in base.Genes)
                    value += chromosome.Value.MaxValue;
                return value;
            }
        }

        public ContainerChromosome(T[] genes) : base (genes) { }

        public override ContainerChromosome<T, E, F, G, H> Generate(int length)
        {
            T[] newGenes = new T[length];
            for (int i = 0; i < length; i++)
                newGenes[i] = (T)base.Genes[0].Generate();

            return new ContainerChromosome<T, E, F, G, H>(newGenes);
        }

        private void ClearSequence()
        {
            foreach(T chromosome in base.Genes)
            {
            }
        }

        public BIGene[] GetFlatSequence()
        {
            List<BIGene> sequence = new List<BIGene>();
            int containersCount = base.Genes.Length, sequenceCount;
            for (int i = 0; i < containersCount; i++)
            {
                sequenceCount = base.Genes[i].Value.ObjGenes.Length;
                for (int e = 0; e < sequenceCount; e++)
                {
                    sequence.Add(base.Genes[i].Value.ObjGenes[e]);
                }
            }
            return sequence.ToArray();
        }
    }
}
