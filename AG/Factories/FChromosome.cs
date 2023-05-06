using GA.Structures.Interfaces;

using GA.Structures.Integer;
using GA.Structures.Binaries;

namespace GA.Factories
{
    public class FChromosome 
    {
        private static FChromosome _instance;

        public static FChromosome Instance => _instance ??= new FChromosome();

        private FChromosome() { }

        public object? GenerateChromosome(Type tChromosome, BIGene[] genes, object[] arguments)
        {
            switch (tChromosome)
            {
                case Type t when t.Equals(typeof(BinaryChromosome)):
                    return new BinaryChromosome(genes as BinaryGene[]);

                case Type t when t.Equals(typeof(TargetBinaryChromosome)):
                    return new TargetBinaryChromosome(genes as BinaryGene[], (int)arguments[0]);
                case Type t when t.Equals(typeof(IntegerChromosome)):
                    return new IntegerChromosome(genes as IntegerGene[], maxValue: (int)arguments[0]);

                default:
                    throw new ArgumentException();
            }
        }

        public static IChromosome<T, E>[] Reflection_CreateEmptyArray<T, E>(int size) where T : IGene<E>
        {
            return new IChromosome<T, E>[size];
        }

        public BIChromosome[]? CreateEmptyArray(Type tGene, Type tGeneValue, int size)
        {
            return (BIChromosome[]?)typeof(FChromosome).GetMethod("Reflection_CreateEmptyArray")?.
                MakeGenericMethod(new Type[] { tGene, tGeneValue }).Invoke(null, new object[] { size });
        }

    }
}
