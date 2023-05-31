using GA.Structures.BasicInterfaces;
using GA.Structures.Individuals;
using GA.Structures.Interfaces;

namespace GA.Functions.Interfaces
{
    public interface IFunction
    {
        public double[] Parameters { get; set; }
        public double[] Scales { get; set;  }
        public double[] LInfs { get; set; }
        public double[] LSups{ get; set; }
        public bool IsMinimization { get; set; }
        public bool ApplyRestrictions { get; set; }

        public void ApplyScales(double[] a, out double[] b);

        public double Calc(object[] variables, bool applyFactor = true);

        public double Calc(BIIndividual individual);
    }
}
