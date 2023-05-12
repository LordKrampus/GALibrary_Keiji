using GALibrary.Structures.BasicInterfaces;
namespace GA.Structures.BasicInterfaces
{
    public interface BITargetChromosome : BIGeneric
    {
        public int Target { get; }
        public double[] Values { get; }
        public double[] MaxValues { get; }
    }
}
