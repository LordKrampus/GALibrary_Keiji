using GA.Structures.Interfaces;

using GA.Structures.Integer;
using GA.Structures.Binaries;
using GALibrary.Factories;

namespace GA.Factories
{
    public class FChromosome : IFactory
    {
        private static FChromosome _instance;

        public static FChromosome Instance => _instance ??= new FChromosome();

        private FChromosome() { }

        public object? CreateItem(Type type, Type[] tGenerics, object[] arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryChromosome)):
                    return new BinaryChromosome((BinaryGene[])arguments[0]);

                case Type t when t.Equals(typeof(TargetBinaryChromosome)):
                    return new TargetBinaryChromosome((BinaryGene[])arguments[0], (int)arguments[1]);

                case Type t when t.Equals(typeof(IntegerChromosome)):
                    return new IntegerChromosome((IntegerGene[])arguments[0], maxValue: (int)arguments[1]);

                default:
                    throw new ArgumentException();
            }
        }

        public static object[] Reflection_CreateEmptyArray<T, E>(Type type, int size) where T : IGene<E>
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryChromosome)):
                    return new BinaryChromosome[size] ;

                case Type t when t.Equals(typeof(TargetBinaryChromosome)):
                    return new TargetBinaryChromosome[size];

                case Type t when t.Equals(typeof(IntegerChromosome)):
                    return new IntegerChromosome[size];

                default:
                    throw new ArgumentException();
            }

            return new IChromosome<T, E>[size];
        }

        public object[]? CreateEmptyArray(Type type, Type[] tGenerics, int size)
        {
            return (BIChromosome[]?)typeof(FChromosome).GetMethod("Reflection_CreateEmptyArray")?.
                MakeGenericMethod(tGenerics).Invoke(null, new object[] { type, size });
        }

    }
}
