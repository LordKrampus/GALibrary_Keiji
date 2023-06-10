using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;
using GALibrary.Structures.Real;

namespace GA.Operators
{
    public class DiferentialMutation : Mutation<RealChromosome, RealGene, double>
    {
        public DiferentialMutation(IFunction function, double factor) : base(function, factor)
        {
        }

        public override RealChromosome[] Apply(RealChromosome[] parameters)
        {
            RealChromosome[] chromosomes = new RealChromosome[]{
                ((RealChromosome)parameters[0]),
                ((RealChromosome)parameters[1]),
                ((RealChromosome)parameters[2]),
            };

            return new RealChromosome[] { 
                this.Calc(chromosomes[0], chromosomes[1], chromosomes[2], chromosomes[0].Count) };
        }

        // v[i,g+1] <= x[r1, g] + F(x[r3, g] - x[r2, g])
        public RealChromosome Calc(RealChromosome r1, RealChromosome r2, RealChromosome r3, int length)
        {
            RealChromosome v = new RealChromosome(new RealGene[length]);
            for(int i = 0; i < length; i++)
            {
                v.Genes[i] = 
                    new RealGene(base.Factor * (r3.Genes[i].Value - r2.Genes[i].Value) + r1.Genes[i].Value);
            }

            return v;
        }

        public override RealChromosome Apply(RealChromosome a)
        {
            throw new NotImplementedException();
        }

        public override RealGene[] Apply(RealGene[] genes)
        {
            throw new NotImplementedException();
        }

        protected override double GenerateMutationValue(RealGene[] genes, int mutationPoint)
        {
            throw new NotImplementedException();
        }
    }
}
