using GA.Functions.Interfaces;
using GA.Operators;
using GA.Operators.Interfaces;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using GALibrary.Structures.Real;
using System;


namespace GALibrary.Factories.Operators
{
    public abstract class FOperators: IFactory
    {
        public object CreateItem(Type type, Type[] tGenerics, object[] arguments)
        {
            throw new NotImplementedException();
        }

        public object[] CreateEmptyArray(Type type, Type[] tGenerics, int size)
        {
            throw new NotImplementedException();
        }

        public abstract BIOperator CreateCrossover(Type type, IFunction function, double factor, object[]? arguments);

        public abstract BIOperator CreateMutation(Type type, IFunction function, double factor, object[]? arguments);

        public abstract object[] CreateEmptyArray(int size);

        public static FOperators GetInstance(Type type, Type[] tGenerics)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(FSimpleOperators<,,>)):
                    return (FOperators)typeof(FOperators).GetMethod("Reflection_GetInstanceFSimpleOperators")?.MakeGenericMethod(tGenerics).Invoke(null, new object[] { });

                case Type t when t.Equals(typeof(FTargetOperators<,,>)):
                    return (FOperators)typeof(FOperators).GetMethod("Reflection_GetInstanceFTergetOperators")?.MakeGenericMethod(tGenerics).Invoke(null, new object[] { });

                case Type t when t.Equals(typeof(FContainerOperators<,,,,>)):
                    return (FOperators)typeof(FOperators).GetMethod("Reflection_GetFContainerOperators")?.MakeGenericMethod(tGenerics).Invoke(null, new object[] { });

                default:
                    throw new ArgumentException();
            }
        }

        public static FOperators Reflection_GetInstanceFSimpleOperators<T, E, F>()
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return FSimpleOperators<T, E, F>.GetInstance();
        }


        public static FOperators Reflection_GetInstanceFTergetOperators<T, E, F>()
            where T : ITargetChromosome<E, F> where E : IGene<F>
        {
            return FTargetOperators<T, E, F>.GetInstance();
        }


        public static FOperators Reflection_GetFContainerOperators<T, E, F, G, H>()
            where T : ContainerChromosome<GeneChromosome<DynamicChromosome<E, F, G, H>, E, H>, E, F, G, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
            where F : IChromosome<G, H> where G : IGene<H>
        {
            return FContainerOperators<T, E, F, G, H>.GetInstance();
        }

    }
}
