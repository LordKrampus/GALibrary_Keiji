﻿using System;
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

        public override BinaryChromosome Generate(int length)
        {
            BinaryGene[] newGenes = new BinaryGene[length];
            for (int i = 0; i < length; i++)
                newGenes[i] = this._genes[0].Generate();

            return new BinaryChromosome(newGenes);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    } // end : struct
} // end : namespace
