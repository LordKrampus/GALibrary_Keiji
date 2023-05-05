using GA.Structures.Capsules;
using GA.Structures.Generics;
using GA.Structures.Interfaces;
using System;

namespace GA.Structures.Capsules
{
    public class PersistentGene<T> : Gene<T> 
    {
        private int _persistence;

        public int Persistence => this._persistence;

        public PersistentGene(T value, int persistence) : base (value)
        {
            this._persistence = persistence;
        }

        public override PersistentGene<T> Generate()
        {
            return new PersistentGene<T>(base._value, this._persistence);
        }

        public override string ToString()
        {
            return base.ToString() + $" ({Persistence})";
        }
    }
}