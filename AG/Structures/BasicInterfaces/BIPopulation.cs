using GA.Structures.Interfaces;
using System;

namespace GA.Structures.BasicInterfaces
{
    public interface BIPopulation
    {
        public BIIndividual[] ObjIndividuals { get; }

        public int Size { get; }
        public bool BiggerIsBest { get; }

        public int Generation { get; set; }
        public double Mean { get; }

        public new object Clone();
    }
}
