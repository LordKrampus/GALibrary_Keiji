
using GA.Operators.Interfaces;
using GA.Functions.Interfaces;
using GA.Structures.Interfaces;

using GA.Operators;

namespace GALibrary.Factories.Operators
{
    public class FSimpleOperators<T, E, F> : FOperators
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

        public override BIOperator CreateCrossover(Type type, IFunction function, double factor, object[]? arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryCrossover)):
                    return CreateBinaryCrossover(function, factor);

                case Type t when t.Equals(typeof(RadcliffeCrossover)):
                    return CreateRadCliffeCrossover(function, factor, (double)arguments[0], (bool)arguments[1]);

                case Type t when t.Equals(typeof(WrigthCrossover)):
                    return CreateWrigthCrossover(function, factor, (double)arguments[0], (bool)arguments[1]);

                case Type t when t.Equals(typeof(DiferentialCrossover)):
                    return CreateDiferentialCrossover(function, factor);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateBinaryCrossover(IFunction function, double factor)
        {
            return new BinaryCrossover(function, factor);
        }

        private static BIOperator CreateRadCliffeCrossover(IFunction function, double factor, double beta, bool isSum)
        {
            return new RadcliffeCrossover(function, factor, beta, isSum);
        }

        private static BIOperator CreateWrigthCrossover(IFunction function, double factor, double beta, bool isSum)
        {
            return new WrigthCrossover(function, factor, beta, isSum);
        }

        private static BIOperator CreateDiferentialCrossover(IFunction function, double factor)
        {
            return new DiferentialCrossover(function, factor);
        }

        public override BIOperator CreateMutation(Type type, IFunction function, double factor, object[]? arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryMutation)):
                    return CreateBinaryMutation(function, factor);

                case Type t when t.Equals(typeof(RealMutation)):
                    return CreateRealMutation(function, factor);

                case Type t when t.Equals(typeof(DiferentialMutation)):
                    return CreateDiferentialMutation(function, factor);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateBinaryMutation(IFunction function, double factor)
        {
            return new BinaryMutation(function, factor);
        }

        private static BIOperator CreateRealMutation(IFunction function, double factor)
        {
            return new RealMutation(function, factor);
        }
        private static BIOperator CreateDiferentialMutation(IFunction function, double factor)
        {
            return new DiferentialMutation(function, factor);
        }

        public override object[] CreateEmptyArray(int size)
        {
            return new IOperator<T, E, F>[size];
        }
    }
}
