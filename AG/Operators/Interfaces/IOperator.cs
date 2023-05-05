using GA.Operators.Interfaces;
using GA.Structures.Interfaces;

namespace GA.Operators.Interfaces
{
    public interface IOperator<T, E, F> : BIOperator where T : IChromosome<E, F> where E: IGene<F>
    {
        public T[] Apply(T[] paramameters);
    }
}
