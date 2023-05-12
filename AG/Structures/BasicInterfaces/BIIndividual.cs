using GA.Structures.Interfaces;
using GALibrary.Structures.BasicInterfaces;

namespace GA.Structures.BasicInterfaces
{
    public interface BIIndividual : BIGeneric
    {
        public BIChromosome ObjChromosome { get; }

        public double Value { get; }
        public int Size { get; }
        public double Fitness { get; set; }
    }
}
