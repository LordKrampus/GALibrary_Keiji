using GA.Structures.Individuals;
using GA.Structures.Interfaces;
using GA.Structures.BasicInterfaces;
using GALibrary.Factories;

namespace GA.Factories
{
    public class FIndividual : IFactory
    {
        private static FIndividual _instance;

        private FIndividual() { }

        public static FIndividual Instance => _instance ??= new FIndividual();

        public static IIndividual<T, E, F> Reflection_CreateIndividual<T, E, F>(T chromosome) 
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new Individual<T, E, F>(chromosome);
        }

        public object? CreateItem(Type tIndividual, Type[] tGenerics, object[] arguments)
        {
            return typeof(FIndividual).GetMethod("Reflection_CreateIndividual")?.
                MakeGenericMethod(tGenerics).Invoke(null, arguments);
        }

        public static IIndividual<T, E, F>[] Reflection_CreateEmptyArray<T, E, F>(Type type, int size)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new IIndividual<T, E, F>[size];
        }

        public object[]? CreateEmptyArray(Type type, Type[] tGenerics, int size)
        {
            return (BIIndividual[]?)typeof(FIndividual).GetMethod("Reflection_CreateEmptyArray")?.
               MakeGenericMethod(tGenerics)
               .Invoke(null, new object[] { type, size });
        }
    }
}
