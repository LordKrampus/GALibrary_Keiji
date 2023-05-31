using System;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Utilities;
using GALibrary.Structures.Real;

namespace GA.Operators
{
    public class RealMutation : Mutation<RealChromosome, RealGene, double> 
    {
        private double _lInf, _lSup; // limites

        public RealMutation(IFunction function, double factor, double lInf, double lSup) : base(function, factor) 
        {
            this._lInf = lInf;
            this._lSup = lSup;
        }

        protected override double GenerateMutationValue(RealGene[] genes, int mutationPoint)
        {
            return sorter.SortContinue(base.Function.LInfs[mutationPoint], base.Function.LSups[mutationPoint]);
        }
    }
}
