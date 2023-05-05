using GA.Structures.Generics;
using System;

namespace GA.Structures.Integer
{
    public class DynamicIntegerChromosome : DynamicChromosome<IntegerGene, int>
    {
        private int _maxValue;

        public override double Value
        {
            get
            {
                double value = 0;
                foreach (IntegerGene gene in base.Genes)
                    value += gene.Value;
                return value;
            }
        }
        public override double MaxValue => this._maxValue;

        public DynamicIntegerChromosome(IntegerGene[] genes, int maxValue) : base(genes)
        {
            this._maxValue = maxValue;
        }

        public override DynamicIntegerChromosome Generate(int length)
        {
            int size = base.Genes.Length;
            IntegerGene[] newGenes = new IntegerGene[size];
            for (int i = 0; i < size; i++)
                newGenes[i] = new IntegerGene(0);
            return new DynamicIntegerChromosome(newGenes, this._maxValue);
        }
    }
}
