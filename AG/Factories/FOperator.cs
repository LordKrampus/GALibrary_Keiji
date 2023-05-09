﻿using GA.Operators.Interfaces;
using GA.Structures.Interfaces;

using GA.Operators;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GALibrary.Operators;

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

        public static IOperator<T, G, H> Reflection_CreateContainerCrossover<T, E, F, G, H>(double factor)
            where T : ContainerChromosome<GeneChromosome<DynamicChromosome<E, F, G, H>, E, H>, E, F, G, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
            where F : IChromosome<G, H> where G : IGene<H>
        {
            return new ContainerCrossover<T, E, F, G, H>(factor);
        }

        public static IOperator<T, G, H> Reflection_CreateContainerMutation<T, E, F, G, H>(double factor)
            where T : ContainerChromosome<GeneChromosome<DynamicChromosome<E, F, G, H>, E, H>, E, F, G, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
            where F : IChromosome<G, H> where G : IGene<H>
        {
            return new ContainerMutation<T, E, F, G, H>(factor);
        }

        public BIOperator? CreateContainerCrossover(Type[] tGenerics, double factor)
        {
            return (BIOperator?)typeof(FOperator).GetMethod("Reflection_CreateContainerCrossover")?.
                MakeGenericMethod(tGenerics).Invoke(null, new object[] { factor });
        }

        public BIOperator? CreateContainerMutation(Type[] tGenerics, double factor)
        {
            return (BIOperator?)typeof(FOperator).GetMethod("Reflection_CreateContainerMutation")?.
                MakeGenericMethod(tGenerics).Invoke(null, new object[] { factor });
        }

        public BIOperator? CreateContainerOperator(Type tOperator, Type[] tGenerics, double factor)
        {
            string methodName;
            switch (tOperator)
            {
                case Type t when t.Equals(typeof(Crossover<,,>)):
                    methodName = "Reflection_CreateContainerCrossover";
                    break;
                case Type t when t.Equals(typeof(Mutation<,,>)):
                    methodName = "Reflection_CreateContainerMutation";
                    break;
                default:
                    throw new Exception();
            }

            return (BIOperator?)typeof(FOperator).GetMethod(methodName)?.
                MakeGenericMethod(tGenerics).Invoke(null, new object[] { factor });
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
