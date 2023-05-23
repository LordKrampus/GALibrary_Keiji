using GA.Factories;
using GA.Functions.Interfaces;
using GA.Operators.Interfaces;
using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Interfaces;
using GALibrary.Structures.Real;
using System;

namespace GALibrary.Factories.Operators
{
    public class FTargetOperators<T, E, F> : FOperators<T, E, F>
        where T : ITargetChromosome<E, F> where E : IGene<F>
    {
        private static FTargetOperators<T, E, F> _instance;

        private FTargetOperators() { }

        public static FTargetOperators<T, E, F> GetInstance()
        {
            return _instance ??= new FTargetOperators<T, E, F>();
        }

        public BIOperator CreateCrossover(Type type, object[] arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(TargetCrossover<,,>)):
                    return CreateTargetCrossover(arguments);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateTargetCrossover(object[] arguments)
        {
            return new TargetCrossover<T, E, F>((Crossover<T, E, F>)arguments[0], (double)arguments[1]);
        }

        public BIOperator CreateMutation(Type type, object[] arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(TargetMutation<,,>)):
                    return CreateTargetMutation(arguments);

                default:
                    throw new Exception();
            }
        }

        private static BIOperator CreateTargetMutation(object[] arguments)
        {
            return new TargetMutation<T, E, F>((Mutation<T, E, F>)arguments[0], (double)arguments[1]);
        }
    }
}
