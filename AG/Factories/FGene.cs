using GA.Structures.Interfaces;

using GA.Structures.Integer;
using GA.Structures.Binaries;

namespace GA.Factories
{
    public class FGene
    {
        private static FGene _instance;

        private FGene() { }

        public static FGene Instance => _instance ??= new FGene();

        public BIGene CreateGene(Type tGene, Type tValue, object value)
        {
            switch (tGene)
            {
                case Type t when t.Equals(typeof(BinaryGene)):
                    return new BinaryGene((bool)value);

                case Type t when t.Equals(typeof(IntegerGene)):
                    return new IntegerGene((int)value);

                default:
                    throw new Exception();
            }
        }

        public static IGene<T>[]? Reflection_CreateEmptyArray<T>(Type tGene, int size)
        {
            switch (tGene)
            {
                case Type t when t.Equals(typeof(BinaryGene)):
                    return new BinaryGene[size] as IGene<T>[];

                case Type t when t.Equals(typeof(IntegerGene)):
                    return new IntegerGene[size] as IGene<T>[];

                default:
                    throw new Exception();
            }
        }

        public BIGene[]? CreateEmptyArray(Type tGene, Type tValue, int size)
        {
            return (BIGene[]?)typeof(FGene).GetMethod("Reflection_CreateEmptyArray")?.
                MakeGenericMethod(tValue).Invoke(null, new object[] { tGene, size });
        }
    }
}
