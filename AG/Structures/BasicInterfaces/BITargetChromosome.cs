using System;

namespace GA.Structures.BasicInterfaces
{
    public interface BITargetChromosome
    {
        public int Target { get; }
        public double[] Values { get; }
        public double[] MaxValues { get; }
    }
}
