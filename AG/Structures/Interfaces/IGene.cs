using System;

namespace GA.Structures.Interfaces
{
    public interface IGene<T> : BIGene
    {
        public T Value { get; set; }
    }
}
