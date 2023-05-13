using System;
using GA.Structures.Generics;

namespace GALibrary.Structures.Real
{
    public class RealGene : Gene<double>
    {
        public RealGene(double value) : base(value)
        { }

        public override object New(object[] arguments)
        {
            return this.Value;
        }
    }
}
