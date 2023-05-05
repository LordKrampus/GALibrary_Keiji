using GA.Structures.Generics;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Capsules
{
    public class DynamicChromosome<T, E, F> : 
        Chromosome<T, E> where T : PersistentGene<E> where E : GeneChromosome<F> where F : BIChromosome
    {
        private int _limit;

        public override double Value 
        {
            get
            {
                double value = 0;
                foreach (T gene in base.Genes)
                    value += gene.Value.Value.Value;
                return value;
            }
        }

        public override double MaxValue
        {
            get
            {
                double value = 0;
                foreach (T chromosome in base.Genes)
                    value += chromosome.Value.Value.MaxValue;
                return value;
            }
        }

        public DynamicChromosome(int limit) : base(new T[] { }) 
        {
            this._limit = limit;
        }

        public override BIChromosome Generate(int length)
        {
            DynamicChromosome<T, E, F> newChromosome = new DynamicChromosome<T, E, F>(this._limit);
            return newChromosome;
        }

        public void AddGene(T gene)
        {
            List<T> genes = new List<T>(base.Genes);
            genes.Add(gene);
            this.Genes = genes.ToArray();
        }

        public void AddGenes(T[] genes)
        {
            this.Genes = new List<T>(genes).ToArray();
        }

        public void Clear()
        {
            this.Genes = new T[] { };
        }
    }
}
