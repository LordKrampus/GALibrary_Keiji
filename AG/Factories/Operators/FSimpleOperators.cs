using GA.Factories;
using GA.Functions.Interfaces;
using GA.Operators;
using GA.Operators.Interfaces;
using GA.Structures.Binaries;
using GA.Structures.Interfaces;
using GALibrary.Structures.Real;
using System;

namespace GALibrary.Factories.Operators
{
    public class FSimpleOperators<T, E, F> : FOperators<T, E, F> 
        where T : IChromosome<E, F> where E : IGene<F>
    {
        private static FSimpleOperators<T, E, F> _instance;

        private FSimpleOperators() { }

        public static FSimpleOperators<T, E, F> GetInstance()
        {
            return _instance ??= new FSimpleOperators<T, E, F>();
        }

        public object CreateItem(Type type, Type[] tGenerics, object[] arguments)
        {
            throw new NotImplementedException();
        }

        public object[] CreateEmptyArray(Type type, Type[] tGenerics, int size)
        {
            throw new NotImplementedException();
        }

        public BIOperator CreateCrossover(Type type, object[] arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryCrossover)):
                    return CreateBinaryCrossover(arguments);

                case Type t when t.Equals(typeof(RadcliffeCrossover)):
                    return CreateRadCliffeCrossover(arguments);

                case Type t when t.Equals(typeof(WrigthCrossover)):
                    return CreateWrigthCrossover(arguments);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateBinaryCrossover(object[] arguments)
        {
            return new BinaryCrossover((double)arguments[0]);
        }

        private static BIOperator CreateRadCliffeCrossover(object[] arguments)
        {
            return new RadcliffeCrossover((double)arguments[0], (bool)arguments[1], (double)arguments[2]);
        }

        private static BIOperator CreateWrigthCrossover(object[] arguments)
        {
            return new WrigthCrossover((IFunction)arguments[0], (bool)arguments[1], (double)arguments[2], (bool)arguments[3], (double)arguments[4]);
        }

        public BIOperator CreateMutation(Type type, object[] arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryChromosome)):
                    return CreateBinaryMutation(arguments);

                case Type t when t.Equals(typeof(RealChromosome)):
                    return CreateRealMutation(arguments);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateBinaryMutation(object[] arguments)
        {
            return new BinaryMutation((double)arguments[0]);
        }

        private static BIOperator CreateRealMutation(object[] arguments)
        {
            return new RealMutation((double)arguments[0], (double)arguments[1], (double)arguments[2]);
        }

    }
}
