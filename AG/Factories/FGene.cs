using GA.Structures.Interfaces;

using GA.Structures.Integer;
using GA.Structures.Binaries;
using GALibrary.Factories;
using GALibrary.Structures.Real;

namespace GA.Factories
{
    public class FGene : IFactory
    {
        private static FGene _instance;

        private FGene() { }

        public static FGene Instance => _instance ??= new FGene();

        public object CreateItem(Type type, Type[] tGenerics, object[] arguments)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryGene)):
                    return new BinaryGene((bool)arguments[0]);

                case Type t when t.Equals(typeof(IntegerGene)):
                    return new IntegerGene((int)arguments[0]);

                case Type t when t.Equals(typeof(RealGene)):
                    return new RealGene((double)arguments[0]);

                default:
                    throw new Exception();
            }
        }

        public static IGene<T>[]? Reflection_CreateEmptyArray<T>(Type type, int size)
        {
            switch (type)
            {
                case Type t when t.Equals(typeof(BinaryGene)):
                    return new BinaryGene[size] as IGene<T>[];

                case Type t when t.Equals(typeof(IntegerGene)):
                    return new IntegerGene[size] as IGene<T>[];

                case Type t when t.Equals(typeof(RealGene)):
                    return new RealGene[size] as IGene<T>[];

                default:
                    throw new Exception();
            }
            //return new IGene<T>[size];
        }

        public object[]? CreateEmptyArray(Type type, Type[] tGenerics, int size)
        {
            return (object[]?)typeof(FGene).GetMethod("Reflection_CreateEmptyArray")?.
                MakeGenericMethod(tGenerics).Invoke(null, new object[] { type, size });
        }
    }
}
