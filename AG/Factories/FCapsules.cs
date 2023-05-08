using GA.Structures.Interfaces;

using GA.Structures.Capsules;

namespace GA.Factories
{
    public class FGeneCapsule
    {
        private static FGeneCapsule _instance;

        private FGeneCapsule() { }

        public static FGeneCapsule Instance => _instance ??= new FGeneCapsule();


        public static ContainerChromosome<T, E, F, G, H> Reflection_CreateContainerChromosome<T, E, F, G, H>(T[] genes)
            where T : GeneChromosome<DynamicChromosome<E, F, G, H>, E, H> where E : PersistentGene<GeneChromosome<F, G, H>, H>
            where F : IChromosome<G, H> where G : IGene<H>
        {
            return new ContainerChromosome<T, E, F, G, H>(genes);
        }

        public static DynamicChromosome<T, E, F, G> Reflection_CreateDynamicChromosome<T, E, F, G>(int limit)
           where T : PersistentGene<GeneChromosome<E, F, G>, G> where E : IChromosome<F, G> where F : IGene<G>
        {
            return new DynamicChromosome<T, E, F, G>(limit);
        }

        public BIChromosome? CreateContainerChromosome(Type[] tGenerics, BIGene[] genes)
        {
            return (BIChromosome?)typeof(FChromosome).GetMethod("Reflection_CreateContainerChromosome")?.
                MakeGenericMethod(tGenerics).Invoke(null, new object[] { genes });
        }

        public BIChromosome? CreateDynamicChromosome(Type[] tGenerics, int limit)
        {
            return (BIChromosome?)typeof(FChromosome).GetMethod("Reflection_CreateDynamicChromosome")?.
                MakeGenericMethod(tGenerics).Invoke(null, new object[] { limit });
        }

        public BIChromosome? CreateChromosomeCapsule(Type tChromosome, Type[] tGenerics, object[] arguments)
        {
            string methodStr;
            switch (tChromosome)
            {
                case Type t when t.Equals(typeof(ContainerChromosome<,,,,>)):
                    methodStr = "Reflection_CreateContainerChromosome";
                    break;

                case Type t when t.Equals(typeof(DynamicChromosome<,,,>)):
                    methodStr = "Reflection_CreateDynamicChromosome";
                    break;

                default:
                    throw new Exception();
            }

            return (BIChromosome?)typeof(FChromosome).GetMethod(methodStr)?.
               MakeGenericMethod(tGenerics).Invoke(null, arguments);
        }

        public static BIGene Reflection_CreatePersistentGene<T, E>(T gene, string name, int persistence)
            where T : IGene<E>
        {
            return new PersistentGene<T, E>(gene, name, persistence);
        }

        public static BIGene Reflection_CreateGeneChromosome<T, E, F>(T chromosome)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            return new GeneChromosome<T, E, F>(chromosome);
        }

        public BIGene? CreatePersistentGene(Type tValue, object gene, string name, int persistence)
        {
            return (BIGene?)typeof(FGene).GetMethod("Reflection_CreatePersistentGene")?.
               MakeGenericMethod(tValue).Invoke(null, new object[] { gene, name, persistence });
        }

        public BIGene? CreateGeneChromosome(Type tValue, object chromosome)
        {
            return (BIGene?)typeof(FGene).GetMethod("Reflection_CreateGeneChromosome")?.
                MakeGenericMethod(tValue).Invoke(null, new object[] { chromosome });
        }

        public BIChromosome? CreateGeneCapsule(Type tGene, Type tGenerics, object[] arguments)
        {
            string methodStr;
            switch (tGene)
            {
                case Type t when t.Equals(typeof(GeneChromosome<,,>)):
                    methodStr = "Reflection_CreateGeneChromosome";
                    break;

                case Type t when t.Equals(typeof(PersistentGene<,>)):
                    methodStr = "Reflection_CreatePersistentGene";
                    break;

                default:
                    throw new Exception();
            }

            return (BIChromosome?)typeof(FChromosome).GetMethod(methodStr)?.
               MakeGenericMethod(tGenerics).Invoke(null, arguments);
        }

        public static BIGene[]? Reflection_CreateEmptyArray<T>(int size)
        {
            return new IGene<T>[size];
        }

        public BIGene[]? CreateEmptyArray(Type tGene, int size)
        {
           
            return (BIGene[]?)typeof(FGeneCapsule).GetMethod("Reflection_CreateEmptyArray")?.
               MakeGenericMethod(new Type[] { tGene }).
               Invoke(null, new object[] { size});
        }
    }
}
