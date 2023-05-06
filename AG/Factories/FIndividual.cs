using GA.Structures.Individuals;
using GA.Structures.Interfaces;
using GA.Structures.BasicInterfaces;

namespace GA.Factories
{
    public class FIndividual
    {
        private static FIndividual _instance;

        private FIndividual() { }

        public static FIndividual Instance => _instance ??= new FIndividual();

        public static IIndividual<T, E, F> Reflection_CreateIndividual<T, E, F>(Type type, T chromosome) 
            where T : IChromosome<E, F> where E : IGene<F>
        {
            switch (type) 
            {
                case Type t when t.Equals(typeof(Individual<,,>)):
                    return new Individual<T, E, F>(chromosome);

                default:
                    throw new NotImplementedException();
            }
        }

        public static IIndividual<T, E, F>[] Reflection_CreateEmptyArray<T, E, F>(Type type, int size)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(Individual<,,>)):
                    return new Individual<T, E, F>[size];

                default:
                    throw new NotImplementedException();
            }
        }

        public object? CreateIndividual(Type tChromosome, Type tGene, Type tGeneValue, Type tIndividual,
            object chromosome)
        {
            return typeof(FIndividual).GetMethod("Reflection_CreateIndividual")?.
                MakeGenericMethod(new Type[] { tChromosome, tGene, tGeneValue})
                .Invoke(null, new object[] { tIndividual, chromosome });
        }

        public BIIndividual[]? CreateEmptyArray(Type tChromosome, Type tGene, Type tGeneValue, Type tIndividual, int size)
        {
            return (BIIndividual[]?)typeof(FIndividual).GetMethod("Reflection_CreateEmptyArray")?.
               MakeGenericMethod(new Type[] { tChromosome, tGene, tGeneValue })
               .Invoke(null, new object[] { tIndividual, size });
        }
    }
}
