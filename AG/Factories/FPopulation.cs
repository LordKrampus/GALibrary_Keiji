using GA.Utilities;

using GA.Structures.Interfaces;
using GA.Structures.BasicInterfaces;

using GA.Structures.Populations;
using GA.Operators.Interfaces;
using GALibrary.Factories;

namespace GA.Factories
{
    public class FPopulation : IFactory
    {
        private static FPopulation _instance;
        private Sorter _sorter;

        private FPopulation() 
        {
            this._sorter = new Sorter();
        }

        public static FPopulation Instance => _instance ??= new FPopulation();

        public static IPopulation<T, E, F> Reflection_CreatePopulation<T, E, F>(BIIndividual[] individuals, int populationSize, bool biggerIsBetter) 
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new Population<T, E, F>((IIndividual<T, E, F>[])individuals, populationSize, biggerIsBetter);
        }

        public object? GeneratePopulation(Type tPopulation, Type[] tGenerics, BIIndividual[] individuals, int populationSize, bool biggerIsBetter)
        {
            return this.CreateItem(tPopulation, tGenerics, new object[] { individuals, populationSize, biggerIsBetter });
        }

        public object? CreateItem(Type tPopulation, Type[] tGenerics, object[] arguments)
        {
            return (object?)typeof(FPopulation).GetMethod("Reflection_CreatePopulation")?.
                MakeGenericMethod(tGenerics).
                Invoke(null, arguments );
        }

        public static IPopulation<T, E, F>[] Reflection_CreateEmptyArray<T, E, F>(Type type, int size)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new IPopulation<T, E, F>[size];
        }

        public object[]? CreateEmptyArray(Type type, Type[] TGenerics, int size)
        {
            return (object[]?)typeof(FPopulation).GetMethod("Reflection_CreateEmptyArray")?.
                         MakeGenericMethod(TGenerics).
                         Invoke(null, new object[] { type, size });
        }
    }
}
