using System;

using GA.Structures.Generics;
using GA.Structures.Interfaces;

namespace GA.Structures.Capsules
{
    public class GeneChromosome<Chrom, Gen, Val> : Gene<Val> where Chrom : IChromosome<Gen, Val> where Gen : IGene<Val>
    {
        private Chrom _chromosome;

        public Chrom Chromosome => this._chromosome;

        public override Val Value
        {
            get
            {
                return this._value; // !!!
            }
        }

        public GeneChromosome(Chrom chromosome) : base(default) 
        {
            this._chromosome = chromosome;
        }

        public override object New(object[] arguments)
        {
            return new GeneChromosome<Chrom, Gen, Val>((Chrom)this._chromosome.New(new object[]{ }));
        }

        public override object[] GenerateArray(int length)
        {
            return new GeneChromosome<Chrom, Gen, Val>[length];
        }

        public override string ToString()
        {
            return this.Chromosome.ToString() ;
        }
    }
}
