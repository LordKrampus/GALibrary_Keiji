using GA.Structures.Interfaces;
using System;
using System.Text;

namespace GA.Structures.Generics
{
    public abstract class TargetChromosome<T, E> : Chromosome<T, E> where T : IGene<E>, ITargetChromosome<T, E>
    {
        private int _target;

        public int Target => this._target;

        public abstract double[] Values { get; }
        public abstract double[] MaxValues { get; }

        public TargetChromosome(T[] genes, int target) : base(genes)
        {  
            this._target = target;
        }

        public override abstract BIChromosome Generate(int length);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int length = base.Genes.Length;
            for (int i = 0; i < length; i++)
            {
                if (i == this.Target)
                    sb.Append("| ");
                sb.Append(base.Genes[i].ToString() + " ");
            }

            double[] values = this.Values;
            return $".String:{sb.ToString()} .Value x: {values[0]} .Values y: {values[1]}";
        }
    }
}
