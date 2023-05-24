using System;
using System.Text;
using GA.Structures.Generics;
using GA.Structures.Integer;

namespace GALibrary.Structures.Real
{
    public class RealGene : Gene<double>
    {
        public RealGene(double value) : base(value)
        { }

        public override object New(object[] arguments)
        {
            return new RealGene(this.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
