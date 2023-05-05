using System;
using System.Text;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;

/*
namespace AG.Structures._deprecated.Combines
{
    public class ContainerChromosome<T> : ICombineChromosome where T : IChromosome
    {
        private CombineChromosome<T>[] _sequence;
        private double _limit;

        public IChromosome[] Sequence
        {
            get
            {
                return _sequence;
            }
            set
            {
                // algoritmo de distribuicao
                foreach (CombineChromosome<T> combine in _sequence)
                    combine.Sequence = null;
                _limit = 0;

                IChromosome[] values = value as IChromosome[];

                int firstMatch;
                int e = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    firstMatch = e;
                    while (((PersistentChromosome)values[i]).Persistence > e - firstMatch)
                    {
                        if (e >= _sequence.Length)
                        {
                            e = ((PersistentChromosome)values[i]).Persistence;
                            firstMatch = 0;
                            break;
                        }

                        if (values[i].Value + _sequence[e].Value <= _sequence[e].MaxValue)
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
                        _sequence[j].Add(values[i]);
                    }

                    if (e >= _sequence.Length)
                        e = 0;

                    _limit += values[i].Value;
                }
            }
        }
        public int Count => _sequence.Length;

        // interface
        public double Value
        {
            get
            {
                double value = .0f;
                foreach (IChromosome chromosome in _sequence)
                    value += chromosome.Value;
                return value;
            }
            private set => throw new NotImplementedException();
        }
        public double MaxValue
        {
            get
            {
                double value = .0f;
                foreach (IChromosome chromosome in _sequence)
                    value += chromosome.MaxValue;
                return value;
            }
        }

        public IGene[] Genes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ContainerChromosome(CombineChromosome<T>[] combines)
        {
            _sequence = combines;
            _limit = 0;
        }

        public void Add(IChromosome chromosome)
        {
            throw new NotImplementedException();
        }

        public IChromosome[] FlatListChromosomes()
        {
            List<T> flatList = new List<T>();
            foreach (CombineChromosome<T> combine in _sequence)
            {
                foreach (T chromosome in combine.Sequence)
                {
                    if (!flatList.Contains(chromosome))
                        flatList.Add(chromosome);
                }
            }

            return flatList.ToArray() as IChromosome[];
        }

        public IChromosome Generate(int length)
        {
            int size = Count;
            CombineChromosome<T>[] combines = new CombineChromosome<T>[size];

            for (int i = 0; i < size; i++)
            {
                combines[i] = (CombineChromosome<T>)_sequence[i].Generate(length);
            }

            ContainerChromosome<T> container = new ContainerChromosome<T>(combines);
            container.Sequence = FlatListChromosomes();

            return container;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (CombineChromosome<T> combine in _sequence)
            {
                sb.Append(combine.ToString() + "\n");
            }

            return $"({Value}/{MaxValue}):\n{sb.ToString()}";
        }
    }
}
*/
