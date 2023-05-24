using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;
using GALibrary.Structures.Real;

namespace GA.Operators
{
    public abstract class RealCrossover : Crossover<RealChromosome, RealGene, double>
    {
        private double _beta;
        private int _subOperator;

        protected double Beta { get => this._beta; }
        protected double SubOperator { get => this._beta; }

        public RealCrossover(IFunction function, double factor, double beta, bool isSum) : base(function, factor) 
        {
            this._beta = beta;
            this._subOperator = isSum? 1 : -1;
        }

        public new abstract RealGene[][] Apply(RealGene[] aE, RealGene[] bE);

        protected void GenerateChild(RealGene[] pA, RealGene[] pB, double factorA, double factorB, out RealGene[] f, int length)
        {
            f = new RealGene[length];
            for(int i = 0; i < length; i++)
            {
                f[i] = new RealGene(factorA * pA[i].Value + this.SubOperator * factorB * pB[i].Value);
            }
        }
    }
}
