using GA.Structures.Generics;
using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Integer
{
    public class IntegerGene : Gene<int>
    {
        public IntegerGene(int value) : base(value) { }

        public override Gene<int> Generate()
        {
            return new IntegerGene(base._value);
        }
    }
}
