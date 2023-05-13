﻿using System;
using GA.Structures.Generics;
using GA.Structures.Interfaces;

namespace GA.Structures.Binaries
{
    public class BinaryGene : Gene<bool>
    {
        public BinaryGene(bool value) : base(value) { }

        public override object New(object[] arguments)
        {
            return new BinaryGene(this.Value);
        }

        public override string ToString()
        {
            int b;
            Util.BooltoInt((bool)this.Value, out b);
            return $"{b}";
        }
    }
}
