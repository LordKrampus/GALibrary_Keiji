using GA.Structures.Interfaces;
using System;
using System.Text;

/*
namespace AG.Structures._deprecated.Combines
{
    public class CombineChromosome<T> : ICombineChromosome where T : IChromosome
    {
        private List<T> _sequence;
        private double _limit;

        public IChromosome[] Sequence
        {
            get
            {
                return _sequence.ToArray() as IChromosome[];
            }
            set
            {
                _sequence.Clear();
            }
        }
        public int Count => _sequence.Count;

        // IChromosome
        public IGene[] Genes
        {
            get
            {
                int fullSize = 0;
                int size = Sequence.Length;
                IGene[][] genes = new IGene[size][];
                for (int i = 0; i < size; i++)
                {
                    genes[i] = _sequence[i].Genes;
                    fullSize += genes[i].Length;
                }

                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double Value
        {
            get
            {
                double value = .0f;
                foreach (T chromosome in _sequence)
                {
                    value += chromosome.Value;
                }
                return value;
            }
        }

        public IChromosome[] FlatListChromosomes()
        {
            throw new NotImplementedException();
        }

        public double MaxValue => _limit;

        public CombineChromosome(double limit)
        {
            _sequence = new List<T>();
            _limit = limit;
        }

        public IChromosome Generate(int Length)
        {
            return new CombineChromosome<T>(_limit);
        }

        public void Add(IChromosome chromosome)
        {
            _sequence.Add((T)chromosome);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                sb.Append(_sequence[i].ToString() + "\n");
            }

            return $"({Value}/{MaxValue}):[\n{sb.ToString()}]";
        }
    }
}
*/