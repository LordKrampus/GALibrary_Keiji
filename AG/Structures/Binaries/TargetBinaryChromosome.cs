﻿using System;
using System.Text;
using GA.Structures.Generics;
using GA.Structures.Interfaces;

namespace GA.Structures.Binaries
{
    public class TargetBinaryChromosome : BinaryChromosome, ITargetChromosome<BinaryGene, bool>
    {
        private int _target;

        public int Target => this._target;

        public double[] Values
        {
            get
            {
                double[] values = new double[2];
                values[0] = 0;

                int size = Target - 1;
                for (int e = 0; e <= size; e++)
                    if ((bool)Genes[e].Value)
                        values[0] += (int)Math.Pow(2, size - e);

                values[1] = 0;
                size = base.Genes.Length - Target - 1;
                for (int e = 0; e <= size; e++)
                    if ((bool)Genes[e + Target].Value)
                        values[1] += (int)Math.Pow(2, size - e);

                return values;
            }
        }

        public double[] MaxValues
        {
            get
            {
                double[] values = new double[2];
                values[0] = 0;

                int size = Target - 1;
                for (int e = 0; e <= size; e++)
                    values[0] += (int)Math.Pow(2, size - e);

                values[1] = 0;
                size = base.Genes.Length - Target - 1;
                for (int e = 0; e <= size; e++)
                    values[1] += (int)Math.Pow(2, size - e);

                return values;
            }
        }

        public TargetBinaryChromosome(BinaryGene[] genes,  int target) : base(genes) 
        {
            this._target = target;
        }

        public override TargetBinaryChromosome Generate(int length)
        {
            BinaryGene[] newGenes = new BinaryGene[length];

            for (int i = 0; i < length; i++)
                newGenes[i] = new BinaryGene(false);

            return new TargetBinaryChromosome(newGenes, this._target);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    } // end : struct
} // end : namespace
