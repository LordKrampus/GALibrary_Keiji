using GA.Factories;
using GA.Structures.Capsules;
using GA.Structures.Generics;
using GA.Structures.Integer;
using GA.Structures;
using GA.Structures.Binaries;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using GA.Utilities;
using System;
using System.Drawing;

namespace GA.Factories
{
    public class FChromosome 
    {
        private static FChromosome _instance;

        public static FChromosome Instance => _instance ??= new FChromosome();

        private FChromosome() { }

        public static ContainerChromosome<T, E> Reflection_CreateContainerChromosome<T, E>(T[] genes)
            where T : GeneChromosome<E> where E : BIChromosome
        {
            return new ContainerChromosome<T, E>(genes);
        }

        public BIChromosome? CreateContainerChromosome(Type tGenes, Type tGenesValue, BIGene[] genes)
        {
            return (BIChromosome?)typeof(FChromosome).GetMethod("Reflection_CreateContainerChromosome")?.
                MakeGenericMethod(new Type[] { tGenes, tGenesValue }).Invoke(null, new object[] { genes });
        }

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
