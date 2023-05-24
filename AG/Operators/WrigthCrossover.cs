using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Individuals;
using GA.Structures.Utilities;
using GALibrary.Structures.Real;

namespace GA.Operators
{
    public class WrigthCrossover : RealCrossover
    {
        public WrigthCrossover(IFunction function, double factor, double beta, bool isSum) : 
            base(function, factor, beta, isSum) 
        { }

        public override RealChromosome[] Apply(RealChromosome a, RealChromosome b)
        {
            if (!base.SortApply()) return new RealChromosome[] { a, b };

            RealGene[][] sections;

            sections = this.Apply(a.Genes, b.Genes);
            a.Genes = sections[0];
            b.Genes = sections[1];

            return new RealChromosome[] { a, b };
        }

        public override RealGene[][] Apply(RealGene[] aE, RealGene[] bE)
        {
            int length = aE.Length;
            RealGene[][] fs = new RealGene[3][];

            base.GenerateChild(aE, bE, base.Beta, (1 - base.Beta), out fs[0], length);
            base.GenerateChild(aE, bE, (1 + base.Beta),  (-base.Beta), out fs[1], length);
            base.GenerateChild(aE, bE, (-base.Beta), (1 + base.Beta), out fs[2], length);

            double[] fitness = new double[3];
            Individual<RealChromosome, RealGene, double> individual = new Individual<RealChromosome, RealGene, double>(new RealChromosome(fs[0]));
            fitness[0] = base.Function.Calc(individual);
            individual = new Individual<RealChromosome, RealGene, double>(new RealChromosome(fs[1]));
            fitness[1] = base.Function.Calc(individual);
            individual = new Individual<RealChromosome, RealGene, double>(new RealChromosome(fs[2]));
            fitness[2] = base.Function.Calc(individual);

            if(base.Function.IsMinimization)
                if (fitness[0] < fitness[2] && fitness[1] < fitness[2])
                    return new RealGene[][] { fs[0], fs[1] };
                else if (fitness[0] < fitness[1] && fitness[2] < fitness[1])
                    return new RealGene[][] { fs[0], fs[2] };
                else
                    return new RealGene[][] { fs[1], fs[2] };
            else
                if (fitness[0] > fitness[2] && fitness[1] > fitness[2])
                return new RealGene[][] { fs[0], fs[1] };
            else if (fitness[0] > fitness[1] && fitness[2] > fitness[1])
                return new RealGene[][] { fs[0], fs[2] };
            else
                return new RealGene[][] { fs[1], fs[2] };
        }
    }
}
