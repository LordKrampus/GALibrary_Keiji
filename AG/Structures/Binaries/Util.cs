using System;
using System.Runtime.CompilerServices;
using GA.Structures.Interfaces;

namespace GA.Structures.Binaries
{
    public static class Util
    {
        public static void InttoBool(int a, out bool b)
        {
            b = (a < 1 ? false : true);
        }

        public static void BooltoInt(bool a, out int b)
        {
            b = ( a ? 1: 0);
        }

        public static void InttoBinaryGene(int value, out BinaryGene[] genes)
        {
            int sum = 0;
            int count = (int)Math.Ceiling(Math.Sqrt(value));
            genes = new BinaryGene[count];

            int pow;
            int size = count - 1;
            for (int i = 0; i < count; i++)
            {
                pow = (int)Math.Pow(2, size - i);
                if (sum + pow <= value)
                {
                    sum += pow;
                    genes[i] = new BinaryGene(true);
                }
                else
                {
                    genes[i] = new BinaryGene(false);
                }
            }
        }

    } // end : class (Gene : IGene)

} // end : namespace (.Binary)
