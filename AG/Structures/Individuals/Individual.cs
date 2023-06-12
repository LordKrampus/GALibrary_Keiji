using System;
using System.Text;
using GA.Structures.Binaries;
using GA.Structures.Interfaces;

namespace GA.Structures.Individuals
{
    public class Individual<T, E, F> : IIndividual<T, E, F> where T : IChromosome<E, F> where E : IGene<F>
    {
        protected T _chromosome;
        protected double _fitness;

        public T Chromosome
        { get => _chromosome; set => _chromosome = value; }
        public BIChromosome ObjChromosome => this.Chromosome;

        public double Fitness
        { get => _fitness; set => _fitness = value; }

        public double Value => Chromosome.Value;
        public virtual int Size => Chromosome.Genes.Length;

        public Individual(T chromosome)
        {
            _chromosome = chromosome;
            _fitness = .0f;
        }

        public object New(object[] arguments)
        {
            int iSize = _chromosome.Genes.Length;
            return new Individual<T, E, F>((T)_chromosome.New(new object[] { iSize }));
        }

        public object[] GenerateArray(int length)
        {
            return new IIndividual<T, E, F>[length];
        }


        public virtual object Clone()
        {
            int iSize = _chromosome.Genes.Length;
            T newChromosome = (T)_chromosome.New(new object[] { iSize });

            E gene;
            E newGene;
            for (int i = 0; i < iSize; i++)
            {
                gene = _chromosome.Genes[i];

                newGene = (E)gene.New(new object[] { });
                newGene.Value = gene.Value;

                newChromosome.Genes[i] = newGene;
            }

            Individual<T, E, F> newIndividual = new Individual<T, E, F>(newChromosome);
            newIndividual.Fitness = Fitness;

            return newIndividual;
        }

        public override string ToString()
        {
            return $"{this._chromosome.ToString()}; {this._fitness}";
        }
    }
}
