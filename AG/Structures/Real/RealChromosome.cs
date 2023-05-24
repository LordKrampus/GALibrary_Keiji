using System;
using System.Text;
using GA.Structures.Generics;
using GA.Structures.Integer;

namespace GALibrary.Structures.Real
{
    public class RealChromosome : Chromosome<RealGene, double>
    {
        public override double Value 
        {
            get
            {
                double value = 0;
                foreach (RealGene gene in this.Genes)
                    value += gene.Value;
                return value;
            }
        }

        public override double MaxValue => this.Value;

        public RealChromosome(RealGene[] genes) : base(genes) { }

        public override object New(object[] arguments)
        {
            RealGene[] newGenes = new RealGene[this.Count];
            for (int i = 0; i < this.Count; i++)
                newGenes[i] = (RealGene)this._genes[0].New(new object[] { });

            return new RealChromosome(newGenes);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (RealGene gene in base._genes)
                sb.Append(gene.ToString() + " ");

            return sb.ToString();
        }
    }
}
