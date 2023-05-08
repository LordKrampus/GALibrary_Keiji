using GA.Structures.Generics;
using GA.Structures.Interfaces;
using System;
using System.Text;

namespace GA.Structures.Integer
{
    public class IntegerChromosome : Chromosome<IntegerGene, int>
    {
        private int _maxValue;

        public override double Value 
        {
            get 
            {
                double value = 0;
                foreach(IntegerGene gene in base.Genes)
                    value += gene.Value;
                return value;
            }
        }
        public override double MaxValue => this._maxValue;

        public IntegerChromosome(IntegerGene[] genes, int maxValue) : base(genes)
        {
            this._maxValue = maxValue;
        }

        public override IntegerChromosome Generate(int length)
        {
            int size = base.Genes.Length;
            IntegerGene[] newGenes = new IntegerGene[size];
            for (int i = 0; i < size; i++)
                newGenes[i] = new IntegerGene(0);
            return new IntegerChromosome(newGenes, this._maxValue);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach(IntegerGene gene in base._genes)
                sb.Append(gene.ToString() + " ");

            return sb.ToString();
        }
    }
}
