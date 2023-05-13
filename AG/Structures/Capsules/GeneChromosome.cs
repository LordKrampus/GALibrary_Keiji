using System;

using GA.Structures.Generics;
using GA.Structures.Interfaces;

namespace GA.Structures.Capsules
{
    public class GeneChromosome<T, E, F> : Gene<F> where T : IChromosome<E, F> where E : IGene<F>
    {
        private T _chromosome;

        public T Chromosome => this._chromosome;

        public override F Value
        {
            get
            {
                return this._chromosome.Genes[0].Value; // !!!
            }
        }

        public GeneChromosome(T chromosome) : base(default) 
        {
            this._chromosome = chromosome;
        }

        public override object New(object[] arguments)
        {
            return new GeneChromosome<T, E, F>((T)this._chromosome.New(new object[]{ }));
        }

        public object[] GenerateArray(int length)
        {
            return new GeneChromosome<T, E, F>[length];
        }

        public override string ToString()
        {
            return $"{this._chromosome.ToString()} ({base._value.ToString()})" ;
        }
    }
}
