using GA.Structures.Generics;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;
using GA.Factories;

namespace GA.Structures.Capsules
{
    public class ContainerChromosome<T, E, F> : Chromosome<E, F> 
        //where T : GeneChromosome<G> where E : DynamicChromosome<F, G, H> where F : PersistentGene<G>
        //where G : GeneChromosome<H> where H : BIChromosome
        ///where T : GeneChromosome<DynamicChromosome<E, F, G, H>, E, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
        //where F : IChromosome<G, H> where G : IGene<H> 
        where T : GeneChromosome<DynamicChromosome<PersistentGene<GeneChromosome<IChromosome<E, F>, E, F>, F>, E, F>, E, F> where E : IGene<F>
    {
        private T[] _containers;

        public T[] Containers => this._containers;

        public override double Value
        {
            get
            {
                double value = 0;
                foreach (T container in this._containers)
                    value += container.Chromosome.Value;
                return value;
            }
        }

        public override double MaxValue
        {
            get
            {
                double value = 0;
                foreach(T container in this._containers)
                    value += container.Chromosome.MaxValue;
                return value;
            }
        }

        public ContainerChromosome(T[] containers) : base (Array.Empty<T>()) 
        {
            this._containers = containers;
        }

        public override ContainerChromosome<T, E, F, G, H> New(object[] arguments)
        {
            T[] newGenes = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
                newGenes[i] = (T)this.Containers[i].New(new object[] { });

            return new ContainerChromosome<T, E, F, G, H>(newGenes);
        }

        public void AddSequence(E[] sequence)
        {
            this.ClearContainers();
            int valuesCount = sequence.Length, containersCount = this._containers.Length;

            int controlCheck, firstMatch, e = 0;
            for (int i = 0; i < valuesCount; i++)
            {
                controlCheck = 0;
                firstMatch = e;

                while (sequence[i].Persistence > e - firstMatch)
                {
                    // fora do array de containers
                    if (e >= containersCount)
                    {
                        if (controlCheck > 0)
                        {
                            // adiciona do primeiro container
                            firstMatch = 0;
                            e = sequence[i].Persistence;
                            break;
                        }

                        // certifica uma busca a partir do primeiro container
                        e = 0;
                        firstMatch = e;
                        controlCheck++;
                        continue;
                    }

                    if (sequence[i].Gene.Chromosome.Value + this._containers[e].Chromosome.Value <= this._containers[e].Chromosome.Limit)
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
                    this._containers[j].Chromosome.AddGene(sequence[i]);
                }

                if (e >= containersCount)
                    e = 0;
            }
        }

        public void ClearContainers()
        {
            foreach(T container in this._containers)
            {
                container.Chromosome.ClearCombine();
            }
        }

        public BIGene[] ObjArrayGetFlatSequence()
        {
            return GetFlatSequence();
        }


        public E[] GetFlatSequence()
        {
            List<E> sequence = new List<E>();
            int containersCount = this._containers.Length, sequenceCount;
            E gene;
            for (int i = 0; i < containersCount; i++)
            {
                sequenceCount = this._containers[i].Chromosome.Genes.Length;
                for (int e = 0; e < sequenceCount; e++)
                {
                    gene = this._containers[i].Chromosome.Genes[e];
                    if (gene.Persistence > 1 && sequence.Contains(gene))
                        continue;

                    sequence.Add(gene);
                }
            }
            return sequence.ToArray();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
