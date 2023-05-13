using GA.Structures.Generics;
using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Integer
{
    public class IntegerGene : Gene<int>
    {
        public IntegerGene(int value) : base(value) { }

        public override object New(object[] arguments)
        {
            return new IntegerGene(base._value);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
