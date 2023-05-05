using System;

using GA.Structures.Generics;
using GA.Structures.Interfaces;

namespace GA.Structures.Capsules
{
    public class GeneChromosome<T> : Gene<T>
    {
        public GeneChromosome(T value) : base(value) { }

        public override GeneChromosome<T> Generate()
        {
            return new GeneChromosome<T>(this._value);
        }

        public override string ToString()
        {
            return base._value.ToString() ;
        }
    }
}
