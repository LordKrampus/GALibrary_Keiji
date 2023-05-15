using GA.Structures.Generics;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;
using System.Text;

namespace GA.Structures.Capsules
{
    public class DynamicChromosome<Caps, Chrom, Gen, Val> : Chromosome<Caps, Val>
       //Chromosome<Caps, Gen1>
       //where T : PersistentGene<E> where E : GeneChromosome<F> where F : BIChromosome
       //where T : PersistentGene<GeneChromosome<E, F, G>, G> where E : IChromosome<F, G> where F : IGene<G>
       //where T : PersistentGene<GeneChromosome<E, F, G>, G> where E : IChromosome<F, G> where F : IGene<G>
       //where Caps : PersistentGene<Gen1> where Gen1 : GeneChromosome<Chrom, Gen2, Val> 
       //where Chrom : IChromosome<Gen2, Val>where Gen2 : IGene<Val>
       where Caps : PersistentGene<GeneChromosome<Chrom, Gen, Val>, Val> where Chrom : IChromosome<Gen, Val> where Gen : IGene<Val>
    {
        private string _name;
        private double _limit;

        public override double Value
        {
            get
            {
                double value = 0;
                foreach (Caps capsule in base.Genes)
                    value += capsule.Gene.Chromosome.Value;
                return value;
            }
        }

        public override double MaxValue
        {
            get
            {
                double value = 0;
                foreach (Caps capsule in base.Genes)
                    value += capsule.Gene.Chromosome.MaxValue;
                return value;
            }
        }

        public override int Count => this.Genes.Length;

        public double Limit => this._limit;
        public string Name => this._name;

        public DynamicChromosome(string name, double limit) : base(Array.Empty<Caps>()) 
        {
            this._name = name;
            this._limit = limit;
        }

        public override BIChromosome New(object[] arguments)
        {
            DynamicChromosome<Caps, Chrom, Gen, Val> newChromosome = 
                new DynamicChromosome<Caps, Chrom, Gen, Val>(this._name, this._limit);
            newChromosome.Genes = new Caps[this.Genes.Length];
            for (int i = 0; i < this.Genes.Length; i++)
                newChromosome.Genes[i] = this.Genes[i];
            return newChromosome;
        }

        public override object[] GenerateArray(int length)
        {
            return new DynamicChromosome<Caps, Chrom, Gen, Val>[length];
        }

        public void AddGene(Caps gene)
        {
            this.Genes = new List<Caps>(base.Genes)
            {
                gene
            }.ToArray();
        }

        public void AddGenes(Caps[] genes)
        {
            this.Genes = new List<Caps>(genes).ToArray();
        }

        public void ClearCombine()
        {
            this.Genes = Array.Empty<Caps>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Caps gene in this.Genes)
                sb.Append(gene.ToString() + " ");

            return sb.ToString();
        }
    }
}
