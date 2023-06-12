using GA.Structures.Generics;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;
using GA.Factories;
using System.Text;

namespace GA.Structures.Capsules
{
    public class ContainerChromosome<Gen1, Caps, Chrom, Gen2, Val> : Chromosome<Gen2, Val>
        where Gen1 : GeneChromosome<DynamicChromosome<Caps, Chrom, Gen2, Val>, Caps, Val> where Caps : PersistentGene<GeneChromosome<Chrom, Gen2, Val>, Val>
        where Chrom : IChromosome<Gen2, Val> where Gen2 : IGene<Val>
    {
        private Gen1[] _containers;

        public Gen1[] Containers => this._containers;

        public override double Value
        {
            get
            {
                double value = 0;
                foreach (Gen1 container in this._containers)
                    value += container.Chromosome.Value;
                return value;
            }
        }

        public override double MaxValue
        {
            get
            {
                double value = 0;
                foreach(Gen1 container in this._containers)
                    value += container.Chromosome.MaxValue;
                return value;
            }
        }

        public override int Count => this._containers.Length;

        public ContainerChromosome(Gen1[] containers) : base (Array.Empty<Gen2>()) 
        {
            this._containers = containers;
        }

        public void AddSequence(Caps[] sequence)
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
            foreach(Gen1 container in this._containers)
            {
                container.Chromosome.ClearCombine();
            }
        }

        public BIGene[] ObjArrayGetFlatSequence()
        {
            return GetFlatSequence();
        }


        public Caps[] GetFlatSequence()
        {
            List<Caps> sequence = new List<Caps>();
            int containersCount = this._containers.Length, sequenceCount;
            Caps gene;
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

        public override ContainerChromosome<Gen1, Caps, Chrom, Gen2, Val> New(object[] arguments)
        {
            Gen1[] newGenes = new Gen1[this.Count];
            for (int i = 0; i < this.Count; i++)
                newGenes[i] = (Gen1)this.Containers[i].New(new object[] { });

            return new ContainerChromosome<Gen1, Caps, Chrom, Gen2, Val>(newGenes);
        }

        public override object[] GenerateArray(int length)
        {
            return new ContainerChromosome<Gen1, Caps, Chrom, Gen2, Val>[length];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Gen1 container in this._containers)
            {
                sb.Append(container.ToString() + "");
            }

            return sb.ToString();
        }
    }
}
