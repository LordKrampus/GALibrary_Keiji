using System;
using System.Text;
using GA.Structures.Generics;
using GA.Structures.Interfaces;

namespace GA.Structures.Binaries
{
    public class BinaryChromosome : Chromosome<BinaryGene, bool>
    {
        public override double Value
        {
            get
            {
                int value = 0;
                int size = base.Genes.Length - 1;

                for (int i = 0; i <= size; i++)
                    if (base.Genes[i].Value)
                        value += (int)Math.Pow(2, size - i);

                return value;
            }
        }

        public override double MaxValue
        {
            get
            {
                int value = 0;
                int size = Genes.Length - 1;

                for (int i = 0; i <= size; i++)
                    value += (int)Math.Pow(2, size - i);

                return value;
            }
        }

        public BinaryChromosome(BinaryGene[] genes) : base(genes)
        { }

        public override BinaryChromosome New(object[] arguments)
        {
            BinaryGene[] newGenes = new BinaryGene[this.Count];
            for (int i = 0; i < this.Count; i++)
                newGenes[i] = (BinaryGene)this._genes[0].New(new object[] { });

            return new BinaryChromosome(newGenes);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    } // end : struct
} // end : namespace
