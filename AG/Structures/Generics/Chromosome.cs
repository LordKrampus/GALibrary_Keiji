using GA.Structures.Interfaces;
using System;
using System.Text;

namespace GA.Structures.Generics
{
    public abstract class Chromosome<T, E> : IChromosome<T, E> where T : IGene<E>
    {
        protected T[] _genes;

        public virtual T[] Genes { get => this._genes; set => this._genes = value; }
        public virtual BIGene[] ObjGenes { get => this._genes as BIGene[]; set => this._genes = value as T[]; }

        public abstract double Value { get; }
        public abstract double MaxValue { get; }

        public virtual int Count => this.Genes.Length;

        public Chromosome(T[] gene)
        {
            this._genes = gene;
        }

        public abstract object New(object[] arguments);

        public virtual object[] GenerateArray(int length)
        {
            return new IChromosome<T, E>[length];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T gene in this._genes)
                sb.Append(gene.ToString());

            return $"{sb.ToString()} .value: {this.Value} .maxValue {this.MaxValue}";
        }

    } // end : class

} // end : namespace
