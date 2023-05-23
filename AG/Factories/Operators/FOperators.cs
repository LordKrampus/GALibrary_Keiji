using GA.Operators.Interfaces;
using GA.Structures.Interfaces;
using System;


namespace GALibrary.Factories.Operators
{
    public abstract class FOperators<T, E, F>: IFactory where T : IChromosome<E, F> where E : IGene<F>
    {
        public object CreateItem(Type type, Type[] tGenerics, object[] arguments)
        {
            throw new NotImplementedException();
        }

        public object[] CreateEmptyArray(Type type, Type[] tGenerics, int size)
        {
            throw new NotImplementedException();
        }

        public object[] CreateEmptyArray(int size)
        {
            return new IOperator<T, E, F>[size];
        }
    }
}
