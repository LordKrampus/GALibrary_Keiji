using GA.Structures.BasicInterfaces;
using GA.Structures.Individuals;
using GA.Structures.Interfaces;

namespace GA.Functions.Interfaces
{
    public interface IFunction
    {
        public double[] Factors { get; set;  }
        public bool IsMinimization { get; set; }

        public void ApplyFactor(double[] a, out double[] b);

        public double Calc(object[] variables, bool applyFactor = true);

        public double Calc(BIIndividual individual);
    }
}
