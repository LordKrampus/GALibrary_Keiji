using System;

using GA.Structures.Capsules;
using GA.Structures.Generics;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;


namespace GA.Factories
{
    public class FGeneCapsule
    {
        private static FGeneCapsule _instance;

        private FGeneCapsule() { }

        public static FGeneCapsule Instance => _instance ??= new FGeneCapsule();

        /*
        public static IGene<T> Reflection_CreateGeneCapsule<T, E, F>(Type tGene, T value, object[] arguments)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            switch (tGene)
            {
                case Type t when t.Equals(typeof(GeneChromosome<,,>)):
                    return new GeneChromosome<T, E, F>(value);

                case Type t when t.Equals(typeof(PersistentGene<>)):
                    return new PersistentGene<T>(value, (int)arguments[0]);

                default:
                    throw new Exception();
            }
        }

        public object? CreateGeneCapsule(Type tChromosome, Type tGene, Type tValue, object value, object[] arguments)
        {
            return typeof(FGeneCapsule).GetMethod("Reflection_CreateGene")?.
                MakeGenericMethod(new Type[] { tChromosome, tGene, tValue }).
                Invoke(null, new object[] { value, arguments });
        }

        public static IGene<T>? Reflection_CreateEmptyArray<T,E,F>(Type tCapsule , int size)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            switch (tCapsule)
            {
                case Type t when t.Equals(typeof(GeneChromosome<,,>)):
                    return new GeneChromosome<T, E, F>[size] as  IGene<T>;

                default:
                    throw new Exception();
            }
        }

        public object? CreateEmptyArray(Type tChromosome, Type tGene, Type tValue, Type tCapsule, int size)
        {
            return typeof(FGeneCapsule).GetMethod("Reflection_CreateGene")?.
               MakeGenericMethod(new Type[] { tChromosome, tGene, tValue }).
               Invoke(null, new object[] { tCapsule, size });
        }
        */
    }
}
