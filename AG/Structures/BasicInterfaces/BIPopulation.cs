using GALibrary.Structures.BasicInterfaces;

namespace GA.Structures.BasicInterfaces
{
    public interface BIPopulation : BIGeneric
    {
        public BIIndividual[] ObjIndividuals { get; }

        public int Count { get; }
        public bool BiggerIsBest { get; }

        public BIIndividual ObjBestIndividual { get; }
        public int Generation { get; set; }
        public double Mean { get; }
    }
}
