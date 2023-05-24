using GA.Factories;
using GA.Functions.Interfaces;
using GA.Operators.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Interfaces;
using GALibrary.Structures.Real;
using System;
using System.Xml.Linq;

namespace GALibrary.Factories.Operators
{
    public class FTargetOperators<T, E, F> : FOperators
        where T : ITargetChromosome<E, F> where E : IGene<F>
    {
        private static FTargetOperators<T, E, F> _instance;

        private FTargetOperators() { }

        public static FTargetOperators<T, E, F> GetInstance()
        {
            return _instance ??= new FTargetOperators<T, E, F>();
        }

        public override BIOperator CreateCrossover(Type type, IFunction function, double factor, object[]? arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(TargetCrossover<,,>)):
                    return CreateTargetCrossover(function, factor, (Crossover<T, E, F>)arguments[0]);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateTargetCrossover(IFunction function, double factor, Crossover<T, E, F> covered)
        {
            return new TargetCrossover<T, E, F>(function, factor, covered);
        }

        public override BIOperator CreateMutation(Type type, IFunction function, double factor, object[]? arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(TargetMutation<,,>)):
                    return CreateTargetMutation(function, factor, (Mutation<T, E, F>)arguments[0]);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateTargetMutation(IFunction function, double factor, Mutation<T, E, F> covered)
        {
            return new TargetMutation<T, E, F>(function, factor, covered);
        }

        public override object[] CreateEmptyArray(int size)
        {
            return new IOperator<T, E, F>[size];
        }
    }
}
