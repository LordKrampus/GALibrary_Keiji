using System;
using GA.Structures.Binaries;

namespace GA.Structures.Interfaces
{
    public interface IChromosome<T, E> : BIChromosome where T : IGene<E>
    {
        public T[] Genes { get; set; }
    }
}
