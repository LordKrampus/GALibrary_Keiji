using GA.Structures.Capsules;
using GA.Structures.Generics;
using GA.Structures.Integer;
using GA.Factories;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using System;

namespace GA.Factories
{
    public class FGene
    {
        private static FGene _instance;

        private FGene() { }

        public static FGene Instance => _instance ??= new FGene();

        public static BIGene Reflection_CreatePersistentGene<T>(T value, int persistence)
        {
            return new PersistentGene<T>(value, persistence);
        }

        public BIGene? CreatePersistentGene(Type tValue, object value, int persistence)
        {
            return (BIGene?)typeof(FGene).GetMethod("Reflection_CreatePersistentGene")?.
               MakeGenericMethod(tValue).Invoke(null, new object[] { value, persistence});
        }

        public static BIGene Reflection_CreateGeneChromosome<T>(T value)
        {
            return new GeneChromosome<T>(value);
        }

        public BIGene? CreateGeneChromosome(Type tValue, object value)
        {
            return (BIGene?)typeof(FGene).GetMethod("Reflection_CreateGeneChromosome")?.
                MakeGenericMethod(tValue).Invoke(null, new object[] { value });
        }


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

                case Type t when t.Equals(typeof(PersistentGene<>)):
                    return new PersistentGene<T>[size] as IGene<T>[];

                case Type t when t.Equals(typeof(GeneChromosome<>)):
                    return new GeneChromosome<T>[size] as IGene<T>[];

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
