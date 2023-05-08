using GA.Structures.Generics;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Capsules
{
    public class DynamicChromosome<T, E, F, G> : Chromosome<T, G>
        //where T : PersistentGene<E> where E : GeneChromosome<F> where F : BIChromosome
        //where T : PersistentGene<GeneChromosome<E, F, G>, G> where E : IChromosome<F, G> where F : IGene<G>
        where T : PersistentGene<GeneChromosome<E, F, G>, G> where E : IChromosome<F, G> where F : IGene<G>
    {
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

        public double Limit => this._limit;

        public DynamicChromosome(double limit) : base(Array.Empty<T>()) 
        {
            this._limit = limit;
        }

        public override BIChromosome Generate(int length)
        {
            DynamicChromosome<T, E, F, G> newChromosome = new DynamicChromosome<T, E, F, G>(this._limit);
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
    }
}
