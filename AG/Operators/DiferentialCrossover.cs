using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;
using GALibrary.Structures.Real;

namespace GA.Operators
{
    public class DiferentialCrossover : Crossover<RealChromosome, RealGene, double>
    {
        public DiferentialCrossover(IFunction function, double factor) : base(function, factor)
        {  }

        public override RealChromosome[] Apply(RealChromosome a, RealChromosome b)
        {
            return new RealChromosome[] { this.CalcU(v:a, x:b, d:a.Count) };
        }

        public RealChromosome CalcU(RealChromosome v, RealChromosome x, int d)
        {
            RealChromosome u = new RealChromosome(new RealGene[d]);
            double r, l;
            for (int i = 0; i < d; i++)
            {
                r = base.sorter.SortContinue(0, 1);
                l = base.sorter.SortBefore(d);

                u.Genes[i] = 
                    new RealGene(r <= this.Factor || i == l ? v.Genes[i].Value : x.Genes[i].Value);  
            }

            return u;
        }

        public override RealGene[][] Apply(RealGene[] aE, RealGene[] bE)
        {
            throw new NotImplementedException();
        }
    }
}
