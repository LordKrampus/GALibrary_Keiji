using System;

using GA.Structures.BasicInterfaces;

namespace GA.Structures.Interfaces
{
    public interface ITargetChromosome<T, E> : BITargetChromosome, IChromosome<T, E> where T : IGene<E>
    { }

}
