using GA.Structures.Generics;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;
using System.Text;

namespace GA.Structures.Capsules
{
    public class DynamicChromosome<T, E, F, G> : Chromosome<T, G>
        //where T : PersistentGene<E> where E : GeneChromosome<F> where F : BIChromosome
        //where T : PersistentGene<GeneChromosome<E, F, G>, G> where E : IChromosome<F, G> where F : IGene<G>
        where T : PersistentGene<GeneChromosome<E, F, G>, G> where E : IChromosome<F, G> where F : IGene<G>
    {
        private string _name;
        private double _limit;

        public override double Value
        {
            get
            {
                double value = 0;
                foreach (T chromosome in base.Genes)
                    value += chromosome.Gene.Chromosome.Value;
                return value;
            }
        }

        public override double MaxValue
        {
            get
            {
                double value = 0;
                foreach (T chromosome in base.Genes)
                    value += chromosome.Gene.Chromosome.MaxValue;
                return value;
            }
        }

        public int Count => this.Genes.Length;

        public double Limit => this._limit;
        public string Name => this._name;

        public DynamicChromosome(string name, double limit) : base(Array.Empty<T>()) 
        {
            this._name = name;
            this._limit = limit;
        }

        public override BIChromosome Generate(int length)
        {
            DynamicChromosome<T, E, F, G> newChromosome = new DynamicChromosome<T, E, F, G>(this._name, this._limit);
            newChromosome.Genes = new T[this.Genes.Length];
            for (int i = 0; i < this.Genes.Length; i++)
                newChromosome.Genes[i] = this.Genes[i];
            return newChromosome;
        }

        public void AddGene(T gene)
        {
            this.Genes = new List<T>(base.Genes)
            {
                gene
            }.ToArray();
        }

        public void AddGenes(T[] genes)
        {
            this.Genes = new List<T>(genes).ToArray();
        }

        public void Clear()
        {
            this.Genes = Array.Empty<T>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T gene in this.Genes)
                sb.Append(gene.ToString() + " ");

            return sb.ToString();
        }
    }
}
