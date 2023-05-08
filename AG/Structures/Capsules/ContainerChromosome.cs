using GA.Structures.Generics;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;
using GA.Factories;

namespace GA.Structures.Capsules
{
    public class ContainerChromosome<T, E, F, G, H> : Chromosome<G, H> 
        //where T : GeneChromosome<G> where E : DynamicChromosome<F, G, H> where F : PersistentGene<G>
        //where G : GeneChromosome<H> where H : BIChromosome
        where T : GeneChromosome<DynamicChromosome<E, F, G, H>, E, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
        where F : IChromosome<G, H> where G : IGene<H> 
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

        public ContainerChromosome(T[] containers) : base (Array.Empty<G>()) 
        {
            this._containers = containers;
        }

        public override ContainerChromosome<T, E, F, G, H> Generate(int length)
        {
            T[] newGenes = new T[length];
            for (int i = 0; i < length; i++)
                newGenes[i] = (T)base.Genes[0].Generate();

            return new ContainerChromosome<T, E, F, G, H>(newGenes);
        }

        public void AddSequence(E[] sequence)
        {
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
                        if(controlCheck > 0)
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


        public void ClearSequence()
        {
            foreach(T container in this._containers)
            {
                container.Chromosome.Clear();
            }
        }

        public BIGene[] GetFlatSequence()
        {
            List<E> sequence = new List<E>();
            int containersCount = this._containers.Length, sequenceCount;
            for (int i = 0; i < containersCount; i++)
            {
                sequenceCount = this._containers[i].Chromosome.Genes.Length;
                for (int e = 0; e < sequenceCount; e++)
                {
                    sequence.Add(this._containers[i].Chromosome.Genes[e]);
                }
            }
            return sequence.ToArray();
        }
    }
}
