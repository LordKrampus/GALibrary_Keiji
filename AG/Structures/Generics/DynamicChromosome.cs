using GA.Structures.Capsules;
using GA.Factories;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;
using System.Text;

namespace GA.Structures.Generics
{
    public abstract class DynamicChromosome<T, E> : IChromosome<T, E> where T : Gene<E>
    {
        protected List<T> _genes;

        public T[] Genes
        {
            get
            {
                return this.Genes.ToArray();
            }
            set
            {
                // algoritmo de distribuicao
                /*
                int firstMatch;
                int e = 0;
                PersistentGene<E> gene;
                for (int i = 0; i < value.Length; i++)
                {
                    firstMatch = e;
                    gene = value[i] as PersistentGene<E>;
                    while (gene.Persistence > e - firstMatch)
                    {
                        if (e >= value.Length)
                        {
                            e = gene.Persistence;
                            firstMatch = 0;
                            break;
                        }

                        if (((IChromosome<T,>(IGene<E>)gene.Value).Value) + (BIChromosome)this._genes[e].Value <= (BIChromosome)this._genes[e].MaxValue)
                        {
                            e++;
                            continue;
                        }
                        else
                        {
                            e++;
                            firstMatch = e;
                            continue;
                        }
                    }

                    for (int j = firstMatch; j < e; j++)
                    {
                        this._genes[j].Add(value[i]);
                    }

                    if (e >= this._genes.Count)
                        e = 0;
                */
                throw new NotImplementedException();

            }
        }
        public BIGene[] ObjGenes { get => this._genes as BIGene[]; set => throw new NotImplementedException(); }

        public abstract double Value { get; }
        public abstract double MaxValue { get; }

        public DynamicChromosome(T[] genes)
        {
            this.Genes = genes;
        }

        public abstract BIChromosome Generate(int length);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (T gene in this._genes)
                sb.Append(gene.ToString());

            return $"{sb.ToString()} .value: {this.Value} .maxValue {this.MaxValue}";
        }
    }
}
