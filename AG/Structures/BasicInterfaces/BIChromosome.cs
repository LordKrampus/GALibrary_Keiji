using GALibrary.Structures.BasicInterfaces;

namespace GA.Structures.Interfaces
{
    public interface BIChromosome : BIGeneric
    {
        public BIGene[] ObjGenes { get; set; }

        public double Value { get; }
        public double MaxValue { get; }
        public int Count { get; }
    }
}
