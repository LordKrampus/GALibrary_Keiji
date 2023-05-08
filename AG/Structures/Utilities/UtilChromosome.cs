using GA.Structures.Capsules;
using GA.Structures.Integer;
using GA.Structures.Capsules;
using GA.Structures.Interfaces;
using GA.Utilities;
using System;

namespace GA.Structures.Utilities
{
    public static class UtilChromosome
    {
        public static void InvertValueInChromossome<T, E, F>(T chromosome, int point, F value)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            chromosome.Genes[point].Value = value;
            //return chromosome;
        }

        public static void InvertValueInGenes<E, F>(E[] genes, int point, F value)
            where E : IGene<F>
        {
            genes[point].Value = value;
            //return chromosome;
        }

        public static void InvertChromosomeInSequence<T, E, F>(T[] sequence, int pointA, int pointB)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            T aux = sequence[pointB];
            sequence[pointB] = sequence[pointA];
            sequence[pointA] = aux;
        }

        public static void SwapSectionInChromosome<T, E, F>(T chromosome, int slicePoint, E[] genes, int genesCount)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            for (int i = 0; i < genesCount; i++)
            {
                chromosome.Genes[slicePoint + i] = genes[i];
            }
        }

        public static void SwapSectionInChromosome<E, F>(E[] genes, int slicePoint, E[] section, int genesCount)
            where E : IGene<F>
        {
            for (int i = 0; i < genesCount; i++)
            {
                genes[slicePoint + i] = section[i];
            }
        }

        /*
        public static void DistributeSequenceContainers<T, E, F, G>(T[] containers, out E[][] sequence) 
            where T : GeneChromosome<DynamicChromosome<E, F, G>> where E : PersistentGene<F>
            where F : GeneChromosome<G> where G : BIChromosome 
        {
            int valuesCount, containersCount = containers.Length;
            sequence = new E[containersCount][];

            for(int i = 0; i < containersCount; i++)
            {
                valuesCount = containers[i].Value.Genes.Length;
                sequence[i] = new E[valuesCount];

                for (int e = 0; e < valuesCount; e++)
                    sequence[i][e] = containers[i].Value.Genes[e];
            }
        }

        public static void DistributeSequenceContainers<T, E, F, G>(E[][] sequence, ref T[] containers)
             where T : GeneChromosome<DynamicChromosome<E, F, G>> where E : PersistentGene<F>
             where F : GeneChromosome<G> where G : BIChromosome
        {
            int containersCount = sequence.Length;
            containers = new T[containersCount];

            for (int i = 0; i < containersCount; i++)
            {
                containers[i].Value.Clear();
                containers[i].Value.AddGenes(sequence[i]);
            }
        }
        */

        /*
        public static void SwapSectionInSequence<T>(T[] sequence, int slicePoint, T[] chromosomes,
            int chromSize) where T : IChromosome
        {
            for (int i = 0; i < chromSize; i++)
            {
                sequence[slicePoint + i] = chromosomes[i];
            }
        }
        */

        /*
        public static void SwapInverseSectionInChromosome<T>(T chromosome, int slicePoint, IGene[] genes,
            int genesCount) where T : IChromosome
        {
            for (int i = 0; i < slicePoint; i++)
            {
                chromosome.Genes[i] = genes[i];
            }

            //return chromosome;
        }
        */

        /*
        public static void SplitSectionsInChromosome<T>(T chromosome, int chromosomeSize, int slicePoint, out object[][] sections)
            where T : IChromosome
        {
            sections = new object[2][];

            sections[0] = new object[slicePoint];
            sections[1] = new object[chromosomeSize - slicePoint];

            int i = 0;
            for (; i < sections[0].Length; i++)
                sections[0][i] = chromosome.Genes[i];

            for (i = 0; i < sections[1].Length; i++)
            {
                sections[1][i] = chromosome.Genes[i + slicePoint];
            }
        }
        */


        public static void SplitSectionsInChromosome<T, E, F>(T chromosome, int chromosomeSize, int slicePoint, out E[][] sections)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            sections = new E[2][];

            sections[0] = new E[slicePoint];
            sections[1] = new E[chromosomeSize - slicePoint];

            int i = 0;
            for (; i < sections[0].Length; i++)
                sections[0][i] = chromosome.Genes[i];

            for (i = 0; i < sections[1].Length; i++)
            {
                sections[1][i] = chromosome.Genes[i + slicePoint];
            }
        }

        public static void SplitSectionsInGenes<E, F>(E[] genes, int chromosomeSize, int slicePoint, out E[][] sections)
             where E : IGene<F>
        {
            sections = new E[2][];

            sections[0] = new E[slicePoint];
            sections[1] = new E[chromosomeSize - slicePoint];

            int i = 0;
            for (; i < sections[0].Length; i++)
                sections[0][i] = genes[i];

            for (i = 0; i < sections[1].Length; i++)
            {
                sections[1][i] = genes[i + slicePoint];
            }
        }

        /*
        public static void SplitSectionsInSequence<T>(T[] sequence, int seqSize, int slicePoint, out T[][] sections)
            where T : IChromosome
        {
            sections = new T[2][];

            sections[0] = new T[slicePoint];
            sections[1] = new T[seqSize - slicePoint];

            int i = 0;
            for (; i < sections[0].Length; i++)
                sections[0][i] = sequence[i];

            for (i = 0; i < sections[1].Length; i++)
            {
                sections[1][i] = sequence[i + slicePoint];
            }
        }
        */

        public static void SplitSectionsInChromosome<T, E, F>(T chromosome, int chromosomeSize, int[] slicePoints, int slicePointCount, out E[][] sections)
            where T : IChromosome<E, F> where E : IGene<F>
        {
            sections = new E[slicePointCount + 1][];

            int i = 0, e = 0;
            int lastSlicePoint = 0;
            for (i = 0; i < slicePointCount; i++)
            {
                sections[i] = new E[slicePoints[i] - lastSlicePoint];

                for (e = 0; e < sections[i].Length; e++)
                    sections[i][e] = chromosome.Genes[e + lastSlicePoint];

                lastSlicePoint = slicePoints[i];
            }

            sections[i] = new E[chromosomeSize - lastSlicePoint];
            for (e = 0; e < sections[i].Length; e++)
                sections[i][e] = chromosome.Genes[e + lastSlicePoint];
        }

        public static void SortSequence(BIGene[] sequence, out BIGene[] sortSeq)
        {
            Sorter sorter = new Sorter();
            int sort;

            int size = sequence.Length;
            List<BIGene> list = new List<BIGene>(sequence);
            sortSeq = new BIGene[size];

            for (int i = 0; i < size; i++)
            {
                sort = sorter.SortBefore(list.Count - 1);
                sortSeq[i] = list.ElementAt(sort);
                list.RemoveAt(sort);
            }
        }

    }
}
