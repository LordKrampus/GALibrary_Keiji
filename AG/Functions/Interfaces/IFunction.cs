using GA.Structures.BasicInterfaces;
using GA.Structures.Individuals;
using GA.Structures.Interfaces;

namespace GA.Functions.Interfaces
{
    public interface IFunction
    {
        public double[] Factor { get; set;  }

        public void ApplyFactor(double[] a, out double[] b);

        public double Calc(object[] variables, bool applyFactor = true);

        public double Calc(BIIndividual individual);

        //public double Calc<T, E, F>(Individual<T, E, F> individual) where T : IChromosome<E, F> where E : IGene<F>;

        // f(x) : y
        //public void Calc(double x, out double y, bool applyFactor = true);

        // f(x, y) : z
        //public void Calc(double x, double y, out double z, bool applyFactor = true);
    }
}
