using GA.Operators.Interfaces;
using GA.Structures.Interfaces;

using GA.Operators;
using GA.Structures.Binaries;

namespace GA.Factories
{
    public class FOperator
    {
        private static FOperator? _instance;

        private FOperator() { }

        public static FOperator Instance => _instance ??= new FOperator();

        public static IOperator<T, E, F> Reflection_CreateSimpleOperator<T, E, F>(Type type, object[] arguments)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(Crossover<,,>)):
                    return Reflection_CreateCrossover<T, E, F>(typeof(T), arguments);

                case Type t when t.Equals(typeof(Mutation<,,>)):
                    return Reflection_CreateMutation<T, E, F>(typeof(T), arguments);

                default:
                    throw new Exception();
            }
        }

        public static IOperator<T, E, F> Reflection_CreateTargetOperator<T, E, F>(Type type, object[] arguments)
            where T : ITargetChromosome<E, F> where E : IGene<F>
        {

            switch (type)
            {
                case Type t when t.Equals(typeof(Crossover<,,>)):
                    return new TargetCrossover<T, E, F>(
                        (Crossover<T, E, F>)FOperator.Reflection_CreateSimpleOperator<T, E, F>(typeof(Crossover<,,>), arguments), factor: (double)arguments[0]);

                case Type t when t.Equals(typeof(Mutation<,,>)):
                    return new TargetMutation<T, E, F>(
                        (Mutation<T, E, F>)FOperator.Reflection_CreateSimpleOperator<T, E, F>(typeof(Mutation<,,>), arguments), factor: (double)arguments[0]);

                default:
                    throw new Exception();
            }
        }

        public static IOperator<T, E, F> Reflection_CreateCrossover<T, E, F>(Type type, object[] arguments)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryChromosome)):
                     return CreateBinaryCrossover<T, E, F, BinaryChromosome>(arguments);

                case Type t when t.Equals(typeof(TargetBinaryChromosome)):
                    return CreateBinaryCrossover<T, E, F, TargetBinaryChromosome>(arguments);

                default:
                    throw new Exception();
            }
        }

        public static IOperator<T, E, F> Reflection_CreateMutation<T, E, F>(Type type, object[] arguments)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryChromosome)):
                    return CreateBinaryMutation<T, E, F, BinaryChromosome>(arguments);

                case Type t when t.Equals(typeof(TargetBinaryChromosome)):
                    return CreateBinaryMutation<T, E, F, TargetBinaryChromosome>(arguments);

                default:
                    throw new Exception();
            }
        }


        private static IOperator<T, E, F> CreateBinaryCrossover<T, E, F, G>(object[] arguments)
            where T : IChromosome<E, F> where E : IGene<F> where G : BinaryChromosome
        {
            return (IOperator<T, E, F>)new BinaryCrossover<G>((double)arguments[0]);
        }

        private static IOperator<T, E, F> CreateBinaryMutation<T, E, F, G>(object[] arguments)
            where T : IChromosome<E, F> where E : IGene<F> where G : BinaryChromosome
        {
            return (IOperator<T, E, F>)new BinaryMutation<G>((double)arguments[0]);
        }

        public object? GenerateOperator(Type tChromosomeInterface, Type tOperator, Type[] tGenerics, object[] arguments)
        {
            string reflectionMethod;
            switch (tChromosomeInterface)
            {
                case Type t when t.Equals(typeof(IChromosome<,>)):
                    reflectionMethod = "Reflection_CreateSimpleOperator";
                    break;

                case Type t when t.Equals(typeof(ITargetChromosome<,>)):
                    reflectionMethod = "Reflection_CreateTargetOperator";
                    break;

                default:
                    throw new Exception();
            }

            return typeof(FOperator).GetMethod(reflectionMethod)?.
                        MakeGenericMethod(tGenerics).
                        Invoke(null, new object[] { tOperator, arguments });
        }

        public static IOperator<T, E, F>[] Reflection_CreateEmptyList<T, E, F>(int size)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new IOperator<T, E, F>[size];
        }

        public object[]? CreateEmptyArray(Type[] TGenerics, int size)
        {
            return (object[]?)typeof(FOperator).GetMethod("Reflection_CreateEmptyList")?.
                         MakeGenericMethod(TGenerics).
                         Invoke(null, new object[] { size });
        }
    }
}
